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

  Public Class TCPReceiver
    Private CPiListener As TcpListener

    Private CPiReceivingIPEndPoint As System.Net.IPEndPoint
    Private WithEvents _backWorkerListener As System.ComponentModel.BackgroundWorker
    Private _backWorkerClients As New List(Of System.ComponentModel.BackgroundWorker)

    Private sPiHostName As String
    Private CPiIPAddress As IPAddress
    Private nPiPort As Integer
    Private bytCommand() As Byte

    Public Event ErrorEvent(ByRef sender As TCPReceiver, ByVal CiException As Exception)
    Public Event DataReceive(ByRef sender As TCPReceiver, ByVal siData As String)
    Public Event DataReceiveBytes(ByRef sender As TCPReceiver, ByRef biData() As Byte)
    Public Event ActivityIncoming(ByRef sender As TCPReceiver)

    Public ReceiverBusy As Boolean = False

    Private CPiLlistaData As New List(Of String)
    Private CPiLlistaDataIPEndPoint As New List(Of System.Net.IPEndPoint)

    Public ReadOnly Property Port As Integer
      Get
        Return Me.nPiPort
      End Get
    End Property

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

    Public Function Listen(ByVal niPort As Integer) As Boolean
      Try
        Me.nPiPort = niPort
        'Me.CPiReceivingIPEndPoint = New System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)

        'Me.CPiListener = New System.Net.Sockets.TcpListener(CPiReceivingIPEndPoint, niPort)

        ''Me.CPiClient = New System.Net.Sockets.TCPClient()
        ''Dim endPoint = New System.Net.IPEndPoint(0, niPort)
        ''Me.CPiClient = New System.Net.Sockets.TCPClient()
        ''Me.CPiClient.ExclusiveAddressUse = False
        ''Me.CPiClient.Client.SetSocketOption(Net.Sockets.SocketOptionLevel.Socket, Net.Sockets.SocketOptionName.ReuseAddress, True)
        ''Me.CPiClient.Client.Bind(endPoint)
        'Me.CPiListener.BeginAcceptSocket.ReceiveBufferSize = 65536

        Me._backWorkerListener = New System.ComponentModel.BackgroundWorker
        Me._backWorkerListener.WorkerReportsProgress = True
        Me._backWorkerListener.WorkerSupportsCancellation = True
        Me._backWorkerListener.RunWorkerAsync()

        Return True
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Throw ex
        Return False
      End Try
    End Function

    Public Sub Disconnect()
      Try
        Me._backWorkerListener.CancelAsync()
        Me._backWorkerListener.Dispose()
        'Me.CPiListener.Close()
        Me.CPiListener = Nothing
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
      End Try
    End Sub

    Private Structure dataReturn
      Dim sData As String
      Dim bData() As Byte
    End Structure

    Private Sub _backWorkerListener_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _backWorkerListener.DoWork
      Try
        Dim ip As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim port As Integer = Me.nPiPort
        Dim listener As New TcpListener(ip, port)

        listener.Start()
        While _backWorkerListener.CancellationPending = False
          Dim client As TcpClient = listener.AcceptTcpClient
          Dim clientWorker As New ComponentModel.BackgroundWorker()
          clientWorker.WorkerReportsProgress = True
          clientWorker.WorkerSupportsCancellation = True
          AddHandler clientWorker.DoWork, AddressOf _backWorkerClient_DoWork
          AddHandler clientWorker.ProgressChanged, AddressOf _backWorkerClient_ProgressChanged
          _backWorkerClients.Add(clientWorker)
          clientWorker.RunWorkerAsync(client)
          _backWorkerListener.ReportProgress(0, client)
        End While
      Catch ex As Exception

      End Try
    End Sub

    Private Sub _backWorkerListener_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles _backWorkerListener.ProgressChanged
      Try

      Catch ex As Exception

      End Try
    End Sub

    Private Sub _backWorkerClient_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
      Try
        Dim tcpClient As System.Net.Sockets.TcpClient = CType(e.Argument, TcpClient)
        Dim networkStream As NetworkStream = tcpClient.GetStream()
        Dim bWorker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim bytesRead As Integer

        If networkStream.CanRead() Then
          While Not bWorker.CancellationPending
            Dim dData As dataReturn
            Dim inbuffer As Byte() = New Byte(CInt(tcpClient.ReceiveBufferSize)) {}
            Dim byteCount As Integer = 0
            'TODO: this is not right: should be adding bytes until the end
            'If networkStream.CanRead Then
            '  Do
            byteCount = networkStream.Read(inbuffer, 0, CInt(tcpClient.ReceiveBufferSize))
            '  Loop While networkStream.DataAvailable
            'End If
            Dim incomingData(byteCount) As Byte
            Array.Copy(inbuffer, incomingData, byteCount)
            dData.bData = incomingData
            dData.sData = System.Text.Encoding.UTF8.GetString(incomingData)
            Me._backWorkerListener.ReportProgress(0, dData)
            bWorker.ReportProgress(0, dData)
          End While
        End If
      Catch ex As Exception
      End Try
    End Sub

    Private Sub _backWorkerClient_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
      Try
        Dim dAux As dataReturn = CType(e.UserState, dataReturn)
        RaiseEvent ActivityIncoming(Me)
        RaiseEvent DataReceive(Me, dAux.sData)
        RaiseEvent DataReceiveBytes(Me, dAux.bData)
        _dataRate.AddData(dAux.sData)
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
      End Try
    End Sub
  End Class
End Namespace
