Imports System.Data
Imports System.IO

Partial Class Forms_inventario
    Inherits System.Web.UI.Page

    Dim CantidadProductosTotal As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'valida el permiso a la pagina
            Dim pagina As String = "inventario.aspx"
            Dim objpermi As New usuario
            objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
            'CargarProductos()
            If IsPostBack = False Then
                PnIngresar.Visible = False
                PnConsulta.Visible = False
                PnExistencias.Visible = False
                'validad auditoria
                Dim objaud As New Auditoria
                Dim ds As New DataSet
                objaud.registro_auditoria(pagina, Session("login").ToString)
            End If
        Catch ex As Exception
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAgregar.Click
        lnkAgregar.Visible = False
        lnkConsultar.Visible = False
        LnkExistencias.Visible = False
        PnConsulta.Visible = False
        PnExistencias.Visible = False
        PnIngresar.Visible = True
        CargarProductos()
        CargarBodegas()
        Me.ViewState("dtseleccion") = Nothing
        CantidadProductosTotal = 0
        GvDetalleProductos.DataSource = Nothing
        GvDetalleProductos.DataBind()
    End Sub

    Protected Sub lnkConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkConsultar.Click
        lnkAgregar.Visible = False
        lnkConsultar.Visible = False
        lnkexistencias.Visible = False
        PnIngresar.Visible = False
        PnExistencias.Visible = False
        PnConsulta.Visible = True
        CargarInventarios()
    End Sub

    Protected Sub LinkExistencias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkExistencias.Click
        lnkAgregar.Visible = False
        lnkConsultar.Visible = False
        LnkExistencias.Visible = False
        PnIngresar.Visible = False
        PnConsulta.Visible = False
        PnExistencias.Visible = True
        CargarExistencias()
    End Sub

    Public Sub CargarProductos()
        Dim dtproductos As New DataTable
        Dim objbus As New Productos
        dtproductos = objbus.consultar_producto.Tables(0)
        GvProductos.DataSource = dtproductos
        GvProductos.DataBind()
    End Sub
    Public Sub CargarExistencias()
        Dim dtexistencias As New DataSet
        Dim objbus As New Productos
        dtexistencias = objbus.consultar_existencias
        GvExistencias.DataSource = dtexistencias.Tables(0)
        GvExistencias.DataBind()
    End Sub

    Private Sub CargarBodegas()
        Dim bod As New Bodegas
        cbbod.DataSource = bod.consultar_bodega.Tables(0)
        cbbod.DataTextField = "nombre"
        cbbod.DataValueField = "registro"
        cbbod.DataBind()
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar.Click
        lnkAgregar.Visible = True
        lnkConsultar.Visible = True
        LnkExistencias.Visible = True
        PnIngresar.Visible = False
        PnConsulta.Visible = False
        PnExistencias.Visible = False
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        LbMensaje.Visible = False
        Try

            If Len(Trim(txtbus.Text)) = 0 Then
                LbMensaje.Text = "No Existe Criterio para Buscar"
                LbMensaje.ForeColor = Drawing.Color.Red
                LbMensaje.Visible = True
                CargarProductos()
                Exit Sub
            End If

            Dim dtproductos As New DataTable
            Dim objbus As New Productos
            dtproductos = objbus.buscar_productos(txtbus.Text).Tables(0)
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

    Protected Sub GvProductos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvProductos.PageIndexChanging
        CargarProductos()
        GvProductos.PageIndex = e.NewPageIndex
        GvProductos.DataBind()
    End Sub
    Protected Sub Gvexistencias_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gvexistencias.PageIndexChanging
        CargarExistencias()
        Gvexistencias.PageIndex = e.NewPageIndex
        Gvexistencias.DataBind()
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGuardar.Click

        Try


            If Me.cbbod.SelectedValue = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe seleccionar la bodega');</script>", False)
                Exit Sub
            End If

            Dim obj As New Inventario

            Dim IdInventario As Integer = obj.ingresar_inventario(cbbod.SelectedValue, Integer.Parse(Me.ViewState("CantidadProductosTotal")), UCase(txtObservacion.Text))

            If IdInventario > 0 Then

                Dim dtdetalle As New DataTable
                dtdetalle = Me.ViewState("dtseleccion")

                If dtdetalle.Rows.Count > 0 Then

                    Try
                        For i As Integer = 0 To dtdetalle.Rows.Count - 1
                            obj.ingresar_inventario_detalle(IdInventario, Integer.Parse(dtdetalle.Rows(i)("idproducto")), Integer.Parse(dtdetalle.Rows(i)("Cantidad")))
                            obj.actualizar_inventario_bodega(IdInventario, Integer.Parse(cbbod.SelectedValue), Integer.Parse(dtdetalle.Rows(i)("idproducto")), Integer.Parse(dtdetalle.Rows(i)("Cantidad")), 1)

                        Next
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Inventario ingresado correctamente');</script>", False)
                        Response.Redirect("~/Reportes/ViewReporte_Inventario.aspx?idinventario=" & IdInventario.ToString)
                    Catch ex As Exception
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio el siguiente error : " & ex.Message & " , comuniquese con el administrador del sistema');</script>", False)
                        Dim ruta As String = "d:\fichero.txt"
                        Dim escritor As StreamWriter
                        escritor = File.AppendText(ruta)
                        escritor.Write("Prueba" & ex.Message.ToString() & "")
                        escritor.Flush()
                        escritor.Close()
                    End Try

                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Inventario ingresado correctamente');</script>", False)
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
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
        End Try
    End Sub

    Public Sub CargarInventarios()
        Dim obj As New Inventario
        GvInventarios.DataSource = obj.consultar_inventarios()
        GvInventarios.DataBind()

        If GvInventarios.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('No se han registrado inventarios.');</script>", False)
            lnkAgregar.Visible = True
            lnkConsultar.Visible = True
            PnIngresar.Visible = False
            PnConsulta.Visible = False
        End If
    End Sub

    Protected Sub GvInventarios_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvInventarios.RowDeleting
        Try
            Dim id As Integer = Me.GvInventarios.DataKeys(0).Value
            Dim obj As New Inventario
            obj.eliminar_inventario(id)
            obj.actualizar_inventario_bodega(id, 0, 0, 0, 0)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Inventario eliminado exitosamente');</script>", False)
            CargarInventarios()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio un error, contacte con el Administrador');</script>", False)
            Dim ruta As String = "d:\fichero.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.Write("Prueba" & ex.Message.ToString() & "")
            escritor.Flush()
            escritor.Close()
        End Try
    End Sub

    Protected Sub GvInventarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvInventarios.PageIndexChanging
        CargarInventarios()
        GvInventarios.PageIndex = e.NewPageIndex
        GvInventarios.DataBind()
        GvInventarios.Visible = True
    End Sub

    Protected Sub btnRegresar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar2.Click
        lnkAgregar.Visible = True
        lnkConsultar.Visible = True
        LnkExistencias.Visible = True
        PnIngresar.Visible = False
        PnConsulta.Visible = False
        PnExistencias.Visible = False
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

    Protected Sub GvInventarios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GvInventarios.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                DirectCast(e.Row.Cells(0).Controls(0), LinkButton).Attributes("onclick") = "if(!confirm('Esta seguro de eliminar este inventario?'))return   false;"
            End If
        End If
    End Sub

    Protected Sub GvDetalleProductos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvDetalleProductos.PageIndexChanging
        GvDetalleProductos.PageIndex = e.NewPageIndex
        GvDetalleProductos.DataBind()
    End Sub

    Protected Sub btnAgregarProducto_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgregarProducto.Click

        For i As Integer = 0 To GvProductos.Rows.Count - 1

            Dim row As GridViewRow = GvProductos.Rows(i)
            Dim id As Integer = Integer.Parse(GvProductos.DataKeys.Item(i).Value.ToString())

            Dim chbcontrol As CheckBox = DirectCast(row.FindControl("CheckBox1"), CheckBox)

            If chbcontrol.Checked Then

                Dim txtcontrol As TextBox = DirectCast(row.FindControl("TextBox4"), TextBox)

                If txtcontrol.Text = "" Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe ingresar una cantidad');</script>", False)
                Else

                    If Val(txtcontrol.Text) <= 0 Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe ingresar un valor mayor a cero');</script>", False)
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
                        dr("nombre") = GvProductos.Rows(i).Cells(4).Text
                        dr("Cantidad") = txtcontrol.Text
                        dt.Rows.Add(dr)
                        Me.ViewState("dtseleccion") = dt

                    Else

                        Dim dt2 As DataTable = Me.ViewState("dtseleccion")
                        dr = dt2.NewRow()
                        dr("idproducto") = lbid.Text 'GvProductos.Rows(i).Cells(3).Text
                        dr("nombre") = GvProductos.Rows(i).Cells(4).Text
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

    Protected Sub Gvinventarios_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GvInventarios.SelectedIndexChanging
        Response.Redirect("~/Reportes/ViewReporte_Inventario.aspx?idinventario=" & Integer.Parse(Server.HtmlDecode(GvInventarios.Rows(e.NewSelectedIndex).Cells(1).Text.ToString)))
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


            Dim objbuscar As New Inventario
            GvInventarios.DataSource = objbuscar.buscar_inventario_bodega(bodega.Value)
            GvInventarios.DataBind()
            'label2.text = ""

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

    Protected Sub btnbusexi_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbusexi.Click
        Try

            'Retorna Solo la Identificacion de la Bodega. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenausu As String = txtexistencias.Text
            For i = 1 To Len(Cadenausu)

                If Mid(Cadenausu, i, 1) = " " Then
                    bodegaexis.Value = Trim(Left(Cadenausu, i))
                    Exit For
                End If
            Next


            Dim objbuscar As New Inventario
            Gvexistencias.DataSource = objbuscar.buscar_existencias_bodega(bodegaexis.Value)
            Gvexistencias.DataBind()
            'label2.text = ""

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

    Protected Sub btnRegresar3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar3.Click
        lnkAgregar.Visible = True
        lnkConsultar.Visible = True
        LnkExistencias.Visible = True
        PnIngresar.Visible = False
        PnConsulta.Visible = False
        PnExistencias.Visible = False
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


            Dim objbuscar As New Inventario
            GvInventarios.DataSource = objbuscar.buscar_inventario_bodega(bodega.Value)
            GvInventarios.DataBind()
            'label2.text = ""

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

    Protected Sub txtexistencias_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtexistencias.TextChanged
        Try

            'Retorna Solo la Identificacion de la Bodega. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenausu As String = txtexistencias.Text
            For i = 1 To Len(Cadenausu)

                If Mid(Cadenausu, i, 1) = " " Then
                    bodegaexis.Value = Trim(Left(Cadenausu, i))
                    Exit For
                End If
            Next


            Dim objbuscar As New Inventario
            GvExistencias.DataSource = objbuscar.buscar_existencias_bodega(bodegaexis.Value)
            GvExistencias.DataBind()
            'label2.text = ""

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

    Protected Sub ImpRep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImpRep.Click
        Try
            'Retorna Solo la Identificacion de la Bodega. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenausu As String = txtexistencias.Text
            For i = 1 To Len(Cadenausu)

                If Mid(Cadenausu, i, 1) = " " Then
                    bodegaexis.Value = Trim(Left(Cadenausu, i))
                    Exit For
                End If
            Next
            Response.Redirect("~/Reportes/ViewReporte_Bodega.aspx?idbodega=" & bodegaexis.Value)

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
End Class
