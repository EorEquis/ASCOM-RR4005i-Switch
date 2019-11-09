
' --------------------------------------------------------------------------------
'
' ASCOM Switch driver for RR4005i
'
' Description:	An ASCOM Switch driver to allow management of the West Mountain 
'				Radio RIGRunner 4005i.
'				http://www.westmountainradio.com/product_info.php?products_id=rr_4005i 
'
' Implements:	ASCOM Switch interface version: 1.0
'
' Edit Log:
'
' See https://github.com/EorEquis/RR4005i-Switch
'
' Your driver's ID is ASCOM.RR4005i.Switch
'
' The Guid attribute sets the CLSID for ASCOM.DeviceName.Switch
' The ClassInterface/None addribute prevents an empty interface called
' _Switch from being created and used as the [default] interface
'

' This definition is used to select code that's only applicable for one device type

#Const Device = "Switch"

Imports System.Threading
Imports ASCOM
Imports ASCOM.Astrometry
Imports ASCOM.Astrometry.AstroUtils
Imports ASCOM.DeviceInterface
Imports ASCOM.Utilities

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.Xml


<Guid("da08b3e4-17f3-49f5-96bf-8e7ec2910459")> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class Switch

    ' The Guid attribute sets the CLSID for ASCOM.RR4005i.Switch
    ' The ClassInterface/None addribute prevents an empty interface called
    ' _RR4005i from being created and used as the [default] interface

    Implements ISwitchV2

#Region "Variables"

    ' Driver ID and descriptive string that shows in the Chooser
    Friend Shared driverID As String = "ASCOM.RR4005i.Switch"
    Private Shared driverDescription As String = "RR4005i Switch"

    'Constants used for Profile persistence

    Friend Shared traceStateProfileName As String = "Trace Level"
    Friend Shared comPortDefault As String = "COM1"
    Friend Shared traceStateDefault As String = "False"
    Friend Shared IPProfileName As String = "IP Address"
    Friend Shared IPDefault As String = "0.0.0.0"
    Friend Shared portNamesProfileName As String = "Port Name"
    Friend Shared portNameDefault(24) As String ' Filled later in constructor
    Friend Shared deviceNameProfileName As String = "Device Name"
    Friend Shared deviceNameDefault As String = "RR4005i"
    Friend Shared numberOfUnitsProfileName As String = "Number Of Units"
    Friend Shared numberOfUnitsDefault As String = "1"
    Friend Shared maxSwitchesProfileName As String = "Max Switches"
    Friend Shared maxSwitchesDefault As String = "5"
    Friend Shared fetchNamesProfileName As String = "Fetch Port Names"
    Friend Shared fetchNamesDefault As String = "True"

    ' Variables to hold the currrent device configuration

    Friend Shared traceState As Boolean
    Friend Shared RRIP(4) As String
    Friend Shared PortNames(24) As String
    Friend Shared DeviceNames(4) As String
    Friend Shared NumUnits As Integer
    Friend Shared bFetchNames As Boolean
    Friend Shared numSwitches As Integer

    Private connectedState As Boolean ' Private variable to hold the connected state
    Private utilities As Util ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)

#End Region

#Region "Constructor"

    ' Constructor - Must be public for COM registration!
    Public Sub New()

        ReadProfile() ' Read device configuration from the ASCOM Profile store
        TL = New TraceLogger("", "RR4005i")
        TL.Enabled = traceState
        TL.LogMessage("Switch", "Starting initialisation")

        connectedState = False ' Initialise connected to false
        utilities = New Util() ' Initialise util object
        astroUtilities = New AstroUtils 'Initialise new astro utiliites object

        ' Basically just laziness.  I didn't want to type all 25 default port names.
        For i As Integer = 0 To 24
            portNameDefault(i) = "Port " & (i + 1).ToString
        Next
        TL.LogMessage("Switch", "Completed initialisation")
    End Sub

#End Region

