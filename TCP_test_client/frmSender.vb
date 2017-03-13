Imports TCP_test_client.Connections

Public Class frmSender
  Private WithEvents _tcpSender As Connections.TCPSender

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If Not _tcpSender Is Nothing Then
      _tcpSender.SendData("New text " & Now.ToString())
    End If
  End Sub

  Public Delegate Sub UpdateGUIDelegate()
  Public Sub UpdateGUI()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateGUIDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpSender Is Nothing Then
        Me.LabelSenderState.Text = "Data sent " & Now.ToString
        Me.LabelSenderDataRate.Text = _tcpSender.DataRateCalculator.DataRateText & " " & _tcpSender.DataRateCalculator.TotalDataReceivedText
      End If
    End If
  End Sub

  Public Delegate Sub UpdateButtonsDelegate()
  Public Sub UpdateButtons()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateButtonsDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpSender Is Nothing Then
        Me.ButtonSenderConnect.Text = "Disconnect"
        Me.ButtonSenderConnect.BackColor = Color.LightGreen
      Else
        Me.ButtonSenderConnect.Text = "Connect"
        Me.ButtonSenderConnect.BackColor = Color.LightSalmon
      End If
    End If
  End Sub

  Private Sub _tcpSender_ActivityOutgoing() Handles _tcpSender.ActivityOutgoing
    UpdateGUI()
  End Sub

  Private Sub ButtonSenderConnect_Click(sender As Object, e As EventArgs) Handles ButtonSenderConnect.Click
    If _tcpSender Is Nothing Then
      _tcpSender = New Connections.TCPSender
      _tcpSender.Connect(Me.TextBoxSenderHost.Text, Me.NumericUpDownSenderHost.Value)
    Else
      _tcpSender.Disconnect()
      _tcpSender = Nothing
    End If
    UpdateButtons()
  End Sub

  Private Sub _tcpSender_SentData(ByRef sender As TCPSender, siData As String) Handles _tcpSender.SentData

    Dim itm As ListViewItem = Me.ListViewPackets.Items.Insert(0, Me.ListViewPackets.Items.Count)
    itm.SubItems.Add(Now.ToString)
    itm.SubItems.Add(siData.Length)
    itm.SubItems.Add(siData)
  End Sub
End Class
