Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.ComponentModel


Public Class CommManager
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
  Private _msg As String
  Private _transType As TransmissionType
  Private _type As TransmissionType
  Private _displayWindow As RichTextBox
  'global manager variables
  Private MessageColor As Color() = {Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red}
  Private comPort As New SerialPort() ' SerialPort()
  Private write As Boolean = True

  Public Property GroupPackets As Integer = 1
  Public Property AsyncSend As Boolean = True
  Public Property ExpectedPacketSize As Integer = 0



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
    AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
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
    AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
  End Sub
#End Region

#Region "polling data thread"
  Private WithEvents _readDataWorker As System.ComponentModel.BackgroundWorker

  Private Sub _readDataWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _readDataWorker.DoWork
    Try
      Dim lastBytesToRead As Integer = 0
      While comPort.IsOpen
        Dim bytesToRead As Integer = comPort.BytesToRead
        If comPort.BytesToRead > 0 Then
          If comPort.BytesToRead >= Me.ExpectedPacketSize Or lastBytesToRead = bytesToRead Then
            Dim bytes(bytesToRead - 1) As Byte
            comPort.Read(bytes, 0, bytesToRead)
            RaiseEvent DataReceiveBytes(Me, bytes)
          End If
        End If
        lastBytesToRead = bytesToRead
        Threading.Thread.Sleep(2)
      End While
    Catch ex As Exception

    End Try
  End Sub
#End Region

#Region "WriteData"
  Public Sub SendData(ByVal newMsg As String)
    If newMsg.Length > 0 Then AddMessageToQueue(New msgToWrite(newMsg))
    ''first make sure the port is open
    ''if its not open then open it
    'If Not (comPort.IsOpen = True) Then
    '  comPort.Open()
    'End If
    ''send the message to the port
    'comPort.Write(msg)
    ''display the message
    ''_msg = msg + "" + Environment.NewLine + ""
  End Sub

  Public Sub SendData(newMsg As Byte())
    Try
      If newMsg.Length > 0 Then AddMessageToQueue(New msgToWrite(newMsg))

      'If Me.Connected And Not newMsg Is Nothing Then
      '  'send the message to the port
      '  comPort.Write(newMsg, 0, newMsg.Length)
      '  'convert back to hex and display
      '  '_msg = ByteToHex(newMsg) + "" + Environment.NewLine + ""
      'End If
    Catch ex As Exception

    End Try
  End Sub

  Private Class msgToWrite
    Public text As String
    Public bytes() As Byte
    Public isText As Boolean = False

    Public Sub New(data As String)
      Me.text = data
      Me.isText = True
    End Sub
    Public Sub New(data() As Byte)
      Me.bytes = data
      Me.isText = False
    End Sub
    Public Function DataToWrite() As Object
      Return IIf(Me.isText, Me.text, Me.bytes)
    End Function
  End Class

  Private Sub AddMessageToQueue(msg As msgToWrite)
    Try
      If AsyncSend = False Then 'just send it!
        If Me.Connected Then
          If msg.isText Then
            comPort.Write(msg.text)
          Else
            comPort.Write(msg.bytes, 0, msg.bytes.Length)
          End If
        End If
      Else
        _dataQueue.Enqueue(msg)
        If _sendThread Is Nothing Then
          _sendThread = New System.ComponentModel.BackgroundWorker
          _sendThread.WorkerReportsProgress = False
          _sendThread.WorkerSupportsCancellation = True
          _sendThread.RunWorkerAsync()
        ElseIf _sendThread.IsBusy = False Then
          _sendThread.RunWorkerAsync()
        End If
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private _dataQueue As New Concurrent.ConcurrentQueue(Of msgToWrite)
  Private WithEvents _sendThread As New System.ComponentModel.BackgroundWorker
  Private _portOverruns As Integer = 0
  Public ReadOnly Property PortOverruns As Integer
    Get
      Return _portOverruns
    End Get
  End Property


  Private Sub _sendThread_DoWork(sender As Object, e As DoWorkEventArgs) Handles _sendThread.DoWork
    Try
      Dim msg As msgToWrite = Nothing
      While Not _sendThread Is Nothing
        If groupPackets < 2 Then
          While _dataQueue.Count > 0
            If _dataQueue.Count > 1 Then
              _portOverruns += 1
            End If
            If _dataQueue.TryDequeue(msg) Then
              'if the port is open, send ethe message in the right format
              If Me.Connected Then
                If msg.isText Then
                  comPort.Write(msg.text)
                Else
                  comPort.Write(msg.bytes, 0, msg.bytes.Length)
                End If
              End If
            End If
          End While
        Else

          'we wait until we have 2 things to send, send them together
          If _dataQueue.Count >= groupPackets Then
            Dim msgQueue As New Queue(Of msgToWrite)
            Dim newDataSize As Integer = 0
            While msgQueue.Count < groupPackets
              If _dataQueue.TryDequeue(msg) Then
                msgQueue.Enqueue(msg)
                newDataSize += msg.bytes.Length
              End If
            End While
            Dim newData(newDataSize - 1) As Byte
            Dim offset As Integer = 0
            While msgQueue.Count > 0
              msg = msgQueue.Dequeue()
              Buffer.BlockCopy(msg.bytes, 0, newData, offset, msg.bytes.Length)
            End While
            comPort.Write(newData, 0, newData.Length)
          End If
        End If
      End While
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
      'return true
      _readDataWorker = New BackgroundWorker
      _readDataWorker.RunWorkerAsync()
      Return True
    Catch ex As Exception
      Me.LastErrorID = ex.HResult
      Me.LastErrorString = ex.Message
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
    Try
      'determine the mode the user selected (binary/string)
      'wait to get all data
      'Threading.Thread.Sleep(5)
      'we will wait... 

      Dim pollMode As Boolean = False
      If pollMode = False Then
        Dim timeToWait As Double = 1000 * 11 * Me.ExpectedPacketSize / (BaudRate)

        Threading.Thread.Sleep(timeToWait)
      Else
        While comPort.BytesToRead <= Me.ExpectedPacketSize
          Threading.Thread.Sleep(1)
        End While
      End If
      Dim bytesToRead As Integer = comPort.BytesToRead
      Dim bytes(bytesToRead - 1) As Byte
      comPort.Read(bytes, 0, bytesToRead)
      RaiseEvent DataReceiveBytes(Me, bytes)

      ''read data waiting in the buffer
      'Dim myData As New List(Of Byte)
      'While comPort.BytesToRead > 0
      '  myData.Add(comPort.ReadByte)
      'End While
      ''Dim str As String = comPort.ReadExisting()
      '' Dim str As String = System.Text.Encoding.ASCII.GetString(myData.ToArray)
      ''RaiseEvent DataReceive(Me, str)
      'RaiseEvent DataReceiveBytes(Me, myData.ToArray)
      ''display the data to the user
    Catch ex As Exception
      Debug.Print(ex.ToString)
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

