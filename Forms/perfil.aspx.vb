
Partial Class Forms_perfil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pagina As String = "perfil.aspx"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
        If IsPostBack = False Then
            'realizar al auditoria
            Dim objaud As New Auditoria
            ' Dim ds As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)
        End If
    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click

        Try

            If Len(Trim(txtnom.Text)) = 0 Then
                Label1.Text = "Debe Escribir un Nombre"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub
            End If


            If accion.Value = 1 Then

                Dim objperfil As New perfil

                txtcod.Text = objperfil.ingresar_perfil(UCase(txtnom.Text))
                Label1.Text = "Registro Guardado"
                Label1.ForeColor = Drawing.Color.Blue
                Label1.Visible = True
                llenar_grilla()

                btnnuevo.Enabled = True
                btnguardar.Enabled = False
                txtnom.Enabled = False

            ElseIf accion.Value = 2 Then

                Dim objperfil As New perfil

                objperfil.modificar_perfil(txtcod.Text, UCase(txtnom.Text))
                Label1.Text = "Registro Actualizado"
                Label1.ForeColor = Drawing.Color.Blue
                Label1.Visible = True
                llenar_grilla()

                btnnuevo.Enabled = True
                btnguardar.Enabled = False
                txtnom.Enabled = False

            End If

        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
            Label1.Visible = True
        End Try


    End Sub

    Public Sub llenar_grilla()

        Dim objper As New perfil

        GridView1.DataSource = objper.consultar_perfiles.Tables(0)
        GridView1.DataBind()


    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        accion.Value = 1 ''variabñe que indica que se realizara un Insert

        btnnuevo.Enabled = False
        btnguardar.Enabled = True
        txtnom.Enabled = True
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Try

            Dim objelimi As New perfil
            objelimi.eliminar_perfil(GridView1.Rows(e.RowIndex).Cells(1).Text.ToString)
            Label1.Text = "Registro Eliminado"
            Label1.ForeColor = Drawing.Color.Blue
            Label1.Visible = True
            llenar_grilla()

        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
            Label1.Visible = True
        End Try
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Try

   
            accion.Value = 2 ''variabñe que indica que se realizara un Update
            btnnuevo.Enabled = False
            btnguardar.Enabled = True
            txtnom.Enabled = True

            txtcod.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(1).Text.ToString)
            txtnom.Text = GridView1.Rows(e.NewEditIndex).Cells(2).Text.ToString
        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
            Label1.Visible = True
        End Try

    End Sub
End Class
