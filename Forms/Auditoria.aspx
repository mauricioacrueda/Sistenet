<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="Auditoria.aspx.vb" Inherits="Forms_Auditoria" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <p align=center> Consultar auditorias</p>
            <p align="center">
                <asp:TextBox ID="txtbus" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnbuscar" runat="server" Height="31px" 
                    ImageUrl="~/imagenes/buscar.png" ToolTip="Buscar(id y Nombre)" Width="33px" />
            </p>
            <p align="center">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <p align="center">
                <asp:GridView ID="GvAuditoria" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    CssClass="Alinear_GridVief">
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                </asp:GridView>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
            <p align="center">
                &nbsp;</p>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

