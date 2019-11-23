<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCcommManager
  Inherits System.Windows.Forms.UserControl

  'UserControl overrides dispose to clean up the component list.
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
    Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.LabelCOMPort = New System.Windows.Forms.Label()
    Me.ComboBoxSerialPort = New System.Windows.Forms.ComboBox()
    Me.NumericUpDownBaudRate = New System.Windows.Forms.NumericUpDown()
    Me.ButtonStartStop = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ComboBoxDataBits = New System.Windows.Forms.ComboBox()
    Me.ComboBoxStopBits = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ComboBoxParity = New System.Windows.Forms.ComboBox()
    Me.CheckBoxAppendCR = New System.Windows.Forms.CheckBox()
    Me.PanelLog = New System.Windows.Forms.Panel()
    Me.TableLayoutPanelCommView = New System.Windows.Forms.TableLayoutPanel()
    Me.RichTextBoxLog = New System.Windows.Forms.RichTextBox()
    Me.TextBoxSend = New System.Windows.Forms.TextBox()
    Me.ButtonSend = New System.Windows.Forms.Button()
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.LogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CheckBoxAsyncSend = New System.Windows.Forms.CheckBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.NumericUpDownGroupPackets = New System.Windows.Forms.NumericUpDown()
    Me.LabelExpectedPacketSize = New System.Windows.Forms.Label()
    Me.NumericUpDownExpectedPacketSize = New System.Windows.Forms.NumericUpDown()
    CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainerMain.Panel1.SuspendLayout()
    Me.SplitContainerMain.Panel2.SuspendLayout()
    Me.SplitContainerMain.SuspendLayout()
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.NumericUpDownBaudRate, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.PanelLog.SuspendLayout()
    Me.TableLayoutPanelCommView.SuspendLayout()
    Me.MenuStrip1.SuspendLayout()
    CType(Me.NumericUpDownGroupPackets, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownExpectedPacketSize, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SplitContainerMain
    '
    Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainerMain.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainerMain.Name = "SplitContainerMain"
    '
    'SplitContainerMain.Panel1
    '
    Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanel1)
    '
    'SplitContainerMain.Panel2
    '
    Me.SplitContainerMain.Panel2.Controls.Add(Me.PanelLog)
    Me.SplitContainerMain.Size = New System.Drawing.Size(562, 397)
    Me.SplitContainerMain.SplitterDistance = 225
    Me.SplitContainerMain.TabIndex = 0
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.55556!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.44444!))
    Me.TableLayoutPanel1.Controls.Add(Me.LabelCOMPort, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxSerialPort, 1, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownBaudRate, 1, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.ButtonStartStop, 1, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxDataBits, 1, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxStopBits, 1, 5)
    Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 5)
    Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 4)
    Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxParity, 1, 4)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxAppendCR, 1, 10)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxAsyncSend, 1, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 8)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownGroupPackets, 1, 8)
    Me.TableLayoutPanel1.Controls.Add(Me.LabelExpectedPacketSize, 0, 9)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownExpectedPacketSize, 1, 9)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 11
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(225, 397)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'LabelCOMPort
    '
    Me.LabelCOMPort.AutoSize = True
    Me.LabelCOMPort.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelCOMPort.Location = New System.Drawing.Point(3, 30)
    Me.LabelCOMPort.Name = "LabelCOMPort"
    Me.LabelCOMPort.Size = New System.Drawing.Size(83, 27)
    Me.LabelCOMPort.TabIndex = 0
    Me.LabelCOMPort.Text = "COM Port"
    Me.LabelCOMPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ComboBoxSerialPort
    '
    Me.ComboBoxSerialPort.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ComboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxSerialPort.FormattingEnabled = True
    Me.ComboBoxSerialPort.Location = New System.Drawing.Point(92, 33)
    Me.ComboBoxSerialPort.Name = "ComboBoxSerialPort"
    Me.ComboBoxSerialPort.Size = New System.Drawing.Size(130, 21)
    Me.ComboBoxSerialPort.TabIndex = 1
    '
    'NumericUpDownBaudRate
    '
    Me.NumericUpDownBaudRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.NumericUpDownBaudRate.Location = New System.Drawing.Point(92, 60)
    Me.NumericUpDownBaudRate.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.NumericUpDownBaudRate.Name = "NumericUpDownBaudRate"
    Me.NumericUpDownBaudRate.Size = New System.Drawing.Size(130, 20)
    Me.NumericUpDownBaudRate.TabIndex = 2
    Me.NumericUpDownBaudRate.Value = New Decimal(New Integer() {38400, 0, 0, 0})
    '
    'ButtonStartStop
    '
    Me.ButtonStartStop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonStartStop.Location = New System.Drawing.Point(92, 3)
    Me.ButtonStartStop.Name = "ButtonStartStop"
    Me.ButtonStartStop.Size = New System.Drawing.Size(130, 24)
    Me.ButtonStartStop.TabIndex = 3
    Me.ButtonStartStop.Text = "Start"
    Me.ButtonStartStop.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label1.Location = New System.Drawing.Point(3, 84)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(83, 27)
    Me.Label1.TabIndex = 5
    Me.Label1.Text = "Data bits"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ComboBoxDataBits
    '
    Me.ComboBoxDataBits.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ComboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxDataBits.FormattingEnabled = True
    Me.ComboBoxDataBits.Items.AddRange(New Object() {"5", "6", "7", "8"})
    Me.ComboBoxDataBits.Location = New System.Drawing.Point(92, 87)
    Me.ComboBoxDataBits.Name = "ComboBoxDataBits"
    Me.ComboBoxDataBits.Size = New System.Drawing.Size(130, 21)
    Me.ComboBoxDataBits.TabIndex = 6
    '
    'ComboBoxStopBits
    '
    Me.ComboBoxStopBits.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ComboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxStopBits.FormattingEnabled = True
    Me.ComboBoxStopBits.Items.AddRange(New Object() {"None", "1", "1.5", "2"})
    Me.ComboBoxStopBits.Location = New System.Drawing.Point(92, 141)
    Me.ComboBoxStopBits.Name = "ComboBoxStopBits"
    Me.ComboBoxStopBits.Size = New System.Drawing.Size(130, 21)
    Me.ComboBoxStopBits.TabIndex = 8
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label2.Location = New System.Drawing.Point(3, 138)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(83, 27)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "Stop bits"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label3.Location = New System.Drawing.Point(3, 111)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(83, 27)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "Parity"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ComboBoxParity
    '
    Me.ComboBoxParity.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ComboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxParity.FormattingEnabled = True
    Me.ComboBoxParity.Location = New System.Drawing.Point(92, 114)
    Me.ComboBoxParity.Name = "ComboBoxParity"
    Me.ComboBoxParity.Size = New System.Drawing.Size(130, 21)
    Me.ComboBoxParity.TabIndex = 10
    '
    'CheckBoxAppendCR
    '
    Me.CheckBoxAppendCR.AutoSize = True
    Me.CheckBoxAppendCR.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxAppendCR.Location = New System.Drawing.Point(92, 373)
    Me.CheckBoxAppendCR.Name = "CheckBoxAppendCR"
    Me.CheckBoxAppendCR.Size = New System.Drawing.Size(130, 21)
    Me.CheckBoxAppendCR.TabIndex = 11
    Me.CheckBoxAppendCR.Text = "Append CR"
    Me.CheckBoxAppendCR.UseVisualStyleBackColor = True
    '
    'PanelLog
    '
    Me.PanelLog.Controls.Add(Me.TableLayoutPanelCommView)
    Me.PanelLog.Controls.Add(Me.MenuStrip1)
    Me.PanelLog.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PanelLog.Location = New System.Drawing.Point(0, 0)
    Me.PanelLog.Name = "PanelLog"
    Me.PanelLog.Size = New System.Drawing.Size(333, 397)
    Me.PanelLog.TabIndex = 0
    '
    'TableLayoutPanelCommView
    '
    Me.TableLayoutPanelCommView.ColumnCount = 2
    Me.TableLayoutPanelCommView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelCommView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
    Me.TableLayoutPanelCommView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelCommView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanelCommView.Controls.Add(Me.TextBoxSend, 0, 1)
    Me.TableLayoutPanelCommView.Controls.Add(Me.RichTextBoxLog, 0, 0)
    Me.TableLayoutPanelCommView.Controls.Add(Me.ButtonSend, 1, 1)
    Me.TableLayoutPanelCommView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelCommView.Location = New System.Drawing.Point(0, 24)
    Me.TableLayoutPanelCommView.Name = "TableLayoutPanelCommView"
    Me.TableLayoutPanelCommView.RowCount = 2
    Me.TableLayoutPanelCommView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelCommView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanelCommView.Size = New System.Drawing.Size(333, 373)
    Me.TableLayoutPanelCommView.TabIndex = 2
    '
    'RichTextBoxLog
    '
    Me.RichTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TableLayoutPanelCommView.SetColumnSpan(Me.RichTextBoxLog, 2)
    Me.RichTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
    Me.RichTextBoxLog.Location = New System.Drawing.Point(3, 3)
    Me.RichTextBoxLog.Name = "RichTextBoxLog"
    Me.RichTextBoxLog.ReadOnly = True
    Me.RichTextBoxLog.Size = New System.Drawing.Size(327, 337)
    Me.RichTextBoxLog.TabIndex = 1
    Me.RichTextBoxLog.Text = ""
    '
    'TextBoxSend
    '
    Me.TextBoxSend.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxSend.Location = New System.Drawing.Point(3, 346)
    Me.TextBoxSend.Name = "TextBoxSend"
    Me.TextBoxSend.Size = New System.Drawing.Size(287, 20)
    Me.TextBoxSend.TabIndex = 0
    '
    'ButtonSend
    '
    Me.ButtonSend.Location = New System.Drawing.Point(296, 346)
    Me.ButtonSend.Name = "ButtonSend"
    Me.ButtonSend.Size = New System.Drawing.Size(34, 22)
    Me.ButtonSend.TabIndex = 1
    Me.ButtonSend.Text = ">>"
    Me.ButtonSend.UseVisualStyleBackColor = True
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(333, 24)
    Me.MenuStrip1.TabIndex = 0
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'LogToolStripMenuItem
    '
    Me.LogToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.SaveToolStripMenuItem})
    Me.LogToolStripMenuItem.Name = "LogToolStripMenuItem"
    Me.LogToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
    Me.LogToolStripMenuItem.Text = "Log"
    '
    'ClearToolStripMenuItem
    '
    Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
    Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
    Me.ClearToolStripMenuItem.Text = "Clear"
    '
    'SaveToolStripMenuItem
    '
    Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
    Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
    Me.SaveToolStripMenuItem.Text = "Save..."
    '
    'CheckBoxAsyncSend
    '
    Me.CheckBoxAsyncSend.AutoSize = True
    Me.CheckBoxAsyncSend.Checked = True
    Me.CheckBoxAsyncSend.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBoxAsyncSend.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxAsyncSend.Location = New System.Drawing.Point(92, 292)
    Me.CheckBoxAsyncSend.Name = "CheckBoxAsyncSend"
    Me.CheckBoxAsyncSend.Size = New System.Drawing.Size(130, 21)
    Me.CheckBoxAsyncSend.TabIndex = 12
    Me.CheckBoxAsyncSend.Text = "async send"
    Me.CheckBoxAsyncSend.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label4.Location = New System.Drawing.Point(3, 316)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(83, 27)
    Me.Label4.TabIndex = 13
    Me.Label4.Text = "Group packets"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'NumericUpDownGroupPackets
    '
    Me.NumericUpDownGroupPackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.NumericUpDownGroupPackets.Location = New System.Drawing.Point(92, 319)
    Me.NumericUpDownGroupPackets.Name = "NumericUpDownGroupPackets"
    Me.NumericUpDownGroupPackets.Size = New System.Drawing.Size(130, 20)
    Me.NumericUpDownGroupPackets.TabIndex = 14
    Me.NumericUpDownGroupPackets.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'LabelExpectedPacketSize
    '
    Me.LabelExpectedPacketSize.AutoSize = True
    Me.LabelExpectedPacketSize.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelExpectedPacketSize.Location = New System.Drawing.Point(3, 343)
    Me.LabelExpectedPacketSize.Name = "LabelExpectedPacketSize"
    Me.LabelExpectedPacketSize.Size = New System.Drawing.Size(83, 27)
    Me.LabelExpectedPacketSize.TabIndex = 15
    Me.LabelExpectedPacketSize.Text = "Expected packet size"
    '
    'NumericUpDownExpectedPacketSize
    '
    Me.NumericUpDownExpectedPacketSize.Dock = System.Windows.Forms.DockStyle.Fill
    Me.NumericUpDownExpectedPacketSize.Location = New System.Drawing.Point(92, 346)
    Me.NumericUpDownExpectedPacketSize.Name = "NumericUpDownExpectedPacketSize"
    Me.NumericUpDownExpectedPacketSize.Size = New System.Drawing.Size(130, 20)
    Me.NumericUpDownExpectedPacketSize.TabIndex = 16
    '
    'UCcommManager
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.SplitContainerMain)
    Me.Name = "UCcommManager"
    Me.Size = New System.Drawing.Size(562, 397)
    Me.SplitContainerMain.Panel1.ResumeLayout(False)
    Me.SplitContainerMain.Panel2.ResumeLayout(False)
    CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerMain.ResumeLayout(False)
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel1.PerformLayout()
    CType(Me.NumericUpDownBaudRate, System.ComponentModel.ISupportInitialize).EndInit()
    Me.PanelLog.ResumeLayout(False)
    Me.PanelLog.PerformLayout()
    Me.TableLayoutPanelCommView.ResumeLayout(False)
    Me.TableLayoutPanelCommView.PerformLayout()
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    CType(Me.NumericUpDownGroupPackets, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownExpectedPacketSize, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents SplitContainerMain As SplitContainer
  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents LabelCOMPort As Label
  Friend WithEvents ComboBoxSerialPort As ComboBox
  Friend WithEvents NumericUpDownBaudRate As NumericUpDown
  Friend WithEvents PanelLog As Panel
  Friend WithEvents RichTextBoxLog As RichTextBox
  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents LogToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ButtonStartStop As Button
  Friend WithEvents Label1 As Label
  Friend WithEvents ComboBoxDataBits As ComboBox
  Friend WithEvents ComboBoxStopBits As ComboBox
  Friend WithEvents Label2 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents ComboBoxParity As ComboBox
  Friend WithEvents CheckBoxAppendCR As CheckBox
  Friend WithEvents TableLayoutPanelCommView As TableLayoutPanel
  Friend WithEvents TextBoxSend As TextBox
  Friend WithEvents ButtonSend As Button
  Friend WithEvents CheckBoxAsyncSend As CheckBox
  Friend WithEvents Label4 As Label
  Friend WithEvents NumericUpDownGroupPackets As NumericUpDown
  Friend WithEvents LabelExpectedPacketSize As Label
  Friend WithEvents NumericUpDownExpectedPacketSize As NumericUpDown
End Class
