Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.ReportSource
Partial Class Reportes_BuscarOrdenReporte
    Inherits System.Web.UI.Page

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Try

            Label1.Visible = False

            ''obtener el id del cliente
            ''Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenacli As String = txtcliente.Text
            For i = 1 To Len(Cadenacli)

                If Mid(Cadenacli, i, 1) = " " Then
                    idcli.Value = Trim(Left(Cadenacli, i))
                    Exit For
                End If
            Next
            ''FIN

            ''-----Codigo OK---------------
            Dim p1 As New ParameterFields 'Con esta variable se envian todos los parametros al crystal report
            Dim p2 As New ParameterField
            Dim p3 As New ParameterDiscreteValue


            'Dim VarTodoEnviar As New ParameterFields
            Dim nomparametro As New ParameterField
            Dim parametro As New ParameterDiscreteValue

            'Dim VarTodoEnviar1 As New ParameterFields
            Dim nomparametro1 As New ParameterField
            Dim parametro1 As New ParameterDiscreteValue


            Dim cliente As String = idcli.Value



            Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            rpt.Load(Server.MapPath("Reporte_OrdenT.rpt"))
            'rpt.Load("D:\Dropbox\compartida\sistenet\Reportes\Reporte_CotizacionT.rpt")


            If Len(Trim(cliente)) = 0 Then
                cliente = "0"
            End If


            nomparametro1.ParameterFieldName = "@idcli"
            parametro1.Value = cliente
            nomparametro1.CurrentValues.Add(parametro1)
            p1.Add(nomparametro1)



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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If IsPostBack = False Then
            ''valida el permiso a la pagina
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)


            'realizar al auditoria
            Dim objadi As New Auditoria
            Dim pagina As String = "BuscarOrdenReporte"
            objadi.registro_auditoria(pagina, Session("login").ToString)


        End If


    End Sub
End Class
