Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class ciudades
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand
	Public Function ingresar_ciudad(ByVal id As String, ByVal nombre As String, ByVal cod_depar As String) As Boolean

        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_ciudad"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id", SqlDbType.NVarChar).Value = id
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@cod_depar", SqlDbType.NVarChar).Value = cod_depar
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function
    Public Function consultar_ciudades() As DataSet
        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_ciudad"
        objcomando.CommandType = CommandType.StoredProcedure
        'objcomando.Parameters.Add("@nit", SqlDbType.NVarChar).Value = nit_ciudad
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function modificar_ciudad(ByVal id As String, ByVal nombre As String, ByVal cod_depar As String) As Boolean

        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_ciudad"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@cod_depar", SqlDbType.NVarChar).Value = cod_depar
        objcomando.Parameters.Add("@id", SqlDbType.NVarChar).Value = id

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function
    Public Sub eliminar_ciudad(ByVal id As String)
        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_ciudad"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id", SqlDbType.NVarChar).Value = id
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function consultar_ciudad() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_ciudad"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function buscar_ciudad(ByVal id_c As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_ciudad"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_c

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function

    Public Function consultar_ciu_por_depar(ByVal id_departamento As String) As DataSet


        objcomando.Connection = conn

        objcomando.CommandText = "consultar_ciudades_por_departamento"
        objcomando.Parameters.Add("@cod_dep", SqlDbType.NVarChar).Value = id_departamento
        objcomando.CommandType = CommandType.StoredProcedure

        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
End Class
