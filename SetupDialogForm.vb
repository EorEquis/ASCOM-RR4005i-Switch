Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports ASCOM.Utilities
Imports ASCOM.RR4005i

<ComVisible(False)> _
Public Class SetupDialogForm

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click ' OK button event handler
        ' Persist new values of user settings to the ASCOM profile
        Dim tb As TextBox
        Switch.traceState = chkTrace.Checked
        Switch.RRIP = txtIP.Text
        For i As Integer = 0 To 4
            tb = Me.Controls("txtPortName" & i.ToString)
            Switch.PortNames(i) = tb.Text
        Next

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
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
        Dim tb As TextBox
        chkTrace.Checked = Switch.traceState
        txtIP.Text = Switch.RRIP
        For i As Integer = 0 To 4
            tb = Me.Controls("txtPortName" & i.ToString)
            tb.Text = Switch.PortNames(i)
        Next
    End Sub


End Class
