Imports System.Data
Imports System.IO

Partial Class Forms_Baja
    Inherits System.Web.UI.Page

    Dim CantidadProductosTotal As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "Baja"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            'TextBox4.Attributes.Add("onkeypress", "return AcceptNum(event)")
            'CargarProductos()
            If IsPostBack = False Then
                PnIngresar.Visible = False
                PnConsulta.Visible = False
                'realizar al auditoria
                Dim objadi As New Auditoria
                Dim ds As New DataSet
                objadi.registro_auditoria(pagina, Session("login").ToString)
            End If
        Catch ex As Exception
            label1.Visible = True
            label1.ForeColor = Drawing.Color.Red
            label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAgregar.Click
        lnkAgregar.Visible = False
        lnkConsultar.Visible = False
        PnConsulta.Visible = False
        PnIngresar.Visible = True
        CargarProductos()
        CargarBodegas()
        GvProductos.DataSource = Nothing
        GvProductos.DataBind()
    End Sub

    Protected Sub lnkConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkConsultar.Click
        lnkAgregar.Visible = False
        lnkConsultar.Visible = False
        PnIngresar.Visible = False
        PnConsulta.Visible = True
        Cargarbajas()
    End Sub

    Public Sub CargarProductos()
        Dim dtproductos As New DataTable
        Dim objbus As New Productos
        If cbbod.SelectedValue = "" Or Me.cbbod.Text = "Seleccionar...." Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Recuerde Seleccionar una Bodega');</script>", False)
        Else
            dtproductos = objbus.buscar_productos_cantidad(txtbus.Text, cbbod.SelectedValue).Tables(0)
            'dtproductos = objbus.buscar_productos(txtbus.Text).Tables(0)
            GvProductos.DataSource = dtproductos
            GvProductos.DataBind()
        End If

    End Sub

    Public Sub CargarBaja()
        Dim dtbaja As New DataTable
        Dim objbus As New Baja
        dtbaja = objbus.buscar_baja(txtbus.Text).Tables(0)
        GvProductos.DataSource = dtbaja
        GvProductos.DataBind()
    End Sub
    Private Sub CargarBodegas()
        Dim bod As New Bodegas
        cbbod.DataSource = bod.consultar_bodega.Tables(0)
        cbbod.DataTextField = "nombre"
        cbbod.DataValueField = "registro"
        cbbod.DataBind()
        cbbod.Items.Insert(0, "Seleccionar....")
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar.Click
        lnkAgregar.Visible = True
        lnkConsultar.Visible = True
        PnIngresar.Visible = False
        PnConsulta.Visible = False
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        LbMensaje.Visible = False
        Try

            If Len(Trim(txtbus.Text)) = 0 Or Me.cbbod.Text = "Seleccionar...." Then

                label1.Text = "No Existe Criterio para Buscar o no ha seleecionado ninguna Bodega"
                label1.ForeColor = Drawing.Color.Red
                label1.Visible = True
                CargarProductos()
                Exit Sub

            End If

            Dim dtproductos As New DataTable
            Dim objbus As New Productos
            dtproductos = objbus.buscar_productos_cantidad(txtbus.Text, cbbod.SelectedValue).Tables(0)
            GvProductos.DataSource = dtproductos
            GvProductos.DataBind()

            LbNota.Visible = True
            btnAgregarProducto.Visible = True

        Catch ex As Exception

            LbMensaje.Visible = True
            LbMensaje.Text = ex.Message
            LbMensaje.ForeColor = Drawing.Color.Red
            LbNota.Visible = False
            btnAgregarProducto.Visible = False

        End Try

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click

        Try

            If Me.cbbod.SelectedValue = "" Or Me.cbbod.Text = "Seleccionar..." Or Me.txtObservacion.Text = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Recuerde ingresar todos lo datos');</script>", False)
                Exit Sub
            End If

            Dim obj As New Baja

            Dim Idbaja As Integer = obj.ingresar_baja(cbbod.SelectedValue, Integer.Parse(Me.ViewState("CantidadProductosTotal")), txtObservacion.Text)

            If Idbaja > 0 Then

                Dim dtdetalle As New DataTable
                dtdetalle = Me.ViewState("dtseleccion")

                If dtdetalle.Rows.Count > 0 Then

                    Try
                        For i As Integer = 0 To dtdetalle.Rows.Count - 1



                            obj.ingresar_baja_detalle(Idbaja, Integer.Parse(dtdetalle.Rows(i)("idproducto")), Integer.Parse(dtdetalle.Rows(i)("Cantidad")))
                            obj.actualizar_baja_bodega(Idbaja, Integer.Parse(cbbod.SelectedValue), Integer.Parse(dtdetalle.Rows(i)("idproducto")), Integer.Parse(dtdetalle.Rows(i)("Cantidad")), 1)
                        Next
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('baja ingresado correctamente');</script>", False)
                        'genera el reporte
                        'Response.Redirect("~/Reportes/ViewReporte_Baja.aspx?id=" & Idbaja.ToString & "", False)
                        Response.Redirect("~/Reportes/ViewReporte_Baja.aspx?idbaja=" & Idbaja.ToString)
                    Catch ex As Exception
                        Dim au As New Auditoria
                        au.fichero(ex.ToString)
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio el siguiente error : " & ex.Message & " , comuniquese con el administrador del sistema');</script>", False)
                    End Try

                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('baja ingresado correctamente');</script>", False)
                    'genera el reporte
                    'Response.Redirect("~/Reportes/ReporteBaja.aspx?id=" & Idbaja.ToString & "", False)
                End If

            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio un error, comuniquese con el administrador del sistema');</script>", False)
            End If

            lnkAgregar.Visible = True
            lnkConsultar.Visible = True
            PnIngresar.Visible = False
            PnConsulta.Visible = False

            Me.ViewState("dtseleccion") = Nothing
            Me.ViewState("CantidadProductosTotal") = Nothing

            txtObservacion.Text = ""
            txtbus.Text = ""

        Catch ex As Exception

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio el siguiente error : " & ex.Message & " , comuniquese con el administrador del sistema');</script>", False)

        End Try

    End Sub


    Public Sub Cargarbajas()
        Dim obj As New Baja
        Gvbajas.DataSource = obj.consultar_baja()
        Gvbajas.DataBind()

        If Gvbajas.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('No se han registrado bajas.');</script>", False)
            lnkAgregar.Visible = True
            lnkConsultar.Visible = True
            PnIngresar.Visible = False
            PnConsulta.Visible = False
        End If
    End Sub

    Protected Sub Gvbajas_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Gvbajas.RowDeleting
        Try
            Dim id As Integer = Me.Gvbajas.DataKeys(0).Value
            Dim obj As New Baja
            obj.eliminar_baja(id)
            obj.actualizar_baja_bodega(id, 0, 0, 0, 0)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('baja eliminado exitosamente');</script>", False)
            Cargarbajas()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio un error, contacte con el Administrador');</script>", False)
        End Try
    End Sub

    Protected Sub Gvbajas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gvbajas.PageIndexChanging
        Dim obj As New Baja
        Gvbajas.DataSource = obj.consultar_baja()
        Gvbajas.DataBind()
        Gvbajas.PageIndex = e.NewPageIndex
        Gvbajas.DataBind()
    End Sub

    Protected Sub btnRegresar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar2.Click
        lnkAgregar.Visible = True
        lnkConsultar.Visible = True
        PnIngresar.Visible = False
        PnConsulta.Visible = False
    End Sub

    Protected Sub GvDetalleProductos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvDetalleProductos.RowDeleting
        Try
            Dim dt As New DataTable
            dt = Me.ViewState("dtseleccion")
            dt.Rows.RemoveAt(e.RowIndex)
            Me.ViewState("dtseleccion") = dt
            If dt.Rows.Count > 0 Then
                GvDetalleProductos.DataSource = dt
                GvDetalleProductos.DataBind()
            Else
                GvDetalleProductos.DataSource = Nothing
                GvDetalleProductos.DataBind()
            End If

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Producto eliminado exitosamente de la lista.');</script>", False)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio un error, contacte con el Administrador');</script>", False)
        End Try
    End Sub

    Protected Sub GvDetalleProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GvDetalleProductos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                DirectCast(e.Row.Cells(0).Controls(0), LinkButton).Attributes("onclick") = "if(!confirm('Esta seguro de eliminar este producto?'))return   false;"
            End If
        End If
    End Sub

    Protected Sub Gvbajas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Gvbajas.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                DirectCast(e.Row.Cells(0).Controls(0), LinkButton).Attributes("onclick") = "if(!confirm('Esta seguro de eliminar este baja?'))return   false;"
            End If
        End If
    End Sub

    Protected Sub Gvproductos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvProductos.PageIndexChanging
        CargarProductos()
        GvProductos.PageIndex = e.NewPageIndex
        GvProductos.DataBind()
    End Sub



    Protected Sub cbbod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbod.SelectedIndexChanged
        CargarProductos()
        ' .Attributes.Add("onkeypress", "return AcceptNum(event)")
    End Sub

    Protected Sub txtbus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbus.TextChanged
        LbMensaje.Visible = False
        Try

            If Len(Trim(txtbus.Text)) = 0 Or Me.cbbod.Text = "Seleccionar...." Then

                label1.Text = "No Existe Criterio para Buscar o no ha seleecionado ninguna Bodega"
                label1.ForeColor = Drawing.Color.Red
                label1.Visible = True

                Exit Sub

            End If

            Dim dtproductos As New DataTable
            Dim objbus As New Productos
            dtproductos = objbus.buscar_productos_cantidad(txtbus.Text, cbbod.SelectedValue).Tables(0)
            GvProductos.DataSource = dtproductos
            GvProductos.DataBind()

            LbNota.Visible = True
            btnAgregarProducto.Visible = True

        Catch ex As Exception

            LbMensaje.Visible = True
            LbMensaje.Text = ex.Message
            LbMensaje.ForeColor = Drawing.Color.Red
            LbNota.Visible = False
            btnAgregarProducto.Visible = False

        End Try
    End Sub

    Protected Sub Gvbajas_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles Gvbajas.SelectedIndexChanging
        'txtregistro.Text = Server.HtmlDecode(Gvbajas.Rows(e.NewSelectedIndex).Cells(2).Text.ToString)
        Response.Redirect("~/Reportes/ViewReporte_Baja.aspx?Idbaja=" & Integer.Parse(Server.HtmlDecode(Gvbajas.Rows(e.NewSelectedIndex).Cells(2).Text.ToString)))
    End Sub

    Protected Sub btnAgregarProducto_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgregarProducto.Click

        For i As Integer = 0 To GvProductos.Rows.Count - 1

            Dim row As GridViewRow = GvProductos.Rows(i)
            Dim chbcontrol As CheckBox = DirectCast(row.FindControl("CheckBox1"), CheckBox)
            Dim id As Integer = Integer.Parse(GvProductos.DataKeys.Item(i).Value.ToString())

            If chbcontrol.Checked Then

                Dim txtcontrol As TextBox = DirectCast(row.FindControl("TextBox4"), TextBox)

                If txtcontrol.Text = "" Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe ingresar una cantidad');</script>", False)
                Else

                    Dim existenciaGrilla As Integer = GvProductos.Rows(i).Cells(4).Text

                    If Integer.Parse(txtcontrol.Text) > existenciaGrilla Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('El valor debe ser menor o igual a las existencias');</script>", False)
                        Exit Sub
                    End If

                    Dim dttemp As New DataTable
                    dttemp = Me.ViewState("dtseleccion")

                    If Not dttemp Is Nothing Then

                        For j As Integer = 0 To dttemp.Rows.Count - 1


                            If Integer.Parse(dttemp.Rows(j)("idproducto")) = id Then
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('el producto seleccionado ya esta en la lista');</script>", False)
                                Exit Sub
                            End If

                        Next

                    End If

                    Dim lbid As Label = DirectCast(row.FindControl("lbid"), Label)

                    Dim dt As New DataTable
                    Dim dr As DataRow
                    dt.Columns.Add(New DataColumn("idproducto", GetType(String)))
                    dt.Columns.Add(New DataColumn("nombre", GetType(String)))
                    dt.Columns.Add(New DataColumn("Cantidad", GetType(String)))

                    If Me.ViewState("dtseleccion") Is Nothing Then

                        dr = dt.NewRow()
                        dr("idproducto") = lbid.Text 'GvProductos.Rows(i).Cells(3).Text
                        dr("nombre") = GvProductos.Rows(i).Cells(5).Text
                        dr("Cantidad") = txtcontrol.Text
                        dt.Rows.Add(dr)
                        Me.ViewState("dtseleccion") = dt

                    Else

                        Dim dt2 As DataTable = Me.ViewState("dtseleccion")
                        dr = dt2.NewRow()
                        dr("idproducto") = lbid.Text 'GvProductos.Rows(i).Cells(3).Text
                        dr("nombre") = GvProductos.Rows(i).Cells(5).Text
                        dr("Cantidad") = txtcontrol.Text
                        dt2.Rows.Add(dr)
                        Me.ViewState("dtseleccion") = dt2

                    End If

                    CantidadProductosTotal += Integer.Parse(txtcontrol.Text.Trim)
                    Me.ViewState("CantidadProductosTotal") = CantidadProductosTotal
                    chbcontrol.Checked = False
                    txtcontrol.Text = ""

                End If

            End If

        Next

        Dim dtdetalle As New DataTable
        dtdetalle = Me.ViewState("dtseleccion")
        GvDetalleProductos.DataSource = dtdetalle
        GvDetalleProductos.DataBind()
    End Sub

    
    Protected Sub txtbodega_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbodega.TextChanged
        Try

            'Retorna Solo la Identificacion de la Bodega. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenausu As String = txtbodega.Text
            For i = 1 To Len(Cadenausu)

                If Mid(Cadenausu, i, 1) = " " Then
                    bodega.Value = Trim(Left(Cadenausu, i))
                    Exit For
                End If
            Next


            Dim objbuscar As New Baja
            Gvbajas.DataSource = objbuscar.buscar_baja_bodega(bodega.Value)
            Gvbajas.DataBind()
            'label2.text = ""

        Catch ex As Exception
            label1.Visible = True
            label1.ForeColor = Drawing.Color.Blue
            label1.Text = ex.Message
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
        End Try
    End Sub

    Protected Sub btnbusinv_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbusinv.Click
        Try

            'Retorna Solo la Identificacion de la Bodega. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenausu As String = txtbodega.Text
            For i = 1 To Len(Cadenausu)

                If Mid(Cadenausu, i, 1) = " " Then
                    bodega.Value = Trim(Left(Cadenausu, i))
                    Exit For
                End If
            Next


            Dim objbuscar As New Baja
            Gvbajas.DataSource = objbuscar.buscar_baja_bodega(bodega.Value)
            Gvbajas.DataBind()
            'label2.text = ""

        Catch ex As Exception
            label1.Visible = True
            label1.ForeColor = Drawing.Color.Blue
            label1.Text = ex.Message
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
        End Try
    End Sub

End Class
