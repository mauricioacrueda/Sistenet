Imports System.Data
Partial Class Forms_cambiar_clave
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pagina As String = "Cambiar_Clave"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
        If IsPostBack = False Then
            'realizar al auditoria
            Dim objadi As New Auditoria
            Dim ds As New DataSet
            objadi.registro_auditoria(pagina, Session("login").ToString)

        End If

    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        Try

            If Len(Trim(txtpass.Text)) = 0 Or Len(Trim(txtpassnue.Text)) = 0 Or Len(Trim(txtconfirpass.Text)) = 0 Then
                Label1.Text = "Por favor Digite los Campos Obligatorios(*)"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub
            End If

            If txtpassnue.Text <> txtconfirpass.Text Then
                Label1.Text = "Las Contraseñas deben ser iguales"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub

            End If


            Dim objusu As New usuario

            objusu.cambiar_clave(txtpass.Text, Session("login".ToString), txtpassnue.Text)
            Label1.Text = "Clave Actualzada"
            Label1.ForeColor = Drawing.Color.Blue
            Label1.Visible = True


        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
        End Try
        



    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/cambiar_clave.aspx")
    End Sub
End Class
