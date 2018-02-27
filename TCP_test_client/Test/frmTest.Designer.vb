<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTest
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
    Me.TimerReconnect = New System.Windows.Forms.Timer(Me.components)
    Me.LabelReceiverDataRate = New System.Windows.Forms.Label()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.GroupBoxSender.SuspendLayout()
    Me.TableLayoutPanel2.SuspendLayout()
    CType(Me.NumericUpDownSenderPort, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownDataSendTime, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownSenderPort, 1, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.TextBoxSenderHost, 1, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderPort, 0, 1)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderHost, 0, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderState, 0, 6)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelSenderDataRate, 1, 6)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonSenderConnect, 1, 2)
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxSendData, 0, 5)
    Me.TableLayoutPanel2.Controls.Add(Me.NumericUpDownDataSendTime, 1, 5)
    Me.TableLayoutPanel2.Controls.Add(Me.ButtonReset, 1, 4)
    Me.TableLayoutPanel2.Controls.Add(Me.LabelReceiverDataRate, 0, 7)
    Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 23)
    Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
    Me.TableLayoutPanel2.RowCount = 8
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel2.Size = New System.Drawing.Size(370, 323)
    Me.TableLayoutPanel2.TabIndex = 0
    '
    'NumericUpDownSenderPort
    '
    Me.NumericUpDownSenderPort.Location = New System.Drawing.Point(188, 28)
    Me.NumericUpDownSenderPort.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownSenderPort.Name = "NumericUpDownSenderPort"
    Me.NumericUpDownSenderPort.Size = New System.Drawing.Size(98, 27)
    Me.NumericUpDownSenderPort.TabIndex = 1
    Me.NumericUpDownSenderPort.Value = New Decimal(New Integer() {6100, 0, 0, 0})
    '
    'TextBoxSenderHost
    '
    Me.TextBoxSenderHost.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxSenderHost.Location = New System.Drawing.Point(188, 3)
    Me.TextBoxSenderHost.Name = "TextBoxSenderHost"
    Me.TextBoxSenderHost.Size = New System.Drawing.Size(179, 27)
    Me.TextBoxSenderHost.TabIndex = 2
    Me.TextBoxSenderHost.Text = "192.168.146.76"
    '
    'LabelSenderPort
    '
    Me.LabelSenderPort.AutoSize = True
    Me.LabelSenderPort.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderPort.Location = New System.Drawing.Point(3, 25)
    Me.LabelSenderPort.Name = "LabelSenderPort"
    Me.LabelSenderPort.Size = New System.Drawing.Size(179, 25)
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
    Me.LabelSenderHost.Size = New System.Drawing.Size(179, 25)
    Me.LabelSenderHost.TabIndex = 3
    Me.LabelSenderHost.Text = "Host"
    Me.LabelSenderHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelSenderState
    '
    Me.LabelSenderState.AutoSize = True
    Me.LabelSenderState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderState.Location = New System.Drawing.Point(3, 273)
    Me.LabelSenderState.Name = "LabelSenderState"
    Me.LabelSenderState.Size = New System.Drawing.Size(179, 25)
    Me.LabelSenderState.TabIndex = 4
    Me.LabelSenderState.Text = "State"
    Me.LabelSenderState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelSenderDataRate
    '
    Me.LabelSenderDataRate.AutoSize = True
    Me.LabelSenderDataRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelSenderDataRate.Location = New System.Drawing.Point(188, 273)
    Me.LabelSenderDataRate.Name = "LabelSenderDataRate"
    Me.LabelSenderDataRate.Size = New System.Drawing.Size(179, 25)
    Me.LabelSenderDataRate.TabIndex = 4
    Me.LabelSenderDataRate.Text = "Data rate"
    Me.LabelSenderDataRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ButtonSenderConnect
    '
    Me.ButtonSenderConnect.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonSenderConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonSenderConnect.Location = New System.Drawing.Point(188, 53)
    Me.ButtonSenderConnect.Name = "ButtonSenderConnect"
    Me.ButtonSenderConnect.Size = New System.Drawing.Size(179, 29)
    Me.ButtonSenderConnect.TabIndex = 5
    Me.ButtonSenderConnect.Text = "Connect"
    Me.ButtonSenderConnect.UseVisualStyleBackColor = True
    '
    'CheckBoxSendData
    '
    Me.CheckBoxSendData.AutoSize = True
    Me.CheckBoxSendData.Location = New System.Drawing.Point(3, 251)
    Me.CheckBoxSendData.Name = "CheckBoxSendData"
    Me.CheckBoxSendData.Size = New System.Drawing.Size(110, 19)
    Me.CheckBoxSendData.TabIndex = 6
    Me.CheckBoxSendData.Text = "Send data"
    Me.CheckBoxSendData.UseVisualStyleBackColor = True
    '
    'NumericUpDownDataSendTime
    '
    Me.NumericUpDownDataSendTime.Location = New System.Drawing.Point(188, 251)
    Me.NumericUpDownDataSendTime.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownDataSendTime.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
    Me.NumericUpDownDataSendTime.Name = "NumericUpDownDataSendTime"
    Me.NumericUpDownDataSendTime.Size = New System.Drawing.Size(91, 27)
    Me.NumericUpDownDataSendTime.TabIndex = 7
    Me.NumericUpDownDataSendTime.Value = New Decimal(New Integer() {1000, 0, 0, 0})
    '
    'ButtonReset
    '
    Me.ButtonReset.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonReset.Location = New System.Drawing.Point(188, 216)
    Me.ButtonReset.Name = "ButtonReset"
    Me.ButtonReset.Size = New System.Drawing.Size(179, 29)
    Me.ButtonReset.TabIndex = 8
    Me.ButtonReset.Text = "Reset"
    Me.ButtonReset.UseVisualStyleBackColor = True
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
    Me.ListViewReceivePackets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
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
    'TimerReconnect
    '
    Me.TimerReconnect.Enabled = True
    Me.TimerReconnect.Interval = 10000
    '
    'LabelReceiverDataRate
    '
    Me.LabelReceiverDataRate.AutoSize = True
    Me.TableLayoutPanel2.SetColumnSpan(Me.LabelReceiverDataRate, 2)
    Me.LabelReceiverDataRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelReceiverDataRate.Location = New System.Drawing.Point(3, 298)
    Me.LabelReceiverDataRate.Name = "LabelReceiverDataRate"
    Me.LabelReceiverDataRate.Size = New System.Drawing.Size(364, 25)
    Me.LabelReceiverDataRate.TabIndex = 9
    Me.LabelReceiverDataRate.Text = "Data rate"
    '
    'frmTest
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1616, 355)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmTest"
    Me.Text = "Sender"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.GroupBoxSender.ResumeLayout(False)
    Me.TableLayoutPanel2.ResumeLayout(False)
    Me.TableLayoutPanel2.PerformLayout()
    CType(Me.NumericUpDownSenderPort, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownDataSendTime, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerPackets.Panel1.ResumeLayout(False)
    Me.SplitContainerPackets.Panel2.ResumeLayout(False)
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
  Friend WithEvents LabelReceiverDataRate As Label
End Class
