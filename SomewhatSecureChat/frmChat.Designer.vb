<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChat))
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.txtDestinationPort = New System.Windows.Forms.TextBox()
        Me.txtListeningPort = New System.Windows.Forms.TextBox()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblDestination = New System.Windows.Forms.Label()
        Me.lblDestinationPort = New System.Windows.Forms.Label()
        Me.lblListeningPort = New System.Windows.Forms.Label()
        Me.lblReceived = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStriplblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHelp1 = New System.Windows.Forms.LinkLabel()
        Me.cmdListen = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblHelp2 = New System.Windows.Forms.LinkLabel()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(102, 80)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(513, 115)
        Me.txtMessage.TabIndex = 1
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(24, 278)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(39, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Label1"
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(101, 163)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(124, 20)
        Me.txtDestination.TabIndex = 3
        '
        'txtDestinationPort
        '
        Me.txtDestinationPort.Location = New System.Drawing.Point(334, 163)
        Me.txtDestinationPort.Name = "txtDestinationPort"
        Me.txtDestinationPort.Size = New System.Drawing.Size(60, 20)
        Me.txtDestinationPort.TabIndex = 4
        '
        'txtListeningPort
        '
        Me.txtListeningPort.Location = New System.Drawing.Point(334, 20)
        Me.txtListeningPort.Name = "txtListeningPort"
        Me.txtListeningPort.Size = New System.Drawing.Size(60, 20)
        Me.txtListeningPort.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtListeningPort, "If you don't know what this means, you can choose any number between 1100-65000. " & _
                "")
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(471, 163)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(152, 30)
        Me.cmdSend.TabIndex = 8
        Me.cmdSend.Text = "Button1"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(11, 17)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(39, 13)
        Me.lblMessage.TabIndex = 9
        Me.lblMessage.Text = "Label2"
        '
        'lblDestination
        '
        Me.lblDestination.AutoSize = True
        Me.lblDestination.Location = New System.Drawing.Point(11, 166)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New System.Drawing.Size(39, 13)
        Me.lblDestination.TabIndex = 10
        Me.lblDestination.Text = "Label3"
        '
        'lblDestinationPort
        '
        Me.lblDestinationPort.AutoSize = True
        Me.lblDestinationPort.Location = New System.Drawing.Point(242, 166)
        Me.lblDestinationPort.Name = "lblDestinationPort"
        Me.lblDestinationPort.Size = New System.Drawing.Size(39, 13)
        Me.lblDestinationPort.TabIndex = 11
        Me.lblDestinationPort.Text = "Label4"
        '
        'lblListeningPort
        '
        Me.lblListeningPort.AutoSize = True
        Me.lblListeningPort.Location = New System.Drawing.Point(242, 23)
        Me.lblListeningPort.Name = "lblListeningPort"
        Me.lblListeningPort.Size = New System.Drawing.Size(39, 13)
        Me.lblListeningPort.TabIndex = 12
        Me.lblListeningPort.Text = "Label5"
        '
        'lblReceived
        '
        Me.lblReceived.AutoSize = True
        Me.lblReceived.Location = New System.Drawing.Point(11, 63)
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Size = New System.Drawing.Size(39, 13)
        Me.lblReceived.TabIndex = 14
        Me.lblReceived.Text = "Label7"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStriplblStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 492)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(670, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStriplblStatus
        '
        Me.ToolStriplblStatus.Name = "ToolStriplblStatus"
        Me.ToolStriplblStatus.Size = New System.Drawing.Size(89, 22)
        Me.ToolStriplblStatus.Text = "ToolStripLabel1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MenuStrip1.Size = New System.Drawing.Size(670, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblHelp1)
        Me.Panel1.Controls.Add(Me.cmdSend)
        Me.Panel1.Controls.Add(Me.lblMessage)
        Me.Panel1.Controls.Add(Me.txtDestinationPort)
        Me.Panel1.Controls.Add(Me.lblDestination)
        Me.Panel1.Controls.Add(Me.txtDestination)
        Me.Panel1.Controls.Add(Me.lblDestinationPort)
        Me.Panel1.Location = New System.Drawing.Point(12, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(646, 201)
        Me.Panel1.TabIndex = 17
        '
        'lblHelp1
        '
        Me.lblHelp1.AutoSize = True
        Me.lblHelp1.Location = New System.Drawing.Point(400, 166)
        Me.lblHelp1.Name = "lblHelp1"
        Me.lblHelp1.Size = New System.Drawing.Size(33, 13)
        Me.lblHelp1.TabIndex = 21
        Me.lblHelp1.TabStop = True
        Me.lblHelp1.Text = "(help)"
        '
        'cmdListen
        '
        Me.cmdListen.Location = New System.Drawing.Point(471, 23)
        Me.cmdListen.Name = "cmdListen"
        Me.cmdListen.Size = New System.Drawing.Size(152, 30)
        Me.cmdListen.TabIndex = 18
        Me.cmdListen.Text = "Button1"
        Me.cmdListen.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblHelp2)
        Me.Panel2.Controls.Add(Me.txtLog)
        Me.Panel2.Controls.Add(Me.cmdListen)
        Me.Panel2.Controls.Add(Me.lblReceived)
        Me.Panel2.Controls.Add(Me.lblListeningPort)
        Me.Panel2.Controls.Add(Me.txtListeningPort)
        Me.Panel2.Location = New System.Drawing.Point(12, 309)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(646, 175)
        Me.Panel2.TabIndex = 19
        '
        'lblHelp2
        '
        Me.lblHelp2.AutoSize = True
        Me.lblHelp2.Location = New System.Drawing.Point(400, 23)
        Me.lblHelp2.Name = "lblHelp2"
        Me.lblHelp2.Size = New System.Drawing.Size(33, 13)
        Me.lblHelp2.TabIndex = 20
        Me.lblHelp2.TabStop = True
        Me.lblHelp2.Text = "(help)"
        '
        'txtLog
        '
        Me.txtLog.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.Location = New System.Drawing.Point(101, 60)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(513, 101)
        Me.txtLog.TabIndex = 19
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Lucida Console", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(27, 36)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(311, 26)
        Me.lblTitle.TabIndex = 20
        Me.lblTitle.Text = "Label1"
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlogan.Location = New System.Drawing.Point(308, 48)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(49, 14)
        Me.lblSlogan.TabIndex = 21
        Me.lblSlogan.Text = "Label1"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(114, 275)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPassword.Size = New System.Drawing.Size(501, 20)
        Me.txtPassword.TabIndex = 22
        '
        'frmChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 517)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(686, 555)
        Me.MinimumSize = New System.Drawing.Size(686, 555)
        Me.Name = "frmChat"
        Me.Text = "Form1"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents txtDestinationPort As System.Windows.Forms.TextBox
    Friend WithEvents txtListeningPort As System.Windows.Forms.TextBox
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents lblDestinationPort As System.Windows.Forms.Label
    Friend WithEvents lblListeningPort As System.Windows.Forms.Label
    Friend WithEvents lblReceived As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStriplblStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdListen As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblHelp2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblHelp1 As System.Windows.Forms.LinkLabel

End Class
