Imports TCP_test_client.Connections

Public Class frmBridge
  Private WithEvents _udpReceiver As Connections.UDPReceiver
  Private WithEvents _tcpReceiver As Connections.TCPReceiver
  Private WithEvents _udpSender As Connections.UDPSender
  Private WithEvents _tcpSender As Connections.TCPSender

  Private Sub _udpReceiver_DataReceive(ByRef sender As UDPReceiver, siData As String) Handles _udpReceiver.DataReceive
    Debug.Print("udp Data received " & Now.ToString)
    _tcpSender.SendData(siData)
    ' _udpSender.SendData(siData)
  End Sub
  Private Sub _tcpReceiver_DataReceive(ByRef sender As TCPReceiver, siData As String) Handles _tcpReceiver.DataReceive
    Debug.Print("tcp Data received " & Now.ToString)
    _tcpSender.SendData(siData)
    _udpSender.SendData(siData)
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    _udpReceiver = New Connections.UDPReceiver()
    _udpReceiver.Listen(555)
    '
    _tcpReceiver = New Connections.TCPReceiver()
    _tcpReceiver.Listen(560)

    _udpSender = New UDPSender()
    _udpSender.Connect("127.0.0.1", 550)

    _tcpSender = New TCPSender()
    _tcpSender.Connect("127.0.0.1", 580)
  End Sub

End Class