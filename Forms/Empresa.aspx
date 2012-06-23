<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="Empresa.aspx.vb" Inherits="Forms_Empresa" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 951px;
        }
        .style5
        {
        }
        .style6
        {
            width: 507px;
        }
        .style7
        {
            width: 105px;
        }
        .style8
        {
            width: 99px;
            height: 22px;
        }
        .style9
        {
            width: 96px;
        }
        .style10
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style4">
    <tr>
        <td class="style8" colspan="5" style="text-align: center" align="center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="5" style="text-align: center">
            <b __designer:mapid="382">DATOS PERSONALES DE LA EMPRESA</b></td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    Nit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Width="176px" MaxLength="50" ></asp:TextBox>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    <br />
                    Nombre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                    <br />
                    <br />
                    Direcccion&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                    <br />
                    <br />
                    Telefono&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                    <br />
                    <br />
                    Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox5" ErrorMessage="Direccion Invalida" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                    Departamento&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="cbdepar" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <br />
                    <br />
                    Ciudad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="cbmuni" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:ImageButton ID="btnuevo" runat="server" Height="46px" 
                        ImageUrl="~/imagenes/nuevo.png" Width="46px" 
                        ToolTip="Click para podereditar los datos" />
                    <asp:ImageButton ID="btnguardar" runat="server" 
                        ImageUrl="~/imagenes/guardar.png" Height="46px" Width="46px" />
                    <asp:ImageButton ID="btncancelar" runat="server" 
                        ImageUrl="~/imagenes/Cancel.png" 
                        onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');" />
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:HiddenField ID="accion" runat="server" />
                    <br />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TextBox1" />
                    <asp:AsyncPostBackTrigger ControlID="TextBox2" />
                    <asp:AsyncPostBackTrigger ControlID="TextBox3" />
                    <asp:AsyncPostBackTrigger ControlID="TextBox4" />
                    <asp:AsyncPostBackTrigger ControlID="TextBox5" />
                    <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    <asp:AsyncPostBackTrigger ControlID="accion" />
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
        <td class="style9">
            &nbsp;</td>
        <td class="style6">
            <br />
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10" colspan="5">
            </td>
    </tr>
    <tr>
        <td class="style5" align="center" colspan="5">
            &nbsp;</td>
    </tr>
</table></asp:Content>

