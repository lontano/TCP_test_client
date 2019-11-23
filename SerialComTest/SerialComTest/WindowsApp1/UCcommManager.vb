Imports WindowsApp1

Public Class UCcommManager
  Private WithEvents _commManager As CommManager = New CommManager

  Public Property commManager As CommManager
    Get
      Return _commManager
    End Get
    Set(value As CommManager)
      _commManager = value
    End Set
  End Property

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    Dim portNames As New List(Of String)(System.IO.Ports.SerialPort.GetPortNames)
    portNames.Sort()
    Me.ComboBoxSerialPort.DataSource = System.IO.Ports.SerialPort.GetPortNames

    Me.ComboBoxDataBits.Items.Clear()
    Me.ComboBoxDataBits.Items.Add(5)
    Me.ComboBoxDataBits.Items.Add(6)
    Me.ComboBoxDataBits.Items.Add(7)
    Me.ComboBoxDataBits.Items.Add(8)
    Me.ComboBoxDataBits.SelectedItem = 8

    Me.ComboBoxParity.Items.Clear()
    Me.ComboBoxParity.Items.Add(IO.Ports.Parity.None)
    Me.ComboBoxParity.Items.Add(IO.Ports.Parity.Even)
    Me.ComboBoxParity.Items.Add(IO.Ports.Parity.Odd)
    Me.ComboBoxParity.Items.Add(IO.Ports.Parity.Mark)
    Me.ComboBoxParity.Items.Add(IO.Ports.Parity.Space)
    Me.ComboBoxParity.SelectedItem = IO.Ports.Parity.None

    Me.ComboBoxStopBits.Items.Clear()
    'Me.ComboBoxStopBits.Items.Add(IO.Ports.StopBits.None)
    Me.ComboBoxStopBits.Items.Add(IO.Ports.StopBits.One)
    Me.ComboBoxStopBits.Items.Add(IO.Ports.StopBits.OnePointFive)
    Me.ComboBoxStopBits.Items.Add(IO.Ports.StopBits.Two)
    Me.ComboBoxStopBits.SelectedItem = IO.Ports.StopBits.One


  End Sub

  Public Event SocketDisconnected(sender As CommManager)

  Private Sub ButtonStartStop_Click(sender As Object, e As EventArgs) Handles ButtonStartStop.Click
    Try
      If Not _commManager Is Nothing AndAlso _commManager.Connected Then
        _commManager.ClosePort()
        RaiseEvent SocketDisconnected(_commManager)
        ButtonStartStop.Text = "Start"
      Else
        _commManager = New CommManager(Me.NumericUpDownBaudRate.Value, Me.ComboBoxParity.SelectedItem, Me.ComboBoxStopBits.SelectedItem, Me.ComboBoxDataBits.SelectedItem, Me.ComboBoxSerialPort.Text, Me.RichTextBoxLog)
        _commManager.CurrentTransmissionType = CommManager.TransmissionType.Hex
        _commManager.ExpectedPacketSize = Me.NumericUpDownExpectedPacketSize.Value
        _commManager.AsyncSend = Me.CheckBoxAsyncSend.Checked
        _commManager.GroupPackets = Me.NumericUpDownGroupPackets.Value
        If _commManager.OpenPort() Then
          ButtonStartStop.Text = "Stop"
          RaiseEvent SocketConnected(_commManager)
        Else
          MsgBox("Unable to open port " & Me.ComboBoxSerialPort.Text & " " & _commManager.LastErrorString)
          ButtonStartStop.Text = "Start"
        End If
      End If
    Catch ex As Exception
      MsgBox(ex.ToString)
      ButtonStartStop.Text = "Start"
    End Try
  End Sub

  Private Sub ButtonSendRandomData_Click(sender As Object, e As EventArgs)
    Try
      If Not _commManager Is Nothing AndAlso _commManager.Connected Then
        _commManager.SendData(System.Text.Encoding.ASCII.GetBytes("this is some data " & Now.ToString))
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
    Try
      Me.RichTextBoxLog.Text = ""
    Catch ex As Exception

    End Try
  End Sub

  Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
    Try

    Catch ex As Exception

    End Try
  End Sub

  Public Event DataReceiveBytes(ByRef sender As CommManager, ByRef biData() As Byte)
  Private Sub _commManager_DataReceiveBytes(ByRef sender As CommManager, ByRef biData() As Byte) Handles _commManager.DataReceiveBytes
    RaiseEvent DataReceiveBytes(sender, biData)
  End Sub

  Public Event DataReceive(ByRef sender As CommManager, ByRef siData As String)
  Private Sub _commManager_DataReceive(ByRef sender As CommManager, siData As String) Handles _commManager.DataReceive
    RaiseEvent DataReceive(sender, siData)
  End Sub

  Public Event SocketConnected(sender As CommManager)
  Private Sub _commManager_SocketConnected(ByRef sender As CommManager) Handles _commManager.SocketConnected
    RaiseEvent SocketConnected(sender)
  End Sub

  Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
    SendText()
  End Sub

  Private Sub TextBoxSend_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSend.KeyDown
    Select Case e.KeyCode
      Case Keys.Enter
        SendText()
    End Select
  End Sub

  Private Sub SendText()
    _commManager.CurrentTransmissionType = CommManager.TransmissionType.Text
    _commManager.SendData(System.Text.Encoding.ASCII.GetBytes(Me.TextBoxSend.Text & IIf(Me.CheckBoxAppendCR.Checked, vbCr, "")))
  End Sub

  Private Sub CheckBoxAsyncSend_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAsyncSend.CheckedChanged
    _commManager.AsyncSend = Me.CheckBoxAsyncSend.Checked
  End Sub

  Private Sub NumericUpDownGroupPackets_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownGroupPackets.ValueChanged
    _commManager.GroupPackets = Me.NumericUpDownGroupPackets.Value
  End Sub

  Private Sub NumericUpDownExpectedPacketSize_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownExpectedPacketSize.ValueChanged
    _commManager.ExpectedPacketSize = Me.NumericUpDownGroupPackets.Value
  End Sub
End Class
