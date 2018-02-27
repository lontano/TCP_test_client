Imports System.Net.Sockets
Imports TCP_test_client.Connections

Public Class frmReceiver
  Private WithEvents _tcpReceiver As Connections.TCPReceiver

  Public Delegate Sub UpdateGUIDelegate()
  Public Sub UpdateGUI()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateGUIDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpReceiver Is Nothing Then
        Me.LabelReceiverState.Text = "Data received " & Now.ToString
        Me.LabelReceiverDataRate.Text = _tcpReceiver.DataRateCalculator.DataRateText & " " & _tcpReceiver.DataRateCalculator.TotalDataReceivedText
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
      Dim itm As ListViewItem = Me.ListViewPackets.Items.Insert(0, Me.ListViewPackets.Items.Count)
      itm.SubItems.Add(Now.ToString)
      itm.SubItems.Add(siData.Length)
      itm.SubItems.Add(siData)
    End If
  End Sub

  Dim _lastPacket As String = ""
  Private Sub _tcpReceiver_DataReceive(ByRef sender As TCPReceiver, siData As String) Handles _tcpReceiver.DataReceive
    UpdatePacket(siData)
    UpdateGUI()
  End Sub


  Private Sub ButtonReceiverConnect_Click(sender As Object, e As EventArgs) Handles ButtonReceiverConnect.Click
    If _tcpReceiver Is Nothing Then
      _tcpReceiver = New Connections.TCPReceiver
      _tcpReceiver.Listen(Me.NumericUpDownReceiverPort.Value)

      My.Settings.ReceiverPort = Me.NumericUpDownReceiverPort.Value
      My.Settings.Save()
    Else
      _tcpReceiver.Disconnect()
      _tcpReceiver = Nothing
    End If
    UpdateButtons()
  End Sub

  Private Sub frmSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

  Private Sub _tcpReceiver_NewConnection(sender As TCPReceiver, client As TcpClient) Handles _tcpReceiver.NewConnection
    Try
      _numConnections += 1
      Me.LabelStatusLabel.Text = Now.ToString & vbCrLf & "#" & _numConnections & " New connection from " & client.Client.RemoteEndPoint.ToString()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub frmReceiver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    Try
      _tcpReceiver.Disconnect()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click

    Me.ListViewPackets.Items.Clear()
  End Sub
End Class
