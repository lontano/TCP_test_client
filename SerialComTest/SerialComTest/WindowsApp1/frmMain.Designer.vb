<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Dim CommManager1 As SerialTest.CommManager = New SerialTest.CommManager()
    Dim CommManager2 As SerialTest.CommManager = New SerialTest.CommManager()
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.UCcommManagerSend = New SerialTest.UCcommManager()
    Me.UCcommManagerReceive = New SerialTest.UCcommManager()
    Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
    Me.ButtonLoad = New System.Windows.Forms.Button()
    Me.ButtonStartStop = New System.Windows.Forms.Button()
    Me.LabelInfo = New System.Windows.Forms.Label()
    Me.CheckBoxFreedSym = New System.Windows.Forms.CheckBox()
    Me.CheckBoxLoop = New System.Windows.Forms.CheckBox()
    Me.CheckBoxForwardToUDP = New System.Windows.Forms.CheckBox()
    Me.TextBoxUDPHost = New System.Windows.Forms.TextBox()
    Me.NumericUpDownUDPPort = New System.Windows.Forms.NumericUpDown()
    Me.ButtonUpdateSessions = New System.Windows.Forms.Button()
    Me.OpenFileDialogSession = New System.Windows.Forms.OpenFileDialog()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.TableLayoutPanel2.SuspendLayout()
    CType(Me.NumericUpDownUDPPort, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.UCcommManagerSend, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.UCcommManagerReceive, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 2
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(1000, 415)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'UCcommManagerSend
    '
    CommManager1.AsyncSend = True
    CommManager1.BaudRate = 38400
    CommManager1.CurrentTransmissionType = SerialTest.CommManager.TransmissionType.Text
    CommManager1.DataBits = 8
    CommManager1.DisplayWindow = Nothing
    CommManager1.ExpectedPacketSize = 0
    CommManager1.GroupPackets = 1
    CommManager1.Message = Nothing
    CommManager1.Parity = System.IO.Ports.Parity.None
    CommManager1.PortName = "COM1"
    CommManager1.StopBits = System.IO.Ports.StopBits.One
    CommManager1.Type = SerialTest.CommManager.MessageType.Incoming
    Me.UCcommManagerSend.commManager = CommManager1
    Me.UCcommManagerSend.Dock = System.Windows.Forms.DockStyle.Fill
    Me.UCcommManagerSend.Location = New System.Drawing.Point(2, 63)
    Me.UCcommManagerSend.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
    Me.UCcommManagerSend.Name = "UCcommManagerSend"
    Me.UCcommManagerSend.Size = New System.Drawing.Size(496, 349)
    Me.UCcommManagerSend.TabIndex = 1
    '
    'UCcommManagerReceive
    '
    CommManager2.AsyncSend = True
    CommManager2.BaudRate = 38400
    CommManager2.CurrentTransmissionType = SerialTest.CommManager.TransmissionType.Text
    CommManager2.DataBits = 8
    CommManager2.DisplayWindow = Nothing
    CommManager2.ExpectedPacketSize = 0
    CommManager2.GroupPackets = 1
    CommManager2.Message = Nothing
    CommManager2.Parity = System.IO.Ports.Parity.None
    CommManager2.PortName = "COM1"
    CommManager2.StopBits = System.IO.Ports.StopBits.One
    CommManager2.Type = SerialTest.CommManager.MessageType.Incoming
    Me.UCcommManagerReceive.commManager = CommManager2
    Me.UCcommManagerReceive.Dock = System.Windows.Forms.DockStyle.Fill
    Me.UCcommManagerReceive.Location = New System.Drawing.Point(502, 63)
    Me.UCcommManagerReceive.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
    Me.UCcommManagerReceive.Name = "UCcommManagerReceive"
    Me.UCcommManagerReceive.Size = New System.Drawing.Size(496, 349)
    Me.UCcommManagerReceive.TabIndex = 0
    '
    'TableLayoutPanel2
    '
    Me.TableLayoutPanel2.ColumnCount = 5
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonLoad, 0, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonStartStop, 1, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelInfo, 4, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxFreedSym, 2, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxLoop, 3, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxForwardToUDP, 1, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.TextBoxUDPHost, 2, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownUDPPort, 3, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonUpdateSessions, 0, 1)
    Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
    Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
    Me.TableLayoutPanel2.RowCount = 2
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel2.Size = New System.Drawing.Size(494, 54)
    Me.TableLayoutPanel2.TabIndex = 2
    '
    'ButtonLoad
    '
    Me.ButtonLoad.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonLoad.Location = New System.Drawing.Point(3, 3)
    Me.ButtonLoad.Name = "ButtonLoad"
    Me.ButtonLoad.Size = New System.Drawing.Size(94, 21)
    Me.ButtonLoad.TabIndex = 0
    Me.ButtonLoad.Text = "Load"
    Me.ButtonLoad.UseVisualStyleBackColor = True
    '
    'ButtonStartStop
    '
    Me.ButtonStartStop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonStartStop.Location = New System.Drawing.Point(103, 3)
    Me.ButtonStartStop.Name = "ButtonStartStop"
    Me.ButtonStartStop.Size = New System.Drawing.Size(94, 21)
    Me.ButtonStartStop.TabIndex = 1
    Me.ButtonStartStop.Text = "Start"
    Me.ButtonStartStop.UseVisualStyleBackColor = True
    '
    'LabelInfo
    '
    Me.LabelInfo.AutoSize = True
    Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelInfo.Location = New System.Drawing.Point(403, 0)
    Me.LabelInfo.Name = "LabelInfo"
    Me.LabelInfo.Size = New System.Drawing.Size(88, 27)
    Me.LabelInfo.TabIndex = 2
    Me.LabelInfo.Text = "Info"
    '
    'CheckBoxFreedSym
    '
    Me.CheckBoxFreedSym.AutoSize = True
    Me.CheckBoxFreedSym.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxFreedSym.Location = New System.Drawing.Point(203, 3)
    Me.CheckBoxFreedSym.Name = "CheckBoxFreedSym"
    Me.CheckBoxFreedSym.Size = New System.Drawing.Size(94, 21)
    Me.CheckBoxFreedSym.TabIndex = 3
    Me.CheckBoxFreedSym.Text = "Free-d sym"
    Me.CheckBoxFreedSym.UseVisualStyleBackColor = True
    '
    'CheckBoxLoop
    '
    Me.CheckBoxLoop.AutoSize = True
    Me.CheckBoxLoop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxLoop.Location = New System.Drawing.Point(303, 3)
    Me.CheckBoxLoop.Name = "CheckBoxLoop"
    Me.CheckBoxLoop.Size = New System.Drawing.Size(94, 21)
    Me.CheckBoxLoop.TabIndex = 4
    Me.CheckBoxLoop.Text = "Loop"
    Me.CheckBoxLoop.UseVisualStyleBackColor = True
    '
    'CheckBoxForwardToUDP
    '
    Me.CheckBoxForwardToUDP.AutoSize = True
    Me.CheckBoxForwardToUDP.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxForwardToUDP.Location = New System.Drawing.Point(103, 30)
    Me.CheckBoxForwardToUDP.Name = "CheckBoxForwardToUDP"
    Me.CheckBoxForwardToUDP.Size = New System.Drawing.Size(94, 21)
    Me.CheckBoxForwardToUDP.TabIndex = 5
    Me.CheckBoxForwardToUDP.Text = "Forward to UDP"
    Me.CheckBoxForwardToUDP.UseVisualStyleBackColor = True
    '
    'TextBoxUDPHost
    '
    Me.TextBoxUDPHost.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxUDPHost.Location = New System.Drawing.Point(203, 30)
    Me.TextBoxUDPHost.Name = "TextBoxUDPHost"
    Me.TextBoxUDPHost.Size = New System.Drawing.Size(94, 19)
    Me.TextBoxUDPHost.TabIndex = 6
    Me.TextBoxUDPHost.Text = "127.0.0.1"
    '
    'NumericUpDownUDPPort
    '
    Me.NumericUpDownUDPPort.Dock = System.Windows.Forms.DockStyle.Fill
    Me.NumericUpDownUDPPort.Location = New System.Drawing.Point(303, 30)
    Me.NumericUpDownUDPPort.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownUDPPort.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
    Me.NumericUpDownUDPPort.Name = "NumericUpDownUDPPort"
    Me.NumericUpDownUDPPort.Size = New System.Drawing.Size(94, 19)
    Me.NumericUpDownUDPPort.TabIndex = 7
    Me.NumericUpDownUDPPort.Value = New Decimal(New Integer() {6301, 0, 0, 0})
    '
    'ButtonUpdateSessions
    '
    Me.ButtonUpdateSessions.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonUpdateSessions.Location = New System.Drawing.Point(3, 30)
    Me.ButtonUpdateSessions.Name = "ButtonUpdateSessions"
    Me.ButtonUpdateSessions.Size = New System.Drawing.Size(94, 21)
    Me.ButtonUpdateSessions.TabIndex = 8
    Me.ButtonUpdateSessions.Text = "Update sessions"
    Me.ButtonUpdateSessions.UseVisualStyleBackColor = True
    '
    'OpenFileDialogSession
    '
    Me.OpenFileDialogSession.FileName = "OpenFileDialog1"
    Me.OpenFileDialogSession.Filter = "Session|*.tss|All files|*.*"
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1000, 415)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
    Me.Name = "frmMain"
    Me.Text = "Serial test"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel2.ResumeLayout(False)
    Me.TableLayoutPanel2.PerformLayout()
    CType(Me.NumericUpDownUDPPort, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents UCcommManagerReceive As UCcommManager
  Friend WithEvents UCcommManagerSend As UCcommManager
  Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
  Friend WithEvents ButtonLoad As Button
  Friend WithEvents ButtonStartStop As Button
  Friend WithEvents LabelInfo As Label
  Friend WithEvents OpenFileDialogSession As OpenFileDialog
  Friend WithEvents CheckBoxFreedSym As CheckBox
  Friend WithEvents CheckBoxLoop As CheckBox
  Friend WithEvents CheckBoxForwardToUDP As CheckBox
  Friend WithEvents TextBoxUDPHost As TextBox
  Friend WithEvents NumericUpDownUDPPort As NumericUpDown
  Friend WithEvents ButtonUpdateSessions As Button
End Class
