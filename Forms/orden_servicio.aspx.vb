Imports System.Data

Partial Class Forms_orden_trabajo
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Crear_Orden"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            'validad auditoria
            Dim objadi As New Auditoria
            Dim ds As New DataSet
            ' objadi.registro_auditoria(pagina, Session("login").ToString)


            ''recibe parametro idorden en "p1" de la pagina actualizar_orden.aspx
            If IsPostBack = False Then



                'realizar al auditoria
                Dim objaud As New Auditoria
                Dim dsa As New DataSet
                objaud.registro_auditoria(pagina, Session("login").ToString)

                If Request.QueryString("p1") <> "" Then
                    Dim nombre As String = Request.QueryString("p1")
                    txtcliente.Text = nombre

                    Dim objconsulorden As New orden
                    '  Dim ds As DataSet
                    ds = objconsulorden.recibir_idorden(Request.QueryString("p1"))

                    txtregis.Text = ds.Tables(0).Rows(0).Item("orden").ToString
                    txtfecha1.Text = ds.Tables(0).Rows(0).Item("Fecha_Apertura").ToString
                    txtfecha2.Text = ds.Tables(0).Rows(0).Item("Fecha_Cierre").ToString
                    txtdescriservi.Text = ds.Tables(0).Rows(0).Item("Reporte_Falla").ToString
                    txtequipo.Text = ds.Tables(0).Rows(0).Item("Equipo").ToString
                    txtmarca.Text = ds.Tables(0).Rows(0).Item("Marca").ToString
                    txtmodelo.Text = ds.Tables(0).Rows(0).Item("Modelo").ToString
                    txtserie.Text = ds.Tables(0).Rows(0).Item("Serie").ToString
                    txtobs.Text = ds.Tables(0).Rows(0).Item("Reporte_Tecnico").ToString
                    txttecnico.Text = ds.Tables(0).Rows(0).Item("idemp").ToString + " " + ds.Tables(0).Rows(0).Item("nomemp").ToString + " " + ds.Tables(0).Rows(0).Item("apeemp").ToString
                    txtcliente.Text = ds.Tables(0).Rows(0).Item("idcli").ToString + " " + ds.Tables(0).Rows(0).Item("nomcli").ToString + " " + ds.Tables(0).Rows(0).Item("apecli").ToString
                    Dim estado As String = ds.Tables(0).Rows(0).Item("Estado").ToString
                    cbestado.SelectedValue = estado
                    accion.Value = 2 ''variable que indica que se va a realizar un Update


                    txtfecha2.Text = Format(Date.Today.Date, "MM-dd-yyyy")


                    Dim f1 As Date = txtfecha1.Text
                    txtfecha1.Text = Format(f1, "MM-dd-yyyy")


                    txtregis.Enabled = False
                    txtfecha1.Enabled = False

                Else
                    txtfecha1.Text = Format(Date.Today.Date, "MM-dd-yyyy")
                    desahibitar()
                    cbestado.SelectedValue = "ABIERTO"

                End If

            End If

            'Fin------


        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try

    End Sub

    Public Sub guardar()

        Try
            If cbestado.SelectedValue = "" Or Len(Trim(txtfecha1.Text)) = 0 Or Len(Trim(txttecnico.Text)) = 0 Or Len(Trim(txtcliente.Text)) = 0 Or Len(Trim(txtdescriservi.Text)) = 0 Then
                Label1.Text = "Por favor Digite los Campos Obligatorios(*)"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub

            End If


            If Len(Trim(txtfecha2.Text)) > 0 And Len(Trim(txtobs.Text)) = 0 Then
                Label1.Text = "Orden con Fecha de cierre y sin Observacion"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub

            End If
            If Len(Trim(txtobs.Text)) > 0 And Len(Trim(txtfecha2.Text)) = 0 Then
                Label1.Text = "Observación sin Fecha de Cierre"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub

            End If



            'Valida las fechas seleccionadas
            If Len(Trim(txtfecha2.Text)) > 0 And txtfecha2.Text < txtfecha1.Text Then

                Label1.Text = "Fecha de Cierre no puede ser inferior a Fecha de Apertura"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub
            End If

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


            If accion.Value = 1 Then


                Dim objorden As New orden
                Dim caracterespecial As New Auditoria

                txtregis.Text = objorden.crear_orden(txtfecha1.Text, txtfecha2.Text, UCase(caracterespecial.quitarcaracteres(txtdescriservi.Text)), UCase(caracterespecial.quitarcaracteres(txtequipo.Text)), UCase(caracterespecial.quitarcaracteres(txtmarca.Text)), UCase(caracterespecial.quitarcaracteres(txtmodelo.Text)), UCase(caracterespecial.quitarcaracteres(txtserie.Text)), UCase(caracterespecial.quitarcaracteres(txtobs.Text)), idemp.Value, idcli.Value, cbestado.SelectedValue, 1)
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Blue
                Label1.Text = "Registro Guarado"
                desahibitar()


            ElseIf accion.Value = 2 Then
                Dim caracterespecial As New Auditoria
                Dim objmodifi As New orden
                objmodifi.actualizar_orden(txtregis.Text, "1", txtfecha2.Text, UCase(caracterespecial.quitarcaracteres(txtdescriservi.Text)), UCase(caracterespecial.quitarcaracteres(txtequipo.Text)), UCase(caracterespecial.quitarcaracteres(txtmarca.Text)), UCase(caracterespecial.quitarcaracteres(txtmodelo.Text)), UCase(caracterespecial.quitarcaracteres(txtserie.Text)), UCase(caracterespecial.quitarcaracteres(txtobs.Text)), cbestado.SelectedValue)
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Blue
                Label1.Text = "Registro Actualizado"



            End If


        Catch ex As Exception
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try


    End Sub

    Public Sub habilitar()

        txtfecha1.Enabled = True
        txtfecha2.Enabled = True
        txttecnico.Enabled = True
        txtcliente.Enabled = True
        txtdescriservi.Enabled = True
        txtequipo.Enabled = True
        txtmarca.Enabled = True
        txtmodelo.Enabled = True
        txtobs.Enabled = True
        cbestado.Enabled = True


    End Sub
    Public Sub desahibitar()

        txtfecha1.Enabled = False
        txtfecha2.Enabled = False
        txttecnico.Enabled = False
        txtcliente.Enabled = False
        txtdescriservi.Enabled = False
        txtequipo.Enabled = False
        txtmarca.Enabled = False
        txtmodelo.Enabled = False
        txtobs.Enabled = False
        cbestado.Enabled = False

    End Sub
    Public Sub limpiar()
        Label1.Text = ""
        Label1.Visible = False
        txtregis.Text = ""
        txtcliente.Text = ""
        txttecnico.Text = ""
        txtdescriservi.Text = ""
        txtobs.Text = ""
        txtserie.Text = ""
        txtequipo.Text = ""
        txtmarca.Text = ""
        txtmodelo.Text = ""
        txtfecha2.Text = ""
    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar()
    End Sub

    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnuevo.Click
        limpiar()
        habilitar()
        accion.Value = 1 ''variable que indica que se va a realizar un Insert
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Try


            If Len(Trim(txtregis.Text)) = 0 Then
                Label1.Visible = True
                Label1.Text = "Primero debe Guardar la Orden"
                Label1.ForeColor = Drawing.Color.Red
                Exit Sub

            End If

            ''Direcciona a la pagina para imprimir orden
            Response.Redirect("~/Reportes/ViewReporte_Orden.aspx?IdOrden=" & Integer.Parse(txtregis.Text))

        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
        End Try
    End Sub
End Class
