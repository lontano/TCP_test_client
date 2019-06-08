Imports System.Net
Imports System.Net.Sockets
Imports TCP_test_client.Connections

Public Class frmTestTCP
  Private WithEvents _tcpSender As Connections.TCPSender
  Private WithEvents _tcpReceiver As Connections.TCPReceiver

  Private _lastPacketSent As Integer = 0
  Private _dictionaryPackets As New Dictionary(Of String, TestPacket)


  Private rnd As New Random

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If Not _tcpSender Is Nothing And Me.CheckBoxSendData.Checked Then
      Dim wordCount As Integer = 3
      For i As Integer = 0 To 0 * CInt(rnd.Next(5))

        Dim packet As New TestPacket
        'packet.Text = _lastPacketSent & " This is a test packet"
        packet.Text = "<" & _lastPacketSent & " RENDERER SET_OBJECT nothing>"
        Dim padding As Integer = Me.NumericUpDownMaxPacketSize.Value - packet.Text.Length

        packet.Text = packet.Text & New String(CStr(_lastPacketSent Mod 10), Math.Max(0, padding - 1))

        packet.data = System.Text.Encoding.ASCII.GetBytes(packet.Text)
        packet.SentTime = Now

        _tcpSender.SendData(packet.Text & vbNullChar)
        _lastPacketSent += 1
        _dictionaryPackets.Add(packet.Text, packet)
        _sentPacketList.Add(packet)
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
        Me.LabelSenderState.Text = _sentPackets & "/" & _receivedIntermediatePackets & "/" & _receivedPackets
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
  Private _receivedIntermediatePackets As Integer = 0
  Private _lastSentTime As Date

  Private Sub _tcpSender_SentData(ByRef sender As TCPSender, siData As String) Handles _tcpSender.SentData
    _sentPackets += 1

    If Me.CheckBoxShowPackets.Checked Then
      Dim diff2 As TimeSpan = Now.Subtract(_lastSentTime)
      _lastSentTime = Now
      Dim itm As ListViewItem = Me.ListViewSendPackets.Items.Insert(0, Me.ListViewSendPackets.Items.Count)
      itm.SubItems.Add(siData.Replace(vbNullChar, "").Trim.Length)
      itm.SubItems.Add(diff2.TotalMilliseconds)
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
    _sentPacketList.Clear()
    _receivedPacketList.Clear()
    _receivedintermediatePacketList.Clear()
    _minRoundTripTime = Double.MaxValue
    _maxRoundTripTime = Double.MinValue
    _meanRoundTripTime = 0
    _sentPackets = 0
    _receivedPackets = 0
    _receivedIntermediatePackets = 0
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

  Private Sub ProcessCommand(sData As String)
    Try
      If Len(Trim(sData)) = 0 Then Exit Sub
      If _dictionaryPackets.ContainsKey(sData) Then
        Dim packet As TestPacket = _dictionaryPackets(sData)
        packet.ReceiveTime = Now
        packet.data = System.Text.Encoding.UTF8.GetBytes(sData) ' biData'packet.data = biData
        packet.RoundTripCompleted = True
        _receivedPacketList.Add(packet)
        AddReceivePacket(packet)
        _receivedPackets += 1
      Else
        Dim packet As New TestPacket
        packet.ReceiveTime = Now
        packet.data = System.Text.Encoding.UTF8.GetBytes(sData) ' biData
        packet.Text = sData
        packet.RoundTripCompleted = True
        _receivedPacketList.Add(packet)
        AddReceivePacket(packet)
      End If

      UpdateGUI()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ProcessIntermediateCommand(sData As String)
    Try
      If Len(Trim(sData)) = 0 Then Exit Sub
      If _dictionaryPackets.ContainsKey(sData) Then
        Dim packet As TestPacket = _dictionaryPackets(sData)
        packet.ReceiveIntermediateTime = Now
        'packet.data = System.Text.Encoding.UTF8.GetBytes(sData) ' biData'packet.data = biData
        packet.HalfTripCompleted = True
        _receivedintermediatePacketList.Add(packet)
        'AddReceivePacket(packet)
        _receivedIntermediatePackets += 1
      Else
        Dim packet As New TestPacket
        packet.ReceiveTime = Now
        packet.data = System.Text.Encoding.UTF8.GetBytes(sData) ' biData
        packet.Text = sData
        packet.HalfTripCompleted = True
        _receivedintermediatePacketList.Add(packet)
        'AddReceivePacket(packet)
      End If
      UpdateGUI()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ShowAllPackets()
    Try
      Dim lastPacket As TestPacket = Nothing
      Me.ListViewReceivePackets.Items.Clear()
      Me.ListViewSendPackets.Items.Clear()

      For Each packet As TestPacket In _sentPacketList
        _lastReceiveTime = packet.ReceiveTime

        Dim itm As ListViewItem = Me.ListViewSendPackets.Items.Insert(0, Me.ListViewSendPackets.Items.Count)
        'itm.SubItems.Add(packet.SentTime.ToString)

        If Not lastPacket Is Nothing Then
          Dim diff2 As TimeSpan = packet.SentTime.Subtract(lastPacket.SentTime)
          itm.SubItems.Add(diff2.TotalMilliseconds)
        Else
          itm.SubItems.Add("")
        End If
        lastPacket = packet
        itm.SubItems.Add(packet.data.Length)
        itm.SubItems.Add(packet.Text)
      Next

      lastPacket = Nothing
      For Each packet As TestPacket In _receivedPacketList
        Dim diff As TimeSpan = packet.ReceiveTime.Subtract(packet.SentTime)
        _lastReceiveTime = packet.ReceiveTime

        Dim itm As ListViewItem = Me.ListViewReceivePackets.Items.Insert(0, Me.ListViewReceivePackets.Items.Count)
        itm.SubItems.Add(diff.TotalMilliseconds)

        If Not lastPacket Is Nothing Then
          Dim diff2 As TimeSpan = packet.ReceiveTime.Subtract(lastPacket.ReceiveTime)
          itm.SubItems.Add(diff2.TotalMilliseconds)
        Else
          itm.SubItems.Add("")
        End If
        lastPacket = packet
        itm.SubItems.Add(packet.data.Length)
        itm.SubItems.Add(packet.Text)
      Next
    Catch ex As Exception

    End Try
  End Sub



  Private incommingData As String = ""
  Private Sub _tcpSender_ReceivedDataBytes(ByRef sender As TCPSender, biData() As Byte, endPoint As IPEndPoint) Handles _tcpSender.ReceivedDataBytes
    '_receivedPackets += 1
    'Try
    '  Dim sData As String = System.Text.Encoding.ASCII.GetString(biData)

    '  incommingData = incommingData & sData

    '  While incommingData.Contains(vbNullChar)
    '    Dim index As Integer = incommingData.IndexOf(vbNullChar)
    '    ProcessCommand(incommingData.Substring(0, index))
    '    incommingData = incommingData.Substring(index + 1)
    '  End While
    'Catch ex As Exception

    'End Try
  End Sub

  Private Sub _tcpSender_ReceivedData(ByRef sender As TCPSender, siData As String, endPoint As IPEndPoint) Handles _tcpSender.ReceivedData

    Try
      incommingData = incommingData & siData

      While incommingData.Contains(vbNullChar)
        Dim index As Integer = incommingData.IndexOf(vbNullChar)
        ProcessCommand(incommingData.Substring(0, index))
        incommingData = incommingData.Substring(index + 1)
      End While
    Catch ex As Exception

    End Try
  End Sub

  Private _sentPacketList As New List(Of TestPacket)
  Private _receivedintermediatePacketList As New List(Of TestPacket)
  Private _receivedPacketList As New List(Of TestPacket)

  Private _incommingIntermediateData As String = ""



  Private messagesLock As New Object
  Private Sub _tcpReceiver_DataReceiveBytes(ByRef sender As TCPReceiver, biData() As Byte) Handles _tcpReceiver.DataReceiveBytes
    Try

      SyncLock messagesLock
        If Me.CheckBoxRelayData.Checked Then
          _tcpReceiver.send(biData)
        End If

        _incommingIntermediateData = _incommingIntermediateData & System.Text.Encoding.UTF8.GetString(biData)

        While _incommingIntermediateData.Contains(vbNullChar)
          Dim index As Integer = _incommingIntermediateData.IndexOf(vbNullChar)
          ProcessIntermediateCommand(_incommingIntermediateData.Substring(0, index))
          _incommingIntermediateData = _incommingIntermediateData.Substring(index + 1)
        End While

      End SyncLock

    Catch ex As Exception

    End Try
  End Sub

  Private _minRoundTripTime As Double = Double.MaxValue
  Private _maxRoundTripTime As Double = Double.MinValue
  Private _meanRoundTripTime As Double = 0
  Private _lastReceiveTime As Date

  Private Sub AddSentPacket(packet As TestPacket, Optional force As Boolean = False)
    Try

      Me.Invoke(Sub()

                  Dim diff2 As TimeSpan = packet.SentTime.Subtract(_lastSentTime)
                  _lastSentTime = packet.SentTime
                  If Me.CheckBoxShowPackets.Checked Or force Then
                    Dim itm As ListViewItem = Me.ListViewSendPackets.Items.Insert(0, Me.ListViewReceivePackets.Items.Count)
                    itm.SubItems.Add(packet.SentTime.ToString)
                    itm.SubItems.Add(diff2.TotalMilliseconds)
                    itm.SubItems.Add(packet.data.Length)
                    itm.SubItems.Add(packet.Text)

                  End If

                  Me.LabelReceiverDataRate.Text = "Mean time " & _meanRoundTripTime & " (" & _minRoundTripTime & " to " & _maxRoundTripTime & ")"
                End Sub)
    Catch ex As Exception

    End Try
  End Sub

  Private Sub AddReceivePacket(packet As TestPacket, Optional force As Boolean = False)
    Try

      Me.Invoke(Sub()
                  Dim diff As TimeSpan = packet.ReceiveTime.Subtract(packet.SentTime)
                  Dim diff2 As TimeSpan = packet.ReceiveTime.Subtract(_lastReceiveTime)
                  _lastReceiveTime = packet.ReceiveTime
                  If Me.CheckBoxShowPackets.Checked Or force Then
                    Dim itm As ListViewItem = Me.ListViewReceivePackets.Items.Insert(0, Me.ListViewReceivePackets.Items.Count)
                    itm.SubItems.Add(diff.TotalMilliseconds)
                    itm.SubItems.Add(diff2.TotalMilliseconds)
                    itm.SubItems.Add(packet.data.Length)
                    itm.SubItems.Add(packet.Text)
                  End If
                  _minRoundTripTime = Math.Min(_minRoundTripTime, diff.TotalMilliseconds)
                  _maxRoundTripTime = Math.Max(_maxRoundTripTime, diff.TotalMilliseconds)
                  _meanRoundTripTime = (_meanRoundTripTime * (_receivedPacketList.Count - 1) + diff.TotalMilliseconds) / _receivedPacketList.Count

                  Me.LabelReceiverDataRate.Text = "Mean time " & _meanRoundTripTime & " (" & _minRoundTripTime & " to " & _maxRoundTripTime & ")"
                End Sub)
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _tcpReceiver_ActivityIncoming(ByRef sender As TCPReceiver) Handles _tcpReceiver.ActivityIncoming
    Me.UpdateGUI()
  End Sub

  Private Sub ButtonSendManualText_Click(sender As Object, e As EventArgs) Handles ButtonSendManualText.Click
    Dim packet As New TestPacket
    'packet.Text = _lastPacketSent & " This is a test packet"
    packet.Text = _lastPacketSent & ":" & Me.TextBoxManualText.Text
    Dim padding As Integer = Me.NumericUpDownMaxPacketSize.Value - packet.Text.Length


    packet.Text = packet.Text & New String(CStr(_lastPacketSent Mod 10), Math.Max(0, padding - 1))

    packet.Text = packet.Text & ":"
    packet.SentTime = Now
    packet.data = System.Text.Encoding.UTF8.GetBytes(packet.Text)

    _tcpSender.SendData(packet.Text & vbNullChar)
    _lastPacketSent += 1
    _dictionaryPackets.Add(packet.Text, packet)
    _sentPacketList.Add(packet)
  End Sub

  Private Sub SendPacket(siText As String)

    Dim packet As New TestPacket
    'packet.Text = _lastPacketSent & " This is a test packet"
    packet.Text = _lastPacketSent & ":" & siText & vbNullChar
    packet.data = System.Text.Encoding.UTF8.GetBytes(packet.Text)
    packet.SentTime = Now

    _tcpSender.SendData(packet.Text)
    _lastPacketSent += 1
    _dictionaryPackets.Add(packet.Text, packet)

    _sentPacketList.Add(packet)
  End Sub

  Private Sub CheckBoxSendData_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSendData.CheckedChanged

  End Sub

  Private Sub ButtonUpdateData_Click(sender As Object, e As EventArgs) Handles ButtonUpdateData.Click
    Me.ShowAllPackets()
  End Sub

  Private Sub _tcpReceiver_NewConnection(sender As TCPReceiver, client As TcpClient) Handles _tcpReceiver.NewConnection
    Try
      Debug.Print("New connection")
    Catch ex As Exception

    End Try
  End Sub
End Class
