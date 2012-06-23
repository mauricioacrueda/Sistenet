Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Partial Class Forms_Empleado
    Inherits System.Web.UI.Page
    Dim id_e As New empleados
    Dim acentos As New Auditoria


    Public Sub guardar()
        Try
            If Me.TextBox1.Text = "" Or Me.txtnom.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Or Me.TextBox5.Text = "" Or Me.cbcar.SelectedValue = "" Or Me.cbcar.Text = "" Then
                Label1.Text = "Por favor diligencie todos los datos"
                Label1.ForeColor = Drawing.Color.Red
                txtnom.Enabled = True
                Exit Sub

            End If
            If accion.Value = 1 Then
                Dim hk As New empleados
                hk.ingresar_empleado(Trim(Me.TextBox1.Text), acentos.quitarcaracteres(UCase(Me.txtnom.Text)), acentos.quitarcaracteres((UCase(Me.TextBox3.Text))), UCase(Me.TextBox4.Text), UCase(Me.TextBox5.Text), UCase(Me.TextBox6.Text), Me.cbcar.SelectedValue)
                Label1.Text = "Los datos se ingresaron correctamente"
                Label1.ForeColor = Drawing.Color.Blue
                llenar()
                TextBox1.Focus()
            ElseIf accion.Value = 2 Then
                modificar()
                llenar()
            End If
        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
            TextBox1.Focus()
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
        End Try
    End Sub
    Public Sub modificar()
        TextBox1.Enabled = False
        If Me.TextBox1.Text = "" Or Me.txtnom.Text = "" Or Me.cbcar.SelectedValue = "" Then
            Response.Write("<Script language=javascript>alert('Por favor diligencie todos los campos!');</script>")
            Exit Sub
        End If
        Dim hk As New empleados
        hk.modificar_empleado(Me.ViewState("id"), acentos.quitarcaracteres(acentos.quitarcaracteres(Trim(Me.TextBox1.Text))), acentos.quitarcaracteres(UCase(Me.txtnom.Text)), acentos.quitarcaracteres(UCase(Me.TextBox3.Text)), UCase(Me.TextBox4.Text), UCase(Me.TextBox5.Text), UCase(Me.TextBox6.Text.Trim), Me.cbcar.SelectedValue)
        llenar()
        Label1.Text = "registro modificado"
        Label1.ForeColor = Drawing.Color.Blue
    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        accion.Value = 1
        Label1.Text = ""
        Label2.Text = ""
        TextBox1.Enabled = True
        txtnom.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox1.Text = ""
        txtnom.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Empleado"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            If IsPostBack = False Then
                'realizar al auditoria
                Dim objaud As New Auditoria
                Dim ds As New DataSet
                objaud.registro_auditoria(pagina, Session("login").ToString)
                llena_combo()
                TextBox1.Enabled = False
                txtnom.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                btnnuevo.Enabled = True
            End If


        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub

    Private Sub llena_combo()
        If IsPostBack = False Then
            Dim objcar As New empleados
            cbcar.DataSource = objcar.consultar_cargo.Tables(0)
            cbcar.DataTextField = "nombre"
            cbcar.DataValueField = "id"
            cbcar.DataBind()
            cbcar.Items.Insert(0, "Seleccionar....")
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        accion.Value = 2
        TextBox1.Enabled = True
        txtnom.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        Label1.Text = ""
        Label2.Text = ""
        Me.ViewState("id") = GridView1.Rows(e.NewEditIndex).Cells(1).Text
        cbcar.SelectedValue = GridView1.Rows(e.NewEditIndex).Cells(9).Text
        TextBox1.Text = GridView1.Rows(e.NewEditIndex).Cells(2).Text
        txtnom.Text = GridView1.Rows(e.NewEditIndex).Cells(4).Text
        TextBox3.Text = GridView1.Rows(e.NewEditIndex).Cells(5).Text
        TextBox4.Text = GridView1.Rows(e.NewEditIndex).Cells(6).Text
        TextBox5.Text = GridView1.Rows(e.NewEditIndex).Cells(7).Text
        'TextBox6.Text = GridView1.Rows(e.NewEditIndex).Cells(8).Text
        TextBox6.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(8).Text.ToString)
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        ''oculta las columnas 7 Identificador del Cargo
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(1).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(9).Visible = False
            GridView1.HeaderRow.Cells(1).Visible = False
            GridView1.HeaderRow.Cells(4).Visible = False
            GridView1.HeaderRow.Cells(5).Visible = False
            GridView1.HeaderRow.Cells(9).Visible = False
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        id_e.eliminar_empleado(GridView1.Rows(e.RowIndex).Cells(2).Text)
        llenar()
    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar()
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
            Dim objbus As New empleados

            GridView1.DataSource = objbus.buscar_empleado(txtbus.Text).Tables(0)
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
    Public Sub llenar()
        GridView1.DataSource = id_e.consultar_empleado.Tables(0)
        GridView1.DataBind()
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
            Dim objbus As New empleados

            GridView1.DataSource = objbus.buscar_empleado(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Blue

        End Try
    End Sub

    Protected Sub cbdep_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbcar.SelectedIndexChanged

    End Sub

    Protected Sub txtnom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnom.TextChanged

    End Sub

    Protected Sub btnconsultodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsultodos.Click
        llenar()
    End Sub
    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/inicio.aspx")
    End Sub
End Class
