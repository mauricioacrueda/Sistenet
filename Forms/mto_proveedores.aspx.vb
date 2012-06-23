Imports System.Data
Partial Class Forms_mto_proveedores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida el permiso a lapagina
        Dim pagina As String = "Actualizar_Proveedor"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)



        'deshabilitar()
        btnnuevo.Enabled = True

        If IsPostBack = False Then
            'realizar al auditoria
            Dim objaud As New Auditoria
            Dim ds As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)
            'Cargar el combo de Departamentos
            consular_departamento()
        End If


    End Sub
    Private Sub llenar_grilla()

        Dim objprovee As New proveedor
        GridView1.DataSource = objprovee.consultar_proveedor.Tables(0)
        GridView1.DataBind()


    End Sub
    Private Sub nuevo()
        txtced.Text = ""
        txtdir.Text = ""
        txtema.Text = ""
        txtnom.Text = ""
        txttel.Text = ""
        Label1.Text = ""
        Label1.Visible = False

        cbestado.ClearSelection()
        cbdepar.ClearSelection()
        cbciu.DataSource = ""
        cbciu.DataBind()

    End Sub
    Private Sub habilitar()
        txtced.Enabled = True
        txtdir.Enabled = True
        txtema.Enabled = True
        txtnom.Enabled = True
        txttel.Enabled = True

        cbestado.Enabled = True
        cbdepar.Enabled = True
        cbciu.Enabled = True
    End Sub

    Private Sub deshabilitar()

        txtced.Enabled = False
        txtdir.Enabled = False
        txtema.Enabled = False
        txtnom.Enabled = False
        txttel.Enabled = False

        cbestado.Enabled = False
        cbdepar.Enabled = False
        cbciu.Enabled = False


    End Sub
    Private Sub consular_departamento()
        Dim objdepar As New Departamento

        cbdepar.DataSource = objdepar.consultar_departamento.Tables(0)
        cbdepar.DataTextField = "nombre"
        cbdepar.DataValueField = "codigo"
        cbdepar.DataBind()

    End Sub

    Protected Sub btnconsultall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnconsultall.Click
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
        'oculta las columnas 6,8

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(6).Visible = False  'Id Departamento
            e.Row.Cells(8).Visible = False ' Id Ciudad
            GridView1.HeaderRow.Cells(6).Visible = False
            GridView1.HeaderRow.Cells(8).Visible = False

            'GridView1.HeaderRow.Cells(2).Text = "Razon Social"

        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Try

            Label1.Visible = False

            Dim del As New proveedor
            del.eliminar_proveedor(GridView1.Rows(e.RowIndex).Cells(1).Text)

            Label1.Text = "Registro Eliminado"
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue

            '' Llena la grilla vacia

            GridView1.Dispose()
            GridView1.DataBind()


        Catch ex As Exception
            Label1.ForeColor = Drawing.Color.Red
            Label1.Visible = True
            Label1.Text = ex.Message

        End Try
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Try
            Label1.Visible = False

            habilitar()
            txtced.Text = GridView1.Rows(e.NewEditIndex).Cells(1).Text.ToString
            txtnom.Text = GridView1.Rows(e.NewEditIndex).Cells(2).Text.ToString
            txtdir.Text = GridView1.Rows(e.NewEditIndex).Cells(3).Text.ToString
            txttel.Text = GridView1.Rows(e.NewEditIndex).Cells(4).Text.ToString
            txtema.Text = GridView1.Rows(e.NewEditIndex).Cells(5).Text.ToString
            cbdepar.Text = GridView1.Rows(e.NewEditIndex).Cells(6).Text

            txtdir.Text = txtdir.Text.Replace("&nbsp;", "")
            txttel.Text = txttel.Text.Replace("&nbsp;", "")
            txtema.Text = txtema.Text.Replace("&nbsp;", "")


            ''Llena el Cbmuni con las ciudades correspondientes al departamento para despues
            ''para poder colocar el cbmuni.Text que corresponde al cliente
            Dim objciudades As New ciudades

            cbciu.DataSource = objciudades.consultar_ciu_por_depar(GridView1.Rows(e.NewEditIndex).Cells(6).Text)
            cbciu.DataTextField = "nombre"
            cbciu.DataValueField = "id"
            cbciu.DataBind()
            cbciu.Text = GridView1.Rows(e.NewEditIndex).Cells(8).Text
            habilitar()
            txtced.Enabled = False
            btnnuevo.Enabled = False


            'Busca por el nit el estado del proveedor para colocarlo en el cbestado.selectedvalue
            Dim objconsulestado As New proveedor
            Dim ds As New DataSet
            cbestado.Dispose()
            ds = objconsulestado.buscar_provee(GridView1.Rows(e.NewEditIndex).Cells(1).Text)
            cbestado.SelectedValue = ds.Tables(0).Rows(0).Item("estado")



        Catch ex As Exception
            Label1.ForeColor = Drawing.Color.Red
            Label1.Visible = True
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub cbdepar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbdepar.SelectedIndexChanged
        If IsPostBack Then

            Dim objciu As New ciudades

            cbciu.DataSource = objciu.consultar_ciu_por_depar(cbdepar.SelectedValue)
            cbciu.DataTextField = "nombre"
            cbciu.DataValueField = "id"
            cbciu.DataBind()


        End If
    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        Try


            If cbestado.Text = "" Or Len(Trim(txtnom.Text)) = 0 Or Len(Trim(txtdir.Text)) = 0 Or cbdepar.Text = "" Then
                Label1.Text = "Por favor Seleccione el Proveedor a Modificar"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub
            End If


            Dim objmodifiprovee As New proveedor
            Dim caracterespecial As New Auditoria
            objmodifiprovee.modificar_proveedor(Trim(txtced.Text), UCase(caracterespecial.quitarcaracteres(txtnom.Text)), UCase(caracterespecial.quitarcaracteres(txtdir.Text)), caracterespecial.quitarcaracteres(txttel.Text), txtema.Text, cbciu.SelectedValue, cbestado.SelectedValue)
            Label1.Text = "Registro Modificado"
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue
            deshabilitar()

            ' Muestra el proveedor con los nuevos datos despues de modificar

            Dim objbusdepuesdemodifi As New proveedor

            GridView1.DataSource = objbusdepuesdemodifi.buscar_provee(txtced.Text).Tables(0)
            GridView1.DataBind()


        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red

        End Try
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        'Busca clientes en el evento clic

        Label1.Visible = False

        Try

            If Len(Trim(txtbus.Text)) = 0 Then

                Label1.Text = "No Existe Criterio para Buscar"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub

            End If

            Label1.Visible = False
            Dim objbus As New proveedor

            GridView1.DataSource = objbus.buscar_provee(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Blue

        End Try
    End Sub

    Protected Sub txtbus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbus.TextChanged
        'Busca clientes en el evento textcnague o  Enter

        Label1.Visible = False

        Try

            If Len(Trim(txtbus.Text)) = 0 Then

                Label1.Text = "No Existe Criterio para Buscar"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub

            End If

            Label1.Visible = False
            Dim objbus As New proveedor

            GridView1.DataSource = objbus.buscar_provee(txtbus.Text).Tables(0)
            GridView1.DataBind()

        Catch ex As Exception

            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Blue

        End Try
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click

    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/proveedores.aspx")
    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        nuevo()

    End Sub
End Class
