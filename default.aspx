<%@ Page Language="VB" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="inicio_prueba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistemas y Tecnologias.NET</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        #form1
        {
            height: 188px;
            width: 921px;
        }
        .style2
        {
            width: 289px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div style="font-weight: 700" align="center">
    
    </div>
    
    <%
        
        
        
        %>
    
    
    <table align="center" class="style1">
        <tr>
            <td align="center" class="style2">
                &nbsp;</td>
            <td align="center">
                <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
                    BorderPadding="4" BorderStyle="Double" BorderWidth="1px" Font-Names="Verdana" 
                    Font-Size="Medium" ForeColor="#333333" Height="284px" Width="486px" 
                    RememberMeText="" DisplayRememberMe="False" 
                    TitleText="Iniciar sesión SISTENET" CreateUserText="Regresar al Portal" 
                    CreateUserUrl="http://www.sistenet.comze.com" 
                    FailureText="Los datos de validacion  no fueron correctos.">
                    <TextBoxStyle Font-Size="0.8em" />
                    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                        ForeColor="White" />
                </asp:Login>
            </td>
            <td align="center">
                &nbsp;</td>
        </tr>
    </table>
    
    
    </form>
    
</body>
</html>
