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
    Me.ButtonNewSender = New System.Windows.Forms.Button()
    Me.ButtonNewReceiver = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ButtonUDPTest = New System.Windows.Forms.Button()
    Me.ButtonBridge = New System.Windows.Forms.Button()
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
    Me.TableLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanelAll.Location = New System.Drawing.Point(0, 0)
    Me.TableLayoutPanelAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.TableLayoutPanelAll.Name = "TableLayoutPanelAll"
    Me.TableLayoutPanelAll.RowCount = 3
    Me.TableLayoutPanelAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    Me.TableLayoutPanelAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    Me.TableLayoutPanelAll.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    Me.TableLayoutPanelAll.Size = New System.Drawing.Size(379, 321)
    Me.TableLayoutPanelAll.TabIndex = 0
    '
    'ButtonNewSender
    '
    Me.ButtonNewSender.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonNewSender.Location = New System.Drawing.Point(4, 4)
    Me.ButtonNewSender.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.ButtonNewSender.Name = "ButtonNewSender"
    Me.ButtonNewSender.Size = New System.Drawing.Size(181, 98)
    Me.ButtonNewSender.TabIndex = 0
    Me.ButtonNewSender.Text = "New TCP sender"
    Me.ButtonNewSender.UseVisualStyleBackColor = True
    '
    'ButtonNewReceiver
    '
    Me.ButtonNewReceiver.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonNewReceiver.Location = New System.Drawing.Point(193, 4)
    Me.ButtonNewReceiver.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.ButtonNewReceiver.Name = "ButtonNewReceiver"
    Me.ButtonNewReceiver.Size = New System.Drawing.Size(182, 98)
    Me.ButtonNewReceiver.TabIndex = 1
    Me.ButtonNewReceiver.Text = "New TCP receiver"
    Me.ButtonNewReceiver.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Button1.Location = New System.Drawing.Point(3, 108)
    Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(183, 102)
    Me.Button1.TabIndex = 2
    Me.Button1.Text = "New Test TCP"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ButtonUDPTest
    '
    Me.ButtonUDPTest.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonUDPTest.Location = New System.Drawing.Point(192, 108)
    Me.ButtonUDPTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.ButtonUDPTest.Name = "ButtonUDPTest"
    Me.ButtonUDPTest.Size = New System.Drawing.Size(184, 102)
    Me.ButtonUDPTest.TabIndex = 2
    Me.ButtonUDPTest.Text = "New Test UDP"
    Me.ButtonUDPTest.UseVisualStyleBackColor = True
    '
    'ButtonBridge
    '
    Me.ButtonBridge.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ButtonBridge.Location = New System.Drawing.Point(4, 216)
    Me.ButtonBridge.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
    Me.ButtonBridge.Name = "ButtonBridge"
    Me.ButtonBridge.Size = New System.Drawing.Size(181, 101)
    Me.ButtonBridge.TabIndex = 1
    Me.ButtonBridge.Text = "Bridge"
    Me.ButtonBridge.UseVisualStyleBackColor = True
    '
    'frmControl
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(379, 321)
    Me.Controls.Add(Me.TableLayoutPanelAll)
    Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
End Class
