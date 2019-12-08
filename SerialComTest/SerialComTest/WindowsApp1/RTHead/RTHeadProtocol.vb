Public Class RTHeadProtocol
  Public Property Pan As Integer = 0
  Public Property Tilt As Integer = 0
  Public Property Zoom As Integer = 0
  Public Property Focus As Integer = 0
  Public Property Index As Integer = 0

  Private _crc As Integer = 0
  Public ReadOnly Property CRC As Integer
    Get
      Return _crc
    End Get
  End Property

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
      If value.Length = 15 AndAlso value(0) = 4 Then
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

End Class
