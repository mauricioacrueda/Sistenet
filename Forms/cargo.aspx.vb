Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Partial Class Forms_cargo
    Inherits System.Web.UI.Page
    Dim id_ca As New cargo
    Dim acentos As New Auditoria

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btguardar.Click
        guardar()
    End Sub

    Public Sub guardar()
        Try
            If Me.TextBox2.Text = "" Or Me.cbtipo.SelectedValue = "" Then
                Label1.Text = "Por favor diligencie todos lo datos"
                Label1.ForeColor = Drawing.Color.Red
                TextBox2.Enabled = True
                TextBox1.Focus()
                Exit Sub

            End If
            If accion.Value = 1 Then
                Dim hk As New cargo
                hk.ingresar_cargo(acentos.quitarcaracteres(UCase(Me.TextBox2.Text)), UCase(Me.cbtipo.SelectedValue))
                llenar()
            ElseIf accion.Value = 2 Then
                modificar()
                llenar()
            End If
        Catch ex As Exception
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
        Dim hk As New cargo
        hk.modificar_cargo(Trim(Me.TextBox1.Text), UCase(acentos.quitarcaracteres((Me.TextBox2.Text))), UCase(cbtipo.SelectedValue))
        Label1.Text = "registro modificado"
        Label1.ForeColor = Drawing.Color.Blue
        llenar()
        TextBox1.Focus()
    End Sub
    Public Sub llenar()
        GridView1.DataSource = id_ca.consultar_cargo.Tables(0)
        GridView1.DataBind()
    End Sub

    Protected Sub txtbus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbus.TextChanged
        'Label2.Visible = False
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
            Dim objbus As New cargo

            GridView1.DataSource = objbus.buscar_cargo(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Blue
        End Try
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        ' Label1.Visible = False
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
            Dim objbus As New cargo

            GridView1.DataSource = objbus.buscar_cargo(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Blue
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Cargo"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            If IsPostBack = False Then
                'realizar al auditoria
                Dim objadi As New Auditoria
                Dim ds As New DataSet
                objadi.registro_auditoria(pagina, Session("login").ToString)
            End If
            TextBox1.Attributes.Add("onkeypress", "return AcceptNum(event)")
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            btguardar.Enabled = False
        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        accion.Value = 1
        TextBox2.Enabled = True
        Label1.Text = ""
        Label2.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        btguardar.Enabled = True
    End Sub

    Protected Sub btnconsultodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsultodos.Click
        llenar()
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        accion.Value = 2
        TextBox2.Enabled = True
        TextBox1.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(1).Text)
        TextBox2.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(2).Text)
        cbtipo.Text = GridView1.Rows(e.NewEditIndex).Cells(3).Text
        TextBox2.Focus()
        btguardar.Enabled = True
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        id_ca.eliminar_cargo(GridView1.Rows(e.RowIndex).Cells(1).Text)
        llenar()
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        ' ''oculta las columnas 2 Identificador del Cargo
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    e.Row.Cells(4).Visible = False
        '    GridView1.HeaderRow.Cells(4).Visible = False
        'End If
    End Sub
End Class

