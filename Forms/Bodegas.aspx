<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="Bodegas.aspx.vb" Inherits="Forms_Bodegas" title="Bodega" %>

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
                </p>
            <p ALIGN=center><b>BODEGAS</b></p>
            <p align=center>Identificaci�n<asp:TextBox ID="TextBox1" runat="server" 
                    CssClass="Alinear_Objetos" Height="22px" Width="128px" 
                    ToolTip="Recuerde que este Valor lo genera el Sistema"></asp:TextBox>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
                <p align=center>Nombre&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="Alinear_Objetos" Height="22px" 
                        Width="128px" MaxLength="50"></asp:TextBox>
            </p>
            <p align=center>Direcci�n</p>
                <asp:TextBox ID="TextBox3" runat="server" 
                CssClass="Alinear_Objetos" MaxLength="100"></asp:TextBox>
        
                <p align=center>Departamento</p>
                <asp:DropDownList ID="cbdep" runat="server" AutoPostBack="True" 
                CssClass="Alinear_Objetos" Height="22px">
                </asp:DropDownList>
           
                <p align=center>Ciudad</p>
            <asp:DropDownList ID="cbmuni" runat="server" 
                CssClass="Alinear_Objetos">
            </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:ImageButton ID="btnnuevo" runat="server" Height="44px" 
                    ImageUrl="~/imagenes/nuevo.png" Width="43px" ToolTip="Habilitar Campos" />
                <asp:ImageButton ID="btnguardar" runat="server" 
                    ImageUrl="~/imagenes/guardar.png" Height="41px" Width="47px" 
                    ToolTip="Guardar Valores" />            
                <br />
                <asp:Button ID="btnconsultodos" runat="server" BorderStyle="Solid" 
                    CssClass="Alinear_Objetos" Font-Size="XX-Small" Height="18px" 
                    Text="Consultar Todos" Width="87px" />
                <br /><p align=center><asp:TextBox ID="txtbus" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnbuscar" runat="server" Height="31px" 
                    ImageUrl="~/imagenes/buscar.png" Width="33px" ToolTip="Buscar(id y Nombre)" /></p>
                
                <p align=center><asp:Label ID="Label2" runat="server"></asp:Label></p>
       
            <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" 
                AutoGenerateEditButton="True" AllowPaging="True" 
                CssClass="Alinear_GridVief"   
    PagerStyle-CssClass="pgr"  
    AlternatingRowStyle-CssClass="alt" BackColor="White" BorderColor="#3366CC" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <RowStyle BackColor="White" ForeColor="#003399" />
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <AlternatingRowStyle CssClass="alt" />
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
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <asp:AsyncPostBackTrigger ControlID="accion" />
                        <asp:AsyncPostBackTrigger ControlID="cbmuni" />
                        <asp:AsyncPostBackTrigger ControlID="ScriptManager1" />
                    </Triggers>
    </asp:UpdatePanel>

   
    
</asp:Content>
