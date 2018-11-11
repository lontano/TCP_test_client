Imports System.ComponentModel
Imports System.IO.Ports

Namespace Connections
  Public Class SerialReceiver
    Private _comPortName As String
    Private WithEvents _comPort As IO.Ports.SerialPort

    Public Event ErrorEvent(ByRef sender As SerialReceiver, ByVal CiException As Exception)
    Public Event DataReceive(ByRef sender As SerialReceiver, ByVal siData As String)
    Public Event DataReceiveBytes(ByRef sender As SerialReceiver, ByRef biData() As Byte)
    Public Event ActivityIncoming(ByRef sender As SerialReceiver)

    Public Function Listen(ByVal siComPort As String) As Boolean
      If My.Computer.Ports.SerialPortNames.Contains(siComPort) Then
        _comPortName = siComPort
        _comPort = My.Computer.Ports.OpenSerialPort(_comPortName)
      Else
        _comPortName = ""
      End If
      Return (_comPortName <> "")
    End Function

    Public Sub Disconnect()
      _comPort.Close()
      _comPort = Nothing
    End Sub

    Private Sub _comPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles _comPort.DataReceived
      RaiseEvent DataReceive(Me, _comPort.ReadLine())
    End Sub
  End Class

End Namespace