#Region "Common properties and methods"

    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements ISwitchV2.SetupDialog
        ' consider only showing the setup dialog if not connected
        ' or call a different dialog if connected
        If IsConnected Then
            System.Windows.Forms.MessageBox.Show("Already connected, just press OK")
        End If

        Using F As SetupDialogForm = New SetupDialogForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                WriteProfile() ' Persist device configuration values to the ASCOM Profile store
            End If
        End Using
    End Sub

    Public ReadOnly Property SupportedActions() As ArrayList Implements ISwitchV2.SupportedActions
        Get
            TL.LogMessage("SupportedActions Get", "Returning empty arraylist")
            Return New ArrayList()
        End Get
    End Property

    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements ISwitchV2.Action
        Throw New ActionNotImplementedException("Action " & ActionName & " is not supported by this driver")
    End Function

    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements ISwitchV2.CommandBlind
        CheckConnected("CommandBlind")
        Dim webclient As New System.Net.WebClient, result As String
        Dim webMutex As Mutex   ' Very simple multithreading.  Don't need anything complicated, since there's no serial comms w/ the RR4005i
        webMutex = New Mutex(False, "RRMutex")
        webMutex.WaitOne()
        Try
            result = webclient.DownloadString(Command)
        Catch ex As Exception
            TL.LogMessage("CommandBlind", "Error Sending Command " & Command & " : " & ex.Message)
        Finally
            webMutex.ReleaseMutex()
        End Try
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements ISwitchV2.CommandBool
        ' Nothing we'll use returns a boolean, not implemented
        Throw New MethodNotImplementedException("CommandBool")
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String _
        Implements ISwitchV2.CommandString
        CheckConnected("CommandString")
        Dim document As New XmlDocument, reader As New XmlTextReader(Command)
        Dim webMutex As Mutex   ' Very simple multithreading.  Don't need anything complicated, since there's no serial comms w/ the RR4005i
        webMutex = New Mutex(False, "RRMutex")
        webMutex.WaitOne()
        Try
            document.Load(reader)
            Return document.InnerXml.ToString()
        Catch ex As Exception
            TL.LogMessage("CommandBool", "Error Sending Command " & Command & " : " & ex.Message)
            Return ""
        Finally
            webMutex.ReleaseMutex()
        End Try
    End Function

    Public Property Connected() As Boolean Implements ISwitchV2.Connected
        Get
            TL.LogMessage("Connected Get", IsConnected.ToString())
            Return IsConnected
        End Get
        Set(value As Boolean)
            TL.LogMessage("Connected Set", value.ToString())
            If value = IsConnected Then
                Return
            End If

            If value Then

                '**********************************
                ' We should be able to handle both reading the port names and verifying connectivity in one step
                ' TODO : This presumes firmware 1.14 or later, should probably modify this to account for earlier devices
                '**********************************
                Dim webclient As New System.Net.WebClient, result As String, splitChar As String = vbCrLf, index As Integer
                For i As Integer = 0 To NumUnits - 1
                    Try
                        result = webclient.DownloadString("http://" & RRIP(i) & "/settings.cgi")
                        If bFetchNames Then
                            Dim strAry() As String = result.Split(splitChar)
                            For Each line As String In strAry
                                line = Replace(line, vbLf, String.Empty)
                                If line.StartsWith("RAILSTR") Then
                                    index = CInt(line.Substring(7, 1))
                                    PortNames(index + (i * 5)) = line.Substring(9)
                                    If index = 4 Then
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                        TL.LogMessage("Connected Set", "Connected to RIGRunner at " & RRIP(i))
                        connectedState = True
                    Catch ex As Exception
                        TL.LogMessage("Connected Set", "Error connecting to RigRunner at " & RRIP(i))
                    End Try
                Next

            Else
                connectedState = False
                WriteProfile() ' Persist device configuration values to the ASCOM Profile store
                If NumUnits > 1 Then
                    TL.LogMessage("Connected Set", "Disconnected from RigRunners")
                Else
                    TL.LogMessage("Connected Set", "Disconnected from RigRunner")
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property Description As String Implements ISwitchV2.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            TL.LogMessage("Description Get", d)
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverInfo As String Implements ISwitchV2.DriverInfo
        Get
            Dim m_version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
            Dim s_driverInfo As String = "ASCOM Switch Driver for West Mountain Radio's RIGRunner 4005i. Version: " + m_version.Major.ToString() + "." + m_version.Minor.ToString()
            TL.LogMessage("DriverInfo Get", s_driverInfo)
            Return s_driverInfo
        End Get
    End Property

    Public ReadOnly Property DriverVersion() As String Implements ISwitchV2.DriverVersion
        Get
            ' Get our own assembly and report its version number
            TL.LogMessage("DriverVersion Get", Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2))
            Return Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2)
        End Get
    End Property

    Public ReadOnly Property InterfaceVersion() As Short Implements ISwitchV2.InterfaceVersion
        Get
            TL.LogMessage("InterfaceVersion Get", "2")
            Return 2
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ISwitchV2.Name
        Get
            Dim s_name As String = "ASCOM RIGRunner 4005i Switch Driver"
            TL.LogMessage("Name Get", s_name)
            Return s_name
        End Get
    End Property

    Public Sub Dispose() Implements ISwitchV2.Dispose
        ' Clean up the tracelogger and util objects
        TL.Enabled = False
        TL.Dispose()
        TL = Nothing
        utilities.Dispose()
        utilities = Nothing
        astroUtilities.Dispose()
        astroUtilities = Nothing
    End Sub

