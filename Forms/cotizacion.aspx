<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="cotizacion.aspx.vb" Inherits="Forms_cotizacion" title="Cotizacion" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
  
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
        .style5
        {
            height: 26px;
        }
        .style6
        {
            width: 125px;
        }
        .style7
        {
        }
        .style9
        {
        }
        .style10
        {
            width: 231px;
        }
        .style11
        {
            width: 176px;
        }
        .style12
        {
            height: 26px;
            width: 218px;
        }
        .style15
        {
            width: 136px;
        }
        .style16
        {
            height: 26px;
            width: 136px;
        }
        .style17
        {
            width: 218px;
        }
        .style19
        {
            width: 218px;
            height: 43px;
        }
        .style20
        {
            width: 136px;
            height: 43px;
        }
        .style21
        {
            height: 43px;
        }
        .style23
        {
            height: 43px;
        }
        .style24
        {
            width: 152px;
        }
        .style26
        {
            width: 141px;
        }
        .style27
        {
            width: 123px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Datos Cliente">
        <table class="style4">
            <tr>
                <td class="style19">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                        EnableScriptGlobalization="True">
                    </asp:ScriptManager>
                </td>
                <td class="style20">
                    </td>
                <td class="style21" colspan="2">
                    <b style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Cotización</b></td>
                <td class="style23">
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="idcli" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                <td class="style23">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style15">
                    Cotizacion No</td>
                <td class="style24">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtnumcotiza" runat="server" ReadOnly="True"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style26">
                    &nbsp;</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="accion" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style15">
                    Fecha Cotizacion:</td>
                <td class="style24">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtfcoti" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtfcoti_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtfcoti">
                            </cc1:CalendarExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style26">
                    Fecha vencimiento:</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtfvenci" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtfvenci_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtfvenci" Format="MM-dd-yyyy">
                            </cc1:CalendarExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                    </td>
                <td class="style16">
                    Cliente:</td>
                <td class="style5" colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtcli" runat="server" Height="22px" Width="410px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="txtcli_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="ObtListaClientes" 
                                ServicePath="~/autocompletar.asmx" TargetControlID="txtcli" 
                                CompletionInterval="10">
                            </cc1:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style5">
                    </td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" GroupingText="Datos Cotizacion">
        <table class="style4">
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cbbodega" runat="server" AutoPostBack="True" 
                                Visible="False">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    Producto:</td>
                <td class="style7" colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtpro" runat="server" Height="22px" Width="410px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="txtpro_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="ObtListaProductos" 
                                ServicePath="~/autocompletar.asmx" TargetControlID="txtpro" 
                                CompletionInterval="0" MinimumPrefixLength="2">
                            </cc1:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    Cantidad</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtcant" runat="server" Height="21px" Width="53px"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnagregar" runat="server" Text="Agregar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" colspan="6">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" 
                                AutoGenerateDeleteButton="True" BackColor="White" BorderColor="#3366CC" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                ToolTip="Detalle de la Cotizacion">
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    Total Cotizacion:</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txttotal" runat="server" Enabled="False"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style27">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td class="style11">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server">Imprimir</asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                        <ContentTemplate>
                            &nbsp;<asp:ImageButton ID="btnlimpiar" runat="server" 
                                ImageUrl="~/imagenes/btnLimpiar.png" 
                                ToolTip="LImpia toda la Informacion del Formulario" />
                            &nbsp;&nbsp;
                            <asp:ImageButton ID="btnguardar" runat="server" Height="41px" 
                                ImageUrl="~/imagenes/guardar.png" ToolTip="Guarda La Cotizacion" Width="44px" />
                            <asp:ImageButton ID="btncancelar" runat="server" 
                                ImageUrl="~/imagenes/Cancel.png" 
                                onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style27">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    </td>
                <td class="style6">
                    </td>
                <td>
                    </td>
                <td class="style27">
                    </td>
                <td class="style11">
                    </td>
                <td>
                    </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

