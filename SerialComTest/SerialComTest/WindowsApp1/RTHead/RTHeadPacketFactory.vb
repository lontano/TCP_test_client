Public Class RTHeadPacketFactory
  Private _listBytes As New List(Of Byte)
  Public Property DetectedPackets As New List(Of RTHeadPacket)
  Public Property LastDetectedPacket As RTHeadPacket = Nothing

  Public Sub New()

  End Sub

  Public Sub Reset()
    Try
      _listBytes.Clear()
      DetectedPackets.Clear()
      LastDetectedPacket = Nothing
      _discardedBytes = 0
      _processedBytes = 0
      Me.AnalyzePackets()
    Catch ex As Exception
    End Try
  End Sub

  Public Function AddBytes(data() As Byte) As RTHeadPacket()
    Dim listPackets As New List(Of RTHeadPacket)
    Try
      _processedBytes += data.Length
      'enqueue the data 
      For Each b As Byte In data
        _listBytes.Add(b)
      Next

      'while there's enough data on the list to build a packet...
      While _listBytes.Count >= RTHeadPacket.ByteCount
        'discard everything until we have a candidate or we run out of bytes
        While (_listBytes.Count <> 0) AndAlso _listBytes(0) <> RTHeadPacket.StartingByte
          _listBytes.RemoveAt(0)
          _discardedBytes += 1
        End While
        'do we still have enough to create a new packet?
        If _listBytes.Count >= RTHeadPacket.ByteCount Then
          'we try to get a packet from current bytes
          Dim aux As RTHeadPacket = RTHeadPacket.GetPacket(_listBytes.ToArray)
          'if the packet is correct, we add it to the list and get rid of all bytes used by it
          If Not aux Is Nothing Then
            listPackets.Add(aux)
            DetectedPackets.Add(aux)
            For i As Integer = 0 To RTHeadPacket.ByteCount - 1
              _listBytes.RemoveAt(0)
            Next
          Else
            'there was no packet to be read here, we get rid of the first byte and try again
            _listBytes.RemoveAt(0)
            _discardedBytes += 1
          End If
        End If
      End While

      'analyze data if we have new packets
      If listPackets.Count > 0 Then
        Me.LastDetectedPacket = listPackets.Last
      End If
    Catch ex As Exception

    End Try
    Return listPackets.ToArray
  End Function

