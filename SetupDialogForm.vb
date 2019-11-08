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
        Switch.NumUnits = ddNumUnits.SelectedItem
        For i As Integer = 0 To 4
            tb = Me.Controls("txtIP" & i.ToString)
            Switch.RRIP(i) = tb.Text
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
        Dim tb As TextBox, lb As Label
        chkTrace.Checked = Switch.traceState
        ddNumUnits.SelectedItem = Switch.NumUnits
        For i As Integer = 0 To Switch.NumUnits - 1
            tb = Me.Controls("txtIP" & i.ToString)
            lb = Me.Controls("lblIP" & i.ToString)
            tb.Visible = True
            tb.Text = Switch.RRIP(i)
            lb.Visible = True
        Next
        For i As Integer = Switch.NumUnits To 4
            tb = Me.Controls("txtIP" & i.ToString)
            lb = Me.Controls("lblIP" & i.ToString)
            tb.Visible = False
            lb.Visible = False

        Next
    End Sub


    Private Sub ddNumUnits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddNumUnits.SelectedIndexChanged
        Switch.NumUnits = CInt(ddNumUnits.SelectedItem)
        InitUI()
    End Sub

End Class
