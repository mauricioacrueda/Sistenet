Imports System.Data
Partial Class Forms_Productos
    Inherits System.Web.UI.Page
    Dim id_p As New Productos

    Protected Sub btnconsultodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsultodos.Click
        GridView1.DataSource = id_p.consultar_producto.Tables(0)
        GridView1.DataBind()
    End Sub

    Protected Sub btnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnuevo.Click
        accion.Value = 1
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Label1.Text = ""
        Label2.Text = ""
    End Sub
    Private Sub guardar()
        Try
            If Me.TextBox5.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Then
                Label1.Text = "Por favor diligencie todos los datos"
                Label1.ForeColor = Drawing.Color.Red
                Exit Sub

            End If
            If accion.Value = 1 Then
                Dim hk As New Productos
                hk.ingresar_producto(Trim(UCase(Me.TextBox5.Text)), UCase(Me.TextBox2.Text), Me.TextBox3.Text, UCase(Me.TextBox4.Text))
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('El producto se ingresaron Correctamente');</script>", False)
                llenar()
                SetFocus(TextBox5)
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                Label1.Text = ""
                TextBox3.Attributes.Add("onkeypress", "return AcceptNum(event)")
                TextBox1.Attributes.Add("onkeypress", "return AcceptNum(event)")
                Label2.Text = ""
            ElseIf accion.Value = 2 Then
                modificar()
                llenar()
            End If
        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
            SetFocus(TextBox5)
        End Try
    End Sub
    Public Sub modificar()
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Then
            Response.Write("<Script language=javascript>alert('Por favor diligencie todos los campos!');</script>")
            Exit Sub

        End If
        Dim hk As New Productos
        hk.modificar_producto(Me.TextBox1.Text, Trim(Me.TextBox5.Text), UCase(Me.TextBox2.Text), Me.TextBox3.Text, UCase(Me.TextBox4.Text))
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Se Modificaron Correctamente los datos');</script>", False)
        llenar()
        Label1.Text = "registro modificado"
        Label1.ForeColor = Drawing.Color.Blue
    End Sub
    Public Sub llenar()
        GridView1.DataSource = id_p.consultar_producto.Tables(0)
        GridView1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Productos"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            
            If IsPostBack = False Then
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                Label1.Text = ""
                TextBox3.Attributes.Add("onkeypress", "return AcceptNum(event)")
                TextBox1.Attributes.Add("onkeypress", "return AcceptNum(event)")
                Label2.Text = ""
                'realizar al auditoria
                Dim objaud As New Auditoria
                Dim ds As New DataSet
                objaud.registro_auditoria(pagina, Session("login").ToString)
            End If
        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar()
        accion.Value = 1
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        accion.Value = 2
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox1.Text = GridView1.Rows(e.NewEditIndex).Cells(1).Text
        TextBox5.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(2).Text)
        TextBox2.Text = GridView1.Rows(e.NewEditIndex).Cells(3).Text
        TextBox3.Text = GridView1.Rows(e.NewEditIndex).Cells(4).Text
        TextBox4.Text = GridView1.Rows(e.NewEditIndex).Cells(5).Text

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting



        id_p.eliminar_producto(GridView1.Rows(e.RowIndex).Cells(1).Text)
        llenar()
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        'Busca clientes en el evento clic

        Label1.Visible = False

        Try

            If Len(Trim(txtbus.Text)) = 0 Then

                Label2.Text = "No Existe Criterio para Buscar"
                llenar()
                Label2.ForeColor = Drawing.Color.Red
                Label2.Visible = True

                Exit Sub

            End If

            Label2.Visible = False
            Dim objbus As New Productos

            GridView1.DataSource = objbus.buscar_producto(txtbus.Text).Tables(0)
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

                Label2.Text = "No Existe Criterio para Buscar"
                llenar()
                Label2.ForeColor = Drawing.Color.Red
                Label2.Visible = True

                Exit Sub

            End If


            btnbuscar.Focus()
            Label2.Visible = False
            Dim objbus As New Productos

            GridView1.DataSource = objbus.buscar_producto(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Blue

        End Try
    End Sub

 
    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    Select Case e.Row.RowType
    '        Case DataControlRowType.DataRow

    '            Dim ctrlEliminar As LinkButton = CType(e.Row.Cells(1).Controls(0), LinkButton)
    '            ctrlEliminar.OnClientClick = "return confirm('¿Esta seguro de eliminar este registro?');"

    '    End Select
    'End Sub

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    If e.CommandName = "EliminarP" Then
    '        id_p.eliminar_producto(GridView1.DataKeys(0).Value)
    '        llenar()
    '    End If
    'End Sub
End Class
