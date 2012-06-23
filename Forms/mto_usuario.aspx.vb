Imports System.Data
Partial Class Forms_mto_usuario
    Inherits System.Web.UI.Page

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click

        Try


            If cbestado.Text = "Seleccionar..." Or Len(Trim(txtusu.Text)) = 0 Or Len(Trim(txtnom.Text)) = 0 Or Len(Trim(txtape.Text)) = 0 Or cbperfil.Text = "Seleccionar..." Then
                Label1.Text = "Por favor Digite los Campos Obligatorios(*)"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub
            End If

            If txtpass.Text <> txtconfirpass.Text Then
                Label1.Text = "Las Contraseñas deben ser iguales"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub

            End If

            Dim objmodifiusu As New usuario
            objmodifiusu.modificar_usuario(Trim(Me.txtusu.Text), Me.txtpass.Text, Me.txtnom.Text, Me.txtape.Text, Me.txtema.Text, Me.cbperfil.SelectedValue, Me.cbestado.SelectedValue)
            Label1.Text = "Registro Modificado"
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue
            deshabilitar()

            '' Muestra el usuario con los nuevos datos despues de modificar

            Dim objbusdepuesdemodifi As New usuario

            GridView1.DataSource = objbusdepuesdemodifi.buscar_usuario(txtusu.Text).Tables(0)
            GridView1.DataBind()


        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red

        End Try

    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/usuario.aspx")
    End Sub
    Private Sub llenar_grilla()

        Dim objusu As New usuario
        GridView1.DataSource = objusu.consultar_usuarios.Tables(0)
        GridView1.DataBind()


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
        cbestado.DataTextField = "Seleccionar..."
        cbperfil.DataTextField = "Seleccionar..."
        btnguardar.Enabled = True

    End Sub

    Private Sub deshabilitar()

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

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        'Busca clientes en el evento clic

        Label1.Visible = False

        Try

            If Len(Trim(txtbus.Text)) = 0 Then

                Label2.Text = "No Existe Criterio para Buscar"
                Label2.ForeColor = Drawing.Color.Red
                Label2.Visible = True

                Exit Sub

            End If

            Label2.Visible = False
            Dim objbus As New usuario

            GridView1.DataSource = objbus.buscar_usuario(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Red

        End Try
    End Sub

    Protected Sub btnconsultartodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsultartodos.Click
        llenar_grilla()
    End Sub

    Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        llenar_grilla()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(6).Visible = False  'Id Departamento
            GridView1.HeaderRow.Cells(6).Visible = False
            'GridView1.HeaderRow.Cells(2).Text = "Razon Social"


        End If


    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        Try


            Label1.Visible = False

            habilitar()
            txtusu.Enabled = False
            txtusu.Text = GridView1.Rows(e.NewEditIndex).Cells(1).Text
            txtnom.Text = GridView1.Rows(e.NewEditIndex).Cells(2).Text
            txtape.Text = GridView1.Rows(e.NewEditIndex).Cells(3).Text
            txtema.Text = GridView1.Rows(e.NewEditIndex).Cells(4).Text
            cbperfil.SelectedValue = GridView1.Rows(e.NewEditIndex).Cells(6).Text

            txtema.Text = txtema.Text.Replace("&nbsp;", "")

            Dim objconsulestado As New usuario
            Dim ds As New DataSet
            cbestado.Dispose()
            ds = objconsulestado.buscar_usuario(GridView1.Rows(e.NewEditIndex).Cells(1).Text)
            cbestado.SelectedValue = ds.Tables(0).Rows(0).Item("estado")


        Catch ex As Exception
            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Red
        End Try



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida permiso a pagina
        Dim pagina As String = "Actualizar_Usuario"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)


        btnnuevo.Enabled = True

        'llena el cboerfil con los perfiles del sistema
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
            Dim ds As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/inicio.aspx")
    End Sub
End Class
