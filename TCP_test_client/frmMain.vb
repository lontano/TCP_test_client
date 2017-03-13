Imports TCP_test_client.Connections

Public Class frmMain
  Private WithEvents _tcpSender As Connections.TCPSender
  Private WithEvents _tcpReceiver As Connections.TCPReceiver

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
      If Not _tcpReceiver Is Nothing Then
        Me.LabelReceiverState.Text = "Data received " & Now.ToString
        Me.LabelReceiverDataRate.Text = _tcpReceiver.DataRateCalculator.DataRateText & " " & _tcpReceiver.DataRateCalculator.TotalDataReceivedText
      End If
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
      If Not _tcpReceiver Is Nothing Then
        Me.ButtonReceiverConnect.Text = "Disconnect"
        Me.ButtonReceiverConnect.BackColor = Color.LightGreen
      Else
        Me.ButtonReceiverConnect.Text = "Connect"
        Me.ButtonReceiverConnect.BackColor = Color.LightSalmon
      End If
      If Not _tcpSender Is Nothing Then
        Me.ButtonSenderConnect.Text = "Disconnect"
        Me.ButtonSenderConnect.BackColor = Color.LightGreen
      Else
        Me.ButtonSenderConnect.Text = "Connect"
        Me.ButtonSenderConnect.BackColor = Color.LightSalmon
      End If
    End If
  End Sub

  Private Sub _tcpReceiver_DataReceive(ByRef sender As TCPReceiver, siData As String) Handles _tcpReceiver.DataReceive
    UpdateGUI()
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
