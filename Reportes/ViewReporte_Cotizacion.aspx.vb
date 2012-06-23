Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.ReportSource
Partial Class Reportes_ViewReporte_Cotizacion
    Inherits System.Web.UI.Page

    Protected Sub CrystalReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Init



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim p1 As New ParameterFields
        Dim p2 As New ParameterField
        Dim p3 As New ParameterDiscreteValue


        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        rpt.Load(Server.MapPath("Reporte_Cotzacion_.rpt"))
        Me.CrystalReportViewer1.ReportSource = rpt

        p2.ParameterFieldName = "idcotiza"
        p3.Value = Integer.Parse(Request.QueryString("IdCoti"))
        p2.CurrentValues.Add(p3)
        p1.Add(p2)
        Me.CrystalReportViewer1.ParameterFieldInfo = p1



    End Sub

End Class
