
Imports System.Net

Namespace Connections
  Public Class UDPSendMultiSocket
    Private _udpSenders As New List(Of UDPSender)
    Private _activeSender As Integer = 0

    Private _udpSenderQueue As New Queue(Of UDPSender)


    Public Property NumberOfSenders As Integer = 5

    Private sPiHostName As String
    Private CPiIPAddress As IPAddress
    Private nPiPort As Integer
    Private bytCommand() As Byte

    Public Event ErrorEvent(ByVal CiException As Exception)
    Public Event ActivityOutgoing()
    Public Event SocketConnected()
    Public Event SentData(ByRef sender As UDPSender, data As String)

    Private _dataRate As New DataRateCalculator
    Public ReadOnly Property DataRate As Double
      Get
        Return _dataRate.DataRate
      End Get
    End Property

    Private _connected As Boolean
    Public ReadOnly Property Connected
      Get
        Return _connected
      End Get
    End Property

    Public Function ConnectForBroadcast(ByVal niPort As Integer) As Boolean
      Try
        While _udpSenders.Count > 0
          _udpSenders(0).Disconnect()
          _udpSenders(0) = Nothing
          _udpSenders.RemoveAt(0)
        End While

        While _udpSenders.Count < Me.NumberOfSenders
          Dim udp As New UDPSender
          udp.ConnectForBroadcast(niPort)
          _udpSenders.Add(udp)
        End While

        While _udpSenderQueue.Count < Me.NumberOfSenders
          Dim udp As New UDPSender
          udp.ConnectForBroadcast(niPort)
          _udpSenderQueue.Enqueue(udp)
        End While

        _activeSender = 0

        _connected = True
        RaiseEvent SocketConnected()
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
    End Function

    Public Function Connect(ByVal siHost As String, ByVal niPort As Integer) As Boolean
      Try
        While _udpSenders.Count > 0
          _udpSenders(0).Disconnect()
          _udpSenders(0) = Nothing
          _udpSenders.RemoveAt(0)
        End While

        While _udpSenders.Count < Me.NumberOfSenders
          Dim udp As New UDPSender
          udp.Connect(siHost, niPort)
          AddHandler udp.SentData, AddressOf DataSent
          _udpSenders.Add(udp)
        End While

        While _udpSenderQueue.Count < Me.NumberOfSenders
          Dim udp As New UDPSender
          udp.Connect(siHost, niPort)
          AddHandler udp.SentData, AddressOf DataSent
          _udpSenderQueue.Enqueue(udp)
        End While
        _activeSender = 0

        _connected = True
        RaiseEvent SocketConnected()
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
    End Function

    Public Function SendData(ByVal siData As String) As Integer
      Dim nRes As Integer = 0
      Try
        If True Then
          If _udpSenders.Count > 0 Then
            _activeSender = (_activeSender + 1) Mod _udpSenders.Count
            nRes = _udpSenders(_activeSender).SendData(siData)
          End If
        Else
          Dim udp As UDPSender = _udpSenderQueue.Dequeue
          _udpSenderQueue.Enqueue(udp)
          nRes = udp.SendData(siData)
        End If
      Catch ex As Exception

      End Try

      Return nRes
    End Function

    Private Sub DataSent(ByRef sender As UDPSender, data As String)
      RaiseEvent SentData(sender, data)
    End Sub

    Public Sub UDPSend(ar As IAsyncResult)
      ' Debug.Print("UDPSEnd in " & sw.ElapsedMilliseconds)

    End Sub

    Public Sub Disconnect()
      Try
        While _udpSenders.Count > 0
          _udpSenders(0).Disconnect()
          _udpSenders(0) = Nothing
          _udpSenders.RemoveAt(0)
        End While
        _connected = False
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
    End Sub
  End Class
End Namespace