#End Region

#Region "ISwitchV2 Implementation"

    ''' <summary>
    ''' The number of switches managed by this driver
    ''' </summary>
    Public ReadOnly Property MaxSwitch As Short Implements ISwitchV2.MaxSwitch
        Get
            TL.LogMessage("MaxSwitch Get", numSwitches.ToString())
            Return numSwitches
        End Get
    End Property

    ''' <summary>
    ''' Return the name of switch n
    ''' </summary>
    ''' <param name="id">The switch number to return</param>
    ''' <returns>The name of the switch</returns>
    Public Function GetSwitchName(id As Short) As String Implements ISwitchV2.GetSwitchName
        Validate("GetSwitchName", id)
        TL.LogMessage("GetSwitchName", PortNames(id))
        Return PortNames(id)
    End Function

    ''' <summary>
    ''' Sets a switch name to a specified value
    ''' </summary>
    ''' <param name="id">The number of the switch whose name is to be set</param>
    ''' <param name="name">The name of the switch</param>
    Sub SetSwitchName(id As Short, name As String) Implements ISwitchV2.SetSwitchName
        'Not implemented : not allowing client to set port names
        TL.LogMessage("SetSwitchName", "Not Implemented")
        Throw New ASCOM.MethodNotImplementedException("SetSwitchName")
    End Sub

    ''' <summary>
    ''' Gets the description of the specified switch. This is to allow a fuller description of
    ''' the switch to be returned, for example for a tool tip.
    ''' </summary>
    ''' <param name="id">The number of the switch whose description is to be returned</param><returns></returns>
    ''' <exception cref="MethodNotImplementedException">If the method is not implemented</exception>
    ''' <exception cref="InvalidValueException">If id is outside the range 0 to MaxSwitch - 1</exception>
    Public Function GetSwitchDescription(id As Short) As String Implements ISwitchV2.GetSwitchDescription
        ' Just return the switch name for now : TODO - Implement longer desc?
        Validate("GetSwitchDescription", id)
        TL.LogMessage("GetSwitchDescription", PortNames(id))
        Return PortNames(id)
    End Function

    ''' <summary>
    ''' Reports if the specified switch can be written to.
    ''' This is false if the switch cannot be written to, for example a limit switch or a sensor.
    ''' The default is true.
    ''' </summary>
    ''' <param name="id">The number of the switch whose write state is to be returned</param><returns>
    '''   <c>true</c> if the switch can be set, otherwise <c>false</c>.
    ''' </returns>
    ''' <exception cref="MethodNotImplementedException">If the method is not implemented</exception>
    ''' <exception cref="InvalidValueException">If id is outside the range 0 to MaxSwitch - 1</exception>
    Public Function CanWrite(id As Short) As Boolean Implements ISwitchV2.CanWrite
        ' Always return true.  All ports on the rigrunner can be turned on or off
        Validate("CanWrite", id)
        TL.LogMessage("CanWrite", "Default true")
        Return True
    End Function

