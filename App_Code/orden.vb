Imports System
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class orden
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function crear_orden(ByVal fechaini As String, ByVal fechafin As String, ByVal falla As String, ByVal equipo As String, ByVal marca As String, ByVal modelo As String, ByVal serial As String, ByVal obs As String, ByVal emp As String, ByVal clie As String, ByVal estado As String, ByVal cod As Integer) As Integer

        If fechafin = "" Then
            fechafin = "0"
        End If


        objcomando.Connection = conn
        objcomando.CommandText = "insertar_orden"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@fecha_ini", SqlDbType.NVarChar).Value = fechaini
        objcomando.Parameters.Add("@fecha_fin", SqlDbType.NVarChar).Value = fechafin
        objcomando.Parameters.Add("@falla", SqlDbType.NVarChar).Value = falla
        objcomando.Parameters.Add("@equipo", SqlDbType.NVarChar).Value = equipo
        objcomando.Parameters.Add("@marca", SqlDbType.NVarChar).Value = marca
        objcomando.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = modelo
        objcomando.Parameters.Add("@serial", SqlDbType.NVarChar).Value = serial
        objcomando.Parameters.Add("@obs", SqlDbType.NVarChar).Value = obs
        objcomando.Parameters.Add("@ced_emp", SqlDbType.NVarChar).Value = emp
        objcomando.Parameters.Add("@id_cli", SqlDbType.NVarChar).Value = clie
        objcomando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado
        objcomando.Parameters.Add("@salidaid", SqlDbType.Int).Value = cod
        objcomando.Parameters("@salidaid").Direction = ParameterDirection.Output

        conn.Open()


        objcomando.ExecuteScalar()
        Dim a As Integer = objcomando.Parameters("@salidaid").Value


        Return a

    End Function

    Public Function buscar_orden(ByVal fecha1 As String, ByVal fecha2 As String, ByVal idemp As String, ByVal idcli As String, ByVal tipobusqueda As String) As DataSet

        If idemp = "" Then
            tipobusqueda = "1"
            idemp = "11"
        End If
        If idcli = "" Then
            tipobusqueda = "0"
            idcli = "11"
        End If

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_orden"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@f1", SqlDbType.NVarChar).Value = fecha1
        objcomando.Parameters.Add("@f2", SqlDbType.NVarChar).Value = fecha2
        objcomando.Parameters.Add("@emp", SqlDbType.NVarChar).Value = idemp
        objcomando.Parameters.Add("@idcli", SqlDbType.NVarChar).Value = idcli
        objcomando.Parameters.Add("@tipobusqueda", SqlDbType.NVarChar).Value = tipobusqueda


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds
    End Function

    Public Function recibir_idorden(ByVal idorden As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_orden_detalle"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = idorden
        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()

        Return ds
    End Function

    Public Function actualizar_orden(ByVal cod As String, ByVal fechaini As String, ByVal fechafin As String, ByVal falla As String, ByVal equipo As String, ByVal marca As String, ByVal modelo As String, ByVal serial As String, ByVal obs As String, ByVal estado As String) As Boolean

        fechaini = "04-01-2011" 'variable solo para que envie un parametro pero no actualiza nada


        objcomando.Connection = conn
        objcomando.CommandText = "modificar_orden"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@codorden", SqlDbType.NVarChar).Value = cod
        objcomando.Parameters.Add("@fecha_fin", SqlDbType.NVarChar).Value = fechafin
        objcomando.Parameters.Add("@falla", SqlDbType.NVarChar).Value = falla
        objcomando.Parameters.Add("@equipo", SqlDbType.NVarChar).Value = equipo
        objcomando.Parameters.Add("@marca", SqlDbType.NVarChar).Value = marca
        objcomando.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = modelo
        objcomando.Parameters.Add("@serial", SqlDbType.NVarChar).Value = serial
        objcomando.Parameters.Add("@obs", SqlDbType.NVarChar).Value = obs
        objcomando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado


        conn.Open()


        objcomando.ExecuteNonQuery()

        Return True

    End Function



End Class
