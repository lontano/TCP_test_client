Public Class TimingMaster
  Public Shared SW As New Stopwatch
  Public Shared ReadOnly Property CurrentTime As Double
    Get
      If SW Is Nothing Then SW = New Stopwatch
      If SW.IsRunning = False Then SW.Start()
      Return SW.ElapsedTicks / TimeSpan.TicksPerMillisecond
    End Get
  End Property
End Class
