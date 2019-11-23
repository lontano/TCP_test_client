Public Class CaptureSession
  Public Name As String
  Public Description As String
  Public StartTime As Double
  Public CapturedMessages As New List(Of CaptureMessage)
  Public CaptureLog As String = ""

  Public Sub New()
  End Sub

  Public Sub New(name As String, description As String)
    Me.Name = name
    Me.Description = description
  End Sub


  Public Sub AddMessage(data() As Byte)
    Try
      Dim currentTime As Double = Now.Subtract(Date.MinValue).TotalMilliseconds
      If CapturedMessages.Count = 0 Then
        Me.StartTime = currentTime
        Me.CaptureLog = ""
      End If
      Me.CapturedMessages.Add(New CaptureMessage() With {.CaptureTime = currentTime, .TimeOffset = currentTime - Me.StartTime, .data = data})
      Me.CaptureLog = Me.CaptureLog & "Captured message " & Me.CapturedMessages.Count - 1 & " at offset " & Me.CapturedMessages.Last.TimeOffset & vbCrLf
    Catch ex As Exception
    End Try
  End Sub
End Class
