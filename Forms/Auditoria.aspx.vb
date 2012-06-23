Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Forms_Auditoria
    Inherits System.Web.UI.Page
    Dim id_a As New Auditoria
    Public Sub llenar()
        GvAuditoria.DataSource = id_a.consultar_auditoria.Tables(0)
        GvAuditoria.DataBind()
    End Sub
    Public Sub fichero(ByVal ex As String)

        Dim ruta As String = "d:\fichero.txt"
        Dim escritor As StreamWriter
        escritor = File.AppendText(ruta)
        escritor.Write("fecha:" & Date.Now.ToString() & "-" & ex & "")
        escritor.Flush()
        escritor.Close()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Script", "<script language='javascript'>alert('Ocurrio el siguiente error : " & ex & " , comuniquese con el administrador del sistema');</script>", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenar()
    End Sub
    Protected Sub txtbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        'Busca Bodega en el evento clic

        Label1.Visible = False

        Try

            If Len(Trim(txtbus.Text)) = 0 Then

                Label1.Text = "No Existe Criterio para Buscar"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub

            End If

            Label1.Visible = False
            Dim objbus As New Auditoria

            GvAuditoria.DataSource = objbus.buscar_auditoria(txtbus.Text).Tables(0)
            GvAuditoria.DataBind()

        Catch ex As Exception

            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Blue

        End Try
    End Sub

    Protected Sub txtbus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbus.TextChanged
        'Busca clientes en el evento TextChanged
        Try

            If Len(Trim(txtbus.Text)) = 0 Then

                Label1.Text = "No Existe Criterio para Buscar"
                Label1.ForeColor = Drawing.Color.Red
                Label1.Visible = True

                Exit Sub

            End If


            btnbuscar.Focus()
            Label1.Visible = False
            Dim objbus As New Auditoria

            GvAuditoria.DataSource = objbus.buscar_auditoria(txtbus.Text).Tables(0)
            GvAuditoria.DataBind()

        Catch ex As Exception

            Label1.Visible = True
            Label1.Text = ex.Message
            Label1.ForeColor = Drawing.Color.Blue

        End Try
    End Sub
End Class
