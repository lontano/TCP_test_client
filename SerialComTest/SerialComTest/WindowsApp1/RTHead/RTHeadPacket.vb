Public Class RTHeadPacket
  Public Property Pan As Integer = 0
  Public Property Tilt As Integer = 0
  Public Property Zoom As Integer = 0
  Public Property Focus As Integer = 0
  Public Property Index As Integer = 0
  Public Property TimeStamp As Double = TimingMaster.CurrentTime

  Public Shared ReadOnly Property StartingByte As Byte = 4
  Public Shared ReadOnly Property ByteCount As Integer = 15
  Public Shared ReadOnly Property PacketTime As Double = 10

  Private _crc As Integer = 0
  Public ReadOnly Property CRC As Integer
    Get
      Return _crc
    End Get
  End Property

  Public Shared Function ComputeCRC(data() As Byte) As Integer
    Dim crc As Integer = 0
    Try
      crc = 0
      If data.Length >= RTHeadPacket.ByteCount - 2 Then
        For i As Integer = 0 To RTHeadPacket.ByteCount - 2
          crc += data(i)
        Next
      End If
      crc = crc Mod 256
    Catch ex As Exception
    End Try
    Return crc
  End Function

  Public Property Bytes() As Byte()
    Get
      Dim myBytes As New List(Of Byte)
      myBytes.Add(4)
      myBytes.Add(128 + Index)
      For i As Integer = 2 To 0 Step -1
        myBytes.Add(BitConverter.GetBytes(CInt(Me.Pan))(i))
      Next
      For i As Integer = 2 To 0 Step -1
        myBytes.Add(BitConverter.GetBytes(CInt(Me.Tilt))(i))
      Next
      For i As Integer = 2 To 0 Step -1
        myBytes.Add(BitConverter.GetBytes(CInt(Me.Zoom))(i))
      Next
      For i As Integer = 2 To 0 Step -1
        myBytes.Add(BitConverter.GetBytes(CInt(Me.Focus))(i))
      Next

      _crc = 0
      For Each val As Byte In myBytes
        _crc += val
      Next
      _crc = _crc Mod 256

      myBytes.Add(BitConverter.GetBytes(CInt(_crc))(0))

      Return myBytes.ToArray
    End Get
    Set(value As Byte())
      If value.Length >= 15 AndAlso value(0) = 4 Then
        Me.Index = value(1) Mod 128

        Dim myBytes As New List(Of Byte)

        myBytes = New List(Of Byte)({value(4), value(3), value(2), value(2)})
        Me.Pan = BitConverter.ToInt32(myBytes.ToArray, 0)

        myBytes = New List(Of Byte)({value(7), value(6), value(5), value(5)})
        Me.Tilt = BitConverter.ToInt32(myBytes.ToArray, 0)

        myBytes = New List(Of Byte)({value(10), value(9), value(8), value(8)})
        Me.Zoom = BitConverter.ToInt32(myBytes.ToArray, 0)

        myBytes = New List(Of Byte)({value(13), value(12), value(11), value(11)})
        Me.Focus = BitConverter.ToInt32(myBytes.ToArray, 0)

        myBytes = New List(Of Byte)({value(14), 0, 0, 0})
        _crc = BitConverter.ToInt32(myBytes.ToArray, 0)
      End If
    End Set
  End Property

  Public Sub New()

  End Sub

  Public Sub New(data() As Byte)
    Me.Bytes = data
  End Sub

  Public Shared Function GetPacket(data() As Byte) As RTHeadPacket
    Try
      'do we have enough data for a packet?
      If data.Length < RTHeadPacket.ByteCount Then Return Nothing
      'is the first byte correct?
      If data(0) <> RTHeadPacket.StartingByte Then Return Nothing

      Dim aux As New RTHeadPacket(data)
      'is the CRC right?
      If data(RTHeadPacket.ByteCount - 1) = RTHeadPacket.ComputeCRC(data) Then
        Return aux
      Else
        Return Nothing
      End If
    Catch ex As Exception
      Return Nothing
    End Try
  End Function

  Public Overrides Function ToString() As String
    Return MyBase.ToString & " " & Me.Index & " pan=" & Me.Pan & " tilt=" & Me.Tilt & " zoom=" & Me.Zoom & " focus=" & Me.Focus & " timeStamp=" & Strings.Format(Me.TimeStamp, "000")
  End Function
End Class
