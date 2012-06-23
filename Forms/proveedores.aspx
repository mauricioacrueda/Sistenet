<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="proveedores.aspx.vb" Inherits="Forms_proveedores" title="Proveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
        .style5
        {
            width: 274px;
        }
        .style6
        {
        }
        .style7
        {
            width: 274px;
            height: 12px;
        }
        .style8
        {
            width: 191px;
            height: 12px;
        }
        .style9
        {
            height: 12px;
        }
        .style10
        {
            width: 191px;
        }
        .style22
        {
            font-size: x-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style4">
        <tr>
            <td class="style5">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td class="style6" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <b>Registro de&nbsp;Proveedores</b></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                Nit/Cedula:<span class="style22">(*)</span></td>
            <td>
                <asp:TextBox ID="txtced" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
            </td>
            <td class="style8">
                Nombre/Razon Social:<span class="style22">(*)</span></td>
            <td class="style9">
                <asp:TextBox ID="txtnom" runat="server" Width="359px" MaxLength="100"></asp:TextBox>
            </td>
            <td class="style9">
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                Departamento:<span class="style22">(*)</span></td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cbdepar" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
            </td>
            <td class="style10">
                Ciudad:<span class="style22">(*)</span></td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cbciu" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                Direccion:<span class="style22">(*)</span></td>
            <td>
                <asp:TextBox ID="txtdir" runat="server" Width="180px" MaxLength="100"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                Telefono</td>
            <td>
                <asp:TextBox ID="txttel" runat="server" MaxLength="100"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                Email</td>
            <td>
                <asp:TextBox ID="txtema" runat="server" Width="180px" MaxLength="100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtema" ErrorMessage="Direccion Invalida" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                Estado:<span class="style22">(*)</span></td>
            <td>
                <asp:DropDownList ID="cbestado" runat="server">
                    <asp:ListItem Value="True">Activo</asp:ListItem>
                    <asp:ListItem Value="False">Inactivo</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="btnnuevo" runat="server" Height="43px" 
                    ImageUrl="~/imagenes/nuevo.png" Width="46px" />
                <asp:ImageButton ID="btnguardar" runat="server" Height="43px" 
                    ImageUrl="~/imagenes/guardar.png" Width="46px" />
                                                            <asp:ImageButton ID="btncancelar" runat="server" 
                                                                ImageUrl="~/imagenes/Cancel.png" onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');"/>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

