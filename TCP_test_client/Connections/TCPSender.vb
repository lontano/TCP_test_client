Imports System.Collections.Generic
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

    Public Event ErrorEvent(ByVal CiException As Exception)
    Public Event ActivityOutgoing()
    Public Event SentData(ByRef sender As TCPSender, siData As String)

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

    Public Function Connect(ByVal siHost As String, ByVal niPort As Integer) As Boolean
      Try
        Me.nPiPort = niPort
        Me.CPiClient = New TcpClient
        Me.CPiClient.Client.SendBufferSize = 65536
        If IPAddress.TryParse(siHost, Me.CPiIPAddress) Then
          Me.sPiHostName = ""
          Me.CPiClient.Connect(Me.CPiIPAddress, Me.nPiPort)
        Else
          Me.sPiHostName = siHost
          Me.CPiClient.Connect(Me.sPiHostName, Me.nPiPort)
        End If
        Return True
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
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
        RaiseEvent ErrorEvent(ex)
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
        RaiseEvent ErrorEvent(ex)
      End Try
      Return nRes
    End Function


    Public Sub Disconnect()
      Try
        Me.CPiClient.Close()
        Me.CPiClient = Nothing
      Catch ex As Exception
        RaiseEvent ErrorEvent(ex)
      End Try
    End Sub

  End Class

End Namespace