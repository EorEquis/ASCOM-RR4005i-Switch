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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupDialogForm))
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
        Me.cbFetchNames = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(265, 167)
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
        Me.PictureBox1.Location = New System.Drawing.Point(362, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'chkTrace
        '
        Me.chkTrace.AutoSize = True
        Me.chkTrace.Location = New System.Drawing.Point(393, 145)
        Me.chkTrace.Name = "chkTrace"
        Me.chkTrace.Size = New System.Drawing.Size(15, 14)
        Me.chkTrace.TabIndex = 60
        Me.ToolTip1.SetToolTip(Me.chkTrace, "Enable ASCOM trace logging")
        Me.chkTrace.UseVisualStyleBackColor = True
        '
        'txtIP0
        '
        Me.txtIP0.Location = New System.Drawing.Point(107, 74)
        Me.txtIP0.Name = "txtIP0"
        Me.txtIP0.Size = New System.Drawing.Size(118, 20)
        Me.txtIP0.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.txtIP0, "Enter the unit's IP address on your network")
        '
        'lblIP0
        '
        Me.lblIP0.AutoSize = True
        Me.lblIP0.Location = New System.Drawing.Point(12, 77)
        Me.lblIP0.Name = "lblIP0"
        Me.lblIP0.Size = New System.Drawing.Size(89, 13)
        Me.lblIP0.TabIndex = 11
        Me.lblIP0.Text = "Unit 1 IP Address"
        Me.ToolTip1.SetToolTip(Me.lblIP0, "Enter the unit's IP address on your network")
        '
        'ddNumUnits
        '
        Me.ddNumUnits.FormattingEnabled = True
        Me.ddNumUnits.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ddNumUnits.Location = New System.Drawing.Point(107, 47)
        Me.ddNumUnits.Name = "ddNumUnits"
        Me.ddNumUnits.Size = New System.Drawing.Size(58, 21)
        Me.ddNumUnits.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ddNumUnits, "Select the number of RIGRunner Units")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Number of Units"
        Me.ToolTip1.SetToolTip(Me.Label3, "Select the number of RIGRunner Units")
        '
        'lblIP1
        '
        Me.lblIP1.AutoSize = True
        Me.lblIP1.Location = New System.Drawing.Point(12, 103)
        Me.lblIP1.Name = "lblIP1"
        Me.lblIP1.Size = New System.Drawing.Size(89, 13)
        Me.lblIP1.TabIndex = 64
        Me.lblIP1.Text = "Unit 2 IP Address"
        Me.ToolTip1.SetToolTip(Me.lblIP1, "Enter the unit's IP address on your network")
        '
        'txtIP1
        '
        Me.txtIP1.Location = New System.Drawing.Point(107, 100)
        Me.txtIP1.Name = "txtIP1"
        Me.txtIP1.Size = New System.Drawing.Size(118, 20)
        Me.txtIP1.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.txtIP1, "Enter the unit's IP address on your network")
        '
        'lblIP2
        '
        Me.lblIP2.AutoSize = True
        Me.lblIP2.Location = New System.Drawing.Point(12, 129)
        Me.lblIP2.Name = "lblIP2"
        Me.lblIP2.Size = New System.Drawing.Size(89, 13)
        Me.lblIP2.TabIndex = 66
        Me.lblIP2.Text = "Unit 3 IP Address"
        Me.ToolTip1.SetToolTip(Me.lblIP2, "Enter the unit's IP address on your network")
        '
        'txtIP2
        '
        Me.txtIP2.Location = New System.Drawing.Point(107, 126)
        Me.txtIP2.Name = "txtIP2"
        Me.txtIP2.Size = New System.Drawing.Size(118, 20)
        Me.txtIP2.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.txtIP2, "Enter the unit's IP address on your network")
        '
        'lblIP3
        '
        Me.lblIP3.AutoSize = True
        Me.lblIP3.Location = New System.Drawing.Point(12, 155)
        Me.lblIP3.Name = "lblIP3"
        Me.lblIP3.Size = New System.Drawing.Size(89, 13)
        Me.lblIP3.TabIndex = 68
        Me.lblIP3.Text = "Unit 4 IP Address"
        Me.ToolTip1.SetToolTip(Me.lblIP3, "Enter the unit's IP address on your network")
        '
        'txtIP3
        '
        Me.txtIP3.Location = New System.Drawing.Point(107, 152)
        Me.txtIP3.Name = "txtIP3"
        Me.txtIP3.Size = New System.Drawing.Size(118, 20)
        Me.txtIP3.TabIndex = 40
        Me.ToolTip1.SetToolTip(Me.txtIP3, "Enter the unit's IP address on your network")
        '
        'lblIP4
        '
        Me.lblIP4.AutoSize = True
        Me.lblIP4.Location = New System.Drawing.Point(12, 181)
        Me.lblIP4.Name = "lblIP4"
        Me.lblIP4.Size = New System.Drawing.Size(89, 13)
        Me.lblIP4.TabIndex = 70
        Me.lblIP4.Text = "Unit 5 IP Address"
        Me.ToolTip1.SetToolTip(Me.lblIP4, "Enter the unit's IP address on your network")
        '
        'txtIP4
        '
        Me.txtIP4.Location = New System.Drawing.Point(107, 178)
        Me.txtIP4.Name = "txtIP4"
        Me.txtIP4.Size = New System.Drawing.Size(118, 20)
        Me.txtIP4.TabIndex = 50
        Me.ToolTip1.SetToolTip(Me.txtIP4, "Enter the unit's IP address on your network")
        '
        'cbFetchNames
        '
        Me.cbFetchNames.AutoSize = True
        Me.cbFetchNames.Location = New System.Drawing.Point(394, 125)
        Me.cbFetchNames.Name = "cbFetchNames"
        Me.cbFetchNames.Size = New System.Drawing.Size(15, 14)
        Me.cbFetchNames.TabIndex = 71
        Me.ToolTip1.SetToolTip(Me.cbFetchNames, "The driver can fetch your assigned portnames")
        Me.cbFetchNames.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(242, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Fetch port names on connect"
        Me.ToolTip1.SetToolTip(Me.Label2, "The driver can fetch your assigned portnames" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from the RIGRunner.  Do you want it" & _
        " to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "do this when you connect?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Otherwise, the driver will use the last known " & _
        "port" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "names once connected.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(336, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Trace On"
        Me.ToolTip1.SetToolTip(Me.Label4, "Enable ASCOM trace logging")
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(423, 208)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbFetchNames)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RR4005i Switch Setup"
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
    Friend WithEvents cbFetchNames As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
