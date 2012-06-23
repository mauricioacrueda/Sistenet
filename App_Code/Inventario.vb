Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Inventario

    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_inventario(ByVal IdBodega As String, ByVal cantidadProductos As Integer, ByVal observaciones As String) As Integer
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_inventario"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@cantidad", SqlDbType.Float).Value = cantidadProductos
        objcomando.Parameters.Add("@bodega", SqlDbType.NVarChar).Value = IdBodega
        objcomando.Parameters.Add("@observaciones", SqlDbType.NVarChar).Value = observaciones
        conn.Open()
        Dim id As Integer = objcomando.ExecuteScalar()
        conn.Close()
        Return id
    End Function

    Public Function ingresar_inventario_detalle(ByVal IdInventario As Integer, ByVal IdProducto As Integer, ByVal cantidad As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_inventario_detalle"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro_inv", SqlDbType.Int).Value = IdInventario
        objcomando.Parameters.Add("@id_producto", SqlDbType.Int).Value = IdProducto
        objcomando.Parameters.Add("@cantidad", SqlDbType.Float).Value = cantidad
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True
    End Function

    Public Function consultar_inventarios() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_inventarios"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Sub eliminar_inventario(ByVal registro As Integer)
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_inventario"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = registro
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function actualizar_inventario_bodega(ByVal idinventario As Integer, ByVal idbodega As Integer, ByVal IdProducto As Integer, ByVal cantidad As Integer, ByVal accion As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "actualizar_inventario_bodega"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@accion", SqlDbType.Int).Value = accion '1-sumar 0- restar
        objcomando.Parameters.Add("@idinventario", SqlDbType.Int).Value = idinventario
        objcomando.Parameters.Add("@id_bodega", SqlDbType.Int).Value = idbodega
        objcomando.Parameters.Add("@id_producto", SqlDbType.Int).Value = IdProducto
        objcomando.Parameters.Add("@cantidad", SqlDbType.Float).Value = cantidad
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True
    End Function
    Public Function consultar_datos_reporteinventario(ByVal IdInventario As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_datos_reporteinventario"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = IdInventario
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function buscar_inventario_fecha(ByVal fecha1 As String, ByVal fecha2 As String, ByVal bodega As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_inventario_fecha"
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
    Public Function buscar_inventario_bodega(ByVal bodega As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_inventario_bodega"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@bodega", SqlDbType.NVarChar).Value = bodega


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds
    End Function
    Public Function buscar_existencias_bodega(ByVal bodega As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_existencias_bodega"
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
