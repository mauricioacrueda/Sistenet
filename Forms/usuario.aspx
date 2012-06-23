<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="usuario.aspx.vb" Inherits="Forms_usuario" title="Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style4
    {
        width: 100%;
    }
        .style5
        {
            width: 257px;
        }
        .style6
        {
    }
        .style8
        {
            text-align: center;
        }
        .style9
        {
            width: 257px;
            text-align: center;
        }
        .style10
        {
            width: 173px;
        }
        .style11
        {
            width: 257px;
            height: 21px;
        }
        .style12
        {
            height: 21px;
            text-align: center;
        }
        .style14
        {
            height: 21px;
        }
        .style15
    {
        width: 257px;
        height: 33px;
    }
    .style16
    {
        width: 141px;
        height: 33px;
    }
    .style18
    {
        height: 33px;
    }
        .style19
        {
            width: 173px;
            height: 33px;
        }
        .style20
        {
            width: 141px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style4">
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style8" colspan="2">
            <b style="text-align: center">Creacion de Usuario</b></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Usuario:</td>
        <td class="style16">
            <asp:TextBox ID="txtusu" runat="server" Width="157px" MaxLength="50"></asp:TextBox>
        </td>
        <td class="style19">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Estado:</td>
        <td class="style18">
            <asp:DropDownList ID="cbestado" runat="server" Height="22px" Width="178px">
                <asp:ListItem Value="99">Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Activo</asp:ListItem>
                <asp:ListItem Value="0">Inactivo</asp:ListItem>
            </asp:DropDownList>
                                </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Nombres:</td>
        <td class="style20">
            <asp:TextBox ID="txtnom" runat="server" Width="157px" MaxLength="50"></asp:TextBox>
        </td>
        <td class="style10">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Apellidos:</td>
        <td>
            <asp:TextBox ID="txtape" runat="server" Width="157px" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E-Mail:</td>
        <td class="style20">
            <asp:TextBox ID="txtema" runat="server" Width="157px" MaxLength="50"></asp:TextBox>
        </td>
        <td class="style10">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Perfil:</td>
        <td>
            <asp:DropDownList ID="cbperfil" runat="server" Width="178px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Contraseña:</td>
        <td class="style20">
            <asp:TextBox ID="txtpass" runat="server" Width="157px" TextMode="Password" 
                MaxLength="50"></asp:TextBox>
        </td>
        <td class="style10">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Confirmar Contraseña:</td>
        <td>
            <asp:TextBox ID="txtconfirpass" runat="server" Width="157px" 
                TextMode="Password" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td class="style12" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
        <td class="style14">
            </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style6" colspan="2">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtema" ErrorMessage="Direccion Invalida" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td class="style8" colspan="2">
            <asp:ImageButton ID="btnnuevo" runat="server" Height="43px" 
                ImageUrl="~/imagenes/nuevo.png" style="margin-top: 0px" Width="46px" 
                ToolTip="Habilitar Campos." />
            <asp:ImageButton ID="btnguardar" runat="server" Height="43px" 
                ImageUrl="~/imagenes/guardar.png" Width="46px" 
                style="text-align: center" ToolTip="Guardar Valores" />
                                                            <asp:ImageButton ID="btncancelar" runat="server" 
                                                                ImageUrl="~/imagenes/Cancel.png" onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');"/>
        </td>
        <td class="style8">
            &nbsp;</td>
    </tr>
</table>
            <br />
</asp:Content>

