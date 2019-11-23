Imports System.ComponentModel
Imports TCP_test_client.Connections

Public Class frmTestUDP
  Private WithEvents _udpSender As Connections.UDPSendMultiSocket
  Private WithEvents _udpReceiver As Connections.UDPReceiver

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
            Dim sendTime As Double = _clockSW.Elapsed.TotalMilliseconds - _lastSendTime
            If _clockSW.Elapsed.TotalMilliseconds - _lastSendTime > _sendMS Then
              _lastSendTime = _clockSW.Elapsed.TotalMilliseconds

              Dim frameNumber As Integer = _clockSW.Elapsed.TotalMilliseconds \ _sendMS
              If frameNumber <> _lastSentFramenumber Then
                _lastSentFramenumber = frameNumber
                '   Debug.Print(sw.ElapsedMilliseconds)
                Dim sPacket As String = ""
                For i As Integer = 1 To packetsPerFrame
                  sPacket = sPacket & frameNumber & " " & _clockSW.Elapsed.ToString & " " & IIf(i = 1, "*******", "") & i & "/" & packetsPerFrame & " " & sendTime - _lastSendTime & ":" & sendTime & vbNullChar
                Next
                SendNewPacket(sPacket)
              Else
              End If

            End If
            Threading.Thread.Sleep(1)
            Application.DoEvents()
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

    If Not _udpSender Is Nothing And Me.CheckBoxSendData.Checked Then
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
    packet.Text = _lastPacketSent & ":" & data
    packet.SentTime = Now

    If Not _lastPacket Is Nothing Then
      packet.TimeSinceLastPacket = packet.SentTime.Subtract(_lastPacket.SentTime).TotalMilliseconds
    End If
    _lastPacket = packet

    _udpSender.SendData(packet.Text)
    _lastPacketSent += 1
    _dictionaryPackets.Add(packet.Text, packet)
  End Sub

  Public ReadOnly Property Connected
    Get
      If _udpSender Is Nothing Then
        Return False
      Else
        Return _udpSender.Connected
      End If
    End Get
  End Property

  Public Delegate Sub UpdateGUIDelegate()
  Public Sub UpdateGUI()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateGUIDelegate(AddressOf UpdateGUI))
    Else
      If Not _udpSender Is Nothing Then
        Me.LabelSenderState.Text = _sentPackets & "/" & _receivedPackets
        '  Me.ListViewReceivePackets.Items.AddRange(_receiveListViewItems.ToArray)
        ' _receiveListViewItems.Clear()
        'Me.LabelSenderDataRate.Text = _udpSender.DataRateCalculator.DataRateText & " " & _udpSender.DataRateCalculator.TotalDataReceivedText
        Me.LabelReceiverDataRate.Text = "Mean time " & _meanRoundTripTime & " dev " & _meanRoundTripTimeDesviation & " (" & _minRoundTripTime & " to " & _maxRoundTripTime & ")"
      End If
    End If
  End Sub

  Public Delegate Sub UpdateButtonsDelegate()
  Public Sub UpdateButtons()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateButtonsDelegate(AddressOf UpdateGUI))
    Else
      If _connectRequest Then
        If Not _udpSender Is Nothing Then
          If _udpSender.Connected Then
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

  Private Sub _tcpSender_ActivityOutgoing() Handles _udpSender.ActivityOutgoing
    UpdateGUI()
  End Sub

  Private _connectRequest As Boolean = False

  Private Sub ButtonSenderConnect_Click(sender As Object, e As EventArgs) Handles ButtonSenderConnect.Click
    _connectRequest = Not _connectRequest
    If _connectRequest Then
      If _udpSender Is Nothing Then
        _udpSender = New Connections.UDPSendMultiSocket
        _udpSender.Connect(Me.TextBoxSenderHost.Text, Me.NumericUpDownSenderPort.Value)
        My.Settings.UDPSenderPort = Me.NumericUpDownSenderPort.Value
        My.Settings.UDPSenderHost = Me.TextBoxSenderHost.Text
        My.Settings.Save()
      ElseIf _udpSender.Connected = False Then
        _udpSender.Connect(My.Settings.UDPSenderHost, My.Settings.UDPSenderPort)
      End If

      If _udpReceiver Is Nothing Then
        My.Settings.UDPReceiverPort = Me.NumericUpDownReceiverPort.Value
        _udpReceiver = New Connections.UDPReceiver
        _udpReceiver.Listen(Me.NumericUpDownReceiverPort.Value)
      Else
        _udpReceiver.Listen(Me.NumericUpDownReceiverPort.Value)
      End If
    Else
      _udpSender.Disconnect()
      _udpSender = Nothing
      _udpReceiver.Disconnect()
      _udpReceiver = Nothing
    End If

    UpdateButtons()
  End Sub

  Private _sentPackets As Integer = 0
  Private _receivedPackets As Integer = 0

  Private Sub _tcpSender_SentData(ByRef sender As UDPSender, siData As String) Handles _udpSender.SentData
    _sentPackets += 1
    If Me.CheckBoxShowPackets.Checked Then
      Me.Invoke(Sub()
                  Dim itm As ListViewItem = Me.ListViewSendPackets.Items.Insert(0, Me.ListViewSendPackets.Items.Count)
                  itm.SubItems.Add(siData.Length)
                  If Not _lastPacket Is Nothing AndAlso _lastPacket.Text = siData Then
                    itm.SubItems.Add(_lastPacket.TimeSinceLastPacket)
                  End If
                  itm.SubItems.Add(siData)
                  itm.SubItems.Add(siData)

                End Sub)
    End If
  End Sub

  Private Sub frmSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    AppNewAutosizeColumns(Me.ListViewSendPackets)
    Me.TextBoxSenderHost.Text = My.Settings.UDPSenderHost
    Me.NumericUpDownSenderPort.Value = My.Settings.UDPSenderPort
    Me.NumericUpDownReceiverPort.Value = My.Settings.UDPReceiverPort
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
    _meanRoundTripTimeDesviation = 0
    _receivedPackets = 0
    _sentPackets = 0
  End Sub

  Private Sub TimerReconnect_Tick(sender As Object, e As EventArgs) Handles TimerReconnect.Tick
    If _connectRequest Then
      If _udpSender Is Nothing Then
        _udpSender = New Connections.UDPSendMultiSocket
        _udpSender.Connect(Me.TextBoxSenderHost.Text, Me.NumericUpDownSenderPort.Value)
        My.Settings.UDPSenderPort = Me.NumericUpDownSenderPort.Value
        My.Settings.UDPSenderHost = Me.TextBoxSenderHost.Text
        My.Settings.Save()
      ElseIf _udpSender.Connected = False Then
        _udpSender.Connect(My.Settings.UDPSenderHost, My.Settings.UDPSenderPort)
      End If
    End If
    Me.UpdateGUI()
  End Sub

  Private Sub _tcpSender_Connected() Handles _udpSender.SocketConnected
    Me.UpdateGUI()
    UpdateButtons()
  End Sub


  Private _lastReceivePacketDate As Date = Now
  Private Sub _udpReceiver_DataReceive(ByRef sender As UDPReceiver, siData As String) Handles _udpReceiver.DataReceive
    Try
      If _dictionaryPackets.ContainsKey(siData) Then
        Dim packet As TestPacket = _dictionaryPackets(siData)
        If packet.RoundTripCompleted = False Then
          _receivedPackets += 1
          packet.ReceiveTime = Now
          packet.RoundTripCompleted = True
          AddReceivePacket(packet)
        End If
      Else
        _receivedPackets += 1
        Dim packet As TestPacket = New TestPacket
        packet.Text = siData
        packet.SentTime = _lastReceivePacketDate
        packet.ReceiveTime = Now
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)
        _lastReceivePacketDate = packet.ReceiveTime
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _udpReceiver_DataReceiveBytes(ByRef sender As UDPReceiver, ByRef biData() As Byte) Handles _udpReceiver.DataReceiveBytes

    Try
      If _dictionaryPackets.ContainsKey(System.Text.Encoding.UTF8.GetString(biData)) Then
        Dim packet As TestPacket = _dictionaryPackets(System.Text.Encoding.UTF8.GetString(biData))
        If packet.RoundTripCompleted = False Then
          _receivedPackets += 1
          packet.ReceiveTime = Now
          packet.RoundTripCompleted = True
          AddReceivePacket(packet)
        End If
      Else
        _receivedPackets += 1
        Dim packet As TestPacket = New TestPacket
        packet.data = biData
        packet.Text = biData.Length
        packet.SentTime = _lastReceivePacketDate
        packet.ReceiveTime = Now
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)
        _lastReceivePacketDate = packet.ReceiveTime
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Function GetDISPacketDescription(packetBytes() As Byte) As String
    Dim sres As String = ""
    Try

      Dim protoVersion As Byte = packetBytes(0)
      Dim exerciseID As Byte = packetBytes(1)
      Dim pduType As Byte = packetBytes(2)
      Dim protoFamily As Byte = packetBytes(3)
      Dim TimeStamp As UInt64 = BitConverter.ToUInt64(packetBytes, 4)
      Dim pduLength As UInt16 = BitConverter.ToUInt16(packetBytes, 8)
      Dim pduPadding As UInt16 = BitConverter.ToUInt16(packetBytes, 10)
      If packetBytes.Length >= 12 Then
        Dim pdu(packetBytes.Length - 12) As Byte
        Buffer.BlockCopy(packetBytes, 12, pdu, 0, packetBytes.Length - 12)
        sres = "Time stamp " & TimeStamp & " | "
        'sres = sres & " | " & System.Text.Encoding.ASCII.GetString(pdu)

        For i As Integer = 0 To packetBytes.Length - 4 Step 4
          sres = sres & " " & BitConverter.ToSingle(packetBytes, i)
        Next
      Else
        sres = System.Text.Encoding.ASCII.GetString(packetBytes)
      End If


    Catch ex As Exception

    End Try
    Return sres
  End Function


  Private _minRoundTripTime As Double = Double.MaxValue
  Private _maxRoundTripTime As Double = Double.MinValue
  Private _meanRoundTripTime As Double = 0
  Private _meanRoundTripTimeDesviation As Double = 0
  Private _lastReceiveTicks As Double = 0
  Private Sub AddReceivePacket(packet As TestPacket)
    Try
      If Not _clockSW.IsRunning Then _clockSW.Start()
      Dim receivedTick As Double = _clockSW.Elapsed.TotalMilliseconds

      Me.Invoke(Sub()
                  Dim diff As TimeSpan = packet.ReceiveTime.Subtract(packet.SentTime)
                  Dim diffTime As Double = receivedTick - _lastReceiveTicks
                  If Me.CheckBoxShowPackets.Checked Then

                    Dim itm As ListViewItem = Me.ListViewReceivePackets.Items.Insert(0, Me.ListViewReceivePackets.Items.Count)
                    itm.SubItems.Add(packet.Text.Length)
                    itm.SubItems.Add((diffTime))
                    itm.SubItems.Add(packet.Text)
                  End If

                  ' _minRoundTripTime = Math.Min(_minRoundTripTime, diff.TotalMilliseconds)
                  ' _maxRoundTripTime = Math.Max(_maxRoundTripTime, diff.TotalMilliseconds)
                  '_meanRoundTripTime = (_meanRoundTripTime * (Me.ListViewReceivePackets.Items.Count - 1) + diff.TotalMilliseconds) / Me.ListViewReceivePackets.Items.Count
                  If diffTime > 0 Then
                    _minRoundTripTime = Math.Min(_minRoundTripTime, diffTime)
                    _maxRoundTripTime = Math.Max(_maxRoundTripTime, diffTime)
                    _meanRoundTripTime = (_meanRoundTripTime * (_receivedPackets - 1) + diffTime) / _receivedPackets
                    _meanRoundTripTimeDesviation = (_meanRoundTripTimeDesviation * (_receivedPackets - 1) + Math.Abs(_meanRoundTripTime - diffTime)) / _receivedPackets


                    'Debug.Print(diffTime & " " & (_meanRoundTripTime - diffTime))
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

  Private WithEvents _multimediaTimer As Timer


  Private Sub InitTestTimer()
    _sendSW.Start()
    _clockSW.Reset()
    _clockSW.Start()

    _multimediaTimer = New Timer
    _multimediaTimer.Interval = 1 ' Me.NumericUpDownDataSendTime.Value
    AddHandler _multimediaTimer.Tick, AddressOf timer_Elapsed 'Function(o, e) Console.WriteLine(s.ElapsedMilliseconds)

    _multimediaTimer.Start()

  End Sub
  Private Sub timer_Elapsed(sender As Object, e As EventArgs)

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
      End If
      'InitTestTimer()
      _lastSendTime = 0
    Else
      If Not _backWorker Is Nothing Then
        _backWorker.CancelAsync()
      End If
      If Not _multimediaTimer Is Nothing Then _multimediaTimer.Stop()
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

  Private Sub _multimediaTimer_Elapsed(sender As Object, e As EventArgs) Handles _multimediaTimer.Tick
    Try
      '_multimediaTimer.Interval = 1 ' Me.NumericUpDownDataSendTime.Value

      Dim packetsPerFrame As Integer = 1
      Dim sendTime As Double = _clockSW.Elapsed.TotalMilliseconds - _lastSendTime
      'Debug.Print(sendTime)
      If sendTime > _sendMS Then
        _lastSendTime = _clockSW.Elapsed.TotalMilliseconds

        Dim frameNumber As Integer = _clockSW.Elapsed.TotalMilliseconds \ _sendMS
        If frameNumber <> _lastSentFramenumber Then
          _lastSentFramenumber = frameNumber
          '   Debug.Print(sw.ElapsedMilliseconds)
          Dim sPacket As String = ""
          For i As Integer = 1 To packetsPerFrame
            sPacket = sPacket & frameNumber & " " & _clockSW.Elapsed.ToString & " " & IIf(i = 1, "*******", "") & i & "/" & packetsPerFrame & " " & sendTime - _lastSendTime & ":" & sendTime & vbNullChar
          Next
          SendNewPacket(sPacket)
        Else
        End If

      End If
    Catch ex As Exception

    End Try

  End Sub

#End Region
End Class
