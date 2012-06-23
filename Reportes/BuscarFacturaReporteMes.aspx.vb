Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.ReportSource
Partial Class Reportes_BuscarFacturaReporteMes
    Inherits System.Web.UI.Page

    Private Sub generar()


        Try
            ''-----Codigo OK---------------
            Dim p1 As New ParameterFields 'Con esta variable se envian todos los parametros al crystal report
            Dim p2 As New ParameterField
            Dim p3 As New ParameterDiscreteValue



            Dim nomparametro As New ParameterField
            Dim parametro As New ParameterDiscreteValue


            Dim nomparametro1 As New ParameterField
            Dim parametro1 As New ParameterDiscreteValue





            Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            rpt.Load(Server.MapPath("Reporte_FacturaMes.rpt"))
            'rpt.Load("D:\Dropbox\compartida\sistenet\Reportes\Reporte_CotizacionT.rpt")


            p2.ParameterFieldName = "@f1"
            p3.Value = txtfecha1.Text
            p2.CurrentValues.Add(p3)
            p1.Add(p2)



            nomparametro.ParameterFieldName = "@f2"
            parametro.Value = txtfecha2.Text
            nomparametro.CurrentValues.Add(parametro)
            p1.Add(nomparametro)




            ''carga el crystal report
            Me.CrystalReportViewer1.ReportSource = rpt


            Me.CrystalReportViewer1.ParameterFieldInfo = p1

        Catch ex As Exception
            Label1.ForeColor = Drawing.Color.Red
            Label1.Visible = True
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub btngenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerar.Click
        generar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'valida el permiso a la pagina
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)


        'Realiza la Auditoria
        If IsPostBack = False Then
            Dim pagina As String = "Reporte Ventas Mes"
            'realizar al auditoria
            Dim objaud As New Auditoria
            Dim dsa As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)

        End If
    End Sub
End Class
