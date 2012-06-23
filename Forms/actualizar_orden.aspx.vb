Imports System.Data

Partial Class Forms_actualizar_orden
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'valida permiso a pagina
        Dim pagina As String = "Actualizar_Orden"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)


    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Try

            ''Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenacli As String = txtcliente.Text
            For i = 1 To Len(Cadenacli)

                If Mid(Cadenacli, i, 1) = " " Then
                    idcli.Value = Trim(Left(Cadenacli, i))
                    Exit For
                End If
            Next
            ''FIN

            ''Retorna Solo la Identificacion del Tecnico Asignado. Busca el 1er espacio y toma todos los digitos de izp a der
            Dim Cadenaemp As String = txttecnico.Text
            For i = 1 To Len(Cadenaemp)

                If Mid(Cadenaemp, i, 1) = " " Then
                    idemp.Value = Trim(Left(Cadenaemp, i))
                    Exit For
                End If
            Next
            ''FIN

            Dim objbuscar As New orden
            GridView1.DataSource = objbuscar.buscar_orden(txtfecha1.Text, txtfecha2.Text, idemp.Value, idcli.Value, "1")
            GridView1.DataBind()

        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub cbbusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbusqueda.SelectedIndexChanged


        If cbbusqueda.SelectedValue = 1 Then
            lbcliente.Visible = False
            txtcliente.Visible = False
            lbtecnico.Visible = True
            txttecnico.Visible = True
        ElseIf cbbusqueda.SelectedValue = 2 Then
            lbcliente.Visible = True
            txtcliente.Visible = True
            lbtecnico.Visible = False
            txttecnico.Visible = False
            'txtcliente.Attributes.Add("style", "Z-INDEX: 101; LEFT: 10px; POSITION: absolute; TOP: 100px")
        End If

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'oculta las columnas 9

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(9).Visible = False  'Reporte Tecnico

            GridView1.HeaderRow.Cells(9).Visible = False

            ' GridView1.HeaderRow.Cells(2).Text = "Razon Social"


        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub txtcliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcliente.TextChanged
    End Sub

   
End Class
