Imports SerialTest

Public Class MirandaLittleRedControl
#Region "Properties"
  Private WithEvents _commManager As New CommManager
  Public Property CommManager As CommManager
    Get
      Return _commManager
    End Get
    Set(value As CommManager)
      _commManager = value
    End Set
  End Property

  Public Property SerialPortName As String = ""
  Public Property DisplayWindow As RichTextBox = Nothing

  Public ReadOnly Property Connected As Boolean
    Get
      If _commManager Is Nothing Then
        Return False
      Else
        Return _commManager.Connected
      End If
    End Get
  End Property
#End Region

#Region "Commands"
  Public Enum eCommandType
    None
    GetProductID
    Settings_Save
    Settings_Restore
    SetGPO1
    SetGPO2
    SetGPO3
    SetGPO4
    SetGPOAll
    SetGPITrigger
    StartContinuousReport
    StopContinuousReport
    ShowTimeAddress
    ShowUserGroup
    ShowStatusData
  End Enum

  Private Class SerialCommand
    Public CommandType As eCommandType = eCommandType.None
    Public CommandData As String = ""
    Public Response As String = ""

    Public Sub New()
      CommandType = eCommandType.None
    End Sub

    Public Sub New(type As eCommandType)
      CommandType = type
      CommandData = ""
    End Sub

    Public Sub New(type As eCommandType, data As String)
      CommandType = type
      CommandData = data
    End Sub

    Public Sub New(type As eCommandType, data As Integer)
      CommandType = type
      CommandData = CStr(data)
    End Sub

    Public Sub New(type As eCommandType, data As Boolean)
      CommandType = type
      CommandData = IIf(data, "1", "0")
    End Sub

    Public ReadOnly Property SerialCommandString() As String
      Get
        Dim sCmd As String = ""
        Try
          Select Case Me.CommandType
            Case eCommandType.GetProductID
              sCmd = "GS>"
            Case eCommandType.Settings_Restore
              sCmd = "RP>"
            Case eCommandType.StartContinuousReport
              sCmd = "RM>1"
            Case eCommandType.StopContinuousReport
              sCmd = "RM>0"
            Case eCommandType.SetGPO1
              sCmd = "O1>" & Me.CommandData
            Case eCommandType.SetGPO2
              sCmd = "O2>" & Me.CommandData
            Case eCommandType.SetGPO3
              sCmd = "O3>" & Me.CommandData
            Case eCommandType.SetGPO4
              sCmd = "O4>" & Me.CommandData
            Case eCommandType.SetGPOAll
              sCmd = "O?>" & Me.CommandData
            Case eCommandType.SetGPITrigger
              sCmd = "I?>" & Me.CommandData
            Case eCommandType.ShowTimeAddress
              sCmd = "RT>" & Me.CommandData
            Case eCommandType.ShowUserGroup
              sCmd = "RU>" & Me.CommandData
            Case eCommandType.ShowStatusData
              sCmd = "RS>" & Me.CommandData
          End Select
          sCmd = sCmd & vbCr
        Catch ex As Exception
        End Try
        Return sCmd
      End Get
    End Property

    Public ReadOnly Property SerialCommandBytes() As Byte()
      Get
        Return System.Text.Encoding.ASCII.GetBytes(Me.SerialCommandString)
      End Get
    End Property

  End Class
#End Region

#Region "Device functions"
  Public Sub Start(silentMode As Boolean)
    Try
      'create the comm manager
      _commManager = New CommManager(9600, System.IO.Ports.Parity.None, System.IO.Ports.StopBits.One, 8, Me.SerialPortName, Me.DisplayWindow)

      _commManager.OpenPort()
      'Me.SendCommand(eCommandType.GetProductID)
      Me.SendCommand(eCommandType.Settings_Restore)
      Me.SendCommand(eCommandType.ShowStatusData, True)
      Me.SendCommand(eCommandType.ShowTimeAddress, False)
      Me.SendCommand(eCommandType.ShowUserGroup, False)
      Me.SendCommand(eCommandType.SetGPITrigger, "0")
      Me.SendCommand(eCommandType.StartContinuousReport)

      'ask for version
    Catch ex As Exception

    End Try
  End Sub

  Public Sub [Stop]()
    Try
      _commManager.ClosePort()
    Catch ex As Exception

    End Try
  End Sub
