Imports System.Data
Imports System.Data.SqlClient

Partial Class Forms_cotizacion
    Inherits System.Web.UI.Page
    Dim con As New conexion
    Dim objcomando As New SqlClient.SqlCommand
    Dim conn As New SqlConnection(con.conex)
    Dim guardartotal As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'valida el permiso a la pagina
        Dim pagina As String = "Cotizacion"
        Dim objpermi As New usuario
        objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
        Dim ds As New DataSet
        If IsPostBack = False Then
            'realizar al auditoria
            Dim objadi As New Auditoria
            objadi.registro_auditoria(pagina, Session("login").ToString)

        End If
        If Not Page.IsPostBack Then



            txtcant.Attributes.Add("onkeypress", "return AcceptNum(event)") '' permite solo ingresar numeros
            accion.Value = 1 ' variable que indica un insert
            Dim obj As New Bodegas
            cbbodega.DataSource = obj.consultar_bodega.Tables(0)
            cbbodega.DataValueField = "registro"
            cbbodega.DataTextField = "nombre"
            cbbodega.DataBind()
            cbbodega.Items.Insert(0, "Seleccionar...")


            Dim tbl As New DataTable
            tbl.Columns.Add("CODIGO")
            tbl.Columns.Add("NOMBRE")
            tbl.Columns.Add("DESCRIPCION")
            tbl.Columns.Add("VALOR")
            tbl.Columns.Add("CANT")
            tbl.Columns.Add("TOTAL")
            ViewState("tabla") = tbl

            ViewState("guardartotal") = guardartotal

            If Request.QueryString("p1") <> "" Then
            

                Dim objconsulcotiza As New cotizacion
                ' Dim ds As DataSet
                Dim fcoti As Date
                Dim fvenci As Date
                ds = objconsulcotiza.buscar_cotiza_detalle(Request.QueryString("p1"))

                txtnumcotiza.Text = ds.Tables(0).Rows(0).Item("registro").ToString
                fcoti = ds.Tables(0).Rows(0).Item("fecha_coti").ToString
                txtfcoti.Text = Format(fcoti, "MM-dd-yyyy")
                fvenci = ds.Tables(0).Rows(0).Item("fecha_ven_coti").ToString
                txtfvenci.Text = Format(fvenci, "MM-dd-yyyy")
                txtcli.Text = ds.Tables(0).Rows(0).Item("id").ToString & " " & ds.Tables(0).Rows(0).Item("nombre").ToString & " " & ds.Tables(0).Rows(0).Item("apellido").ToString
                'txttotal.Text = (String.Format("{0:n2}", ds.Tables(0).Rows(0).Item("valor_cot").ToString)) '' Solo es para visializar pero no loguarda con ese formato



                Dim dt As DataTable = ViewState("tabla")



                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim fila As DataRow = dt.NewRow
                    fila("CODIGO") = ds.Tables(0).Rows(i).Item("cod").ToString
                    fila("NOMBRE") = ds.Tables(0).Rows(i).Item("Producto").ToString
                    fila("DESCRIPCION") = ds.Tables(0).Rows(i).Item("descripcion").ToString
                    fila("VALOR") = (String.Format("{0:n2}", ds.Tables(0).Rows(i).Item("valor").ToString))
                    fila("CANT") = ds.Tables(0).Rows(i).Item("cantidad_pro").ToString
                    fila("TOTAL") = (String.Format("{0:n2}", (ds.Tables(0).Rows(i).Item("cantidad_pro").ToString) * (ds.Tables(0).Rows(i).Item("valor").ToString)))
                    'fila("TOTAL") = (txtcant.Text * ds.Tables(0).Rows(0).Item("valor").ToString) ''Multiplica la cantidad X valor del producto
                    dt.Rows.Add(fila)

                Next
                GridView1.DataSource = dt
                GridView1.DataBind()
                Me.ViewState("tabla") = dt

                'Suma el Total de Productos:
                Dim total As Integer ' variable para almacenar la suma de productos
                For i As Integer = 0 To dt.Rows.Count - 1

                    total += dt.Rows(i)("TOTAL")

                Next

                'guardartotal = total
                ViewState("guardartotal") = total

                txttotal.Text = String.Format("{0:n2}", total) '' Solo es para visializar pero no loguarda con ese formato


        
                accion.Value = 2 ''variable que indica que se va a realizar un Update


                'txtfecha2.Text = Format(Date.Today.Date, "MM-dd-yyyy")


                'Dim f1 As Date = txtfecha1.Tex
                'txtfecha1.Text = Format(f1, "MM-dd-yyyy")


                'txtregis.Enabled = False
                'txtfecha1.Enabled = False

            Else
                txtfcoti.Text = Format(Date.Today.Date, "MM-dd-yyyy")
                'txtfecha1.Text = Format(Date.Today.Date, "MM-dd-yyyy")
                'desahibitar()
                'cbestado.SelectedValue = "ABIERTO"

            End If




        End If



    End Sub

    Protected Sub btnagregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        Try
            Dim codproducto As Integer

            'Valida que digiten el cliente
            If Len(Trim(txtcli.Text)) = 0 Then
                Label1.Visible = True
                Label1.Text = "Debe indicar un cliente"
                Label1.ForeColor = Drawing.Color.Red
                txtcli.Focus()
                Exit Sub
            End If


            'valida que seleccionen una bodega y digiten un producto:
            If Len(Trim(txtpro.Text)) = 0 Then
                Label1.Visible = True
                Label1.Text = "Seleccione un Producto"
                Label1.ForeColor = Drawing.Color.Red
                Exit Sub
            End If

            'valida que ingresen la cantidad de producto:

            If Len(Trim(txtcant.Text)) = 0 Then
                Label1.Visible = True
                Label1.Text = "Debe especificar una Cantidad"
                Label1.ForeColor = Drawing.Color.Red
                txtcant.Focus()
                Exit Sub
            End If


            'Retorna Solo el campo de busqueda para el nombre. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenaproducto As String = txtpro.Text
            Dim cont As Integer = Len(Cadenaproducto)
            For i As Integer = cont To 1 Step -1

                If Mid(Cadenaproducto, i, 1) = " " Then
                    Dim ab As Integer = cont - i
                    codproducto = Trim(Right(Cadenaproducto, ab))
                    objcomando.Parameters.Add("@id", SqlDbType.Int).Value = codproducto
                    Exit For
                End If

            Next

            'FIN



            Dim dt As DataTable = ViewState("tabla") '' = Me.ViewState("dtseleccion")
            Dim fila As DataRow = dt.NewRow

            'Valida que el producto no se repita en la cotizacion

            If dt.Rows.Count = 0 Then  '' si la tabla esta en 0 la llena con el 1er producto

                agregar_producto()


            Else ''si ya tiene productos verifica que no este en la tabla


                For i As Integer = 0 To dt.Rows.Count


                    If dt.Rows(i)("CODIGO") = codproducto Then
                        Label1.Visible = True
                        Label1.Text = "El Producto ya fue Ingresado"
                        Label1.ForeColor = Drawing.Color.Red
                        Exit For


                    ElseIf dt.Rows(i)("CODIGO") <> codproducto Then ' si no esta en la tabla lo agrega y se sale del for

                        agregar_producto()
                        Exit For

                    End If

                Next

            End If


        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = "No se Encontro El Producto"
            Label1.ForeColor = Drawing.Color.Red
            txtpro.Text = ""
            txtpro.Focus()

        End Try
    End Sub

    Protected Sub cbbodega_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbodega.SelectedIndexChanged
        Session("idbodega") = cbbodega.SelectedValue



    End Sub

    Protected Sub txtpro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpro.TextChanged

    End Sub

    Public Sub agregar_producto()

        objcomando.Connection = conn
        objcomando.CommandText = "consultar_productobyid"
        objcomando.CommandType = CommandType.StoredProcedure

        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()



        Dim dt As DataTable = ViewState("tabla") '' = Me.ViewState("dtseleccion")
        Dim fila As DataRow = dt.NewRow

        fila("CODIGO") = ds.Tables(0).Rows(0).Item("id").ToString
        fila("NOMBRE") = ds.Tables(0).Rows(0).Item("nombre").ToString
        fila("DESCRIPCION") = ds.Tables(0).Rows(0).Item("descripcion").ToString
        fila("VALOR") = ds.Tables(0).Rows(0).Item("valor").ToString
        fila("CANT") = txtcant.Text
        fila("TOTAL") = String.Format("{0:n2}", (txtcant.Text * ds.Tables(0).Rows(0).Item("valor").ToString)) ''Multiplica la cantidad X valor del producto
        dt.Rows.Add(fila)
        GridView1.DataSource = dt
        GridView1.DataBind()
        Me.ViewState("tabla") = dt

        'Suma el Total de Productos:
        Dim total As Integer ' variable para almacenar la suma de productos
        For i As Integer = 0 To dt.Rows.Count - 1

            total += dt.Rows(i)("TOTAL")
    
        Next

        'guardartotal = total
        ViewState("guardartotal") = total

        txttotal.Text = String.Format("{0:n2}", total) '' Solo es para visializar pero no loguarda con ese formato

        txtpro.Text = ""
        txtcant.Text = ""
        txtpro.Focus()
        Label1.Visible = False


    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        'Elimina Los productos seleccionados en la tabla
        Try
            Dim dt As New DataTable
            dt = Me.ViewState("tabla")
            dt.Rows.RemoveAt(e.RowIndex)
            Me.ViewState("tabla") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()
            txtpro.Text = ""
            txtpro.Focus()


        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnlimpiar.Click
        limpiar()
        habilitar()
        accion.Value = 1
    End Sub

    Public Sub limpiar()
        Label1.Text = ""
        Label1.Focus()
        txtnumcotiza.Text = ""
        txtfvenci.Text = ""
        txtcli.Text = ""
        cbbodega.Text = "Seleccionar..."
        txtpro.Text = ""
        txtcant.Text = ""
        ViewState("tabla") = Nothing
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        txttotal.Text = ""
        Dim tbl As New DataTable
        tbl.Columns.Add("CODIGO")
        tbl.Columns.Add("NOMBRE")
        tbl.Columns.Add("DESCRIPCION")
        tbl.Columns.Add("VALOR")
        tbl.Columns.Add("CANT")
        tbl.Columns.Add("TOTAL")
        ViewState("tabla") = tbl
    End Sub

    Public Sub habilitar()

        txtfvenci.Enabled = True
        txtcli.Enabled = True
        cbbodega.Enabled = True
        txtpro.Enabled = True
        txtcant.Enabled = True
        btnagregar.Enabled = True
        btnlimpiar.Enabled = True
        btnguardar.Enabled = True

    End Sub

    Public Sub deshabilitar()
        txtfvenci.Enabled = False
        txtcli.Enabled = False
        cbbodega.Enabled = False
        txtpro.Enabled = False
        txtcant.Enabled = False
        btnagregar.Enabled = False
        btnlimpiar.Enabled = False
        btnguardar.Enabled = False

    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        Try

            ''obtener el id del cliente
            ''Retorna Solo la Identificacion del cliente. Busca el 1er espacio y toma todos los digitos de izq a der
            Dim Cadenacli As String = txtcli.Text
            For i = 1 To Len(Cadenacli)

                If Mid(Cadenacli, i, 1) = " " Then
                    idcli.Value = Trim(Left(Cadenacli, i))
                    Exit For
                End If
            Next
            ''FIN


            If txtfvenci.Text < txtfcoti.Text Then

                Label1.Text = "Fecha Vencimiento Invalida "
                txtfvenci.Text = ""
                txtfvenci.Focus()
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True
                Exit Sub
            End If


            If accion.Value = 1 Then ''variable que indica que se realizara un insert


                Dim objcoti As New cotizacion


                Dim idcoti As Integer = objcoti.ingresar_cotizacion(txtfvenci.Text, ViewState("guardartotal").ToString, idcli.Value)

                Dim dt As DataTable = ViewState("tabla")

                For i As Integer = 0 To dt.Rows.Count - 1

                    objcoti.ingresar_cotiza_detalle(idcoti, Integer.Parse(dt.Rows(i)("CODIGO")), Integer.Parse(dt.Rows(i)("CANT")))

                Next

                txtnumcotiza.Text = idcoti
                Label1.Visible = True
                Label1.Text = "Cotizacion Guardada"
                Label1.ForeColor = Drawing.Color.Blue


                deshabilitar()
                btnlimpiar.Enabled = True



            ElseIf accion.Value = 2 Then  ''variable que indica que se realizara un update

                Dim objelimicotizadetalle As New cotizacion
                Dim objcoti As New cotizacion

                objelimicotizadetalle.eliminar_cotiza_detalle(Integer.Parse(txtnumcotiza.Text)) ''Elimina todos los items de la cotizacion para volverlos a crear

                Dim dt As DataTable = ViewState("tabla")

                For i As Integer = 0 To dt.Rows.Count - 1

                    objcoti.ingresar_cotiza_detalle(Integer.Parse(txtnumcotiza.Text), Integer.Parse(dt.Rows(i)("CODIGO")), Integer.Parse(dt.Rows(i)("CANT")))

                Next

                'Suma el Total de Productos:
                Dim total As Integer ' variable para almacenar la suma de productos
                For i As Integer = 0 To dt.Rows.Count - 1

                    total += dt.Rows(i)("TOTAL")

                Next

                guardartotal = total ''Es la varable que se va a guardar
                txttotal.Text = String.Format("{0:n2}", total) '' Solo es para visializar pero no loguarda con ese formato


                'Modifica en la tabla cotizacion
                objcoti.modificar_cotizacion(txtnumcotiza.Text, txtfvenci.Text, ViewState("guardartotal").ToString, idcli.Value)
                Label1.Visible = True
                Label1.Text = "Cotizacion Actualizada"
                Label1.ForeColor = Drawing.Color.Blue


            End If


        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
        End Try
 
    End Sub

    Protected Sub txttotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        Try

 
            If Len(Trim(txtnumcotiza.Text)) = 0 Then
                Label1.Visible = True
                Label1.Text = "Primero debe Guardar la Cotizacion"
                Label1.ForeColor = Drawing.Color.Red
                Exit Sub

            End If

            Response.Redirect("~/Reportes/ViewReporte_Cotizacion.aspx?IdCoti=" & Integer.Parse(txtnumcotiza.Text))

        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Red
        End Try

    End Sub
End Class
