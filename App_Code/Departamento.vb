Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Departamento
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_departamento(ByVal id_d As String, ByVal nombre As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_departamento"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id_d", SqlDbType.NVarChar).Value = id_d
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        If conn.State = ConnectionState.Closed Then conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True
    End Function

    Public Function consultar_departamento() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_departamento"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function modificar_departamento(ByVal id_d As String, ByVal nombre As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_departamento"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@id_d", SqlDbType.NVarChar).Value = id_d
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function
    Public Sub eliminar_departamento(ByVal id_d As String)
        Dim objcomando As New SqlCommand 'preguntar problema
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_departamento"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id_d", SqlDbType.NVarChar).Value = id_d
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
    End Sub
    Public Function buscar_departamento(ByVal id_d As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_departamento"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_d

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function
End Class
