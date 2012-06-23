Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class empleados
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand
    Public Function ingresar_empleado(ByVal cedula As String, ByVal nombre As String, ByVal apellido As String, ByVal direccion As String, ByVal telefono As String, ByVal email As String, ByVal cargo As String) As Boolean

        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_empleado"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido
        objcomando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion
        objcomando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = telefono
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@cargo", SqlDbType.NVarChar).Value = cargo

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function
    Public Function consultar_empleado() As DataSet


        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_empleado"
        objcomando.CommandType = CommandType.StoredProcedure

        'objcomando.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula

        If conn.State = ConnectionState.Closed Then conn.Open()


        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function modificar_empleado(ByVal id As String, ByVal cedula As String, ByVal nombre As String, ByVal apellido As String, ByVal direccion As String, ByVal telefono As String, ByVal email As String, ByVal id_cargo As String) As Boolean

        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_empleado"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@id", SqlDbType.Int).Value = id
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido
        objcomando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion
        objcomando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = telefono
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@cargo", SqlDbType.NVarChar).Value = id_cargo
        objcomando.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function
    Public Sub eliminar_empleado(ByVal cedula As String)
        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_empleado"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()


    End Sub
    Public Function buscar_empleado(ByVal id_c As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_empleado"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_c

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


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
End Class
