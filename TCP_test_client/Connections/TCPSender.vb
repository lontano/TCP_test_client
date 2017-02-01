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
    Private CPiClient As TcpClient

    Private sPiHostName As String
    Private CPiIPAddress As IPAddress
    Private nPiPort As Integer
    Private bytCommand() As Byte

    Public Event ErrorEvent(ByVal CiException As Exception)
    Public Event ActivityOutgoing()

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
        Me.bytCommand = Encoding.UTF8.GetBytes(siData)
        Me.CPiClient.Client.Send(Me.bytCommand)
        RaiseEvent ActivityOutgoing()
        _dataRate.AddData(siData)
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