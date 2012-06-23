﻿<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="cargo.aspx.vb" Inherits="Forms_cargo" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript">
 
function AcceptNum(evt) {
              var keynum;
            if (window.event) // IE
            {
                keynum = evt.keyCode;
            }
            else if (evt.which) // Netscape/Firefox/Opera
            {
                keynum = evt.which;
            }
            return (keynum < 13 || (keynum >= 48 && keynum <= 57))       
          }

 
 </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <p align=center><b>CARGO</b></p>
            <p align=center>Código<asp:TextBox ID="TextBox1" 
                runat="server" CssClass="Alinear_Objetos" 
                ToolTip="Recuerde que este campo lo genera el Sistema"></asp:TextBox>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <p align="center">
                Nombre</p>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="Alinear_Objetos" 
                MaxLength="50"></asp:TextBox>
            <br />
            <p align=center>Tipo</p><asp:DropDownList ID="cbtipo" runat="server" 
                CssClass="Alinear_Objetos">
                <asp:ListItem>ADMINISTRATIVO</asp:ListItem>
                <asp:ListItem>ASISTENCIAL</asp:ListItem>
                <asp:ListItem>COMERCIAL</asp:ListItem>
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="btnnuevo" runat="server" Height="46px" 
                ImageUrl="~/imagenes/nuevo.png" Width="46px" ToolTip="Habilitar Campos" />
            <asp:ImageButton ID="btguardar" runat="server" Height="46px" 
                ImageUrl="~/imagenes/guardar.png" Width="46px" ToolTip="Guardar Campos" />
            <asp:ImageButton ID="btncancelar" runat="server" 
                ImageUrl="~/imagenes/Cancel.png" 
                onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');" />
            <br />
            <asp:Button ID="btnconsultodos" runat="server" BorderStyle="Solid" 
                CssClass="Alinear_Objetos" Font-Size="XX-Small" Height="18px" 
                Text="Consultar Todos" Width="87px" />
         <p align=center><asp:TextBox ID="txtbus" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnbuscar" runat="server" Height="31px" 
                    ImageUrl="~/imagenes/buscar.png" Width="33px" ToolTip="Buscar(id y Nombre)" /></p>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" 
                AutoGenerateEditButton="True" CssClass="Alinear_GridVief" 
                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4">
                <RowStyle BackColor="White" ForeColor="#003399" />
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            </asp:GridView>
            <asp:HiddenField ID="accion" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

