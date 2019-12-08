Imports System.Text

Public Class CaptureMessage
  Public CaptureTime As Double
  Public TimeOffset As Double
  Public data() As Byte

  Public Overrides Function ToString() As String
    Return "Message offset " & Me.TimeOffset & " data length = " & data.Length & " bytes | data = " & CaptureMessage.ByteToHex(Me.data)
  End Function
  Public Shared Function HexToByte(ByVal msg As String) As Byte()
    Dim _msg As String
    If msg.Length Mod 2 = 0 Then
      'remove any spaces from the string
      _msg = msg
      _msg = msg.Replace(" ", "")
      'create a byte array the length of the
      'divided by 2 (Hex is 2 characters in length)
      Dim comBuffer As Byte() = New Byte(_msg.Length / 2 - 1) {}
      For i As Integer = 0 To _msg.Length - 1 Step 2
        comBuffer(i / 2) = CByte(Convert.ToByte(_msg.Substring(i, 2), 16))
      Next
      Return comBuffer
    Else
      _msg = "Invalid format"
      Return Nothing
    End If
  End Function
  Public Shared Function ByteToHex(ByVal comByte As Byte(), Optional numDigits As Integer = 0, Optional backwards As Boolean = False) As String
    'create a new StringBuilder object
    Dim builder As New StringBuilder(comByte.Length * 3)
    'loop through each byte in the array
    Dim digit As Integer = 0
    For Each data As Byte In comByte
      If numDigits = 0 Or digit < numDigits Then
        If Not backwards Then
          builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
        Else
          builder.Insert(0, Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
        End If
        digit += 1
      End If
      'convert the byte to a string and add to the stringbuilder
    Next
    'return the converted value
    Return builder.ToString().ToUpper()
  End Function
End Class
