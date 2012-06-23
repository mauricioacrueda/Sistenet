Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class cotizacion
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_cotizacion(ByVal fechavenci As String, ByVal valtotal As String, ByVal idcli As String) As Integer
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_cotizacion"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@fechavenci", SqlDbType.NVarChar).Value = fechavenci
        objcomando.Parameters.Add("@valor", SqlDbType.Int).Value = Integer.Parse(valtotal)
        objcomando.Parameters.Add("@idcli", SqlDbType.NVarChar).Value = idcli

        conn.Open()
        Dim id As Integer = objcomando.ExecuteScalar()

        conn.Close()

        Return id

    End Function

    Public Function ingresar_cotiza_detalle(ByVal idcotiza As Integer, ByVal codproducto As Integer, ByVal cant As Integer) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "insertar_cotiza_detalle"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@idcoti", SqlDbType.Int).Value = idcotiza
        objcomando.Parameters.Add("@codpro", SqlDbType.Int).Value = codproducto
        objcomando.Parameters.Add("@cantidad", SqlDbType.Int).Value = cant

        conn.Open()
        objcomando.ExecuteNonQuery()

        conn.Close()

        Return True

    End Function

    Public Function buscar_cotizacion(ByVal idcli As String, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet

        If idcli Is Nothing Then
            idcli = 0
        End If


        objcomando.Connection = conn
        objcomando.CommandText = "buscar_cotizacion"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@idcli", SqlDbType.NVarChar).Value = idcli
        objcomando.Parameters.Add("@f1", SqlDbType.NVarChar).Value = fecha1
        objcomando.Parameters.Add("@f2", SqlDbType.NVarChar).Value = fecha2


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds

    End Function

    Public Function buscar_cotiza_detalle(ByVal idcotiza As Integer) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_cotiza_detalle"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.Int).Value = idcotiza

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds

    End Function

    Public Function eliminar_cotiza_detalle(ByVal idcotizadetalle As Integer) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_cotiza_detalle"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@idcotiza", SqlDbType.Int).Value = idcotizadetalle

        conn.Open()
        objcomando.ExecuteNonQuery()

        conn.Close()

        Return True

    End Function

    Public Function modificar_cotizacion(ByVal idcotiza As Integer, ByVal fechavencimi As String, ByVal valor As Integer, ByVal idcli As String) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "modificar_cotizacion"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@idcoti", SqlDbType.Int).Value = idcotiza
        objcomando.Parameters.Add("@fechavenci", SqlDbType.VarChar).Value = fechavencimi
        objcomando.Parameters.Add("@valor", SqlDbType.Int).Value = valor
        objcomando.Parameters.Add("@idcli", SqlDbType.VarChar).Value = idcli



        conn.Open()
        objcomando.ExecuteNonQuery()

        conn.Close()

        Return True

    End Function
    Public Function consultar_datos_reportecotizacion(ByVal Idcotizacion As Integer) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_datos_reporteOrdenCotizacion"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@registro", SqlDbType.Int).Value = Idcotizacion
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

End Class
