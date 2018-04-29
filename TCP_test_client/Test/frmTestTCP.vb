Imports TCP_test_client.Connections

Public Class frmTestTCP
  Private WithEvents _tcpSender As Connections.TCPSender
  Private WithEvents _tcpReceiver As Connections.TCPReceiver

  Private _lastPacketSent As Integer = 0
  Private _dictionaryPackets As New Dictionary(Of String, TestPacket)



  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If Not _tcpSender Is Nothing And Me.CheckBoxSendData.Checked Then
      Dim wordCount As Integer = 3
      Static rnd As New Random
      For i As Integer = 0 To 0 * CInt(rnd.Next(5))

        Dim packet As New TestPacket
        'packet.Text = _lastPacketSent & " This is a test packet"
        packet.Text = "<" & _lastPacketSent & " RENDERER SET_OBJECT nothing>"
        packet.SentTime = Now

        _tcpSender.SendData(packet.Text)
        _lastPacketSent += 1
        _dictionaryPackets.Add(packet.Text, packet)
      Next
    End If
  End Sub

  Public ReadOnly Property Connected
    Get
      If _tcpSender Is Nothing Then
        Return False
      Else
        Return _tcpSender.Connected
      End If
    End Get
  End Property

  Public Delegate Sub UpdateGUIDelegate()
  Public Sub UpdateGUI()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateGUIDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpSender Is Nothing Then
        'Me.LabelSenderState.Text = "Data sent " & Now.ToString
        Me.LabelSenderState.Text = _sentPackets & "/" & _receivedPackets
        Me.LabelSenderDataRate.Text = _tcpSender.DataRateCalculator.DataRateText & " " & _tcpSender.DataRateCalculator.TotalDataReceivedText
      End If
    End If
  End Sub

  Public Delegate Sub UpdateButtonsDelegate()
  Public Sub UpdateButtons()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateButtonsDelegate(AddressOf UpdateGUI))
    Else
      If _connectRequest Then
        If Not _tcpSender Is Nothing Then
          If _tcpSender.Connected Then
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

  Private Sub _tcpSender_ActivityOutgoing() Handles _tcpSender.ActivityOutgoing
    UpdateGUI()
  End Sub

  Private _connectRequest As Boolean = False

  Private Sub ButtonSenderConnect_Click(sender As Object, e As EventArgs) Handles ButtonSenderConnect.Click
    _connectRequest = Not _connectRequest
    If _connectRequest Then
      If _tcpSender Is Nothing Then
        _tcpSender = New Connections.TCPSender
        _tcpSender.Connect(Me.TextBoxSenderHost.Text, Me.NumericUpDownSenderPort.Value)
        My.Settings.SenderPort = Me.NumericUpDownSenderPort.Value
        My.Settings.SenderHost = Me.TextBoxSenderHost.Text
        My.Settings.Save()
      ElseIf _tcpSender.Connected = False Then
        _tcpSender.Connect(My.Settings.SenderHost, My.Settings.SenderPort)
      End If

      If _tcpReceiver Is Nothing Then
        _tcpReceiver = New Connections.TCPReceiver
        _tcpReceiver.Listen(Me.NumericUpDownSenderPort.Value)
      Else
        _tcpReceiver.Listen(Me.NumericUpDownSenderPort.Value)
      End If
    Else
      _tcpSender.Disconnect()
      _tcpSender = Nothing
    End If

    UpdateButtons()
  End Sub


  Private _sentPackets As Integer = 0
  Private _receivedPackets As Integer = 0

  Private Sub _tcpSender_SentData(ByRef sender As TCPSender, siData As String) Handles _tcpSender.SentData
    _sentPackets += 1

    If Me.CheckBoxShowPackets.Checked Then

      Dim itm As ListViewItem = Me.ListViewSendPackets.Items.Insert(0, Me.ListViewSendPackets.Items.Count)
      itm.SubItems.Add(siData.Length)
      itm.SubItems.Add(siData.Length)
      itm.SubItems.Add(siData)
    End If
  End Sub

  Private Sub frmSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    AppNewAutosizeColumns(Me.ListViewSendPackets)
    Me.TextBoxSenderHost.Text = My.Settings.SenderHost
    Me.NumericUpDownSenderPort.Value = My.Settings.SenderPort
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

  Private Sub _tcpSender_ErrorEvent(ByRef sender As TCPSender, CiException As Exception) Handles _tcpSender.ErrorEvent
    Static busy As Boolean = False
    If busy Then Exit Sub
    busy = True

    Debug.Print(CiException.ToString)
    busy = False
  End Sub

  Private Sub NumericUpDownDataSendTime_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownDataSendTime.ValueChanged
    Me.Timer1.Interval = Me.NumericUpDownDataSendTime.Value
  End Sub

  Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
    _lastPacketSent = 0
    Me.ListViewSendPackets.Items.Clear()
    Me.ListViewReceivePackets.Items.Clear()
    _dictionaryPackets.Clear()
    _minRoundTripTime = Double.MaxValue
    _maxRoundTripTime = Double.MinValue
    _meanRoundTripTime = 0
    _sentPackets = 0
    _receivedPackets = 0
  End Sub

  Private Sub TimerReconnect_Tick(sender As Object, e As EventArgs) Handles TimerReconnect.Tick
    If _connectRequest Then
      If _tcpSender Is Nothing Then
        _tcpSender = New Connections.TCPSender
        _tcpSender.Connect(Me.TextBoxSenderHost.Text, Me.NumericUpDownSenderPort.Value)
        My.Settings.SenderPort = Me.NumericUpDownSenderPort.Value
        My.Settings.SenderHost = Me.TextBoxSenderHost.Text
        My.Settings.Save()
      ElseIf _tcpSender.Connected = False Then
        _tcpSender.Connect(My.Settings.SenderHost, My.Settings.SenderPort)
      End If
    End If
    Me.UpdateGUI()
  End Sub

  Private Sub _tcpSender_Connected() Handles _tcpSender.SocketConnected
    Me.UpdateGUI()
    UpdateButtons()
  End Sub

  Private Sub _tcpReceiver_DataReceive(ByRef sender As TCPReceiver, siData As String) Handles _tcpReceiver.DataReceive

  End Sub

  Private Sub _tcpReceiver_DataReceiveBytes(ByRef sender As TCPReceiver, ByRef biData() As Byte) Handles _tcpReceiver.DataReceiveBytes
    _receivedPackets += 1
    Try
      Dim sData As String = System.Text.Encoding.UTF8.GetString(biData)
      If _dictionaryPackets.ContainsKey(sData) Then
        Dim packet As TestPacket = _dictionaryPackets(sData)
        packet.ReceiveTime = Now
        packet.data = biData
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)
      Else
        Dim packet As New TestPacket
        packet.ReceiveTime = Now
        packet.data = biData
        packet.Text = System.Text.Encoding.UTF8.GetString(biData)
        packet.RoundTripCompleted = True
        AddReceivePacket(packet)

      End If
    Catch ex As Exception

    End Try
  End Sub

  Private _minRoundTripTime As Double = Double.MaxValue
  Private _maxRoundTripTime As Double = Double.MinValue
  Private _meanRoundTripTime As Double = 0

  Private Sub AddReceivePacket(packet As TestPacket)
    Try

      Me.Invoke(Sub()
                  Dim diff As TimeSpan = packet.ReceiveTime.Subtract(packet.SentTime)
                  If Me.CheckBoxShowPackets.Checked Then
                    Dim itm As ListViewItem = Me.ListViewReceivePackets.Items.Insert(0, Me.ListViewReceivePackets.Items.Count)
                    itm.SubItems.Add(diff.TotalMilliseconds)
                    itm.SubItems.Add(packet.data.Length)
                    itm.SubItems.Add(packet.Text)


                  End If
                  _minRoundTripTime = Math.Min(_minRoundTripTime, diff.TotalMilliseconds)
                  _maxRoundTripTime = Math.Max(_maxRoundTripTime, diff.TotalMilliseconds)
                  _meanRoundTripTime = (_meanRoundTripTime * (Me.ListViewReceivePackets.Items.Count - 1) + diff.TotalMilliseconds) / Me.ListViewReceivePackets.Items.Count

                  Me.LabelReceiverDataRate.Text = "Mean time " & _meanRoundTripTime & " (" & _minRoundTripTime & " to " & _maxRoundTripTime & ")"
                End Sub)
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _tcpReceiver_ActivityIncoming(ByRef sender As TCPReceiver) Handles _tcpReceiver.ActivityIncoming
    Me.UpdateGUI()
  End Sub

  Private Sub ButtonSendManualText_Click(sender As Object, e As EventArgs) Handles ButtonSendManualText.Click
    If Not _tcpSender Is Nothing Then
      SendPacket(Me.TextBoxManualText.Text)
    End If
  End Sub

  Private Sub SendPacket(siText As String)

    Dim packet As New TestPacket
    'packet.Text = _lastPacketSent & " This is a test packet"
    packet.Text = _lastPacketSent & ":" & siText & vbNullChar
    packet.SentTime = Now

    _tcpSender.SendData(packet.Text)
    _lastPacketSent += 1
    _dictionaryPackets.Add(packet.Text, packet)
  End Sub
End Class
