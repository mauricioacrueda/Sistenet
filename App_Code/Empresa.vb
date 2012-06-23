Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class Empresa
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_empresa(ByVal nit As String, ByVal nombre As String, ByVal direccion As String, ByVal telefono As String, ByVal email As String, ByVal departamento As String, ByVal ciudad As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_empresa"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nit", SqlDbType.NVarChar).Value = nit
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion
        objcomando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = telefono
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@departamento", SqlDbType.NVarChar).Value = Departamento
        objcomando.Parameters.Add("@ciudad", SqlDbType.NVarChar).Value = ciudad
        If conn.State = ConnectionState.Closed Then conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Function consultar_empresa() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_empresa"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function modificar_empresa(ByVal nit As String, ByVal nombre As String, ByVal direccion As String, ByVal telefono As String, ByVal email As String, ByVal ciudad As String, ByVal departamento As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_empresa"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion
        objcomando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = telefono
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@ciudad", SqlDbType.NVarChar).Value = ciudad
        objcomando.Parameters.Add("@departamento", SqlDbType.NVarChar).Value = departamento
        objcomando.Parameters.Add("@nit", SqlDbType.NVarChar).Value = nit
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function
    Public Sub eliminar_empresa(ByVal nit As String)
        Dim objcomando As New SqlCommand 'preguntar problema
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_empresa"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nit", SqlDbType.NVarChar).Value = nit
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

    End Sub
End Class
