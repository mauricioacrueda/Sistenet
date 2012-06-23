Imports System.Data

Partial Class Forms_Factura
    Inherits System.Web.UI.Page

#Region "Variables"

    Dim objfac As New factura
    Private AccionExitosa As Integer
    Private AccionExitosa2 As Boolean

#End Region

#Region "Procedimientos y Funciones.."

    Private Sub AtributosJavaScript()
        btnAgregarDt.Attributes("onmouseover") = "this.src='../Imagenes/btnAgregar2.png';"
        btnAgregarDt.Attributes("onmouseout") = "this.src='../Imagenes/btnAgregar.png';"

        btnRegresarD.Attributes("onmouseover") = "this.src='../Imagenes/btnCancelar2.png';"
        btnRegresarD.Attributes("onmouseout") = "this.src='../Imagenes/btnCancelar.png';"

        btnReporte.Attributes("onmouseover") = "this.src='../Imagenes/btnImprimir2.png';"
        btnReporte.Attributes("onmouseout") = "this.src='../Imagenes/btnImprimir.png';"

        btnCancelarDt.Attributes("onmouseover") = "this.src='../Imagenes/btnLimpiar2.png';"
        btnCancelarDt.Attributes("onmouseout") = "this.src='../Imagenes/btnLimpiar.png';"

        btnCerrarD.Attributes("onmouseover") = "this.src='../Imagenes/btnCerrar2.png';"
        btnCerrarD.Attributes("onmouseout") = "this.src='../Imagenes/btnCerrar.png';"
        btnModificarD.Attributes("onmouseover") = "this.src='../Imagenes/btnModificar2.png';"
        btnModificarD.Attributes("onmouseout") = "this.src='../Imagenes/btnModificar.png';"
        btnModificarDt.Attributes("onmouseover") = "this.src='../Imagenes/btnModificar2.png';"
        btnModificarDt.Attributes("onmouseout") = "this.src='../Imagenes/btnModificar.png';"

        btnBuscarD.Attributes("onmouseover") = "this.src='../Imagenes/btnbuscar2.png';"
        btnBuscarD.Attributes("onmouseout") = "this.src='../Imagenes/btnBuscar.png';"

        'Busqueda
        btnCalendarBD.Attributes.Add("onmouseover", "return BorrarFechaBusqueda('" + txtFechaBD.ClientID & "')")
        txtBuscarBD.Attributes.Add("onfocus", "SetSelected('" + txtBuscarBD.ClientID & "')")

        txtBuscarBD.Attributes.Add("OnKeyPress", "return AcceptNum(event)")
        txtCantidadDt.Attributes.Add("OnKeyPress", "return AcceptNum(event)")

        txtValorUnitarioDt.Attributes.Add("OnKeyPress", "return AcceptNumComa(event)")

        'txtclienteb.Attributes.Add("onChange", "return EnviarFocoBusqueda('" + txtBuscarBD.ClientID & "')")
        'ddlEstadoBD.Attributes.Add("onChange", "return EnviarFocoBusqueda('" + txtBuscarBD.ClientID & "')")

    End Sub

    Private Sub ReasignarValoresLoad()
        If Request(txtFechaHoraVencimientoD.UniqueID) <> "" Then
            If Request(txtFechaBD.UniqueID) Is Nothing Then
                txtFechaHoraVencimientoD.Text = String.Format("{0:d}", DateTime.Now)
            Else
                txtFechaHoraVencimientoD.Text = Request(txtFechaHoraVencimientoD.UniqueID)
            End If
        End If

        If Request(txtFechaBD.UniqueID) <> "" Then
            If Request(txtFechaBD.UniqueID) Is Nothing Then
                txtFechaBD.Text = "Todos"
            Else
                txtFechaBD.Text = Request(txtFechaBD.UniqueID)
            End If
        End If

        'Detalles del Documento
        If Request(txtBrutoDt.UniqueID) <> "" Then
            txtBrutoDt.Text = Request(txtBrutoDt.UniqueID)
        End If

        If Request(txtIvaDt.UniqueID) <> "" Then
            txtIvaDt.Text = Request(txtIvaDt.UniqueID)
        End If

        If Request(txtNetoDt.UniqueID) <> "" Then
            txtNetoDt.Text = Request(txtNetoDt.UniqueID)
        End If

    End Sub