#End Region

#Region "GPIO States"
  Public Event GPI_State_Changed(sender As MirandaLittleRedControl, index As Integer, value As Boolean)
  Public Event GPO_State_Changed(sender As MirandaLittleRedControl, index As Integer, value As Boolean)

  Public Sub SetGPI(index As Integer, value As Boolean)
    Try

    Catch ex As Exception

    End Try
  End Sub

  Private _GPIStates() As Boolean = {False, False}
  Private _GPOStates() As Boolean = {False, False, False, False}

  'Get gpi state, index starts at 1
  Public Function GetGPI(index As Integer) As Boolean
    Dim res As Boolean = False
    Try
      If index > 0 And index <= _GPIStates.Count Then
        Return _GPIStates(index - 1)
      End If
    Catch ex As Exception

    End Try
    Return res
  End Function

  'Get gpo state, index starts at 1
  Public Function GetGPO(index As Integer) As Boolean
    Dim res As Boolean = False
    Try
      If index > 0 And index <= _GPOStates.Count Then
        Return _GPOStates(index - 1)
      End If
    Catch ex As Exception

    End Try
    Return res
  End Function


  Public ReadOnly Property GPIStates As UInteger
    Get
      Dim state As UInteger = 0
      For i As Integer = 0 To _GPIStates.Count - 1
        BitSet(state, i, _GPIStates(i))
      Next
      Return state
    End Get
  End Property

  Public ReadOnly Property GPOStates As UInteger
    Get
      Dim state As UInteger = 0
      For i As Integer = 0 To _GPOStates.Count - 1
        BitSet(state, i, _GPOStates(i))
      Next
      Return state
    End Get
  End Property

  Public Sub Set_GPIStates(gpiState As UInteger)
    Try
      For i As Integer = 0 To _GPIStates.Count - 1
        Me.UpdateGPIValue(i + 1, BitGet(gpiState, i))
      Next
    Catch ex As Exception
    End Try
  End Sub

  Public Sub Set_GPOStates(gpoState As UInteger)
    Try
      For i As Integer = 0 To _GPOStates.Count - 1
        Me.UpdateGPOValue(i + 1, BitGet(gpoState, i))
      Next
    Catch ex As Exception
    End Try
  End Sub
#End Region

