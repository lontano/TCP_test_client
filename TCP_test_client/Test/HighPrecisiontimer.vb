Option Strict On
Option Explicit On
Imports System.ComponentModel

<System.ComponentModel.DefaultEvent("Tick")>
Public Class PrecisionTimer
  Inherits System.ComponentModel.Component

  Private WithEvents _backWorkerTimer As New BackgroundWorker

#Region "Events"

  Public Event Tick(ByVal sender As Object, ByVal e As EventArgs)

#End Region

#Region "Methods"


  Public Sub Start()
    _backWorkerTimer = New BackgroundWorker
    _backWorkerTimer.WorkerReportsProgress = True
    _backWorkerTimer.WorkerSupportsCancellation = True
    _backWorkerTimer.RunWorkerAsync()
  End Sub

  Public Sub [Stop]()
    Me.Enabled = False
  End Sub

#End Region

#Region "New Constructor"

  Sub New()
    Me.Interval = 100
  End Sub

  Sub New(ByVal interval As Double)
    Me.Interval = interval
  End Sub

#End Region

#Region "Properties"

  Public Property AutoReset As Boolean
  Private pEnabled As Boolean
  Public Property Enabled() As Boolean
    Get
      Return pEnabled
    End Get
    Set(ByVal value As Boolean)
      If pEnabled <> value Then
        pEnabled = value
        If pEnabled Then RaiseEvent Tick(Me, EventArgs.Empty)
      End If
    End Set
  End Property
  Public Property Interval As Double

#End Region


  Private Sub _backWorkerTimer_DoWork(sender As Object, e As DoWorkEventArgs) Handles _backWorkerTimer.DoWork
    Try
      Dim sw As New Stopwatch
      sw.Start()

      While Not _backWorkerTimer.CancellationPending
        If sw.ElapsedMilliseconds >= Me.Interval Then
          Debug.Print("Ellapsed time " & sw.ElapsedMilliseconds)
          '_backWorkerTimer.ReportProgress(0)
          If Me.Enabled Then
            RaiseEvent Tick(Me, Nothing)
          End If
          sw.Reset()
          sw.Start()

        Else
          Threading.Thread.Sleep(1)
        End If
      End While
    Catch ex As Exception

    End Try
  End Sub

  Private Sub _backWorkerTimer_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles _backWorkerTimer.ProgressChanged
    If Me.Enabled Then
      RaiseEvent Tick(Me, Nothing)
    End If
  End Sub
End Class