#Region "boolean members"
    ''' <summary>
    ''' Return the state of switch n as a boolean
    ''' A multi-value switch must throw a MethodNotImplementedException.
    ''' </summary>
    ''' <param name="id">The switch number to return</param>
    ''' <returns>True or false</returns>
    Function GetSwitch(id As Short) As Boolean Implements ISwitchV2.GetSwitch
        Validate("GetSwitch", id, True)

        Dim xmld As New XmlDocument, result As Boolean

        xmld.LoadXml(CommandString("http://" & RRIP(id \ 5) & "/status.xml"))
        result = convertInt(CInt(xmld.SelectSingleNode("/rr4005i/RAILENA" & (id Mod 5).ToString).InnerText))
        TL.LogMessage("GetSwitch", "id " & id.ToString & " : " & result.ToString)
        Return result
    End Function

    ''' <summary>
    ''' Sets a switch to the specified state, true or false.
    ''' If the switch cannot be set then throws a MethodNotImplementedException.
    ''' A multi-value switch must throw a MethodNotImplementedException.
    ''' </summary>
    ''' <param name="ID">The number of the switch to set</param>
    ''' <param name="State">The required switch state</param>
    Sub SetSwitch(id As Short, state As Boolean) Implements ISwitchV2.SetSwitch
        Validate("SetSwitch", id, True)
        CommandBlind("http://" & RRIP(id \ 5) & "/index.htm?RAILENA" & (id Mod 5).ToString & "=" & convertBool(state))
        TL.LogMessage("SetSwitch", "Set switch " & id.ToString & " to " & state.ToString)
    End Sub
#End Region

#Region "Analogue members"
    ' Forcing these to be implemented is silly, but here we are.  ASCOM requires these to not throw a MethodNotImplementedException
    ' so we'll just hardcode 0.0 and 1.0 values, regardless of the ID, per the documentation

    ''' <summary>
    ''' returns the maximum analogue value for this switch
    ''' boolean switches must return 1.0
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function MaxSwitchValue(id As Short) As Double Implements ISwitchV2.MaxSwitchValue
        Validate("MaxSwitchValue", id)
        TL.LogMessage("MaxSwitchValue", "1.0")
        Return 1.0
    End Function

    ''' <summary>
    ''' returns the minimum analogue value for this switch
    ''' boolean switches must return 0.0
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function MinSwitchValue(id As Short) As Double Implements ISwitchV2.MinSwitchValue
        Validate("MinSwitchValue", id)
        TL.LogMessage("MinSwitchValue", "0.0")
        Return 0.0
    End Function

    ''' <summary>
    ''' returns the step size that this switch supports. This gives the difference between
    ''' successive values of the switch.
    ''' The number of values is ((MaxSwitchValue - MinSwitchValue) / SwitchStep) + 1
    ''' boolean switches must return 1.0, giving two states.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function SwitchStep(id As Short) As Double Implements ISwitchV2.SwitchStep
        Validate("SwitchStep", id)
        TL.LogMessage("SwitchStep", "1.0")
        Return 1.0
    End Function

    ''' <summary>
    ''' returns the analogue switch value for switch id
    ''' boolean switches must throw a MethodNotImplementedException
    ''' 
    ''' 
    ''' Ok, this is fucking brilliant.  The ASCOM documentation at https://ascom-standards.org/Help/Developer/html/M_ASCOM_DeviceInterface_ISwitchV2_GetSwitchValue.htm 
    ''' says specifically : "Must be implemented, must not throw a MethodNotImplementedException."
    ''' But the template says "boolean switches must throw a MethodNotImplementedException"
    ''' WTF
    ''' 
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function GetSwitchValue(id As Short) As Double Implements ISwitchV2.GetSwitchValue
        ' Ok, we're going with the template, and not implementing.  We'll see what breaks.
        TL.LogMessage("GetSwitchValue", "Not Implemented")
        Throw New ASCOM.MethodNotImplementedException("GetSwitchValue")
    End Function

    ''' <summary>
    ''' set the analogue value for this switch.
    ''' If the switch cannot be set then throws a MethodNotImplementedException.
    ''' If the value is not between the maximum and minimum then throws an InvalidValueException
    ''' boolean switches must throw a MethodNotImplementedException
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="value"></param>
    Sub SetSwitchValue(id As Short, value As Double) Implements ISwitchV2.SetSwitchValue
        TL.LogMessage("SetSwitchValue", "Not Implemented")
        Throw New ASCOM.MethodNotImplementedException("SetSwitchValue")
    End Sub

#End Region

#End Region

#Region "Validation Functions"

    ''' <summary>
    ''' Checks that the switch id is in range and throws an InvalidValueException if it isn't
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="id">The id.</param>
    Private Sub Validate(message As String, id As Short)
        If (id < 0 Or id >= numSwitches) Then
            Throw New ASCOM.InvalidValueException(message, id.ToString(), String.Format("0 to {0}", numSwitches - 1))
        End If
    End Sub

    ''' <summary>
    ''' Checks that the number of states for the switch is correct and throws a methodNotImplemented exception if not.
    ''' Boolean switches must have 2 states and multi-value switches more than 2.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="id"></param>
    ''' <param name="expectBoolean"></param>
    Private Sub Validate(message As String, id As Short, expectBoolean As Boolean)
        Validate(message, id)
        Dim ns As Integer = (((MaxSwitchValue(id) - MinSwitchValue(id)) / SwitchStep(id)) + 1)
        If (expectBoolean And ns <> 2) Or (Not expectBoolean And ns <= 2) Then
            TL.LogMessage(message, String.Format("Switch {0} has the wriong number of states", id, ns))
            Throw New MethodNotImplementedException(String.Format("{0}({1})", message, id))
        End If
    End Sub

    ''' <summary>
    ''' Checks that the switch id and value are in range and throws an
    ''' InvalidValueException if they are not.
    ''' </summary>
    ''' <param name="message">The message.</param>
    ''' <param name="id">The id.</param>
    ''' <param name="value">The value.</param>
    Private Sub Validate(message As String, id As Short, value As Double)
        Validate(message, id, False)
        Dim min = MinSwitchValue(id)
        Dim max = MaxSwitchValue(id)
        If (value < min Or value > max) Then
            TL.LogMessage(message, String.Format("Value {1} for Switch {0} is out of the allowed range {2} to {3}", id, value, min, max))
            Throw New InvalidValueException(message, value.ToString(), String.Format("Switch({0}) range {1} to {2}", id, min, max))
        End If
    End Sub

