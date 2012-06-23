<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="inventario.aspx.vb" Inherits="Forms_inventario" title="Inventario" %>
<%@ register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" >
    </asp:ScriptManager>
 
            <table style="width: 90%;">
                <tr>
                    <td>
                        <b __designer:mapid="43b">INVENTARIO</b></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkAgregar" runat="server">Ingresar Invientario</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkConsultar" runat="server">Consultar Inventario</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LnkExistencias" runat="server">Consultar Existencias</asp:LinkButton>
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
                                        <asp:Label ID="LbIngresar0" runat="server" Text="INGRESAR INVENTARIO"></asp:Label>
                                    </td>
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
                                                    <asp:DropDownList ID="cbbod" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="30%">
                                                    <asp:Label ID="LbObservacion" runat="server" Text="Observación"></asp:Label>
                                                </td>
                                                <td width="70%">
                                                    <asp:TextBox ID="txtObservacion" runat="server" Height="64px" Width="541px" 
                                                        MaxLength="500" TextMode="MultiLine"></asp:TextBox>
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
                                                                Text="Busque los productos que desea ingresar a la bodega"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtbus" runat="server"></asp:TextBox>
                                                            <asp:ImageButton ID="btnbuscar" runat="server" Height="30px" 
                                                                ImageUrl="~/imagenes/buscar.png" Width="30px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" width="30%">
                                                            <asp:Label ID="LbMensaje" runat="server"></asp:Label>
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
                                            
                                            Text="Nota: Debe seleccionar los productos de la Tabla y dar clic en el boton &quot;Agregar Productos&quot;."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                  
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GvProductos" runat="server" AllowPaging="True" 
                                                                AutoGenerateColumns="False" 
                                                                style="margin-right: 2px; top: 0px; left: -105px;" BackColor="White" 
                                                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                                CssClass="Alinear_GridVief" DataKeyNames="Codigo">
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
                                                                    <asp:TemplateField HeaderText="id" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbid" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                   
                                                                    <asp:BoundField DataField="nombre" HeaderText="nombre" />
                                                                    <asp:TemplateField HeaderText="Cantidad">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TextBox4" runat="server" Width="86px"></asp:TextBox>
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
                                                            <asp:ImageButton ID="btnAgregarProducto" runat="server" 
                                                                ImageUrl="~/imagenes/add.png" CssClass="Alinear_Objetos" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            
                                                            <asp:GridView ID="GvDetalleProductos"  AutoGenerateDeleteButton="True" runat="server" AllowPaging="True" 
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
                                                                            <asp:ImageButton ID="ImageButton6" runat="server" 
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
                                                        <td align ="center">
                                                            <asp:ImageButton ID="btnGuardar" runat="server" Height="56px" 
                                                                ImageUrl="~/imagenes/guardar.png" Width="56px" />
                                                            <asp:ImageButton ID="btnRegresar" runat="server" Height="56px" 
                                                                ImageUrl="~/imagenes/regresar.jpg" Width="56px" />
                                                            <asp:ImageButton ID="btncancelar" runat="server" 
                                                                ImageUrl="~/imagenes/Cancel.png" 
                                                                onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
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
                                        <asp:Label ID="LbConsultar" runat="server" Text="CONSULTAR INVENTARIO"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtbodega" runat="server" Height="22px" Width="185px"></asp:TextBox>
                                        <ccl:AutoCompleteExtender ID="txtbodega_AutoCompleteExtender" runat="server" 
                                            CompletionInterval="0" DelimiterCharacters="" Enabled="True" 
                                            MinimumPrefixLength="1" ServiceMethod="ObtListabodega" 
                                            ServicePath="~/autocompletar.asmx" TargetControlID="txtbodega">
                                        </ccl:AutoCompleteExtender>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="btnbusinv" runat="server" Height="31px" 
                                            ImageUrl="~/imagenes/buscar.png" ToolTip="Buscar(id y Nombre)" Width="33px" />
                                        Buscar Por Bodega</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LbConsulta" runat="server" 
                                            Text="A continuación se listan los inventarios registrados en el sistema."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GvInventarios" DataKeyNames="registro" 
                                            AutoGenerateDeleteButton="True"  AutoGenerateSelectButton="True" runat="server" AllowPaging="True" 
                                                                AutoGenerateColumns="False" 
                                                                style="margin-right: 2px; top: 0px; left: -105px;" BackColor="White" 
                                                                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                                CssClass="Alinear_GridVief">
                                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                            <Columns>
                                                <asp:BoundField DataField="registro" HeaderText="No." />
                                                <asp:BoundField DataField="nombre" HeaderText="Bodega" />
                                                <asp:BoundField DataField="producto" HeaderText="Producto" />
                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                                                <asp:TemplateField HeaderText="Eliminar" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton5" runat="server" 
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
                                        <asp:HiddenField ID="bodega" runat="server" />
                                        <br />
                                        <asp:ImageButton ID="btnRegresar2" runat="server" Height="56px" 
                                            ImageUrl="~/imagenes/regresar.jpg" Width="56px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                <td>
                 <asp:Panel ID="PnExistencias" runat="server">
                                    
                                            <table style="width:100%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LbExistencias" runat="server" Text="CONSULTAR EXISTENCIAS"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtexistencias" runat="server" Height="22px" Width="185px"></asp:TextBox>
                                                        <ccl:AutoCompleteExtender ID="txtexistencias_AutoCompleteExtender" runat="server" 
                                                            CompletionInterval="0" DelimiterCharacters="" Enabled="True" 
                                                            MinimumPrefixLength="1" ServiceMethod="ObtListabodega" 
                                                            ServicePath="~/autocompletar.asmx" TargetControlID="txtexistencias">
                                                        </ccl:AutoCompleteExtender>
                                                        <asp:ImageButton ID="btnbusexi" runat="server" Height="31px" 
                                                            ImageUrl="~/imagenes/buscar.png" ToolTip="Buscar(id y Nombre)" 
                                                            Width="33px" />
                                                        &nbsp;Buscar Por Bodega<br />
                                                        <asp:Label ID="LbConsulta0" runat="server" 
                                                            Text="A continuación se listan las Existencias registrados en el sistema."></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GvExistencias" runat="server" AllowPaging="True" 
                                                            AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                                                            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                            CssClass="Alinear_GridVief" DataKeyNames="registro" 
                                                            style="margin-right: 2px; top: 0px; left: -105px;">
                                                            <RowStyle BackColor="White" ForeColor="#003399" />
                                                            <Columns>
                                                                <asp:BoundField DataField="nombre" HeaderText="Bodega" />
                                                                <asp:BoundField DataField="producto" HeaderText="Producto" />
                                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                                <asp:TemplateField HeaderText="Eliminar" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton7" runat="server" 
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
                                                        <asp:HiddenField ID="bodegaexis" runat="server" />
                                                        <asp:Button ID="ImpRep" runat="server" 
                                                            Text="Imprimir Reporte Total por bodega" />
                                                        <br />
                                                        <asp:ImageButton ID="btnRegresar3" runat="server" Height="56px" 
                                                            ImageUrl="~/imagenes/regresar.jpg" Width="56px" />
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
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

