Imports TCP_test_client.Connections

Public Class frmTestUDP
  Private WithEvents _udpSender As Connections.UDPSender
  Private WithEvents _udpReceiver As Connections.UDPReceiver

  Private _lastPacketSent As Integer = 0
  Private _dictionaryPackets As New Dictionary(Of String, TestPacket)

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If Not _udpSender Is Nothing And Me.CheckBoxSendData.Checked Then
      Dim wordCount As Integer = 3

      Dim packet As New TestPacket
      packet.Text = _lastPacketSent & " This is a test packet"
      packet.SentTime = Now

      _udpSender.SendData(packet.Text)
      _lastPacketSent += 1
      _dictionaryPackets.Add(packet.Text, packet)
    End If
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
        Me.LabelSenderState.Text = "Data sent " & Now.ToString
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
        _udpSender = New Connections.UDPSender
        _udpSender.Connect(Me.TextBoxSenderHost.Text, Me.NumericUpDownSenderPort.Value)
        My.Settings.UDPSenderPort = Me.NumericUpDownSenderPort.Value
        My.Settings.UDPSenderHost = Me.TextBoxSenderHost.Text
        My.Settings.Save()
      ElseIf _udpSender.Connected = False Then
        _udpSender.Connect(My.Settings.UDPSenderHost, My.Settings.UDPSenderPort)
      End If

      If _udpReceiver Is Nothing Then
        _udpReceiver = New Connections.UDPReceiver
        _udpReceiver.Listen(Me.NumericUpDownSenderPort.Value)
      Else
        _udpReceiver.Listen(Me.NumericUpDownSenderPort.Value)
      End If
    Else
      _udpSender.Disconnect()
      _udpSender = Nothing
      _udpReceiver.Disconnect()
      _udpReceiver = Nothing
    End If

    UpdateButtons()
  End Sub

  Private Sub _tcpSender_SentData(ByRef sender As UDPSender, siData As String) Handles _udpSender.SentData
    Dim itm As ListViewItem = Me.ListViewSendPackets.Items.Insert(0, Me.ListViewSendPackets.Items.Count)
    itm.SubItems.Add(siData.Length)
    itm.SubItems.Add(Now.ToString)
    itm.SubItems.Add(siData)
  End Sub

  Private Sub frmSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    AppNewAutosizeColumns(Me.ListViewSendPackets)
    Me.TextBoxSenderHost.Text = My.Settings.UDPSenderHost
    Me.NumericUpDownSenderPort.Value = My.Settings.UDPSenderPort
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
  End Sub

  Private Sub TimerReconnect_Tick(sender As Object, e As EventArgs) Handles TimerReconnect.Tick
    If _connectRequest Then
      If _udpSender Is Nothing Then
        _udpSender = New Connections.UDPSender
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

  Private Sub _tcpReceiver_DataReceive(ByRef sender As UDPReceiver, siData As String) Handles _udpReceiver.DataReceive
    Try
      If _dictionaryPackets.ContainsKey(siData) Then
        Dim packet As TestPacket = _dictionaryPackets(siData)
        packet.ReceiveTime = Now
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

  Private Sub AddReceivePacket(packet As TestPacket)
    Try

      Me.Invoke(Sub()
                  Dim diff As TimeSpan = packet.ReceiveTime.Subtract(packet.SentTime)
                  Dim itm As ListViewItem = Me.ListViewReceivePackets.Items.Insert(0, Me.ListViewReceivePackets.Items.Count)
                  itm.SubItems.Add(diff.TotalMilliseconds)
                  itm.SubItems.Add(Now.ToString)
                  itm.SubItems.Add(packet.Text)

                  _minRoundTripTime = Math.Min(_minRoundTripTime, diff.TotalMilliseconds)
                  _maxRoundTripTime = Math.Max(_maxRoundTripTime, diff.TotalMilliseconds)
                  _meanRoundTripTime = (_meanRoundTripTime * (Me.ListViewReceivePackets.Items.Count - 1) + diff.TotalMilliseconds) / Me.ListViewReceivePackets.Items.Count

                  Me.LabelReceiverDataRate.Text = "Mean time " & _meanRoundTripTime & " (" & _minRoundTripTime & " to " & _maxRoundTripTime & ")"
                End Sub)
    Catch ex As Exception

    End Try
  End Sub
End Class
