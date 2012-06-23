<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="cambiar_clave.aspx.vb" Inherits="Forms_cambiar_clave" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style4
    {
        width: 99%;
        border-left-style: solid;
        border-left-width: 1px;
        border-right: 1px solid #C0C0C0;
        border-top-style: solid;
        border-top-width: 1px;
        border-bottom: 1px solid #C0C0C0;
    }
    .style5
    {
        text-align: center;
    }
    .style6
    {
        font-weight: bold;
        text-align: center;
    }
    .style7
    {
        text-align: right;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style4">
    <tr>
        <td class="style6" colspan="2">
            Cambiar Clave de Acceso</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            Clave Anterior:</td>
        <td>
            <asp:TextBox ID="txtpass" runat="server" TextMode="Password" Width="140px" 
                MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            Nueva Clave:</td>
        <td>
            <asp:TextBox ID="txtpassnue" runat="server" TextMode="Password" Width="140px" 
                MaxLength="50" ToolTip="Recuerde que deben ser iguales las Claves"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            Confirma Nueva Clave:</td>
        <td>
            <asp:TextBox ID="txtconfirpass" runat="server" TextMode="Password" 
                Width="140px" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style5" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td>
            <asp:ImageButton ID="btnguardar" runat="server" Height="43px" 
                ImageUrl="~/imagenes/guardar.png" Width="46px" 
                ToolTip="Guardar los Valores" />
                                                            <asp:ImageButton ID="btncancelar" runat="server" 
                                                                ImageUrl="~/imagenes/Cancel.png" onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');"/>
        </td>
    </tr>
</table>
</asp:Content>

