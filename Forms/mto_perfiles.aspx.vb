Imports System.Data

Partial Class Forms_mto_perfiles
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida permiso a pagina
        Dim pagina As String = "Actualizar_Perfil"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)


        'carga todas las paginas en la grilla1
        llenar_grilla1()
        If IsPostBack = False Then
            'realizar al auditoria
            Dim objaud As New Auditoria
            Dim ds As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)

        End If


    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbperfil.SelectedIndexChanged

        'consulta los permisos asignados para el perfil seleccionado
      permisos_perfil()

    End Sub

    Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        ''evento para paginacion
        llenar_grilla1()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        ''evento para paginacion
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Try

            ''Asigna el permiso al perfil selecciondo en al combo=cbperfil

            If CheckBox1.Checked = False Then
                Label1.Text = "Debe Seleccionar un Perfil"
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Red
                Exit Sub
            End If

            Dim objpermipag As New perfil

            objpermipag.ingresar_permiso_perfil(GridView1.Rows(e.NewSelectedIndex).Cells(1).Text.ToString, cbperfil.SelectedValue)
            Label1.Text = "Permiso Asignado Correctamente"
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue

            Dim objperfi As New perfil
            GridView2.DataSource = objperfi.consultar_permisos_de_perfil(cbperfil.SelectedValue)
            GridView2.DataBind()
            Label1.Visible = True

        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
        End Try

    End Sub

    Private Sub llenar_grilla1()
        ''llena la grilla 1 con las paginas del sistema
        Dim objper As New perfil
        GridView1.DataSource = objper.consultar_pagina.Tables(0)
        GridView1.DataBind()

    End Sub

    Protected Sub GridView2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.PageIndexChanged
        'Grilla donde se muestra los permisos por perfil
        permisos_perfil()
    End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        'ocultar las columnas 1 y 3

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(1).Visible = False  'Id del Menu
            e.Row.Cells(3).Visible = False  'Id permiso


            GridView2.HeaderRow.Cells(1).Visible = False
            GridView2.HeaderRow.Cells(3).Visible = False

        End If
    End Sub

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Try


            Label1.Visible = False
            Dim objpermi As New perfil
            objpermi.eliminar_permiso(GridView2.Rows(e.RowIndex).Cells(1).Text.ToString, GridView2.Rows(e.RowIndex).Cells(3).Text.ToString, cbperfil.SelectedValue)
            Dim objperfi As New perfil
            GridView2.DataSource = objperfi.consultar_permisos_de_perfil(cbperfil.SelectedValue)
            GridView2.DataBind()
        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        ''Llena el cbperfil con los perfiles del sistema
        Label1.Visible = False
        Label1.Text = ""
        If CheckBox1.Checked = True Then

            cbperfil.Enabled = True

            Dim obj As New perfil
            cbperfil.DataSource = obj.consultar_perfiles.Tables(0)
            cbperfil.DataTextField = "nombre_perfil"
            cbperfil.DataValueField = "codigo_perfil"
            cbperfil.DataBind()

            permisos_perfil()

        ElseIf CheckBox1.Checked = False Then
            cbperfil.Enabled = False
            cbperfil.DataSource = ""

        End If
    End Sub

    Public Sub permisos_perfil()
        'consulta los permisos asignados para el perfil seleccionado
        Dim objperfi As New perfil
        GridView2.DataSource = objperfi.consultar_permisos_de_perfil(cbperfil.SelectedValue)
        GridView2.DataBind()
    End Sub
End Class