#Region "Documentos.."

    Private Sub ActivarGridViewD(ByVal Valor As Boolean)
        If gvwDocumentos.Rows.Count > 0 Then
            For Each row As GridViewRow In gvwDocumentos.Rows
                Dim Editar As ImageButton = DirectCast(row.FindControl("IbnEditar"), ImageButton)
                Dim Eliminar As ImageButton = DirectCast(row.FindControl("IbnEliminar"), ImageButton)
                Dim Ver As ImageButton = DirectCast(row.FindControl("IbnAgregar"), ImageButton)

                Editar.Enabled = Valor
                Eliminar.Enabled = Valor
                Ver.Enabled = Valor
            Next
        End If
    End Sub

    Private Sub ActivarBusquedaD(ByVal Valor As Boolean)
        txtclienteb.Enabled = Valor
        ddlEstadoBD.Enabled = Valor
        ddlOpcionBusquedaBD.Enabled = Valor
        txtBuscarBD.ReadOnly = Not Valor
        btnBuscarD.Enabled = Valor
        btnCalendarBD.Enabled = Valor
        lbnVerTodosD.Enabled = Valor

        If Valor Then
            btnBuscarD.ToolTip = "Clic para Buscar las Facturas."
            btnBuscarD.ImageUrl = "../Imagenes/btnBuscar.png"
            btnBuscarD.Attributes("onmouseover") = "this.src='../Imagenes/btnbuscar2.png';"
            btnBuscarD.Attributes("onmouseout") = "this.src='../Imagenes/btnBuscar.png';"
        Else
            btnBuscarD.ToolTip = "En el momento, no hay Facturas Creadas en el sistema."
            btnBuscarD.ImageUrl = "../Imagenes/btnbuscar3.png"
        End If
    End Sub

    Private Sub CargarBodegas()
        Dim ds As New DataSet
        Dim obj As New Bodegas
        ds = obj.consultar_bodega()

        If (ds.Tables(0).Rows.Count > 0) Then
            ddlBodega.Items.Clear()
            ddlBodega.DataSource = ds
            ddlBodega.Items.Add(New ListItem("Seleccione la Bodega..", "0"))
            ddlBodega.DataValueField = "registro"
            ddlBodega.DataTextField = "Nombre"
            ddlBodega.DataBind()
            ddlBodega.SelectedIndex = 0
        Else
            ddlBodega.Items.Clear()
            ddlBodega.Items.Add(New ListItem("Seleccione la Bodega...", "0"))
            ddlBodega.Enabled = False
        End If

    End Sub

    Private Sub CargarProveedores()
        Dim ds As New DataSet
        Dim obj As New proveedor
        ds = obj.consultar_proveedor()

        If (ds.Tables(0).Rows.Count > 0) Then
            ddlProveedores.Items.Clear()
            ddlProveedores.DataSource = ds
            ddlProveedores.Items.Add(New ListItem("Seleccione el Proveedor..", "0"))
            ddlProveedores.DataValueField = "codigo"
            ddlProveedores.DataTextField = "nombre"
            ddlProveedores.DataBind()
            ddlProveedores.SelectedIndex = 0
        Else
            ddlProveedores.Items.Clear()
            ddlProveedores.Items.Add(New ListItem("Seleccione la Proveedor...", "0"))
            ddlProveedores.Enabled = False
        End If

    End Sub

    Private Sub CargarEstadosBusqueda(ByVal Ddl As DropDownList)
        If Ddl.Items.Count > 0 Then
            Ddl.Items.Clear()
        End If
        Ddl.Items.Add(New ListItem("Todos", "0"))
        Ddl.Items.Add(New ListItem("Abierta", "1"))
        Ddl.Items.Add(New ListItem("Cerrada", "2"))
        Ddl.Items.Add(New ListItem("Inactiva", "3"))
        Ddl.SelectedIndex = 0
    End Sub

    Private Sub CargarOpcionesBusquedaD()
        If ddlOpcionBusquedaBD.Items.Count > 0 Then
            ddlOpcionBusquedaBD.Items.Clear()
        End If
        ddlOpcionBusquedaBD.Items.Add(New ListItem("Número Factura", "0"))
        ddlOpcionBusquedaBD.Items.Add(New ListItem("Observación", "1"))
        ddlOpcionBusquedaBD.SelectedIndex = 0
    End Sub

    Private Sub CargarTiposFactura()
        ddlTipoFac.Items.Clear()
        ddlTipoFac.Items.Add(New ListItem("Seleccione...", "0"))
        ddlTipoFac.Items.Add(New ListItem("Factura de Compra", "FC"))
        ddlTipoFac.Items.Add(New ListItem("Factura de Venta", "FV"))
        ddlTipoFac.DataBind()
    End Sub

    Private Sub CargarDocumentosTodos()
        ViewState("Paginar") = 1
        'Todos 

        Dim DtData As New DataSet()
        DtData = objfac.consultar_facturas()

        If DtData.Tables(0).Rows.Count > 0 Then
            gvwDocumentos.DataSource = DtData.Tables(0)
            gvwDocumentos.DataBind()
            imgAlertD.ImageUrl = ""
            imgAlertD.Visible = False

            Me.ActivarBusquedaD(True)
        Else
            gvwDocumentos.DataSource = Nothing
            gvwDocumentos.DataBind()
            imgAlertD.ImageUrl = "../Imagenes/Alert2.png"
            imgAlertD.Visible = True

            Me.ActivarBusquedaD(False)
        End If
    End Sub

    Private Sub CargarDatosDocumentos()
        If (txtFechaBD.Text <> "Todos") OrElse (ddlEstadoBD.SelectedIndex <> 0) OrElse (txtcliente.Text.Trim().Length <> 0) OrElse (txtBuscarBD.Text.Trim().Length <> 0) Then
            'Me.CargarDocumentosBusqueda()
            lbnVerTodosD.Visible = True
        Else

            Dim DtData As New DataSet()
            DtData = objfac.consultar_facturas()

            If DtData.Tables(0).Rows.Count > 0 Then
                Me.ActivarBusquedaD(True)
            Else
                Me.ActivarBusquedaD(False)
            End If
            gvwDocumentos.DataSource = Nothing
            gvwDocumentos.DataBind()
            lbnVerTodosD.Visible = False
        End If
    End Sub

   Private Sub CargarDocumentosBusqueda()
        'ViewState("Paginar") = 2

        Dim cliente As String = txtclienteb.Text
        Dim estado As String = ddlEstadoBD.SelectedValue
        Dim fecha As String = txtFechaBD.Text
        Dim opcion As String = ddlOpcionBusquedaBD.SelectedValue
        Dim obs As String = txtBuscarBD.Text

        Dim DtData As New DataSet()

        Dim idcli As Integer = 0
        Dim Cadenacli As String = cliente
        For i = 1 To Len(Cadenacli)
            If Mid(Cadenacli, i, 1) = " " Then
                idcli = Trim(Left(Cadenacli, i))
                Exit For
            End If
        Next

        'solo por cliente
        If cliente <> "" And estado = "0" And fecha = "Todos" Then
            DtData = objfac.busqueda_factura(idcli, 0, 0, "", 0, "")
        End If

        'solo por estado
        If cliente = "" And estado <> "0" And fecha = "Todos" Then
            DtData = objfac.busqueda_factura(idcli, Integer.Parse(estado), 0, "", 1, "")
        End If

        'solo por fecha
        If cliente = "" And estado = "0" And fecha <> "Todos" Then
            DtData = objfac.busqueda_factura(idcli, 0, 0, "", 2, fecha)
        End If

        'solo por numero de factura
        If cliente = "" And estado = "0" And fecha = "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, 0, 1, obs, 3, fecha)
        End If

        'solo por observaciones
        If cliente = "" And estado = "0" And fecha = "Todos" And opcion = "1" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, 0, 2, obs, 4, fecha)
        End If

        ' por cliente y estado
        If cliente <> "" And estado <> "0" And fecha = "Todos" And opcion = "0" And obs = "" Then
            DtData = objfac.busqueda_factura(idcli, estado, 1, obs, 5, fecha)
        End If

        'por cliente y fecha
        If cliente <> "" And estado = "0" And fecha <> "Todos" And opcion = "0" And obs = "" Then
            DtData = objfac.busqueda_factura(idcli, 0, 1, obs, 6, fecha)
        End If

        'por cliente y numero de factura
        If cliente <> "" And estado = "0" And fecha = "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, 0, 1, obs, 7, fecha)
        End If

        'por estado y fecha
        If cliente = "" And estado <> "0" And fecha <> "Todos" And opcion = "0" And obs = "" Then
            DtData = objfac.busqueda_factura(idcli, estado, 1, obs, 8, fecha)
        End If

        'por estado y numero de factura
        If cliente = "" And estado <> "0" And fecha = "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, estado, 1, obs, 9, fecha)
        End If

        'por fecha y numero de factura
        If cliente = "" And estado = "0" And fecha <> "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, 0, 1, obs, 10, fecha)
        End If

        'por cliente, estado, fecha, numero factura
        If cliente <> "" And estado <> "0" And fecha <> "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, estado, 1, obs, 11, fecha)
        End If

        'por cliente, estado, fecha
        If cliente <> "" And estado <> "0" And fecha <> "Todos" And opcion = "0" And obs = "" Then
            DtData = objfac.busqueda_factura(idcli, estado, 1, obs, 12, fecha)
        End If

        'por cliente, estado, numero factura
        If cliente <> "" And estado <> "0" And fecha = "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, estado, 1, obs, 13, fecha)
        End If

        'por cliente, fecha, numero factura
        If cliente <> "" And estado = "0" And fecha <> "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, 0, 1, obs, 14, fecha)
        End If

        'por estado, fecha, numero factura
        If cliente = "" And estado <> "0" And fecha <> "Todos" And opcion = "0" And obs <> "" Then
            DtData = objfac.busqueda_factura(idcli, estado, 1, obs, 15, fecha)
        End If

        'If DtData.Tables.Count > 0 Then
        '    Me.ActivarBusquedaD(True)
        'Else
        '    Me.ActivarBusquedaD(False)
        'End If

        If DtData.Tables.Count > 0 Then
            gvwDocumentos.DataSource = DtData
            gvwDocumentos.DataBind()
            imgAlertD.ImageUrl = ""
            imgAlertD.Visible = False
        Else
            gvwDocumentos.DataSource = Nothing
            gvwDocumentos.DataBind()
            imgAlertD.ImageUrl = "../Imagenes/Alert.png"
            imgAlertD.Visible = True
        End If

    End Sub

    Private Sub CargarDocumentoPorIdDocumento(ByVal IdDocumento As Integer)

        Dim DtData As New DataSet()
        DtData = objfac.consultar_datos_factura(IdDocumento)

        If DtData.Tables(0).Rows.Count > 0 Then
            gvwDocumentos.DataSource = DtData
            gvwDocumentos.DataBind()
        Else
            gvwDocumentos.DataSource = Nothing
            gvwDocumentos.DataBind()
        End If

        If Not btnBuscarD.Enabled Then
            Me.ActivarBusquedaD(True)
        End If
    End Sub

    Private Sub LimpiarDocumentoValores()

        txtTotalValorBrutoPF.Text = String.Empty
        txtTotalIvaPF.Text = String.Empty
        txtValorBrutoconIvaPF.Text = String.Empty
        txtTotalValorNetoPF.Text = String.Empty
        txtValorEnLetrasPF.Text = String.Empty

        If btnCerrarD.Visible Then
            btnCerrarD.Visible = False
        End If
        If btnReporte.Visible Then
            btnReporte.Visible = False
        End If
    End Sub

    Private Sub LimpiarDocumentos()
        txtcliente.Text = ""

        Dim PeriodoActual As String = If(DateTime.Now.Month.ToString().Length = 1, "0" & DateTime.Now.Month.ToString(), DateTime.Now.Month.ToString())
        Dim LapsoActual As String = DateTime.Now.Year.ToString() & " - " & PeriodoActual

        ddlTipoFac.ClearSelection()

        ddlBodega.ClearSelection()
        If ddlBodega.Items.Count = 2 Then
            ddlBodega.SelectedIndex = 1
        End If

        txtFechaHoraCreacionD.Text = String.Format("{0:d}", DateTime.Now)

        txtFechaHoraVencimientoD.Text = String.Format("{0:d}", DateTime.Now)

        txtObservacionD.Text = ""

    End Sub

    Private Sub DesactivarDocumento(ByVal IdDocumento As Integer)
        AccionExitosa2 = objfac.desactivar_factura(IdDocumento)
        If AccionExitosa2 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Factura de Venta desactivada exitosamente');</script>", False)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ha ocurrido un error en el sistema');</script>", False)
        End If
    End Sub

    Private Sub HabilitarDocumento(ByVal Valor As Boolean)
        cbxSwActivoD.Visible = Not Valor
        lblActivoD.Visible = Not Valor
        btnModificarD.Visible = Not Valor
        btnRegresarD.Visible = Not Valor
    End Sub

    Private Sub LlenarDocumento(ByVal IdDocumento As Integer)
        ViewState("EsNuevo") = False
        Me.EstaCerradoDocumento(False)
        Me.HabilitarDocumento(False)
        btnModificarD.Focus()

        lblTituloD.Text = "Edición de la Factura"

        Dim ds As New DataSet
        ds = objfac.consultar_datos_factura(IdDocumento)

        ViewState("IdDocumento") = IdDocumento

        CargarBodegas()
        CargarTiposFactura()

        Dim liIdCentro As ListItem = ddlBodega.Items.FindByValue(ds.Tables(0).Rows(0)("id_bodega").ToString().ToString())
        If liIdCentro IsNot Nothing Then
            ddlBodega.SelectedValue = ds.Tables(0).Rows(0)("id_bodega").ToString()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('El Centro asociado a la Factura, no está disponible');</script>", False)
            ddlBodega.ClearSelection()
        End If

        Dim liIdTipoPagoFactura As ListItem = ddlTipoFac.Items.FindByValue(ds.Tables(0).Rows(0)("tipo_fac").ToString())
        If liIdTipoPagoFactura IsNot Nothing Then
            ddlTipoFac.SelectedValue = ds.Tables(0).Rows(0)("tipo_fac").ToString()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('El Tipo asociado a la Factura, no está disponible');</script>", False)
            ddlTipoFac.ClearSelection()
        End If

        ddlTipoFac.Enabled = False



        If ds.Tables(0).Rows(0)("tipo_fac").ToString() = "FC" Then

            lblTerD.Visible = False
            txtcliente.Visible = False
            rfvIdTerceroD.Enabled = False

            ddlBodega.Visible = False
            lblBodega.Visible = False

            ddlProveedores.Visible = True
            lblProveedores.Visible = True
            CargarTodosConceptos()

            ViewState("IdTercero") = ds.Tables(0).Rows(0)("id_cli")

        Else

            lblTerD.Visible = True
            txtcliente.Visible = True
            rfvIdTerceroD.Enabled = True

            ddlProveedores.Visible = False
            lblProveedores.Visible = False

            ddlBodega.Visible = True
            lblBodega.Visible = True
            CargarConceptos()

        End If

        pnlNumeroSistema.Visible = True

        lblNumeroSistema.Text = ds.Tables(0).Rows(0)("registro").ToString()

        txtcliente.Text = ds.Tables(0).Rows(0)("cliente").ToString()

        txtFechaHoraCreacionD.Text = Format(ds.Tables(0).Rows(0)("fecha_fac").ToString(), "Short Date")
        'String.Format("{0:d}", ds.Tables(0).Rows(0)("fecha_fac").ToString())

        txtFechaHoraVencimientoD.Text = Format(ds.Tables(0).Rows(0)("fecha_ven_fac").ToString(), "Short Date")
        'String.Format("{0:d}", ds.Tables(0).Rows(0)("fecha_ven_fac").ToString())

        txtObservacionD.Text = ds.Tables(0).Rows(0)("observaciones").ToString()

        cbxSwActivoD.Checked = Convert.ToBoolean(ds.Tables(0).Rows(0)("ind").ToString())

        Me.PreparaDocumentosDetalle(IdDocumento)

        ViewState("EsNuevo") = False

        Me.Panel1.Visible = True
        Me.Panel2.Visible = False

        'cerrada
        If ds.Tables(0).Rows(0)("estado_fac").ToString() = "2" Then
            btnModificarD.Visible = False
            btnRegresarD.Visible = False
            btnAgregarDt.Visible = False
            btnModificarDt.Visible = False
            btnCancelarDt.Visible = False
            btnCerrarD.Visible = False
            btnReporte.Visible = True
        End If

        Me.ModificarPieDeFactura()


    End Sub

    Private Function ValidarTerceroSeleccionado(ByVal tercero As clientes_sistenet) As Boolean
        Dim TerceroValido As Boolean = True

        Dim DtDetalles As New DataTable()
        'DtDetalles = Documento.ObtenerDocumentosDetallePorDocumento(Convert.ToInt32(ViewState("IdDocumento")))

        For i As Integer = 0 To DtDetalles.Rows.Count - 1
            Dim IdConceptoV As Int32 = Convert.ToInt32(DtDetalles.Rows(i)("IdConcepto"))

            'If (Concepto.ObtenerValoresFacturacionVentasPorIdConcepto(IdConceptoV, DateTime.Now.Year.ToString(), tercero.IdCiudad, tercero.IdTercero).Tables(1).Rows.Count > 0) Then
            '    TerceroValido = True
            'Else
            '    TerceroValido = False
            '    Exit For
            'End If
        Next

        Return TerceroValido
    End Function

    Private Sub ModificarDocumento()

        If txtFechaHoraVencimientoD.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe seleccionar una fecha de vencimiento.');</script>", False)
            Exit Sub
        End If

        If txtcliente.Text.Trim().Length > 0 Or ddlProveedores.SelectedValue <> "0" Then

            Dim ds1 As New DataSet
            Dim dt As New DataTable
            ds1.Dispose()
            ds1.Clear()
            dt = Nothing
            dt = Me.ViewState("dtConceptos")
            ds1.Tables.Add(dt.Copy())

            If ddlTipoFac.SelectedValue = "FV" Then

                Dim dv As DataView = ds1.Tables(0).DefaultView
                dv.RowFilter = "id=" & Integer.Parse(ddlIdConceptoDt.SelectedValue) & ""

                Dim entero As Integer = Integer.Parse(dv.Table.Rows(0)("cantidad"))
                Dim decimales As Integer = Integer.Parse(Math.Round((entero - entero) * 100, 2))

                Dim iExistencias As Integer = 0
                Dim dExistencias As Integer = 0

                If decimales > 0 Then
                    dExistencias = entero
                    iExistencias = 0
                Else
                    iExistencias = entero
                    dExistencias = 0
                End If

                Dim Mensaje As String = String.Empty

                If (entero < Integer.Parse(txtCantidadDt.Text.Trim())) Then

                    If (iExistencias = 0 And dExistencias > 0) Then

                        Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + dExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                        txtCantidadDt.Focus()
                        Exit Sub

                    ElseIf (iExistencias > 0 And dExistencias = 0) Then

                        Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + iExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                        txtCantidadDt.Focus()
                        Exit Sub

                    End If

                End If

                ''Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
                Dim Cadenacli As String = txtcliente.Text
                For i = 1 To Len(Cadenacli)
                    If Mid(Cadenacli, i, 1) = " " Then
                        Me.Session("id_cli") = Trim(Left(Cadenacli, i))
                        Exit For
                    End If
                Next

            Else

                Me.Session("id_cli") = ddlProveedores.SelectedValue

            End If

        Else

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe ingresar un Cliente o seleccionar un Proveedor.');</script>", False)
            Exit Sub

        End If

        'idusuario que inicio sesion
        Me.Session("cedempleado") = "01"

        If ddlTipoFac.SelectedValue = "FC" Then
            'bodega por defecto de compras 1
            AccionExitosa2 = objfac.modificar_factura(Integer.Parse(ViewState("IdDocumento")), DateTime.Parse(txtFechaHoraVencimientoD.Text), ddlTipoFac.SelectedValue, Decimal.Parse(txtBrutoDt.Text), Decimal.Parse(txtIvaDt.Text), Decimal.Parse(txtNetoDt.Text), 1, 1, Me.Session("id_cli"), Me.Session("cedempleado").ToString(), Me.txtObservacionD.Text)
        Else
            AccionExitosa2 = objfac.modificar_factura(Integer.Parse(ViewState("IdDocumento")), DateTime.Parse(txtFechaHoraVencimientoD.Text), ddlTipoFac.SelectedValue, Decimal.Parse(txtBrutoDt.Text), Decimal.Parse(txtIvaDt.Text), Decimal.Parse(txtNetoDt.Text), 1, Integer.Parse(ddlBodega.SelectedValue), Me.Session("id_cli"), Me.Session("cedempleado").ToString(), Me.txtObservacionD.Text)
        End If

        If AccionExitosa2 Then

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Factura actualizada exitosamente');</script>", False)

        Else

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ha ocurrido un error en el sistema');</script>", False)

        End If
    End Sub

    Private Sub CambiarBotonesInactivos(ByVal Valor As Boolean)
        If Valor Then
            btnModificarD.ImageUrl = "../Imagenes/btnModificar3.png"
            btnCerrarD.ImageUrl = "../Imagenes/btnCerrar3.png"
            btnAgregarDt.ImageUrl = "../Imagenes/btnAgregar3.png"
            btnCancelarDt.ImageUrl = "../Imagenes/btnLimpiar3.png"
        Else
            btnModificarD.ImageUrl = "../Imagenes/btnModificar.png"
            btnModificarD.Attributes("onmouseover") = "this.src='../Imagenes/btnModificar2.png';"
            btnModificarD.Attributes("onmouseout") = "this.src='../Imagenes/btnModificar.png';"

            btnCerrarD.ImageUrl = "../Imagenes/btnCerrar.png"
            btnCerrarD.Attributes("onmouseover") = "this.src='../Imagenes/btnCerrar2.png';"
            btnCerrarD.Attributes("onmouseout") = "this.src='../Imagenes/btnCerrar.png';"

            btnAgregarDt.ImageUrl = "../Imagenes/btnAgregar.png"
            btnAgregarDt.Attributes("onmouseover") = "this.src='../Imagenes/btnAgregar2.png';"
            btnAgregarDt.Attributes("onmouseout") = "this.src='../Imagenes/btnAgregar.png';"

            btnCancelarDt.ImageUrl = "../Imagenes/btnLimpiar.png"
            btnCancelarDt.Attributes("onmouseover") = "this.src='../Imagenes/btnLimpiar2.png';"
            btnCancelarDt.Attributes("onmouseout") = "this.src='../Imagenes/btnLimpiar.png';"
        End If
    End Sub

    Private Sub EstaCerradoDocumento(ByVal Valor As Boolean)
        'Documentos
        btnReporte.Visible = Valor
        btnCerrarD.Enabled = Not Valor
        btnModificarD.Enabled = Not Valor

        txtcliente.Enabled = Not Valor

        ddlBodega.Enabled = Not Valor
        txtObservacionD.Enabled = Not Valor
        cbxSwActivoD.Enabled = Not Valor
        ddlTipoFac.Enabled = Not Valor
        btnCalendarD.Enabled = Not Valor

        'DocumentosDetallle      
        Me.ActivarGridViewDt(Not Valor)

        pnlNuevoDet.Visible = Not Valor
        ddlIdConceptoDt.Enabled = Not Valor
        txtCantidadDt.Enabled = Not Valor
        txtValorUnitarioDt.Enabled = Not Valor
        cbxSwActivoDt.Enabled = Not Valor
        btnAgregarDt.Enabled = Not Valor
        btnModificarDt.Enabled = Not Valor
        btnCancelarDt.Enabled = Not Valor

        gvwDetalle.Columns(0).Visible = Not Valor
        gvwDetalle.Columns(1).Visible = Not Valor

        Me.CambiarBotonesInactivos(Valor)
    End Sub

