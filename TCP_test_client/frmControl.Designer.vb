<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControl
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
    Me.TableLayoutPanelAll = New System.Windows.Forms.TableLayoutPanel()
    Me.ButtonBridge = New System.Windows.Forms.Button()
    Me.ButtonNewSender = New System.Windows.Forms.Button()
    Me.ButtonNewReceiver = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ButtonUDPTest = New System.Windows.Forms.Button()
    Me.ButtonSerialTest = New System.Windows.Forms.Button()
    Me.TableLayoutPanelAll.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanelAll
    '
    Me.TableLayoutPanelAll.ColumnCount = 2
    Me.TableLayoutPanelAll.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanelAll.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanelAll.Controls.Add(Me.ButtonBridge, 0, 2)
    Me.TableLayoutPanelAll.Controls.Add(Me.ButtonNewSender, 0, 0)
    Me.TableLayoutPanelAll.Controls.Add(Me.ButtonNewReceiver, 1, 0)
    Me.TableLayoutPanelAll.Controls.Add(Me.Button1, 0, 1)
    Me.TableLayoutPanelAll.Controls.Add(Me.ButtonUDPTest, 1, 1)
    Me.TableLayoutPanelAll.Controls.Add(Me.ButtonSerialTest, 0, 3)
    Me.TableLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelAll.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanelAll.Name = "TableLayoutPanelAll"
    Me.TableLayoutPanelAll.RowCount = 4
    Me.TableLayoutPanelAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanelAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanelAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanelAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanelAll.Size = New System.Drawing.Size(284, 367)
    Me.TableLayoutPanelAll.TabIndex = 0
    '
    'ButtonBridge
    '
    Me.ButtonBridge.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonBridge.Location = New System.Drawing.Point(3, 185)
    Me.ButtonBridge.Name = "ButtonBridge"
    Me.ButtonBridge.Size = New System.Drawing.Size(136, 85)
    Me.ButtonBridge.TabIndex = 1
    Me.ButtonBridge.Text = "Bridge"
    Me.ButtonBridge.UseVisualStyleBackColor = True
    '
    'ButtonNewSender
    '
    Me.ButtonNewSender.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonNewSender.Location = New System.Drawing.Point(3, 3)
    Me.ButtonNewSender.Name = "ButtonNewSender"
    Me.ButtonNewSender.Size = New System.Drawing.Size(136, 85)
    Me.ButtonNewSender.TabIndex = 0
    Me.ButtonNewSender.Text = "New TCP sender"
    Me.ButtonNewSender.UseVisualStyleBackColor = True
    '
    'ButtonNewReceiver
    '
    Me.ButtonNewReceiver.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonNewReceiver.Location = New System.Drawing.Point(145, 3)
    Me.ButtonNewReceiver.Name = "ButtonNewReceiver"
    Me.ButtonNewReceiver.Size = New System.Drawing.Size(136, 85)
    Me.ButtonNewReceiver.TabIndex = 1
    Me.ButtonNewReceiver.Text = "New TCP receiver"
    Me.ButtonNewReceiver.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Button1.Location = New System.Drawing.Point(2, 93)
    Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(138, 87)
    Me.Button1.TabIndex = 2
    Me.Button1.Text = "New Test TCP"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ButtonUDPTest
    '
    Me.ButtonUDPTest.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonUDPTest.Location = New System.Drawing.Point(144, 93)
    Me.ButtonUDPTest.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
    Me.ButtonUDPTest.Name = "ButtonUDPTest"
    Me.ButtonUDPTest.Size = New System.Drawing.Size(138, 87)
    Me.ButtonUDPTest.TabIndex = 2
    Me.ButtonUDPTest.Text = "New Test UDP"
    Me.ButtonUDPTest.UseVisualStyleBackColor = True
    '
    'ButtonSerialTest
    '
    Me.ButtonSerialTest.Location = New System.Drawing.Point(3, 276)
    Me.ButtonSerialTest.Name = "ButtonSerialTest"
    Me.ButtonSerialTest.Size = New System.Drawing.Size(124, 67)
    Me.ButtonSerialTest.TabIndex = 3
    Me.ButtonSerialTest.Text = "New Test Serial"
    Me.ButtonSerialTest.UseVisualStyleBackColor = True
    '
    'frmControl
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 367)
    Me.Controls.Add(Me.TableLayoutPanelAll)
    Me.Name = "frmControl"
    Me.Text = "Tx/Rx test"
    Me.TableLayoutPanelAll.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents TableLayoutPanelAll As TableLayoutPanel
  Friend WithEvents ButtonNewSender As Button
  Friend WithEvents ButtonNewReceiver As Button
  Friend WithEvents Button1 As Button
  Friend WithEvents ButtonUDPTest As Button
  Friend WithEvents ButtonBridge As Button
  Friend WithEvents ButtonSerialTest As Button
End Class
