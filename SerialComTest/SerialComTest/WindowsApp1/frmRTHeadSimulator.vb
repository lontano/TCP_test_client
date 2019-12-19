Imports System.ComponentModel
Imports SerialTest.Connections

Public Class frmRTHeadSimulator
  Private _updating As Boolean = False
  Private _lastIndex As Integer = 0

  Private _currentFrame As New RTHeadPacket()

  Private Sub NumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownPan.ValueChanged, NumericUpDownZoom.ValueChanged, NumericUpDownTilt.ValueChanged, NumericUpDownFocus.ValueChanged, NumericUpDownIndex.ValueChanged
    Try
      If Not _updating Then
        _updating = True
        _currentFrame = New RTHeadPacket() With {.Pan = Me.NumericUpDownPan.Value, .Tilt = Me.NumericUpDownTilt.Value, .Zoom = Me.NumericUpDownZoom.Value, .Focus = Me.NumericUpDownFocus.Value, .Index = Me.NumericUpDownIndex.Value}

        HexFromPZTValues()
      End If
    Catch ex As Exception

    End Try
    _updating = False
  End Sub

  Private Sub TextBoxHexValues_TextChanged(sender As Object, e As EventArgs) Handles TextBoxHexValues.TextChanged
    Try
      If Not _updating Then
        _updating = True

      End If
    Catch ex As Exception

    End Try
    _updating = False
  End Sub

  Private Sub HexFromPZTValues()
    Try
      Dim bytes As New List(Of Byte)
      bytes.Add(4)
      bytes.Add(128 + NumericUpDownIndex.Value)
      For i As Integer = 2 To 0 Step -1
        bytes.Add(BitConverter.GetBytes(CInt(Me.NumericUpDownPan.Value))(i))
      Next
      For i As Integer = 2 To 0 Step -1
        bytes.Add(BitConverter.GetBytes(CInt(Me.NumericUpDownTilt.Value))(i))
      Next
      For i As Integer = 2 To 0 Step -1
        bytes.Add(BitConverter.GetBytes(CInt(Me.NumericUpDownZoom.Value))(i))
      Next
      For i As Integer = 2 To 0 Step -1
        bytes.Add(BitConverter.GetBytes(CInt(Me.NumericUpDownFocus.Value))(i))
      Next

      Dim crc As Integer = 0
      For Each val As Byte In bytes
        crc += val
      Next
      crc = crc Mod 256

      bytes.Add(BitConverter.GetBytes(CInt(crc))(0))

      Me.TextBoxHexValues.Text = CaptureMessage.ByteToHex(bytes.ToArray)

    Catch ex As Exception

    End Try
  End Sub


  Private Sub PZTValuesFromHex()
    Try

    Catch ex As Exception

    End Try
  End Sub



  Private Sub CheckBoxSimulateDevice_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSimulateDevice.CheckedChanged
    Me.Simulate(Me.CheckBoxSimulateDevice.Checked)
  End Sub

