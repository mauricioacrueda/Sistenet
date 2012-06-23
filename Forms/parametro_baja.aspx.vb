Imports System.Data
Imports System.IO

Partial Class Forms_parametro_baja
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida permiso a pagina
        'Dim pagina As String = "parametro_baja"
        'Dim objpermi As New usuario
        'objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Try

            'Retorna Solo la Identificacion de la Bodega. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenausu As String = txtbodega.Text
            For i = 1 To Len(Cadenausu)

                If Mid(Cadenausu, i, 1) = " " Then
                    bodega.Value = Trim(Left(Cadenausu, i))
                    Exit For
                End If
            Next

            If Me.txtfecha1.Text = "" Or Me.txtfecha2.Text = "" Then
                Label2.Text = "Por favor diligencie todos los datos"
                Label2.ForeColor = Drawing.Color.Red
                txtfecha1.Enabled = True
                txtfecha2.Enabled = True
                Exit Sub

            End If

            Dim objbuscar As New Baja
            GridView1.DataSource = objbuscar.buscar_baja_fecha(txtfecha1.Text, txtfecha2.Text, bodega.Value)
            GridView1.DataBind()
            label2.text = ""

        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue
            Label1.Text = ex.Message
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
        End Try
    End Sub


    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        'Genera el reporte tomando el primer Valor de la Gridview
        Response.Redirect("~/Reportes/ViewReporte_Baja.aspx?Idbaja=" & Integer.Parse(Server.HtmlDecode(GridView1.Rows(e.NewSelectedIndex).Cells(1).Text.ToString)))
    End Sub
End Class
