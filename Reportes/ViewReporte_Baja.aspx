﻿<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="ViewReporte_Baja.aspx.vb" Inherits="Reportes_ViewReporte_Baja" title="Página sin título" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="True" Height="50px" ReportSourceID="Datos_Baja" 
    Width="350px" DisplayGroupTree="False" />
<br />
<CR:CrystalReportSource ID="Datos_Baja" runat="server">
    <Report FileName="Reportes\Reporte_Baja.rpt">
    </Report>
</CR:CrystalReportSource>
<br />
<br />
<br />
</asp:Content>
