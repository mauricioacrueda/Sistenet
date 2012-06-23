<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="mto_proveedores.aspx.vb" Inherits="Forms_mto_proveedores" title="Actualiza Proveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
    {
        width: 99%;
    }
        .style5
        {
            height: 21px;
        }
        .style6
        {
            height: 21px;
            width: 160px;
        }
        .style7
        {
        }
        .style8
        {
            height: 21px;
            width: 168px;
        }
        .style9
        {
            width: 168px;
        }
        .style10
        {
            height: 21px;
            width: 241px;
        }
        .style11
        {
            width: 241px;
        }
        .style12
        {
            height: 21px;
            width: 94px;
        }
        .style13
        {
            width: 94px;
        }
        .style14
        {
            width: 160px;
        }
        .style15
        {
            width: 241px;
            text-align: center;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style4">
    <tr>
        <td class="style6">
            </td>
        <td class="style8">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </td>
        <td class="style10">
            </td>
        <td class="style12">
            </td>
        <td class="style5">
            </td>
        <td class="style5">
            </td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style15">
            Actualizar Proveedores</td>
        <td class="style13">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style15">
            &nbsp;</td>
        <td class="style13">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
                Nit/Cedula</td>
        <td class="style11">
            <asp:TextBox ID="txtced" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td class="style13">
                Departamento</td>
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
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
                Nombre/Razon Social</td>
        <td class="style11">
            <asp:TextBox ID="txtnom" runat="server" Width="229px"></asp:TextBox>
        </td>
        <td class="style13">
                Ciudad</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbciu" runat="server">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            Direccion</td>
        <td class="style11">
            <asp:TextBox ID="txtdir" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td class="style13">
            Email</td>
        <td>
            <asp:TextBox ID="txtema" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtema" ErrorMessage="Direccion Invalida" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            Telefono</td>
        <td class="style11">
            <asp:TextBox ID="txttel" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td class="style13">
            Estado</td>
        <td>
            <asp:DropDownList ID="cbestado" runat="server">
                <asp:ListItem Value="99">Seleccionar...</asp:ListItem>
                <asp:ListItem Value="True">Activo</asp:ListItem>
                <asp:ListItem Value="False">Inactivo</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style11">
            <asp:ImageButton ID="btnnuevo" runat="server" Height="43px" 
                ImageUrl="~/imagenes/nuevo.png" Width="46px" />
            <asp:ImageButton ID="btnguardar" runat="server" Height="43px" 
                ImageUrl="~/imagenes/guardar.png" Width="46px" />
            <asp:ImageButton ID="btncancelar" runat="server" 
                ImageUrl="~/imagenes/Cancel.png" />
        </td>
        <td class="style13">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style11">
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style11">
            Buscar:<br />
            <asp:TextBox ID="txtbus" runat="server" Width="180px"></asp:TextBox>
            <asp:ImageButton ID="btnbuscar" runat="server" Height="16px" 
                ImageUrl="~/imagenes/buscar.png" Width="21px" />
        </td>
        <td class="style13">
            <asp:Button ID="btnconsultall" runat="server" Font-Size="XX-Small" Height="18px" 
                Text="Consultar Todos" Width="87px" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7" colspan="6">
            <table class="style4">
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" 
                            AutoGenerateEditButton="True" BackColor="White" BorderColor="#3366CC" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" 
                            HorizontalAlign="Center" Width="742px">
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style13">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

