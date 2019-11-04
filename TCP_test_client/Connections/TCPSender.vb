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

    Public Event ErrorEvent(ByRef sender As TCPSender, ByVal CiException As Exception)
    Public Event ActivityOutgoing()
    Public Event SentData(ByRef sender As TCPSender, siData As String)
    Public Event ReceivedData(ByRef sender As TCPSender, siData As String, endPoint As IPEndPoint)
    Public Event ReceivedDataBytes(ByRef sender As TCPSender, biData() As Byte, endPoint As IPEndPoint)
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

          Dim state As New StateObject
          state.workSocket = tcpclient.Client
          state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReadCallback), state)
        End If
      Catch ex As Exception
        IsConnectionSuccessful = False
        socketexception = ex
      Finally
        TimeoutObject.[Set]()
      End Try
    End Sub

    Public Class StateObject
      ' Client  socket.
      Public workSocket As Socket = Nothing
      ' Size of receive buffer.
      Public Const BufferSize As Integer = 1024
      ' Receive buffer.
      Public buffer(BufferSize) As Byte
      ' Received data string.
      Public sb As New StringBuilder
    End Class 'StateObject

    Private Sub ReadCallback(ByVal ar As IAsyncResult)
      Dim content As String = String.Empty

      Try

        ' Retrieve the state object and the handler socket
        ' from the asynchronous state object.
        Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Dim handler As Socket = state.workSocket

        ' Read data from the client socket. 
        Dim bytesRead As Integer = handler.EndReceive(ar)

        If bytesRead > 0 Then
          ' There  might be more data, so store the data received so far.
          state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead))
          If bytesRead > 1023 Then
            'we wait for more data
          Else
            content = state.sb.ToString()
            ' Debug.Print(Now.ToString & " Read {0} bytes from socket. " & vbLf & " Data : {1}", content.Length, content)

            RaiseEvent ReceivedData(Me, content, handler.RemoteEndPoint)
            RaiseEvent ReceivedDataBytes(Me, System.Text.Encoding.UTF8.GetBytes(content), handler.RemoteEndPoint)
            state.sb.Clear()
          End If
        Else
          'Debug.Print("Empty callback received from " & CType(ar.AsyncState, StateObject).workSocket.RemoteEndPoint.ToString())
          bytesRead = bytesRead
        End If


        If Me.Connected Then
          handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReadCallback), state)
        End If

      Catch ex As Exception
        ex.ToString()
      End Try

    End Sub 'ReadCallback
  End Class

End Namespace