Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports ASCOM.Utilities
Imports ASCOM.RR4005i
Imports System.Net

<ComVisible(False)> _
Public Class SetupDialogForm

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click ' OK button event handler
        ' Persist new values of user settings to the ASCOM profile
        Dim tb As TextBox, ipstring As String, is_valid As Boolean = True
        Switch.traceState = chkTrace.Checked
        Switch.NumUnits = ddNumUnits.SelectedItem
        For i As Integer = 0 To Switch.NumUnits - 1
            tb = Me.Controls("txtIP" & i.ToString)
            ipstring = tb.Text
            Dim ip As IPAddress
            If Not IPAddress.TryParse(ipstring, ip) Then
                is_valid = False
                Exit For
            Else
                Switch.RRIP(i) = tb.Text
            End If
        Next
        If is_valid Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("IP Address Invalid")
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click 'Cancel button event handler
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ShowAscomWebPage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick, PictureBox1.Click
        ' Click on ASCOM logo event handler
        Try
            System.Diagnostics.Process.Start("http://ascom-standards.org/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub SetupDialogForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load ' Form load event handler
        ' Retrieve current values of user settings from the ASCOM Profile
        InitUI()
    End Sub

    Private Sub InitUI()
        Dim tb As TextBox, lb As Label
        chkTrace.Checked = Switch.traceState
        ddNumUnits.SelectedItem = Switch.NumUnits.ToString
        cbFetchNames.Checked = Switch.bFetchNames
        ' Enable the IP Address text boxes, based on the number of units.
        For i As Integer = 0 To Switch.NumUnits - 1
            tb = Me.Controls("txtIP" & i.ToString)
            lb = Me.Controls("lblIP" & i.ToString)
            tb.Visible = True
            tb.Text = Switch.RRIP(i)
            lb.Visible = True
        Next
        ' Disable the remaining IP Address textboxes based on the number of units
        For i As Integer = Switch.NumUnits To 4
            tb = Me.Controls("txtIP" & i.ToString)
            lb = Me.Controls("lblIP" & i.ToString)
            tb.Visible = False
            lb.Visible = False
        Next
    End Sub

    Private Sub ddNumUnits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddNumUnits.SelectedIndexChanged
        ' Refresh the UI with the correct number of units
        Switch.NumUnits = CInt(ddNumUnits.SelectedItem)
        InitUI()
    End Sub

    Private Sub cbFetchNames_CheckedChanged(sender As Object, e As EventArgs) Handles cbFetchNames.CheckedChanged
        ' The driver can fetch port names from the RIGRunner.  Should we do this on connect?
        Switch.bFetchNames = cbFetchNames.Checked
    End Sub

End Class
