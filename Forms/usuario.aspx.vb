Imports Microsoft.VisualBasic
Imports System.Data
Partial Class Forms_usuario
    Inherits System.Web.UI.Page

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click

        Try


            If cbestado.Text = "Seleccionar..." Or Len(Trim(txtusu.Text)) = 0 Or Len(Trim(txtnom.Text)) = 0 Or Len(Trim(txtape.Text)) = 0 Or cbperfil.Text = "Seleccionar..." Or Len(Trim(txtpass.Text)) = 0 Or Len(Trim(txtconfirpass.Text)) = 0 Then
                Label1.Text = "Por favor Digite los Campos Obligatorios(*)"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                'habilitar()
                Exit Sub
            End If

            If txtpass.Text <> txtconfirpass.Text Then
                Label1.Text = "Las Contraseñas deben ser iguales"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub

            End If

            Dim ingresar As New usuario
            ingresar.ingresar_usuarios(Trim(Me.txtusu.Text), Me.txtpass.Text, Me.txtnom.Text, Me.txtape.Text, Me.txtema.Text, Me.cbperfil.SelectedValue, Me.cbestado.SelectedValue)
            Label1.Text = "Registro Guardado"
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue
            desabilitar()


        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red


        End Try

    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/usuario.aspx")
    End Sub

    Private Sub habilitar()
        txtusu.Enabled = True
        txtnom.Enabled = True
        txtape.Enabled = True
        txtema.Enabled = True
        txtpass.Enabled = True
        txtconfirpass.Enabled = True
        cbestado.Enabled = True
        cbperfil.Enabled = True
        btnguardar.Enabled = True

        txtusu.Text = ""
        txtnom.Text = ""
        txtape.Text = ""
        txtema.Text = ""
        txtpass.Text = ""
        txtconfirpass.Text = ""
        btnguardar.Enabled = True
        Label1.Visible = False




    End Sub

    Private Sub desabilitar()

        txtusu.Enabled = False
        txtnom.Enabled = False
        txtape.Enabled = False
        txtema.Enabled = False
        txtpass.Enabled = False
        txtconfirpass.Enabled = False
        cbestado.Enabled = False
        cbperfil.Enabled = False
        btnguardar.Enabled = False

    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        habilitar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida el permiso a lapagina
        Dim pagina As String = "usuario"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
        'validad auditoria
        Dim objadi As New Auditoria
        Dim ds As New DataSet
        objadi.registro_auditoria(pagina, Session("login").ToString)
        If Not IsPostBack Then
            Dim obj As New perfil
            cbperfil.DataSource = obj.consultar_perfiles.Tables(0)
            cbperfil.DataTextField = "nombre_perfil"
            cbperfil.DataValueField = "codigo_perfil"
            cbperfil.DataBind()
            cbperfil.Items.Insert(0, "Seleccionar...")

        End If
        If IsPostBack = False Then
            'realizar al auditoria
            Dim objaud As New Auditoria
            ' Dim ds As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)
            desabilitar()
        End If
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/inicio.aspx")
    End Sub
End Class
