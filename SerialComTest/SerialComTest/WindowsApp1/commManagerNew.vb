Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
'*****************************************************************************************
'                           LICENSE INFORMATION
'*****************************************************************************************
'   PCCom.SerialCommunication Version 1.0.0.0
'   Class file for managing serial port communication
'
'   Copyright (C) 2007  
'   Richard L. McCutchen 
'   Email: richard@psychocoder.net
'   Created: 20OCT07
'
'   This program is free software: you can redistribute it and/or modify
'   it under the terms of the GNU General Public License as published by
'   the Free Software Foundation, either version 3 of the License, or
'   (at your option) any later version.
'
'   This program is distributed in the hope that it will be useful,
'   but WITHOUT ANY WARRANTY; without even the implied warranty of
'   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'   GNU General Public License for more details.
'
'   You should have received a copy of the GNU General Public License
'   along with this program.  If not, see <http://www.gnu.org/licenses/>.
'*****************************************************************************************


Public Class CommManagern
#Region "Manager Enums"
  ''' <summary>
  ''' enumeration to hold our transmission types
  ''' </summary>
  Public Enum TransmissionType
    Text
    Hex
  End Enum

  ''' <summary>
  ''' enumeration to hold our message types
  ''' </summary>
  Public Enum MessageType
    Incoming
    Outgoing
    Normal
    Warning
    [Error]
  End Enum
#End Region

#Region "Manager Variables"
  'property variables
  Private _baudRate As Integer = 38400
  Private _parity As Parity = IO.Ports.Parity.None
  Private _stopBits As StopBits = IO.Ports.StopBits.One
  Private _dataBits As Integer = 8
  Private _portName As String = String.Empty
  Private _transType As TransmissionType
  Private _displayWindow As RichTextBox
  Private _msg As String
  Private _type As MessageType
  'global manager variables
  Private MessageColor As Color() = {Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red}
  Private port As New SerialPort() ' SerialPort()
  Private write As Boolean = True

  Public LastErrorID As Integer = 0
  Public LastErrorString As String = ""
#End Region

#Region "Events"
  Public Event ActivityOutgoing(ByRef sender As Object)
  Public Event SocketConnected(ByRef sender As Object)
  Public Event SentData(ByRef sender As Object, data As String)

  Public Event ErrorEvent(ByRef sender As Object, ByVal CiException As Exception)
  Public Event DataReceive(ByRef sender As Object, ByVal siData As String)
  Public Event DataReceiveBytes(ByRef sender As Object, ByRef biData() As Byte)
  Public Event ActivityIncoming(ByRef sender As Object)

#End Region

