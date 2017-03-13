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
End Class