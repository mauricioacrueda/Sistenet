<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="Baja.aspx.vb" Inherits="Forms_Baja" title="Baja" %>
<%@ register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccl" %>
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
        .style6
        {
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" >
    </asp:ScriptManager>
 
            <table style="width: 90%;">
                <tr>
                    <td>
                        <b __designer:mapid="44">BAJA</b></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkAgregar" runat="server">Ingresar Baja</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkConsultar" runat="server">Consultar baja</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                                            
                        <asp:Panel ID="PnIngresar" runat="server">
                                          
                          <table style="width:100%;">
                                <tr>
                                    <td colspan="2">
                                        <b>INGRESAR BAJA</b></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LbBodega" runat="server" Text="Bodega"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="cbbod" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="30%">
                                                    <asp:Label ID="LbObservacion" runat="server" Text="Observación"></asp:Label>
                                                </td>
                                                <td width="70%">
                                                    <asp:TextBox ID="txtObservacion" runat="server" Height="64px" Width="541px" 
                                                        MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                         
                                       
                                                 <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="LbBusqueda" runat="server" 
                                                                Text="Busque los productos que desea dar de baja"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtbus" runat="server" CssClass="style6"></asp:TextBox>
                                                            <asp:ImageButton ID="btnbuscar" runat="server" Height="30px" 
                                                                ImageUrl="~/imagenes/buscar.png" Width="30px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" width="30%">
                                                            <asp:Label ID="LbMensaje" runat="server"></asp:Label>
                                                            <asp:Label ID="label1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="LbNota" runat="server" 
                                            Text="Nota: Debe seleccionar los productos de la grilla y dar clic en el boton &quot;Agregar Productos&quot;."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                  
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GvProductos"  DataKeyNames="id" 
                                                               runat="server" AllowPaging="True" 
                                                                AutoGenerateColumns="False" 
                                                                style="margin-right: 2px; top: 0px; left: -105px;" BackColor="White" 
                                                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                                CssClass="Alinear_GridVief" >
                                                                 <RowStyle BackColor="White" ForeColor="#003399" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Agregar">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Editar" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                                                                ImageUrl="../imagenes/editar.gif" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Eliminar" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton4" runat="server" 
                                                                                ImageUrl="../imagenes/eliminar.gif" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="cantidad" HeaderText="Existencias" />
                                                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                                                    <asp:TemplateField HeaderText="Cantidad">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TextBox4" runat="server" Width="86px" ></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                                ControlToValidate="TextBox4" ErrorMessage="RegularExpressionValidator" 
                                                                                ValidationExpression="[0-9]*">Solo Números</asp:RegularExpressionValidator>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnAgregarProducto" runat="server" CssClass="Alinear_Objetos" 
                                                                Height="50px" ImageUrl="~/imagenes/add.png" 
                                                                ToolTip="Agregar Productos para dar de Baja" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GvDetalleProductos"  AutoGenerateDeleteButton="True" 
                                                               runat="server" AllowPaging="True" 
                                                                AutoGenerateColumns="False" 
                                                                style="margin-right: 2px; top: 0px; left: -105px;" BackColor="White" 
                                                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                                CssClass="Alinear_GridVief" >
                                                                 <RowStyle BackColor="White" ForeColor="#003399" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="idproducto" HeaderText="idproducto" 
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="nombre" HeaderText="Producto" />
                                                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                                    <asp:TemplateField HeaderText="Eliminar" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton4" runat="server" 
                                                                                ImageUrl="../imagenes/eliminar.gif" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:ImageButton ID="btnGuardar" runat="server" Height="56px" 
                                                                ImageUrl="~/imagenes/guardar.png" Width="56px" CssClass="Aliniar_text" 
                                                                ToolTip="Da de Baja de lso articulos de la lista" />
                                                            <asp:ImageButton ID="btnRegresar" runat="server" Height="56px" 
                                                                ImageUrl="~/imagenes/regresar.jpg" Width="56px" 
                                                                ToolTip="Regresa al anterior formulario" />
                                                            <asp:ImageButton ID="btncancelar" runat="server" 
                                                                ImageUrl="~/imagenes/Cancel.png" onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            
                                    </td>
                                </tr>
                            </table>
                            
                         </asp:Panel>
                        
                       
                                         
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="PnConsulta" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <b>CONSULTAR BAJA</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:TextBox ID="txtbodega" runat="server" Height="22px" Width="185px"></asp:TextBox>
                                        <ccl:AutoCompleteExtender ID="txtbodega_AutoCompleteExtender" runat="server" 
                                            CompletionInterval="0" DelimiterCharacters="" Enabled="True" 
                                            MinimumPrefixLength="1" ServiceMethod="ObtListabodega" 
                                            ServicePath="~/autocompletar.asmx" TargetControlID="txtbodega">
                                        </ccl:AutoCompleteExtender>
                                        <asp:ImageButton ID="btnbusinv" runat="server" Height="31px" 
                                            ImageUrl="~/imagenes/buscar.png" ToolTip="Buscar(id y Nombre)" Width="33px" />
                                        Buscar por Bodega<br />
                                        <asp:Label ID="LbConsulta0" runat="server" 
                                            Text="A continuación se listan los bajas registrados en el sistema."></asp:Label>
                                        <br />
                                        <asp:GridView ID="Gvbajas" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" AutoGenerateDeleteButton="True" 
                                            AutoGenerateSelectButton="True" BackColor="White" BorderColor="#3366CC" 
                                            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                            CssClass="Alinear_GridVief" DataKeyNames="registro" 
                                            style="margin-right: 2px; top: 0px; left: -105px;">
                                            <RowStyle BackColor="White" ForeColor="#003399" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Eliminar" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton5" runat="server" 
                                                            ImageUrl="../imagenes/eliminar.gif" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="registro" HeaderText="Consecutivo" />
                                                <asp:BoundField DataField="nombre" HeaderText="Bodega" />
                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                                            </Columns>
                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LbConsulta" runat="server" 
                                            Text="A continuación se listan los bajas registrados en el sistema."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="bodega" runat="server" />
                                        <br />
                                        <asp:ImageButton ID="btnRegresar2" runat="server" Height="56px" 
                                            ImageUrl="~/imagenes/regresar.jpg" Width="56px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
    </table>
    <br />
    <br />
    <br />
    </asp:Content>

