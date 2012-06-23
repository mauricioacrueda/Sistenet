Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class inicio_sesion_cls


    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Function consultar_usuario(ByVal login As String, ByVal password As String) As DataSet
        objcomando.Connection = conn
        objcomando.CommandText = "inicio_sesion"
        objcomando.CommandType = CommandType.StoredProcedure


        Dim objusuario As New usuario



        Dim parametro1 As New SqlParameter("@usuario", SqlDbType.NVarChar)
        Dim parametro2 As New SqlParameter("@password", SqlDbType.NVarChar)

        parametro1.Value = login
        parametro2.Value = objusuario.encriptar(password)


        objcomando.Parameters.Add(parametro1)
        objcomando.Parameters.Add(parametro2)




        If conn.State = ConnectionState.Closed Then conn.Open()


        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)

        ad.Fill(ds)

        Return ds




    End Function

End Class
