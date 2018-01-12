<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.GroupBoxSender = New System.Windows.Forms.GroupBox()
    Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
    Me.NumericUpDownSenderHost = New System.Windows.Forms.NumericUpDown()
    Me.TextBoxSenderHost = New System.Windows.Forms.TextBox()
    Me.LabelSenderPort = New System.Windows.Forms.Label()
    Me.LabelSenderHost = New System.Windows.Forms.Label()
    Me.LabelSenderState = New System.Windows.Forms.Label()
    Me.LabelSenderDataRate = New System.Windows.Forms.Label()
    Me.ButtonSenderConnect = New System.Windows.Forms.Button()
    Me.GroupBoxReceiver = New System.Windows.Forms.GroupBox()
    Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
    Me.NumericUpDownReceiverPort = New System.Windows.Forms.NumericUpDown()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LabelReceiverState = New System.Windows.Forms.Label()
    Me.LabelReceiverDataRate = New System.Windows.Forms.Label()
    Me.ButtonReceiverConnect = New System.Windows.Forms.Button()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.GroupBoxSender.SuspendLayout()
    Me.TableLayoutPanel2.SuspendLayout()
    CType(Me.NumericUpDownSenderHost, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBoxReceiver.SuspendLayout()
    Me.TableLayoutPanel3.SuspendLayout()
    CType(Me.NumericUpDownReceiverPort, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    Me.Timer1.Interval = 20
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxSender, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxReceiver, 1, 0)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(633, 197)
    Me.TableLayoutPanel1.TabIndex = 2
    '
    'GroupBoxSender
    '
    Me.GroupBoxSender.Controls.Add(Me.TableLayoutPanel2)
    Me.GroupBoxSender.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBoxSender.Location = New System.Drawing.Point(3, 3)
    Me.GroupBoxSender.Name = "GroupBoxSender"
    Me.GroupBoxSender.Size = New System.Drawing.Size(310, 191)
    Me.GroupBoxSender.TabIndex = 0
    Me.GroupBoxSender.TabStop = False
    Me.GroupBoxSender.Text = "Sender"
    '
    'TableLayoutPanel2
    '
    Me.TableLayoutPanel2.ColumnCount = 2
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownSenderHost, 1, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.TextBoxSenderHost, 1, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderPort, 0, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderHost, 0, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderState, 0, 4)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderDataRate, 1, 4)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonSenderConnect, 1, 2)
    Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 17)
    Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
    Me.TableLayoutPanel2.RowCount = 5
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.Size = New System.Drawing.Size(304, 171)
    Me.TableLayoutPanel2.TabIndex = 0
    '
    'NumericUpDownSenderHost
    '
    Me.NumericUpDownSenderHost.Location = New System.Drawing.Point(155, 28)
    Me.NumericUpDownSenderHost.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownSenderHost.Name = "NumericUpDownSenderHost"
    Me.NumericUpDownSenderHost.Size = New System.Drawing.Size(98, 21)
    Me.NumericUpDownSenderHost.TabIndex = 1
    Me.NumericUpDownSenderHost.Value = New Decimal(New Integer() {6100, 0, 0, 0})
    '
    'TextBoxSenderHost
    '
    Me.TextBoxSenderHost.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxSenderHost.Location = New System.Drawing.Point(155, 3)
    Me.TextBoxSenderHost.Name = "TextBoxSenderHost"
    Me.TextBoxSenderHost.Size = New System.Drawing.Size(146, 21)
    Me.TextBoxSenderHost.TabIndex = 2
    Me.TextBoxSenderHost.Text = "192.168.146.76"
    '
    'LabelSenderPort
    '
    Me.LabelSenderPort.AutoSize = True
    Me.LabelSenderPort.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderPort.Location = New System.Drawing.Point(3, 25)
    Me.LabelSenderPort.Name = "LabelSenderPort"
    Me.LabelSenderPort.Size = New System.Drawing.Size(146, 25)
    Me.LabelSenderPort.TabIndex = 0
    Me.LabelSenderPort.Text = "Port"
    Me.LabelSenderPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelSenderHost
    '
    Me.LabelSenderHost.AutoSize = True
    Me.LabelSenderHost.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderHost.Location = New System.Drawing.Point(3, 0)
    Me.LabelSenderHost.Name = "LabelSenderHost"
    Me.LabelSenderHost.Size = New System.Drawing.Size(146, 25)
    Me.LabelSenderHost.TabIndex = 3
    Me.LabelSenderHost.Text = "Host"
    Me.LabelSenderHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelSenderState
    '
    Me.LabelSenderState.AutoSize = True
    Me.LabelSenderState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderState.Location = New System.Drawing.Point(3, 146)
    Me.LabelSenderState.Name = "LabelSenderState"
    Me.LabelSenderState.Size = New System.Drawing.Size(146, 25)
    Me.LabelSenderState.TabIndex = 4
    Me.LabelSenderState.Text = "State"
    Me.LabelSenderState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelSenderDataRate
    '
    Me.LabelSenderDataRate.AutoSize = True
    Me.LabelSenderDataRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderDataRate.Location = New System.Drawing.Point(155, 146)
    Me.LabelSenderDataRate.Name = "LabelSenderDataRate"
    Me.LabelSenderDataRate.Size = New System.Drawing.Size(146, 25)
    Me.LabelSenderDataRate.TabIndex = 4
    Me.LabelSenderDataRate.Text = "Data rate"
    Me.LabelSenderDataRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ButtonSenderConnect
    '
    Me.ButtonSenderConnect.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonSenderConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonSenderConnect.Location = New System.Drawing.Point(155, 53)
    Me.ButtonSenderConnect.Name = "ButtonSenderConnect"
    Me.ButtonSenderConnect.Size = New System.Drawing.Size(146, 24)
    Me.ButtonSenderConnect.TabIndex = 5
    Me.ButtonSenderConnect.Text = "Connect"
    Me.ButtonSenderConnect.UseVisualStyleBackColor = True
    '
    'GroupBoxReceiver
    '
    Me.GroupBoxReceiver.Controls.Add(Me.TableLayoutPanel3)
    Me.GroupBoxReceiver.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBoxReceiver.Location = New System.Drawing.Point(319, 3)
    Me.GroupBoxReceiver.Name = "GroupBoxReceiver"
    Me.GroupBoxReceiver.Size = New System.Drawing.Size(311, 191)
    Me.GroupBoxReceiver.TabIndex = 1
    Me.GroupBoxReceiver.TabStop = False
    Me.GroupBoxReceiver.Text = "Receiver"
    '
    'TableLayoutPanel3
    '
    Me.TableLayoutPanel3.ColumnCount = 2
    Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel3.Controls.Add(Me.NumericUpDownReceiverPort, 1, 1)
    Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 1)
    Me.TableLayoutPanel3.Controls.Add(Me.LabelReceiverState, 0, 4)
    Me.TableLayoutPanel3.Controls.Add(Me.LabelReceiverDataRate, 1, 4)
    Me.TableLayoutPanel3.Controls.Add(Me.ButtonReceiverConnect, 1, 2)
    Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
    Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
    Me.TableLayoutPanel3.RowCount = 5
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel3.Size = New System.Drawing.Size(305, 171)
    Me.TableLayoutPanel3.TabIndex = 1
    '
    'NumericUpDownReceiverPort
    '
    Me.NumericUpDownReceiverPort.Location = New System.Drawing.Point(155, 28)
    Me.NumericUpDownReceiverPort.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownReceiverPort.Name = "NumericUpDownReceiverPort"
    Me.NumericUpDownReceiverPort.Size = New System.Drawing.Size(98, 21)
    Me.NumericUpDownReceiverPort.TabIndex = 1
    Me.NumericUpDownReceiverPort.Value = New Decimal(New Integer() {6100, 0, 0, 0})
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label1.Location = New System.Drawing.Point(3, 25)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(146, 25)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Port"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelReceiverState
    '
    Me.LabelReceiverState.AutoSize = True
    Me.LabelReceiverState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelReceiverState.Location = New System.Drawing.Point(3, 146)
    Me.LabelReceiverState.Name = "LabelReceiverState"
    Me.LabelReceiverState.Size = New System.Drawing.Size(146, 25)
    Me.LabelReceiverState.TabIndex = 4
    Me.LabelReceiverState.Text = "State"
    Me.LabelReceiverState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelReceiverDataRate
    '
    Me.LabelReceiverDataRate.AutoSize = True
    Me.LabelReceiverDataRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelReceiverDataRate.Location = New System.Drawing.Point(155, 146)
    Me.LabelReceiverDataRate.Name = "LabelReceiverDataRate"
    Me.LabelReceiverDataRate.Size = New System.Drawing.Size(147, 25)
    Me.LabelReceiverDataRate.TabIndex = 4
    Me.LabelReceiverDataRate.Text = "Data rate"
    Me.LabelReceiverDataRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ButtonReceiverConnect
    '
    Me.ButtonReceiverConnect.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonReceiverConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonReceiverConnect.Location = New System.Drawing.Point(155, 53)
    Me.ButtonReceiverConnect.Name = "ButtonReceiverConnect"
    Me.ButtonReceiverConnect.Size = New System.Drawing.Size(147, 24)
    Me.ButtonReceiverConnect.TabIndex = 5
    Me.ButtonReceiverConnect.Text = "Connect"
    Me.ButtonReceiverConnect.UseVisualStyleBackColor = True
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(633, 197)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmMain"
    Me.Text = "Form1"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.GroupBoxSender.ResumeLayout(False)
    Me.TableLayoutPanel2.ResumeLayout(False)
    Me.TableLayoutPanel2.PerformLayout()
    CType(Me.NumericUpDownSenderHost, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBoxReceiver.ResumeLayout(False)
    Me.TableLayoutPanel3.ResumeLayout(False)
    Me.TableLayoutPanel3.PerformLayout()
    CType(Me.NumericUpDownReceiverPort, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Timer1 As Timer
  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents GroupBoxSender As GroupBox
  Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
  Friend WithEvents NumericUpDownSenderHost As NumericUpDown
  Friend WithEvents TextBoxSenderHost As TextBox
  Friend WithEvents LabelSenderPort As Label
  Friend WithEvents LabelSenderHost As Label
  Friend WithEvents LabelSenderState As Label
  Friend WithEvents LabelSenderDataRate As Label
  Friend WithEvents ButtonSenderConnect As Button
  Friend WithEvents GroupBoxReceiver As GroupBox
  Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
  Friend WithEvents NumericUpDownReceiverPort As NumericUpDown
  Friend WithEvents Label1 As Label
  Friend WithEvents LabelReceiverState As Label
  Friend WithEvents LabelReceiverDataRate As Label
  Friend WithEvents ButtonReceiverConnect As Button
End Class
