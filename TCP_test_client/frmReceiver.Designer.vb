<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReceiver
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
    Me.GroupBoxReceiver = New System.Windows.Forms.GroupBox()
    Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
    Me.NumericUpDownReceiverPort = New System.Windows.Forms.NumericUpDown()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LabelReceiverState = New System.Windows.Forms.Label()
    Me.LabelReceiverDataRate = New System.Windows.Forms.Label()
    Me.ButtonReceiverConnect = New System.Windows.Forms.Button()
    Me.LabelStatusLabel = New System.Windows.Forms.Label()
    Me.ListViewPackets = New System.Windows.Forms.ListView()
    Me.ColumnHeaderNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeaderData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.TableLayoutPanel1.SuspendLayout()
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
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxReceiver, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.ListViewPackets, 1, 0)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(859, 396)
    Me.TableLayoutPanel1.TabIndex = 2
    '
    'GroupBoxReceiver
    '
    Me.GroupBoxReceiver.Controls.Add(Me.TableLayoutPanel3)
    Me.GroupBoxReceiver.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBoxReceiver.Location = New System.Drawing.Point(3, 3)
    Me.GroupBoxReceiver.Name = "GroupBoxReceiver"
    Me.GroupBoxReceiver.Size = New System.Drawing.Size(194, 390)
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
    Me.TableLayoutPanel3.Controls.Add(Me.LabelReceiverState, 0, 5)
    Me.TableLayoutPanel3.Controls.Add(Me.LabelReceiverDataRate, 1, 5)
    Me.TableLayoutPanel3.Controls.Add(Me.ButtonReceiverConnect, 1, 2)
    Me.TableLayoutPanel3.Controls.Add(Me.LabelStatusLabel, 0, 4)
    Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
    Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
    Me.TableLayoutPanel3.RowCount = 6
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
    Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
    Me.TableLayoutPanel3.Size = New System.Drawing.Size(188, 370)
    Me.TableLayoutPanel3.TabIndex = 1
    '
    'NumericUpDownReceiverPort
    '
    Me.NumericUpDownReceiverPort.Location = New System.Drawing.Point(97, 28)
    Me.NumericUpDownReceiverPort.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
    Me.NumericUpDownReceiverPort.Name = "NumericUpDownReceiverPort"
    Me.NumericUpDownReceiverPort.Size = New System.Drawing.Size(88, 21)
    Me.NumericUpDownReceiverPort.TabIndex = 1
    Me.NumericUpDownReceiverPort.Value = New Decimal(New Integer() {6100, 0, 0, 0})
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Label1.Location = New System.Drawing.Point(3, 25)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(88, 25)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Port"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelReceiverState
    '
    Me.LabelReceiverState.AutoSize = True
    Me.LabelReceiverState.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelReceiverState.Location = New System.Drawing.Point(3, 345)
    Me.LabelReceiverState.Name = "LabelReceiverState"
    Me.LabelReceiverState.Size = New System.Drawing.Size(88, 25)
    Me.LabelReceiverState.TabIndex = 4
    Me.LabelReceiverState.Text = "State"
    Me.LabelReceiverState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelReceiverDataRate
    '
    Me.LabelReceiverDataRate.AutoSize = True
    Me.LabelReceiverDataRate.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelReceiverDataRate.Location = New System.Drawing.Point(97, 345)
    Me.LabelReceiverDataRate.Name = "LabelReceiverDataRate"
    Me.LabelReceiverDataRate.Size = New System.Drawing.Size(88, 25)
    Me.LabelReceiverDataRate.TabIndex = 4
    Me.LabelReceiverDataRate.Text = "Data rate"
    Me.LabelReceiverDataRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ButtonReceiverConnect
    '
    Me.ButtonReceiverConnect.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonReceiverConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ButtonReceiverConnect.Location = New System.Drawing.Point(97, 53)
    Me.ButtonReceiverConnect.Name = "ButtonReceiverConnect"
    Me.ButtonReceiverConnect.Size = New System.Drawing.Size(88, 24)
    Me.ButtonReceiverConnect.TabIndex = 5
    Me.ButtonReceiverConnect.Text = "Connect"
    Me.ButtonReceiverConnect.UseVisualStyleBackColor = True
    '
    'LabelStatusLabel
    '
    Me.LabelStatusLabel.AutoSize = True
    Me.TableLayoutPanel3.SetColumnSpan(Me.LabelStatusLabel, 2)
    Me.LabelStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelStatusLabel.Location = New System.Drawing.Point(3, 295)
    Me.LabelStatusLabel.Name = "LabelStatusLabel"
    Me.LabelStatusLabel.Size = New System.Drawing.Size(182, 50)
    Me.LabelStatusLabel.TabIndex = 6
    Me.LabelStatusLabel.Text = "Label2"
    '
    'ListViewPackets
    '
    Me.ListViewPackets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderNumber, Me.ColumnHeaderSize, Me.ColumnHeaderTime, Me.ColumnHeaderData})
    Me.ListViewPackets.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListViewPackets.Location = New System.Drawing.Point(203, 3)
    Me.ListViewPackets.Name = "ListViewPackets"
    Me.ListViewPackets.Size = New System.Drawing.Size(653, 390)
    Me.ListViewPackets.TabIndex = 2
    Me.ListViewPackets.UseCompatibleStateImageBehavior = False
    Me.ListViewPackets.View = System.Windows.Forms.View.Details
    '
    'ColumnHeaderNumber
    '
    Me.ColumnHeaderNumber.Text = "#"
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
    'frmReceiver
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(859, 396)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmReceiver"
    Me.Text = "Receiver"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.GroupBoxReceiver.ResumeLayout(False)
    Me.TableLayoutPanel3.ResumeLayout(False)
    Me.TableLayoutPanel3.PerformLayout()
    CType(Me.NumericUpDownReceiverPort, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Timer1 As Timer
  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents GroupBoxReceiver As GroupBox
  Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
  Friend WithEvents NumericUpDownReceiverPort As NumericUpDown
  Friend WithEvents Label1 As Label
  Friend WithEvents LabelReceiverState As Label
  Friend WithEvents LabelReceiverDataRate As Label
  Friend WithEvents ButtonReceiverConnect As Button
  Friend WithEvents ListViewPackets As ListView
  Friend WithEvents ColumnHeaderNumber As ColumnHeader
  Friend WithEvents ColumnHeaderSize As ColumnHeader
  Friend WithEvents ColumnHeaderTime As ColumnHeader
  Friend WithEvents ColumnHeaderData As ColumnHeader
  Friend WithEvents LabelStatusLabel As Label
End Class
