<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="ViewReporte_Cotizacion.aspx.vb" Inherits="Reportes_ViewReporte_Cotizacion" title="Página sin título" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="True" Height="50px" ReportSourceID="origen_reporte" 
    Width="350px" ReuseParameterValuesOnRefresh="True" 
    DisplayGroupTree="False" />
    <CR:CrystalReportSource ID="origen_reporte" runat="server">
        <Report FileName="Reportes\Reporte_Cotzacion_.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

