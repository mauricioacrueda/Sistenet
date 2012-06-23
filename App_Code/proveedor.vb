Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class proveedor
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_proveedor(ByVal nit As String, ByVal nombre As String, ByVal direccion As String, ByVal telefono As String, ByVal email As String, ByVal ciu As String, ByVal estado As Boolean) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_proveedor"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@idprove", SqlDbType.NVarChar).Value = nit
        objcomando.Parameters.Add("@nomprove", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@dirprove", SqlDbType.NVarChar).Value = direccion
        objcomando.Parameters.Add("@telprove", SqlDbType.NVarChar).Value = telefono
        objcomando.Parameters.Add("@emailprove", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@idciu", SqlDbType.NVarChar).Value = ciu
        objcomando.Parameters.Add("@estadoprove", SqlDbType.NVarChar).Value = estado

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Function consultar_proveedor() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_proveedor"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function modificar_proveedor(ByVal nit As String, ByVal nombre As String, ByVal direccion As String, ByVal telefono As String, ByVal email As String, ByVal ciu As String, ByVal estado As Boolean) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_proveedor"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@idprove", SqlDbType.NVarChar).Value = nit
        objcomando.Parameters.Add("@nomprove", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@dirprove", SqlDbType.NVarChar).Value = direccion
        objcomando.Parameters.Add("@telprove", SqlDbType.NVarChar).Value = telefono
        objcomando.Parameters.Add("@emailprove", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@idciu", SqlDbType.NVarChar).Value = ciu
        objcomando.Parameters.Add("@estadoprove", SqlDbType.NVarChar).Value = estado

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function
    Public Sub eliminar_proveedor(ByVal nit_emp As String)
        Dim objcomando As New SqlCommand 'preguntar problema
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_proveedor"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@idprovee", SqlDbType.NVarChar).Value = nit_emp
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

    End Sub
    Public Function buscar_provee(ByVal idpro As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_proveedor"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = idpro

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function
End Class
