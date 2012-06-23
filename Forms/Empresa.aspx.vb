imports Microsoft.VisualBasic
Imports System.Data
imports System.data.sqlclient
Partial Class Forms_Empresa
    Inherits System.Web.UI.Page
    Dim nit As New Empresa
    Public Sub guardar()
        Try
            If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Or Me.TextBox5.Text = "" Or Me.cbdepar.SelectedValue = "" Or Me.cbmuni.SelectedValue = "" Then
                Label1.Text = "Por favor diligencie todos los datos"
                Label1.ForeColor = Drawing.Color.Red
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                TextBox4.Enabled = True
                TextBox5.Enabled = True
                Exit Sub

            End If
            If accion.Value = 1 Then
                Dim hk As New Empresa
                hk.ingresar_empresa(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text, Me.TextBox4.Text, Me.TextBox5.Text, Me.cbdepar.SelectedValue, Me.cbmuni.SelectedValue)

            ElseIf accion.Value = 2 Then
                modificar()

            End If
        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    Public Sub modificar()
        TextBox1.Enabled = False
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Or Me.TextBox5.Text = "" Or Me.cbmuni.SelectedValue = "" Or Me.cbdepar.SelectedValue Then
            Response.Write("<Script language=javascript>alert('Por favor diligencie todos los campos!');</script>")
            Exit Sub

        End If
        Dim hk As New Empresa
        hk.modificar_empresa(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text, Me.TextBox4.Text, Me.TextBox5.Text, Me.cbmuni.SelectedValue, Me.cbdepar.SelectedValue)

        Label1.Text = "registro modificado"
        Label1.ForeColor = Drawing.Color.Red
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Empresa"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)


            btnuevo.Enabled = True
            If IsPostBack = False Then
                deshabilitar()
                'realizar al auditoria
                Dim objaud As New Auditoria
                Dim ds As New DataSet
                objaud.registro_auditoria(pagina, Session("login").ToString)
                consular_departamento()
                'Dim ds As New DataSet
                ds = nit.consultar_empresa
                TextBox1.Text = ds.Tables(0).Rows(0)("nit").ToString()
                TextBox2.Text = ds.Tables(0).Rows(0)("nombre").ToString
                TextBox3.Text = ds.Tables(0).Rows(0)("direccion").ToString()
                TextBox4.Text = ds.Tables(0).Rows(0)("telefono").ToString()
                TextBox5.Text = ds.Tables(0).Rows(0)("email").ToString()
                cbdepar.SelectedValue = ds.Tables(0).Rows(0)("id_departamento").ToString()
                cargar_ciudades(cbdepar.SelectedValue)
                cbmuni.SelectedValue = ds.Tables(0).Rows(0)("id_ciudad").ToString()
            End If
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub


    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnuevo.Click
        'limpiar()
        accion.Value = 2
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        habilitar()

    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar()
    End Sub

   
    Protected Sub cbdepar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbdepar.SelectedIndexChanged
        ' If IsPostBack Then

        Dim objciu As New ciudades

        cbmuni.DataSource = objciu.consultar_ciu_por_depar(cbdepar.SelectedValue)
        cbmuni.DataTextField = "nombre"
        cbmuni.DataValueField = "id"
        cbmuni.DataBind()


        'End If

    End Sub
    Protected Sub cargar_ciudades(ByVal id_dep As String)

        Dim objciu As New ciudades

        cbmuni.DataSource = objciu.consultar_ciu_por_depar(id_dep)
        cbmuni.DataTextField = "nombre"
        cbmuni.DataValueField = "id"
        cbmuni.DataBind()

    End Sub
    Private Sub consular_departamento()

        Dim objdepar As New Departamento

        cbdepar.DataSource = objdepar.consultar_departamento.Tables(0)
        cbdepar.DataTextField = "nombre"
        cbdepar.DataValueField = "codigo"
        cbdepar.DataBind()

    End Sub
    Private Sub deshabilitar()

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        cbdepar.Enabled = False
        cbmuni.Enabled = False
        btnguardar.Enabled = False


    End Sub

    Private Sub habilitar()

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        cbdepar.Enabled = True
        cbmuni.Enabled = True
        btnguardar.Enabled = True
    End Sub
    Private Sub limpiar()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Label1.Visible = False
        cbdepar.ClearSelection()
        cbmuni.DataSource = ""
        cbmuni.DataBind()

    End Sub
End Class
