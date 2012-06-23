<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="mto_usuario.aspx.vb" Inherits="Forms_mto_usuario" title="Actualizar Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style4
    {
        width: 100%;
    }
        .style8
        {
            text-align: center;
        }
        .style9
        {
            text-align: center;
        }
        .style15
    {
        width: 253px;
        height: 33px;
    }
    .style16
    {
        width: 163px;
        height: 33px;
    }
    .style18
    {
        height: 33px;
            width: 984px;
        }
        .style20
        {
            width: 163px;
        }
        .style22
        {
            text-align: center;
            height: 26px;
        }
        .style23
        {
            height: 5px;
            text-align: center;
        }
        .style24
        {
            width: 253px;
            height: 4px;
        }
        .style25
        {
            height: 4px;
            width: 984px;
        }
        .style26
        {
            text-align: center;
            height: 4px;
        }
        .style27
        {
            width: 965px;
        }
        .style28
        {
            width: 253px;
        }
        .style30
        {
            text-align: center;
            height: 26px;
            width: 984px;
        }
        .style31
        {
            height: 5px;
            text-align: center;
            width: 984px;
        }
        .style32
        {
            text-align: center;
            width: 984px;
        }
        .style33
        {
            text-align: center;
            height: 15px;
        }
        .style34
        {
            text-align: center;
            width: 984px;
            height: 15px;
        }
        .style35
        {
            width: 169px;
            height: 33px;
        }
        .style36
        {
            width: 169px;
        }
        .style37
        {
            text-align: center;
            height: 26px;
            width: 253px;
        }
        .style38
        {
            height: 5px;
            text-align: center;
            width: 253px;
        }
        .style39
        {
            text-align: center;
            height: 15px;
            width: 253px;
        }
        .style40
        {
            text-align: center;
            width: 253px;
        }
        .style41
        {
            width: 984px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style27">
    <tr>
        <td class="style28">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </td>
        <td class="style8" colspan="2">
            M<b style="text-align: center">antenimiento de Usuario</b></td>
        <td class="style41">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style28">
            &nbsp;</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td class="style41">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Usuario:</td>
        <td class="style16">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtusu" runat="server" Width="157px"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style35">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estado:</td>
        <td class="style18">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbestado" runat="server" Height="22px" 
    Width="178px">
                        <asp:ListItem>Seleccionar...</asp:ListItem>
                        <asp:ListItem Value="True">Activo</asp:ListItem>
                        <asp:ListItem Value="False">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
                                </td>
    </tr>
    <tr>
        <td class="style28">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nombres:</td>
        <td class="style20">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtnom" runat="server" Width="157px"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style36">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Apellidos:</td>
        <td class="style41">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtape" runat="server" Width="157px"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style28">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;E-Mail:</td>
        <td class="style20">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtema" runat="server" Width="157px"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style36">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Perfil:</td>
        <td class="style41">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbperfil" runat="server" Width="178px">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style28">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Contraseña:</td>
        <td class="style20">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtpass" runat="server" Width="157px" TextMode="Password"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style36">
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Confirmar Contraseña:</td>
        <td class="style41">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtconfirpass" runat="server" Width="157px" 
                        TextMode="Password"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style24">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtema" ErrorMessage="Direccion Invalida" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
        <td class="style26" colspan="2">
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style25">
            </td>
    </tr>
    <tr>
        <td class="style37">
            </td>
        <td class="style22" colspan="2">
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                    <asp:ImageButton ID="btnnuevo" runat="server" Height="43px" 
                ImageUrl="~/imagenes/nuevo.png" style="margin-top: 0px" 
    Width="46px" />
                    <asp:ImageButton ID="btnguardar" runat="server" Height="43px" 
                        ImageUrl="~/imagenes/guardar.png" style="text-align: center" Width="46px" />
                    <asp:ImageButton ID="btncancelar" runat="server" 
                        ImageUrl="~/imagenes/Cancel.png" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style30">
            </td>
    </tr>
    <tr>
        <td class="style38">
            </td>
        <td class="style23" colspan="2">
            </td>
        <td class="style31">
            </td>
    </tr>
    <tr>
        <td class="style39">
            </td>
        <td class="style33" colspan="2">
            Buscar:
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtbus" runat="server" Width="157px"></asp:TextBox>
                    <asp:ImageButton ID="btnbuscar" runat="server" Height="20px" 
                        ImageUrl="~/imagenes/buscar.png" onclick="ImageButton1_Click" Width="26px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style34">
            </td>
    </tr>
    <tr>
        <td class="style40">
            &nbsp;</td>
        <td class="style8" colspan="2">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label2" runat="server" style="text-align: left" 
    Text="Label" Visible="False"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style32">
            <table class="style4">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnconsultartodos" runat="server" BorderStyle="Solid" 
                            Font-Size="X-Small" Height="18px" Text="Consultar Todos" Width="87px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="style9" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" 
    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" AllowPaging="True" ForeColor="Black" AutoGenerateEditButton="True">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" 
        HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" 
        ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" 
        ForeColor="#CCCCFF" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style40">
            &nbsp;</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td class="style32">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style40">
            &nbsp;</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td class="style32">
            &nbsp;</td>
    </tr>
</table>
            <br />
</asp:Content>

