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
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.ButtonNewSender = New System.Windows.Forms.Button()
    Me.ButtonNewReceiver = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ButtonUDPTest = New System.Windows.Forms.Button()
    Me.ButtonBridge = New System.Windows.Forms.Button()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.ButtonNewSender, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.ButtonNewReceiver, 1, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.ButtonUDPTest, 1, 1)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(24, 12)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 2
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(248, 131)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'ButtonNewSender
    '
    Me.ButtonNewSender.Location = New System.Drawing.Point(3, 3)
    Me.ButtonNewSender.Name = "ButtonNewSender"
    Me.ButtonNewSender.Size = New System.Drawing.Size(86, 40)
    Me.ButtonNewSender.TabIndex = 0
    Me.ButtonNewSender.Text = "New sender"
    Me.ButtonNewSender.UseVisualStyleBackColor = True
    '
    'ButtonNewReceiver
    '
    Me.ButtonNewReceiver.Location = New System.Drawing.Point(127, 3)
    Me.ButtonNewReceiver.Name = "ButtonNewReceiver"
    Me.ButtonNewReceiver.Size = New System.Drawing.Size(91, 43)
    Me.ButtonNewReceiver.TabIndex = 1
    Me.ButtonNewReceiver.Text = "New receiver"
    Me.ButtonNewReceiver.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(2, 67)
    Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(120, 62)
    Me.Button1.TabIndex = 2
    Me.Button1.Text = "New Test"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ButtonUDPTest
    '
    Me.ButtonUDPTest.Location = New System.Drawing.Point(126, 67)
    Me.ButtonUDPTest.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
    Me.ButtonUDPTest.Name = "ButtonUDPTest"
    Me.ButtonUDPTest.Size = New System.Drawing.Size(120, 62)
    Me.ButtonUDPTest.TabIndex = 2
    Me.ButtonUDPTest.Text = "New Test UDP"
    Me.ButtonUDPTest.UseVisualStyleBackColor = True
    '
    'ButtonBridge
    '
    Me.ButtonBridge.Location = New System.Drawing.Point(42, 163)
    Me.ButtonBridge.Name = "ButtonBridge"
    Me.ButtonBridge.Size = New System.Drawing.Size(103, 66)
    Me.ButtonBridge.TabIndex = 1
    Me.ButtonBridge.Text = "Bridge"
    Me.ButtonBridge.UseVisualStyleBackColor = True
    '
    'frmControl
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 261)
    Me.Controls.Add(Me.ButtonBridge)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Name = "frmControl"
    Me.Text = "Tx/Rx test"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
  Friend WithEvents ButtonNewSender As Button
  Friend WithEvents ButtonNewReceiver As Button
  Friend WithEvents Button1 As Button
  Friend WithEvents ButtonUDPTest As Button
  Friend WithEvents ButtonBridge As Button
End Class
