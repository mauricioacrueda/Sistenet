Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Partial Class Forms_backup
    Inherits System.Web.UI.Page

    Dim con As New conexion
    Dim conn As New SqlConnection(con.conex)
    Dim objcomando As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pagina As String = "Backup"
        Dim objpermi As New usuario
        'objpermi.consultar_permisos(Session("login").ToString, Session("perfil").ToString)
        If IsPostBack = False Then
            'realizar al auditoria
            Dim objadi As New Auditoria
            Dim ds As New DataSet
            objadi.registro_auditoria(pagina, Session("login").ToString)

        End If
        crear_backup()
        

    End Sub

    Public Function crear_backup() As Boolean

        'poner un randomico
        Dim nombre As String = "D:\Dropbox\compartida\sistenet\Backup\sistenet.bak"

        Try
            objcomando.Connection = conn
            objcomando.CommandText = "crear_backup"
            objcomando.CommandType = CommandType.StoredProcedure
            objcomando.Parameters.Clear()
            objcomando.Parameters.Add("@ruta", SqlDbType.VarChar).Value = nombre
            If conn.State = ConnectionState.Closed Then conn.Open()
            objcomando.ExecuteNonQuery()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Se realizo satisfactoriamente el backup');</script>", False)
            Return True
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('No se pudo realizar el backup, Recuerde tener una carpeta  en al ubicación C:\copias');</script>", False)
            Return False
        End Try


    End Function

End Class
