Imports System.IO
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Module MSerialize

  Public Function SerializeObjectToFile(ByVal siFile As String, ByRef CiObject As Object, ByVal biCompress As Boolean) As Boolean

    Dim bRes As Boolean = False
    Try
      Dim sRes As String = SerializeObjectToString(CiObject, biCompress)
      If sRes <> "" Then
        Dim myFileStream As FileStream = File.Create(siFile)
        Dim bytes() As Byte
        bytes = System.Text.Encoding.UTF8.GetBytes(sRes)
        myFileStream.Write(bytes, 0, bytes.Length)
        myFileStream.Flush()
        myFileStream.Close()
      Else
        Try
          Dim xs As New XmlSerializer(CiObject.GetType)
          Using fs As New System.IO.FileStream(siFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            xs.Serialize(fs, CiObject)
          End Using
        Catch generatedExceptionName As Exception
          Throw
        End Try
      End If
    Catch ex As Exception
      Debug.Print(ex.ToString)
    End Try
    Return bRes
  End Function

  Public Function SerializeObjectToString(ByRef CiObject As Object, ByVal biCompress As Boolean) As String
    Dim sRes As String = ""
    Try
      Dim sr As New IO.StringWriter()
      Dim serializer As New XmlSerializer(CiObject.GetType)
      serializer.Serialize(sr, CiObject)
      sRes = sr.ToString

    Catch ex As Exception
      Debug.Print(ex.ToString)
    End Try
    Return sRes
  End Function

  Public Function DesserializeObjectFromFile(ByVal siFile As String, ByRef CoObject As Object, ByVal biUnCompress As Boolean) As Boolean
    Dim bRes As Boolean = False
    Try
      If File.Exists(siFile) Then
        Dim myFileStream As FileStream = File.OpenRead(siFile)
        Dim bytes(myFileStream.Length - 1) As Byte
        myFileStream.Read(bytes, 0, myFileStream.Length)
        Dim sRes As String
        sRes = System.Text.Encoding.UTF8.GetString(bytes)
        DesserializeObjectFromString(sRes, CoObject, biUnCompress)
        myFileStream.Close()
        bRes = True
      End If
    Catch ex As Exception
    End Try
    Return bRes
  End Function

  Public Function DesserializeObjectFromString(ByVal siString As String, ByRef CoObject As Object, ByVal biUnCompress As Boolean) As Boolean
    Dim bRes As Boolean = False
    Dim sRead As String = siString
    Try
      If sRead.Contains(vbNullChar) Then
        sRead = siString.Replace(vbNullChar, "")
      Else
        sRead = siString
      End If

      Dim sr As New IO.StringReader(sRead)
      Dim deserializer As New XmlSerializer(CoObject.GetType)
      CoObject = deserializer.Deserialize(sr)
      bRes = True
    Catch ex As Exception
    End Try
    Return bRes
  End Function
End Module
