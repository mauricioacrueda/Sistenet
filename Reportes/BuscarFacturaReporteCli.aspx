<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="BuscarFacturaReporteCli.aspx.vb" Inherits="Reportes_BuscarFacturaReporteCli" title="Reporte Facturacion" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style4
        {
            width: 1084px;
        }
        .style6
        {
        width: 131px;
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
        .style10
        {
            width: 350px;
            font-weight: bold;
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
            <td class="style10">
                Generar Reporte Facturacion Por Cliente</td>
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
                                Enabled="True" Format="MM/dd/yyyy" 
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
                Enabled="True" TargetControlID="txtfecha2" Format="MM/dd/yyyy">
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
                <asp:Button ID="btngenerar" runat="server" Text="Generar" />
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
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    Height="50px" ReportSourceID="CrystalReportSource1" Width="350px" 
        DisplayGroupTree="False" />
<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    <Report FileName="Reportes\Reporte_FacturaCliente.rpt">
    </Report>
</CR:CrystalReportSource>
</asp:Content>

