<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMLR
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
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.GroupBoxMirandaLittleRed = New System.Windows.Forms.GroupBox()
    Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
    Me.TableLayoutPanelControl = New System.Windows.Forms.TableLayoutPanel()
    Me.ButtonMLRStartStop = New System.Windows.Forms.Button()
    Me.ButtonGPI1 = New System.Windows.Forms.Button()
    Me.ButtonGPI2 = New System.Windows.Forms.Button()
    Me.ButtonGPO1 = New System.Windows.Forms.Button()
    Me.ButtonGPO2 = New System.Windows.Forms.Button()
    Me.ButtonGPO3 = New System.Windows.Forms.Button()
    Me.ButtonGPO4 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ComboBoxMLRCOMPort = New System.Windows.Forms.ComboBox()
    Me.ButtonStreamStart = New System.Windows.Forms.Button()
    Me.ButtonStreamStop = New System.Windows.Forms.Button()
    Me.LabelGPIState = New System.Windows.Forms.Label()
    Me.LabelGPOState = New System.Windows.Forms.Label()
    Me.NumericUpDownGPIState = New System.Windows.Forms.NumericUpDown()
    Me.NumericUpDownGPOState = New System.Windows.Forms.NumericUpDown()
    Me.RichTextBoxLog = New System.Windows.Forms.RichTextBox()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.GroupBoxMirandaLittleRed.SuspendLayout()
    CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainerMain.Panel1.SuspendLayout()
    Me.SplitContainerMain.Panel2.SuspendLayout()
    Me.SplitContainerMain.SuspendLayout()
    Me.TableLayoutPanelControl.SuspendLayout()
    CType(Me.NumericUpDownGPIState, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownGPOState, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 1
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxMirandaLittleRed, 0, 0)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(667, 415)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'GroupBoxMirandaLittleRed
    '
    Me.GroupBoxMirandaLittleRed.Controls.Add(Me.SplitContainerMain)
    Me.GroupBoxMirandaLittleRed.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBoxMirandaLittleRed.Location = New System.Drawing.Point(3, 3)
    Me.GroupBoxMirandaLittleRed.Name = "GroupBoxMirandaLittleRed"
    Me.GroupBoxMirandaLittleRed.Size = New System.Drawing.Size(661, 409)
    Me.GroupBoxMirandaLittleRed.TabIndex = 1
    Me.GroupBoxMirandaLittleRed.TabStop = False
    Me.GroupBoxMirandaLittleRed.Text = "MLR"
    '
    'SplitContainerMain
    '
    Me.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainerMain.Location = New System.Drawing.Point(3, 15)
    Me.SplitContainerMain.Name = "SplitContainerMain"
    '
    'SplitContainerMain.Panel1
    '
    Me.SplitContainerMain.Panel1.Controls.Add(Me.TableLayoutPanelControl)
    '
    'SplitContainerMain.Panel2
    '
    Me.SplitContainerMain.Panel2.Controls.Add(Me.RichTextBoxLog)
    Me.SplitContainerMain.Size = New System.Drawing.Size(655, 391)
    Me.SplitContainerMain.SplitterDistance = 218
    Me.SplitContainerMain.TabIndex = 2
    '
    'TableLayoutPanelControl
    '
    Me.TableLayoutPanelControl.ColumnCount = 2
    Me.TableLayoutPanelControl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanelControl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonMLRStartStop, 0, 0)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonGPI1, 0, 5)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonGPI2, 0, 6)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonGPO1, 1, 5)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonGPO2, 1, 6)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonGPO3, 1, 7)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonGPO4, 1, 8)
    Me.TableLayoutPanelControl.Controls.Add(Me.Label1, 0, 1)
    Me.TableLayoutPanelControl.Controls.Add(Me.ComboBoxMLRCOMPort, 1, 1)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonStreamStart, 0, 3)
    Me.TableLayoutPanelControl.Controls.Add(Me.ButtonStreamStop, 1, 3)
    Me.TableLayoutPanelControl.Controls.Add(Me.LabelGPIState, 0, 9)
    Me.TableLayoutPanelControl.Controls.Add(Me.LabelGPOState, 1, 9)
    Me.TableLayoutPanelControl.Controls.Add(Me.NumericUpDownGPIState, 0, 10)
    Me.TableLayoutPanelControl.Controls.Add(Me.NumericUpDownGPOState, 1, 10)
    Me.TableLayoutPanelControl.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelControl.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanelControl.Name = "TableLayoutPanelControl"
    Me.TableLayoutPanelControl.RowCount = 14
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanelControl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanelControl.Size = New System.Drawing.Size(218, 391)
    Me.TableLayoutPanelControl.TabIndex = 0
    '
    'ButtonMLRStartStop
    '
    Me.TableLayoutPanelControl.SetColumnSpan(Me.ButtonMLRStartStop, 2)
    Me.ButtonMLRStartStop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonMLRStartStop.Location = New System.Drawing.Point(3, 3)
    Me.ButtonMLRStartStop.Name = "ButtonMLRStartStop"
    Me.ButtonMLRStartStop.Size = New System.Drawing.Size(212, 24)
    Me.ButtonMLRStartStop.TabIndex = 0
    Me.ButtonMLRStartStop.Text = "Start"
    Me.ButtonMLRStartStop.UseVisualStyleBackColor = True
    '
    'ButtonGPI1
    '
    Me.ButtonGPI1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonGPI1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonGPI1.Location = New System.Drawing.Point(3, 101)
    Me.ButtonGPI1.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
    Me.ButtonGPI1.Name = "ButtonGPI1"
    Me.ButtonGPI1.Size = New System.Drawing.Size(103, 23)
    Me.ButtonGPI1.TabIndex = 1
    Me.ButtonGPI1.Tag = "1"
    Me.ButtonGPI1.Text = "GPI 1"
    Me.ButtonGPI1.UseVisualStyleBackColor = True
    '
    'ButtonGPI2
    '
    Me.ButtonGPI2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonGPI2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonGPI2.Location = New System.Drawing.Point(3, 126)
    Me.ButtonGPI2.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
    Me.ButtonGPI2.Name = "ButtonGPI2"
    Me.ButtonGPI2.Size = New System.Drawing.Size(103, 23)
    Me.ButtonGPI2.TabIndex = 2
    Me.ButtonGPI2.Tag = "2"
    Me.ButtonGPI2.Text = "GPI 2"
    Me.ButtonGPI2.UseVisualStyleBackColor = True
    '
    'ButtonGPO1
    '
    Me.ButtonGPO1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonGPO1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonGPO1.Location = New System.Drawing.Point(112, 101)
    Me.ButtonGPO1.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
    Me.ButtonGPO1.Name = "ButtonGPO1"
    Me.ButtonGPO1.Size = New System.Drawing.Size(103, 23)
    Me.ButtonGPO1.TabIndex = 3
    Me.ButtonGPO1.Tag = "1"
    Me.ButtonGPO1.Text = "GPO 1"
    Me.ButtonGPO1.UseVisualStyleBackColor = True
    '
    'ButtonGPO2
    '
    Me.ButtonGPO2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonGPO2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonGPO2.Location = New System.Drawing.Point(112, 126)
    Me.ButtonGPO2.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
    Me.ButtonGPO2.Name = "ButtonGPO2"
    Me.ButtonGPO2.Size = New System.Drawing.Size(103, 23)
    Me.ButtonGPO2.TabIndex = 4
    Me.ButtonGPO2.Tag = "2"
    Me.ButtonGPO2.Text = "GPO 2"
    Me.ButtonGPO2.UseVisualStyleBackColor = True
    '
    'ButtonGPO3
    '
    Me.ButtonGPO3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonGPO3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonGPO3.Location = New System.Drawing.Point(112, 151)
    Me.ButtonGPO3.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
    Me.ButtonGPO3.Name = "ButtonGPO3"
    Me.ButtonGPO3.Size = New System.Drawing.Size(103, 23)
    Me.ButtonGPO3.TabIndex = 5
    Me.ButtonGPO3.Tag = "3"
    Me.ButtonGPO3.Text = "GPO 3"
    Me.ButtonGPO3.UseVisualStyleBackColor = True
    '
    'ButtonGPO4
    '
    Me.ButtonGPO4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonGPO4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonGPO4.Location = New System.Drawing.Point(112, 176)
    Me.ButtonGPO4.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
    Me.ButtonGPO4.Name = "ButtonGPO4"
    Me.ButtonGPO4.Size = New System.Drawing.Size(103, 23)
    Me.ButtonGPO4.TabIndex = 6
    Me.ButtonGPO4.Tag = "4"
    Me.ButtonGPO4.Text = "GPO 4"
    Me.ButtonGPO4.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label1.Location = New System.Drawing.Point(3, 30)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(103, 25)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "COM Port"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ComboBoxMLRCOMPort
    '
    Me.ComboBoxMLRCOMPort.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ComboBoxMLRCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBoxMLRCOMPort.FormattingEnabled = True
    Me.ComboBoxMLRCOMPort.Location = New System.Drawing.Point(112, 33)
    Me.ComboBoxMLRCOMPort.Name = "ComboBoxMLRCOMPort"
    Me.ComboBoxMLRCOMPort.Size = New System.Drawing.Size(103, 20)
    Me.ComboBoxMLRCOMPort.TabIndex = 8
    '
    'ButtonStreamStart
    '
    Me.ButtonStreamStart.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonStreamStart.Location = New System.Drawing.Point(3, 68)
    Me.ButtonStreamStart.Name = "ButtonStreamStart"
    Me.ButtonStreamStart.Size = New System.Drawing.Size(103, 19)
    Me.ButtonStreamStart.TabIndex = 9
    Me.ButtonStreamStart.Text = "Start capture"
    Me.ButtonStreamStart.UseVisualStyleBackColor = True
    '
    'ButtonStreamStop
    '
    Me.ButtonStreamStop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonStreamStop.Location = New System.Drawing.Point(112, 68)
    Me.ButtonStreamStop.Name = "ButtonStreamStop"
    Me.ButtonStreamStop.Size = New System.Drawing.Size(103, 19)
    Me.ButtonStreamStop.TabIndex = 10
    Me.ButtonStreamStop.Text = "Stop capture"
    Me.ButtonStreamStop.UseVisualStyleBackColor = True
    '
    'LabelGPIState
    '
    Me.LabelGPIState.AutoSize = True
    Me.LabelGPIState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelGPIState.Location = New System.Drawing.Point(3, 200)
    Me.LabelGPIState.Name = "LabelGPIState"
    Me.LabelGPIState.Size = New System.Drawing.Size(103, 25)
    Me.LabelGPIState.TabIndex = 11
    Me.LabelGPIState.Text = "0000"
    Me.LabelGPIState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabelGPOState
    '
    Me.LabelGPOState.AutoSize = True
    Me.LabelGPOState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelGPOState.Location = New System.Drawing.Point(112, 200)
    Me.LabelGPOState.Name = "LabelGPOState"
    Me.LabelGPOState.Size = New System.Drawing.Size(103, 25)
    Me.LabelGPOState.TabIndex = 11
    Me.LabelGPOState.Text = "0000"
    Me.LabelGPOState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'NumericUpDownGPIState
    '
    Me.NumericUpDownGPIState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.NumericUpDownGPIState.Location = New System.Drawing.Point(3, 228)
    Me.NumericUpDownGPIState.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.NumericUpDownGPIState.Name = "NumericUpDownGPIState"
    Me.NumericUpDownGPIState.Size = New System.Drawing.Size(103, 19)
    Me.NumericUpDownGPIState.TabIndex = 12
    '
    'NumericUpDownGPOState
    '
    Me.NumericUpDownGPOState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.NumericUpDownGPOState.Location = New System.Drawing.Point(112, 228)
    Me.NumericUpDownGPOState.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.NumericUpDownGPOState.Name = "NumericUpDownGPOState"
    Me.NumericUpDownGPOState.Size = New System.Drawing.Size(103, 19)
    Me.NumericUpDownGPOState.TabIndex = 12
    '
    'RichTextBoxLog
    '
    Me.RichTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.RichTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
    Me.RichTextBoxLog.Location = New System.Drawing.Point(0, 0)
    Me.RichTextBoxLog.Name = "RichTextBoxLog"
    Me.RichTextBoxLog.Size = New System.Drawing.Size(433, 391)
    Me.RichTextBoxLog.TabIndex = 0
    Me.RichTextBoxLog.Text = ""
    '
    'frmMLR
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(667, 415)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
    Me.Name = "frmMLR"
    Me.Text = "Serial test"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.GroupBoxMirandaLittleRed.ResumeLayout(False)
    Me.SplitContainerMain.Panel1.ResumeLayout(False)
    Me.SplitContainerMain.Panel2.ResumeLayout(False)
    CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainerMain.ResumeLayout(False)
    Me.TableLayoutPanelControl.ResumeLayout(False)
    Me.TableLayoutPanelControl.PerformLayout()
    CType(Me.NumericUpDownGPIState, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDownGPOState, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents GroupBoxMirandaLittleRed As GroupBox
  Friend WithEvents TableLayoutPanelControl As TableLayoutPanel
  Friend WithEvents ButtonMLRStartStop As Button
  Friend WithEvents ButtonGPI1 As Button
  Friend WithEvents ButtonGPI2 As Button
  Friend WithEvents ButtonGPO1 As Button
  Friend WithEvents ButtonGPO2 As Button
  Friend WithEvents ButtonGPO3 As Button
  Friend WithEvents ButtonGPO4 As Button
  Friend WithEvents Label1 As Label
  Friend WithEvents ComboBoxMLRCOMPort As ComboBox
  Friend WithEvents SplitContainerMain As SplitContainer
  Friend WithEvents RichTextBoxLog As RichTextBox
  Friend WithEvents ButtonStreamStart As Button
  Friend WithEvents ButtonStreamStop As Button
  Friend WithEvents LabelGPIState As Label
  Friend WithEvents LabelGPOState As Label
  Friend WithEvents NumericUpDownGPIState As NumericUpDown
  Friend WithEvents NumericUpDownGPOState As NumericUpDown
End Class