#End Region

#Region "DocumentosDetalle.."

    Private Sub BotonAgregarActivo(ByVal Activo As Boolean)
        btnAgregarDt.Enabled = Activo

        If Activo Then
            btnAgregarDt.ImageUrl = "../Imagenes/btnAgregar.png"
            btnAgregarDt.Attributes("onmouseover") = "this.src='../Imagenes/btnAgregar2.png';"
            btnAgregarDt.Attributes("onmouseout") = "this.src='../Imagenes/btnAgregar.png';"
        Else
            btnAgregarDt.ImageUrl = "../Imagenes/btnAgregar3.png"
        End If
    End Sub

    Private Sub LimpiarDetalle()
        ddlIdConceptoDt.ClearSelection()

        txtCantidadDt.Text = "1"
        txtCantidadDt.Enabled = False

        txtValorUnitarioDt.Text = String.Empty
        txtValorUnitarioDt.Enabled = False

        txtBrutoDt.Text = "0"
        txtIvaDt.Text = "0"
        txtNetoDt.Text = "0"

        btnCancelarDt.Visible = False
        Me.BotonAgregarActivo(False)

    End Sub

    Private Sub ActivarGridViewDt(ByVal Valor As Boolean)
        If gvwDetalle.Rows.Count > 0 Then
            For Each row As GridViewRow In gvwDetalle.Rows
                Dim Eliminar As ImageButton = DirectCast(row.FindControl("IbnEliminar"), ImageButton)
                Eliminar.Enabled = Valor
            Next
        End If
    End Sub

    Private Sub CargarFacturas()
        Dim DsData As New DataSet()

        DsData = objfac.consultar_facturas()
        If DsData.Tables(0).Rows.Count > 0 Then
            gvwDocumentos.DataSource = DsData.Tables(0)
            gvwDocumentos.DataBind()
            Me.ActivarBusquedaD(True)
        Else
            Me.ActivarBusquedaD(False)
        End If
    End Sub

    Private Sub CargarConceptos()
        Dim DsData As New DataSet()
        Dim obj As New Productos
        DsData = obj.consultar_producto_byidbodega(Integer.Parse(ddlBodega.SelectedValue))
        If DsData.Tables(0).Rows.Count > 0 Then

            Me.ViewState("dtConceptos") = Nothing
            Me.ViewState("dtConceptos") = DsData.Tables(0)
            If ddlIdConceptoDt.Items.Count > 0 Then
                ddlIdConceptoDt.Items.Clear()
            End If

            ddlIdConceptoDt.DataSource = DsData.Tables(0)
            ddlIdConceptoDt.Items.Add(New ListItem("Seleccione su opción", "0"))
            ddlIdConceptoDt.DataValueField = "id_pro"
            ddlIdConceptoDt.DataTextField = "Nombre"
            ddlIdConceptoDt.DataBind()

            ddlIdConceptoDt.Enabled = True
            txtCantidadDt.Enabled = True
            txtValorUnitarioDt.Enabled = False
            txtBrutoDt.Enabled = False
            txtIvaDt.Enabled = False
            txtNetoDt.Enabled = False

            Me.lblMensajeBodega.Visible = False

        Else

            Me.lblMensajeBodega.Visible = True

            ddlIdConceptoDt.Items.Clear()
            ddlIdConceptoDt.Items.Add(New ListItem("Seleccione su opción", "0"))
        End If
    End Sub

    Private Sub CargarTodosConceptos()
        Dim DsData As New DataSet()
        Dim obj As New Productos
        DsData = obj.consultar_producto
        If DsData.Tables(0).Rows.Count > 0 Then

            Me.ViewState("dtConceptos") = Nothing
            Me.ViewState("dtConceptos") = DsData.Tables(0)
            If ddlIdConceptoDt.Items.Count > 0 Then
                ddlIdConceptoDt.Items.Clear()
            End If

            ddlIdConceptoDt.DataSource = DsData.Tables(0)
            ddlIdConceptoDt.Items.Add(New ListItem("Seleccione su opción", "0"))
            ddlIdConceptoDt.DataValueField = "codigo"
            ddlIdConceptoDt.DataTextField = "Nombre"
            ddlIdConceptoDt.DataBind()

            ddlIdConceptoDt.Enabled = True
            txtCantidadDt.Enabled = True
            txtValorUnitarioDt.Enabled = False
            txtBrutoDt.Enabled = False
            txtIvaDt.Enabled = False
            txtNetoDt.Enabled = False

            Me.lblMensajeBodega.Visible = False

        Else
            ddlIdConceptoDt.Items.Clear()
            ddlIdConceptoDt.Items.Add(New ListItem("Seleccione su opción", "0"))

            Me.lblMensajeBodega.Visible = True

        End If
    End Sub

    Private Sub CargarDetallesTodos()
        Dim DsData As New DataSet()
        DsData = objfac.consultar_detalle_factura(Integer.Parse(ViewState("IdDocumento").ToString()))

        If DsData.Tables(0).Rows.Count > 0 Then
            gvwDetalle.DataSource = DsData.Tables(0)
            gvwDetalle.DataBind()
            btnCerrarD.Visible = True
        Else
            gvwDetalle.DataSource = Nothing
            gvwDetalle.DataBind()
            btnCerrarD.Visible = False
        End If
    End Sub

    Private Sub ModificarPieDeFactura()

        Dim DsSumas As New DataSet()
        DsSumas = objfac.ObtenerSumatoriasValoresDetalleFactura(Integer.Parse(ViewState("IdDocumento").ToString()))

        If DsSumas.Tables(0).Rows.Count > 0 Then

            Dim TotalValorBruto As Decimal = 0
            Dim ValorBrutoConIva As Decimal = 0
            Dim TotalValorNeto As Decimal = 0
            Dim TotalIva As Decimal = 0

            For i As Integer = 0 To DsSumas.Tables(0).Rows.Count - 1

                TotalIva += Decimal.Parse(DsSumas.Tables(0).Rows(i)("SUMIva").ToString())
                'TotalValorNeto+ = Decimal.Round(Decimal.Parse(DsSumas.Tables(0).Rows(I)("SUMNeto").ToString()), 2)
                TotalValorNeto += Convert.ToDecimal(DsSumas.Tables(0).Rows(i)("SUMNeto"))
                TotalValorBruto += Decimal.Parse(DsSumas.Tables(0).Rows(i)("SUMBruto").ToString())
                ValorBrutoConIva += TotalValorBruto + Decimal.Parse(DsSumas.Tables(0).Rows(i)("SUMIva").ToString())

            Next

            txtTotalIvaPF.Text = Decimal.Round(TotalIva, 2).ToString()

            'Me.ObtenerValorNetoActual(DsSumas.Tables(0))

            txtTotalValorBrutoPF.Text = Decimal.Round(TotalValorBruto, 2).ToString()

            txtTotalValorNetoPF.Text = Decimal.Round(TotalValorNeto, 2).ToString()

            txtValorBrutoconIvaPF.Text = Decimal.Round(ValorBrutoConIva, 2).ToString()

            txtValorEnLetrasPF.Text = ValorEnLetras(txtTotalValorNetoPF.Text)

        Else

            ViewState("ValorNetoActual") = "0"

        End If

    End Sub

    Public Shared Function ValorEnLetras(ByVal Numero As String) As String
        Dim res As String, dec As String = ""
        Dim entero As Int64
        Dim decimales As Integer
        Dim nro As Double
        Try
            nro = Convert.ToDouble(Numero)
        Catch
            Return ""
        End Try
        entero = Convert.ToInt64(Math.Truncate(nro))
        decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2))
        If decimales > 0 Then
            dec = " CON " & decimales.ToString() & "/100"
        End If
        res = PasarATexto(Convert.ToDouble(entero)) & dec & " PESOS MCTE."
        Return res
    End Function

    Private Shared Function PasarATexto(ByVal value As Double) As String
        Dim Num2Text As String = ""
        value = Math.Truncate(value)
        If value = 0 Then
            Num2Text = "CERO"
        ElseIf value = 1 Then
            Num2Text = "UNO"
        ElseIf value = 2 Then
            Num2Text = "DOS"
        ElseIf value = 3 Then
            Num2Text = "TRES"
        ElseIf value = 4 Then
            Num2Text = "CUATRO"
        ElseIf value = 5 Then
            Num2Text = "CINCO"
        ElseIf value = 6 Then
            Num2Text = "SEIS"
        ElseIf value = 7 Then
            Num2Text = "SIETE"
        ElseIf value = 8 Then
            Num2Text = "OCHO"
        ElseIf value = 9 Then
            Num2Text = "NUEVE"
        ElseIf value = 10 Then
            Num2Text = "DIEZ"
        ElseIf value = 11 Then
            Num2Text = "ONCE"
        ElseIf value = 12 Then
            Num2Text = "DOCE"
        ElseIf value = 13 Then
            Num2Text = "TRECE"
        ElseIf value = 14 Then
            Num2Text = "CATORCE"
        ElseIf value = 15 Then
            Num2Text = "QUINCE"
        ElseIf value < 20 Then
            Num2Text = "DIECI" & PasarATexto(value - 10)
        ElseIf value = 20 Then
            Num2Text = "VEINTE"
        ElseIf value < 30 Then
            Num2Text = "VEINTI" & PasarATexto(value - 20)
        ElseIf value = 30 Then
            Num2Text = "TREINTA"
        ElseIf value = 40 Then
            Num2Text = "CUARENTA"
        ElseIf value = 50 Then
            Num2Text = "CINCUENTA"
        ElseIf value = 60 Then
            Num2Text = "SESENTA"
        ElseIf value = 70 Then
            Num2Text = "SETENTA"
        ElseIf value = 80 Then
            Num2Text = "OCHENTA"
        ElseIf value = 90 Then
            Num2Text = "NOVENTA"
        ElseIf value < 100 Then
            Num2Text = PasarATexto(Math.Truncate(value / 10) * 10) & " Y " & PasarATexto(value Mod 10)
        ElseIf value = 100 Then
            Num2Text = "CIEN"
        ElseIf value < 200 Then
            Num2Text = "CIENTO " & PasarATexto(value - 100)
        ElseIf (value = 200) OrElse (value = 300) OrElse (value = 400) OrElse (value = 600) OrElse (value = 800) Then
            Num2Text = PasarATexto(Math.Truncate(value / 100)) & "CIENTOS"
        ElseIf value = 500 Then
            Num2Text = "QUINIENTOS"
        ElseIf value = 700 Then
            Num2Text = "SETECIENTOS"
        ElseIf value = 900 Then
            Num2Text = "NOVECIENTOS"
        ElseIf value < 1000 Then
            Num2Text = PasarATexto(Math.Truncate(value / 100) * 100) & " " & PasarATexto(value Mod 100)
        ElseIf value = 1000 Then
            Num2Text = "MIL"
        ElseIf value < 2000 Then
            Num2Text = "MIL " & PasarATexto(value Mod 1000)
        ElseIf value < 1000000 Then
            Num2Text = PasarATexto(Math.Truncate(value / 1000)) & " MIL"
            If (value Mod 1000) > 0 Then
                Num2Text = Num2Text & " " & PasarATexto(value Mod 1000)
            End If
        ElseIf value = 1000000 Then
            Num2Text = "UN MILLON"
        ElseIf value < 2000000 Then
            Num2Text = "UN MILLON " & PasarATexto(value Mod 1000000)
        ElseIf value < 1000000000000L Then
            Num2Text = PasarATexto(Math.Truncate(value / 1000000)) & " MILLONES "
            If (value - Math.Truncate(value / 1000000) * 1000000) > 0 Then
                Num2Text = Num2Text & " " & PasarATexto(value - Math.Truncate(value / 1000000) * 1000000)
            End If
        ElseIf value = 1000000000000L Then
            Num2Text = "UN BILLON"
        ElseIf value < 2000000000000L Then
            Num2Text = "UN BILLON " & PasarATexto(value - Math.Truncate(value / 1000000000000L) * 1000000000000L)
        Else
            Num2Text = PasarATexto(Math.Truncate(value / 1000000000000L)) & " BILLONES"
            If (value - Math.Truncate(value / 1000000000000L) * 1000000000000L) > 0 Then
                Num2Text = Num2Text & " " & PasarATexto(value - Math.Truncate(value / 1000000000000L) * 1000000000000L)
            End If
        End If

        Return Num2Text

    End Function

    Private Sub ObtenerValorNetoActual(ByVal DtSumas As DataTable)
        If DtSumas.Rows.Count > 0 Then
            Dim ValorNeto As Decimal = Convert.ToDecimal(DtSumas.Rows(0)("SUMNeto"))
            ViewState("ValorNetoActual") = DtSumas.Rows(0)("SUMNeto").ToString()
            ViewState("ValorNetoActualSinDcto") = ValorNeto.ToString()
        Else
            ViewState("ValorNetoActual") = "0"
            ViewState("ValorNetoActualSinDcto") = "0"
        End If
    End Sub

    Private Sub PreparaDocumentosDetalle(ByVal IdDocumento As Integer)

        Me.CargarDetallesTodos()

        'Dim DtSumas As New DataTable()
        'Me.ObtenerValorNetoActual(DtSumas)

        Me.LimpiarDetalle()

        'Me.LlenarEncabezadoPieFactura(IdDocumento)

        Me.EsNuevoDetalle(True)

        txtValorUnitarioDt.Enabled = False

    End Sub

    Private Sub EsNuevoDetalle(ByVal Valor As Boolean)
        btnAgregarDt.Visible = Valor

        btnModificarDt.Visible = Not Valor

        If Valor Then
            btnAgregarDt.Focus()
        Else
            btnModificarDt.Focus()
        End If

        Me.ActivarGridViewDt(Valor)

        lblActivoDt.Visible = Not Valor
        cbxSwActivoDt.Visible = Not Valor
    End Sub

    Private Sub DesactivarDetalle(ByVal IdDetalle As Integer)
        AccionExitosa2 = objfac.BorrarDocumentoDetalle(IdDetalle)
        If AccionExitosa2 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Detalle de Factura desactivado exitosamente.');</script>", False)
            Me.CargarDetallesTodos()
            If btnCerrarD.Visible = True Then
                CargarDetallesTodos()
                'If Documento.ObtenerDocumentosDetalleActivosPorDocumento(Convert.ToInt32(ViewState("IdDocumento"))).Rows.Count > 0 Then
                '    btnCerrarD.Visible = True
                'Else
                '    btnCerrarD.Visible = False
                'End If
            End If
            Me.ModificarPieDeFactura()
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ha ocurrido un error en el sistema.');</script>", False)
        End If
    End Sub

    Private Sub CalcularValoresDetalle()

        If ddlIdConceptoDt.SelectedIndex > 0 Then

            If btnAgregarDt.Visible = True Then
                Me.BotonAgregarActivo(True)
            End If

            btnCancelarDt.Visible = True
            txtValorUnitarioDt.Enabled = True
            txtCantidadDt.Enabled = True

            Dim ValorReteFuente As Decimal = 0
            Dim ValorReteIca As Decimal = 0
            Dim ValorIva As Decimal = 16
            Dim ValorReteIva As Decimal = 0
            Dim ValorNeto As Decimal = 0
            Dim ValorNetoSinDescuento As Decimal = 0
            Dim ValorDescuento As Decimal = 0

            ViewState("ReteFuenteValido") = False
            Dim PorcentajeRubrosValor As Decimal = 0
            Dim ValorBrutoDetalle As Decimal = 0

            Dim IvaVentas As Decimal = 16
            Dim Base As Decimal = 0
            Dim Multiplicador As Int16 = 0
            Dim ValorVenta As Decimal = 0

            Dim DsData As New DataSet()
            DsData = objfac.consultar_productobyid(Integer.Parse(ddlIdConceptoDt.SelectedValue))

            'DATOS DEL CONCEPTO
            If DsData.Tables(0).Rows.Count > 0 Then

                ViewState("TipoIva") = "GR"

                If Not String.IsNullOrEmpty(DsData.Tables(0).Rows(0)("Valor").ToString()) Then
                    ValorVenta = Convert.ToDecimal(DsData.Tables(0).Rows(0)("Valor"))
                End If

                txtValorUnitarioDt.Text = ValorVenta.ToString()

                ValorBrutoDetalle = Convert.ToDecimal(txtCantidadDt.Text.Trim()) * Convert.ToDecimal(txtValorUnitarioDt.Text.Trim())

            End If


            txtIvaDt.Text = ValorBrutoDetalle * ValorIva / 100

            txtBrutoDt.Text = Decimal.Round(ValorBrutoDetalle, 2).ToString()

            'ValorNeto = ValorBrutoDetalle - (ValorReteFuente + ValorReteIca) + (ValorIva - ValorReteIva) - ValorDescuento
            ValorNeto = ValorBrutoDetalle + (ValorBrutoDetalle * ValorIva / 100)

            ' ValorNetoSinDescuento = ValorBrutoDetalle - (ValorReteFuente + ValorReteIca) + (ValorIva - ValorReteIva)
            ValorNetoSinDescuento = ValorNeto
            ViewState("ValorNeto") = Decimal.Round(ValorNetoSinDescuento, 2)
            txtNetoDt.Text = Decimal.Round(ValorNeto, 2).ToString()

            txtCantidadDt.Attributes.Clear()
            txtValorUnitarioDt.Attributes.Clear()

            txtCantidadDt.Attributes.Add("onkeyup", (((((("return CalcularValoresDetalle('" + btnAgregarDt.ClientID & "','") + ddlIdConceptoDt.ClientID & "','") + txtCantidadDt.ClientID & "','") + txtValorUnitarioDt.ClientID & "','") + txtBrutoDt.ClientID & "','") + txtIvaDt.ClientID & "','") + txtNetoDt.ClientID & "','" & IvaVentas.ToString() & "','" & PorcentajeRubrosValor & "','" & Base.ToString() & "','" & Multiplicador.ToString() & "')")

            txtValorUnitarioDt.Attributes.Add("onkeyup", (((((("return CalcularValoresDetalle('" + btnAgregarDt.ClientID & "','") + ddlIdConceptoDt.ClientID & "','") + txtCantidadDt.ClientID & "','") + txtValorUnitarioDt.ClientID & "','") + txtBrutoDt.ClientID & "','") + txtIvaDt.ClientID & "','") + txtNetoDt.ClientID & "','" & IvaVentas.ToString() & "','" & PorcentajeRubrosValor & "','" & Base.ToString() & "','" & Multiplicador.ToString() & "')")

            txtCantidadDt.Attributes.Add("OnKeyPress", "return AcceptNum(event)")

            txtValorUnitarioDt.Attributes.Add("OnKeyPress", "return AcceptNumComa(event)")


        Else

            If btnAgregarDt.Visible = True Then
                Me.BotonAgregarActivo(False)
            End If

            txtIvaDt.Text = String.Empty
            txtNetoDt.Text = String.Empty
            ViewState("ValorNeto") = 0

            txtValorUnitarioDt.Enabled = False
            txtCantidadDt.Enabled = False

            txtValorUnitarioDt.Text = String.Empty
            txtBrutoDt.Text = String.Empty
            txtCantidadDt.Text = "1"

            btnCancelarDt.Visible = False

        End If

        ddlIdConceptoDt.Enabled = True

        uplConcepto.Update()

    End Sub

