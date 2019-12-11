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
    Private _tcpClients As New List(Of TcpClient)

    Private sPiHostName As String
    Private CPiIPAddress As IPAddress
    Private nPiPort As Integer
    Private bytCommand() As Byte

    Public Event ErrorEvent(ByRef sender As TCPReceiver, ByVal CiException As Exception)
    Public Event DataReceive(ByRef sender As TCPReceiver, ByVal siData As String)
    Public Event DataReceiveBytes(ByRef sender As TCPReceiver, biData() As Byte)
    Public Event ActivityIncoming(ByRef sender As TCPReceiver)

    Public ReceiverBusy As Boolean = False

    Private CPiLlistaData As New List(Of String)
    Private CPiLlistaDataIPEndPoint As New List(Of System.Net.IPEndPoint)

    Public Property ForwardMessagesToOtherClients As Boolean = False

    Public ReadOnly Property Port As Integer
      Get
        Return Me.nPiPort
      End Get
    End Property


    Public Overridable Function Listen(ByVal niPort As Integer) As Boolean
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

        Dim ip As IPAddress = IPAddress.Any
        Dim port As Integer = Me.nPiPort
        CPiListener = New TcpListener(ip, port)

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

    Public Overridable Sub Disconnect()
      Try
        Me.CPiListener.Stop()
        Me.CPiListener = Nothing

        Me._backWorkerListener.CancelAsync()
        Me._backWorkerListener.Dispose()

        For i As Integer = 0 To _tcpClients.Count - 1
          _tcpClients(i).Close()
          _tcpClients(i) = Nothing
        Next
        For i As Integer = 0 To _backWorkerClients.Count - 1
          _backWorkerClients(i).CancelAsync()
          _backWorkerClients(i).Dispose()
        Next

        _tcpClients.Clear()
        _backWorkerClients.Clear()

      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Friend Structure dataReturn
      Dim sData As String
      Dim bData() As Byte
      Dim remoteEndPoint As EndPoint
    End Structure

    Private Sub _backWorkerListener_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _backWorkerListener.DoWork
      Try
        CPiListener.Start()
        While _backWorkerListener.CancellationPending = False
          Dim client As TcpClient = CPiListener.AcceptTcpClient
          Dim clientWorker As New ComponentModel.BackgroundWorker()
          clientWorker.WorkerReportsProgress = True
          clientWorker.WorkerSupportsCancellation = True
          AddHandler clientWorker.DoWork, AddressOf _backWorkerClient_DoWork
          AddHandler clientWorker.ProgressChanged, AddressOf _backWorkerClient_ProgressChanged
          _tcpClients.Add(client)
          _backWorkerClients.Add(clientWorker)
          clientWorker.RunWorkerAsync(client)
          _backWorkerListener.ReportProgress(0, client)
        End While
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Public Event NewConnection(sender As TCPReceiver, client As TcpClient)

    Private Sub _backWorkerListener_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles _backWorkerListener.ProgressChanged
      Try
        RaiseEvent NewConnection(Me, CType(e.UserState, TcpClient))
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Private Sub _backWorkerClient_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
      Try
        Dim tcpClient As System.Net.Sockets.TcpClient = CType(e.Argument, TcpClient)
        Dim networkStream As NetworkStream = tcpClient.GetStream()
        Dim bWorker As BackgroundWorker = CType(sender, BackgroundWorker)

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
            If byteCount > 0 Then
              Dim incomingData(byteCount - 1) As Byte
              Array.Copy(inbuffer, incomingData, byteCount)
              dData.bData = incomingData
              dData.sData = System.Text.Encoding.UTF8.GetString(incomingData)
              dData.remoteEndPoint = tcpClient.Client.RemoteEndPoint
              'Me._backWorkerListener.ReportProgress(0, dData)
              bWorker.ReportProgress(0, dData)
              If Me.ForwardMessagesToOtherClients Then
                Me.send(incomingData)
              End If
            End If
          End While
        End If
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Public Sub send(data() As Byte)
      'send to everybody else
      Dim clientsToRemove As New Queue(Of TcpClient)
      For Each client As TcpClient In _tcpClients
        Try
          'client.Client.Send(data)
          client.Client.BeginSend(data, 0, data.Length, 0, New AsyncCallback(AddressOf SendCallback), client.Client)
        Catch ex As Exception
          clientsToRemove.Enqueue(client)
        End Try
      Next

      While clientsToRemove.Count > 0
        Dim client As TcpClient = clientsToRemove.Dequeue()
        _tcpClients.Remove(client)
        Try
          client.Close()
        Catch ex As Exception
        End Try
      End While
    End Sub

    Private Sub SendCallback(ByVal ar As IAsyncResult)

    End Sub

    Public Sub Send(data As String)
      Me.send(System.Text.Encoding.UTF8.GetBytes(data))
    End Sub

    Private Sub _backWorkerClient_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
      Try
        Dim dData As dataReturn = CType(e.UserState, dataReturn)
        Me.RaiseReceiverEvents(dData)

        Task.run(Sub()

                   'send to everybody else
                   Dim clientsToRemove As New Queue(Of TcpClient)
                   For Each client As TcpClient In _tcpClients
                     If client.Client.RemoteEndPoint.ToString <> dData.remoteEndPoint.ToString Then
                       Try
                         If ForwardMessagesToOtherClients Then client.Client.Send(dData.bData)
                       Catch ex As Exception
                         clientsToRemove.Enqueue(client)
                       End Try
                     End If
                   Next

                   While clientsToRemove.Count > 0
                     Dim client As TcpClient = clientsToRemove.Dequeue()
                     _tcpClients.Remove(client)
                     Try
                       client.Close()
                     Catch ex As Exception
                     End Try
                   End While

                 End Sub)
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Friend Sub RaiseReceiverEvents(data As dataReturn)
      Try
        RaiseEvent ActivityIncoming(Me)
        RaiseEvent DataReceive(Me, data.sData)
        RaiseEvent DataReceiveBytes(Me, data.bData)
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Friend Sub RaiseReceiverEvents(data As String)
      Try
        RaiseEvent ActivityIncoming(Me)
        RaiseEvent DataReceive(Me, data)
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

    Friend Sub RaiseReceiverEvents(data() As Byte)
      Try
        RaiseEvent ActivityIncoming(Me)
        RaiseEvent DataReceiveBytes(Me, data)
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub
  End Class
End Namespace
