Imports System.IO
Imports System.IO.Ports

Public Class minimalCOMlistener
  Private comPort As SerialPort

#Region "Properties"
  Private _baudRate As Integer = 38400
  Private _parity As Parity = IO.Ports.Parity.None
  Private _stopBits As StopBits = IO.Ports.StopBits.One
  Private _dataBits As Integer = 8
  Private _portName As String = String.Empty
  Private _msg As String = ""
#End Region

#Region "Events"
  Public Event DataReceiveBytes(ByRef sender As Object, ByRef biData() As Byte)
#End Region

  Public Function Connect(comPort As String)
    Try
      _portName = comPort
      If Me.OpenPort() Then
        Listen()
      End If
    Catch ex As Exception

    End Try
  End Function

  Public Sub Disconnect()
    Try
      If Not comPort Is Nothing Then
        comPort.Close()
        comPort = Nothing
      End If
    Catch ex As Exception

    End Try
  End Sub

  Public Sub Listen()
    Dim kickoffRead As Action = Nothing
    Dim mybuffer(1023) As Byte

    kickoffRead = Sub()
                    comPort.BaseStream.BeginRead(mybuffer, 0, mybuffer.Length, Sub(ByVal ar As IAsyncResult)
                                                                                 Try
                                                                                   Dim actualLength As Integer = comPort.BaseStream.EndRead(ar)
                                                                                   Dim received As Byte() = New Byte(actualLength - 1) {}
                                                                                Buffer.BlockCopy(mybuffer, 0, received, 0, actualLength)
                                                                                raiseAppSerialDataEvent(received)
                                                                              Catch exc As IOException
                                                                                handleAppSerialError(exc)
                                                                              End Try

                                                                              kickoffRead()
                                                                            End Sub, Nothing)
                  End Sub

    kickoffRead()
  End Sub

  Private Sub raiseAppSerialDataEvent(data() As Byte)
    RaiseEvent DataReceiveBytes(Me, data)
  End Sub

  Private Sub handleAppSerialError(exc As IOException)

  End Sub


#Region "OpenPort"
  Public ReadOnly Property Connected As Boolean
    Get
      If comPort Is Nothing Then
        Return False
      Else
        Return comPort.IsOpen
      End If
    End Get
  End Property

  Public Function OpenPort() As Boolean
    Try
      If comPort Is Nothing Then comPort = New SerialPort
      'first check if the port is already open
      'if its open then close it
      If comPort.IsOpen = True Then
        comPort.Close()
      End If

      'set the properties of our SerialPort Object
      comPort.BaudRate = Integer.Parse(_baudRate)
      'BaudRate
      comPort.DataBits = Integer.Parse(_dataBits)
      'DataBits
      Select Case _stopBits
        Case StopBits.None
          comPort.StopBits = StopBits.None
        Case StopBits.One
          comPort.StopBits = StopBits.One
        Case StopBits.OnePointFive
          comPort.StopBits = StopBits.OnePointFive
        Case StopBits.Two
          comPort.StopBits = StopBits.Two
      End Select
      'StopBits
      comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
      'Parity
      comPort.PortName = _portName
      'PortName
      'now open the port
      comPort.Open()
      'display message
      _msg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""

      Return True
    Catch ex As Exception
      _msg = ex.ToString
      Return False
    End Try
  End Function
#End Region

#Region " ClosePort "
  Public Sub ClosePort()
    If comPort.IsOpen Then
      _msg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
      comPort.Close()
    End If
  End Sub
#End Region

End Class
