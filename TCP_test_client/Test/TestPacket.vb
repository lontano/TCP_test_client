Public Class TestPacket
  Public Property data As Byte()
  Public Property Text As String
  Public Property SentTime As Date
  Public Property ReceiveIntermediateTime As Date
  Public Property ReceiveTime As Date
  Public Property HalfTripCompleted As Boolean
  Public Property RoundTripCompleted As Boolean
  Public Property TimeSinceLastPacket As Double
  Public Property SendTicks As Double
  Public Property ReceiveTicks As Double
  Public Property diffTime As Double
End Class
