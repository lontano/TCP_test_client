Imports TCP_test_client.Connections

Public Class frmReceiver
  Private WithEvents _tcpReceiver As Connections.TCPReceiver

  Public Delegate Sub UpdateGUIDelegate()
  Public Sub UpdateGUI()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateGUIDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpReceiver Is Nothing Then
        Me.LabelReceiverState.Text = "Data received " & Now.ToString
        Me.LabelReceiverDataRate.Text = _tcpReceiver.DataRateCalculator.DataRateText & " " & _tcpReceiver.DataRateCalculator.TotalDataReceivedText
      End If
    End If
  End Sub

  Public Delegate Sub UpdateButtonsDelegate()
  Public Sub UpdateButtons()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateButtonsDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpReceiver Is Nothing Then
        Me.ButtonReceiverConnect.Text = "Disconnect"
        Me.ButtonReceiverConnect.BackColor = Color.LightGreen
      Else
        Me.ButtonReceiverConnect.Text = "Connect"
        Me.ButtonReceiverConnect.BackColor = Color.LightSalmon
      End If

      Dim itm As ListViewItem = Me.ListViewPackets.Items.Insert(0, Me.ListViewPackets.Items.Count)
      itm.SubItems.Add(Now.ToString)
      itm.SubItems.Add(_lastPacket.Length)
      itm.SubItems.Add(_lastPacket)
    End If
  End Sub

  Public Delegate Sub UpdatePacketDelegate(data As String)
  Public Sub UpdatePacket(siData As String)
    If Me.InvokeRequired Then
      Me.Invoke(New UpdatePacketDelegate(AddressOf UpdatePacket), siData)
    Else
      Dim itm As ListViewItem = Me.ListViewPackets.Items.Insert(0, Me.ListViewPackets.Items.Count)
      itm.SubItems.Add(Now.ToString)
      itm.SubItems.Add(siData.Length)
      itm.SubItems.Add(siData)
    End If
  End Sub

  Dim _lastPacket As String = ""
  Private Sub _tcpReceiver_DataReceive(ByRef sender As TCPReceiver, siData As String) Handles _tcpReceiver.DataReceive
    UpdatePacket(siData)
    UpdateGUI()
  End Sub


  Private Sub ButtonReceiverConnect_Click(sender As Object, e As EventArgs) Handles ButtonReceiverConnect.Click
    If _tcpReceiver Is Nothing Then
      _tcpReceiver = New Connections.TCPReceiver
      _tcpReceiver.Listen(Me.NumericUpDownReceiverPort.Value)
    Else
      _tcpReceiver.Disconnect()
      _tcpReceiver = Nothing
    End If
    UpdateButtons()
  End Sub
End Class
