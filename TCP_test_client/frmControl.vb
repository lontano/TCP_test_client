Public Class frmControl
  Private _childForms As New List(Of Form)

  Private Sub ButtonNewSender_Click(sender As Object, e As EventArgs) Handles ButtonNewSender.Click
    Dim frm As New frmSender
    frm.Show(Me)
    _childForms.Add(frm)
  End Sub

  Private Sub ButtonNewReceiver_Click(sender As Object, e As EventArgs) Handles ButtonNewReceiver.Click
    Dim frm As New frmReceiver
    frm.Show(Me)
    _childForms.Add(frm)
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim frm As New frmTestTCP
    frm.Show(Me)
    _childForms.Add(frm)
  End Sub

  Private Sub ButtonUDPTest_Click(sender As Object, e As EventArgs) Handles ButtonUDPTest.Click
    Dim frm As New frmTestUDP
    frm.Show(Me)
    _childForms.Add(frm)
  End Sub

  Private Sub ButtonBridge_Click(sender As Object, e As EventArgs) Handles ButtonBridge.Click
    Dim frm As New frmBridge
    frm.Show(Me)
    _childForms.Add(frm)
  End Sub

  Private Sub ButtonSerialTest_Click(sender As Object, e As EventArgs) Handles ButtonSerialTest.Click
    Dim frm As New frmTestSerial
    frm.Show(Me)
    _childForms.Add(frm)
  End Sub
End Class