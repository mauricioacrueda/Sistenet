<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="mto_cotizacion.aspx.vb" Inherits="Forms_mto_cotizacion" title="Actualizar Cotizacion" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .style4
    {
        width: 100%;
    }
    .style6
    {
            width: 352px;
        }
    .style7
    {
            width: 96px;
        }
    .style8
    {
        width: 560px;
        font-weight: bold;
    }
        .style9
        {
            width: 352px;
            height: 11px;
        }
        .style10
        {
            width: 96px;
            height: 11px;
        }
        .style11
        {
            width: 560px;
            height: 11px;
        }
        .style12
        {
            height: 11px;
        }
    .style5
    {
        width: 560px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style4">
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style8">
            Buscar Cotizacion</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            <asp:ScriptManager ID="ScriptManager1" runat="server" 
                EnableScriptGlobalization="True">
            </asp:ScriptManager>
        </td>
        <td class="style10">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style12">
            &nbsp;</td>
        <td class="style12">
            &nbsp;</td>
        <td class="style12">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            <asp:HiddenField ID="idcli" runat="server" />
        </td>
        <td class="style7">
                    <asp:Label ID="lbcliente" runat="server" Text="Cliente"></asp:Label>
        </td>
        <td class="style5">
                    <asp:TextBox ID="txtcliente" runat="server" Width="350px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="txtcliente_AutoCompleteExtender0" runat="server" 
                DelimiterCharacters="" Enabled="True" ServicePath="~/autocompletar.asmx" 
                TargetControlID="txtcliente" ServiceMethod="ObtListaClientes" 
                CompletionInterval="0">
                    </cc1:AutoCompleteExtender>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            Fecha Desde</td>
        <td class="style5">
                            <asp:TextBox ID="txtfecha1" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtfecha1_CalendarExtender0" runat="server" 
                                Enabled="True" Format="MM-dd-yyyy" 
                TargetControlID="txtfecha1">
                            </cc1:CalendarExtender>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            Fecha Hasta</td>
        <td class="style5">
            <asp:TextBox ID="txtfecha2" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="txtfecha2_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtfecha2" Format="MM-dd-yyyy">
            </cc1:CalendarExtender>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style5">
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style5">
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="6" style="text-align: center">
                    <asp:GridView ID="GridView1" runat="server"

                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="Registro" 
                                DataNavigateUrlFormatString="~/Forms/cotizacion.aspx?p1={0}" 
                                FooterText="footer" NavigateUrl="~/Forms/orden_servicio.aspx" 
                                Text="Seleccionar" />
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
        </td>
        <td class="style7">
        </td>
        <td class="style5">
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