#Region "Packet analyzer"
  Public _zeroIndexPackets As UInteger = 0
  Public _repeatedPacekts As UInteger = 0
  Public _packetsOutOfOrder As UInteger = 0
  Public _processedBytes As UInteger = 0
  Public _discardedBytes As UInteger = 0

  Public _timingMean As Double = 0
  Public _timingStdDev As Double = 0
  Public _timingMin As Double = 0
  Public _timingMax As Double = 0

  Private _maxPacketsToAnalyze As Integer = 2000

  Public Sub AnalyzePackets()
    Try
      Dim packets As New List(Of RTHeadPacket)

      For i As Integer = Math.Max(0, Me.DetectedPackets.Count - _maxPacketsToAnalyze) To Me.DetectedPackets.Count - 1
        packets.Add(Me.DetectedPackets(i))
      Next


      _zeroIndexPackets = 0
      _repeatedPacekts = 0
      _packetsOutOfOrder = 0

      _timingMean = 0
      _timingStdDev = 0
      _timingMin = 0
      _timingMax = 0

      'Analyze packet indexes
      If packets.Count >= 1 Then
        For i As Integer = 0 To packets.Count - 1
          If packets(i).Index = 0 Then _zeroIndexPackets += 1 'packet with zero index: starting a new 16 packet loop?
          If i > 0 Then
            If packets(i).Index = packets(i - 1).Index Then _repeatedPacekts += 1
            If packets(i).Index <> (packets(i - 1).Index + 1) Mod 16 Then _packetsOutOfOrder += 1
          End If
        Next
      End If

      'Analyze packet timing, we need at least 2...
      If packets.Count >= 2 Then
        Dim firstPacketTime As Date = packets(0).TimeStamp
        Dim formerPacketTime As Date = packets(0).TimeStamp
        'mean
        _timingMean = 0
        _timingMin = Double.MaxValue
        _timingMax = Double.MinValue
        For i As Integer = 1 To packets.Count - 1
          Dim diff As Double = packets(i).TimeStamp.Subtract(packets(i - 1).TimeStamp).TotalMilliseconds
          _timingMean += diff
          _timingMax = Math.Max(_timingMax, diff)
          _timingMin = Math.Min(_timingMin, diff)
        Next
        _timingMean = _timingMean / (packets.Count - 1)
        'std dev
        _timingStdDev = 0
        For i As Integer = 1 To packets.Count - 1
          _timingStdDev += Math.Pow(packets(i).TimeStamp.Subtract(packets(i - 1).TimeStamp).TotalMilliseconds - _timingMean, 2)
        Next
        _timingStdDev = _timingStdDev / (packets.Count - 1)
        _timingStdDev = Math.Sqrt(_timingStdDev)
      End If

    Catch ex As Exception

    End Try
  End Sub

  Private Function GetPositionForValue(value, minValue, maxValue, minPosition, maxPosition) As Double
    Dim res As Double = minPosition
    Try
      res = (maxValue - value) / (maxValue - minValue)
      res = maxPosition - res * (maxPosition - minPosition)
    Catch ex As Exception

    End Try
    Return res
  End Function


  Public Function CreateAnalyzerCanvas(width As Integer, height As Integer) As Bitmap
    Dim bmp As New Bitmap(width, height)
    Try

      Dim packets As New List(Of RTHeadPacket)

      For i As Integer = Math.Max(0, Me.DetectedPackets.Count - _maxPacketsToAnalyze) To Me.DetectedPackets.Count - 1
        packets.Add(Me.DetectedPackets(i))
      Next

      Using g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.Black)


        Dim diffs As New List(Of Double)
        Dim histogramValues As New List(Of UInteger)
        Dim histogramScale As Double = 10
        diffs.Add(0)
        For i As Integer = 1 To packets.Count - 1
          Dim diff As Double = packets(i).TimeStamp.Subtract(packets(i - 1).TimeStamp).TotalMilliseconds
          If diff > 0 Then
            diffs.Add(diff)

            While histogramValues.Count <= CInt(histogramScale * diff)
              histogramValues.Add(0)
            End While
            histogramValues(CInt(histogramScale * diff)) += 1
          End If
        Next

        Dim span As Integer = 5
        Dim canvasRect As New Rectangle(span, span, width - 2 * span, height / 2 - 2 * span)
        Dim x As Double = 0
        Dim y As Double = 0
        Dim xValueMin As Double = 0
        Dim xValueMax As Double = 0
        Dim yValueMin As Double = 0
        Dim yValueMax As Double = 0
        Dim value As Double = 0
        Dim valueMin As Double = 0
        Dim valueMax As Double = 0

        canvasRect = New Rectangle(span, span, width - 2 * span, height / 2 - 2 * span)
        'show the rectangle where the canvas lives
        g.DrawRectangle(Pens.Red, canvasRect)
        'mark each packet's diff time, around the expected time mark
        xValueMin = 0
        xValueMax = packets.Count
        yValueMin = 0
        yValueMax = 2 * RTHeadPacket.PacketTime
        'draw the "mean" line
        value = RTHeadPacket.PacketTime
        y = GetPositionForValue(value, yValueMin, yValueMax, canvasRect.Bottom, canvasRect.Top)
        g.DrawLine(Pens.White, New Point(canvasRect.Left, y), New Point(canvasRect.Right, y))

        'draw the lines around the std deviation
        value = RTHeadPacket.PacketTime + Me._timingStdDev
        y = GetPositionForValue(value, yValueMin, yValueMax, canvasRect.Bottom, canvasRect.Top)
        g.DrawLine(Pens.Yellow, New Point(canvasRect.Left, y), New Point(canvasRect.Right, y))

        value = RTHeadPacket.PacketTime - Me._timingStdDev
        y = GetPositionForValue(value, yValueMin, yValueMax, canvasRect.Bottom, canvasRect.Top)
        g.DrawLine(Pens.Yellow, New Point(canvasRect.Left, y), New Point(canvasRect.Right, y))

        For i As Integer = 0 To diffs.Count - 1
          x = GetPositionForValue(i, 0, diffs.Count - 1, canvasRect.Left, canvasRect.Right)
          y = GetPositionForValue(diffs(i), yValueMin, yValueMax, canvasRect.Bottom, canvasRect.Top)
          g.FillEllipse(Brushes.Red, CSng(x), CSng(y), 3, 3)
        Next

        'create an histogram
        canvasRect = New Rectangle(span, span + height / 2, width / 2 - 2 * span, height / 2 - 2 * span)
        'show the rectangle where the canvas lives
        g.DrawRectangle(Pens.Blue, canvasRect)

        Dim maxHistogramValue As UInteger = 0
        For Each diff As UInteger In histogramValues
          maxHistogramValue = Math.Max(maxHistogramValue, diff)
        Next
        Dim valuesToShow As Integer = Math.Min(histogramValues.Count, histogramScale * 20)
        xValueMin = 0
        xValueMax = valuesToShow
        yValueMin = maxHistogramValue
        yValueMax = 0

        Dim pDark As New Pen(Color.FromArgb(20, Color.White))
        'draw marks for the ms
        For i As Integer = 0 To valuesToShow - 1 Step histogramScale

          Dim x1 As Single = GetPositionForValue(i + 0.5, xValueMin, xValueMax, canvasRect.Left, canvasRect.Right)
          Dim x2 As Single = GetPositionForValue(i + 0.5, xValueMin, xValueMax, canvasRect.Left, canvasRect.Right)
          Dim y1 As Single = GetPositionForValue(yValueMax, yValueMin, yValueMax, canvasRect.Top, canvasRect.Bottom)
          Dim y2 As Single = GetPositionForValue(yValueMin, yValueMin, yValueMax, canvasRect.Top, canvasRect.Bottom)

          g.DrawLine(pDark, x1, y1, x2, y2)
        Next

        For i As Integer = 0 To valuesToShow - 1
          Dim x1 As Double = GetPositionForValue(i, xValueMin, xValueMax, canvasRect.Left, canvasRect.Right)
          Dim x2 As Double = GetPositionForValue(i + 1, xValueMin, xValueMax, canvasRect.Left, canvasRect.Right)
          Dim y1 As Double = GetPositionForValue(histogramValues(i), yValueMin, yValueMax, canvasRect.Top, canvasRect.Bottom)
          Dim y2 As Double = GetPositionForValue(0, yValueMin, yValueMax, canvasRect.Top, canvasRect.Bottom)
          Dim p1 As New Point(x, y)
          Dim p2 As New Point(x, y)
          Dim drawRect As New RectangleF(x1, y1, x2 - x1, y2 - y1)
          g.FillRectangle(Brushes.LightGreen, drawRect)
        Next

        'create a circular graph
        canvasRect = New Rectangle(width / 2 + span, span + height / 2, width / 2 - 2 * span, height / 2 - 2 * span)
        'show the rectangle where the canvas lives
        g.DrawRectangle(Pens.Green, canvasRect)

        Dim r As Double = Math.Min(canvasRect.Width, canvasRect.Height) / 2

        Dim b As New SolidBrush(Color.FromArgb(128, Color.Green))

        For i As Integer = Math.Max(0, packets.Count - 300) To packets.Count - 1
          Dim val As Double = packets(i).TimeStamp.Millisecond / 1000

          x = canvasRect.Left + canvasRect.Width / 2 + Math.Cos(2 * val * Math.PI) * r
          y = canvasRect.Top + canvasRect.Height / 2 + Math.Sin(2 * val * Math.PI) * r

          g.FillEllipse(b, CSng(x), CSng(y), 3, 3)

        Next

      End Using
    Catch ex As Exception

    End Try
    Return bmp
  End Function

#End Region

  Public Overrides Function ToString() As String

    AnalyzePackets()
    If DetectedPackets.Count > 0 And _timingMean = 0 Then
      Debug.Print("What?")
    End If
    Return "Tracking packet factory  " & DetectedPackets.Count & " detected packets | zero index=" & _zeroIndexPackets & " repeated=" & _repeatedPacekts & " out of order=" & _packetsOutOfOrder & " | processed bytes=" & _processedBytes & " discarded bytes=" & _discardedBytes & " | timing " & _timingMean & " <" & _timingStdDev & "> min=" & _timingMin & " max=" & _timingMax
  End Function
End Class
