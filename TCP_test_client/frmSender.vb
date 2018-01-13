Imports TCP_test_client.Connections

Public Class frmSender
  Private WithEvents _tcpSender As Connections.TCPSender

  Private _lastPacketSent As Integer = 0

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If Not _tcpSender Is Nothing And Me.CheckBoxSendData.Checked Then
      _tcpSender.SendData(_lastPacketSent & " New text " & Now.ToString())
      _lastPacketSent += 1
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
        Me.LabelSenderState.Text = "Data sent " & Now.ToString
        Me.LabelSenderDataRate.Text = _tcpSender.DataRateCalculator.DataRateText & " " & _tcpSender.DataRateCalculator.TotalDataReceivedText
      End If
    End If
  End Sub

  Public Delegate Sub UpdateButtonsDelegate()
  Public Sub UpdateButtons()
    If Me.InvokeRequired Then
      Me.Invoke(New UpdateButtonsDelegate(AddressOf UpdateGUI))
    Else
      If Not _tcpSender Is Nothing Then
        If _tcpSender.Connected Then
          Me.ButtonSenderConnect.Text = "Disconnect"
          Me.ButtonSenderConnect.BackColor = Color.LightGreen
        Else
          Me.ButtonSenderConnect.Text = "Connect"
          Me.ButtonSenderConnect.BackColor = Color.LightSalmon

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

  Private Sub ButtonSenderConnect_Click(sender As Object, e As EventArgs) Handles ButtonSenderConnect.Click
    If _tcpSender Is Nothing Then
      _tcpSender = New Connections.TCPSender
      _tcpSender.Connect(Me.TextBoxSenderHost.Text, Me.NumericUpDownSenderHost.Value)
    Else
      _tcpSender.Disconnect()
      _tcpSender = Nothing
    End If
    UpdateButtons()
  End Sub

  Private Sub _tcpSender_SentData(ByRef sender As TCPSender, siData As String) Handles _tcpSender.SentData

    Dim itm As ListViewItem = Me.ListViewPackets.Items.Insert(0, Me.ListViewPackets.Items.Count)
    itm.SubItems.Add(Now.ToString)
    itm.SubItems.Add(siData.Length)
    itm.SubItems.Add(siData)
  End Sub

  Private Sub frmSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    AppNewAutosizeColumns(Me.ListViewPackets)
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

  Private Sub _tcpSender_ErrorEvent(CiException As Exception) Handles _tcpSender.ErrorEvent
    Static busy As Boolean = False
    If busy Then Exit Sub
    busy = True

    MsgBox(CiException.ToString)
    busy = False
  End Sub

  Private Sub NumericUpDownDataSendTime_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownDataSendTime.ValueChanged
    Me.Timer1.Interval = Me.NumericUpDownDataSendTime.Value
  End Sub
End Class
