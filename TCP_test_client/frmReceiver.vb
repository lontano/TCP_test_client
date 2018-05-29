Imports System.ComponentModel
Imports System.Net.Sockets
Imports TCP_test_client.Connections

Public Class frmReceiver
  Private WithEvents _tcpReceiver As Connections.TCPReceiver
  Private WithEvents _tcpReceiverForward As Connections.TCPReceiver

  Private WithEvents _forwardWorker As ComponentModel.BackgroundWorker
  Private _dataArrived As New Concurrent.ConcurrentQueue(Of Byte())

  Public Delegate Sub UpdateGUIDelegate()
  Public Sub UpdateGUI()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateGUIDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpReceiver Is Nothing Then
        Me.LabelReceiverState.Text = "Data received " & Now.ToString
        Me.LabelReceiverDataRate.Text = _tcpReceiver.DataRateCalculator.DataRateText & " " & _tcpReceiver.DataRateCalculator.TotalDataReceivedText
      End If
      If Not _tcpReceiverForward Is Nothing Then
        '  Me.LabelReceiverState.Text = "Data received " & Now.ToString
        '  Me.LabelReceiverDataRate.Text = _tcpReceiver.DataRateCalculator.DataRateText & " " & _tcpReceiver.DataRateCalculator.TotalDataReceivedText
      End If
    End If
  End Sub

  Public Delegate Sub UpdateButtonsDelegate()
  Public Sub UpdateButtons()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateButtonsDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpReceiver Is Nothing Then
        Me.ButtonReceiverConnect.Text = "Disconnect"
        Me.ButtonReceiverConnect.BackColor = Color.LightGreen
      Else
        Me.ButtonReceiverConnect.Text = "Connect"
        Me.ButtonReceiverConnect.BackColor = Color.LightSalmon
      End If

      Dim itm As ListViewItem = Me.ListViewPackets.Items.Insert(0, Me.ListViewPackets.Items.Count)
      itm.SubItems.Add(_lastPacket.Length)
      itm.SubItems.Add(Now.ToString)
      itm.SubItems.Add(_lastPacket)
    End If
  End Sub

  Public Delegate Sub UpdatePacketDelegate(data As String)
  Public Sub UpdatePacket(siData As String)
    If Me.InvokeRequired Then
      Me.Invoke(New UpdatePacketDelegate(AddressOf UpdatePacket), siData)
    Else
      Dim asAux() As String = siData.Split(vbNullChar)

      For Each sAux As String In asAux
        If sAux.Trim.Length > 0 Then
          Dim itm As ListViewItem = Me.ListViewPackets.Items.Insert(0, Me.ListViewPackets.Items.Count)
          itm.SubItems.Add(Now.ToString)
          itm.SubItems.Add(sAux.Length)
          itm.SubItems.Add(sAux)
        End If
      Next

    End If
  End Sub

  Dim _lastPacket As String = ""
  Private Sub _tcpReceiver_DataReceive(ByRef sender As TCPReceiver, siData As String) Handles _tcpReceiver.DataReceive
    UpdatePacket(siData)
    UpdateGUI()
  End Sub

  Private Sub _tcpReceiver_DataReceiveBytes(ByRef sender As TCPReceiver, biData() As Byte) Handles _tcpReceiver.DataReceiveBytes
    _dataArrived.Enqueue(biData)
  End Sub

  Private Sub ButtonReceiverConnect_Click(sender As Object, e As EventArgs) Handles ButtonReceiverConnect.Click
    Me.Connect(_tcpReceiver, Me.NumericUpDownReceiverPort.Value)
    Me.Connect(_tcpReceiverForward, Me.NumericUpDownReceiverPort.Value + 1)

    UpdateButtons()
  End Sub

  Private Sub Connect(ByRef tcp As TCPReceiver, port As Integer)
    If tcp Is Nothing Then
      tcp = New Connections.TCPReceiver
      tcp.Listen(port)

      'tcp.ForwardMessagesToOtherClients = Me.CheckBoxForwardMessages.Checked

      My.Settings.ReceiverPort = Me.NumericUpDownReceiverPort.Value
      My.Settings.Save()
    Else
      tcp.Disconnect()
      tcp = Nothing
    End If
  End Sub

  Private Sub frmSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    _forwardWorker = New ComponentModel.BackgroundWorker
    _forwardWorker.RunWorkerAsync()
    AppNewAutosizeColumns(Me.ListViewPackets)
    Me.NumericUpDownReceiverPort.Value = My.Settings.ReceiverPort
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

  Private _numConnections As Integer = 0
  Private _numConnectionsForward As Integer = 0

  Private Sub _tcpReceiver_NewConnection(sender As TCPReceiver, client As TcpClient) Handles _tcpReceiver.NewConnection
    Try
      _numConnections += 1
      Me.LabelStatus.Text = Now.ToString & vbCrLf & "#" & _numConnections & " New connection from " & client.Client.RemoteEndPoint.ToString()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _tcpReceiverForward_NewConnection(sender As TCPReceiver, client As TcpClient) Handles _tcpReceiverForward.NewConnection
    Try
      _numConnectionsForward += 1
      Me.LabelStatusForward.Text = Now.ToString & vbCrLf & "#" & _numConnectionsForward & " New connection from " & client.Client.RemoteEndPoint.ToString()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub frmReceiver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    Try
      _tcpReceiver.Disconnect()
      _tcpReceiverForward.Disconnect()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click

    Me.ListViewPackets.Items.Clear()
  End Sub

  Private Sub CheckBoxForwardMessages_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForwardMessages.CheckedChanged
    If Not _tcpReceiver Is Nothing Then
      _tcpReceiver.ForwardMessagesToOtherClients = Me.CheckBoxForwardMessages.Checked
    End If
  End Sub

  Private Sub _forwardWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _forwardWorker.DoWork
    Try
      While Not _forwardWorker.CancellationPending
        While _dataArrived.Count > 0

          Dim data() As Byte
          If _dataArrived.TryDequeue(data) Then
            If Me.CheckBoxForwardMessages.Checked And Not _tcpReceiverForward Is Nothing Then
              For i As Integer = 0 To 1000
                Dim a As Integer = i
              Next
              '_tcpReceiverForward.send(data)
            End If
          End If
        End While
        Threading.Thread.Sleep(5)
      End While
    Catch ex As Exception

    End Try
  End Sub
End Class