#Region "Manager Properties"
  ''' <summary>
  ''' Property to hold the BaudRate
  ''' of our manager class
  ''' </summary>
  Public Property BaudRate() As Integer
    Get
      Return _baudRate
    End Get
    Set(ByVal value As Integer)
      _baudRate = value
    End Set
  End Property

  ''' <summary>
  ''' property to hold the Parity
  ''' of our manager class
  ''' </summary>
  Public Property Parity() As Parity
    Get
      Return _parity
    End Get
    Set(ByVal value As Parity)
      _parity = value
    End Set
  End Property

  ''' <summary>
  ''' property to hold the StopBits
  ''' of our manager class
  ''' </summary>
  Public Property StopBits() As StopBits
    Get
      Return _stopBits
    End Get
    Set(ByVal value As StopBits)
      _stopBits = value
    End Set
  End Property

  ''' <summary>
  ''' property to hold the DataBits
  ''' of our manager class
  ''' </summary>
  Public Property DataBits() As Integer
    Get
      Return _dataBits
    End Get
    Set(ByVal value As Integer)
      _dataBits = value
    End Set
  End Property

  ''' <summary>
  ''' property to hold the PortName
  ''' of our manager class
  ''' </summary>
  Public Property PortName() As String
    Get
      Return _portName
    End Get
    Set(ByVal value As String)
      _portName = value
    End Set
  End Property

  ''' <summary>
  ''' property to hold our TransmissionType
  ''' of our manager class
  ''' </summary>
  Public Property CurrentTransmissionType() As TransmissionType
    Get
      Return _transType
    End Get
    Set(ByVal value As TransmissionType)
      _transType = value
    End Set
  End Property

  ''' <summary>
  ''' property to hold our display window
  ''' value
  ''' </summary>
  Public Property DisplayWindow() As RichTextBox
    Get
      Return _displayWindow
    End Get
    Set(ByVal value As RichTextBox)
      _displayWindow = value
    End Set
  End Property

  ''' <summary>
  ''' Property to hold the message being sent
  ''' through the serial port
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Message() As String
    Get
      Return _msg
    End Get
    Set(ByVal value As String)
      _msg = value
    End Set
  End Property

  ''' <summary>
  ''' Message to hold the transmission type
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Type() As MessageType
    Get
      Return _type
    End Get
    Set(ByVal value As MessageType)
      _type = value
    End Set
  End Property
#End Region

#Region "Manager Constructors"
  ''' <summary>
  ''' Constructor to set the properties of our Manager Class
  ''' </summary>
  ''' <param name="baud">Desired BaudRate</param>
  ''' <param name="par">Desired Parity</param>
  ''' <param name="sBits">Desired StopBits</param>
  ''' <param name="dBits">Desired DataBits</param>
  ''' <param name="name">Desired PortName</param>
  Public Sub New(ByVal baud As String, ByVal par As String, ByVal sBits As String, ByVal dBits As String, ByVal name As String, ByVal rtb As RichTextBox)
    _baudRate = baud
    _parity = par
    _stopBits = sBits
    _dataBits = dBits
    _portName = name
    _displayWindow = rtb
    'now add an event handler
    'AddHandler port.DataReceived, AddressOf comPort_DataReceived
  End Sub

  ''' <summary>
  ''' Comstructor to set the properties of our
  ''' serial port communicator to nothing
  ''' </summary>
  Public Sub New()
    _baudRate = 38400
    _parity = IO.Ports.Parity.None
    _stopBits = IO.Ports.StopBits.One
    _dataBits = 8
    _portName = "COM1"
    _displayWindow = Nothing
    'add event handler
    'AddHandler port.DataReceived, AddressOf comPort_DataReceived
  End Sub

  Private blockLimit As Integer = 1024
  Private Sub initRead()
    Dim buffer As Byte() = New Byte(blockLimit - 1) {}
    Dim kickoffRead As Action = Nothing
    kickoffRead = Sub()
                    port.BaseStream.BeginRead(buffer, 0, buffer.Length, Sub(ByVal ar As IAsyncResult)
                                                                          Try
                                                                            Dim actualLength As Integer = port.BaseStream.EndRead(ar)
                                                                            Dim received As Byte() = New Byte(actualLength - 1) {}
                                                                            System.Buffer.BlockCopy(buffer, 0, received, 0, actualLength)
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
    If _backgroundWorkerDataReceive Is Nothing Then
      _backgroundWorkerDataReceive = New BackgroundWorker
      _backgroundWorkerDataReceive.RunWorkerAsync()
    End If
    _dataReceivedQueue.Enqueue(data)
  End Sub

  Private WithEvents _backgroundWorkerDataReceive As BackgroundWorker
  Private _dataReceivedQueue As New Concurrent.ConcurrentQueue(Of Byte())
  Private Sub _backgroundWorkerDataReceive_DoWork(sender As Object, e As DoWorkEventArgs) Handles _backgroundWorkerDataReceive.DoWork
    Try
      While Not _backgroundWorkerDataReceive Is Nothing
        While _dataReceivedQueue.Count > 0
          Dim data() As Byte
          If _dataReceivedQueue.TryDequeue(data) Then
            RaiseEvent DataReceiveBytes(Me, data)
            'RaiseEvent DataReceive(Me, System.Text.Encoding.ASCII.GetString(data))
            _msg = System.Text.Encoding.ASCII.GetString(data) + "" + Environment.NewLine + ""
            DisplayData(MessageType.Incoming, _msg)
          End If
        End While
      End While
    Catch ex As Exception

    End Try
  End Sub

  Private Sub handleAppSerialError(exc As IOException)
    MsgBox(exc.ToString)
  End Sub
#End Region

#Region "WriteData"
  Public Sub SendData(ByVal msg As String)
    Select Case CurrentTransmissionType
      Case TransmissionType.Text
        'first make sure the port is open
        'if its not open then open it
        If Not (port.IsOpen = True) Then
          port.Open()
        End If
        'send the message to the port
        port.Write(msg)
        'display the message
        _type = MessageType.Outgoing
        _msg = msg + "" + Environment.NewLine + ""
        DisplayData(_type, _msg)
        RaiseEvent DataReceive(Me, _msg)
        Exit Select
      Case TransmissionType.Hex
        Try
          'convert the message to byte array
          Dim newMsg As Byte() = HexToByte(msg)
          If Not write Then
            DisplayData(_type, _msg)
            Exit Sub
          End If
          'send the message to the port
          port.Write(newMsg, 0, newMsg.Length)
          'convert back to hex and display
          _type = MessageType.Outgoing
          _msg = ByteToHex(newMsg) + "" + Environment.NewLine + ""
          DisplayData(_type, _msg)
          RaiseEvent DataReceiveBytes(Me, newMsg)
        Catch ex As FormatException
          'display error message
          _type = MessageType.Error
          _msg = ex.Message + "" + Environment.NewLine + ""
          DisplayData(_type, _msg)
        Finally
          _displayWindow.SelectAll()
        End Try
        Exit Select
      Case Else
        'first make sure the port is open
        'if its not open then open it
        If Not (port.IsOpen = True) Then
          port.Open()
        End If
        'send the message to the port
        port.Write(msg)
        'display the message
        _type = MessageType.Outgoing
        _msg = msg + "" + Environment.NewLine + ""
        DisplayData(MessageType.Outgoing, msg + "" + Environment.NewLine + "")
        Exit Select
    End Select
  End Sub

  Public Sub SendData(newMsg As Byte())
    Try
      If Me.Connected And Not newMsg Is Nothing Then
        'send the message to the port
        'port.Write(newMsg, 0, newMsg.Length)
        port.BaseStream.BeginWrite(newMsg, 0, newMsg.Length, Nothing, Nothing)

        'convert back to hex and display
        _type = MessageType.Outgoing
        _msg = ByteToHex(newMsg) + "" + Environment.NewLine + ""
        DisplayData(_type, _msg)
      End If
    Catch ex As Exception

    End Try
  End Sub
#End Region

#Region "HexToByte"
  ''' <summary>
  ''' method to convert hex string into a byte array
  ''' </summary>
  ''' <param name="msg">string to convert</param>
  ''' <returns>a byte array</returns>
  Private Function HexToByte(ByVal msg As String) As Byte()
    If msg.Length Mod 2 = 0 Then
      'remove any spaces from the string
      _msg = msg
      _msg = msg.Replace(" ", "")
      'create a byte array the length of the
      'divided by 2 (Hex is 2 characters in length)
      Dim comBuffer As Byte() = New Byte(_msg.Length / 2 - 1) {}
      For i As Integer = 0 To _msg.Length - 1 Step 2
        comBuffer(i / 2) = CByte(Convert.ToByte(_msg.Substring(i, 2), 16))
      Next
      write = True
      'loop through the length of the provided string
      'convert each set of 2 characters to a byte
      'and add to the array
      'return the array
      Return comBuffer
    Else
      _msg = "Invalid format"
      _type = MessageType.Error
      ' DisplayData(_Type, _msg)
      write = False
      Return Nothing
    End If
  End Function
