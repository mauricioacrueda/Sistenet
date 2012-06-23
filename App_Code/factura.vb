Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class factura
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function crear_factura(ByVal fecha_ven_fac As DateTime, _
       ByVal tipo_fac As String, _
       ByVal valor_fac As Decimal, _
       ByVal iva_fac As Decimal, _
       ByVal valor_total_fac As Decimal, _
       ByVal estado_fac As Integer, _
       ByVal id_bodega As Integer, _
       ByVal id_cli As String, _
       ByVal ced_emple As String, _
       ByVal observaciones As String) As Integer

        objcomando.Connection = conn
        objcomando.CommandText = "insertar_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@fecha_ven_fac", SqlDbType.DateTime).Value = fecha_ven_fac
        objcomando.Parameters.Add("@tipo_fac", SqlDbType.Char, 2).Value = tipo_fac
        objcomando.Parameters.Add("@valor_fac", SqlDbType.Float).Value = valor_fac
        objcomando.Parameters.Add("@iva_fac", SqlDbType.Float).Value = iva_fac
        objcomando.Parameters.Add("@valor_total_fac", SqlDbType.Float).Value = valor_total_fac
        objcomando.Parameters.Add("@estado_fac", SqlDbType.Int).Value = estado_fac
        objcomando.Parameters.Add("@id_bodega", SqlDbType.Int).Value = id_bodega
        If tipo_fac = "FV" Then
            objcomando.Parameters.Add("@id_cli", SqlDbType.NVarChar, 20).Value = id_cli
            objcomando.Parameters.Add("@id_pro", SqlDbType.NVarChar, 50).Value = DBNull.Value
        Else
            objcomando.Parameters.Add("@id_cli", SqlDbType.NVarChar, 20).Value = "0000000"
            objcomando.Parameters.Add("@id_pro", SqlDbType.NVarChar, 50).Value = id_cli
        End If
       objcomando.Parameters.Add("@ced_emple", SqlDbType.VarChar, 30).Value = ced_emple
        objcomando.Parameters.Add("@observaciones", SqlDbType.VarChar, 200).Value = observaciones


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim id As Integer = objcomando.ExecuteScalar()

        Return id

    End Function


    Public Function crear_detalle_factura(ByVal idfac As Integer, ByVal producto As Integer, ByVal cantidad As Integer, ByVal valor_pro As Decimal, ByVal valor_iva As Decimal) As Boolean

        Try
            objcomando.Connection = conn
            objcomando.CommandText = "insertar_factura_detalle"
            objcomando.CommandType = CommandType.StoredProcedure
            objcomando.Parameters.Clear()
            objcomando.Parameters.Add("@idfac", SqlDbType.Int).Value = idfac
            objcomando.Parameters.Add("@producto", SqlDbType.Int).Value = producto
            objcomando.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad
            objcomando.Parameters.Add("@valor_det", SqlDbType.Float).Value = valor_pro
            objcomando.Parameters.Add("@iva_det", SqlDbType.Float).Value = valor_iva

            If conn.State = ConnectionState.Closed Then conn.Open()
            objcomando.ExecuteNonQuery()
            conn.Close()
            Return True
        Catch ex As Exception
            conn.Close()
            Return False
        End Try



    End Function

    Public Function actualizar_valores_factura(ByVal idfac As Integer, ByVal valor_pro As Decimal, ByVal valor_iva As Decimal) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "actualizar_valores_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@idfac", SqlDbType.Int).Value = idfac
        objcomando.Parameters.Add("@valor_det", SqlDbType.Float).Value = valor_pro
        objcomando.Parameters.Add("@iva_det", SqlDbType.Float).Value = valor_iva

        If conn.State = ConnectionState.Closed Then conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Function modificar_factura(ByVal registro As Integer, ByVal fecha_ven_fac As DateTime, _
      ByVal tipo_fac As String, _
      ByVal valor_fac As Decimal, _
      ByVal iva_fac As Decimal, _
      ByVal valor_total_fac As Decimal, _
      ByVal estado_fac As Integer, _
      ByVal id_bodega As Integer, _
      ByVal id_cli As String, _
      ByVal ced_emple As String, _
      ByVal observaciones As String) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "modificar_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = registro
        objcomando.Parameters.Add("@fecha_ven_fac", SqlDbType.DateTime).Value = fecha_ven_fac
        objcomando.Parameters.Add("@tipo_fac", SqlDbType.Char, 2).Value = tipo_fac
        objcomando.Parameters.Add("@valor_fac", SqlDbType.Float).Value = valor_fac
        objcomando.Parameters.Add("@iva_fac", SqlDbType.Float).Value = iva_fac
        objcomando.Parameters.Add("@valor_total_fac", SqlDbType.Float).Value = valor_total_fac
        objcomando.Parameters.Add("@estado_fac", SqlDbType.Int).Value = estado_fac
        objcomando.Parameters.Add("@id_bodega", SqlDbType.Int).Value = id_bodega
        objcomando.Parameters.Add("@id_cli", SqlDbType.NVarChar, 20).Value = id_cli
        objcomando.Parameters.Add("@ced_emple", SqlDbType.VarChar, 30).Value = ced_emple
        objcomando.Parameters.Add("@observaciones", SqlDbType.VarChar, 200).Value = observaciones

        If conn.State = ConnectionState.Closed Then conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Function ObtenerSumatoriasValoresDetalleFactura(ByVal idfac As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "obtenerSumatoriasValoresDetalleFactura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@idfac", SqlDbType.Int).Value = idfac
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function verificarExisteFacturaDetalle(ByVal idfac As Integer, ByVal idpro As Integer) As Integer
        objcomando.Connection = conn
        objcomando.CommandText = "verificarExisteFacturaDetalle"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@idfac", SqlDbType.Int).Value = idfac
        objcomando.Parameters.Add("@idpro", SqlDbType.Int).Value = idpro
        conn.Open()
        Dim id As Integer = objcomando.ExecuteScalar()
        conn.Close()
        Return id
    End Function

    Public Function consultar_tipos_documentos() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_tipodocumentos"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function consultar_datos_factura(ByVal IdFactura As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_datos_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = IdFactura
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function consultar_facturas() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_facturas"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function busqueda_factura(ByVal cliente As Integer, ByVal estado As Integer, ByVal opcionbusqueda As Integer, ByVal palabra As String, ByVal tipo As String, ByVal fecha As String) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "busqueda_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@cliente", SqlDbType.Int).Value = cliente
        objcomando.Parameters.Add("@estado", SqlDbType.Int).Value = estado
        objcomando.Parameters.Add("@opcionbusqueda", SqlDbType.Int).Value = opcionbusqueda
        objcomando.Parameters.Add("@palabra", SqlDbType.VarChar, 50).Value = palabra
        objcomando.Parameters.Add("@tipo", SqlDbType.VarChar, 2).Value = tipo
        objcomando.Parameters.Add("@fecha", SqlDbType.VarChar, 10).Value = fecha
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function desactivar_factura(ByVal registro As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "desactivar_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@id", SqlDbType.Int).Value = registro
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function

    Public Function BorrarDocumentoDetalle(ByVal iddetalle As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "borrar_detalle_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@id", SqlDbType.Int).Value = iddetalle
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function

    Public Function cerrar_factura(ByVal registro As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "cerrar_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@id", SqlDbType.Int).Value = registro
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function

    Public Function consultar_detalle_factura(ByVal IdFactura As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_datos_factura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = IdFactura
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function consultar_productobyid(ByVal id_pro As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_productobyid"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@id", SqlDbType.Int).Value = id_pro
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function consultar_datos_reportefactura(ByVal IdFactura As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_datos_reportefactura"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = IdFactura
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function consultar_facturas_por_cliente(ByVal idcliente As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_facturas_por_cliente"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@idcliente", SqlDbType.Int).Value = idcliente

        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

End Class
