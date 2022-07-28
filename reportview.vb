Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class laporan
    Dim reportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo

    Private Sub laporan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized

        reportDocument.Load(Application.StartupPath & "\rpthasil.rpt")
        With ConInfo.ConnectionInfo
            .UserID = "Admin"
            .ServerName = Application.StartupPath & "\promethee.mdb"
            .DatabaseName = Application.StartupPath & "\promethee.mdb"
            .IntegratedSecurity = True
        End With
        For intCounter As Integer = 0 To reportDocument.Database.Tables.Count - 1
            reportDocument.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        Next

        reportDocument.RecordSelectionFormula = ""
        crv.ReportSource = reportDocument

    End Sub
End Class