#End Region

#Region "ByteToHex"
  ''' <summary>
  ''' method to convert a byte array into a hex string
  ''' </summary>
  ''' <param name="comByte">byte array to convert</param>
  ''' <returns>a hex string</returns>
  Public Shared Function ByteToHex(ByVal comByte As Byte()) As String
    'create a new StringBuilder object
    Dim builder As New StringBuilder(comByte.Length * 3)
    'loop through each byte in the array
    For Each data As Byte In comByte
      builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
      'convert the byte to a string and add to the stringbuilder
    Next
    'return the converted value
    Return builder.ToString().ToUpper()
  End Function
#End Region

#Region "DisplayData"
  ''' <summary>
  ''' Method to display the data to and
  ''' from the port on the screen
  ''' </summary>
  ''' <remarks></remarks>
  <STAThread()>
  Private Sub DisplayData(ByVal type As MessageType, ByVal msg As String)
    Select Case type
      Case MessageType.Error
        RaiseEvent ErrorEvent(Me, Nothing)
      Case MessageType.Incoming
        'RaiseEvent ActivityIncoming(Me)
        'RaiseEvent DataReceive(Me, msg)
      Case MessageType.Normal
      Case MessageType.Outgoing
        'RaiseEvent ActivityOutgoing(Me)
        'RaiseEvent SentData(Me, msg)
      Case MessageType.Warning
    End Select
    If Not _displayWindow Is Nothing Then _displayWindow.Invoke(New EventHandler(AddressOf DoDisplay))
  End Sub
#End Region

