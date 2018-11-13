Namespace Connections
  Public Class SerialSender
    Private _comPortName As String
    Private _comPort As IO.Ports.SerialPort

    Public Event ErrorEvent(ByVal CiException As Exception)
    Public Event ActivityOutgoing()
    Public Event SocketConnected()
    Public Event SentData(ByRef sender As SerialSender, data As String)

    Public ReadOnly Property Connected As Boolean
      Get
        Return (Not _comPortName = "")
      End Get
    End Property

    Public Sub Disconnect()

    End Sub

    Public Function Connect(ByVal siComPort As String) As Boolean
      If My.Computer.Ports.SerialPortNames.Contains(siComPort) Then
        _comPortName = siComPort
                ' _comPort = My.Computer.Ports.OpenSerialPort(_comPortName)
                com1 = My.Computer.Ports.OpenSerialPort(_comPortName)
                com1.BaudRate = 38400

                    RaiseEvent SocketConnected()
      Else
        _comPortName = ""
      End If
      Return (_comPortName <> "")
    End Function
        Private com1 As IO.Ports.SerialPort = Nothing

        Sub SendData(ByVal data As String)
            ' Send strings to a serial port.

            com1.WriteLine(data)
                RaiseEvent SentData(Me, data)

        End Sub
  End Class

End Namespace
