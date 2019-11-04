<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestTCP
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
    Me.components = New System.ComponentModel.Container()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.GroupBoxSender = New System.Windows.Forms.GroupBox()
    Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
    Me.NumericUpDownSenderPort = New System.Windows.Forms.NumericUpDown()
    Me.TextBoxSenderHost = New System.Windows.Forms.TextBox()
    Me.LabelSenderPort = New System.Windows.Forms.Label()
    Me.LabelSenderHost = New System.Windows.Forms.Label()
    Me.LabelSenderState = New System.Windows.Forms.Label()
    Me.LabelSenderDataRate = New System.Windows.Forms.Label()
    Me.ButtonSenderConnect = New System.Windows.Forms.Button()
    Me.CheckBoxSendData = New System.Windows.Forms.CheckBox()
    Me.NumericUpDownDataSendTime = New System.Windows.Forms.NumericUpDown()
    Me.ButtonReset = New System.Windows.Forms.Button()
    Me.LabelReceiverDataRate = New System.Windows.Forms.Label()
    Me.CheckBoxShowPackets = New System.Windows.Forms.CheckBox()
    Me.ButtonSendManualText = New System.Windows.Forms.Button()
    Me.TextBoxManualText = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.NumericUpDownMaxPacketSize = New System.Windows.Forms.NumericUpDown()
    Me.ButtonUpdateData = New System.Windows.Forms.Button()
    Me.SplitContainerPackets = New System.Windows.Forms.SplitContainer()
    Me.ListViewSendPackets = New System.Windows.Forms.ListView()
    Me.ColumnHeaderNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ListViewReceivePackets = New System.Windows.Forms.ListView()
    Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderData2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.TimerReconnect = New System.Windows.Forms.Timer(Me.components)
    Me.CheckBoxRelayData = New System.Windows.Forms.CheckBox()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.GroupBoxSender.SuspendLayout()
    Me.TableLayoutPanel2.SuspendLayout()
    CType(Me.NumericUpDownSenderPort, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownDataSendTime, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownMaxPacketSize, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SplitContainerPackets, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainerPackets.Panel1.SuspendLayout()
    Me.SplitContainerPackets.Panel2.SuspendLayout()
    Me.SplitContainerPackets.SuspendLayout()
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
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.70049!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.29951!))
    Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxSender, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.SplitContainerPackets, 1, 0)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(1616, 355)
    Me.TableLayoutPanel1.TabIndex = 2
    '
    'GroupBoxSender
    '
    Me.GroupBoxSender.Controls.Add(Me.TableLayoutPanel2)
    Me.GroupBoxSender.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBoxSender.Location = New System.Drawing.Point(3, 3)
    Me.GroupBoxSender.Name = "GroupBoxSender"
    Me.GroupBoxSender.Size = New System.Drawing.Size(376, 349)
    Me.GroupBoxSender.TabIndex = 0
    Me.GroupBoxSender.TabStop = False
    Me.GroupBoxSender.Text = "Sender"
    '
    'TableLayoutPanel2
    '
    Me.TableLayoutPanel2.ColumnCount = 2
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5!))
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxRelayData, 0, 2)
    Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownSenderPort, 1, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.TextBoxSenderHost, 1, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderPort, 0, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderHost, 0, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderState, 0, 8)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderDataRate, 1, 8)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonSenderConnect, 1, 2)
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxSendData, 0, 7)
    Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownDataSendTime, 1, 7)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonReset, 1, 5)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelReceiverDataRate, 0, 9)
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxShowPackets, 0, 5)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonSendManualText, 1, 4)
    Me.TableLayoutPanel2.Controls.Add(Me.TextBoxManualText, 0, 3)
    Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 6)
    Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownMaxPacketSize, 1, 6)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonUpdateData, 0, 4)
    Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 17)
    Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
    Me.TableLayoutPanel2.RowCount = 10
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.Size = New System.Drawing.Size(370, 329)
    Me.TableLayoutPanel2.TabIndex = 0
    '
    'NumericUpDownSenderPort
    '
    Me.NumericUpDownSenderPort.Location = New System.Drawing.Point(234, 28)
    Me.NumericUpDownSenderPort.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownSenderPort.Name = "NumericUpDownSenderPort"
    Me.NumericUpDownSenderPort.Size = New System.Drawing.Size(98, 21)
    Me.NumericUpDownSenderPort.TabIndex = 1
    Me.NumericUpDownSenderPort.Value = New Decimal(New Integer() {6100, 0, 0, 0})
    '
    'TextBoxSenderHost
    '
    Me.TextBoxSenderHost.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxSenderHost.Location = New System.Drawing.Point(234, 3)
    Me.TextBoxSenderHost.Name = "TextBoxSenderHost"
    Me.TextBoxSenderHost.Size = New System.Drawing.Size(133, 21)
    Me.TextBoxSenderHost.TabIndex = 2
    Me.TextBoxSenderHost.Text = "192.168.146.76"
    '
    'LabelSenderPort
    '
    Me.LabelSenderPort.AutoSize = True
    Me.LabelSenderPort.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderPort.Location = New System.Drawing.Point(3, 25)
    Me.LabelSenderPort.Name = "LabelSenderPort"
    Me.LabelSenderPort.Size = New System.Drawing.Size(225, 25)
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
    Me.LabelSenderHost.Size = New System.Drawing.Size(225, 25)
    Me.LabelSenderHost.TabIndex = 3
    Me.LabelSenderHost.Text = "Host"
    Me.LabelSenderHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelSenderState
    '
    Me.LabelSenderState.AutoSize = True
    Me.LabelSenderState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderState.Location = New System.Drawing.Point(3, 279)
    Me.LabelSenderState.Name = "LabelSenderState"
    Me.LabelSenderState.Size = New System.Drawing.Size(225, 25)
    Me.LabelSenderState.TabIndex = 4
    Me.LabelSenderState.Text = "State"
    Me.LabelSenderState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelSenderDataRate
    '
    Me.LabelSenderDataRate.AutoSize = True
    Me.LabelSenderDataRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderDataRate.Location = New System.Drawing.Point(234, 279)
    Me.LabelSenderDataRate.Name = "LabelSenderDataRate"
    Me.LabelSenderDataRate.Size = New System.Drawing.Size(133, 25)
    Me.LabelSenderDataRate.TabIndex = 4
    Me.LabelSenderDataRate.Text = "Data rate"
    Me.LabelSenderDataRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ButtonSenderConnect
    '
    Me.ButtonSenderConnect.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonSenderConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonSenderConnect.Location = New System.Drawing.Point(234, 53)
    Me.ButtonSenderConnect.Name = "ButtonSenderConnect"
    Me.ButtonSenderConnect.Size = New System.Drawing.Size(133, 29)
    Me.ButtonSenderConnect.TabIndex = 5
    Me.ButtonSenderConnect.Text = "Connect"
    Me.ButtonSenderConnect.UseVisualStyleBackColor = True
    '
    'CheckBoxSendData
    '
    Me.CheckBoxSendData.AutoSize = True
    Me.CheckBoxSendData.Location = New System.Drawing.Point(3, 257)
    Me.CheckBoxSendData.Name = "CheckBoxSendData"
    Me.CheckBoxSendData.Size = New System.Drawing.Size(75, 17)
    Me.CheckBoxSendData.TabIndex = 6
    Me.CheckBoxSendData.Text = "Send data"
    Me.CheckBoxSendData.UseVisualStyleBackColor = True
    '
    'NumericUpDownDataSendTime
    '
    Me.NumericUpDownDataSendTime.Location = New System.Drawing.Point(234, 257)
    Me.NumericUpDownDataSendTime.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownDataSendTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.NumericUpDownDataSendTime.Name = "NumericUpDownDataSendTime"
    Me.NumericUpDownDataSendTime.Size = New System.Drawing.Size(91, 21)
    Me.NumericUpDownDataSendTime.TabIndex = 7
    Me.NumericUpDownDataSendTime.Value = New Decimal(New Integer() {1000, 0, 0, 0})
    '
    'ButtonReset
    '
    Me.ButtonReset.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonReset.Location = New System.Drawing.Point(234, 197)
    Me.ButtonReset.Name = "ButtonReset"
    Me.ButtonReset.Size = New System.Drawing.Size(133, 29)
    Me.ButtonReset.TabIndex = 8
    Me.ButtonReset.Text = "Reset"
    Me.ButtonReset.UseVisualStyleBackColor = True
    '
    'LabelReceiverDataRate
    '
    Me.LabelReceiverDataRate.AutoSize = True
    Me.TableLayoutPanel2.SetColumnSpan(Me.LabelReceiverDataRate, 2)
    Me.LabelReceiverDataRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelReceiverDataRate.Location = New System.Drawing.Point(3, 304)
    Me.LabelReceiverDataRate.Name = "LabelReceiverDataRate"
    Me.LabelReceiverDataRate.Size = New System.Drawing.Size(364, 25)
    Me.LabelReceiverDataRate.TabIndex = 9
    Me.LabelReceiverDataRate.Text = "Data rate"
    '
    'CheckBoxShowPackets
    '
    Me.CheckBoxShowPackets.AutoSize = True
    Me.CheckBoxShowPackets.Location = New System.Drawing.Point(3, 197)
    Me.CheckBoxShowPackets.Name = "CheckBoxShowPackets"
    Me.CheckBoxShowPackets.Size = New System.Drawing.Size(92, 17)
    Me.CheckBoxShowPackets.TabIndex = 10
    Me.CheckBoxShowPackets.Text = "Show packets"
    Me.CheckBoxShowPackets.UseVisualStyleBackColor = True
    '
    'ButtonSendManualText
    '
    Me.ButtonSendManualText.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonSendManualText.Location = New System.Drawing.Point(234, 157)
    Me.ButtonSendManualText.Name = "ButtonSendManualText"
    Me.ButtonSendManualText.Size = New System.Drawing.Size(133, 34)
    Me.ButtonSendManualText.TabIndex = 11
    Me.ButtonSendManualText.Text = "Send text"
    Me.ButtonSendManualText.UseVisualStyleBackColor = True
    '
    'TextBoxManualText
    '
    Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxManualText, 2)
    Me.TextBoxManualText.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxManualText.Location = New System.Drawing.Point(3, 88)
    Me.TextBoxManualText.Multiline = True
    Me.TextBoxManualText.Name = "TextBoxManualText"
    Me.TextBoxManualText.Size = New System.Drawing.Size(364, 63)
    Me.TextBoxManualText.TabIndex = 12
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label1.Location = New System.Drawing.Point(3, 229)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(225, 25)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "Max Packet size"
    '
    'NumericUpDownMaxPacketSize
    '
    Me.NumericUpDownMaxPacketSize.Location = New System.Drawing.Point(234, 232)
    Me.NumericUpDownMaxPacketSize.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
    Me.NumericUpDownMaxPacketSize.Name = "NumericUpDownMaxPacketSize"
    Me.NumericUpDownMaxPacketSize.Size = New System.Drawing.Size(61, 21)
    Me.NumericUpDownMaxPacketSize.TabIndex = 14
    '
    'ButtonUpdateData
    '
    Me.ButtonUpdateData.Location = New System.Drawing.Point(3, 157)
    Me.ButtonUpdateData.Name = "ButtonUpdateData"
    Me.ButtonUpdateData.Size = New System.Drawing.Size(116, 34)
    Me.ButtonUpdateData.TabIndex = 15
    Me.ButtonUpdateData.Text = "Update data"
    Me.ButtonUpdateData.UseVisualStyleBackColor = True
    '
    'SplitContainerPackets
    '
    Me.SplitContainerPackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainerPackets.Location = New System.Drawing.Point(385, 3)
    Me.SplitContainerPackets.Name = "SplitContainerPackets"
    '
    'SplitContainerPackets.Panel1
    '
    Me.SplitContainerPackets.Panel1.Controls.Add(Me.ListViewSendPackets)
    '
    'SplitContainerPackets.Panel2
    '
    Me.SplitContainerPackets.Panel2.Controls.Add(Me.ListViewReceivePackets)
    Me.SplitContainerPackets.Size = New System.Drawing.Size(1228, 349)
    Me.SplitContainerPackets.SplitterDistance = 571
    Me.SplitContainerPackets.TabIndex = 9
    '
    'ListViewSendPackets
    '
    Me.ListViewSendPackets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderNumber, Me.ColumnHeaderSize, Me.ColumnHeaderTime, Me.ColumnHeaderData})
    Me.ListViewSendPackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListViewSendPackets.Location = New System.Drawing.Point(0, 0)
    Me.ListViewSendPackets.Name = "ListViewSendPackets"
    Me.ListViewSendPackets.Size = New System.Drawing.Size(571, 349)
    Me.ListViewSendPackets.TabIndex = 3
    Me.ListViewSendPackets.UseCompatibleStateImageBehavior = False
    Me.ListViewSendPackets.View = System.Windows.Forms.View.Details
    '
    'ColumnHeaderNumber
    '
    Me.ColumnHeaderNumber.Text = "#"
    Me.ColumnHeaderNumber.Width = 85
    '
    'ColumnHeaderSize
    '
    Me.ColumnHeaderSize.Text = "Size"
    '
    'ColumnHeaderTime
    '
    Me.ColumnHeaderTime.Text = "Time"
    '
    'ColumnHeaderData
    '
    Me.ColumnHeaderData.Text = "Data"
    '
    'ListViewReceivePackets
    '
    Me.ListViewReceivePackets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
    Me.ListViewReceivePackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListViewReceivePackets.Location = New System.Drawing.Point(0, 0)
    Me.ListViewReceivePackets.Name = "ListViewReceivePackets"
    Me.ListViewReceivePackets.Size = New System.Drawing.Size(653, 349)
    Me.ListViewReceivePackets.TabIndex = 3
    Me.ListViewReceivePackets.UseCompatibleStateImageBehavior = False
    Me.ListViewReceivePackets.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "#"
    Me.ColumnHeader1.Width = 85
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Size"
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = "Time"
    '
    'ColumnHeader4
    '
    Me.ColumnHeader4.Text = "Data"
    '
    'ColumnHeader5
    '
    Me.ColumnHeader5.Text = "Data2"
    '
    'TimerReconnect
    '
    Me.TimerReconnect.Enabled = True
    Me.TimerReconnect.Interval = 10000
    '
    'CheckBoxRelayData
    '
    Me.CheckBoxRelayData.AutoSize = True
    Me.CheckBoxRelayData.Location = New System.Drawing.Point(3, 53)
    Me.CheckBoxRelayData.Name = "CheckBoxRelayData"
    Me.CheckBoxRelayData.Size = New System.Drawing.Size(78, 17)
    Me.CheckBoxRelayData.TabIndex = 3
    Me.CheckBoxRelayData.Text = "Relay data"
    Me.CheckBoxRelayData.UseVisualStyleBackColor = True
    '
    'frmTestTCP
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1616, 355)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmTestTCP"
    Me.Text = "Sender"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.GroupBoxSender.ResumeLayout(False)
    Me.TableLayoutPanel2.ResumeLayout(False)
    Me.TableLayoutPanel2.PerformLayout()
    CType(Me.NumericUpDownSenderPort, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownDataSendTime, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownMaxPacketSize, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerPackets.Panel1.ResumeLayout(False)
    Me.SplitContainerPackets.Panel2.ResumeLayout(False)
    CType(Me.SplitContainerPackets, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerPackets.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Timer1 As Timer
  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents GroupBoxSender As GroupBox
  Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
  Friend WithEvents NumericUpDownSenderPort As NumericUpDown
  Friend WithEvents TextBoxSenderHost As TextBox
  Friend WithEvents LabelSenderPort As Label
  Friend WithEvents LabelSenderHost As Label
  Friend WithEvents LabelSenderState As Label
  Friend WithEvents LabelSenderDataRate As Label
  Friend WithEvents ButtonSenderConnect As Button
  Friend WithEvents ListViewSendPackets As ListView
  Friend WithEvents ColumnHeaderNumber As ColumnHeader
  Friend WithEvents ColumnHeaderSize As ColumnHeader
  Friend WithEvents ColumnHeaderTime As ColumnHeader
  Friend WithEvents ColumnHeaderData As ColumnHeader
  Friend WithEvents ColumnHeaderData2 As ColumnHeader
  Friend WithEvents CheckBoxSendData As CheckBox
  Friend WithEvents NumericUpDownDataSendTime As NumericUpDown
  Friend WithEvents ButtonReset As Button
  Friend WithEvents TimerReconnect As Timer
  Friend WithEvents SplitContainerPackets As SplitContainer
  Friend WithEvents ListViewReceivePackets As ListView
  Friend WithEvents ColumnHeader1 As ColumnHeader
  Friend WithEvents ColumnHeader2 As ColumnHeader
  Friend WithEvents ColumnHeader3 As ColumnHeader
  Friend WithEvents ColumnHeader4 As ColumnHeader
  Friend WithEvents ColumnHeader5 As ColumnHeader
  Friend WithEvents LabelReceiverDataRate As Label
  Friend WithEvents CheckBoxShowPackets As CheckBox
  Friend WithEvents ButtonSendManualText As Button
  Friend WithEvents TextBoxManualText As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents NumericUpDownMaxPacketSize As NumericUpDown
  Friend WithEvents ButtonUpdateData As Button
  Friend WithEvents CheckBoxRelayData As CheckBox
End Class
