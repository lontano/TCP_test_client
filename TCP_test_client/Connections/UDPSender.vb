Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports System.Diagnostics

Namespace Connections
  Public Class UDPSender
    Private CPiClient As UdpClient

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
        Me.nPiPort = niPort
        Me.CPiClient = New UdpClient(niPort)
        Me.CPiClient.Client.SendBufferSize = 65536
        Me.CPiClient.EnableBroadcast = True
        Me.CPiClient.Connect(IPAddress.Broadcast, niPort)
        _connected = True
        RaiseEvent SocketConnected()
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
    End Function

    Public Function Connect(ByVal siHost As String, ByVal niPort As Integer) As Boolean
      Try
        Me.nPiPort = niPort
        Me.CPiClient = New UdpClient
        Me.CPiClient.Client.SendBufferSize = 65536
        If IPAddress.TryParse(siHost, Me.CPiIPAddress) Then
          Me.sPiHostName = ""
          Me.CPiClient.Connect(Me.CPiIPAddress, Me.nPiPort)
        Else
          Me.sPiHostName = siHost
          Me.CPiClient.Connect(Me.sPiHostName, Me.nPiPort)
        End If
        _connected = True
        RaiseEvent SocketConnected()
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
    End Function

    Public Function SendData(ByVal siData As String) As Integer
      Dim nRes As Integer = 0
      Try
        RaiseEvent ActivityOutgoing()
        RaiseEvent SentData(Me, siData)
        Me.bytCommand = Encoding.UTF8.GetBytes(siData)
        Me.CPiClient.BeginSend(bytCommand, bytCommand.Length, New AsyncCallback(AddressOf UDPSend), Nothing)
        nRes = bytCommand.Length
        ' nRes = Me.CPiClient.Send(Me.bytCommand, Me.bytCommand.Length)
        '_dataRate.AddData(siData)
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
      Return nRes
    End Function


    Public Sub UDPSend(ar As IAsyncResult)

    End Sub

    Public Sub Disconnect()
      Try
        Me.CPiClient.Close()
        Me.CPiClient = Nothing
        _connected = False
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
    End Sub

  End Class
End Namespace