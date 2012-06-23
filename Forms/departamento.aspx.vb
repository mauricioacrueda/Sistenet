Imports System.Data
Imports System.Data.SqlClient
Partial Class Forms_departamento
    Inherits System.Web.UI.Page
    Dim id_d As New Departamento

    Public Sub guardar()
        Try
            If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Then
                Label1.Text = "Por favor diligencie todos los datos"
                Label1.ForeColor = Drawing.Color.Blue
                TextBox2.Enabled = True
                Exit Sub

            End If
            If accion.Value = 1 Then
                Dim hk As New Departamento
                hk.ingresar_departamento(Me.TextBox1.Text, UCase(Me.TextBox2.Text))
                Label1.Text = "Departamento Guardado Correctamente"
                Label1.ForeColor = Drawing.Color.Blue
            ElseIf accion.Value = 2 Then
                modificar()
                llenar()
            End If
        Catch ex As Exception
            llenar()
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    Public Sub modificar()
        TextBox1.Enabled = False
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Then
            Response.Write("<Script language=javascript>alert('Por favor diligencie todos los campos!');</script>")
            Exit Sub

        End If
        Dim hk As New Departamento
        hk.modificar_departamento(Me.TextBox1.Text, UCase(Me.TextBox2.Text))
        Label1.Text = "registro modificado"
        Label1.ForeColor = Drawing.Color.Blue
        llenar()
    End Sub
    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar()
    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        accion.Value = 1
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        btnnuevo.Enabled = True
        btnguardar.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        id_d.eliminar_departamento(Convert.ToString(GridView1.Rows(e.RowIndex).Cells(1).Text))
        llenar()
    End Sub


    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        accion.Value = 2
        TextBox2.Enabled = True
        btnguardar.Enabled = True
        TextBox1.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(1).Text)
        TextBox2.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(2).Text)
        'TextBox1.Text = GridView1.Rows(e.NewEditIndex).Cells(1).Text
        'TextBox2.Text = GridView1.Rows(e.NewEditIndex).Cells(2).Text
    
    End Sub
    Public Sub llenar()
        GridView1.DataSource = id_d.consultar_departamento.Tables(0)
        GridView1.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Departamento"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            If IsPostBack = False Then
                'realizar al auditoria
                Dim objadi As New Auditoria
                Dim ds As New DataSet
                objadi.registro_auditoria(pagina, Session("login").ToString)

            End If
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            btnguardar.Enabled = False
            Label1.Text = ""
            Label2.Text = ""
        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub
  
    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        'Busca clientes en el evento clic

        Label1.Visible = False

        Try

            If Len(Trim(txtbus.Text)) = 0 Then
                llenar()
                Label2.Text = "No Existe Criterio para Buscar"
                Label2.ForeColor = Drawing.Color.Red
                Label2.Visible = True

                Exit Sub

            End If

            Label2.Visible = False
            Dim objbus As New Departamento

            GridView1.DataSource = objbus.buscar_departamento(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Blue

        End Try
    End Sub

    Protected Sub txtbus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbus.TextChanged
        'Busca clientes en el evento TextChanged

        Label1.Visible = False
        Try

            If Len(Trim(txtbus.Text)) = 0 Then
                llenar()
                Label2.Text = "No Existe Criterio para Buscar"
                Label2.ForeColor = Drawing.Color.Red
                Label2.Visible = True

                Exit Sub

            End If


            btnbuscar.Focus()
            Label2.Visible = False
            Dim objbus As New Departamento

            GridView1.DataSource = objbus.buscar_departamento(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Blue

        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub btnconsultodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsultodos.Click
        llenar()
    End Sub
    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/inicio.aspx")
    End Sub
End Class
