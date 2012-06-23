Imports System.Data

Partial Class Forms_mto_cotizacion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pagina As String = "Actualizar_Cotizacion"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
        If IsPostBack = False Then
            'realizar al auditoria
            Dim objaud As New Auditoria
            Dim ds As New DataSet
            objaud.registro_auditoria(pagina, Session("login").ToString)

        End If

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


            Dim objbuscar As New cotizacion
            GridView1.DataSource = objbuscar.buscar_cotizacion(idcli.Value, txtfecha1.Text, txtfecha2.Text)
            GridView1.DataBind()

        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Blue
            Label1.Text = ex.Message
        End Try
    End Sub


End Class
