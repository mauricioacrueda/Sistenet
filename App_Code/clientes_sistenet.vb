Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clientes_sistenet
    'Private id_cliente As String
    'Private nombre As String
    'Private apellido As String
    'Private direccion As String
    'Private telefono As String
    'Private email As String
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlClient.SqlCommand


    Public Function ingresar_cliente(ByVal idcli As String, ByVal nomclie As String, ByVal apeclie As String, ByVal dirclie As String, ByVal telclie As String, ByVal emaclie As String, ByVal idciu As String, ByVal idtipoclie As String, ByVal estado As String) As Boolean



        objcomando.Connection = conn
        objcomando.CommandText = "insertar_cliente"
        objcomando.Parameters.Clear()
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@idclie", SqlDbType.NVarChar).Value = idcli
        objcomando.Parameters.Add("@nom", SqlDbType.NVarChar).Value = nomclie
        objcomando.Parameters.Add("@ape", SqlDbType.NVarChar).Value = apeclie
        objcomando.Parameters.Add("@dir", SqlDbType.NVarChar).Value = dirclie
        objcomando.Parameters.Add("@tel", SqlDbType.NVarChar).Value = telclie
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = emaclie
        objcomando.Parameters.Add("@idciu", SqlDbType.NVarChar).Value = idciu
        objcomando.Parameters.Add("@idtipoclie", SqlDbType.NVarChar).Value = idtipoclie
        objcomando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado


        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True


    End Function

    Public Function modificar_cliente(ByVal idcli As String, ByVal nom As String, ByVal ape As String, ByVal dir As String, ByVal tel As String, ByVal ema As String, ByVal ciu As String, ByVal tipocli As String, ByVal estado As String) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "modificar_cliente"
        objcomando.Parameters.Clear()
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@id", SqlDbType.NVarChar).Value = idcli
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nom
        objcomando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = ape
        objcomando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = dir
        objcomando.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = tel
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = ema
        objcomando.Parameters.Add("@id_ciu", SqlDbType.NVarChar).Value = ciu
        objcomando.Parameters.Add("@id_tipo_cli", SqlDbType.NVarChar).Value = tipocli
        objcomando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado


        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()


    End Function


    Public Function eliminar_cliente(ByVal idcliente As String) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_cliente"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@idcli", SqlDbType.NVarChar).Value = idcliente

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()


        Return True
    End Function


    Public Function consultar_clientes() As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "consultar_clientes"
        objcomando.CommandType = CommandType.StoredProcedure


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)

        conn.Close()

        Return ds


    End Function

    Public Function buscar_cliente(ByVal idcli As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_cliente"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = idcli

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function

    Public Function consultar_datos_clientes(ByVal idcliente As Integer) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "consultar_datos_clientes"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@idcliente", SqlDbType.NVarChar).Value = idcliente

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)

        conn.Close()

        Return ds

    End Function



End Class
