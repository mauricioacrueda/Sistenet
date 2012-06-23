Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Forms_Bodegas
    Inherits System.Web.UI.Page
    Dim id_b As New Bodegas
    Dim acentos As New Auditoria
    Dim hk As New Bodegas
    Public Sub guardar()
        Try
            If Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.cbmuni.SelectedValue = "" Or Me.cbdep.Text = "Seleccionar..." Then
                Label1.Text = "Por favor diligencie todos los datos"
                Label1.ForeColor = Drawing.Color.Red
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                Exit Sub

            End If
            If accion.Value = 1 Then
                TextBox1.Text = hk.ingresar_bodega(UCase(acentos.quitarcaracteres(Me.TextBox2.Text)), Me.cbdep.SelectedValue, Me.cbmuni.SelectedValue, UCase(Me.TextBox3.Text), 1)
                llenar()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Se guardaron correctamente los datos');</script>", False)
                Label1.Text = "Se guardaron Correctamente los datos"
                Label1.ForeColor = Drawing.Color.Blue
                SetFocus(TextBox1)
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
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.cbmuni.SelectedValue = "" Or Me.TextBox3.Text = "" Or Me.cbdep.Text = "Seleccionar..." Then
            Response.Write("<Script language=javascript>alert('Por favor diligencie todos los campos!');</script>")
            Exit Sub

        End If
        Dim hk As New Bodegas
        hk.modificar_bodega(Trim(Me.TextBox1.Text), UCase(acentos.quitarcaracteres(Me.TextBox2.Text)), Me.cbdep.SelectedValue, Me.cbmuni.SelectedValue, UCase(Me.TextBox3.Text))
        llenar()
        Label1.Text = "registro modificado"
        Label1.ForeColor = Drawing.Color.Blue
    End Sub
    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Attributes.Add("onkeypress", "return AcceptNum(event)")
        btnguardar.Enabled = False
    End Sub
    Private Sub llena_combo()
        Dim objciu As New ciudades
        cbmuni.DataSource = objciu.consultar_ciudades.Tables(0)
        cbmuni.DataTextField = "nombre"
        cbmuni.DataValueField = "id"
        cbmuni.DataBind()

    End Sub
    Private Sub llena_combo_dep()
        Dim objdep As New Departamento
        cbdep.DataSource = objdep.consultar_departamento.Tables(0)
        cbdep.DataTextField = "nombre"
        cbdep.DataValueField = "codigo"
        cbdep.DataBind()
        cbdep.Items.Insert(0, "Seleccionar...")
    End Sub

    Public Sub llenar()
        GridView1.DataSource = id_b.consultar_bodega.Tables(0)
        GridView1.DataBind()
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Try

     
            Dim dep As String = GridView1.Rows(e.NewEditIndex).Cells(3).Text
            Label1.Text = ""
            accion.Value = 2
            cbdep.Text = GridView1.Rows(e.NewEditIndex).Cells(3).Text
            If IsPostBack Then

                Dim objciu As New ciudades
                Dim ds As New DataSet
                ds = objciu.consultar_ciu_por_depar(GridView1.Rows(e.NewEditIndex).Cells(3).Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    TextBox2.Enabled = True
                    TextBox3.Enabled = True
                    btnguardar.Enabled = True
                    btnguardar.Enabled = True
                    TextBox1.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(1).Text)
                    TextBox2.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(2).Text)
                    llena_combo_dep()
                    cbdep.SelectedValue = dep
                    cbmuni.DataSource = ds
                    cbmuni.DataTextField = "nombre"
                    cbmuni.DataValueField = "id"
                    cbmuni.DataBind()
                    cbmuni.SelectedValue = GridView1.Rows(e.NewEditIndex).Cells(4).Text
                    TextBox3.Text = Server.HtmlDecode(GridView1.Rows(e.NewEditIndex).Cells(5).Text)

                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('colocar aca el mensaje');</script>", False)
                End If

            End If
        Catch ex As Exception
            Dim au As New Auditoria
            au.fichero(ex.ToString)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio un Error, comuniquese con el Administrador');</script>", False)
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'oculta las columnas 

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(3).Visible = False  'Id Departamento
            e.Row.Cells(4).Visible = False ' Id Ciudad
            e.Row.Cells(6).Visible = False ' Id Ciudad
            GridView1.HeaderRow.Cells(3).Visible = False
            GridView1.HeaderRow.Cells(4).Visible = False
            GridView1.HeaderRow.Cells(6).Visible = False

        End If



    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        id_b.eliminar_bodega(GridView1.Rows(e.RowIndex).Cells(1).Text)
        llenar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Bodegas"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            TextBox1.Attributes.Add("onkeypress", "return AcceptNum(event)")
           'llenar()
            'llena_combo_dep()
            
            TextBox1.Attributes.Add("onkeypress", "return AcceptNum(event)")
            If IsPostBack = False Then
                'realizar al auditoria
                Dim objadi As New Auditoria
                Dim ds As New DataSet
                objadi.registro_auditoria(pagina, Session("login").ToString)
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                btnguardar.Enabled = False
            End If
        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        accion.Value = 1
        Label1.Text = ""
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        btnguardar.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        cbdep.Items.Clear()
        cbmuni.Items.Clear()
        llena_combo_dep()
    End Sub

    Protected Sub txtbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        'Busca Bodega en el evento clic

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
            Dim objbus As New Bodegas

            GridView1.DataSource = objbus.buscar_bodega(txtbus.Text).Tables(0)
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
            Dim objbus As New Bodegas

            GridView1.DataSource = objbus.buscar_bodega(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
            Label2.Visible = True
            Label2.Text = ex.Message
            Label2.ForeColor = Drawing.Color.Red

        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        'GridView1.PageIndex = e.NewPageIndex
        'GridView1.DataBind()
        GridView1.DataSource = id_b.consultar_bodega.Tables(0)
        GridView1.DataBind()
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub cbdep_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbdep.SelectedIndexChanged
        If IsPostBack Then

            Dim objciu As New ciudades

            cbmuni.DataSource = objciu.consultar_ciu_por_depar(cbdep.SelectedValue)
            cbmuni.DataTextField = "nombre"
            cbmuni.DataValueField = "id"
            cbmuni.DataBind()

        End If
    End Sub


    Protected Sub cbmuni_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbmuni.SelectedIndexChanged

    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.Attributes.Add("onkeypress", "return AcceptNum(event)")
    End Sub

    Protected Sub btnconsultodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsultodos.Click
        llenar()
    End Sub
End Class
