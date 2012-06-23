Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Text
Imports System.Text.RegularExpressions.Regex
Imports System.IO

Public Class Auditoria
    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Public Sub fichero(ByVal ex As String)

        Dim ruta As String = "d:\fichero.txt"
        Dim escritor As StreamWriter
        escritor = File.AppendText(ruta)
        escritor.Write(vbCrLf & "fecha:" & Date.Now.ToString() & "-" & ex & vbCrLf & "")
        escritor.Flush()
        escritor.Close()
          End Sub


    Public Function registro_auditoria(ByVal pagina As String, ByVal usuario As String) As Boolean

        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "registro_auditoria"
        objcomando.CommandType = CommandType.StoredProcedure
        objcomando.Parameters.Add("@pagina", SqlDbType.NVarChar).Value = pagina
        objcomando.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = usuario
        conn.Open()
        objcomando.ExecuteNonQuery()
        conn.Close()

        Return True

    End Function
    Public Function consultar_auditoria() As DataSet


        Dim objcomando As New SqlCommand
        objcomando.Connection = conn
        objcomando.CommandText = "consultar_auditoria"
        objcomando.CommandType = CommandType.StoredProcedure
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim ds As New DataSet
        Dim ad As New SqlDataAdapter(objcomando)
        ad.Fill(ds)
        conn.Close()
        Return ds
    End Function
    Public Function buscar_auditoria(ByVal id_b As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_auditoria"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@busqueda", SqlDbType.NVarChar).Value = id_b

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds


    End Function
    Public Function buscar_usuario(ByVal fecha1 As String, ByVal fecha2 As String, ByVal idusu As String) As DataSet

        objcomando.Connection = conn
        objcomando.CommandText = "buscar_auditoria_usuario"
        objcomando.CommandType = CommandType.StoredProcedure

        objcomando.Parameters.Add("@f1", SqlDbType.NVarChar).Value = fecha1
        objcomando.Parameters.Add("@f2", SqlDbType.NVarChar).Value = fecha2
        objcomando.Parameters.Add("@idusu", SqlDbType.NVarChar).Value = idusu


        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim ad As New SqlDataAdapter(objcomando)
        Dim ds As New DataSet
        ad.Fill(ds)
        conn.Close()



        Return ds
    End Function


    Public Function quitarcaracteres(ByVal texto As String) As String


        'Quita Caracteres Especiales
        Dim reg As RegularExpressions.Regex
        Dim textoOriginal As String = texto
        'transformación UNICODE
        Dim textoNormalizado As String = textoOriginal.Normalize(NormalizationForm.FormD)
        'coincide todo lo que no sean letras y números ascii o espacio
        'y lo reemplazamos por una cadena vacía.
        reg = New RegularExpressions.Regex("[^a-zA-Z0-9 ]")
        Dim textoSinAcentos As String = reg.Replace(textoNormalizado, "")
        'Debug.WriteLine(textoSinAcentos)
        texto = textoSinAcentos

        Return texto

    End Function
End Class