#Region "OpenPort"
  Public ReadOnly Property Connected As Boolean
    Get
      If port Is Nothing Then
        Return False
      Else
        Return port.IsOpen
      End If
    End Get
  End Property

  Public Function OpenPort() As Boolean
    Try
      'first check if the port is already open
      'if its open then close it
      If port.IsOpen = True Then
        port.Close()
      End If

      'set the properties of our SerialPort Object
      port.BaudRate = Integer.Parse(_baudRate)
      'BaudRate
      port.DataBits = Integer.Parse(_dataBits)
      'DataBits
      Select Case _stopBits
        Case StopBits.None
          port.StopBits = StopBits.None
        Case StopBits.One
          port.StopBits = StopBits.One
        Case StopBits.OnePointFive
          port.StopBits = StopBits.OnePointFive
        Case StopBits.Two
          port.StopBits = StopBits.Two
      End Select
      'StopBits
      port.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
      'Parity
      port.PortName = _portName
      'PortName
      'now open the port
      port.Open()
      'display message
      _type = MessageType.Normal
      _msg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""
      DisplayData(_type, _msg)
      initRead()
      'return true
      Return True
    Catch ex As Exception
      Me.LastErrorID = ex.HResult
      Me.LastErrorString = ex.Message
      DisplayData(MessageType.[Error], ex.Message)
      Return False
    End Try
  End Function
#End Region

#Region " ClosePort "
  Public Sub ClosePort()
    If port.IsOpen Then
      _msg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
      _type = MessageType.Normal
      DisplayData(_type, _msg)
      port.Close()
    End If
  End Sub
#End Region

#Region "SetParityValues"
  Public Sub SetParityValues(ByVal obj As Object)
    For Each str As String In [Enum].GetNames(GetType(Parity))
      DirectCast(obj, ComboBox).Items.Add(str)
    Next
  End Sub
#End Region

#Region "SetStopBitValues"
  Public Sub SetStopBitValues(ByVal obj As Object)
    For Each str As String In [Enum].GetNames(GetType(StopBits))
      DirectCast(obj, ComboBox).Items.Add(str)
    Next
  End Sub
#End Region

#Region "SetPortNameValues"
  Public Sub SetPortNameValues(ByVal obj As Object)

    For Each str As String In SerialPort.GetPortNames()
      DirectCast(obj, ComboBox).Items.Add(str)
    Next
  End Sub
#End Region

#Region "comPort_DataReceived"
  ''' <summary>
  ''' method that will be called when theres data waiting in the buffer
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
    'determine the mode the user selected (binary/string)
    Select Case CurrentTransmissionType
      Case TransmissionType.Text
        'user chose string
        'read data waiting in the buffer
        Dim msg As String = port.ReadExisting()
        'display the data to the user
        _type = MessageType.Incoming
        _msg = msg
        DisplayData(MessageType.Incoming, msg + "" + Environment.NewLine + "")
        RaiseEvent DataReceive(Me, msg)
        Exit Select
      Case TransmissionType.Hex
        'user chose binary
        'retrieve number of bytes in the buffer
        Dim bytes As Integer = port.BytesToRead
        'create a byte array to hold the awaiting data
        Dim comBuffer As Byte() = New Byte(bytes - 1) {}
        'read the data and store it
        port.Read(comBuffer, 0, bytes)
        'display the data to the user
        _type = MessageType.Incoming
        _msg = ByteToHex(comBuffer) + "" + Environment.NewLine + ""
        'DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "" + Environment.NewLine + "")
        DisplayData(MessageType.Incoming, ByteToHex(comBuffer))
        RaiseEvent DataReceiveBytes(Me, comBuffer)
        Exit Select
      Case Else
        'read data waiting in the buffer
        Dim str As String = port.ReadExisting()
        'display the data to the user
        _type = MessageType.Incoming
        _msg = str + "" + Environment.NewLine + ""
        DisplayData(MessageType.Incoming, str + "" + Environment.NewLine + "")
        Exit Select
    End Select
  End Sub
#End Region

#Region "DoDisplay"
  Private Sub DoDisplay(ByVal sender As Object, ByVal e As EventArgs)
    Try
      If Not _displayWindow Is Nothing Then
        _displayWindow.SelectedText = String.Empty
        _displayWindow.SelectionFont = New Font(_displayWindow.SelectionFont, FontStyle.Bold)
        _displayWindow.SelectionColor = MessageColor(CType(_type, Integer))
        If Not _msg Is Nothing Then _displayWindow.AppendText(_msg)
        _displayWindow.ScrollToCaret()
      End If
    Catch ex As Exception

    End Try
  End Sub
#End Region

  Public Overrides Function ToString() As String
    Dim sText As String = MyBase.ToString
    Try
      sText = Me.PortName & " " & Me.BaudRate & " bps, " & Me.DataBits & Me.Parity.ToString & Me.StopBits
    Catch ex As Exception

    End Try
    Return sText
  End Function
End Class