#Region "serial comunication"
  Private _sentCommands As New List(Of SerialCommand)

  Public Sub SendCommand(cmd As MirandaLittleRedControl.eCommandType)
    Me.SendCommand(cmd, "")
  End Sub
  Public Sub SendCommand(cmd As MirandaLittleRedControl.eCommandType, data As String)
    Try
      Dim scmd As New SerialCommand(cmd, data)
      _sentCommands.Add(scmd)
      _commManager.SendData(scmd.SerialCommandBytes)
    Catch ex As Exception
    End Try
  End Sub

  Public Sub SendCommand(cmd As MirandaLittleRedControl.eCommandType, data As Integer)
    Try
      Dim scmd As New SerialCommand(cmd, data)
      _sentCommands.Add(scmd)
      _commManager.SendData(scmd.SerialCommandBytes)
    Catch ex As Exception
    End Try
  End Sub

  Public Sub SendCommand(cmd As MirandaLittleRedControl.eCommandType, data As Boolean)
    Try
      Dim scmd As New SerialCommand(cmd, data)
      _sentCommands.Add(scmd)
      _commManager.SendData(scmd.SerialCommandBytes)
    Catch ex As Exception
    End Try
  End Sub

  Public Sub SetGPO(index As Integer, value As Boolean)
    Try
      Select Case index
        Case 1
          Me.SendCommand(eCommandType.SetGPO1, value)
        Case 2
          Me.SendCommand(eCommandType.SetGPO2, value)
        Case 3
          Me.SendCommand(eCommandType.SetGPO3, value)
        Case 4
          Me.SendCommand(eCommandType.SetGPO4, value)
      End Select
    Catch ex As Exception

    End Try
  End Sub

  Public Sub ToggleGPO(index As Integer)
    Try
      Me.SetGPO(index, Not Me.GetGPO(index))
    Catch ex As Exception

    End Try
  End Sub

  Public Sub UpdateGPOValue(index As Integer, value As Boolean)
    Try
      If _GPOStates(index - 1) <> value Then
        _GPOStates(index - 1) = value
        RaiseEvent GPO_State_Changed(Me, index, value)
      End If
    Catch ex As Exception
    End Try
  End Sub

  Public Sub UpdateGPIValue(index As Integer, value As Boolean)
    Try
      If _GPIStates(index - 1) <> value Then
        _GPIStates(index - 1) = value
        RaiseEvent GPI_State_Changed(Me, index, value)
      End If
    Catch ex As Exception
    End Try
  End Sub

  Private Sub _commManager_DataReceive(ByRef sender As CommManager, siData As String) Handles _commManager.DataReceive
    Try
      Dim separators() As Char = {" "c, vbCr, vbLf}
      Dim sAux() As String = siData.Split(separators)

      For Each aux As String In sAux
        If aux.Trim.Length > 0 Then ProcessData(aux)
      Next

    Catch ex As Exception

    End Try
  End Sub

  Private Sub ProcessData(siData As String)
    Try
      Select Case siData
        Case "OK>"
        Case "NA>"
        Case "NV>"
        Case Else
          If siData.Trim.Length = 5 Then
            'status string!
            Dim sTimeCodeStatus As String = siData.Substring(0, 1)
            Dim sTimeCodeFlagBits As String = siData.Substring(1, 2)
            Dim sTriggerSourceCodes As String = siData.Substring(3, 2)
            'we only care about trigger sources (gpis)
            Dim triggerSourceCodes As Byte = Convert.ToByte(sTriggerSourceCodes, 16)


            Me.UpdateGPOValue(1, BitGet(triggerSourceCodes, 0))
            Me.UpdateGPOValue(2, BitGet(triggerSourceCodes, 1))
            Me.UpdateGPOValue(3, BitGet(triggerSourceCodes, 2))
            Me.UpdateGPOValue(4, BitGet(triggerSourceCodes, 3))

            Me.UpdateGPIValue(1, BitGet(triggerSourceCodes, 4))
            Me.UpdateGPIValue(2, BitGet(triggerSourceCodes, 5))
          End If
      End Select
      Debug.Print(siData)
    Catch ex As Exception

    End Try
  End Sub


  Private Sub _commManager_DataReceiveBytes(ByRef sender As CommManager, ByRef biData() As Byte) Handles _commManager.DataReceiveBytes
    Try

    Catch ex As Exception

    End Try
  End Sub
#End Region

#Region "Bit data"

  Public Function BitGet(ByRef theNum As Integer, ByVal thBit As Integer) As Boolean
    Dim res As Boolean = False
    If IsNumeric(thBit) And thBit >= 0 And thBit <= 31 Then
      res = theNum And 2 ^ thBit 'get the bit
    Else
      Return False
    End If
    Return res
  End Function

  Public Sub BitSet(ByRef theNum As Integer, ByVal thBit As Integer, value As Boolean)
    If IsNumeric(thBit) And thBit >= 0 And thBit <= 31 Then
      If value Then
        theNum = theNum Or 2 ^ thBit 'set the bit
      Else
        theNum = (theNum Or 2 ^ thBit) Xor 2 ^ thBit 'set the bit
      End If
    Else
      Exit Sub
    End If
  End Sub
#End Region


End Class
