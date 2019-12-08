Imports System.ComponentModel

Public Class frmRTHeadSimulator
  Private _updating As Boolean = False
  Private _lastIndex As Integer = 0

  Private _currentFrame As New RTHeadProtocol()

  Private Sub NumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownPan.ValueChanged, NumericUpDownZoom.ValueChanged, NumericUpDownTilt.ValueChanged, NumericUpDownFocus.ValueChanged, NumericUpDownIndex.ValueChanged
    Try
      If Not _updating Then
        _updating = True
        _currentFrame = New RTHeadProtocol() With {.Pan = Me.NumericUpDownPan.Value, .Tilt = Me.NumericUpDownTilt.Value, .Zoom = Me.NumericUpDownZoom.Value, .Focus = Me.NumericUpDownFocus.Value, .Index = Me.NumericUpDownIndex.Value}

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


  Private Sub Simulate(value As Boolean)
    Try
      If value Then

        If Me.CheckBoxSendToUDP.Checked Then
          _udpSender = New Connections.UDPSender
          _udpSender.Connect(Me.TextBoxUDPHost.Text, Me.NumericUpDownUDPPort.Value)
        End If

        _simulator = New System.ComponentModel.BackgroundWorker
        _simulator.RunWorkerAsync()
        _simulator.WorkerSupportsCancellation = True


      Else
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
      Dim startTime As Double = Now.Subtract(Date.MinValue).TotalMilliseconds
      Dim lastIndex As UInt32 = 0
      While Not _simulator Is Nothing AndAlso Not _simulator.CancellationPending
        Dim currentTime As Double = Now.Subtract(Date.MinValue).TotalMilliseconds - startTime
        Dim index As Integer = currentTime \ Me.NumericUpDownSimulationPeriod.Value
        If index <> lastIndex Then
          lastIndex = index
          Me.SendCurrentValue()
          Me.DoSwing()
        End If
      End While
    Catch ex As Exception

    End Try
  End Sub

  Private Sub SendCurrentValue()
    Try
      _currentFrame.Index = (_currentFrame.Index + 1) Mod 256
      If Me.CheckBoxSendToUDP.Checked Then
        Dim msg(_currentFrame.Bytes.Length) As Byte
        Buffer.BlockCopy(_currentFrame.Bytes, 0, msg, 0, _currentFrame.Bytes.Count)
        _udpSender.SendData(_currentFrame.Bytes)
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
End Class