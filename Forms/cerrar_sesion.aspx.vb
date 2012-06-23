Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Partial Class cerrar_sesion
    Inherits System.Web.UI.Page

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Cerrar Sesion"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            If IsPostBack = False Then
                'realizar al auditoria
                Dim objadi As New Auditoria
                Dim ds As New DataSet
                objadi.registro_auditoria(pagina, Session("login").ToString)
            End If
            Session.RemoveAll()
            Session.Abandon()
            'My.Response.Write("<script language='javascript'>alert('La sesion fue cerrada correctamente');</script>")
            My.Response.Write("<html><script> location='../default.aspx'; </script>")

            'Response.Redirect("../default.aspx")
        Catch ex As Exception
            My.Response.Write("	<script language = JavaScript>alert ('Se genero un error al cerrar la sesion');</script>")
        End Try
    End Sub
End Class
