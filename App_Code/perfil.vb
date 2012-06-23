Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text

Public Class perfil
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function consultar_pagina() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_pagina"
        objcomando.CommandType = CommandType.StoredProcedure

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)

        ad.Fill(ds)

        Return ds

    End Function

    Public Function consultar_permisos_de_perfil(ByVal idperfil As String) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_permiso_perfil"
        objcomando.CommandType = CommandType.StoredProcedure


        Dim objusuario As New usuario

        objcomando.Parameters.Add("@codper", SqlDbType.NVarChar).Value = idperfil


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)

        ad.Fill(ds)

        Return ds

    End Function
    Public Function ingresar_permiso_perfil(ByVal codmenu As String, ByVal idperfil As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_permiso_perfil"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@codperfil", SqlDbType.Int).Value = Integer.Parse(idperfil)
        objcomando.Parameters.Add("@codmenu", SqlDbType.Int).Value = Integer.Parse(codmenu)

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function

    Public Sub eliminar_permiso(ByVal codmenu As String, ByVal codpermiso As String, ByVal idperfil As String)
        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_permiso"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@codmenu", SqlDbType.Int).Value = Integer.Parse(codmenu)
        objcomando.Parameters.Add("@codpermiso", SqlDbType.Int).Value = Integer.Parse(codpermiso)
        objcomando.Parameters.Add("@codperfil", SqlDbType.Int).Value = Integer.Parse(idperfil)
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function consultar_perfiles() As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_perfiles"
        objcomando.CommandType = CommandType.StoredProcedure

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)

        ad.Fill(ds)

        Return ds

    End Function

    Public Function ingresar_perfil(ByVal nombre As String) As Integer
        objcomando.Connection = conn
        objcomando.CommandText = "insertar_perfil"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre
        objcomando.Parameters.Add("@salidaid", SqlDbType.NVarChar).Value = 1
        objcomando.Parameters("@salidaid").Direction = ParameterDirection.Output ''Parametro que retorna el id del nuevo perfil creado

        conn.Open()
        objcomando.ExecuteScalar()
        conn.Close()

        Dim a As Integer = objcomando.Parameters("@salidaid").Value


        Return a

    End Function


    Public Function modificar_perfil(ByVal codigo As Integer, ByVal nombre As String) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "modificar_perfil"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo
        objcomando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()


        Return True

    End Function

    Public Function eliminar_perfil(ByVal idperfil As Integer) As Boolean
        objcomando.Connection = conn
        objcomando.CommandText = "eliminar_perfil"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@codigo", SqlDbType.Int).Value = idperfil

        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()


        Return True
    End Function
End Class
