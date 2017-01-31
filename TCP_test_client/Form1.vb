Public Class Form1
    Private _client As TCPCli
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _client = New TCPCli
        _client.Main()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not _client Is Nothing Then
            _client.SendData(Now.ToString())
        End If
    End Sub
End Class
