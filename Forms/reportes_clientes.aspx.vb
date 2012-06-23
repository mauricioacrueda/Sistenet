Partial Class Forms_reportes_clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'pasar parametro por querystring
        'MostrarPagina("../Reportes/ReportePedidos.aspx?ie=" & Integer.Parse(Me.Session("IdEmpresa")) & "&fi=" & txtFechaInicial.Text & "&ff=" & txtFechaFinal.Text & "&c=" & txtNombreCliente.Text & "&ip=" & Integer.Parse(ddlProductos.SelectedValue))

        'recuperar parametro de querystring
        'Dim idempresa As String = Request.QueryString("ie")

        MostrarPagina("../Reportes/ReporteClientes.aspx")


    End Sub


    Private Sub MostrarPagina(ByVal paginaNombre As String)
        Dim strgrafica As System.Text.StringBuilder = New System.Text.StringBuilder
        With strgrafica
            .Append("<script language='javascript'>")
            .Append("function abrir(){window.open('" & paginaNombre & "','Esto aparece','resizable=yes,toolbar=no,scrollbars=yes');}abrir();")
            .Append("</script>")
            ClientScript.RegisterStartupScript(Me.GetType(), "Ventana", strgrafica.ToString)
        End With
    End Sub
End Class