#Region "Simulate"
  Private WithEvents _simulator As System.ComponentModel.BackgroundWorker

  Private _udpSender As Connections.UDPSender
  Private _serialSender As Connections.SerialSender

  Private Sub Simulate(value As Boolean)
    Try
      If value Then

        If Me.CheckBoxSendToUDP.Checked Then
          _udpSender = New Connections.UDPSender
          _udpSender.Connect(Me.TextBoxUDPHost.Text, Me.NumericUpDownUDPPort.Value)
        End If
        If Me.CheckBoxSendToCOM.Checked Then
          _serialSender = New Connections.SerialSender
          _serialSender.Connect(Me.ComboBoxSendCOM.Text)
        End If
        _simulator = New System.ComponentModel.BackgroundWorker
        _simulator.RunWorkerAsync()
        _simulator.WorkerSupportsCancellation = True


      Else
        _serialSender.Disconnect()
        _serialSender = Nothing

        _simulator.CancelAsync()
        _simulator = Nothing
      End If
      Me.CheckBoxSendToUDP.Enabled = Not value
      Me.TextBoxUDPHost.Enabled = Not value
      Me.NumericUpDownUDPPort.Enabled = Not value
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _simulator_DoWork(sender As Object, e As DoWorkEventArgs) Handles _simulator.DoWork
    Try
      Dim startTime As Double = TimingMaster.CurrentTime
      Dim lastIndex As UInt32 = 0
      Dim sw As New Stopwatch()
      sw.Start()
      Dim aux As New List(Of Double)
      While Not _simulator Is Nothing AndAlso Not _simulator.CancellationPending
        Dim currentTime As Double = TimingMaster.CurrentTime
        Dim index As Integer = currentTime \ Me.NumericUpDownSimulationPeriod.Value
        If index <> lastIndex Then
          lastIndex = index
          Me.SendCurrentValue()
          Me.DoSwing()
          aux.Add(currentTime)
        End If
        'Threading.Thread.Sleep(1)
      End While
    Catch ex As Exception

    End Try
  End Sub

  Private Sub SendCurrentValue()
    Try
      Dim msg(_currentFrame.Bytes.Length) As Byte
      Buffer.BlockCopy(_currentFrame.Bytes, 0, msg, 0, _currentFrame.Bytes.Count)
      _currentFrame.Index = (_currentFrame.Index + 1) Mod 16
      If Me.CheckBoxSendToUDP.Checked Then
        _udpSender.SendData(_currentFrame.Bytes)
      End If
      If Me.CheckBoxSendToCOM.Checked Then
        _serialSender.SendData(_currentFrame.Bytes)
      End If

    Catch ex As Exception

    End Try
  End Sub

  Private Sub DoSwing()
    Try
      _updating = True
      Me.Invoke(Sub()
                  Me.NumericUpDownIndex.Value = (Me.NumericUpDownIndex.Value + 1) Mod 16
                  If Me.CheckBoxSwingPan.Checked Then SwingValue(Me.NumericUpDownPan)
                  If Me.CheckBoxSwingTilt.Checked Then SwingValue(Me.NumericUpDownTilt)
                  If Me.CheckBoxSwingZoom.Checked Then SwingValue(Me.NumericUpDownZoom)
                  If Me.CheckBoxSwingFocus.Checked Then SwingValue(Me.NumericUpDownFocus)

                End Sub)
    Catch ex As Exception

    End Try
    _updating = False
  End Sub

  Private Sub SwingValue(numUpDown As NumericUpDown)
    Try
      Dim angle As Double
      If Not Double.TryParse(numUpDown.Tag, angle) Then
        angle = 0
      End If
      angle += 0.005
      numUpDown.Value = ((numUpDown.Maximum + numUpDown.Minimum) + (numUpDown.Maximum - numUpDown.Minimum) / 2) * Math.Sin(angle)
      numUpDown.Tag = angle
    Catch ex As Exception

    End Try
  End Sub

#End Region

#Region "Data arrival"
  Private WithEvents _udpReceiver As Connections.UDPReceiver

  Private Sub _udpReceiver_DataReceiveBytes(ByRef sender As UDPReceiver, ByRef biData() As Byte) Handles _udpReceiver.DataReceiveBytes
    Try
      _rtHeadPacketFactory.AddBytes(biData)
    Catch ex As Exception
    End Try
  End Sub

  Private Sub CheckBoxReceiveFromudp_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxReceiveFromUDP.CheckedChanged
    Try
      If Me.CheckBoxReceiveFromUDP.Checked Then
        If Not _udpReceiver Is Nothing Then
          _udpReceiver.Disconnect()
          _udpReceiver = Nothing
        End If
        _udpReceiver = New UDPReceiver
        _udpReceiver.Listen(Me.NumericUpDownUDPReceivePort.Value)
      Else
        If Not _udpReceiver Is Nothing Then
          _udpReceiver.Disconnect()
          _udpReceiver = Nothing
        End If
      End If
      Me.NumericUpDownUDPReceivePort.Enabled = Not Me.CheckBoxReceiveFromUDP.Checked
    Catch ex As Exception
      MsgBox(ex.ToString)
    End Try
  End Sub

  Private WithEvents _serialReceiver As minimalCOMlistener

  Private Sub _serialReceiver_DataReceiveBytes(ByRef sender As Object, ByRef biData() As Byte) Handles _serialReceiver.DataReceiveBytes
    Try
      _rtHeadPacketFactory.AddBytes(biData)
    Catch ex As Exception
    End Try
  End Sub

  Private Sub CheckBoxReceiveFromserial_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxReceiveFromCOMPort.CheckedChanged
    Try
      If Me.CheckBoxReceiveFromCOMPort.Checked Then
        If Not _serialReceiver Is Nothing Then
          _serialReceiver.Disconnect()
          _serialReceiver = Nothing
        End If
        _serialReceiver = New minimalCOMlistener
        _serialReceiver.Connect(Me.ComboBoxComPort.Text)
      Else
        If Not _serialReceiver Is Nothing Then
          _serialReceiver.Disconnect()
          _serialReceiver = Nothing
        End If
      End If
      Me.ComboBoxComPort.Enabled = Not Me.CheckBoxReceiveFromCOMPort.Checked
    Catch ex As Exception
      MsgBox(ex.ToString)
    End Try
  End Sub

