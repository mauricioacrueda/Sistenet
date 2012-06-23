Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Text

Public Class usuario
    'Inherits System.Web.UI.Page
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function ingresar_usuarios(ByVal usuario As String, ByVal password As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String, ByVal codigo_perfil As String, ByVal estado As Boolean) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_usuario"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@login", SqlDbType.NVarChar).Value = usuario
        objcomando.Parameters.Add("@password", SqlDbType.NVarChar).Value = encriptar(password)
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@codigo_perfil", SqlDbType.NVarChar).Value = codigo_perfil
        objcomando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Function consultar_usuarios() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_usuario"
        objcomando.CommandType = CommandType.StoredProcedure

        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

    Public Function modificar_usuario(ByVal usuario As String, ByVal password As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String, ByVal codigo_perfil As String, ByVal estado As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_usuario"
        objcomando.CommandType = CommandType.StoredProcedure

        If password = "" Then

            password = "parametrovacio"

        End If

        objcomando.Parameters.Add("@login", SqlDbType.NVarChar).Value = usuario
        objcomando.Parameters.Add("@password", SqlDbType.NVarChar).Value = encriptar(password)
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido
        objcomando.Parameters.Add("@email", SqlDbType.NVarChar).Value = email
        objcomando.Parameters.Add("@codigo_perfil", SqlDbType.NVarChar).Value = codigo_perfil
        objcomando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
        Return True

    End Function
    Public Sub inactivar_usuario(ByVal login As String, ByVal estado As String)
        objcomando.Connection = conn
        objcomando.CommandText = "inactivar_usuario"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@login", SqlDbType.NVarChar).Value = login
        objcomando.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

    End Sub

    Public Function encriptar(ByVal texto As String) As String
        'Crear un objeto de codificación para garantizar el estándar de codificación para el texto fuente
        Dim Ue As New UnicodeEncoding()
        'Recupera una matriz de bytes basado en el texto de origen
        Dim ByteSourceText() As Byte = Ue.GetBytes(texto)
        
        Dim Md5 As New MD5CryptoServiceProvider()
    
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)

        Return Convert.ToBase64String(ByteHash)
    End Function

    Public Function cambiar_clave(ByVal clavevieja As String, ByVal idusu As String, ByVal password As String) As Boolean

        objcomando.Connection = conn
        objcomando.CommandText = "cambiar_clave"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Clear()
        objcomando.Parameters.Add("@clavevieja", SqlDbType.NVarChar).Value = encriptar(clavevieja)
        objcomando.Parameters.Add("@login", SqlDbType.NVarChar).Value = idusu
        objcomando.Parameters.Add("@clavenueva", SqlDbType.NVarChar).Value = encriptar(password)

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Function buscar_usuario(ByVal idusu As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_usuario"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = idusu

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()

        Return ds

    End Function

    Public Function consultar_permisos(ByVal usuario As String, ByVal perfil As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_permiso"
        objcomando.CommandType = CommandType.StoredProcedure


        Dim objusuario As New usuario

        objcomando.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = usuario
        objcomando.Parameters.Add("@perfil", SqlDbType.NVarChar).Value = perfil


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)

        ad.Fill(ds)

        If ds.Tables(0).Rows.Count = 0 Then
            ' Response.Redirect("~/Forms/error_permiso.aspx")
            System.Web.HttpContext.Current.Response.Redirect("~/default.aspx")

        End If

        Return True

    End Function

    Public Function consultar_menu() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "ObtenerOpcionesMenu"
        objcomando.CommandType = CommandType.StoredProcedure

        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function

End Class