#End Region

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Switch"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()> _
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()> _
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region

#Region "Private properties and methods"

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected As Boolean
        Get
            ' connectedState is set in the Connect method
            Return connectedState
        End Get
    End Property

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

    ''' <summary>
    ''' Read the device configuration from the ASCOM Profile store
    ''' </summary>
    Friend Sub ReadProfile()
        Dim iUnit As Integer, iPort As Integer
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, String.Empty, traceStateDefault))
            NumUnits = driverProfile.GetValue(driverID, numberOfUnitsProfileName, String.Empty, numberOfUnitsDefault)
            numSwitches = driverProfile.GetValue(driverID, maxSwitchesProfileName, String.Empty, maxSwitchesDefault)
            bFetchNames = driverProfile.GetValue(driverID, fetchNamesProfileName, String.Empty, fetchNamesDefault)
            For i As Integer = 0 To NumUnits - 1
                RRIP(i) = driverProfile.GetValue(driverID, IPProfileName, i.ToString, IPDefault)
            Next
            For i As Integer = 0 To numSwitches - 1
                iUnit = i \ 5   ' Calculate the unit number that would hold this port
                iPort = i Mod 5 ' Calculate the port number on that unit
                PortNames(i) = driverProfile.GetValue(driverID, portNamesProfileName, iUnit.ToString & "\" & iPort.ToString, portNameDefault(i))
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Write the device configuration to the  ASCOM  Profile store
    ''' </summary>
    Friend Sub WriteProfile()
        Dim iUnit As Integer, iPort As Integer
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Switch"
            driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString())
            driverProfile.WriteValue(driverID, numberOfUnitsProfileName, NumUnits)
            driverProfile.WriteValue(driverID, maxSwitchesProfileName, NumUnits * 5)
            driverProfile.WriteValue(driverID, fetchNamesProfileName, bFetchNames.ToString)

            For i As Integer = 0 To NumUnits - 1
                driverProfile.WriteValue(driverID, IPProfileName, RRIP(i), i.ToString)
            Next
            For i As Integer = 0 To (NumUnits * 5) - 1
                iUnit = i \ 5   ' Calculate the unit number that would hold this port
                iPort = i Mod 5 ' Calculate the port number on that unit
                driverProfile.WriteValue(driverID, portNamesProfileName, PortNames(i), iUnit.ToString & "\" & iPort.ToString)
            Next
        End Using
    End Sub

#End Region

#Region "My Helper Functions"

    ' There are probably better ways to do these, but this is simple and readable and, well, I'm stupid and lazy, so here we are.

    Friend Shared Function convertBool(value As Boolean) As Integer
        If value Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Friend Shared Function convertInt(value As Integer) As Boolean
        If value = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

End Class
