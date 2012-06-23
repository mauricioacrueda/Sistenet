Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Baja
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_baja(ByVal bodega As String, ByVal cant As Integer, ByVal observacion As String) As Integer
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_baja"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@bodega", SqlDbType.NVarChar).Value = bodega
        objcomando.Parameters.Add("@cantidad", SqlDbType.NVarChar).Value = cant
        objcomando.Parameters.Add("@observacion", SqlDbType.NVarChar).Value = observacion
        conn.Open()
        Dim id As Integer = objcomando.ExecuteScalar()
        'objcomando.ExecuteNonQuery()
        conn.Close()

        Return id

    End Function

    Public Function consultar_baja() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_baja"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function modificar_baja(ByVal registro As String, ByVal observacion_emp As String, ByVal codigo_emp As String, ByVal registro_inven_emp As String, ByVal email_emp As String, ByVal ciudad_emp As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_baja"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@observacion", SqlDbType.NVarChar).Value = observacion_emp
        objcomando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo_emp
        objcomando.Parameters.Add("@registro_inven", SqlDbType.NVarChar).Value = registro_inven_emp
        objcomando.Parameters.Add("@registro", SqlDbType.NVarChar).Value = registro
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function
    Public Sub eliminar_baja(ByVal registro As String)
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_baja"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@registro", SqlDbType.NVarChar).Value = registro
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

    End Sub
    Public Function consultar_producto() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_producto"
        objcomando.CommandType = CommandType.StoredProcedure
        'objcomando.Parameters.Add("@nit", SqlDbType.NVarChar).Value = nit_emp
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function ingresar_baja_detalle(ByVal registro_b As String, ByVal producto_b As Integer, ByVal cantidad As Integer) As Boolean
        'Try
        '    objcomando.Connection = conn
        '    objcomando.CommandText = "insertar_baja_detalle"
        '    objcomando.CommandType = CommandType.StoredProcedure
        '    objcomando.Parameters.Add("@registro_b", SqlDbType.NVarChar).Value = registro_b
        '    objcomando.Parameters.Add("@id_producto", SqlDbType.NVarChar).Value = producto_b
        '    objcomando.Parameters.Add("@cantidad", SqlDbType.NVarChar).Value = cantidad
        '    conn.Open()
        '    Dim id As Integer = objcomando.ExecuteScalar()
        '    objcomando.ExecuteNonQuery()
        '    conn.Close()
        '    Return True

        'Catch ex As Exception

        'End Try
        objcomando.Connection = conn
        objcomando.Parameters.Clear()
        objcomando.CommandText = "insertar_baja_detalle"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@registro_b", SqlDbType.NVarChar).Value = registro_b
        objcomando.Parameters.Add("@id_producto", SqlDbType.NVarChar).Value = producto_b
        objcomando.Parameters.Add("@cantidad", SqlDbType.NVarChar).Value = cantidad
        conn.Open()
        ' Dim id As Integer = objcomando.ExecuteScalar()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True
        'Return id
    End Function
    Public Function actualizar_baja_bodega(ByVal idinventario As Integer, ByVal idbodega As Integer, ByVal IdProducto As Integer, ByVal cantidad As Integer, ByVal accion As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "actualizar_inventario_bodega"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@accion", SqlDbType.Int).Value = accion '1-sumar 0- restar
        objcomando.Parameters.Add("@idinventario", SqlDbType.Int).Value = idinventario
        objcomando.Parameters.Add("@id_bodega", SqlDbType.Int).Value = idbodega
        objcomando.Parameters.Add("@id_producto", SqlDbType.Int).Value = IdProducto
        objcomando.Parameters.Add("@cantidad", SqlDbType.Float).Value = -cantidad
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True
    End Function
    Public Function buscar_baja(ByVal id_b As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_baja"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_b

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function
    Public Function consultar_datos_reportebaja(ByVal IdBaja As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_datos_reportebaja"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = IdBaja
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function buscar_baja_fecha(ByVal fecha1 As String, ByVal fecha2 As String, ByVal bodega As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_baja_fecha"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@f1", SqlDbType.NVarChar).Value = fecha1
        objcomando.Parameters.Add("@f2", SqlDbType.NVarChar).Value = fecha2
        objcomando.Parameters.Add("@bodega", SqlDbType.NVarChar).Value = bodega


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds
    End Function
    Public Function buscar_baja_bodega(ByVal bodega As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_baja_bodega"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@bodega", SqlDbType.NVarChar).Value = bodega


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds
    End Function
End Class
