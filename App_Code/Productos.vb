Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Productos
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_producto(ByVal codigo As String, ByVal nombre As String, ByVal valor As String, ByVal descripcion As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_producto"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor
        objcomando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Function modificar_producto(ByVal id As String, ByVal codigo As String, ByVal nombre As String, ByVal valor As String, ByVal descripcion As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_producto"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id", SqlDbType.NVarChar).Value = id
        objcomando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@valor", SqlDbType.NVarChar).Value = valor
        objcomando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function
    Public Sub eliminar_producto(ByVal id As String)
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_producto"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id", SqlDbType.NVarChar).Value = id
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

    End Sub
    Public Function buscar_productos(ByVal id_p As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_producto"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_p

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function
    Public Function consultar_producto() As DataSet
        objcomando.Connection = conn
        objcomando.Parameters.Clear()
        objcomando.CommandText = "consultar_producto"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function consultar_existencias() As DataSet
        objcomando.Connection = conn
        objcomando.Parameters.Clear()
        objcomando.CommandText = "consultar_existencias"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function buscar_productos_cantidad(ByVal id_p As String, ByVal bodega As Integer) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "consultar_productos_cantidad"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_p
        objcomando.Parameters.Add("@bodega", SqlDbType.Int).Value = bodega

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()

        Return ds


    End Function
    Public Function consultar_producto_byidbodega(ByVal idbodega As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_producto_byidbodega"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id_bod", SqlDbType.Int).Value = idbodega
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function buscar_producto(ByVal id_p As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_producto"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_p

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function
End Class