<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="BuscarFacturaReporte.aspx.vb" Inherits="Reportes_BuscarFacturaReporte" title="Página sin título" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style4
        {
            width: 1084px;
        }
        .style6
        {
            width: 143px;
        }
        .style7
        {
            width: 81px;
        }
        .style8
        {
            width: 350px;
        }
        .style9
        {
            width: 4px;
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
            Buscar Orden</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:ScriptManager ID="ScriptManager1" runat="server" 
                                        EnableScriptGlobalization="True">
                </asp:ScriptManager>
            </td>
            <td class="style7">
                                    &nbsp;</td>
            <td class="style8">
                                    &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:HiddenField ID="idcli" runat="server" />
            </td>
            <td class="style7">
                <asp:Label ID="lbcliente" runat="server" Text="Cliente"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="txtcliente" runat="server" Width="350px"></asp:TextBox>
                <cc1:autocompleteextender ID="txtcliente_AutoCompleteExtender0" runat="server" 
                DelimiterCharacters="" Enabled="True" ServicePath="~/autocompletar.asmx" 
                TargetControlID="txtcliente" ServiceMethod="ObtListaClientes" 
                CompletionInterval="30">
                </cc1:autocompleteextender>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                                    &nbsp;</td>
            <td class="style7">
            Fecha Desde</td>
            <td class="style8">
                <asp:TextBox ID="txtfecha1" runat="server"></asp:TextBox>
                <cc1:calendarextender ID="txtfecha1_CalendarExtender0" runat="server" 
                                Enabled="True" Format="MM-dd-yyyy" 
                TargetControlID="txtfecha1">
                </cc1:calendarextender>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
            Fecha Hasta</td>
            <td class="style8">
                <asp:TextBox ID="txtfecha2" runat="server"></asp:TextBox>
                <cc1:calendarextender ID="txtfecha2_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtfecha2" Format="MM-dd-yyyy">
                </cc1:calendarextender>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnbuscar" runat="server" Text="Buscar" />
            &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <asp:GridView ID="GridView1" runat="server"

                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" AutoGenerateSelectButton="True">
                    <RowStyle BackColor="White" ForeColor="#003399" />
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
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

