Imports System.Data
Partial Class inicio_prueba
    Inherits System.Web.UI.Page
    Dim usuario As New inicio_sesion_cls

    Public Sub validar()

        usuario = New inicio_sesion_cls

        Dim ds As New DataSet

        ds = usuario.consultar_usuario(Me.Login1.UserName, Login1.Password)

        If ds.Tables(0).Rows.Count = 0 Then
            'ñññ

        Else

            Session("login") = ds.Tables(0).Rows(0).Item("usuario")
            Session("perfil") = ds.Tables(0).Rows(0).Item("codigo_perfil")
            Response.Redirect("~/Forms/inicio.aspx")


        End If
    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        validar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Login1.Focus()
    End Sub

End Class
