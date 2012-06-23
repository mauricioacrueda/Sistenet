Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Partial Class Reportes_ViewReporte_Orden
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p1 As New ParameterFields
        Dim p2 As New ParameterField
        Dim p3 As New ParameterDiscreteValue


        Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        rpt.Load(Server.MapPath("Reporte_Orden.rpt"))
        Me.CrystalReportViewer1.ReportSource = rpt

        p2.ParameterFieldName = "idorden"
        p3.Value = Integer.Parse(Request.QueryString("IdOrden"))
        p2.CurrentValues.Add(p3)
        p1.Add(p2)
        Me.CrystalReportViewer1.ParameterFieldInfo = p1

    End Sub
End Class
