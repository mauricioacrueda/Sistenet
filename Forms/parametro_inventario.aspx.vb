Imports System.Data

Partial Class Forms_parametro_inventario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida permiso a pagina
        'Dim pagina As String = "parametro_inventario"
        'Dim objpermi As New usuario
        'objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)


    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Try

            'Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenausu As String = txtbodega.Text
            For i = 1 To Len(Cadenausu)

                If Mid(Cadenausu, i, 1) = " " Then
                    bodega.Value = Trim(Left(Cadenausu, i))
                    Exit For
                End If
            Next
            'FIN()
            If Me.txtfecha1.Text = "" Or Me.txtfecha2.Text = "" Then
                Label2.Text = "Por favor diligencie todos los datos"
                Label2.ForeColor = Drawing.Color.Red
                txtfecha1.Enabled = True
                txtfecha2.Enabled = True
                Exit Sub

            End If

            Dim objbuscar As New Inventario
            GridView1.DataSource = objbuscar.buscar_inventario_fecha(txtfecha1.Text, txtfecha2.Text, bodega.Value)
            GridView1.DataBind()
            Label2.Text = ""

        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub


    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Response.Redirect("~/Reportes/ViewReporte_inventario.aspx?Idinventario=" & Integer.Parse(Server.HtmlDecode(GridView1.Rows(e.NewSelectedIndex).Cells(1).Text.ToString)))
    End Sub
End Class
