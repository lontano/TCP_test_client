<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRTHeadSimulator
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRTHeadSimulator))
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.NumericUpDownPan = New System.Windows.Forms.NumericUpDown()
    Me.NumericUpDownTilt = New System.Windows.Forms.NumericUpDown()
    Me.NumericUpDownZoom = New System.Windows.Forms.NumericUpDown()
    Me.NumericUpDownFocus = New System.Windows.Forms.NumericUpDown()
    Me.TextBoxHexValues = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.NumericUpDownIndex = New System.Windows.Forms.NumericUpDown()
    Me.CheckBoxSendToUDP = New System.Windows.Forms.CheckBox()
    Me.TextBoxUDPHost = New System.Windows.Forms.TextBox()
    Me.NumericUpDownUDPPort = New System.Windows.Forms.NumericUpDown()
    Me.CheckBoxSimulateDevice = New System.Windows.Forms.CheckBox()
    Me.NumericUpDownSimulationPeriod = New System.Windows.Forms.NumericUpDown()
    Me.CheckBoxSwingPan = New System.Windows.Forms.CheckBox()
    Me.CheckBoxSwingTilt = New System.Windows.Forms.CheckBox()
    Me.CheckBoxSwingZoom = New System.Windows.Forms.CheckBox()
    Me.CheckBoxSwingFocus = New System.Windows.Forms.CheckBox()
    Me.CheckBoxSendToCOM = New System.Windows.Forms.CheckBox()
    Me.ComboBoxSendCOM = New System.Windows.Forms.ComboBox()
    Me.CheckBoxReceiveFromUDP = New System.Windows.Forms.CheckBox()
    Me.NumericUpDownUDPReceivePort = New System.Windows.Forms.NumericUpDown()
    Me.CheckBoxReceiveFromCOMPort = New System.Windows.Forms.CheckBox()
    Me.ComboBoxComPort = New System.Windows.Forms.ComboBox()
    Me.TimerPacketFactory = New System.Windows.Forms.Timer(Me.components)
    Me.SplitContainerAll = New System.Windows.Forms.SplitContainer()
    Me.GroupBoxSource = New System.Windows.Forms.GroupBox()
    Me.GroupBoxRTHeadReceiver = New System.Windows.Forms.GroupBox()
    Me.TableLayoutPanelReceiver = New System.Windows.Forms.TableLayoutPanel()
    Me.TableLayoutPanelPacketFactory = New System.Windows.Forms.TableLayoutPanel()
    Me.LabelPackerFactoryNonConsecutivePackets = New System.Windows.Forms.Label()
    Me.LabelPackerFactoryBytesDiscarded = New System.Windows.Forms.Label()
    Me.LabelPackerFactoryBytesProcessed = New System.Windows.Forms.Label()
    Me.LabelPackerFactoryPackets = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.LabelPackerFactoryTimingMean = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LabelPackerFactoryTimingStdDev = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LabelPacketIndex = New System.Windows.Forms.Label()
    Me.LabelPacketPan = New System.Windows.Forms.Label()
    Me.LabelPacketTilt = New System.Windows.Forms.Label()
    Me.LabelPacketZoom = New System.Windows.Forms.Label()
    Me.LabelPacketFocus = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.LabelPacketFactoryPacketsPerSecond = New System.Windows.Forms.Label()
    Me.TabControlPacketAnalyzers = New System.Windows.Forms.TabControl()
    Me.TabPagePacketList = New System.Windows.Forms.TabPage()
    Me.TableLayoutPanelPacketList = New System.Windows.Forms.TableLayoutPanel()
    Me.ListViewReceivedPackets = New System.Windows.Forms.ListView()
    Me.ColumnHeaderIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderWarning = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderTimeStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderPan = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderTilt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderZoom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderFocus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderContents = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ContextMenuStripReceiver = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.UpdateReceivedPacketsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
    Me.GotoFirstWarningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.NextWarningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.PreviousWarningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.GotoLastWarningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
    Me.ResetSessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CheckBoxPacketListAutoUpdate = New System.Windows.Forms.CheckBox()
    Me.TableLayoutPanelWarnings = New System.Windows.Forms.TableLayoutPanel()
    Me.ButtonWarningsFirst = New System.Windows.Forms.Button()
    Me.ButtonWarningsPrevious = New System.Windows.Forms.Button()
    Me.ButtonWarningsNext = New System.Windows.Forms.Button()
    Me.ButtonWarningsLast = New System.Windows.Forms.Button()
    Me.LabelWarnings = New System.Windows.Forms.Label()
    Me.TabPageTiming = New System.Windows.Forms.TabPage()
    Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
    Me.CheckBoxTimingAutoUpdate = New System.Windows.Forms.CheckBox()
    Me.PictureBoxTiming = New System.Windows.Forms.PictureBox()
    Me.ContextMenuStripTiming = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
    Me.ResetSessionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.NumericUpDownPan, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownTilt, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownZoom, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownFocus, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownIndex, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownUDPPort, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownSimulationPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownUDPReceivePort, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SplitContainerAll, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainerAll.Panel1.SuspendLayout()
    Me.SplitContainerAll.Panel2.SuspendLayout()
    Me.SplitContainerAll.SuspendLayout()
    Me.GroupBoxSource.SuspendLayout()
    Me.GroupBoxRTHeadReceiver.SuspendLayout()
    Me.TableLayoutPanelReceiver.SuspendLayout()
    Me.TableLayoutPanelPacketFactory.SuspendLayout()
    Me.TabControlPacketAnalyzers.SuspendLayout()
    Me.TabPagePacketList.SuspendLayout()
    Me.TableLayoutPanelPacketList.SuspendLayout()
    Me.ContextMenuStripReceiver.SuspendLayout()
    Me.TableLayoutPanelWarnings.SuspendLayout()
    Me.TabPageTiming.SuspendLayout()
    Me.TableLayoutPanel2.SuspendLayout()
    CType(Me.PictureBoxTiming, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ContextMenuStripTiming.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 4
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownPan, 1, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownTilt, 1, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownZoom, 1, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownFocus, 1, 4)
    Me.TableLayoutPanel1.Controls.Add(Me.TextBoxHexValues, 0, 5)
    Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownIndex, 1, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSendToUDP, 1, 8)
    Me.TableLayoutPanel1.Controls.Add(Me.TextBoxUDPHost, 2, 8)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownUDPPort, 3, 8)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSimulateDevice, 1, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownSimulationPeriod, 2, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingPan, 2, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingTilt, 2, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingZoom, 2, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingFocus, 2, 4)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSendToCOM, 1, 9)
    Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxSendCOM, 2, 9)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 10
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(331, 377)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 25)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(26, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Pan"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(3, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(22, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Tilt"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(3, 75)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(36, 13)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "Zoom"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(3, 100)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(37, 13)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "Focus"
    '
    'NumericUpDownPan
    '
    Me.NumericUpDownPan.Location = New System.Drawing.Point(48, 28)
    Me.NumericUpDownPan.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
    Me.NumericUpDownPan.Minimum = New Decimal(New Integer() {30000, 0, 0, -2147483648})
    Me.NumericUpDownPan.Name = "NumericUpDownPan"
    Me.NumericUpDownPan.Size = New System.Drawing.Size(94, 22)
    Me.NumericUpDownPan.TabIndex = 4
    Me.NumericUpDownPan.Value = New Decimal(New Integer() {30000, 0, 0, 0})
    '
    'NumericUpDownTilt
    '
    Me.NumericUpDownTilt.Location = New System.Drawing.Point(48, 53)
    Me.NumericUpDownTilt.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
    Me.NumericUpDownTilt.Minimum = New Decimal(New Integer() {30000, 0, 0, -2147483648})
    Me.NumericUpDownTilt.Name = "NumericUpDownTilt"
    Me.NumericUpDownTilt.Size = New System.Drawing.Size(94, 22)
    Me.NumericUpDownTilt.TabIndex = 4
    Me.NumericUpDownTilt.Value = New Decimal(New Integer() {30000, 0, 0, 0})
    '
    'NumericUpDownZoom
    '
    Me.NumericUpDownZoom.Location = New System.Drawing.Point(48, 78)
    Me.NumericUpDownZoom.Maximum = New Decimal(New Integer() {12000, 0, 0, 0})
    Me.NumericUpDownZoom.Minimum = New Decimal(New Integer() {12000, 0, 0, -2147483648})
    Me.NumericUpDownZoom.Name = "NumericUpDownZoom"
    Me.NumericUpDownZoom.Size = New System.Drawing.Size(94, 22)
    Me.NumericUpDownZoom.TabIndex = 4
    Me.NumericUpDownZoom.Value = New Decimal(New Integer() {8320, 0, 0, 0})
    '
    'NumericUpDownFocus
    '
    Me.NumericUpDownFocus.Location = New System.Drawing.Point(48, 103)
    Me.NumericUpDownFocus.Maximum = New Decimal(New Integer() {12000, 0, 0, 0})
    Me.NumericUpDownFocus.Minimum = New Decimal(New Integer() {12000, 0, 0, -2147483648})
    Me.NumericUpDownFocus.Name = "NumericUpDownFocus"
    Me.NumericUpDownFocus.Size = New System.Drawing.Size(94, 22)
    Me.NumericUpDownFocus.TabIndex = 4
    Me.NumericUpDownFocus.Value = New Decimal(New Integer() {4110, 0, 0, 0})
    '
    'TextBoxHexValues
    '
    Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxHexValues, 3)
    Me.TextBoxHexValues.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxHexValues.Location = New System.Drawing.Point(3, 128)
    Me.TextBoxHexValues.Name = "TextBoxHexValues"
    Me.TextBoxHexValues.Size = New System.Drawing.Size(255, 22)
    Me.TextBoxHexValues.TabIndex = 5
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(3, 0)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(35, 13)
    Me.Label5.TabIndex = 6
    Me.Label5.Text = "Index"
    '
    'NumericUpDownIndex
    '
    Me.NumericUpDownIndex.Location = New System.Drawing.Point(48, 3)
    Me.NumericUpDownIndex.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
    Me.NumericUpDownIndex.Name = "NumericUpDownIndex"
    Me.NumericUpDownIndex.Size = New System.Drawing.Size(50, 22)
    Me.NumericUpDownIndex.TabIndex = 7
    Me.NumericUpDownIndex.Value = New Decimal(New Integer() {3, 0, 0, 0})
    '
    'CheckBoxSendToUDP
    '
    Me.CheckBoxSendToUDP.AutoSize = True
    Me.CheckBoxSendToUDP.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxSendToUDP.Location = New System.Drawing.Point(48, 330)
    Me.CheckBoxSendToUDP.Name = "CheckBoxSendToUDP"
    Me.CheckBoxSendToUDP.Size = New System.Drawing.Size(120, 19)
    Me.CheckBoxSendToUDP.TabIndex = 8
    Me.CheckBoxSendToUDP.Text = "Send to UDP"
    Me.CheckBoxSendToUDP.UseVisualStyleBackColor = True
    '
    'TextBoxUDPHost
    '
    Me.TextBoxUDPHost.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxUDPHost.Location = New System.Drawing.Point(174, 330)
    Me.TextBoxUDPHost.Name = "TextBoxUDPHost"
    Me.TextBoxUDPHost.Size = New System.Drawing.Size(84, 22)
    Me.TextBoxUDPHost.TabIndex = 9
    Me.TextBoxUDPHost.Text = "127.0.0.1"
    '
    'NumericUpDownUDPPort
    '
    Me.NumericUpDownUDPPort.Location = New System.Drawing.Point(264, 330)
    Me.NumericUpDownUDPPort.Maximum = New Decimal(New Integer() {6500, 0, 0, 0})
    Me.NumericUpDownUDPPort.Name = "NumericUpDownUDPPort"
    Me.NumericUpDownUDPPort.Size = New System.Drawing.Size(52, 22)
    Me.NumericUpDownUDPPort.TabIndex = 10
    Me.NumericUpDownUDPPort.Value = New Decimal(New Integer() {6301, 0, 0, 0})
    '
    'CheckBoxSimulateDevice
    '
    Me.CheckBoxSimulateDevice.AutoSize = True
    Me.CheckBoxSimulateDevice.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxSimulateDevice.Location = New System.Drawing.Point(48, 305)
    Me.CheckBoxSimulateDevice.Name = "CheckBoxSimulateDevice"
    Me.CheckBoxSimulateDevice.Size = New System.Drawing.Size(120, 19)
    Me.CheckBoxSimulateDevice.TabIndex = 11
    Me.CheckBoxSimulateDevice.Text = "Simulate device"
    Me.CheckBoxSimulateDevice.UseVisualStyleBackColor = True
    '
    'NumericUpDownSimulationPeriod
    '
    Me.NumericUpDownSimulationPeriod.Location = New System.Drawing.Point(174, 305)
    Me.NumericUpDownSimulationPeriod.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.NumericUpDownSimulationPeriod.Name = "NumericUpDownSimulationPeriod"
    Me.NumericUpDownSimulationPeriod.Size = New System.Drawing.Size(84, 22)
    Me.NumericUpDownSimulationPeriod.TabIndex = 12
    Me.NumericUpDownSimulationPeriod.Value = New Decimal(New Integer() {10, 0, 0, 0})
    '
    'CheckBoxSwingPan
    '
    Me.CheckBoxSwingPan.AutoSize = True
    Me.CheckBoxSwingPan.Location = New System.Drawing.Point(174, 28)
    Me.CheckBoxSwingPan.Name = "CheckBoxSwingPan"
    Me.CheckBoxSwingPan.Size = New System.Drawing.Size(58, 17)
    Me.CheckBoxSwingPan.TabIndex = 13
    Me.CheckBoxSwingPan.Tag = "Pan"
    Me.CheckBoxSwingPan.Text = "Swing"
    Me.CheckBoxSwingPan.UseVisualStyleBackColor = True
    '
    'CheckBoxSwingTilt
    '
    Me.CheckBoxSwingTilt.AutoSize = True
    Me.CheckBoxSwingTilt.Location = New System.Drawing.Point(174, 53)
    Me.CheckBoxSwingTilt.Name = "CheckBoxSwingTilt"
    Me.CheckBoxSwingTilt.Size = New System.Drawing.Size(58, 17)
    Me.CheckBoxSwingTilt.TabIndex = 13
    Me.CheckBoxSwingTilt.Tag = "Pan"
    Me.CheckBoxSwingTilt.Text = "Swing"
    Me.CheckBoxSwingTilt.UseVisualStyleBackColor = True
    '
    'CheckBoxSwingZoom
    '
    Me.CheckBoxSwingZoom.AutoSize = True
    Me.CheckBoxSwingZoom.Location = New System.Drawing.Point(174, 78)
    Me.CheckBoxSwingZoom.Name = "CheckBoxSwingZoom"
    Me.CheckBoxSwingZoom.Size = New System.Drawing.Size(58, 17)
    Me.CheckBoxSwingZoom.TabIndex = 13
    Me.CheckBoxSwingZoom.Tag = "Pan"
    Me.CheckBoxSwingZoom.Text = "Swing"
    Me.CheckBoxSwingZoom.UseVisualStyleBackColor = True
    '
    'CheckBoxSwingFocus
    '
    Me.CheckBoxSwingFocus.AutoSize = True
    Me.CheckBoxSwingFocus.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxSwingFocus.Location = New System.Drawing.Point(174, 103)
    Me.CheckBoxSwingFocus.Name = "CheckBoxSwingFocus"
    Me.CheckBoxSwingFocus.Size = New System.Drawing.Size(84, 19)
    Me.CheckBoxSwingFocus.TabIndex = 13
    Me.CheckBoxSwingFocus.Tag = "Pan"
    Me.CheckBoxSwingFocus.Text = "Swing"
    Me.CheckBoxSwingFocus.UseVisualStyleBackColor = True
    '
    'CheckBoxSendToCOM
    '
    Me.CheckBoxSendToCOM.AutoSize = True
    Me.CheckBoxSendToCOM.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxSendToCOM.Location = New System.Drawing.Point(48, 355)
    Me.CheckBoxSendToCOM.Name = "CheckBoxSendToCOM"
    Me.CheckBoxSendToCOM.Size = New System.Drawing.Size(120, 19)
    Me.CheckBoxSendToCOM.TabIndex = 14
    Me.CheckBoxSendToCOM.Text = "Send to COM"
    Me.CheckBoxSendToCOM.UseVisualStyleBackColor = True
    '
    'ComboBoxSendCOM
    '
    Me.ComboBoxSendCOM.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ComboBoxSendCOM.FormattingEnabled = True
    Me.ComboBoxSendCOM.Location = New System.Drawing.Point(174, 355)
    Me.ComboBoxSendCOM.Name = "ComboBoxSendCOM"
    Me.ComboBoxSendCOM.Size = New System.Drawing.Size(84, 21)
    Me.ComboBoxSendCOM.TabIndex = 15
    '
    'CheckBoxReceiveFromUDP
    '
    Me.CheckBoxReceiveFromUDP.AutoSize = True
    Me.CheckBoxReceiveFromUDP.Location = New System.Drawing.Point(48, 330)
    Me.CheckBoxReceiveFromUDP.Name = "CheckBoxReceiveFromUDP"
    Me.CheckBoxReceiveFromUDP.Size = New System.Drawing.Size(116, 17)
    Me.CheckBoxReceiveFromUDP.TabIndex = 17
    Me.CheckBoxReceiveFromUDP.Text = "Receive from UDP"
    Me.CheckBoxReceiveFromUDP.UseVisualStyleBackColor = True
    '
    'NumericUpDownUDPReceivePort
    '
    Me.NumericUpDownUDPReceivePort.Location = New System.Drawing.Point(176, 330)
    Me.NumericUpDownUDPReceivePort.Maximum = New Decimal(New Integer() {6500, 0, 0, 0})
    Me.NumericUpDownUDPReceivePort.Name = "NumericUpDownUDPReceivePort"
    Me.NumericUpDownUDPReceivePort.Size = New System.Drawing.Size(52, 22)
    Me.NumericUpDownUDPReceivePort.TabIndex = 10
    Me.NumericUpDownUDPReceivePort.Value = New Decimal(New Integer() {6301, 0, 0, 0})
    '
    'CheckBoxReceiveFromCOMPort
    '
    Me.CheckBoxReceiveFromCOMPort.AutoSize = True
    Me.CheckBoxReceiveFromCOMPort.Location = New System.Drawing.Point(48, 355)
    Me.CheckBoxReceiveFromCOMPort.Name = "CheckBoxReceiveFromCOMPort"
    Me.CheckBoxReceiveFromCOMPort.Size = New System.Drawing.Size(120, 17)
    Me.CheckBoxReceiveFromCOMPort.TabIndex = 18
    Me.CheckBoxReceiveFromCOMPort.Text = "Receive from COM"
    Me.CheckBoxReceiveFromCOMPort.UseVisualStyleBackColor = True
    '
    'ComboBoxComPort
    '
    Me.ComboBoxComPort.FormattingEnabled = True
    Me.ComboBoxComPort.Location = New System.Drawing.Point(176, 355)
    Me.ComboBoxComPort.Name = "ComboBoxComPort"
    Me.ComboBoxComPort.Size = New System.Drawing.Size(84, 21)
    Me.ComboBoxComPort.TabIndex = 19
    '
    'TimerPacketFactory
    '
    Me.TimerPacketFactory.Enabled = True
    '
    'SplitContainerAll
    '
    Me.SplitContainerAll.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainerAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainerAll.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainerAll.Name = "SplitContainerAll"
    '
    'SplitContainerAll.Panel1
    '
    Me.SplitContainerAll.Panel1.Controls.Add(Me.GroupBoxSource)
    '
    'SplitContainerAll.Panel2
    '
    Me.SplitContainerAll.Panel2.Controls.Add(Me.GroupBoxRTHeadReceiver)
    Me.SplitContainerAll.Size = New System.Drawing.Size(1008, 398)
    Me.SplitContainerAll.SplitterDistance = 337
    Me.SplitContainerAll.TabIndex = 1
    '
    'GroupBoxSource
    '
    Me.GroupBoxSource.Controls.Add(Me.TableLayoutPanel1)
    Me.GroupBoxSource.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBoxSource.Location = New System.Drawing.Point(0, 0)
    Me.GroupBoxSource.Name = "GroupBoxSource"
    Me.GroupBoxSource.Size = New System.Drawing.Size(337, 398)
    Me.GroupBoxSource.TabIndex = 0
    Me.GroupBoxSource.TabStop = False
    Me.GroupBoxSource.Text = "RTHead source simulator"
    '
    'GroupBoxRTHeadReceiver
    '
    Me.GroupBoxRTHeadReceiver.Controls.Add(Me.TableLayoutPanelReceiver)
    Me.GroupBoxRTHeadReceiver.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBoxRTHeadReceiver.Location = New System.Drawing.Point(0, 0)
    Me.GroupBoxRTHeadReceiver.Name = "GroupBoxRTHeadReceiver"
    Me.GroupBoxRTHeadReceiver.Size = New System.Drawing.Size(667, 398)
    Me.GroupBoxRTHeadReceiver.TabIndex = 0
    Me.GroupBoxRTHeadReceiver.TabStop = False
    Me.GroupBoxRTHeadReceiver.Text = "RT Head receiver simulator"
    '
    'TableLayoutPanelReceiver
    '
    Me.TableLayoutPanelReceiver.ColumnCount = 5
    Me.TableLayoutPanelReceiver.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
    Me.TableLayoutPanelReceiver.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
    Me.TableLayoutPanelReceiver.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
    Me.TableLayoutPanelReceiver.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
    Me.TableLayoutPanelReceiver.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelReceiver.Controls.Add(Me.CheckBoxReceiveFromUDP, 1, 1)
    Me.TableLayoutPanelReceiver.Controls.Add(Me.NumericUpDownUDPReceivePort, 2, 1)
    Me.TableLayoutPanelReceiver.Controls.Add(Me.CheckBoxReceiveFromCOMPort, 1, 2)
    Me.TableLayoutPanelReceiver.Controls.Add(Me.ComboBoxComPort, 2, 2)
    Me.TableLayoutPanelReceiver.Controls.Add(Me.TableLayoutPanelPacketFactory, 0, 0)
    Me.TableLayoutPanelReceiver.Controls.Add(Me.TabControlPacketAnalyzers, 3, 0)
    Me.TableLayoutPanelReceiver.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelReceiver.Location = New System.Drawing.Point(3, 18)
    Me.TableLayoutPanelReceiver.Name = "TableLayoutPanelReceiver"
    Me.TableLayoutPanelReceiver.RowCount = 3
    Me.TableLayoutPanelReceiver.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelReceiver.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelReceiver.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelReceiver.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelReceiver.Size = New System.Drawing.Size(661, 377)
    Me.TableLayoutPanelReceiver.TabIndex = 0
    '
    'TableLayoutPanelPacketFactory
    '
    Me.TableLayoutPanelPacketFactory.ColumnCount = 2
    Me.TableLayoutPanelReceiver.SetColumnSpan(Me.TableLayoutPanelPacketFactory, 3)
    Me.TableLayoutPanelPacketFactory.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
    Me.TableLayoutPanelPacketFactory.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPackerFactoryNonConsecutivePackets, 1, 3)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPackerFactoryBytesDiscarded, 1, 2)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPackerFactoryBytesProcessed, 1, 1)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPackerFactoryPackets, 1, 0)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label6, 0, 0)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label7, 0, 1)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label8, 0, 2)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label9, 0, 3)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label10, 0, 4)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPackerFactoryTimingMean, 1, 4)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label12, 0, 5)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPackerFactoryTimingStdDev, 1, 5)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label11, 0, 8)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label13, 0, 9)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label14, 0, 10)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label15, 0, 11)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label16, 0, 12)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPacketIndex, 1, 8)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPacketPan, 1, 9)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPacketTilt, 1, 10)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPacketZoom, 1, 11)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPacketFocus, 1, 12)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.Label17, 0, 6)
    Me.TableLayoutPanelPacketFactory.Controls.Add(Me.LabelPacketFactoryPacketsPerSecond, 1, 6)
    Me.TableLayoutPanelPacketFactory.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelPacketFactory.Location = New System.Drawing.Point(3, 3)
    Me.TableLayoutPanelPacketFactory.Name = "TableLayoutPanelPacketFactory"
    Me.TableLayoutPanelPacketFactory.RowCount = 13
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelPacketFactory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelPacketFactory.Size = New System.Drawing.Size(264, 321)
    Me.TableLayoutPanelPacketFactory.TabIndex = 22
    '
    'LabelPackerFactoryNonConsecutivePackets
    '
    Me.LabelPackerFactoryNonConsecutivePackets.AutoSize = True
    Me.LabelPackerFactoryNonConsecutivePackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelPackerFactoryNonConsecutivePackets.Location = New System.Drawing.Point(123, 75)
    Me.LabelPackerFactoryNonConsecutivePackets.Name = "LabelPackerFactoryNonConsecutivePackets"
    Me.LabelPackerFactoryNonConsecutivePackets.Size = New System.Drawing.Size(138, 25)
    Me.LabelPackerFactoryNonConsecutivePackets.TabIndex = 3
    Me.LabelPackerFactoryNonConsecutivePackets.Text = "Label6"
    '
    'LabelPackerFactoryBytesDiscarded
    '
    Me.LabelPackerFactoryBytesDiscarded.AutoSize = True
    Me.LabelPackerFactoryBytesDiscarded.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelPackerFactoryBytesDiscarded.Location = New System.Drawing.Point(123, 50)
    Me.LabelPackerFactoryBytesDiscarded.Name = "LabelPackerFactoryBytesDiscarded"
    Me.LabelPackerFactoryBytesDiscarded.Size = New System.Drawing.Size(138, 25)
    Me.LabelPackerFactoryBytesDiscarded.TabIndex = 2
    Me.LabelPackerFactoryBytesDiscarded.Text = "Label6"
    '
    'LabelPackerFactoryBytesProcessed
    '
    Me.LabelPackerFactoryBytesProcessed.AutoSize = True
    Me.LabelPackerFactoryBytesProcessed.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelPackerFactoryBytesProcessed.Location = New System.Drawing.Point(123, 25)
    Me.LabelPackerFactoryBytesProcessed.Name = "LabelPackerFactoryBytesProcessed"
    Me.LabelPackerFactoryBytesProcessed.Size = New System.Drawing.Size(138, 25)
    Me.LabelPackerFactoryBytesProcessed.TabIndex = 1
    Me.LabelPackerFactoryBytesProcessed.Text = "Label6"
    '
    'LabelPackerFactoryPackets
    '
    Me.LabelPackerFactoryPackets.AutoSize = True
    Me.LabelPackerFactoryPackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelPackerFactoryPackets.Location = New System.Drawing.Point(123, 0)
    Me.LabelPackerFactoryPackets.Name = "LabelPackerFactoryPackets"
    Me.LabelPackerFactoryPackets.Size = New System.Drawing.Size(138, 25)
    Me.LabelPackerFactoryPackets.TabIndex = 0
    Me.LabelPackerFactoryPackets.Text = "Label6"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label6.Location = New System.Drawing.Point(3, 0)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(114, 25)
    Me.Label6.TabIndex = 4
    Me.Label6.Text = "Detected packets"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label7.Location = New System.Drawing.Point(3, 25)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(114, 25)
    Me.Label7.TabIndex = 5
    Me.Label7.Text = "Bytes processed"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label8.Location = New System.Drawing.Point(3, 50)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(114, 25)
    Me.Label8.TabIndex = 6
    Me.Label8.Text = "Bytes discarded"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label9.Location = New System.Drawing.Point(3, 75)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(114, 25)
    Me.Label9.TabIndex = 7
    Me.Label9.Text = "Non consecutive packets"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label10.Location = New System.Drawing.Point(3, 100)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(114, 25)
    Me.Label10.TabIndex = 8
    Me.Label10.Text = "Timing mean"
    '
    'LabelPackerFactoryTimingMean
    '
    Me.LabelPackerFactoryTimingMean.AutoSize = True
    Me.LabelPackerFactoryTimingMean.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelPackerFactoryTimingMean.Location = New System.Drawing.Point(123, 100)
    Me.LabelPackerFactoryTimingMean.Name = "LabelPackerFactoryTimingMean"
    Me.LabelPackerFactoryTimingMean.Size = New System.Drawing.Size(138, 25)
    Me.LabelPackerFactoryTimingMean.TabIndex = 8
    Me.LabelPackerFactoryTimingMean.Text = "Label10"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label12.Location = New System.Drawing.Point(3, 125)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(114, 25)
    Me.Label12.TabIndex = 8
    Me.Label12.Text = "Timing std dev"
    '
    'LabelPackerFactoryTimingStdDev
    '
    Me.LabelPackerFactoryTimingStdDev.AutoSize = True
    Me.LabelPackerFactoryTimingStdDev.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelPackerFactoryTimingStdDev.Location = New System.Drawing.Point(123, 125)
    Me.LabelPackerFactoryTimingStdDev.Name = "LabelPackerFactoryTimingStdDev"
    Me.LabelPackerFactoryTimingStdDev.Size = New System.Drawing.Size(138, 25)
    Me.LabelPackerFactoryTimingStdDev.TabIndex = 8
    Me.LabelPackerFactoryTimingStdDev.Text = "Label10"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(3, 221)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(35, 13)
    Me.Label11.TabIndex = 9
    Me.Label11.Text = "Index"
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(3, 241)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(26, 13)
    Me.Label13.TabIndex = 9
    Me.Label13.Text = "Pan"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(3, 261)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(22, 13)
    Me.Label14.TabIndex = 9
    Me.Label14.Text = "Tilt"
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(3, 281)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 13)
    Me.Label15.TabIndex = 9
    Me.Label15.Text = "Zoom"
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(3, 301)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(37, 13)
    Me.Label16.TabIndex = 9
    Me.Label16.Text = "Focus"
    '
    'LabelPacketIndex
    '
    Me.LabelPacketIndex.AutoSize = True
    Me.LabelPacketIndex.Location = New System.Drawing.Point(123, 221)
    Me.LabelPacketIndex.Name = "LabelPacketIndex"
    Me.LabelPacketIndex.Size = New System.Drawing.Size(46, 13)
    Me.LabelPacketIndex.TabIndex = 9
    Me.LabelPacketIndex.Text = "Label11"
    '
    'LabelPacketPan
    '
    Me.LabelPacketPan.AutoSize = True
    Me.LabelPacketPan.Location = New System.Drawing.Point(123, 241)
    Me.LabelPacketPan.Name = "LabelPacketPan"
    Me.LabelPacketPan.Size = New System.Drawing.Size(46, 13)
    Me.LabelPacketPan.TabIndex = 9
    Me.LabelPacketPan.Text = "Label11"
    '
    'LabelPacketTilt
    '
    Me.LabelPacketTilt.AutoSize = True
    Me.LabelPacketTilt.Location = New System.Drawing.Point(123, 261)
    Me.LabelPacketTilt.Name = "LabelPacketTilt"
    Me.LabelPacketTilt.Size = New System.Drawing.Size(46, 13)
    Me.LabelPacketTilt.TabIndex = 9
    Me.LabelPacketTilt.Text = "Label11"
    '
    'LabelPacketZoom
    '
    Me.LabelPacketZoom.AutoSize = True
    Me.LabelPacketZoom.Location = New System.Drawing.Point(123, 281)
    Me.LabelPacketZoom.Name = "LabelPacketZoom"
    Me.LabelPacketZoom.Size = New System.Drawing.Size(46, 13)
    Me.LabelPacketZoom.TabIndex = 9
    Me.LabelPacketZoom.Text = "Label11"
    '
    'LabelPacketFocus
    '
    Me.LabelPacketFocus.AutoSize = True
    Me.LabelPacketFocus.Location = New System.Drawing.Point(123, 301)
    Me.LabelPacketFocus.Name = "LabelPacketFocus"
    Me.LabelPacketFocus.Size = New System.Drawing.Size(46, 13)
    Me.LabelPacketFocus.TabIndex = 9
    Me.LabelPacketFocus.Text = "Label11"
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label17.Location = New System.Drawing.Point(3, 150)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(114, 25)
    Me.Label17.TabIndex = 10
    Me.Label17.Text = "Packets per second"
    '
    'LabelPacketFactoryPacketsPerSecond
    '
    Me.LabelPacketFactoryPacketsPerSecond.AutoSize = True
    Me.LabelPacketFactoryPacketsPerSecond.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelPacketFactoryPacketsPerSecond.Location = New System.Drawing.Point(123, 150)
    Me.LabelPacketFactoryPacketsPerSecond.Name = "LabelPacketFactoryPacketsPerSecond"
    Me.LabelPacketFactoryPacketsPerSecond.Size = New System.Drawing.Size(138, 25)
    Me.LabelPacketFactoryPacketsPerSecond.TabIndex = 11
    Me.LabelPacketFactoryPacketsPerSecond.Text = "Label18"
    '
    'TabControlPacketAnalyzers
    '
    Me.TableLayoutPanelReceiver.SetColumnSpan(Me.TabControlPacketAnalyzers, 2)
    Me.TabControlPacketAnalyzers.Controls.Add(Me.TabPagePacketList)
    Me.TabControlPacketAnalyzers.Controls.Add(Me.TabPageTiming)
    Me.TabControlPacketAnalyzers.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControlPacketAnalyzers.Location = New System.Drawing.Point(273, 3)
    Me.TabControlPacketAnalyzers.Name = "TabControlPacketAnalyzers"
    Me.TabControlPacketAnalyzers.SelectedIndex = 0
    Me.TabControlPacketAnalyzers.Size = New System.Drawing.Size(385, 321)
    Me.TabControlPacketAnalyzers.TabIndex = 24
    '
    'TabPagePacketList
    '
    Me.TabPagePacketList.Controls.Add(Me.TableLayoutPanelPacketList)
    Me.TabPagePacketList.Location = New System.Drawing.Point(4, 22)
    Me.TabPagePacketList.Name = "TabPagePacketList"
    Me.TabPagePacketList.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPagePacketList.Size = New System.Drawing.Size(377, 295)
    Me.TabPagePacketList.TabIndex = 0
    Me.TabPagePacketList.Text = "Packet list"
    Me.TabPagePacketList.UseVisualStyleBackColor = True
    '
    'TableLayoutPanelPacketList
    '
    Me.TableLayoutPanelPacketList.ColumnCount = 2
    Me.TableLayoutPanelPacketList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelPacketList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
    Me.TableLayoutPanelPacketList.Controls.Add(Me.ListViewReceivedPackets, 0, 1)
    Me.TableLayoutPanelPacketList.Controls.Add(Me.CheckBoxPacketListAutoUpdate, 0, 0)
    Me.TableLayoutPanelPacketList.Controls.Add(Me.TableLayoutPanelWarnings, 1, 0)
    Me.TableLayoutPanelPacketList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelPacketList.Location = New System.Drawing.Point(3, 3)
    Me.TableLayoutPanelPacketList.Name = "TableLayoutPanelPacketList"
    Me.TableLayoutPanelPacketList.RowCount = 2
    Me.TableLayoutPanelPacketList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanelPacketList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelPacketList.Size = New System.Drawing.Size(371, 289)
    Me.TableLayoutPanelPacketList.TabIndex = 0
    '
    'ListViewReceivedPackets
    '
    Me.ListViewReceivedPackets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderIndex, Me.ColumnHeaderCount, Me.ColumnHeaderWarning, Me.ColumnHeaderTimeStamp, Me.ColumnHeaderPan, Me.ColumnHeaderTilt, Me.ColumnHeaderZoom, Me.ColumnHeaderFocus, Me.ColumnHeaderContents})
    Me.TableLayoutPanelPacketList.SetColumnSpan(Me.ListViewReceivedPackets, 2)
    Me.ListViewReceivedPackets.ContextMenuStrip = Me.ContextMenuStripReceiver
    Me.ListViewReceivedPackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListViewReceivedPackets.FullRowSelect = True
    Me.ListViewReceivedPackets.HideSelection = False
    Me.ListViewReceivedPackets.Location = New System.Drawing.Point(3, 33)
    Me.ListViewReceivedPackets.Name = "ListViewReceivedPackets"
    Me.ListViewReceivedPackets.Size = New System.Drawing.Size(365, 253)
    Me.ListViewReceivedPackets.TabIndex = 20
    Me.ListViewReceivedPackets.UseCompatibleStateImageBehavior = False
    Me.ListViewReceivedPackets.View = System.Windows.Forms.View.Details
    '
    'ColumnHeaderIndex
    '
    Me.ColumnHeaderIndex.Text = "Index"
    Me.ColumnHeaderIndex.Width = 40
    '
    'ColumnHeaderCount
    '
    Me.ColumnHeaderCount.Text = "#"
    Me.ColumnHeaderCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.ColumnHeaderCount.Width = 30
    '
    'ColumnHeaderWarning
    '
    Me.ColumnHeaderWarning.Text = "Warning"
    Me.ColumnHeaderWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'ColumnHeaderTimeStamp
    '
    Me.ColumnHeaderTimeStamp.Text = "Diff"
    Me.ColumnHeaderTimeStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ColumnHeaderPan
    '
    Me.ColumnHeaderPan.Text = "Pan"
    Me.ColumnHeaderPan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ColumnHeaderTilt
    '
    Me.ColumnHeaderTilt.Text = "Tilt"
    Me.ColumnHeaderTilt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ColumnHeaderZoom
    '
    Me.ColumnHeaderZoom.Text = "Zoom"
    Me.ColumnHeaderZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ColumnHeaderFocus
    '
    Me.ColumnHeaderFocus.Text = "Focus"
    Me.ColumnHeaderFocus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'ColumnHeaderContents
    '
    Me.ColumnHeaderContents.Text = "Data"
    Me.ColumnHeaderContents.Width = 800
    '
    'ContextMenuStripReceiver
    '
    Me.ContextMenuStripReceiver.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateReceivedPacketsToolStripMenuItem, Me.ToolStripMenuItem1, Me.GotoFirstWarningToolStripMenuItem, Me.NextWarningToolStripMenuItem, Me.PreviousWarningToolStripMenuItem, Me.GotoLastWarningToolStripMenuItem, Me.ToolStripMenuItem2, Me.ResetSessionToolStripMenuItem})
    Me.ContextMenuStripReceiver.Name = "ContextMenuStripReceiver"
    Me.ContextMenuStripReceiver.Size = New System.Drawing.Size(203, 148)
    '
    'UpdateReceivedPacketsToolStripMenuItem
    '
    Me.UpdateReceivedPacketsToolStripMenuItem.Name = "UpdateReceivedPacketsToolStripMenuItem"
    Me.UpdateReceivedPacketsToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
    Me.UpdateReceivedPacketsToolStripMenuItem.Text = "Update received packets"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(199, 6)
    '
    'GotoFirstWarningToolStripMenuItem
    '
    Me.GotoFirstWarningToolStripMenuItem.Name = "GotoFirstWarningToolStripMenuItem"
    Me.GotoFirstWarningToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
    Me.GotoFirstWarningToolStripMenuItem.Text = "Go to first Warning"
    '
    'NextWarningToolStripMenuItem
    '
    Me.NextWarningToolStripMenuItem.Name = "NextWarningToolStripMenuItem"
    Me.NextWarningToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
    Me.NextWarningToolStripMenuItem.Text = "Next Warning"
    '
    'PreviousWarningToolStripMenuItem
    '
    Me.PreviousWarningToolStripMenuItem.Name = "PreviousWarningToolStripMenuItem"
    Me.PreviousWarningToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
    Me.PreviousWarningToolStripMenuItem.Text = "Previous Warning"
    '
    'GotoLastWarningToolStripMenuItem
    '
    Me.GotoLastWarningToolStripMenuItem.Name = "GotoLastWarningToolStripMenuItem"
    Me.GotoLastWarningToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
    Me.GotoLastWarningToolStripMenuItem.Text = "Go to last Warning"
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(199, 6)
    '
    'ResetSessionToolStripMenuItem
    '
    Me.ResetSessionToolStripMenuItem.Name = "ResetSessionToolStripMenuItem"
    Me.ResetSessionToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
    Me.ResetSessionToolStripMenuItem.Text = "Reset session"
    '
    'CheckBoxPacketListAutoUpdate
    '
    Me.CheckBoxPacketListAutoUpdate.AutoSize = True
    Me.CheckBoxPacketListAutoUpdate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxPacketListAutoUpdate.Location = New System.Drawing.Point(3, 3)
    Me.CheckBoxPacketListAutoUpdate.Name = "CheckBoxPacketListAutoUpdate"
    Me.CheckBoxPacketListAutoUpdate.Size = New System.Drawing.Size(115, 24)
    Me.CheckBoxPacketListAutoUpdate.TabIndex = 23
    Me.CheckBoxPacketListAutoUpdate.Text = "Auto update"
    Me.CheckBoxPacketListAutoUpdate.UseVisualStyleBackColor = True
    '
    'TableLayoutPanelWarnings
    '
    Me.TableLayoutPanelWarnings.ColumnCount = 5
    Me.TableLayoutPanelWarnings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanelWarnings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanelWarnings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelWarnings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanelWarnings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
    Me.TableLayoutPanelWarnings.Controls.Add(Me.ButtonWarningsFirst, 0, 0)
    Me.TableLayoutPanelWarnings.Controls.Add(Me.ButtonWarningsPrevious, 1, 0)
    Me.TableLayoutPanelWarnings.Controls.Add(Me.ButtonWarningsNext, 3, 0)
    Me.TableLayoutPanelWarnings.Controls.Add(Me.ButtonWarningsLast, 4, 0)
    Me.TableLayoutPanelWarnings.Controls.Add(Me.LabelWarnings, 2, 0)
    Me.TableLayoutPanelWarnings.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelWarnings.Location = New System.Drawing.Point(124, 3)
    Me.TableLayoutPanelWarnings.Name = "TableLayoutPanelWarnings"
    Me.TableLayoutPanelWarnings.RowCount = 1
    Me.TableLayoutPanelWarnings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelWarnings.Size = New System.Drawing.Size(244, 24)
    Me.TableLayoutPanelWarnings.TabIndex = 21
    '
    'ButtonWarningsFirst
    '
    Me.ButtonWarningsFirst.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonWarningsFirst.Location = New System.Drawing.Point(0, 0)
    Me.ButtonWarningsFirst.Margin = New System.Windows.Forms.Padding(0)
    Me.ButtonWarningsFirst.Name = "ButtonWarningsFirst"
    Me.ButtonWarningsFirst.Size = New System.Drawing.Size(35, 24)
    Me.ButtonWarningsFirst.TabIndex = 0
    Me.ButtonWarningsFirst.Text = "<<"
    Me.ButtonWarningsFirst.UseVisualStyleBackColor = True
    '
    'ButtonWarningsPrevious
    '
    Me.ButtonWarningsPrevious.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonWarningsPrevious.Location = New System.Drawing.Point(35, 0)
    Me.ButtonWarningsPrevious.Margin = New System.Windows.Forms.Padding(0)
    Me.ButtonWarningsPrevious.Name = "ButtonWarningsPrevious"
    Me.ButtonWarningsPrevious.Size = New System.Drawing.Size(35, 24)
    Me.ButtonWarningsPrevious.TabIndex = 0
    Me.ButtonWarningsPrevious.Text = "<"
    Me.ButtonWarningsPrevious.UseVisualStyleBackColor = True
    '
    'ButtonWarningsNext
    '
    Me.ButtonWarningsNext.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonWarningsNext.Location = New System.Drawing.Point(174, 0)
    Me.ButtonWarningsNext.Margin = New System.Windows.Forms.Padding(0)
    Me.ButtonWarningsNext.Name = "ButtonWarningsNext"
    Me.ButtonWarningsNext.Size = New System.Drawing.Size(35, 24)
    Me.ButtonWarningsNext.TabIndex = 0
    Me.ButtonWarningsNext.Text = ">"
    Me.ButtonWarningsNext.UseVisualStyleBackColor = True
    '
    'ButtonWarningsLast
    '
    Me.ButtonWarningsLast.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonWarningsLast.Location = New System.Drawing.Point(209, 0)
    Me.ButtonWarningsLast.Margin = New System.Windows.Forms.Padding(0)
    Me.ButtonWarningsLast.Name = "ButtonWarningsLast"
    Me.ButtonWarningsLast.Size = New System.Drawing.Size(35, 24)
    Me.ButtonWarningsLast.TabIndex = 0
    Me.ButtonWarningsLast.Text = ">>"
    Me.ButtonWarningsLast.UseVisualStyleBackColor = True
    '
    'LabelWarnings
    '
    Me.LabelWarnings.AutoSize = True
    Me.LabelWarnings.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelWarnings.Location = New System.Drawing.Point(73, 0)
    Me.LabelWarnings.Name = "LabelWarnings"
    Me.LabelWarnings.Size = New System.Drawing.Size(98, 24)
    Me.LabelWarnings.TabIndex = 1
    Me.LabelWarnings.Text = "Warnings"
    Me.LabelWarnings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TabPageTiming
    '
    Me.TabPageTiming.Controls.Add(Me.TableLayoutPanel2)
    Me.TabPageTiming.Location = New System.Drawing.Point(4, 22)
    Me.TabPageTiming.Name = "TabPageTiming"
    Me.TabPageTiming.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPageTiming.Size = New System.Drawing.Size(377, 295)
    Me.TabPageTiming.TabIndex = 1
    Me.TabPageTiming.Text = "Timing"
    Me.TabPageTiming.UseVisualStyleBackColor = True
    '
    'TableLayoutPanel2
    '
    Me.TableLayoutPanel2.ColumnCount = 2
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
    Me.TableLayoutPanel2.Controls.Add(Me.CheckBoxTimingAutoUpdate, 0, 0)
    Me.TableLayoutPanel2.Controls.Add(Me.PictureBoxTiming, 0, 1)
    Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
    Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
    Me.TableLayoutPanel2.RowCount = 2
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel2.Size = New System.Drawing.Size(371, 289)
    Me.TableLayoutPanel2.TabIndex = 1
    '
    'CheckBoxTimingAutoUpdate
    '
    Me.CheckBoxTimingAutoUpdate.AutoSize = True
    Me.CheckBoxTimingAutoUpdate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxTimingAutoUpdate.Location = New System.Drawing.Point(3, 3)
    Me.CheckBoxTimingAutoUpdate.Name = "CheckBoxTimingAutoUpdate"
    Me.CheckBoxTimingAutoUpdate.Size = New System.Drawing.Size(115, 24)
    Me.CheckBoxTimingAutoUpdate.TabIndex = 23
    Me.CheckBoxTimingAutoUpdate.Text = "Auto update"
    Me.CheckBoxTimingAutoUpdate.UseVisualStyleBackColor = True
    '
    'PictureBoxTiming
    '
    Me.TableLayoutPanel2.SetColumnSpan(Me.PictureBoxTiming, 2)
    Me.PictureBoxTiming.ContextMenuStrip = Me.ContextMenuStripTiming
    Me.PictureBoxTiming.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PictureBoxTiming.Location = New System.Drawing.Point(3, 33)
    Me.PictureBoxTiming.Name = "PictureBoxTiming"
    Me.PictureBoxTiming.Size = New System.Drawing.Size(365, 253)
    Me.PictureBoxTiming.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureBoxTiming.TabIndex = 24
    Me.PictureBoxTiming.TabStop = False
    '
    'ContextMenuStripTiming
    '
    Me.ContextMenuStripTiming.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateToolStripMenuItem, Me.ToolStripMenuItem3, Me.ResetSessionToolStripMenuItem1})
    Me.ContextMenuStripTiming.Name = "ContextMenuStripTiming"
    Me.ContextMenuStripTiming.Size = New System.Drawing.Size(144, 54)
    '
    'UpdateToolStripMenuItem
    '
    Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
    Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
    Me.UpdateToolStripMenuItem.Text = "Update"
    '
    'ToolStripMenuItem3
    '
    Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
    Me.ToolStripMenuItem3.Size = New System.Drawing.Size(140, 6)
    '
    'ResetSessionToolStripMenuItem1
    '
    Me.ResetSessionToolStripMenuItem1.Name = "ResetSessionToolStripMenuItem1"
    Me.ResetSessionToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
    Me.ResetSessionToolStripMenuItem1.Text = "Reset session"
    '
    'frmRTHeadSimulator
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1008, 398)
    Me.Controls.Add(Me.SplitContainerAll)
    Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frmRTHeadSimulator"
    Me.Text = "RT Head simulator"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel1.PerformLayout()
    CType(Me.NumericUpDownPan, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownTilt, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownZoom, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownFocus, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownIndex, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownUDPPort, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownSimulationPeriod, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownUDPReceivePort, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerAll.Panel1.ResumeLayout(False)
    Me.SplitContainerAll.Panel2.ResumeLayout(False)
    CType(Me.SplitContainerAll, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerAll.ResumeLayout(False)
    Me.GroupBoxSource.ResumeLayout(False)
    Me.GroupBoxRTHeadReceiver.ResumeLayout(False)
    Me.TableLayoutPanelReceiver.ResumeLayout(False)
    Me.TableLayoutPanelReceiver.PerformLayout()
    Me.TableLayoutPanelPacketFactory.ResumeLayout(False)
    Me.TableLayoutPanelPacketFactory.PerformLayout()
    Me.TabControlPacketAnalyzers.ResumeLayout(False)
    Me.TabPagePacketList.ResumeLayout(False)
    Me.TableLayoutPanelPacketList.ResumeLayout(False)
    Me.TableLayoutPanelPacketList.PerformLayout()
    Me.ContextMenuStripReceiver.ResumeLayout(False)
    Me.TableLayoutPanelWarnings.ResumeLayout(False)
    Me.TableLayoutPanelWarnings.PerformLayout()
    Me.TabPageTiming.ResumeLayout(False)
    Me.TableLayoutPanel2.ResumeLayout(False)
    Me.TableLayoutPanel2.PerformLayout()
    CType(Me.PictureBoxTiming, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ContextMenuStripTiming.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents Label1 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents NumericUpDownPan As NumericUpDown
  Friend WithEvents NumericUpDownTilt As NumericUpDown
  Friend WithEvents NumericUpDownZoom As NumericUpDown
  Friend WithEvents NumericUpDownFocus As NumericUpDown
  Friend WithEvents TextBoxHexValues As TextBox
  Friend WithEvents Label5 As Label
  Friend WithEvents NumericUpDownIndex As NumericUpDown
  Friend WithEvents CheckBoxSendToUDP As CheckBox
  Friend WithEvents TextBoxUDPHost As TextBox
  Friend WithEvents NumericUpDownUDPPort As NumericUpDown
  Friend WithEvents CheckBoxSimulateDevice As CheckBox
  Friend WithEvents NumericUpDownSimulationPeriod As NumericUpDown
  Friend WithEvents CheckBoxSwingPan As CheckBox
  Friend WithEvents CheckBoxSwingTilt As CheckBox
  Friend WithEvents CheckBoxSwingZoom As CheckBox
  Friend WithEvents CheckBoxSwingFocus As CheckBox
  Friend WithEvents TimerPacketFactory As Timer
  Friend WithEvents CheckBoxReceiveFromUDP As CheckBox
  Friend WithEvents NumericUpDownUDPReceivePort As NumericUpDown
  Friend WithEvents CheckBoxReceiveFromCOMPort As CheckBox
  Friend WithEvents ComboBoxComPort As ComboBox
  Friend WithEvents CheckBoxSendToCOM As CheckBox
  Friend WithEvents ComboBoxSendCOM As ComboBox
  Friend WithEvents TableLayoutPanelReceiver As TableLayoutPanel
  Friend WithEvents ListViewReceivedPackets As ListView
  Friend WithEvents SplitContainerAll As SplitContainer
  Friend WithEvents GroupBoxSource As GroupBox
  Friend WithEvents GroupBoxRTHeadReceiver As GroupBox
  Friend WithEvents ContextMenuStripReceiver As ContextMenuStrip
  Friend WithEvents UpdateReceivedPacketsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ColumnHeaderIndex As ColumnHeader
  Friend WithEvents ColumnHeaderTimeStamp As ColumnHeader
  Friend WithEvents ColumnHeaderContents As ColumnHeader
  Friend WithEvents ColumnHeaderCount As ColumnHeader
  Friend WithEvents ColumnHeaderPan As ColumnHeader
  Friend WithEvents ColumnHeaderTilt As ColumnHeader
  Friend WithEvents ColumnHeaderZoom As ColumnHeader
  Friend WithEvents ColumnHeaderFocus As ColumnHeader
  Friend WithEvents ColumnHeaderWarning As ColumnHeader
  Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
  Friend WithEvents GotoFirstWarningToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents NextWarningToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents PreviousWarningToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents GotoLastWarningToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents TableLayoutPanelWarnings As TableLayoutPanel
  Friend WithEvents ButtonWarningsFirst As Button
  Friend WithEvents ButtonWarningsPrevious As Button
  Friend WithEvents ButtonWarningsNext As Button
  Friend WithEvents ButtonWarningsLast As Button
  Friend WithEvents LabelWarnings As Label
  Friend WithEvents TableLayoutPanelPacketFactory As TableLayoutPanel
  Friend WithEvents LabelPackerFactoryNonConsecutivePackets As Label
  Friend WithEvents LabelPackerFactoryBytesDiscarded As Label
  Friend WithEvents LabelPackerFactoryBytesProcessed As Label
  Friend WithEvents LabelPackerFactoryPackets As Label
  Friend WithEvents Label6 As Label
  Friend WithEvents Label7 As Label
  Friend WithEvents Label8 As Label
  Friend WithEvents Label9 As Label
  Friend WithEvents Label10 As Label
  Friend WithEvents LabelPackerFactoryTimingMean As Label
  Friend WithEvents Label12 As Label
  Friend WithEvents LabelPackerFactoryTimingStdDev As Label
  Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
  Friend WithEvents ResetSessionToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CheckBoxPacketListAutoUpdate As CheckBox
  Friend WithEvents Label11 As Label
  Friend WithEvents Label13 As Label
  Friend WithEvents Label14 As Label
  Friend WithEvents Label15 As Label
  Friend WithEvents Label16 As Label
  Friend WithEvents LabelPacketIndex As Label
  Friend WithEvents LabelPacketPan As Label
  Friend WithEvents LabelPacketTilt As Label
  Friend WithEvents LabelPacketZoom As Label
  Friend WithEvents LabelPacketFocus As Label
  Friend WithEvents TabControlPacketAnalyzers As TabControl
  Friend WithEvents TabPagePacketList As TabPage
  Friend WithEvents TableLayoutPanelPacketList As TableLayoutPanel
  Friend WithEvents TabPageTiming As TabPage
  Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
  Friend WithEvents CheckBoxTimingAutoUpdate As CheckBox
  Friend WithEvents PictureBoxTiming As PictureBox
  Friend WithEvents ContextMenuStripTiming As ContextMenuStrip
  Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
  Friend WithEvents ResetSessionToolStripMenuItem1 As ToolStripMenuItem
  Friend WithEvents Label17 As Label
  Friend WithEvents LabelPacketFactoryPacketsPerSecond As Label
End Class
