Imports System.ComponentModel
Imports TCP_test_client.Connections

Public Class frmTestSerial
  Private WithEvents _serialSender As SerialSender
  Private WithEvents _serialReceiver As SerialReceiver

  Private _lastPacketSent As Integer = 0
  Private _dictionaryPackets As New Dictionary(Of String, TestPacket)
  Private _lastPacket As TestPacket = Nothing

  Private WithEvents Timer1 As New PrecisionTimer

  Private WithEvents _backWorker As BackgroundWorker = Nothing

  Private _sendTicks As Long = 100
  Private _sendMS As Long = 100
  Private _sendSW As New Stopwatch
  Private _clockSW As New Stopwatch

  Private Enum ePrecissionType
    Normal
    Sleep
  End Enum

  Dim _lastPan As Integer = 0

  Private Function BuildTRHead(pan As Integer, tilt As Integer, roll As Integer, x As Integer, y As Integer, z As Integer, zoom As Integer, focus As Integer) As Byte()
    Dim dummyData(15 - 1) As Byte
    Try
      'create a dummy free-d position message
      dummyData(0) = HexToByte("D4")(0)
      dummyData(1) = HexToByte("80")(0)

      dummyData = HexToByte("04 88 FF 42 88 FF FD C3 00 20 80 00 10 0E D2")
      dummyData = HexToByte("04 83 FF 42 88 FF FE 1D 00 20 80 00 10 0E 28" & "04 88 FF 42 88 FF FD C3 00 20 80 00 10 0E D2")

      Dim dummyDataList As New List(Of Byte())
      Dim dummyDataList2 As New List(Of Byte())

      dummyDataList.Add(HexToByte("04 80 FF B7 70 FF FD FC FF F0 9D FF DF 61 6D"))
      dummyDataList.Add(HexToByte("04 81 FF B7 70 FF FD FC FF F0 9D FF DF 61 6E"))
      dummyDataList.Add(HexToByte("04 82 FF B7 70 FF FD FC FF F0 9C FF DF 61 6E"))
      dummyDataList.Add(HexToByte("04 83 FF B7 70 FF FD FC FF F0 9D FF DF 60 6F"))
      dummyDataList.Add(HexToByte("04 84 FF B7 70 FF FD FC FF F0 9C FF DF 60 6F"))
      dummyDataList.Add(HexToByte("04 85 FF B7 70 FF FD FC FF F0 9D FF DF 61 72"))
      dummyDataList.Add(HexToByte("04 86 FF B7 70 FF FD FC FF F0 9D FF DF 61 73"))
      dummyDataList.Add(HexToByte("04 87 FF B7 70 FF FD FC FF F0 9C FF DF 60 72"))
      dummyDataList.Add(HexToByte("04 88 FF B7 70 FF FD FC FF F0 9D FF DF 60 74"))
      dummyDataList.Add(HexToByte("04 89 FF B7 70 FF FD FC FF F0 9D FF DF 61 76"))
      dummyDataList.Add(HexToByte("04 8A FF B7 70 FF FD FC FF F0 9C FF DF 60 75"))
      dummyDataList.Add(HexToByte("04 8B FF B7 70 FF FD FC FF F0 9D FF DF 61 78"))
      dummyDataList.Add(HexToByte("04 8C FF B7 70 FF FD FC FF F0 9D FF DF 61 79"))
      dummyDataList.Add(HexToByte("04 8D FF B7 70 FF FD FC FF F0 9C FF DF 61 79"))
      dummyDataList.Add(HexToByte("04 8E FF B7 70 FF FD FC FF F0 9D FF DF 61 7B"))
      dummyDataList.Add(HexToByte("04 8F FF B7 70 FF FD FC FF F0 9C FF DF 61 7B"))

      dummyData = dummyDataList(_lastPan Mod dummyDataList.Count)

      'Dim offset As Integer = 2
      ''pan
      'SetByteValue(dummyData, offset, pan * 32768)
      'offset += 3
      ''tilt
      'SetByteValue(dummyData, offset, tilt * 32768)
      'offset += 3
      ''roll
      'SetByteValue(dummyData, offset, roll * 32768)
      'offset += 3

      ''x
      'SetByteValue(dummyData, offset, x * 640)
      'offset += 3
      ''y
      'SetByteValue(dummyData, offset, y * 640)
      'offset += 3
      ''z (height)
      'SetByteValue(dummyData, offset, z * 640)
      'offset += 3

      ''zoom
      'SetByteValue(dummyData, offset, zoom)
      'offset += 3
      ''focus
      'SetByteValue(dummyData, offset, focus)
      'offset += 3

      'compute checksum
      'Dim checkSum As Integer = 0
      'For i As Integer = 0 To dummyData.Count - 2
      '  checkSum += dummyData(i)
      'Next
      'checkSum = (64 - checkSum) Mod 256
      'If checkSum < 0 Then checkSum += 256
      'dummyData(dummyData.Length - 1) = checkSum
    Catch ex As Exception

    End Try
    Return dummyData
  End Function


  Private Function BuildTrackingPacket() As Byte()
    _lastPan += 1
    'Return BuildFreedPacket(_lastPan, 2, 3, 4, 5, 6, 7, 8)
    Return BuildTRHead(0, 0, 0, 0, 0, 0, 0, 0)
    'Return BuildFreed(0, 0, 0, 0, 0, 0, 0, 0)
  End Function
  Private Function BuildFreed(pan As Integer, tilt As Integer, roll As Integer, x As Integer, y As Integer, z As Integer, zoom As Integer, focus As Integer) As Byte()
    Dim dummyData(30 - 1) As Byte
    Try
      'create a dummy free-d position message
      dummyData(0) = HexToByte("D1")(0)
      dummyData(1) = HexToByte("00")(0)

      Dim offset As Integer = 2
      'pan
      SetByteValue(dummyData, offset, pan * 32768)
      offset += 3
      'tilt
      SetByteValue(dummyData, offset, tilt * 32768)
      offset += 3
      'roll
      SetByteValue(dummyData, offset, roll * 32768)
      offset += 3

      'x
      SetByteValue(dummyData, offset, x * 640)
      offset += 3
      'y
      SetByteValue(dummyData, offset, y * 640)
      offset += 3
      'z (height)
      SetByteValue(dummyData, offset, z * 640)
      offset += 3

      'zoom
      SetByteValue(dummyData, offset, zoom)
      offset += 3
      'focus
      SetByteValue(dummyData, offset, focus)
      offset += 3

      'compute checksum
      Dim checkSum As Integer = 0
      For i As Integer = 0 To dummyData.Count - 2
        checkSum += dummyData(i)
      Next
      checkSum = (64 - checkSum) Mod 256
      If checkSum < 0 Then checkSum += 256
      dummyData(dummyData.Length - 1) = checkSum
    Catch ex As Exception

    End Try
    Return dummyData
  End Function

  Private Sub SetByteValue(ByRef data() As Byte, offset As Integer, value As UInteger)
    Try
      Dim bytes() As Byte = BitConverter.GetBytes(value)
      data(offset) = bytes(2)
      data(offset + 1) = bytes(1)
      data(offset + 2) = bytes(0)
    Catch ex As Exception

    End Try
  End Sub

  Public Shared Function HexToByte(ByVal msg As String) As Byte()
    Dim _msg As String
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
      Return comBuffer
    Else
      _msg = "Invalid format"
      Return Nothing
    End If
  End Function


  Private _ePrecissionType As ePrecissionType = ePrecissionType.Normal
  Private _lastSendTime As Double = 0
  Private _lastSentFramenumber As Integer = 0

  Private Sub _backWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _backWorker.DoWork
    Try
      _sendSW.Start()
      _clockSW.Reset()
      _clockSW.Start()

      Dim packetsPerFrame As Integer = 1

      While Not _backWorker.CancellationPending
        Select Case _ePrecissionType
          Case ePrecissionType.Normal
            Dim sendTime As Double = Now.Subtract(Date.MinValue).TotalMilliseconds
            If sendTime - _lastSendTime >= _sendMS Then
              _lastSendTime = sendTime

              Dim data() As Byte = Me.BuildTrackingPacket()
              _lastPacket = New TestPacket
              _lastPacket.data = data
              _lastPacket.Text = System.Text.Encoding.ASCII.GetString(data)
              _lastPacket.SentTime = Now
              _lastPacket.SendTicks = _lastPacket.SentTime.Subtract(Date.MinValue).TotalMilliseconds
              _serialSender.SendData(data)
              'Me.AddSendPacket(_lastPacket.Text)
              'Me.AddReceivePacket(_lastPacket)
              'sPacket = System.Text.Encoding.ASCII.GetString(Me.BuildFreedPacket())
              ' SendNewPacket(sPacket)
              ' Else
            End If

            'End If
            'Threading.Thread.Sleep(1)
            'Application.DoEvents()
          Case ePrecissionType.Sleep
            Threading.Thread.Sleep(New TimeSpan(_sendMS))
            SendNewPacket(_clockSW.Elapsed.ToString & vbTab & _sendSW.Elapsed.TotalMilliseconds & ":" & (1000 * _clockSW.ElapsedTicks) / Stopwatch.Frequency)
            _sendSW.Reset()
            _sendSW.Start()
        End Select
      End While
      _clockSW.Stop()
    Catch ex As Exception

    End Try
  End Sub

  Dim _sw As Stopwatch
  Private Sub Timer1_Tick(sender As Object, e As EventArgs)
    If Me.CheckBoxSendData.Checked Then
      If _backWorker Is Nothing Then
        _backWorker = New BackgroundWorker
      End If
      If _backWorker.IsBusy = False Then
        _backWorker.WorkerSupportsCancellation = True
        _backWorker.WorkerReportsProgress = True
        _backWorker.RunWorkerAsync()
      End If
    Else
      If Not _backWorker Is Nothing Then
        _backWorker.CancelAsync()
      End If
    End If

    Exit Sub

    If Not _serialSender Is Nothing And Me.CheckBoxSendData.Checked Then
      SendNewPacket("Timer")
    End If
  End Sub

  Private Sub SendNewPacket(data As String)
    Dim wordCount As Integer = 3

    If _sw Is Nothing Then
      _sw = New Stopwatch
      _sw.Start()
    Else
      '  Debug.Print("Ticks ellapsed " & _sw.ElapsedMilliseconds)
      '_sw.Reset()
      '_sw.Start()
    End If

    Dim packet As New TestPacket
    packet.Text = data
    packet.SentTime = Now
    packet.SendTicks = _clockSW.Elapsed.TotalMilliseconds


    If Not _lastPacket Is Nothing Then
      packet.TimeSinceLastPacket = packet.SentTime.Subtract(_lastPacket.SentTime).TotalMilliseconds
    End If
    _lastPacket = packet

    _serialSender.SendData(packet.Text)
    _lastPacketSent += 1
    _dictionaryPackets.Add(packet.Text, packet)
  End Sub

  Public ReadOnly Property Connected
    Get
      If _serialSender Is Nothing Then
        Return False
      Else
        Return _serialSender.Connected
      End If
    End Get
  End Property

  Public Delegate Sub UpdateGUIDelegate()
  Public Sub UpdateGUI()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateGUIDelegate(AddressOf UpdateGUI))
    Else
      If Not _serialSender Is Nothing Then
        Me.LabelSenderState.Text = _sentPackets & "/" & _receivedPackets
        '  Me.ListViewReceivePackets.Items.AddRange(_receiveListViewItems.ToArray)
        ' _receiveListViewItems.Clear()
        'Me.LabelSenderDataRate.Text = _udpSender.DataRateCalculator.DataRateText & " " & _udpSender.DataRateCalculator.TotalDataReceivedText
      End If
    End If
  End Sub

  Public Delegate Sub UpdateButtonsDelegate()
  Public Sub UpdateButtons()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateButtonsDelegate(AddressOf UpdateGUI))
    Else
      If _connectRequest Then
        If Not _serialSender Is Nothing Then
          If _serialSender.Connected Then
            Me.ButtonSenderConnect.Text = "Connect"
            Me.ButtonSenderConnect.BackColor = Color.LightGreen
          Else
            Me.ButtonSenderConnect.Text = "Trying to connect"
            Me.ButtonSenderConnect.BackColor = Color.Red
          End If
        End If
      Else
        Me.ButtonSenderConnect.Text = "Connect"
        Me.ButtonSenderConnect.BackColor = Color.LightSalmon
      End If

    End If
  End Sub

  Private Sub _serialSender_ActivityOutgoing() Handles _serialSender.ActivityOutgoing
    UpdateGUI()
  End Sub

  Private _connectRequest As Boolean = False

  Private Sub ButtonSenderConnect_Click(sender As Object, e As EventArgs) Handles ButtonSenderConnect.Click
    Try
      _connectRequest = Not _connectRequest
      If _connectRequest Then
        If _serialSender Is Nothing Then
          _serialSender = New Connections.SerialSender
          _serialSender.Connect(Me.ComboBoxSerialSend.Text)
          My.Settings.SerialSenderPort = Me.ComboBoxSerialSend.Text
          My.Settings.Save()
        ElseIf _serialSender.Connected = False Then
          _serialSender.Connect(My.Settings.UDPSenderHost)
        End If

        If _serialReceiver Is Nothing Then
          My.Settings.SerialReceiverPort = Me.ComboBoxSerialReceiver.Text
          _serialReceiver = New Connections.SerialReceiver
          _serialReceiver.Listen(My.Settings.SerialReceiverPort)
        Else
          _serialReceiver.Listen(My.Settings.SerialReceiverPort)
        End If
      Else
        _serialSender.Disconnect()
        _serialSender = Nothing
        _serialReceiver.Disconnect()
        _serialReceiver = Nothing
      End If

      UpdateButtons()

    Catch ex As Exception

    End Try
  End Sub

  Private _sentPackets As Integer = 0
  Private _receivedPackets As Integer = 0
  Private _lastSentPacketTime As Date

  Private Sub _serialSender_SentData(ByRef sender As SerialSender, siData As String) Handles _serialSender.SentData
    AddSendPacket(siData)
  End Sub
  Private Sub AddSendPacket(siData As String)
    _sentPackets += 1
    If Me.CheckBoxShowPackets.Checked Then
      Me.Invoke(Sub()
                  Dim itm As ListViewItem = Me.ListViewSendPackets.Items.Insert(0, Me.ListViewSendPackets.Items.Count)
                  itm.SubItems.Add(siData.Length)
                  If Not _lastPacket Is Nothing AndAlso _lastPacket.Text = siData Then
                    itm.SubItems.Add(_lastSentPacketTime.Subtract(_lastPacket.SentTime).TotalMilliseconds)
                    'itm.SubItems.Add(_lastPacket.sent)
                    _lastSentPacketTime = _lastPacket.SentTime
                  Else
                    itm.SubItems.Add(Now.Subtract(_lastSentPacketTime).TotalMilliseconds)
                    _lastSentPacketTime = Now
                  End If

                  itm.SubItems.Add(siData)

                End Sub)
    End If
  End Sub

  Private Sub frmSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    AppNewAutosizeColumns(Me.ListViewSendPackets)

    Me.ComboBoxSerialSend.Items.Clear()
    Me.ComboBoxSerialReceiver.Items.Clear()
    For Each com As String In My.Computer.Ports.SerialPortNames
      Me.ComboBoxSerialSend.Items.Add(com)
      Me.ComboBoxSerialReceiver.Items.Add(com)
    Next

    Me.ComboBoxSerialSend.Text = My.Settings.SerialSenderPort
    Me.ComboBoxSerialReceiver.Text = My.Settings.SerialReceiverPort
    'Me.Timer1.Start()
    'Me.Timer1.Enabled = True
    StartTimer()
  End Sub


  'API Declaration in General Declarations
  Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

  'API Constants
  Const SET_COLUMN_WIDTH As Long = 4126
  Const AUTOSIZE_USEHEADER As Long = -2

  'Sub To Resize
  Private Sub AppNewAutosizeColumns(ByVal TargetListView As ListView)

    Const SET_COLUMN_WIDTH As Long = 4126
    Const AUTOSIZE_USEHEADER As Long = -2

    Dim lngColumn As Long

    For lngColumn = 0 To (TargetListView.Columns.Count - 1)

      Call SendMessage(TargetListView.Handle,
                  SET_COLUMN_WIDTH,
                  lngColumn,
                  AUTOSIZE_USEHEADER)

    Next lngColumn

  End Sub

  Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
    _lastPacketSent = 0
    Me.ListViewSendPackets.Items.Clear()
    Me.ListViewReceivePackets.Items.Clear()
    _dictionaryPackets.Clear()
    _minRoundTripTime = Double.MaxValue
    _maxRoundTripTime = Double.MinValue
    _meanRoundTripTime = 0
    _receivedPackets = 0
    _sentPackets = 0
  End Sub

  Private Sub TimerReconnect_Tick(sender As Object, e As EventArgs) Handles TimerReconnect.Tick
    If _connectRequest Then
      If _serialSender Is Nothing Then
        _serialSender = New Connections.SerialSender
        _serialSender.Connect(Me.ComboBoxSerialSend.Text)
        My.Settings.SerialSenderPort = Me.ComboBoxSerialSend.Text
        My.Settings.Save()
      ElseIf _serialSender.Connected = False Then
        _serialSender.Connect(My.Settings.SerialSenderPort)
      End If
    End If
    Me.UpdateGUI()
  End Sub

  Private Sub _serialSender_Connected() Handles _serialSender.SocketConnected
    Me.UpdateGUI()
    UpdateButtons()
  End Sub

  Private _lastPacketReceived As Date = Now
  Private Sub _serialReceiver_DataReceive(ByRef sender As SerialReceiver, siData As String) Handles _serialReceiver.DataReceive
    _receivedPackets += 1
    Try
      If _dictionaryPackets.ContainsKey(siData) Then
        Dim packet As TestPacket = _dictionaryPackets(siData)
        packet.ReceiveTime = Now
        packet.ReceiveTicks = _clockSW.Elapsed.TotalMilliseconds
        packet.ReceiveTicks = packet.ReceiveTime.Subtract(Date.MinValue).TotalMilliseconds
        packet.SendTicks = packet.SentTime.Subtract(Date.MinValue).TotalMilliseconds
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)
      Else
        Dim packet As TestPacket = New TestPacket
        packet.Text = siData
        packet.SentTime = _lastPacketReceived
        packet.ReceiveTime = Now
        packet.ReceiveTicks = packet.ReceiveTime.Subtract(Date.MinValue).TotalMilliseconds
        packet.SendTicks = packet.SentTime.Subtract(Date.MinValue).TotalMilliseconds
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)
      End If
      _lastPacketReceived = Now
    Catch ex As Exception

    End Try
  End Sub

  Private _minRoundTripTime As Double = Double.MaxValue
  Private _maxRoundTripTime As Double = Double.MinValue
  Private _meanRoundTripTime As Double = 0
  Private _lastReceiveTicks As Double = 0
  Private Sub AddReceivePacket(packet As TestPacket)
    Try

      Dim receivedTick As Double = _clockSW.Elapsed.TotalMilliseconds

      Me.Invoke(Sub()
                  Dim diff As TimeSpan = packet.ReceiveTime.Subtract(packet.SentTime)
                  Dim diffTime As Double = receivedTick - _lastReceiveTicks
                  If Me.CheckBoxShowPackets.Checked Then

                    Dim itm As ListViewItem = Me.ListViewReceivePackets.Items.Insert(0, Me.ListViewReceivePackets.Items.Count)
                    itm.SubItems.Add(packet.Text.Length)
                    itm.SubItems.Add((packet.ReceiveTicks - packet.SendTicks))
                    itm.SubItems.Add(packet.Text)
                  End If

                  ' _minRoundTripTime = Math.Min(_minRoundTripTime, diff.TotalMilliseconds)
                  ' _maxRoundTripTime = Math.Max(_maxRoundTripTime, diff.TotalMilliseconds)
                  '_meanRoundTripTime = (_meanRoundTripTime * (Me.ListViewReceivePackets.Items.Count - 1) + diff.TotalMilliseconds) / Me.ListViewReceivePackets.Items.Count
                  If diffTime > 0 Then
                    _minRoundTripTime = Math.Min(_minRoundTripTime, diffTime)
                    _maxRoundTripTime = Math.Max(_maxRoundTripTime, diffTime)
                    _meanRoundTripTime = (_meanRoundTripTime * (_receivedPackets - 1) + diffTime) / _receivedPackets

                    Me.LabelReceiverDataRate.Text = "Mean time " & _meanRoundTripTime & " (" & _minRoundTripTime & " to " & _maxRoundTripTime & ")"
                  End If
                End Sub)
      _lastReceiveTicks = receivedTick
    Catch ex As Exception

    End Try
  End Sub

  Public Interval As Double = 1000

  Private Sub NumericUpDownDataSendTime_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownDataSendTime.ValueChanged
    ' Me.Interval = Me.NumericUpDownDataSendTime.Value
    _sendMS = Me.NumericUpDownDataSendTime.Value
    _sendTicks = Stopwatch.Frequency * (Me.NumericUpDownDataSendTime.Value) / 1000
    Debug.Print("sEND TICKS " & _sendTicks)
  End Sub

