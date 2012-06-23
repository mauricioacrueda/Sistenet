Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class autocompletar
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function ObtListaClientes(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim con As New conexion
        Dim objcomando As New SqlClient.SqlCommand
        Dim conn As New SqlConnection(con.conex)
        'Dim comando As New SqlCommand("select id,nombre,apellido from cliente where nombre  LIKE '%' + @param + '%' ", conn)
        'comando.Parameters.AddWithValue("@param", prefixText)
        objcomando.Connection = conn
        objcomando.CommandText = "buscar_auto_clientes"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = prefixText


        Dim dr As SqlDataReader
        objcomando.Connection.Open()
        dr = objcomando.ExecuteReader
        Dim lista As New List(Of String)
        While dr.Read
            lista.Add(dr.Item("id") + " " + dr.Item("nombre") + " " + dr.Item("apellido"))

        End While
        objcomando.Connection.Close()
        Return lista.ToArray
    End Function
    <WebMethod()> _
    Public Function ObtListaTecnicos(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim con As New conexion
        Dim objcomando As New SqlClient.SqlCommand
        Dim conn As New SqlConnection(con.conex)
        'Dim comando As New SqlCommand("select cedula,nombre,apellido from empleado where nombre  LIKE '%' + @param + '%' ", conn)
        'comando.Parameters.AddWithValue("@param", prefixText)
        objcomando.Connection = conn
        objcomando.CommandText = "buscar_auto_empleados"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = prefixText

        Dim dr As SqlDataReader
        objcomando.Connection.Open()
        dr = objcomando.ExecuteReader
        Dim lista As New List(Of String)
        While dr.Read
            lista.Add(dr.Item("cedula") + " " + dr.Item("nombre") + " " + dr.Item("apellido"))

        End While
        objcomando.Connection.Close()
        Return lista.ToArray
    End Function
    <WebMethod(EnableSession:=True)> _
     Public Function ObtListaProductos(ByVal prefixText As String, ByVal count As Integer) As String()
        'Try


        Dim con As New conexion
        Dim objcomando As New SqlClient.SqlCommand
        Dim conn As New SqlConnection(con.conex)
       
        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = prefixText

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_auto_productos"
        objcomando.CommandType = CommandType.StoredProcedure


        Dim dr As SqlDataReader
        objcomando.Connection.Open()
        dr = objcomando.ExecuteReader
        Dim lista As New List(Of String)
        While dr.Read
            lista.Add(dr.Item("nombre").ToString + " " + "--CODIGO: " + dr.Item("id").ToString)

        End While
        objcomando.Connection.Close()
        Return lista.ToArray
        'Catch ex As Exception

        'End Try

    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function ContadordeHits() As Integer

        If Session("idbodega") Is Nothing Then

            Session("idbodega") = 1

        Else

            Session("idbodega") = Integer.Parse(Session("idbodega")) + 1

        End If

        Return Integer.Parse(Session("idbodega"))

    End Function
    <WebMethod()> _
    Public Function ObtListaUsuarios(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim con As New conexion
        Dim objcomando As New SqlClient.SqlCommand
        Dim conn As New SqlConnection(con.conex)
        objcomando.Connection = conn
        objcomando.CommandText = "buscar_auto_usuario"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = prefixText

        Dim dr As SqlDataReader
        objcomando.Connection.Open()
        dr = objcomando.ExecuteReader
        Dim lista As New List(Of String)
        While dr.Read
            lista.Add(dr.Item("audusu"))

        End While
        objcomando.Connection.Close()
        Return lista.ToArray
    End Function
    <WebMethod()> _
    Public Function ObtListabodega(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim con As New conexion
        Dim objcomando As New SqlClient.SqlCommand
        Dim conn As New SqlConnection(con.conex)
        objcomando.Connection = conn
        objcomando.CommandText = "buscar_auto_bodega"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = prefixText

        Dim dr As SqlDataReader
        objcomando.Connection.Open()
        dr = objcomando.ExecuteReader
        Dim lista As New List(Of String)
        While dr.Read
            lista.Add(dr.Item("registro").ToString + " " + dr.Item("nombre").ToString)
            'lista.Add(dr.Item("nombre"))
        End While
        objcomando.Connection.Close()
        Return lista.ToArray
    End Function

End Class