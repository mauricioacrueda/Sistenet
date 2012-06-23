Imports Microsoft.VisualBasic
Imports System.Data
Partial Class Forms_proveedores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida el permiso a lapagina
        Dim pagina As String = "Proveedore"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)





        'carga los departamentos en el combo
        If IsPostBack = False Then
            btnnuevo.Enabled = True
            deshabilitar()
            'realizar al auditoria
            Dim objaud As New Auditoria
            Dim ds As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)
            consular_departamento()

        End If


    End Sub

    Private Sub consular_departamento()

        Dim objdepar As New Departamento

        cbdepar.DataSource = objdepar.consultar_departamento.Tables(0)
        cbdepar.DataTextField = "nombre"
        cbdepar.DataValueField = "codigo"
        cbdepar.DataBind()
        cbdepar.Items.Insert(0, "Seleccionar...")



    End Sub
    Private Sub guardar()

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
            If Not IsNumeric(txtced.Text) Then
                Label1.Text = "La cedula o Nit debe Ser Numerico"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub
            End If

            If cbestado.SelectedValue = "" Or Len(Trim(txtced.Text)) = 0 Or Len(Trim(txtnom.Text)) = 0 Or Len(Trim(txtdir.Text)) = 0 Or cbdepar.SelectedValue = "" Or cbciu.SelectedValue = "" Then
                Label1.Text = "Por favor Digite los Campos Obligatorios(*)"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub
            End If

            Dim objprove As New proveedor
            Dim caracterespecial As New Auditoria
            objprove.ingresar_proveedor(Trim(caracterespecial.quitarcaracteres(txtced.Text)), UCase(caracterespecial.quitarcaracteres(txtnom.Text)), UCase(caracterespecial.quitarcaracteres(txtdir.Text)), txttel.Text, txtema.Text, cbciu.SelectedValue, cbestado.SelectedValue)
            Label1.Text = "Registro Guardado"
            Label1.ForeColor = Drawing.Color.Blue
            Label1.Visible = True
            deshabilitar()
            btnnuevo.Enabled = True

        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message

        End Try

    End Sub

    Private Sub nuevo()
        txtced.Text = ""
        txtdir.Text = ""
        txtema.Text = ""
        txtnom.Text = ""
        txttel.Text = ""
        Label1.Text = ""
        Label1.Visible = False
        txtced.Enabled = True
        txtnom.Enabled = True
        txtdir.Enabled = True
        txtema.Enabled = True
        txttel.Enabled = True
        btnguardar.Enabled = True
        cbestado.ClearSelection()
        cbdepar.ClearSelection()
        cbciu.DataSource = ""
        cbciu.DataBind()
        cbciu.Enabled = True
        cbdepar.Enabled = True
        cbestado.Enabled = True
5:

    End Sub

    Private Sub deshabilitar()

        txtced.Enabled = False
        txtdir.Enabled = False
        txtema.Enabled = False
        txtnom.Enabled = False
        txttel.Enabled = False
        btnguardar.Enabled = False
        cbestado.Enabled = False
        cbdepar.Enabled = False
        cbciu.Enabled = False


    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        nuevo()
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Response.Redirect("~/Forms/inicio.aspx")
    End Sub
End Class
