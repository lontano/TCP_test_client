﻿Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.IO

Namespace Connections
  Public Class TCPSender
    Private WithEvents CPiClient As TcpClient

    Private sPiHostName As String
    Private CPiIPAddress As IPAddress
    Private nPiPort As Integer
    Private bytCommand() As Byte

    Public Event ErrorEvent(ByRef sender As TCPSender, ByVal CiException As Exception)
    Public Event ActivityOutgoing()
    Public Event SentData(ByRef sender As TCPSender, siData As String)
    Public Event SocketConnected()
    Public Event SocketDisconnected()

    Private _dataRate As New DataRateCalculator
    Public ReadOnly Property DataRate As Double
      Get
        Return _dataRate.DataRate
      End Get
    End Property

    Public ReadOnly Property DataRateCalculator As DataRateCalculator
      Get
        Return _dataRate
      End Get
    End Property

    Public ReadOnly Property Connected As Boolean
      Get
        If CPiClient Is Nothing Then
          Return False
        Else
          Return CPiClient.Connected
        End If
      End Get
    End Property

    Public Overridable Function Connect(ByVal siHost As String, ByVal niPort As Integer) As Boolean
      Try
        Me.nPiPort = niPort
        Me.CPiClient = New TcpClient
        Me.CPiClient.Client.SendBufferSize = 65536
        If IPAddress.TryParse(siHost, Me.CPiIPAddress) Then
          Me.sPiHostName = ""
          'Me.CPiClient.Connect(Me.CPiIPAddress, Me.nPiPort)
          Dim myEndPoint As New IPEndPoint(Me.CPiIPAddress, niPort)
          Me.CPiClient = Connect(myEndPoint, 5000)
        Else
          Me.sPiHostName = siHost
          'Me.CPiClient.Connect(Me.sPiHostName, Me.nPiPort)
          Dim myEndPoint As IPEndPoint = GetIPEndPointFromHostName(siHost, niPort, False)
          Me.CPiClient = Connect(myEndPoint, 5000)
        End If
        Return True
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Return False
      End Try
    End Function

    Public Function SendData(ByVal siData As String) As Integer
      Dim nRes As Integer = 0
      Try
        If Not Me.CPiClient Is Nothing AndAlso Me.CPiClient.Connected Then
          Me.bytCommand = Encoding.UTF8.GetBytes(siData)
          Me.CPiClient.Client.Send(Me.bytCommand)
          RaiseEvent ActivityOutgoing()
          RaiseEvent SentData(Me, siData)
          _dataRate.AddData(siData)
        End If
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
      Return nRes
    End Function

    Public Function SendData(ByVal biData() As Byte) As Integer
      Dim nRes As Integer = 0
      Try
        Me.bytCommand = biData
        Me.CPiClient.Client.Send(Me.bytCommand)
        RaiseEvent ActivityOutgoing()
        Dim sData As String = System.Text.Encoding.UTF8.GetString(biData)
        RaiseEvent SentData(Me, sData)
        _dataRate.AddData(biData)
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
      Return nRes
    End Function


    Public Sub Disconnect()
      Try
        Me.CPiClient.Close()
        Me.CPiClient = Nothing
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Public Shared Function GetIPEndPointFromHostName(ByVal hostName As String, ByVal port As Integer, ByVal throwIfMoreThanOneIP As Boolean) As IPEndPoint
      Dim addresses = System.Net.Dns.GetHostAddresses(hostName)
      If addresses.Length = 0 Then
        Throw New ArgumentException("Unable to retrieve address from specified host name.", "hostName")
      ElseIf throwIfMoreThanOneIP AndAlso addresses.Length > 1 Then
        Throw New ArgumentException("There is more that one IP address to the specified host.", "hostName")
      End If

      Return New IPEndPoint(addresses(0), port)
    End Function


    Private Shared IsConnectionSuccessful As Boolean = False

    Private Shared socketexception As Exception

    Private Shared TimeoutObject As ManualResetEvent = New ManualResetEvent(False)

    Public Function Connect(ByVal remoteEndPoint As IPEndPoint, ByVal timeoutMSec As Integer) As TcpClient
      TimeoutObject.Reset()
      socketexception = Nothing
      Dim serverip As String = Convert.ToString(remoteEndPoint.Address)
      Dim serverport As Integer = remoteEndPoint.Port
      Dim tcpclient As TcpClient = New TcpClient()
      tcpclient.BeginConnect(serverip, serverport, New AsyncCallback(AddressOf CallBackMethod), tcpclient)

      'If TimeoutObject.WaitOne(timeoutMSec, False) Then
      '  If IsConnectionSuccessful Then
      '    Return tcpclient
      '  Else
      '    Throw socketexception
      '  End If
      'Else
      '  tcpclient.Close()
      '  Throw New TimeoutException("TimeOut Exception")
      'End If

      Return tcpclient
    End Function

    Private Sub CallBackMethod(ByVal asyncresult As IAsyncResult)
      Try
        IsConnectionSuccessful = False
        Dim tcpclient As TcpClient = TryCast(asyncresult.AsyncState, TcpClient)
        If tcpclient.Client IsNot Nothing Then
          tcpclient.EndConnect(asyncresult)
          IsConnectionSuccessful = True
          RaiseEvent SocketConnected()
        End If
      Catch ex As Exception
        IsConnectionSuccessful = False
        socketexception = ex
      Finally
        TimeoutObject.[Set]()
      End Try
    End Sub
  End Class

End Namespace