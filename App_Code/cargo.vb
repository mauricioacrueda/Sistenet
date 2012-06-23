Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class cargo
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_cargo(ByVal nombre As String, ByVal tipo As String) As Boolean


        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_cargo"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True
    End Function

    Public Function consultar_cargo() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_cargo"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function modificar_cargo(ByVal id As String, ByVal nombre As String, ByVal tipo As String) As Boolean
        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_cargo"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo
        objcomando.Parameters.Add("@id", SqlDbType.NVarChar).Value = id

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function
    Public Function eliminar_cargo(ByVal codigo As String) As Boolean
        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_cargo"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = codigo
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True
    End Function
    Public Function buscar_cargo(ByVal id_ca As String) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "buscar_cargo"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_ca
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()
        Return ds

    End Function
End Class
