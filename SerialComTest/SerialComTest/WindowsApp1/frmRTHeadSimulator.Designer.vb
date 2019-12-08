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
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.NumericUpDownPan, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownTilt, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownZoom, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownFocus, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownIndex, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownUDPPort, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDownSimulationPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 5
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
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
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSendToUDP, 1, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.TextBoxUDPHost, 2, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownUDPPort, 3, 7)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSimulateDevice, 1, 6)
    Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDownSimulationPeriod, 2, 6)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingPan, 2, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingTilt, 2, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingZoom, 2, 3)
    Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSwingFocus, 2, 4)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 11
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(677, 324)
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
    Me.Label2.Size = New System.Drawing.Size(21, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Tilt"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(3, 75)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(34, 13)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "Zoom"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(3, 100)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(36, 13)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "Focus"
    '
    'NumericUpDownPan
    '
    Me.NumericUpDownPan.Location = New System.Drawing.Point(48, 28)
    Me.NumericUpDownPan.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
    Me.NumericUpDownPan.Minimum = New Decimal(New Integer() {30000, 0, 0, -2147483648})
    Me.NumericUpDownPan.Name = "NumericUpDownPan"
    Me.NumericUpDownPan.Size = New System.Drawing.Size(94, 20)
    Me.NumericUpDownPan.TabIndex = 4
    Me.NumericUpDownPan.Value = New Decimal(New Integer() {30000, 0, 0, 0})
    '
    'NumericUpDownTilt
    '
    Me.NumericUpDownTilt.Location = New System.Drawing.Point(48, 53)
    Me.NumericUpDownTilt.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
    Me.NumericUpDownTilt.Minimum = New Decimal(New Integer() {30000, 0, 0, -2147483648})
    Me.NumericUpDownTilt.Name = "NumericUpDownTilt"
    Me.NumericUpDownTilt.Size = New System.Drawing.Size(94, 20)
    Me.NumericUpDownTilt.TabIndex = 4
    Me.NumericUpDownTilt.Value = New Decimal(New Integer() {30000, 0, 0, 0})
    '
    'NumericUpDownZoom
    '
    Me.NumericUpDownZoom.Location = New System.Drawing.Point(48, 78)
    Me.NumericUpDownZoom.Maximum = New Decimal(New Integer() {12000, 0, 0, 0})
    Me.NumericUpDownZoom.Minimum = New Decimal(New Integer() {12000, 0, 0, -2147483648})
    Me.NumericUpDownZoom.Name = "NumericUpDownZoom"
    Me.NumericUpDownZoom.Size = New System.Drawing.Size(94, 20)
    Me.NumericUpDownZoom.TabIndex = 4
    Me.NumericUpDownZoom.Value = New Decimal(New Integer() {8320, 0, 0, 0})
    '
    'NumericUpDownFocus
    '
    Me.NumericUpDownFocus.Location = New System.Drawing.Point(48, 103)
    Me.NumericUpDownFocus.Maximum = New Decimal(New Integer() {12000, 0, 0, 0})
    Me.NumericUpDownFocus.Minimum = New Decimal(New Integer() {12000, 0, 0, -2147483648})
    Me.NumericUpDownFocus.Name = "NumericUpDownFocus"
    Me.NumericUpDownFocus.Size = New System.Drawing.Size(94, 20)
    Me.NumericUpDownFocus.TabIndex = 4
    Me.NumericUpDownFocus.Value = New Decimal(New Integer() {4110, 0, 0, 0})
    '
    'TextBoxHexValues
    '
    Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxHexValues, 5)
    Me.TextBoxHexValues.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxHexValues.Location = New System.Drawing.Point(3, 128)
    Me.TextBoxHexValues.Name = "TextBoxHexValues"
    Me.TextBoxHexValues.Size = New System.Drawing.Size(671, 20)
    Me.TextBoxHexValues.TabIndex = 5
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(3, 0)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(33, 13)
    Me.Label5.TabIndex = 6
    Me.Label5.Text = "Index"
    '
    'NumericUpDownIndex
    '
    Me.NumericUpDownIndex.Location = New System.Drawing.Point(48, 3)
    Me.NumericUpDownIndex.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
    Me.NumericUpDownIndex.Name = "NumericUpDownIndex"
    Me.NumericUpDownIndex.Size = New System.Drawing.Size(50, 20)
    Me.NumericUpDownIndex.TabIndex = 7
    Me.NumericUpDownIndex.Value = New Decimal(New Integer() {3, 0, 0, 0})
    '
    'CheckBoxSendToUDP
    '
    Me.CheckBoxSendToUDP.AutoSize = True
    Me.CheckBoxSendToUDP.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxSendToUDP.Location = New System.Drawing.Point(48, 178)
    Me.CheckBoxSendToUDP.Name = "CheckBoxSendToUDP"
    Me.CheckBoxSendToUDP.Size = New System.Drawing.Size(94, 19)
    Me.CheckBoxSendToUDP.TabIndex = 8
    Me.CheckBoxSendToUDP.Text = "Send to UDP"
    Me.CheckBoxSendToUDP.UseVisualStyleBackColor = True
    '
    'TextBoxUDPHost
    '
    Me.TextBoxUDPHost.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBoxUDPHost.Location = New System.Drawing.Point(148, 178)
    Me.TextBoxUDPHost.Name = "TextBoxUDPHost"
    Me.TextBoxUDPHost.Size = New System.Drawing.Size(94, 20)
    Me.TextBoxUDPHost.TabIndex = 9
    Me.TextBoxUDPHost.Text = "127.0.0.1"
    '
    'NumericUpDownUDPPort
    '
    Me.NumericUpDownUDPPort.Location = New System.Drawing.Point(248, 178)
    Me.NumericUpDownUDPPort.Maximum = New Decimal(New Integer() {6500, 0, 0, 0})
    Me.NumericUpDownUDPPort.Name = "NumericUpDownUDPPort"
    Me.NumericUpDownUDPPort.Size = New System.Drawing.Size(52, 20)
    Me.NumericUpDownUDPPort.TabIndex = 10
    Me.NumericUpDownUDPPort.Value = New Decimal(New Integer() {6301, 0, 0, 0})
    '
    'CheckBoxSimulateDevice
    '
    Me.CheckBoxSimulateDevice.AutoSize = True
    Me.CheckBoxSimulateDevice.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxSimulateDevice.Location = New System.Drawing.Point(48, 153)
    Me.CheckBoxSimulateDevice.Name = "CheckBoxSimulateDevice"
    Me.CheckBoxSimulateDevice.Size = New System.Drawing.Size(94, 19)
    Me.CheckBoxSimulateDevice.TabIndex = 11
    Me.CheckBoxSimulateDevice.Text = "Simulate device"
    Me.CheckBoxSimulateDevice.UseVisualStyleBackColor = True
    '
    'NumericUpDownSimulationPeriod
    '
    Me.NumericUpDownSimulationPeriod.Location = New System.Drawing.Point(148, 153)
    Me.NumericUpDownSimulationPeriod.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.NumericUpDownSimulationPeriod.Name = "NumericUpDownSimulationPeriod"
    Me.NumericUpDownSimulationPeriod.Size = New System.Drawing.Size(89, 20)
    Me.NumericUpDownSimulationPeriod.TabIndex = 12
    Me.NumericUpDownSimulationPeriod.Value = New Decimal(New Integer() {10, 0, 0, 0})
    '
    'CheckBoxSwingPan
    '
    Me.CheckBoxSwingPan.AutoSize = True
    Me.CheckBoxSwingPan.Location = New System.Drawing.Point(148, 28)
    Me.CheckBoxSwingPan.Name = "CheckBoxSwingPan"
    Me.CheckBoxSwingPan.Size = New System.Drawing.Size(55, 17)
    Me.CheckBoxSwingPan.TabIndex = 13
    Me.CheckBoxSwingPan.Tag = "Pan"
    Me.CheckBoxSwingPan.Text = "Swing"
    Me.CheckBoxSwingPan.UseVisualStyleBackColor = True
    '
    'CheckBoxSwingTilt
    '
    Me.CheckBoxSwingTilt.AutoSize = True
    Me.CheckBoxSwingTilt.Location = New System.Drawing.Point(148, 53)
    Me.CheckBoxSwingTilt.Name = "CheckBoxSwingTilt"
    Me.CheckBoxSwingTilt.Size = New System.Drawing.Size(55, 17)
    Me.CheckBoxSwingTilt.TabIndex = 13
    Me.CheckBoxSwingTilt.Tag = "Pan"
    Me.CheckBoxSwingTilt.Text = "Swing"
    Me.CheckBoxSwingTilt.UseVisualStyleBackColor = True
    '
    'CheckBoxSwingZoom
    '
    Me.CheckBoxSwingZoom.AutoSize = True
    Me.CheckBoxSwingZoom.Location = New System.Drawing.Point(148, 78)
    Me.CheckBoxSwingZoom.Name = "CheckBoxSwingZoom"
    Me.CheckBoxSwingZoom.Size = New System.Drawing.Size(55, 17)
    Me.CheckBoxSwingZoom.TabIndex = 13
    Me.CheckBoxSwingZoom.Tag = "Pan"
    Me.CheckBoxSwingZoom.Text = "Swing"
    Me.CheckBoxSwingZoom.UseVisualStyleBackColor = True
    '
    'CheckBoxSwingFocus
    '
    Me.CheckBoxSwingFocus.AutoSize = True
    Me.CheckBoxSwingFocus.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CheckBoxSwingFocus.Location = New System.Drawing.Point(148, 103)
    Me.CheckBoxSwingFocus.Name = "CheckBoxSwingFocus"
    Me.CheckBoxSwingFocus.Size = New System.Drawing.Size(94, 19)
    Me.CheckBoxSwingFocus.TabIndex = 13
    Me.CheckBoxSwingFocus.Tag = "Pan"
    Me.CheckBoxSwingFocus.Text = "Swing"
    Me.CheckBoxSwingFocus.UseVisualStyleBackColor = True
    '
    'frmRTHeadSimulator
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(677, 324)
    Me.Controls.Add(Me.TableLayoutPanel1)
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
End Class
