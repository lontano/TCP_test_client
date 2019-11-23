Imports SerialTest
Imports WindowsApp1

Public Class frmMLR

  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try
      Dim aux As New List(Of String)(System.IO.Ports.SerialPort.GetPortNames)
      aux.Sort()
      Me.ComboBoxMLRCOMPort.DataSource = aux
      Me.ComboBoxMLRCOMPort.Text = aux(0)
    Catch ex As Exception

    End Try
  End Sub


  Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    Try

    Catch ex As Exception

    End Try
  End Sub

#Region "MLR"
  Private WithEvents _mlrControl As New MirandaLittleRedControl()

  Private Sub ButtonMLRStartStop_Click(sender As Object, e As EventArgs) Handles ButtonMLRStartStop.Click
    Try
      If _mlrControl Is Nothing Then Exit Sub
      If _mlrControl.Connected Then
        _mlrControl.Stop()
      Else
        _mlrControl.SerialPortName = Me.ComboBoxMLRCOMPort.Text
        _mlrControl.DisplayWindow = Me.RichTextBoxLog
        _mlrControl.Start(False)
      End If

      UpdateGUI()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ButtonGPI_Click(sender As Object, e As EventArgs) Handles ButtonGPI1.Click, ButtonGPI2.Click
    Try
      If _mlrControl Is Nothing Then Exit Sub
      If _mlrControl.Connected Then

      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ButtonGPO_Click(sender As Object, e As EventArgs) Handles ButtonGPO1.Click, ButtonGPO2.Click, ButtonGPO3.Click, ButtonGPO4.Click
    Try
      If _mlrControl Is Nothing Then Exit Sub
      If _mlrControl.Connected Then
        _mlrControl.ToggleGPO(sender.tag)
      End If
    Catch ex As Exception

    End Try
  End Sub


  Delegate Sub UpdateGUI_dellegate_definition()
  Dim UpdateGUI_Dellegate As New UpdateGUI_dellegate_definition(AddressOf UpdateGUI_action)
  Public Sub UpdateGUI()
    Try
      If Me.InvokeRequired Then
        Me.Invoke(UpdateGUI_Dellegate)
      Else
        UpdateGUI_action()
      End If
    Catch ex As Exception
    End Try
  End Sub

  Public Sub UpdateGUI_action()
    Try
      If Not _mlrControl Is Nothing Then
        If _mlrControl.Connected Then
          Me.ButtonMLRStartStop.Text = "Stop"
        Else
          Me.ButtonMLRStartStop.Text = "Start"
        End If
      End If

      Dim colorOn As Color = Color.LightGreen
      Dim colorOff As Color = Color.LightSalmon

      Me.ButtonGPI1.BackColor = IIf(_mlrControl.GetGPI(1), colorOn, colorOff)
      Me.ButtonGPI2.BackColor = IIf(_mlrControl.GetGPI(2), colorOn, colorOff)

      Me.ButtonGPO1.BackColor = IIf(_mlrControl.GetGPO(1), colorOn, colorOff)
      Me.ButtonGPO2.BackColor = IIf(_mlrControl.GetGPO(2), colorOn, colorOff)
      Me.ButtonGPO3.BackColor = IIf(_mlrControl.GetGPO(3), colorOn, colorOff)
      Me.ButtonGPO4.BackColor = IIf(_mlrControl.GetGPO(4), colorOn, colorOff)

      Me.LabelGPIState.Text = _mlrControl.GPIStates
      Me.LabelGPOState.Text = _mlrControl.GPoStates

    Catch ex As Exception

    End Try
  End Sub

  Private Sub ButtonStreamStart_Click(sender As Object, e As EventArgs) Handles ButtonStreamStart.Click
    If _mlrControl Is Nothing Then Exit Sub
    If _mlrControl.Connected Then
      _mlrControl.SendCommand(MirandaLittleRedControl.eCommandType.StartContinuousReport)
    End If
    UpdateGUI()
  End Sub

  Private Sub ButtonStreamStop_Click(sender As Object, e As EventArgs) Handles ButtonStreamStop.Click
    If _mlrControl Is Nothing Then Exit Sub
    If _mlrControl.Connected Then
      _mlrControl.SendCommand(MirandaLittleRedControl.eCommandType.StopContinuousReport)
    End If
    UpdateGUI()
  End Sub

  Private Sub _mlrControl_GPI_State_Changed(sender As MirandaLittleRedControl, index As Integer, value As Boolean) Handles _mlrControl.GPI_State_Changed
    UpdateGUI()
  End Sub

  Private Sub _mlrControl_GPO_State_Changed(sender As MirandaLittleRedControl, index As Integer, value As Boolean) Handles _mlrControl.GPO_State_Changed
    UpdateGUI()
  End Sub

  Private Sub NumericUpDownGPIState_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownGPIState.ValueChanged
    If _mlrControl Is Nothing Then Exit Sub
    _mlrControl.Set_GPIStates(Me.NumericUpDownGPIState.Value)
    UpdateGUI()
  End Sub

  Private Sub NumericUpDownGPOState_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownGPOState.ValueChanged
    If _mlrControl Is Nothing Then Exit Sub
    _mlrControl.Set_GPOStates(Me.NumericUpDownGPOState.Value)
    UpdateGUI()
  End Sub

#End Region
End Class