#Region "Timer"
  Private WithEvents _backWorkerTimer As New BackgroundWorker

  Public Sub StartTimer()
    _backWorkerTimer = New BackgroundWorker
    _backWorkerTimer.WorkerReportsProgress = True
    _backWorkerTimer.WorkerSupportsCancellation = True
    _backWorkerTimer.RunWorkerAsync()
  End Sub

  Private Sub _backWorkerTimer_DoWork(sender As Object, e As DoWorkEventArgs) Handles _backWorkerTimer.DoWork
    Try
      'Dim sw As New Stopwatch
      'sw.Start()

      'While Not _backWorkerTimer.CancellationPending
      '  If sw.ElapsedMilliseconds >= Me.Interval Then
      '    '   Debug.Print("Ellapsed time " & sw.ElapsedMilliseconds)
      '    '  _backWorkerTimer.ReportProgress(0)
      '    If Me.Enabled Then
      '      Me.Timer1_Tick(Nothing, Nothing)
      '    End If
      '    sw.Reset()
      '    sw.Start()

      '  Else
      '    Threading.Thread.Sleep(1)
      '  End If
      'End While
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _backWorkerTimer_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _backWorkerTimer.ProgressChanged
    If Me.Enabled Then
      Me.Timer1_Tick(Nothing, Nothing)
    End If
  End Sub

  Private Sub CheckBoxSendData_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSendData.CheckedChanged
    If Me.CheckBoxSendData.Checked Then
      If _backWorker Is Nothing Then
        _backWorker = New BackgroundWorker
      End If
      If _backWorker.IsBusy = False Then
        _backWorker.WorkerSupportsCancellation = True
        _backWorker.WorkerReportsProgress = True
        _backWorker.RunWorkerAsync()
        _lastSendTime = 0
      End If
    Else
      If Not _backWorker Is Nothing Then
        _backWorker.CancelAsync()
      End If
    End If
  End Sub

  Private Sub TimerGUI_Tick(sender As Object, e As EventArgs) Handles TimerGUI.Tick
    Me.UpdateGUI()
  End Sub

  Private Sub ButtonSendPacketNow_Click(sender As Object, e As EventArgs) Handles ButtonSendPacketNow.Click
    Try
      If _sendSW Is Nothing Then _sendSW = New Stopwatch
      If _sendSW.IsRunning = False Then _sendSW.Start()

      If _clockSW Is Nothing Then _clockSW = New Stopwatch
      If _clockSW.IsRunning = False Then _clockSW.Start()

      Dim frameNumber As Integer = _lastSentFramenumber + 1
      Dim sTime As String = _clockSW.Elapsed.ToString
      SendNewPacket(_sendSW.Elapsed.TotalMilliseconds & ":" & (_clockSW.Elapsed.TotalMilliseconds / 1000) & vbTab & " " & sTime & " THIS IS A MANUAL PACKET")
      _sendSW.Reset()
      _sendSW.Start()

      _lastSentFramenumber = frameNumber
    Catch ex As Exception

    End Try
  End Sub

  Private Sub frmTestSerial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    Try
      If Not _serialReceiver Is Nothing Then
        _serialReceiver.Disconnect()
        _serialReceiver = Nothing
      End If
      If Not _serialSender Is Nothing Then
        _serialSender.Disconnect()
        _serialSender = Nothing
      End If
    Catch ex As Exception

    End Try
  End Sub
#End Region
End Class
