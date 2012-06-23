Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Partial Class Forms_inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        '    'valida el permiso a la pagina
        '    Dim pagina As String = "inicio"
        '    Dim objpermi As New usuario
        '    objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
        '    'Realiza la Auditoria
        '    Dim objadi As New Auditoria
        '    Dim ds As New DataSet
        '    objadi.registro_auditoria(pagina, Session("login").ToString)

        'Catch ex As Exception
        '    Label1.Visible = True
        '    Label1.ForeColor = Drawing.Color.Red
        '    Label1.Text = ex.Message
        'End Try
    End Sub
End Class