#End Region

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'valida el permiso a la pagina
        Dim pagina As String = "factura"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
      
        If Not Page.IsPostBack Then
            Panel1.Visible = False
            LinkButton1.Visible = True
            Panel2.Visible = False
            LinkButton2.Visible = True
            Panel3.Visible = False
            'LinkButton3.Visible = True

        End If

        If IsPostBack = False Then
            'realizar al auditoria
            Dim objadi As New Auditoria
            Dim ds As New DataSet
            objadi.registro_auditoria(pagina, Session("login").ToString)

        End If

        Me.ReasignarValoresLoad()

        If Me.Request(Me.txtFechaHoraVencimientoD.UniqueID) <> "" Then
            Me.txtFechaHoraVencimientoD.Text = Me.Request(Me.txtFechaHoraVencimientoD.UniqueID)
        End If



    End Sub

    Protected Sub gvwDocumentos_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)


        CargarDocumentosTodos()
        gvwDocumentos.PageIndex = e.NewPageIndex
        gvwDocumentos.DataBind()

        'gvwDocumentos.PageIndex = e.NewPageIndex)

        '        If Integer.Parse(ViewState("Paginar").ToString()) = 1 Then
        '            Me.CargarDocumentosTodos()
        '        ElseIf Integer.Parse(ViewState("Paginar").ToString()) = 2 Then
        '            ' Me.CargarDocumentosBusqueda()
        '        End If

      End Sub

    Protected Sub gvwDocumentos_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Dim IdDocumento As Integer = 0
        Dim tipo As String
        If e.CommandName <> "Page" Then
            ' IdDocumento = Convert.ToInt32(e.CommandArgument)
            Dim cadena As String = e.CommandArgument

            IdDocumento = Integer.Parse(cadena.Split("-")(0))
            tipo = cadena.Split("-")(1)
            ViewState("IdDocumento") = IdDocumento
        End If

        Select Case e.CommandName
            Case "Ver"
                'Response.Redirect("~/Reportes/ReporteFactura.aspx?id=" & IdDocumento & "", False)
                Response.Redirect("~/Reportes/ViewReporte_Factura.aspx?Idfactura=" & IdDocumento & "&tipo=" & tipo)
                Exit Select

            Case "Eliminar"
                Me.DesactivarDocumento(IdDocumento)
                Me.CargarEstadosBusqueda(ddlEstadoBD)
                Me.CargarOpcionesBusquedaD()
                Me.CargarFacturas()

                Exit Select

            Case "Editar"
                Me.LlenarDocumento(IdDocumento)
                Exit Select
            Case Else

                Exit Select
        End Select
    End Sub

    Protected Sub gvwDocumentos_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim Editar As ImageButton = DirectCast(e.Row.Cells(3).FindControl("IbnEditar"), ImageButton)
            Dim Eliminar As ImageButton = DirectCast(e.Row.Cells(4).FindControl("IbnEliminar"), ImageButton)
            Dim Ver As ImageButton = DirectCast(e.Row.Cells(2).FindControl("IbnAgregar"), ImageButton)

            Dim IdDocumentoK As String = gvwDocumentos.DataKeys(e.Row.RowIndex).Values("registro").ToString()

            Dim lblSwCerrado As Label = DirectCast(e.Row.Cells(1).FindControl("lblSwCerrado"), Label)
            If lblSwCerrado.Text = "True" Then
                Ver.Visible = True
                Editar.Visible = False
                Eliminar.Visible = False
                lblSwCerrado.CssClass = "LabelRojoNegrita"
            Else
                Ver.Visible = False
                Editar.Visible = True
                Eliminar.Visible = True
                lblSwCerrado.CssClass = "LabelNormal"
            End If
            lblSwCerrado.Text = If(lblSwCerrado.Text = "True", "Si", "No")

            Dim lblTotalValorNeto As Label = DirectCast(e.Row.Cells(1).FindControl("lblTotalValorNeto"), Label)
            If lblTotalValorNeto.Text.Trim().Length = 0 Then
                lblTotalValorNeto.Text = "0"
            End If
        End If
    End Sub

    Protected Sub btnRegresarD_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Me.EstaCerradoDocumento(False)

        lblTituloD.Text = "Creación de la Factura"

        Me.LimpiarDocumentos()

        Me.HabilitarDocumento(True)

        txtcliente.Focus()

        Me.LimpiarDetalle()

        Me.LimpiarDocumentoValores()

        gvwDetalle.DataSource = Nothing
        gvwDetalle.DataBind()

        pnlNumeroSistema.Visible = False
        lblNumeroSistema.Text = String.Empty

        ViewState("EsNuevo") = True

        ' Me.CargarLapsos()

        ddlIdConceptoDt.Enabled = False

    End Sub

    Protected Sub btnModificarD_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnModificarD.Click
        Me.ModificarDocumento()
    End Sub

    Protected Sub btnCerrarD_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCerrarD.Click

        AccionExitosa2 = objfac.cerrar_factura(Integer.Parse(ViewState("IdDocumento").ToString()))

        If AccionExitosa2 Then
          
            Me.CargarDatosDocumentos()
            lblTituloD.Text = "Creación de la Factura"
            Me.EstaCerradoDocumento(True)
            ScriptManager.RegisterClientScriptBlock(Me, [GetType], "mensaje", "$(document).ready(function() {$('#mensaje3 p').empty();$('#mensaje3 p').append('Factura de Venta Cerrada exitosamente.'); $('#mensaje3').dialog('open');});", True)

        Else

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ha ocurrido un error. No se pudo cerrar la factura');</script>", False)

        End If

    End Sub

    Protected Sub btnReporte_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnReporte.Click
        'Response.Redirect("~/Reportes/ReporteFactura.aspx?id=" & ViewState("IdDocumento") & "", False)
        Response.Redirect("~/Reportes/ViewReporte_Factura.aspx?Idfactura=" & ViewState("IdDocumento") & "&tipo=" & ViewState("tipo"))
    End Sub

    Protected Sub ddlOpcionBusquedaBD_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ddlOpcionBusquedaBD.SelectedIndex = 0 Then
            txtBuscarBD.Attributes.Add("OnKeyPress", "return AcceptNum(event)")
        ElseIf ddlOpcionBusquedaBD.SelectedIndex = 1 Then
            txtBuscarBD.Attributes.Add("OnKeyPress", "return NoEnter(event)")
        End If
        txtBuscarBD.Text = String.Empty
        txtBuscarBD.Focus()
        uplBusquedaD.Update()
    End Sub

    Protected Sub btnBuscarD_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnBuscarD.Click
        txtBuscarBD.Focus()

        If (txtFechaBD.Text = "Todos") AndAlso (txtcliente.Text.Trim().Length = 0) AndAlso (ddlEstadoBD.SelectedIndex = 0) AndAlso (txtBuscarBD.Text.Trim().Length = 0) Then
            lbnVerTodosD.Visible = False
        Else
            lbnVerTodosD.Visible = True
        End If
        CargarDocumentosBusqueda()
    End Sub

    Protected Sub lbnVerTodosD_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.CargarDocumentosTodos()
        lbnVerTodosD.Visible = False
        txtBuscarBD.Focus()
    End Sub

    Protected Sub ddlIdConceptoDt_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlIdConceptoDt.SelectedIndexChanged
        Me.CalcularValoresDetalle()
    End Sub

    Protected Sub gvwDetalle_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim Eliminar As ImageButton = DirectCast(e.Row.Cells(0).FindControl("IbnEliminar"), ImageButton)

            Dim SwActivoK As String = gvwDetalle.DataKeys(e.Row.RowIndex).Values("SwActivo").ToString()
            If SwActivoK = "True" Then
                Eliminar.Visible = True
            Else
                Eliminar.Visible = False
            End If

            If e.Row.Cells(6).Text = "True" Then
                e.Row.Cells(6).Text = "Si"
            Else
                e.Row.Cells(6).Text = "No"
            End If

        End If

    End Sub

    Protected Sub gvwDetalle_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gvwDetalle.PageIndex = e.NewPageIndex
        Me.CargarDetallesTodos()
    End Sub

    Protected Sub gvwDetalle_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        Dim IdDetalle As Integer = 0
        If e.CommandName <> "Page" Then
            IdDetalle = Convert.ToInt32(e.CommandArgument)
            ViewState("IdDetalle") = IdDetalle
        End If

        Select Case e.CommandName

            Case "Eliminar"

                If gvwDetalle.Rows.Count > 1 Then
                    Me.DesactivarDetalle(IdDetalle)
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe existir como mínimo un artículo en la factura.');</script>", False)

                End If

                Exit Select
            Case Else

                Exit Select
        End Select
    End Sub

    Protected Sub btnCancelarDt_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Me.LimpiarDetalle()

        Me.EsNuevoDetalle(True)

        ddlIdConceptoDt.Focus()
    End Sub


    Protected Sub btnModificarDt_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
       'Hago Insert en DocumentosDetalle
        Dim id As Integer = objfac.verificarExisteFacturaDetalle(Integer.Parse(ViewState("IdDocumento")), Integer.Parse(ddlIdConceptoDt.SelectedValue))

        If id = 0 Then

            Dim ds1 As New DataSet
            Dim dt As New DataTable
            ds1.Dispose()
            ds1.Clear()
            dt = Nothing
            dt = Me.ViewState("dtConceptos")
            ds1.Tables.Add(dt.Copy())

            Dim dv As DataView = ds1.Tables(0).DefaultView
            dv.RowFilter = "id=" & Integer.Parse(ddlIdConceptoDt.SelectedValue) & ""

            Dim entero As Integer = Integer.Parse(dv.Table.Rows(0)("cantidad"))
            Dim decimales As Integer = Integer.Parse(Math.Round((entero - entero) * 100, 2))

            Dim iExistencias As Integer = 0
            Dim dExistencias As Integer = 0

            If decimales > 0 Then
                dExistencias = entero
                iExistencias = 0
            Else
                iExistencias = entero
                dExistencias = 0
            End If

            Dim Mensaje As String = String.Empty

            If (entero < Integer.Parse(txtCantidadDt.Text.Trim())) Then

                If (iExistencias = 0 And dExistencias > 0) Then

                    Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + dExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                    txtCantidadDt.Focus()
                    Exit Sub

                ElseIf (iExistencias > 0 And dExistencias = 0) Then

                    Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + iExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                    txtCantidadDt.Focus()
                    Exit Sub

                End If

            End If


            ''Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenacli As String = txtcliente.Text
            For i = 1 To Len(Cadenacli)
                If Mid(Cadenacli, i, 1) = " " Then
                    Me.Session("id_cli") = Trim(Left(Cadenacli, i))
                    Exit For
                End If
            Next

            Dim ds As New DataSet
            Dim obj As New clientes_sistenet
            ds = obj.consultar_datos_clientes(Integer.Parse(Me.Session("id_cli")))

            Me.Session("cedempleado") = Me.Session("login")

            Dim iddetfac As Boolean = objfac.crear_detalle_factura(Integer.Parse(ViewState("IdDocumento")), Integer.Parse(Me.ddlIdConceptoDt.SelectedValue), Integer.Parse(txtCantidadDt.Text), Decimal.Parse(txtValorUnitarioDt.Text), Decimal.Parse(txtIvaDt.Text))

            If iddetfac = False Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrió un error al ingresar el detalle de la factura.');</script>", False)
                Exit Sub
            End If

            ViewState("IdDocumento") = ViewState("IdDocumento")
            ViewState("IdTercero") = Me.Session("id_cli")
            ViewState("EsNuevo") = False

            pnlNumeroSistema.Visible = True
            lblNumeroSistema.Text = ViewState("IdDocumento").ToString()

            btnModificarD.Visible = True
            btnAgregarDt.Enabled = False
            ddlIdConceptoDt.Focus()

            Me.ModificarPieDeFactura()

            Me.LimpiarDetalle()

            Me.CargarDetallesTodos()

            Me.ActivarGridViewDt(True)

            'Cargo en Busqueda        
            txtclienteb.Text = ""
            CargarEstadosBusqueda(ddlEstadoBD)
            ddlEstadoBD.SelectedIndex = 0
            CargarOpcionesBusquedaD()
            ddlOpcionBusquedaBD.SelectedIndex = 0
            txtBuscarBD.Text = ViewState("IdDocumento").ToString()
            txtFechaBD.Text = "Todos"

            Me.CargarDocumentoPorIdDocumento(ViewState("IdDocumento"))


        Else

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ya hay un Detalle creado para el Concepto selecionado. Modifique el Detalle existente.');</script>", False)

        End If
    End Sub

    Protected Sub ddlBodega_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBodega.SelectedIndexChanged

        If Me.ddlBodega.SelectedIndex <> 0 Then

            If ddlTipoFac.SelectedValue = "FC" Then
                CargarTodosConceptos()
            Else
                Me.CargarConceptos()
            End If

        Else
            ddlIdConceptoDt.Enabled = False
            txtCantidadDt.Enabled = False
            txtValorUnitarioDt.Enabled = False
            txtBrutoDt.Enabled = False
            txtIvaDt.Enabled = False
            txtNetoDt.Enabled = False
        End If

    End Sub

    Protected Sub btnAgregarDt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgregarDt.Click

        If Boolean.Parse(ViewState("EsNuevo")) Then

            If Me.ViewState("cont") Is Nothing Then

                If txtFechaHoraVencimientoD.Text = "" Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe seleccionar una fecha de vencimiento.');</script>", False)
                    Exit Sub
                End If

                If txtcliente.Text.Trim().Length > 0 Or ddlProveedores.SelectedValue <> "0" Then

                    Dim ds1 As New DataSet
                    Dim dt As New DataTable
                    ds1.Dispose()
                    ds1.Clear()
                    dt = Nothing
                    dt = Me.ViewState("dtConceptos")
                    ds1.Tables.Add(dt.Copy())

                    If ddlTipoFac.SelectedValue = "FV" Then

                        Dim dv As DataView = ds1.Tables(0).DefaultView
                        dv.RowFilter = "id=" & Integer.Parse(ddlIdConceptoDt.SelectedValue) & ""

                        Dim entero As Integer = Integer.Parse(DirectCast(DirectCast(dv.Item(0), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(7).ToString()) ' Integer.Parse(dv.Table.Rows(0)("cantidad"))
                        Dim decimales As Integer = Integer.Parse(Math.Round((entero - entero) * 100, 2))

                        Dim iExistencias As Integer = 0
                        'Dim dExistencias As Integer = 0

                        If decimales > 0 Then
                            ' dExistencias = entero
                            iExistencias = 0
                        Else
                            iExistencias = entero
                            'dExistencias = 0
                        End If

                        Dim Mensaje As String = String.Empty

                        If (entero < Integer.Parse(txtCantidadDt.Text.Trim())) Then

                            'If (iExistencias = 0 And dExistencias > 0) Then
                            If (iExistencias <= 0) Then
                                Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + iExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                                txtCantidadDt.Focus()
                                Exit Sub
                                'ElseIf (iExistencias > 0) Then
                                '    Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + iExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                                '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                                '    txtCantidadDt.Focus()
                                '    Exit Sub

                            End If

                        End If

                        ''Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
                        Dim Cadenacli As String = txtcliente.Text
                        For i = 1 To Len(Cadenacli)
                            If Mid(Cadenacli, i, 1) = " " Then
                                Me.Session("id_cli") = Trim(Left(Cadenacli, i))
                                Exit For
                            End If
                        Next

                    Else

                        Me.Session("id_cli") = ddlProveedores.SelectedValue

                    End If

                Else

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe ingresar un Cliente o seleccionar un Proveedor.');</script>", False)
                    Exit Sub

                End If

                'idusuario que inicio sesion
                Me.Session("cedempleado") = Me.Session("login")

                Dim idfac As Integer

                If ddlTipoFac.SelectedValue = "FC" Then
                    'bodega por defecto de compras 1                                    
                    ViewState("tipo") = "FC"
                    idfac = objfac.crear_factura(DateTime.Parse(txtFechaHoraVencimientoD.Text), ddlTipoFac.SelectedValue, Decimal.Parse(txtBrutoDt.Text), Decimal.Parse(txtIvaDt.Text), Decimal.Parse(txtNetoDt.Text), 1, 1, Me.Session("id_cli"), Me.Session("cedempleado").ToString(), Me.txtObservacionD.Text)
                Else
                    idfac = objfac.crear_factura(DateTime.Parse(txtFechaHoraVencimientoD.Text), ddlTipoFac.SelectedValue, Decimal.Parse(txtBrutoDt.Text), Decimal.Parse(txtIvaDt.Text), Decimal.Parse(txtNetoDt.Text), 1, Integer.Parse(ddlBodega.SelectedValue), Me.Session("id_cli"), Me.Session("cedempleado").ToString(), Me.txtObservacionD.Text)
                    ViewState("tipo") = "FV"
                End If


                If idfac > 0 Then

                    Dim iddetfac As Boolean = objfac.crear_detalle_factura(idfac, Integer.Parse(Me.ddlIdConceptoDt.SelectedValue), Integer.Parse(txtCantidadDt.Text), Decimal.Parse(txtValorUnitarioDt.Text), Decimal.Parse(txtIvaDt.Text))

                    If iddetfac = False Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrió un error al ingresar el detalle de la factura.');</script>", False)
                        Exit Sub
                    End If

                    ViewState("IdDocumento") = idfac

                    ViewState("IdTercero") = Me.Session("id_cli")
                    ViewState("EsNuevo") = False

                    pnlNumeroSistema.Visible = True
                    lblNumeroSistema.Text = idfac.ToString()

                    btnModificarD.Visible = True
                    btnAgregarDt.Enabled = False
                    ddlIdConceptoDt.Focus()

                    Me.ModificarPieDeFactura()

                    Me.LimpiarDetalle()

                    Me.CargarDetallesTodos()

                    Me.ActivarGridViewDt(True)

                    'Cargo en Busqueda        
                    txtclienteb.Text = ""
                    CargarEstadosBusqueda(ddlEstadoBD)
                    ddlEstadoBD.SelectedIndex = 0
                    CargarOpcionesBusquedaD()
                    ddlOpcionBusquedaBD.SelectedIndex = 0
                    txtBuscarBD.Text = idfac.ToString()
                    txtFechaBD.Text = "Todos"

                    Me.CargarDocumentoPorIdDocumento(idfac)

                Else

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ha ocurrido un error en el sistema');</script>", False)

                End If

                Me.ViewState("cont") = 1

            End If

        Else

            If (Boolean.Parse(ViewState("EsNuevo")) And Not Me.ViewState("cont") Is Nothing) Or Boolean.Parse(ViewState("EsNuevo")) = False Then

                If ddlIdConceptoDt.SelectedValue <> "0" Then

                    'Hago Insert en DocumentosDetalle
                    Dim id As Integer = objfac.verificarExisteFacturaDetalle(Integer.Parse(ViewState("IdDocumento")), Integer.Parse(ddlIdConceptoDt.SelectedValue))

                    If id = 0 Then

                        If txtFechaHoraVencimientoD.Text = "" Then
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe seleccionar una fecha de vencimiento.');</script>", False)
                            Exit Sub
                        End If


                        If txtcliente.Text.Trim().Length > 0 Or ddlProveedores.SelectedValue <> "0" Then

                            Dim ds1 As New DataSet
                            Dim dt As New DataTable
                            ds1.Dispose()
                            ds1.Clear()
                            dt = Nothing
                            dt = Me.ViewState("dtConceptos")
                            ds1.Tables.Add(dt.Copy())

                            If ddlTipoFac.SelectedValue = "FV" Then

                                Dim dv As DataView = ds1.Tables(0).DefaultView
                                dv.RowFilter = "id=" & Integer.Parse(ddlIdConceptoDt.SelectedValue) & ""

                                Dim entero As Integer = Integer.Parse(DirectCast(DirectCast(dv.Item(0), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(7).ToString()) ' Integer.Parse(dv.Table.Rows(0)("cantidad"))
                                Dim decimales As Integer = Integer.Parse(Math.Round((entero - entero) * 100, 2))

                                Dim iExistencias As Integer = 0
                                'Dim dExistencias As Integer = 0

                                If decimales > 0 Then
                                    'dExistencias = entero
                                    iExistencias = 0
                                Else
                                    iExistencias = entero
                                    'dExistencias = 0
                                End If

                                Dim Mensaje As String = String.Empty

                                If (entero < Integer.Parse(txtCantidadDt.Text.Trim())) Then

                                    ' If (iExistencias = 0 And dExistencias > 0) Then
                                    If (iExistencias <= 0) Then

                                        Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + iExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                                        txtCantidadDt.Focus()
                                        Exit Sub

                                        'ElseIf (iExistencias > 0 And dExistencias = 0) Then

                                        '    Mensaje = "la Cantidad digitada Supera las Existencias del Concepto." + Server.HtmlDecode("<br/><b>") + "Existencias (" + iExistencias.ToString() + ")" + Server.HtmlDecode("</b>")
                                        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('la Cantidad digitada Supera las Existencias del Concepto.');</script>", False)
                                        '    txtCantidadDt.Focus()
                                        '    Exit Sub

                                    End If

                                End If

                                ''Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
                                Dim Cadenacli As String = txtcliente.Text
                                For i = 1 To Len(Cadenacli)
                                    If Mid(Cadenacli, i, 1) = " " Then
                                        Me.Session("id_cli") = Trim(Left(Cadenacli, i))
                                        Exit For
                                    End If
                                Next

                            Else

                                Me.Session("id_cli") = ddlProveedores.SelectedValue

                            End If

                        Else

                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Debe ingresar un Cliente o seleccionar un Proveedor.');</script>", False)

                            Exit Sub

                        End If

                        'idusuario que inicio sesion
                        Me.Session("cedempleado") = Me.Session("login")

                        Dim iddetfac As Boolean
                        iddetfac = objfac.crear_detalle_factura(Integer.Parse(ViewState("IdDocumento")), Integer.Parse(Me.ddlIdConceptoDt.SelectedValue), Integer.Parse(txtCantidadDt.Text), Decimal.Parse(txtValorUnitarioDt.Text), Decimal.Parse(txtIvaDt.Text))

                        If iddetfac = False Then
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrió un error al ingresar el detalle de la factura.');</script>", False)
                            Exit Sub
                        Else
                            Dim bandera As Boolean = objfac.actualizar_valores_factura(Integer.Parse(ViewState("IdDocumento")), Decimal.Parse(txtValorUnitarioDt.Text), Decimal.Parse(txtIvaDt.Text))
                        End If

                        ViewState("IdDocumento") = ViewState("IdDocumento")
                        ViewState("IdTercero") = Me.Session("id_cli")
                        ViewState("EsNuevo") = False

                        pnlNumeroSistema.Visible = True
                        lblNumeroSistema.Text = ViewState("IdDocumento").ToString()

                        btnModificarD.Visible = True
                        btnAgregarDt.Enabled = False
                        ddlIdConceptoDt.Focus()

                        Me.ModificarPieDeFactura()

                        Me.LimpiarDetalle()

                        Me.CargarDetallesTodos()

                        Me.ActivarGridViewDt(True)

                        'Cargo en Busqueda        
                        txtclienteb.Text = ""
                        CargarEstadosBusqueda(ddlEstadoBD)
                        ddlEstadoBD.SelectedIndex = 0
                        CargarOpcionesBusquedaD()
                        ddlOpcionBusquedaBD.SelectedIndex = 0
                        txtBuscarBD.Text = ViewState("IdDocumento").ToString()
                        txtFechaBD.Text = "Todos"

                        Me.CargarDocumentoPorIdDocumento(ViewState("IdDocumento"))

                        Exit Sub

                    Else

                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ya hay un Detalle creado para el Concepto selecionado. Modifique el Detalle existente.');</script>", False)

                    End If

                End If

            Else

                Me.ViewState("cont") = 1

            End If

        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        LimpiarDetalle()
        LimpiarDocumentos()
        LimpiarDocumentoValores()

        Panel1.Visible = True
        LinkButton1.Visible = False
        Panel2.Visible = False
        LinkButton2.Visible = False
        Panel3.Visible = False
        LinkButton3.Visible = False
        ViewState("EsNuevo") = True

        Me.AtributosJavaScript()
        Me.CargarBodegas()
        CargarTiposFactura()
        CargarProveedores()
        txtFechaHoraCreacionD.Text = String.Format("{0:d}", DateTime.Now)

        lblTituloD.Text = "Creación de la Factura"

        btnModificarD.Visible = False
        btnRegresarD.Visible = False
        btnCancelarDt.Visible = False

        Me.BotonAgregarActivo(False)
        btnModificarDt.Visible = False

        txtCantidadDt.Text = "1"
        txtValorUnitarioDt.Enabled = False
        txtCantidadDt.Enabled = False

        pnlNumeroSistema.Visible = False
        ddlIdConceptoDt.Enabled = False

        Me.ReasignarValoresLoad()

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Panel1.Visible = False
        LinkButton1.Visible = False
        Panel2.Visible = True
        LinkButton2.Visible = False
        Panel3.Visible = False
        LinkButton3.Visible = False

        Me.CargarEstadosBusqueda(ddlEstadoBD)
        Me.CargarOpcionesBusquedaD()
        Me.CargarFacturas()


    End Sub

    Protected Sub ddlTipoFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoFac.SelectedIndexChanged
        If ddlTipoFac.SelectedValue = "FC" Then

            lblTerD.Visible = False
            txtcliente.Visible = False
            rfvIdTerceroD.Enabled = False

            ddlBodega.Visible = False
            lblBodega.Visible = False

            ddlProveedores.Visible = True
            lblProveedores.Visible = True
            CargarTodosConceptos()



        Else

            lblTerD.Visible = True
            txtcliente.Visible = True
            rfvIdTerceroD.Enabled = True

            ddlProveedores.Visible = False
            lblProveedores.Visible = False

            ddlBodega.Visible = True
            lblBodega.Visible = True

            ddlIdConceptoDt.Items.Clear()
            ddlIdConceptoDt.Items.Add(New ListItem("Seleccione su opción", "0"))
            ddlIdConceptoDt.Enabled = False
            txtCantidadDt.Enabled = False
            txtValorUnitarioDt.Enabled = False
            txtBrutoDt.Enabled = False
            txtIvaDt.Enabled = False
            txtNetoDt.Enabled = False

        End If
    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar.Click
        Panel1.Visible = False
        LinkButton1.Visible = True
        LinkButton2.Visible = True
        'LinkButton3.Visible = True
        LimpiarDetalle()
        LimpiarDocumentos()
        LimpiarDocumentoValores()
    End Sub

    Protected Sub btnRegresar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar1.Click
        Panel2.Visible = False
        LinkButton1.Visible = True
        LinkButton2.Visible = True
        'LinkButton3.Visible = True
    End Sub



    Protected Sub btnBuscarReporte_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscarReporte.Click
        CargarFacturasporCliente()
    End Sub

    Private Sub CargarFacturasporCliente()

        If Me.txtclientereporte.text = "" Then

            ViewState("Paginar") = 1
            'Todos 

            Dim DtData As New DataSet()
            DtData = objfac.consultar_facturas()

            If DtData.Tables(0).Rows.Count > 0 Then
                gvwFacturas.DataSource = DtData.Tables(0)
                gvwFacturas.DataBind()
                imgAlertD0.ImageUrl = ""
                imgAlertD0.Visible = False
            Else
                gvwFacturas.DataSource = Nothing
                gvwFacturas.DataBind()
                imgAlertD0.ImageUrl = "../Imagenes/Alert2.png"
                imgAlertD0.Visible = True

            End If

        Else

            ViewState("Paginar") = 2

            Dim idcliente As Integer

            Dim Cadenacli As String = txtclientereporte.Text
            For i = 1 To Len(Cadenacli)
                If Mid(Cadenacli, i, 1) = " " Then
                    idcliente = Integer.Parse(Trim(Left(Cadenacli, i)))
                    Exit For
                End If
            Next

            Dim DtData As New DataSet()
            DtData = objfac.consultar_facturas_por_cliente(idcliente)

            If DtData.Tables(0).Rows.Count > 0 Then
                gvwFacturas.DataSource = DtData.Tables(0)
                gvwFacturas.DataBind()
                imgAlertD0.ImageUrl = ""
                imgAlertD0.Visible = False
            Else
                gvwFacturas.DataSource = Nothing
                gvwFacturas.DataBind()
                imgAlertD0.ImageUrl = "../Imagenes/Alert2.png"
                imgAlertD0.Visible = True

            End If

        End If

    End Sub


    Protected Sub gvwFacturas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwFacturas.PageIndexChanging
        gvwFacturas.PageIndex = e.NewPageIndex
        If Integer.Parse(ViewState("Paginar").ToString()) = 1 Then
            Me.CargarDocumentosTodos()
        ElseIf Integer.Parse(ViewState("Paginar").ToString()) = 2 Then
        End If
    End Sub

    Protected Sub gvwFacturas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwFacturas.RowCommand
        Dim IdDocumento As Integer = 0
        Dim tipo As String
        If e.CommandName <> "Page" Then
            Dim cadena As String = e.CommandArgument

            IdDocumento = Integer.Parse(cadena.Split("-")(0))
            tipo = cadena.Split("-")(1)
            ViewState("IdDocumento") = IdDocumento
        End If

        Select Case e.CommandName
            Case "Ver"
                'Response.Redirect("~/Reportes/ReporteFactura.aspx?id=" & IdDocumento & "", False)
                Response.Redirect("~/Reportes/ViewReporte_Factura.aspx?Idfactura=" & ViewState("IdDocumento") & "&tipo=" & tipo)
                Exit Select
            Case Else

                Exit Select
        End Select
    End Sub

    Protected Sub gvwFacturas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvwFacturas.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim Ver As ImageButton = DirectCast(e.Row.Cells(2).FindControl("IbnAgregar0"), ImageButton)

            Dim IdDocumentoK As String = gvwFacturas.DataKeys(e.Row.RowIndex).Values("registro").ToString()

            Dim lblSwCerrado As Label = DirectCast(e.Row.Cells(1).FindControl("lblSwCerrado0"), Label)
            If lblSwCerrado.Text = "True" Then
                Ver.Visible = True
                lblSwCerrado.CssClass = "LabelRojoNegrita"
            Else
                Ver.Visible = True
                lblSwCerrado.CssClass = "LabelNormal"
            End If
            lblSwCerrado.Text = If(lblSwCerrado.Text = "True", "Si", "No")

            Dim lblTotalValorNeto As Label = DirectCast(e.Row.Cells(1).FindControl("lblTotalValorNeto0"), Label)
            If lblTotalValorNeto.Text.Trim().Length = 0 Then
                lblTotalValorNeto.Text = "0"
            End If
        End If
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Panel1.Visible = False
        LinkButton1.Visible = False
        Panel2.Visible = False
        LinkButton2.Visible = False
        Panel3.Visible = True
        LinkButton3.Visible = False
    End Sub

    Protected Sub btnRegresar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegresar2.Click
        Panel3.Visible = False
        LinkButton1.Visible = True
        LinkButton2.Visible = True
        'LinkButton3.Visible = True
    End Sub

  
    
End Class
