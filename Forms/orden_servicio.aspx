<%@ Page Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="orden_servicio.aspx.vb" Inherits="Forms_orden_trabajo" title="Orden de Servicio" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
    {
        text-align: center;
        font-weight: bold;
        height: 36px;
    }
        .style15
        {
            width: 100px;
        }
        .style17
        {
            height: 36px;
            width: 8%;
        }
        .style20
        {
            height: 36px;
            width: 223px;
        }
        .style24
        {}
        .style25
        {
            height: 36px;
            width: 290px;
        }
        .style26
        {
            height: 36px;
            }
        .style27
        {
            height: 36px;
            width: 1%;
        }
        .style28
        {
            width: 223px;
        }
        .style29
        {
            width: 8%;
        }
        .style30
        {
        }
        .style33
        {
            width: 1%;
        }
        .style34
        {
            height: 41px;
            width: 223px;
        }
        .style35
        {
            height: 41px;
            width: 8%;
        }
        .style36
        {
            height: 41px;
            text-align: center;
            font-weight: bold;
        }
        .style37
        {
            height: 41px;
            width: 290px;
        }
        .style38
        {
            height: 41px;
        }
        .style39
        {
            height: 41px;
            width: 1%;
        }
        .style40
        {
            width: 290px;
        }
        .style41
        {
            height: 3px;
            width: 223px;
        }
        .style42
        {
            height: 3px;
            width: 8%;
        }
        .style43
        {
            width: 227px;
            height: 3px;
            text-align: center;
            font-weight: bold;
        }
        .style44
        {
            height: 3px;
            width: 100px;
        }
        .style45
        {
            height: 3px;
            width: 290px;
        }
        .style46
        {
            height: 3px;
            }
        .style47
        {
            height: 3px;
            width: 1%;
        }
        .style48
        {
            font-size: x-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="Alinear_Objetos">
        <tr>
            <td class="style20">
                <asp:ScriptManager ID="ScriptManager1" runat="server" 
                    EnableScriptGlobalization="True">
                </asp:ScriptManager>
                </td>
            <td class="style17">
                &nbsp;</td>
            <td class="style9" colspan="2">
                Orden de Servicio</td>
            <td class="style25">
                </td>
            <td class="style26">
                <asp:HiddenField ID="idcli" runat="server" />
                                </td>
            <td class="style27">
                &nbsp;</td>
            <td class="style27">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30" colspan="2">
          
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                Registro de Orden
                :</td>
            <td class="style30">
                <asp:TextBox ID="txtregis" runat="server" Height="22px" Width="166px" 
                    Enabled="False" ToolTip="Recuerde que este campo lo genera el Sistema"></asp:TextBox>
                                </td>
            <td class="style15">
                Estado Orden</td>
            <td class="style40">
                <asp:DropDownList ID="cbestado" runat="server" Height="23px" Width="166px">
                    <asp:ListItem>ABIERTO</asp:ListItem>
                    <asp:ListItem>CERRADO</asp:ListItem>
                </asp:DropDownList> <span class="style48">(*)</span></td>
            <td>
                <asp:HiddenField ID="idemp" runat="server" Visible="False" />
            </td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                Fecha Apertura:</td>
            <td class="style30">
      
                <asp:TextBox ID="txtfecha1" runat="server" Height="22px" Width="166px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtfecha1_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtfecha1" Format="MM-dd-yyyy">
                </cc1:CalendarExtender>
                                </td>
            <td class="style15">
                Fecha Cierre:</td>
            <td class="style40">
                <asp:TextBox ID="txtfecha2" runat="server" Height="22px" Width="166px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtfecha2_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtfecha2" Format="MM-dd-yyyy">
                </cc1:CalendarExtender>
                                </td>
            <td>
                <asp:HiddenField ID="accion" runat="server" />
                                </td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                Tecnico Asignado</td>
            <td class="style24" colspan="3">
                <asp:TextBox ID="txttecnico" runat="server" Height="22px" Width="350px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txttecnico_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" Enabled="True" ServiceMethod="ObtListaTecnicos" 
                    ServicePath="~/autocompletar.asmx" TargetControlID="txttecnico" 
                    CompletionInterval="0">
                </cc1:AutoCompleteExtender>
                <span class="style48">(*)</span></td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style41">
                </td>
            <td class="style42">
                </td>
            <td class="style43">
                                </td>
            <td class="style44">
                </td>
            <td class="style45">
            </td>
            <td class="style46">
                                </td>
            <td class="style47">
                                </td>
            <td class="style47">
                                </td>
        </tr>
        <tr>
            <td class="style34">
                &nbsp;</td>
            <td class="style35">
                </td>
            <td class="style36" colspan="2">
                Información Del Cliente</td>
            <td class="style37">
            </td>
            <td class="style38">
                &nbsp;</td>
            <td class="style39">
                &nbsp;</td>
            <td class="style39">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                </td>
            <td class="style29">
                Cliente:</td>
            <td colspan="3">
                <asp:TextBox ID="txtcliente" runat="server" Height="22px" Width="350px"></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="txtcliente_AutoCompleteExtender" runat="server" enabled="True"
                                servicepath="~/autocompletar.asmx" minimumprefixlength="2" servicemethod="ObtListaClientes"
                                enablecaching="true" targetcontrolid="txtcliente" 
                    usecontextkey="True" completionsetcount="10"
                                completioninterval="0" >
                    </cc1:AutoCompleteExtender>
                <span class="style48">(*)</span></td>
            <td>
                                </td>
            <td class="style33">
                                &nbsp;</td>
            <td class="style33">
                                </td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                </td>
            <td class="style30">
            </td>
            <td class="style15">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style34">
                &nbsp;</td>
            <td class="style35">
                </td>
            <td class="style36" colspan="2">
                Información Del Equipo</td>
            <td class="style37">
            </td>
            <td class="style38">
                &nbsp;</td>
            <td class="style39">
                &nbsp;</td>
            <td class="style39">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                Equipo:</td>
            <td class="style30">
                <asp:TextBox ID="txtequipo" runat="server" Height="22px" Width="166px" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="style15">
                Marca:</td>
            <td class="style40">
                <asp:TextBox ID="txtmarca" runat="server" Height="22px" Width="166px" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                Modelo:</td>
            <td class="style30">
                <asp:TextBox ID="txtmodelo" runat="server" Height="22px" Width="166px" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="style15">
                No de serie</td>
            <td class="style40">
                <asp:TextBox ID="txtserie" runat="server" Height="22px" Width="166px" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                </td>
            <td class="style30">
                </td>
            <td class="style15">
                </td>
            <td class="style40">
                </td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr style="border: thin hidden #800000; visibility: visible;">
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                Descripcion del Servicio:</td>
            <td class="style30" colspan="2">
                <asp:TextBox ID="txtdescriservi" runat="server" Height="76px" TextMode="MultiLine" 
                    Width="322px" MaxLength="500"></asp:TextBox>
                <span class="style48">(*)</span></td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                Observaciones del tecnico:</td>
            <td class="style30" colspan="2">
                <asp:TextBox ID="txtobs" runat="server" Height="76px" TextMode="MultiLine" 
                    Width="322px" MaxLength="500"></asp:TextBox>
            </td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30">
          
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          
                </td>
            <td class="style15">
                <asp:LinkButton ID="LinkButton1" runat="server">Imprimir</asp:LinkButton>
            </td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btnnuevo" runat="server" Height="49px" 
                    ImageUrl="~/imagenes/nuevo.png" Width="47px" />
&nbsp;
                <asp:ImageButton ID="btnguardar" runat="server" Height="48px" 
                    ImageUrl="~/imagenes/guardar.png" Width="48px" />
                                                            <asp:ImageButton ID="btncancelar" runat="server" 
                                                                ImageUrl="~/imagenes/Cancel.png" onclientclick="return confirm('¿Esta Seguro de Salir del Formulario?');"/>
            </td>
            <td class="style15">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
            <td class="style33">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

