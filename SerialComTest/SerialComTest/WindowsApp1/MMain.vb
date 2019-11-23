Module MMain
  Public Sub Main()
    Try

      'make application run on higher priority
      Dim myProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
      myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime
      Application.Run(frmMain)
    Catch ex As Exception
      MsgBox(ex.ToString)
    End Try
  End Sub

End Module
