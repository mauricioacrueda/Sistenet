<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="Clientes.aspx.vb" Inherits="Clientes" title="Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style4
    {
        width: 100%;
    }
    .style5
    {
            font-weight: 700;
            width: 393px;
        }
    .style6
    {
            text-align: center;
        }
    .style7
    {
            width: 135px;
            font-weight: 700;
        }
    .style8
    {
        font-size: large;
        font-weight: bold;
    }
        .style9
        {
            font-weight: 700;
            text-align: center;
            height: 34px;
        }
        .style10
        {
            font-weight: 700;
            width: 393px;
            height: 20px;
        }
        .style11
        {
            width: 184px;
            height: 20px;
            font-weight: bold;
        }
        .style12
        {
            width: 135px;
            font-weight: 700;
            height: 20px;
        }
        .style13
        {
            height: 20px;
        }
        .style14
        {
            height: 13px;
        }
        .style21
        {
            text-align: center;
            height: 20px;
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
        <td class="style8" colspan="4" style="text-align: center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            </td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center">
            <b>CLIENTES</b></td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center" class="style14">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Tipo de Cliente:<span class="style22">(*)</span></td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbtipoclie" runat="server" Width="180px" Height="22px" 
                        AutoPostBack="True">
                        <asp:ListItem Value="1">Natural</asp:ListItem>
                        <asp:ListItem Value="2">Juridica</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Label" 
    Visible="False"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                                </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Cedula o Nit: <span class="style22">(*)</span></td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtced" runat="server" 
    Width="178px" MaxLength="20"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            Departamento:<span class="style22">(*)</span></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbdepar" runat="server" Height="24px" 
    Width="173px" AutoPostBack="True">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Nombres o Razon Social:<span class="style22">(*)</span></td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtnom" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            Municipio:<span class="style22">(*)</span></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbmuni" runat="server" Height="24px" 
    Width="173px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Apellidos:<span class="style22">(*)</span></td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtape" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            Estado:<span class="style22">(*)</span></td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbestado" runat="server" Height="27px" Width="172px">
                        <asp:ListItem>ACTIVO</asp:ListItem>
                        <asp:ListItem>INACTIVO</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
                                </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Direccion:<span class="style22">(*)</span></td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtdir" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Telefono:</td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txttel" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            E-mail:</td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtema" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtema" ErrorMessage="Direccion Invalida" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="accion" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <asp:ImageButton ID="btnnuevo" runat="server" AlternateText="Nuevo Cliente" 
                Height="49px" ImageUrl="~/imagenes/nuevo.png" ToolTip="Nuevo Cliente" 
                Width="56px" />
                    <asp:ImageButton ID="btnguardar" runat="server" AlternateText="Guardar" 
                        Height="52px" ImageUrl="~/imagenes/Guardar.png" ToolTip="Guardar" 
                        Width="45px" />
                    <asp:ImageButton ID="btncancelar" runat="server" 
                        ImageUrl="~/imagenes/Cancel.png" onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style11">
            Buscar:</td>
        <td class="style12">
            </td>
        <td class="style13">
            </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel18" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtbus" runat="server" Height="21px" 
    Width="176px" AutoCompleteType="Disabled" AutoPostBack="True"></asp:TextBox>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtbus" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style7">
            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False" 
                        Font-Bold="True"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
            </td>
        <td class="style21">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style21">
            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnconsultodos" runat="server" 
    Font-Size="XX-Small" Height="18px" Text="Consultar Todos" Width="87px" BorderStyle="Solid" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style13">
            </td>
    </tr>
    <tr>
        <td class="style9" colspan="4">
            &nbsp;</td>
    </tr>
</table>
<table class="style4">
        <tr>
            <td>
            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" 
                AutoGenerateEditButton="True" BackColor="White" BorderColor="#3366CC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Overline="False" 
                ForeColor="Black" HorizontalAlign="Center" AllowPaging="True" 
                        Width="730px" Height="190px">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" 
                            Wrap="True" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>    
</asp:Content>

