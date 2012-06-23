
Partial Class Forms_error_permiso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('No tiene permisos para visualizar esta pagina');</script>", False)
        Response.Redirect("../default.aspx")

    End Sub
End Class
