Imports System.ComponentModel
Imports WindowsApp1

Public Class frmMain
  Private _captureSession As CaptureSession = Nothing
  Private _udpSender As Connections.UDPSender

  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try

      'make application run on higher priority
      Dim myProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
      myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime

      Me.LoadSession(My.Settings.LastSessionFile)
    Catch ex As Exception

    End Try
  End Sub

  Private Sub UCcommManager1_DataReceiveBytes(ByRef sender As CommManager, ByRef biData() As Byte) Handles UCcommManagerReceive.DataReceiveBytes
    'UCcommManager2.commManager.SendData(biData) 
    If Not _captureSession Is Nothing Then
      _captureSession.AddMessage(biData)
    End If
  End Sub

  Private Sub UCcommManager1_DataReceive(ByRef sender As CommManager, ByRef siData As String) Handles UCcommManagerReceive.DataReceive
    'UCcommManager2.commManager.SendData(siData)
  End Sub

  Private Sub UCcommManager1_SocketConnected(sender As CommManager) Handles UCcommManagerReceive.SocketConnected
    Try
      If Not _captureSession Is Nothing Then
        'save previous capture session
        WriteCaptureSession(False)
      End If
      'create new capture session
      _captureSession = New CaptureSession(sender.ToString, "Captured on " & Now.ToString)
      WriteCaptureSession(True)
    Catch ex As Exception

    End Try
  End Sub


  Private Sub UCcommManager1_SocketDisconnected(sender As CommManager) Handles UCcommManagerReceive.SocketDisconnected
    Try
      WriteCaptureSession(False)
    Catch ex As Exception

    End Try
  End Sub

  Private _activeCommSessionPath As String = ""
  Private Sub WriteCaptureSession(create As Boolean)
    Try

      Dim sText As String = SerializeObjectToString(_captureSession, False)

      Dim aux As New CaptureSession()
      DesserializeObjectFromString(sText, aux, False)

      Dim folder As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Sessions")
      System.IO.Directory.CreateDirectory(folder)

      Dim filePath As String = _activeCommSessionPath
      If create Or Not System.IO.File.Exists(filePath) Then
        Dim fileName As String = _captureSession.Name


        filePath = System.IO.Path.Combine(folder, fileName & ".tss")

        Dim fileIndex As Integer = 0
        While System.IO.File.Exists(filePath)
          filePath = System.IO.Path.Combine(folder, fileName & "_" & Strings.Format(fileIndex, "00") & ".tss")
          fileIndex += 1
        End While
      End If
      _activeCommSessionPath = filePath
      Me.Text = _activeCommSessionPath
      System.IO.File.WriteAllText(filePath, sText)
    Catch ex As Exception

    End Try
  End Sub


  Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    Try
      If Not UCcommManagerReceive.commManager Is Nothing AndAlso UCcommManagerReceive.commManager.Connected Then
        If MsgBox("There is an active session running. Close anyway?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
          UCcommManagerReceive.commManager.ClosePort()
          WriteCaptureSession(False)
        End If
      End If
    Catch ex As Exception

    End Try
  End Sub

#Region "Repdroduce session"
  Private WithEvents _backgroundWorkerReplayManager As BackgroundWorker
  Private WithEvents _backgroundWorkerSendManager As BackgroundWorker
  Private _replaySession As CaptureSession = Nothing

  Public Sub LoadSession(filePath As String)
    Dim aux As New CaptureSession
    My.Settings.LastSessionFile = filePath
    My.Settings.Save()
    If DesserializeObjectFromFile(My.Settings.LastSessionFile, aux, False) Then
      If MsgBox("Fix rthead timing?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        aux = FixRTHeadTiming(aux)
      End If
      _replaySession = aux
      Me.LabelInfo.Text = _replaySession.CapturedMessages.Count & " messages "
    End If
  End Sub


  Private Function FixRTHeadTiming(session As CaptureSession) As CaptureSession
    Try
      'get all the data packets into one
      Dim totalSize As Integer = 0
      For Each msg As CaptureMessage In session.CapturedMessages
        totalSize += msg.data.Length
      Next

      Dim allData(totalSize - 1) As Byte
      Dim dataOffset As Integer = 0
      For Each msg As CaptureMessage In session.CapturedMessages
        Buffer.BlockCopy(msg.data, 0, allData, dataOffset, msg.data.Length)
        dataOffset += msg.data.Length
      Next

      Dim outSession As New CaptureSession("Fixed", "Fixed")

      'we get the data in 15-byte packets, once every 10ms
      dataOffset = 0
      For i As Integer = 0 To allData.Length - 15 Step 15
        Dim msg As New CaptureMessage()
        msg.TimeOffset = 10 * i / 15
        ReDim msg.data(14)
        Buffer.BlockCopy(allData, dataOffset, msg.data, 0, msg.data.Length)
        outSession.CapturedMessages.Add(msg)
        dataOffset += msg.data.Length
      Next
      Return outSession
    Catch ex As Exception

    End Try
  End Function

  Private Sub ButtonLoad_Click(sender As Object, e As EventArgs) Handles ButtonLoad.Click
    Try
      Me.OpenFileDialogSession.FileName = My.Settings.LastSessionFile
      If Me.OpenFileDialogSession.ShowDialog(Me) = DialogResult.OK Then
        Me.LoadSession(Me.OpenFileDialogSession.FileName)
      End If
    Catch ex As Exception

    End Try
  End Sub


  Private Sub ButtonStartStop_Click(sender As Object, e As EventArgs) Handles ButtonStartStop.Click
    Try
      If Not _backgroundWorkerReplayManager Is Nothing AndAlso _backgroundWorkerReplayManager.IsBusy Then
        _backgroundWorkerReplayManager.CancelAsync()
        '_backgroundWorker = Nothing
      Else
        Me.UCcommManagerSend.RichTextBoxLog.Text = ""
        Me.UCcommManagerReceive.RichTextBoxLog.Text = ""
        _backgroundWorkerReplayManager = New BackgroundWorker
        _backgroundWorkerReplayManager.WorkerReportsProgress = True
        _backgroundWorkerReplayManager.WorkerSupportsCancellation = True
        _backgroundWorkerReplayManager.RunWorkerAsync()
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private _senderLogWindow As RichTextBox = Nothing
  Private _receiverLogWindow As RichTextBox = Nothing
  Private Sub _backgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _backgroundWorkerReplayManager.DoWork
    Try
      Dim bDone As Boolean = False
      Dim startTime As Date = Now
      Dim index As Integer = 0
      Me.UCcommManagerReceive.commManager.CurrentTransmissionType = CommManager.TransmissionType.Hex
      Me.UCcommManagerSend.commManager.CurrentTransmissionType = CommManager.TransmissionType.Hex

      _senderLogWindow = Me.UCcommManagerSend.commManager.DisplayWindow
      _receiverLogWindow = Me.UCcommManagerReceive.commManager.DisplayWindow

      Me.UCcommManagerReceive.commManager.DisplayWindow = Nothing
      Me.UCcommManagerSend.commManager.DisplayWindow = Nothing

      Dim sAux As String = ""
      Dim maxMessages As Integer = 2000000

      _backgroundWorkerSendManager = New BackgroundWorker
      _backgroundWorkerSendManager.RunWorkerAsync()

      If _captureSession Is Nothing Then
        _captureSession = New CaptureSession(Now.ToString, Now.ToString)
      End If
      _captureSession.CapturedMessages.Clear()
      _captureSession.Description = Now.ToString

      'Create a dummy dataset!
      Dim session As CaptureSession = _replaySession
      If Me.CheckBoxFreedSym.Checked Then
        session = New CaptureSession("dummy", "dummy session")

        'create a dummy free-d position message
        Dim dummyData(30 - 1) As Byte
        dummyData(0) = CaptureMessage.HexToByte("D1")(0)
        dummyData(1) = CaptureMessage.HexToByte("FF")(0)

        'compute checksum
        Dim checkSum As Integer = 0
        For i As Integer = 0 To dummyData.Count - 2
          checkSum += dummyData(i)
        Next
        checkSum = (64 - checkSum) Mod 256
        If checkSum < 0 Then checkSum += 256
        dummyData(dummyData.Length - 1) = checkSum


        dummyData = CaptureMessage.HexToByte("04 83 FF 42 88 FF FE 1D 00 20 80 00 10 0E 28" & "04 88 FF 42 88 FF FD C3 00 20 80 00 10 0E D2")

        'create 100 messages with our dummy data
        For i As Integer = 0 To 100
          Dim msg As New CaptureMessage()
          msg.TimeOffset = 40 * i
          msg.data = dummyData
          session.CapturedMessages.Add(msg)
        Next
        _replaySession = session
      End If
      If Me.CheckBoxLoop.Checked = False Then maxMessages = 50
      Dim tolerance As Double = 0.5

      _udpSender = New Connections.UDPSender()
      _udpSender.Connect(Me.TextBoxUDPHost.Text, Me.NumericUpDownUDPPort.Value)

      While Not _backgroundWorkerReplayManager.CancellationPending And (CheckBoxLoop.Checked Or (index < session.CapturedMessages.Count And index < maxMessages))
        Dim offset As Double = Now.Subtract(startTime).TotalMilliseconds
        'sAux = sAux & index & " offset = " & offset & vbCrLf

        While index < session.CapturedMessages.Count AndAlso offset > session.CapturedMessages(index).TimeOffset - tolerance And index < maxMessages
          sAux = sAux & index & " offset = " & offset & " | message offset = " & session.CapturedMessages(index).TimeOffset & " | data = " & CaptureMessage.ByteToHex(session.CapturedMessages(index).data) & vbCrLf
          If Me.CheckBoxForwardToUDP.Checked Then
            _udpSender.SendData(session.CapturedMessages(index).data)
          Else
            Me.UCcommManagerSend.commManager.SendData(session.CapturedMessages(index).data)

          End If
          '_queueMessages.Enqueue(session.CapturedMessages(index).data)
          sAux = sAux & "    sent in " & Now.Subtract(startTime).TotalMilliseconds - offset & " ms "

          index = index + 1
          If Me.CheckBoxLoop.Checked Then
            index = index Mod session.CapturedMessages.Count
            If index = 0 Then
              startTime = Now
            End If
          End If
          _backgroundWorkerReplayManager.ReportProgress(index)
        End While
        Threading.Thread.Sleep(1)
      End While
      Debug.Print(sAux)
      If Not _captureSession Is Nothing Then

        Debug.Print(_captureSession.CaptureLog)
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _backgroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _backgroundWorkerReplayManager.ProgressChanged
    Me.LabelInfo.Text = e.ProgressPercentage
  End Sub

  Private Sub _backgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _backgroundWorkerReplayManager.RunWorkerCompleted
    Try
      'compare sessions
      Me.UCcommManagerSend.RichTextBoxLog.Text = Me.UCcommManagerSend.commManager.PortOverruns & " port overruns" & vbCrLf & ShowCaptureSession(_replaySession)
      Me.UCcommManagerReceive.RichTextBoxLog.Text = Me.UCcommManagerReceive.commManager.PortOverruns & " port overruns" & vbCrLf & ShowCaptureSession(_captureSession)

    Catch ex As Exception
    End Try
  End Sub

  Private Function ShowCaptureSession(captureSession As CaptureSession) As String
    Dim res As String = ""
    If captureSession Is Nothing Then Return ""
    Try
      res = captureSession.Name & vbCrLf
      res = res & captureSession.Description & vbCrLf
      res = res & captureSession.Name & vbCrLf
      res = res & captureSession.CapturedMessages.Count & " messages" & vbCrLf

      Dim dataSent As ULong = 0
      For i As Integer = 0 To captureSession.CapturedMessages.Count - 1
        dataSent += captureSession.CapturedMessages(i).data.Length
      Next
      res = res & Strings.Format(dataSent, "###.###.###") & " bytes" & vbCrLf

      dataSent = 0
      Dim _lastOffset As Double = 0
      For i As Integer = 0 To captureSession.CapturedMessages.Count - 1
        res = res & dataSent & " bytes " & " intra packet time = " & Strings.Format(captureSession.CapturedMessages(i).TimeOffset - _lastOffset, "0.0") & " | " & captureSession.CapturedMessages(i).ToString & vbCrLf
        _lastOffset = captureSession.CapturedMessages(i).TimeOffset
        dataSent += captureSession.CapturedMessages(i).data.Length
      Next
    Catch ex As Exception

    End Try
    Return Res
  End Function

  Private _queueMessages As New Concurrent.ConcurrentQueue(Of Byte())
  Private Sub _backgroundWorkerSendManager_DoWork(sender As Object, e As DoWorkEventArgs) Handles _backgroundWorkerSendManager.DoWork
    Try
      While Not _backgroundWorkerSendManager Is Nothing AndAlso Not _backgroundWorkerSendManager.CancellationPending
        While _queueMessages.Count > 0
          Try
            Dim data() As Byte = {}
            If _queueMessages.TryDequeue(data) Then
              Me.UCcommManagerSend.commManager.SendData(data)
            End If
            Threading.Thread.Sleep(1)
          Catch ex As Exception

          End Try

        End While
      End While
      While _queueMessages.Count > 0
        Dim data() As Byte = {}
        _queueMessages.TryDequeue(data)
      End While
    Catch ex As Exception

    End Try
  End Sub


#End Region
End Class