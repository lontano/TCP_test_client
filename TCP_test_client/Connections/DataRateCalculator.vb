Namespace Connections
  Public Class DataRateCalculator
    Private _data_size As New List(Of Integer)
    Private _data_time As New List(Of Date)
    Private _max_data_samples As Integer = 100

    Private _totalDataReceived As Double
    Public ReadOnly Property TotalDataReceived As Double
      Get
        Return _totalDataReceived
      End Get
    End Property

    Public ReadOnly Property TotalDataReceivedText As String
      Get
        Dim TheSize As ULong = Me.TotalDataReceived
        Dim SizeType As String = ""
        Dim DoubleBytes As Double

        Try
          Select Case TheSize
            Case Is >= 1099511627776
              DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
              Return FormatNumber(DoubleBytes, 2) & " TB"
            Case 1073741824 To 1099511627775
              DoubleBytes = CDbl(TheSize / 1073741824) 'GB
              Return FormatNumber(DoubleBytes, 2) & " GB"
            Case 1048576 To 1073741823
              DoubleBytes = CDbl(TheSize / 1048576) 'MB
              Return FormatNumber(DoubleBytes, 2) & " MB"
            Case 1024 To 1048575
              DoubleBytes = CDbl(TheSize / 1024) 'KB
              Return FormatNumber(DoubleBytes, 2) & " KB"
            Case 0 To 1023
              DoubleBytes = TheSize ' bytes
              Return FormatNumber(DoubleBytes, 2) & " Bytes"
            Case Else
              Return ""
          End Select
        Catch
          Return ""
        End Try
      End Get
    End Property

    Public Sub AddData(str As String)
      Try
        Dim size As Integer = System.Text.Encoding.UTF8.GetBytes(str).Length
        _totalDataReceived += size
        _data_size.Add(size)
        _data_time.Add(Now)
        While _data_size.Count > _max_data_samples
          _data_size.RemoveAt(0)
          _data_time.RemoveAt(0)
        End While
      Catch ex As Exception
      End Try
    End Sub

    Public Sub AddData(bytes() As Byte)
      Try
        _totalDataReceived += bytes.Length
        _data_size.Add(bytes.Length)
        _data_time.Add(Now)
        While _data_size.Count > _max_data_samples
          _data_size.RemoveAt(0)
          _data_time.RemoveAt(0)
        End While
      Catch ex As Exception
      End Try
    End Sub

    Public Sub AddData(size As Integer)
      Try
        _totalDataReceived += size
        _data_size.Add(size)
        _data_time.Add(Now)
        While _data_size.Count > _max_data_samples
          _data_size.RemoveAt(0)
          _data_time.RemoveAt(0)
        End While
      Catch ex As Exception
      End Try
    End Sub

    Public ReadOnly Property DataRate() As Double
      Get
        If _data_size.Count > 1 Then
          Return Me.DataSize / Me.TimeSpanSeconds
        Else
          Return 0
        End If
      End Get
    End Property

    Public ReadOnly Property DataRateText As String
      Get
        Dim TheSize As ULong = Me.DataSize
        Dim SizeType As String = ""
        Dim DoubleBytes As Double

        Try
          Select Case TheSize
            Case Is >= 1099511627776
              DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
              Return FormatNumber(DoubleBytes, 2) & " TBps"
            Case 1073741824 To 1099511627775
              DoubleBytes = CDbl(TheSize / 1073741824) 'GB
              Return FormatNumber(DoubleBytes, 2) & " GBps"
            Case 1048576 To 1073741823
              DoubleBytes = CDbl(TheSize / 1048576) 'MB
              Return FormatNumber(DoubleBytes, 2) & " MBps"
            Case 1024 To 1048575
              DoubleBytes = CDbl(TheSize / 1024) 'KB
              Return FormatNumber(DoubleBytes, 2) & " KBps"
            Case 0 To 1023
              DoubleBytes = TheSize ' bytes
              Return FormatNumber(DoubleBytes, 2) & " Bps"
            Case Else
              Return ""
          End Select
        Catch
          Return ""
        End Try
      End Get
    End Property

    Public ReadOnly Property DataSize() As Integer
      Get
        Dim bytes As Integer = 0
        For Each size As Integer In _data_size
          bytes += size
        Next
        Return bytes
      End Get
    End Property

    Public ReadOnly Property TimeSpan() As TimeSpan
      Get
        If _data_time.Count > 1 Then
          Return _data_time.Last.Subtract(_data_time.First)
        Else
          Return New TimeSpan
        End If
      End Get
    End Property

    Public ReadOnly Property TimeSpanSeconds() As Double
      Get
        If _data_time.Count > 1 Then
          Return _data_time.Last.Subtract(_data_time.First).TotalSeconds
        Else
          Return 1
        End If
      End Get
    End Property

  End Class

End Namespace
