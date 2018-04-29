
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Threading.Tasks

Namespace Connections

  Class UDPReceiver

    Private _udpReceive As System.Net.Sockets.UdpClient

    Public Event ErrorEvent(ByRef sender As UDPReceiver, ByVal CiException As Exception)
    Public Event DataReceive(ByRef sender As UDPReceiver, ByVal siData As String)
    Public Event DataReceiveBytes(ByRef sender As UDPReceiver, ByRef biData() As Byte)
    Public Event ActivityIncoming(ByRef sender As UDPReceiver)


    Public Property enabled As Boolean = True

    Public Function Listen(niPort As Integer) As Boolean
      Try
        enabled = True
        _udpReceive = New System.Net.Sockets.UdpClient(niPort)

        _udpReceive.BeginReceive(New AsyncCallback(AddressOf recv), Nothing)

        Return True
      Catch ex As Exception
        MsgBox(ex.ToString)
        Return False
      End Try
    End Function

    Public Sub Disconnect()
      enabled = False
      If _udpReceive IsNot Nothing Then
        _udpReceive.Close()
        _udpReceive = Nothing
      End If
    End Sub

    Private Sub recv(ByVal res As IAsyncResult)
      Try
        Dim RemoteIpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 555)
        Dim received As Byte() = _udpReceive.EndReceive(res, RemoteIpEndPoint)

        If Me.enabled Then
          _udpReceive.BeginReceive(New AsyncCallback(AddressOf recv), Nothing)
        End If

        Dim data As String = Encoding.UTF8.GetString(received)
        RaiseReceiverEvents(received, data)
      Catch __unusedException1__ As Exception
      End Try

      Try
      Catch __unusedException1__ As Exception
      End Try
    End Sub


    Private Sub RaiseReceiverEvents(data() As Byte, sData As String)
      Try
        RaiseEvent ActivityIncoming(Me)
        RaiseEvent DataReceive(Me, sData)
        RaiseEvent DataReceiveBytes(Me, data)
      Catch ex As Exception
        RaiseEvent ErrorEvent(Me, ex)
        Debug.Print(ex.ToString)
      End Try
    End Sub

  End Class
End Namespace
