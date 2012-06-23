<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cerrar_sesion.aspx.vb" Inherits="cerrar_sesion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%  Session.RemoveAll()
    Session.Abandon()
    My.Response.Write("<script language='javascript'>alert('Se guardaron correctamente los datos');</script>")

    My.Response.Write("<html><script> location='../default.aspx'; </script>")
%>