#End Region

#Region "Data analysis"
  Private WithEvents _rtHeadPacketFactory As New RTHeadPacketFactory()

  Private Sub TimerPacketFactory_Tick(sender As Object, e As EventArgs) Handles TimerPacketFactory.Tick
    Try
      _rtHeadPacketFactory.AnalyzePackets()
      Me.LabelPackerFactoryPackets.Text = _rtHeadPacketFactory.DetectedPackets.Count
      Me.LabelPackerFactoryBytesProcessed.Text = _rtHeadPacketFactory._processedBytes
      Me.LabelPackerFactoryBytesDiscarded.Text = _rtHeadPacketFactory._discardedBytes
      Me.LabelPackerFactoryNonConsecutivePackets.Text = _rtHeadPacketFactory._packetsOutOfOrder
      Me.LabelPackerFactoryTimingMean.Text = Strings.Format(_rtHeadPacketFactory._timingMean, "0.00000") & " (" & Strings.Format(_rtHeadPacketFactory._timingMin, "0.0") & " to " & Strings.Format(_rtHeadPacketFactory._timingMax, "0.0") & ")"
      Me.LabelPackerFactoryTimingStdDev.Text = Strings.Format(_rtHeadPacketFactory._timingStdDev, "0.0000")
      Me.LabelPacketFactoryPacketsPerSecond.Text = Strings.Format(_rtHeadPacketFactory._packetsPerSecond, "0.0000") & " " & Strings.Format(_rtHeadPacketFactory._bytesPerSecond, "0.0000") & " Bps"

      If _rtHeadPacketFactory.LastDetectedPacket Is Nothing Then
        Me.LabelPacketIndex.Text = ""
        Me.LabelPacketPan.Text = ""
        Me.LabelPacketTilt.Text = ""
        Me.LabelPacketZoom.Text = ""
        Me.LabelPacketFocus.Text = ""
      Else
        Me.LabelPacketIndex.Text = _rtHeadPacketFactory.LastDetectedPacket.Index
        Me.LabelPacketPan.Text = _rtHeadPacketFactory.LastDetectedPacket.Pan
        Me.LabelPacketTilt.Text = _rtHeadPacketFactory.LastDetectedPacket.Tilt
        Me.LabelPacketZoom.Text = _rtHeadPacketFactory.LastDetectedPacket.Zoom
        Me.LabelPacketFocus.Text = _rtHeadPacketFactory.LastDetectedPacket.Focus
      End If
      If Me.CheckBoxPacketListAutoUpdate.Checked Then
        ShowReceivedPackets()
      End If
      If Me.CheckBoxTimingAutoUpdate.Checked Then
        ShowTiming()
      End If
    Catch ex As Exception

    End Try

  End Sub

  Private Sub UpdateReceivedPacketsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateReceivedPacketsToolStripMenuItem.Click
    ShowReceivedPackets()
  End Sub

  Private _warningCount As Integer = 0
  Private Sub ShowReceivedPackets()
    Try
      Me.Cursor = Cursors.WaitCursor
      Me.ListViewReceivedPackets.BeginUpdate()

      For i As Integer = Me.ListViewReceivedPackets.Items.Count To _rtHeadPacketFactory.DetectedPackets.Count - 1

        Dim diff As Double = 0
        Dim WarningText As String = ""
        If i >= 1 Then
          diff = _rtHeadPacketFactory.DetectedPackets(i).TimeStamp - _rtHeadPacketFactory.DetectedPackets(i - 1).TimeStamp
          If _rtHeadPacketFactory.DetectedPackets(i).Index <> (_rtHeadPacketFactory.DetectedPackets(i - 1).Index + 1) Mod 16 Then
            WarningText = "<<"
          End If
          If diff < 5 Or diff > 14 Then
            WarningText = WarningText & " >>"
          End If
          If WarningText <> "" Then _warningCount += 1
        End If


        Dim itm As ListViewItem = Me.ListViewReceivedPackets.Items.Add(i.ToString)
        itm.SubItems.Add(_rtHeadPacketFactory.DetectedPackets(i).Index)
        itm.SubItems.Add(WarningText)
        itm.SubItems.Add(Strings.Format(diff, "0.000"))
        itm.SubItems.Add(_rtHeadPacketFactory.DetectedPackets(i).Pan)
        itm.SubItems.Add(_rtHeadPacketFactory.DetectedPackets(i).Tilt)
        itm.SubItems.Add(_rtHeadPacketFactory.DetectedPackets(i).Zoom)
        itm.SubItems.Add(_rtHeadPacketFactory.DetectedPackets(i).Focus)
        itm.SubItems.Add(_rtHeadPacketFactory.DetectedPackets(i).ToString)
      Next

      Select Case _warningCount
        Case 0
          Me.LabelWarnings.Text = "No warnings"
        Case 1
          Me.LabelWarnings.Text = "1 warning"
        Case Else
          Me.LabelWarnings.Text = _warningCount & " warnings"
      End Select

    Catch ex As Exception

    End Try
    Me.ListViewReceivedPackets.EndUpdate()
    Me.Cursor = Cursors.Default
  End Sub


  Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
    ShowTiming()
  End Sub

  Private Sub ShowTiming()
    Try
      _rtHeadPacketFactory.CreateAnalyzerCanvas(Me.PictureBoxTiming.Width, Me.PictureBoxTiming.Height)
    Catch ex As Exception

    End Try
  End Sub


  Private Sub _rtHeadPacketFactory_CanvasGenerated(sender As Object, bmp As Bitmap) Handles _rtHeadPacketFactory.CanvasGenerated
    Try
      Me.PictureBoxTiming.Image = bmp
    Catch ex As Exception

    End Try
  End Sub


  Private Sub GotoFirstWarningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoFirstWarningToolStripMenuItem.Click, ButtonWarningsFirst.Click
    FindWarningInListView(0, False, False)
  End Sub

  Private Sub NextWarningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextWarningToolStripMenuItem.Click, ButtonWarningsNext.Click
    If Me.ListViewReceivedPackets.SelectedIndices.Count > 0 Then
      FindWarningInListView(Me.ListViewReceivedPackets.SelectedIndices(0), True, False)
    Else
      FindWarningInListView(0, False, False)
    End If
  End Sub

  Private Sub PreviousWarningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviousWarningToolStripMenuItem.Click, ButtonWarningsPrevious.Click
    If Me.ListViewReceivedPackets.SelectedIndices.Count > 0 Then
      FindWarningInListView(Me.ListViewReceivedPackets.SelectedIndices(0), True, True)
    Else
      FindWarningInListView(Me.ListViewReceivedPackets.Items.Count - 1, False, True)
    End If
  End Sub

  Private Sub GotoLastWarningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoLastWarningToolStripMenuItem.Click, ButtonWarningsLast.Click
    FindWarningInListView(Me.ListViewReceivedPackets.Items.Count - 1, False, True)
  End Sub

  Private Sub FindWarningInListView(startIndex As Integer, jumpOne As Boolean, reverse As Boolean)
    Try
      Dim forStep As Integer = IIf(reverse, -1, 1)
      Dim forFirst As Integer = IIf(jumpOne, startIndex + forStep, startIndex)
      Dim forLast As Integer = IIf(reverse, 0, Me.ListViewReceivedPackets.Items.Count - 1)

      For i As Integer = forFirst To forLast Step forStep
        If Me.ListViewReceivedPackets.Items(i).SubItems(ColumnHeaderWarning.Index).Text <> "" Then
          Me.ListViewReceivedPackets.SelectedItems.Clear()
          Me.ListViewReceivedPackets.Items(i).Selected = True
          Me.ListViewReceivedPackets.EnsureVisible(i)
          Exit For
        End If
      Next
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ResetSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetSessionToolStripMenuItem.Click, ResetSessionToolStripMenuItem1.Click
    Try
      _warningCount = 0
      Me.ListViewReceivedPackets.Items.Clear()
      _rtHeadPacketFactory.Reset()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub frmRTHeadSimulator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'make application run on higher priority
    Dim myProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
    myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime

    Me.ComboBoxComPort.DataSource = System.IO.Ports.SerialPort.GetPortNames
    Me.ComboBoxSendCOM.DataSource = System.IO.Ports.SerialPort.GetPortNames

  End Sub


#End Region
End Class