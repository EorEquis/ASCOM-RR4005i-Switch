<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupDialogForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkTrace = New System.Windows.Forms.CheckBox()
        Me.txtIP0 = New System.Windows.Forms.TextBox()
        Me.lblIP0 = New System.Windows.Forms.Label()
        Me.ddNumUnits = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIP1 = New System.Windows.Forms.Label()
        Me.txtIP1 = New System.Windows.Forms.TextBox()
        Me.lblIP2 = New System.Windows.Forms.Label()
        Me.txtIP2 = New System.Windows.Forms.TextBox()
        Me.lblIP3 = New System.Windows.Forms.Label()
        Me.txtIP3 = New System.Windows.Forms.TextBox()
        Me.lblIP4 = New System.Windows.Forms.Label()
        Me.txtIP4 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(243, 167)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 70
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 80
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RigRunner Parameters"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.RR4005i.My.Resources.Resources.ASCOM
        Me.PictureBox1.Location = New System.Drawing.Point(340, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'chkTrace
        '
        Me.chkTrace.AutoSize = True
        Me.chkTrace.Location = New System.Drawing.Point(320, 144)
        Me.chkTrace.Name = "chkTrace"
        Me.chkTrace.Size = New System.Drawing.Size(69, 17)
        Me.chkTrace.TabIndex = 60
        Me.chkTrace.Text = "Trace on"
        Me.chkTrace.UseVisualStyleBackColor = True
        '
        'txtIP0
        '
        Me.txtIP0.Location = New System.Drawing.Point(107, 74)
        Me.txtIP0.Name = "txtIP0"
        Me.txtIP0.Size = New System.Drawing.Size(118, 20)
        Me.txtIP0.TabIndex = 10
        '
        'lblIP0
        '
        Me.lblIP0.AutoSize = True
        Me.lblIP0.Location = New System.Drawing.Point(12, 77)
        Me.lblIP0.Name = "lblIP0"
        Me.lblIP0.Size = New System.Drawing.Size(89, 13)
        Me.lblIP0.TabIndex = 11
        Me.lblIP0.Text = "Unit 1 IP Address"
        '
        'ddNumUnits
        '
        Me.ddNumUnits.FormattingEnabled = True
        Me.ddNumUnits.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ddNumUnits.Location = New System.Drawing.Point(107, 47)
        Me.ddNumUnits.Name = "ddNumUnits"
        Me.ddNumUnits.Size = New System.Drawing.Size(50, 21)
        Me.ddNumUnits.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Number of Units"
        '
        'lblIP1
        '
        Me.lblIP1.AutoSize = True
        Me.lblIP1.Location = New System.Drawing.Point(12, 103)
        Me.lblIP1.Name = "lblIP1"
        Me.lblIP1.Size = New System.Drawing.Size(89, 13)
        Me.lblIP1.TabIndex = 64
        Me.lblIP1.Text = "Unit 2 IP Address"
        '
        'txtIP1
        '
        Me.txtIP1.Location = New System.Drawing.Point(107, 100)
        Me.txtIP1.Name = "txtIP1"
        Me.txtIP1.Size = New System.Drawing.Size(118, 20)
        Me.txtIP1.TabIndex = 20
        '
        'lblIP2
        '
        Me.lblIP2.AutoSize = True
        Me.lblIP2.Location = New System.Drawing.Point(12, 129)
        Me.lblIP2.Name = "lblIP2"
        Me.lblIP2.Size = New System.Drawing.Size(89, 13)
        Me.lblIP2.TabIndex = 66
        Me.lblIP2.Text = "Unit 3 IP Address"
        '
        'txtIP2
        '
        Me.txtIP2.Location = New System.Drawing.Point(107, 126)
        Me.txtIP2.Name = "txtIP2"
        Me.txtIP2.Size = New System.Drawing.Size(118, 20)
        Me.txtIP2.TabIndex = 30
        '
        'lblIP3
        '
        Me.lblIP3.AutoSize = True
        Me.lblIP3.Location = New System.Drawing.Point(12, 155)
        Me.lblIP3.Name = "lblIP3"
        Me.lblIP3.Size = New System.Drawing.Size(89, 13)
        Me.lblIP3.TabIndex = 68
        Me.lblIP3.Text = "Unit 4 IP Address"
        '
        'txtIP3
        '
        Me.txtIP3.Location = New System.Drawing.Point(107, 152)
        Me.txtIP3.Name = "txtIP3"
        Me.txtIP3.Size = New System.Drawing.Size(118, 20)
        Me.txtIP3.TabIndex = 40
        '
        'lblIP4
        '
        Me.lblIP4.AutoSize = True
        Me.lblIP4.Location = New System.Drawing.Point(12, 181)
        Me.lblIP4.Name = "lblIP4"
        Me.lblIP4.Size = New System.Drawing.Size(89, 13)
        Me.lblIP4.TabIndex = 70
        Me.lblIP4.Text = "Unit 5 IP Address"
        '
        'txtIP4
        '
        Me.txtIP4.Location = New System.Drawing.Point(107, 178)
        Me.txtIP4.Name = "txtIP4"
        Me.txtIP4.Size = New System.Drawing.Size(118, 20)
        Me.txtIP4.TabIndex = 50
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(401, 208)
        Me.Controls.Add(Me.lblIP4)
        Me.Controls.Add(Me.txtIP4)
        Me.Controls.Add(Me.lblIP3)
        Me.Controls.Add(Me.txtIP3)
        Me.Controls.Add(Me.lblIP2)
        Me.Controls.Add(Me.txtIP2)
        Me.Controls.Add(Me.lblIP1)
        Me.Controls.Add(Me.txtIP1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ddNumUnits)
        Me.Controls.Add(Me.lblIP0)
        Me.Controls.Add(Me.txtIP0)
        Me.Controls.Add(Me.chkTrace)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DeviceName Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkTrace As System.Windows.Forms.CheckBox
    Friend WithEvents txtIP0 As System.Windows.Forms.TextBox
    Friend WithEvents lblIP0 As System.Windows.Forms.Label
    Friend WithEvents ddNumUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIP1 As System.Windows.Forms.Label
    Friend WithEvents txtIP1 As System.Windows.Forms.TextBox
    Friend WithEvents lblIP2 As System.Windows.Forms.Label
    Friend WithEvents txtIP2 As System.Windows.Forms.TextBox
    Friend WithEvents lblIP3 As System.Windows.Forms.Label
    Friend WithEvents txtIP3 As System.Windows.Forms.TextBox
    Friend WithEvents lblIP4 As System.Windows.Forms.Label
    Friend WithEvents txtIP4 As System.Windows.Forms.TextBox

End Class
