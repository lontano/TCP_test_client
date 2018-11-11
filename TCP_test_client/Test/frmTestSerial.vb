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
            Threading.Thread.Sleep(2)
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
    packet.Text = _lastPacketSent & ":" & data
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
  End Sub

  Private _sentPackets As Integer = 0
  Private _receivedPackets As Integer = 0

  Private Sub _serialSender_SentData(ByRef sender As SerialSender, siData As String) Handles _serialSender.SentData
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

  Private Sub _serialReceiver_DataReceive(ByRef sender As SerialReceiver, siData As String) Handles _serialReceiver.DataReceive
    _receivedPackets += 1
    Try
      If _dictionaryPackets.ContainsKey(siData) Then
        Dim packet As TestPacket = _dictionaryPackets(siData)
        packet.ReceiveTime = Now
        packet.ReceiveTicks = _clockSW.Elapsed.TotalMilliseconds
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)
      Else
        Dim packet As TestPacket = New TestPacket
        packet.Text = siData
        packet.SentTime = Now
        packet.ReceiveTime = Now
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)
      End If
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
