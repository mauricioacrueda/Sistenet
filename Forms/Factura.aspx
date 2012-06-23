<%@ Page Title="" Language="VB" MasterPageFile="~/Forms/Plantilla.master" AutoEventWireup="false" CodeFile="Factura.aspx.vb" Inherits="Forms_Factura" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CCS/Letters.css" rel="stylesheet" type="text/css" />
    <link href="../CCS/redmond/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
   
    <script type="text/javascript" src="../JS/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../JS/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../JS/jquery-ui-1.7.2.custom.min.js"></script>
   
    <script type="text/javascript">
      function validaCantidad(source, arguments) {
            if (arguments.Value == "" || arguments.Value == undefined) {
                arguments.IsValid = false;
                return;
            } else if (parseInt(arguments.Value, 10) == 0) {
                arguments.IsValid = false;
                return;
            }
            else {
                arguments.IsValid = true;
                return;
            }
        }
    
        function ValidaFechaVencimiento(sender, args) {
            var c = args.Value;
            var FechaV = document.getElementById('<%= txtFechaHoraVencimientoD.ClientID %>').value;
            var FechaE = document.getElementById('<%= txtFechaHoraCreacionD.ClientID %>').value;

            if (FechaV != "" && FechaE != "") {
                arrFechaV = FechaV.split("/");
                FechaV = arrFechaV[1] + "/" + arrFechaV[0] + "/" + arrFechaV[2]
                var FechaVence = new Date(FechaV);

                arrFechaE = FechaE.split("/");
                FechaE = arrFechaE[1] + "/" + arrFechaE[0] + "/" + arrFechaE[2]
                var FechaEmite = new Date(FechaE);          
                
                if (FechaEmite <= FechaVence && c != "") {
                    args.IsValid = true;
                }
                else if (FechaEmite > FechaVence && c != "") {
                    args.IsValid = false;
                }
            }
        }

        function AcceptNumComa(evt) {
            var key;
            if (window.event) // IE
            {
                key = evt.keyCode;
            }
            else if (evt.which) // Netscape/Firefox/Opera
            {
                key = evt.which;
            }
            return (key < 13 || (key >= 48 && key <= 57) || key == 44 || key == 46);
        }

        function AcceptNum(evt) {
            var key;
            if (window.event) // IE
            {
                key = evt.keyCode;
            }
            else if (evt.which) // Netscape/Firefox/Opera
            {
                key = evt.which;
            }
            return (key < 13 || (key >= 48 && key <= 57));
        }

        function NoEnter(evt) {
            var key;
            if (window.event) // IE
            {
                key = evt.keyCode;
            }
            else if (evt.which) // Netscape/Firefox/Opera
            {
                key = evt.which;
            }
            if (key == 13) { return false; }
        }

      
        function BorrarFechaBusqueda(TextFecha) {            
            var Fecha = document.getElementById(TextFecha);           
            Fecha.value = "Todos";
        }

     
        function CalcularValoresDetalle(btnAgregarDt, ddlIdConceptoDt,  txtCantidadDt, txtValorUnitarioDt, txtBrutoDt,  txtIvaDt,txtNetoDt, IvaVentas, Porcentaje, Base, Multiplicador) {
            var btnAgregar = document.getElementById(btnAgregarDt);
            var ddlIdConcepto = document.getElementById(ddlIdConceptoDt);
            var IndiceDdl = ddlIdConcepto.selectedIndex;
            var txtCantidad = document.getElementById(txtCantidadDt);
            var txtValorUnitario = document.getElementById(txtValorUnitarioDt);
            var txtBruto = document.getElementById(txtBrutoDt);
           
            var txtIva = document.getElementById(txtIvaDt);
             var txtNeto = document.getElementById(txtNetoDt);

            if (ddlIdConcepto != null) {
                if (IndiceDdl > 0) {

                    var ValorBrutoSalida = 0;
                    var Cantidad = 0;
                    var ValorU = 0;
                    var strValorU = "";
                    var strValorUSalida = "";
                    var strBrutoSalida = "";                   

                    if (txtCantidad != null && txtValorUnitario != null && txtBruto != null) {
                        Cantidad = parseInt(txtCantidad.value);
                        ValorU = txtValorUnitario.value;
                        strValorU = ValorU.replace(",", ".");
                        strValorUSalida = ValorU.replace(".", ",");
                        txtValorUnitario.value = strValorUSalida;
                        ValorU = parseFloat(strValorU);                      

                        if (Cantidad > 0 && ValorU > 0) {//***OJO **Cambiar en Compras
                            ValorBrutoSalida = Cantidad * ValorU; //Valor Bruto
                        }
                        else if (Cantidad <= 0 || isNaN(Cantidad)) {
                                txtCantidad.value = "1";//*+*
                        ValorBrutoSalida = Cantidad * ValorU;
                            
                        }

                        if (ValorBrutoSalida > 0) {
                            if (ValorBrutoSalida != parseInt(ValorBrutoSalida)) {
                                strBrutoSalida = "" + ValorBrutoSalida.toFixed(2);
                            }
                            else {
                                strBrutoSalida = "" + ValorBrutoSalida;
                            }
                            strBrutoSalida = strBrutoSalida.replace(".", ",");
                        }
                        else {
                            strBrutoSalida = ValorBrutoSalida;
                        }

                        txtBruto.value = strBrutoSalida;

                        if (ValorBrutoSalida > 0) {
                            if (btnAgregar != null) btnAgregar.disabled = false;
                            //Variables Calcular Valores
                            var ValorReteFuente = 0;                                        
                            var ValorReteIca = 0;
                            var ValorIva = 0;
                            var ValorReteIva = 0;
                            var ValorNeto = 0;
                            var ValorDescuento = 0;
                            
                            //Variables ReteFuente
                            var ValorBase = 0;
                            var PorcentajeRubrosValor = 0;
                            var strPorcentaje = "";
                            var strBase = "";
                            var strReteFuenteSalida = "";
                            
                            //Variables Iva
                            var strIvaVentas = "";
                            var strIvaSalida = "";
                            
                            //Variables ReteIva
                            var strReteIvaSalida = "";

                            //Variables ReteIca
                            var strReteIcaSalida = "";

                            //Variables Descuento
                            var strValorDescuento = "";

                             
                            //Calcular Iva
                                strIvaVentas = "" + IvaVentas;
                                strIvaVentas = strIvaVentas.replace(",", ".");
                                ValorIva = (ValorBrutoSalida * parseFloat(strIvaVentas)) / 100;

                                if (ValorIva != parseInt(ValorIva)) {
                                    strValorIvaSalida = "" + ValorIva.toFixed(2);
                                }
                                else {
                                    strValorIvaSalida = "" + ValorIva;
                                }                              
                               
                                strIvaSalida = strValorIvaSalida.replace(".", ",");                      
                         

                            ValorNeto = ValorBrutoSalida + ValorIva ;
                            if (ValorNeto != parseInt(ValorNeto)) {
                                strNetoSalida = "" + ValorNeto.toFixed(2);
                            }
                            else {
                                strNetoSalida = "" + ValorNeto;
                            }                           
                            strNetoSalida = strNetoSalida.replace(".", ","); //*m*

                            txtIva.value = strIvaSalida;
                            txtNeto.value = strNetoSalida;                            
                            
                        }
                        else {
                            txtIva.value = "0";
                            txtNeto.value = "0";
                            if (btnAgregar != null) btnAgregar.disabled = true;
                        }
                    }                    
                }
            }
        }        
        
       function ValorEnLetras(num)
       {
           var res, dec = "";
           var entero;
           var decimales;
           var nro;
           
           var strnum = num.replace(",", ".");

           if (!isNaN(parseFloat(strnum))) {
               nro = parseFloat(strnum);
           }
          else{
               return "";
           }
           entero = parseInt(Math.floor(nro));
           decimales = parseInt(Math.round((nro - entero) * 100, 2));
           if (decimales > 0)
           {
               dec = " CON " + decimales + "/100";
           }
           res = PasarATexto(parseInt(entero)) + dec + " PESOS MCTE.";
           return res;
       }

       function PasarATexto(valor)
       {
           var Num2Text = "";
           valor = Math.floor(valor);
           if (valor == 0) Num2Text = "CERO";
           else if (valor == 1) Num2Text = "UNO";
           else if (valor == 2) Num2Text = "DOS";
           else if (valor == 3) Num2Text = "TRES";
           else if (valor == 4) Num2Text = "CUATRO";
           else if (valor == 5) Num2Text = "CINCO";
           else if (valor == 6) Num2Text = "SEIS";
           else if (valor == 7) Num2Text = "SIETE";
           else if (valor == 8) Num2Text = "OCHO";
           else if (valor == 9) Num2Text = "NUEVE";
           else if (valor == 10) Num2Text = "DIEZ";
           else if (valor == 11) Num2Text = "ONCE";
           else if (valor == 12) Num2Text = "DOCE";
           else if (valor == 13) Num2Text = "TRECE";
           else if (valor == 14) Num2Text = "CATORCE";
           else if (valor == 15) Num2Text = "QUINCE";
           else if (valor < 20) Num2Text = "DIECI" + PasarATexto(valor - 10);
           else if (valor == 20) Num2Text = "VEINTE";
           else if (valor < 30) Num2Text = "VEINTI" + PasarATexto(valor - 20);
           else if (valor == 30) Num2Text = "TREINTA";
           else if (valor == 40) Num2Text = "CUARENTA";
           else if (valor == 50) Num2Text = "CINCUENTA";
           else if (valor == 60) Num2Text = "SESENTA";
           else if (valor == 70) Num2Text = "SETENTA";
           else if (valor == 80) Num2Text = "OCHENTA";
           else if (valor == 90) Num2Text = "NOVENTA";
           else if (valor < 100) Num2Text = PasarATexto(Math.floor(valor / 10) * 10) + " Y " + PasarATexto(valor % 10);
           else if (valor == 100) Num2Text = "CIEN";
           else if (valor < 200) Num2Text = "CIENTO " + PasarATexto(valor - 100);
           else if ((valor == 200) || (valor == 300) || (valor == 400) || (valor == 600) || (valor == 800)) Num2Text = PasarATexto(Math.floor(valor / 100)) + "CIENTOS";
           else if (valor == 500) Num2Text = "QUINIENTOS";
           else if (valor == 700) Num2Text = "SETECIENTOS";
           else if (valor == 900) Num2Text = "NOVECIENTOS";
           else if (valor < 1000) Num2Text = PasarATexto(Math.floor(valor / 100) * 100) + " " + PasarATexto(valor % 100);
           else if (valor == 1000) Num2Text = "MIL";
           else if (valor < 2000) Num2Text = "MIL " + PasarATexto(valor % 1000);
           else if (valor < 1000000)
           {
               Num2Text = PasarATexto(Math.floor(valor / 1000)) + " MIL";
               if ((valor % 1000) > 0) Num2Text = Num2Text + " " + PasarATexto(valor % 1000);
           }
           else if (valor == 1000000) Num2Text = "UN MILLON";
           else if (valor < 2000000) Num2Text = "UN MILLON " + PasarATexto(valor % 1000000);
           else if (valor < 1000000000000)
           {
               Num2Text = PasarATexto(Math.floor(valor / 1000000)) + " MILLONES ";
               if ((valor - Math.floor(valor / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + PasarATexto(valor - Math.floor(valor / 1000000) * 1000000);
           }
           else if (valor == 1000000000000) Num2Text = "UN BILLON";
           else if (valor < 2000000000000) Num2Text = "UN BILLON " + PasarATexto(valor - Math.floor(valor / 1000000000000) * 1000000000000);
           else
           {
               Num2Text = PasarATexto(Math.floor(valor / 1000000000000)) + " BILLONES";
               if ((valor - Math.floor(valor / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + PasarATexto(valor - Math.floor(valor / 1000000000000) * 1000000000000);
           }

           return Num2Text;
       }

       
    </script>
    <style type="text/css">
        .style4
        {
            width: 99px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true" >
   </asp:ScriptManager>
       
    <table style="width: 100%;" border="0">
        <tr>
            <td align="left" valign="top">
                <br />
                <asp:Label ID="lblTituloPrincipal" runat="server" CssClass="LabelTitulo">Facturación</asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server">Crear</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButton2" runat="server">Búsqueda</asp:LinkButton>
                <br />
                <asp:LinkButton ID="LinkButton3" runat="server" Visible="False">Búsqueda Clientes</asp:LinkButton>
                <br />
                <asp:Panel ID="Panel1" runat="server" Width="60%">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td align="left" valign="top" style="height: 30px">
                                        <asp:Label ID="lblTituloD" runat="server" CssClass="LabelTitulo15"></asp:Label>
                                        <asp:HiddenField ID="hfdPopUp" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:Panel ID="pnlEncabezado" runat="server" CssClass="LabelTituloNormal" 
                                        GroupingText="Encabezado de la Factura">
                                            <asp:Panel ID="pnlNumeroSistema" runat="server" Visible="False">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td align="left" valign="top" class="style4">
                                                            <asp:Label ID="lblNSEF" runat="server" CssClass="LabelTituloNormal" 
                                                                Text="Factura Número"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumeroSistema" runat="server" 
                                                            CssClass="LabelNormal"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                                                                          
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblTipopD" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Tipo de Factura"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:DropDownList ID="ddlTipoFac" runat="server" AppendDataBoundItems="True" 
                                                            AutoPostBack="True" CssClass="LabelNormal" Width="450px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblTerD" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Cliente"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:TextBox ID="txtcliente" runat="server" Height="20px" Width="450px"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ID="txtcliente_AutoCompleteExtender" runat="server" 
                                                            completioninterval="200" completionsetcount="10" enablecaching="true" 
                                                            enabled="True" minimumprefixlength="2" servicemethod="ObtListaClientes" 
                                                            servicepath="~/autocompletar.asmx" targetcontrolid="txtcliente" 
                                                            usecontextkey="True">
                                                        </cc1:AutoCompleteExtender>
                                                        <asp:RequiredFieldValidator ID="rfvIdTerceroD" runat="server" 
                                                            ControlToValidate="txtcliente" CssClass="Validador" Display="Dynamic" 
                                                            ErrorMessage="Requerido" InitialValue="0" SetFocusOnError="True" 
                                                            ValidationGroup="valida"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblProveedores" runat="server" Text="Proveedores"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:DropDownList ID="ddlProveedores" runat="server" 
                                                            AppendDataBoundItems="True" CssClass="LabelNormal" Width="450px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblFecD" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Fecha de Emisión"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:TextBox ID="txtFechaHoraCreacionD" runat="server" CssClass="LabelNormal" 
                                                            ReadOnly="True" ValidationGroup="valida" Width="445px" 
                                                            ToolTip="Esta fecha no se puede modificar"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblFevD" runat="server" CssClass="LabelTituloNormal" 
                                                        Text="Fecha de Vencimiento"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:TextBox ID="txtFechaHoraVencimientoD" runat="server" 
                                                        CssClass="LabelNormal" ReadOnly="True" ValidationGroup="valida" 
                                                        Width="420px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtFechaHoraVencimientoD_CalendarExtender" 
                                                        runat="server" Enabled="True" PopupButtonID="btnCalendarD" 
                                                        PopupPosition="Right" TargetControlID="txtFechaHoraVencimientoD">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="btnCalendarD" runat="server" 
                                                        ImageUrl="../Imagenes/imgCalendar.gif" 
                                                        ToolTip="Clic para seleccionar la Fecha de Vencimiento." />
                                                        <asp:RequiredFieldValidator ID="rfvFechaCreacionD" runat="server" 
                                                        ControlToValidate="txtFechaHoraCreacionD" CssClass="Validador" 
                                                        Display="Dynamic" ErrorMessage="Requerido" SetFocusOnError="True" 
                                                        ValidationGroup="valida"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator ID="cvrFechaVencimiento" runat="server" 
                                                        ClientValidationFunction="ValidaFechaVencimiento" 
                                                        ControlToValidate="txtFechaHoraVencimientoD" CssClass="Validador" 
                                                        Display="Dynamic" ErrorMessage="Fecha Inválida" SetFocusOnError="True" 
                                                        ValidateEmptyText="True" ValidationGroup="valida"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblBodega" runat="server" Text="Bodega"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:DropDownList ID="ddlBodega" runat="server" AppendDataBoundItems="True" 
                                                        CssClass="LabelNormal" Width="450px" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblObserD" runat="server" CssClass="LabelTituloNormal" 
                                                        Text="Observación"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:TextBox ID="txtObservacionD" runat="server" CssClass="LabelNormal" 
                                                        MaxLength="200" Rows="4" TextMode="MultiLine" Width="450px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="147">
                                                        <asp:Label ID="lblActivoD" runat="server" CssClass="LabelTituloNormal" 
                                                        Text="Activo" Visible="False"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:CheckBox ID="cbxSwActivoD" runat="server" CssClass="LabelNormal" 
                                                        ToolTip="Clic para seleccionar" Visible="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                        
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="left" height="40" valign="middle" width="110">
                                                        <asp:ImageButton ID="btnModificarD" runat="server" 
                                                        ImageUrl="../Imagenes/btnModificar.png" onclick="btnModificarD_Click" 
                                                        ToolTip="Clic para Modificar el Encabezado de la Factura." 
                                                        ValidationGroup="validam" />
                                                    </td>
                                                    <td align="left" height="35" valign="middle" width="110">
                                                        <asp:ImageButton ID="btnRegresarD" runat="server" 
                                                        ImageUrl="../Imagenes/btnCancelar.png" onclick="btnRegresarD_Click" 
                                                        ToolTip="Clic para Regresar a la creación de las Facturas." />
                                                    </td>
                                                    <td align="left" height="35" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="3" height="40" valign="middle">
                                                        <asp:Label ID="lblMensajeBodega" runat="server" ForeColor="Red" 
                                                            Text="La bodega no tiene existencias." Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:Panel ID="pnlDetalle" runat="server" CssClass="LabelTituloNormal" 
                                        GroupingText="Detalle de la Factura">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="center" valign="top">
                                                        <asp:GridView ID="gvwDetalle" runat="server" AllowPaging="True" 
                                                        AutoGenerateColumns="False" 
                                                        DataKeyNames="registro_det_fac,SwActivo" 
                                                        HorizontalAlign="Center" onpageindexchanging="gvwDetalle_PageIndexChanging" 
                                                        onrowcommand="gvwDetalle_RowCommand" onrowdatabound="gvwDetalle_RowDataBound" 
                                                        PageSize="15" SkinID="SkinGridView" Width="98%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Eliminar">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="IbnEliminar" runat="server" 
                                                                        CommandArgument='<%# DataBinder.Eval(Container, "DataItem.registro_det_fac")  %>' 
                                                                        CommandName="Eliminar" ImageUrl="../Imagenes/eliminar.gif" 
                                                                        onclientclick="return confirm('¿Esta Seguro de Desactivar el Detalle de la Factura?');" 
                                                                        ToolTip="Clic para Desactivar el Detalle de la Factura." />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                                                </asp:TemplateField>                                                                
                                                                <asp:TemplateField HeaderText="Detalle">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdDetalle" runat="server" CssClass="LabelNormalConCursor" 
                                                                        Height="100%" Text='<%# DataBinder.Eval(Container, "DataItem.registro_det_fac") %>' 
                                                                        Width="100%"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Concepto" HeaderText="Concepto">
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="34%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ValorUnitario" HeaderText="Precio Unitario">
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="34%" />
                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="16%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Bruto" HeaderText="Valor">
                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="16%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SwActivo" HeaderText="Activo" Visible="False">
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:Image ID="imgAlertM" runat="server" ImageUrl="../Imagenes/Alert2.png" 
                                                        Visible="False" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:Panel ID="pnlNuevoDet" runat="server">
                                                            <asp:UpdatePanel ID="uplConcepto" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <table style="width:100%;">
                                                                        <tr>
                                                                            <td align="left" valign="top" width="147">
                                                                                <asp:Label ID="lblConDt" runat="server" CssClass="LabelTituloNormal" 
                                                                                Text="Concepto"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlIdConceptoDt" runat="server" 
                                                                                AppendDataBoundItems="True" AutoPostBack="True" CssClass="LabelNormal" 
                                                                                onselectedindexchanged="ddlIdConceptoDt_SelectedIndexChanged" 
                                                                                ValidationGroup="valida2" Width="450px">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvIdConceptoDt" runat="server" 
                                                                                ControlToValidate="ddlIdConceptoDt" CssClass="Validador" Display="Dynamic" 
                                                                                ErrorMessage="Requerido" InitialValue="0" SetFocusOnError="True" 
                                                                                ValidationGroup="valida2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top" width="147">
                                                                                <asp:Label ID="lblCanDt" runat="server" CssClass="LabelTituloNormal" 
                                                                                Text="Cantidad"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:TextBox ID="txtCantidadDt" runat="server" CssClass="LabelNormalNumero" 
                                                                                ValidationGroup="valida2" Width="445px"></asp:TextBox>
                                                                                <asp:CustomValidator ID="cvrCantidadDt" runat="server" 
                                                                                ClientValidationFunction="validaCantidad" ControlToValidate="txtCantidadDt" 
                                                                                CssClass="Validador" Display="Dynamic" ErrorMessage="Requerido" 
                                                                                SetFocusOnError="True" ValidateEmptyText="True" ValidationGroup="valida2"></asp:CustomValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top" width="147">
                                                                                <asp:Label ID="lblValUDt" runat="server" CssClass="LabelTituloNormal" 
                                                                                Text="Valor Unitario"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:TextBox ID="txtValorUnitarioDt" runat="server" 
                                                                                CssClass="LabelNormalNumero" ValidationGroup="valida2" Width="445px"></asp:TextBox>
                                                                                <asp:CustomValidator ID="cvrValorUnitario" runat="server" 
                                                                                ClientValidationFunction="validaCantidad" 
                                                                                ControlToValidate="txtValorUnitarioDt" CssClass="Validador" Display="Dynamic" 
                                                                                ErrorMessage="Requerido" SetFocusOnError="True" ValidateEmptyText="True" 
                                                                                ValidationGroup="valida2"></asp:CustomValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top" width="147">
                                                                                <asp:Label ID="lblValBDt" runat="server" CssClass="LabelTituloNormal" 
                                                                                Text="Valor Bruto"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:TextBox ID="txtBrutoDt" runat="server" CssClass="LabelNormalNumero" 
                                                                                ReadOnly="True" ValidationGroup="valida2" Width="445px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top" width="147">
                                                                                <asp:Label ID="lblIvDt" runat="server" CssClass="LabelTituloNormal" 
                                                                                Text="Valor Iva"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:TextBox ID="txtIvaDt" runat="server" CssClass="LabelNormalNumero" 
                                                                                ReadOnly="True" ValidationGroup="valida2" Width="445px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top" width="147">
                                                                                <asp:Label ID="lblValNDt" runat="server" CssClass="LabelTituloNormal" 
                                                                                Text="Valor Neto"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:TextBox ID="txtNetoDt" runat="server" CssClass="LabelNormalNumeroAzul" 
                                                                                ReadOnly="True" ValidationGroup="valida2" Width="445px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <table style="width:100%;">
                                                                <tr>
                                                                    <td align="left" height="30" valign="top" width="147">
                                                                        <asp:Label ID="lblActivoDt" runat="server" CssClass="LabelTituloNormal" 
                                                                        Text="Activo" Visible="False"></asp:Label>
                                                                    </td>
                                                                    <td align="left" height="30" valign="top">
                                                                        <asp:CheckBox ID="cbxSwActivoDt" runat="server" CssClass="LabelNormal" 
                                                                        ToolTip="Clic para seleccionar" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <table style="width:100%;">
                                                            <tr>
                                                                <td align="left" height="20" valign="middle" width="110">
                                                                    <asp:ImageButton ID="btnAgregarDt" runat="server" 
                                                                    ImageUrl="../Imagenes/btnAgregar.png" onclick="btnAgregarDt_Click" 
                                                                    ToolTip="Clic para Agregar el Detalle de la Factura." 
                                                                    ValidationGroup="valida2" />
                                                                    <asp:ImageButton ID="btnModificarDt" runat="server" 
                                                                    ImageUrl="../Imagenes/btnModificar.png" onclick="btnModificarDt_Click" 
                                                                    ToolTip="Clic para Modificar el Detalle de la Factura." 
                                                                    ValidationGroup="valida2" />
                                                                </td>
                                                                <td align="left" height="20" valign="middle" width="110">
                                                                    <asp:ImageButton ID="btnCancelarDt" runat="server" 
                                                                    ImageUrl="../Imagenes/btnLimpiar.png" onclick="btnCancelarDt_Click" 
                                                                    
                                                                    
                                                                    
                                                                    
                                                                        ToolTip="Clic para Cancelar la Creación o Edición del Detalle de la Factura." />
                                                                </td>
                                                                <td align="left" height="20" valign="middle">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:Panel ID="pnlPie" runat="server" 
                                        GroupingText="Pie de la Factura" CssClass="LabelTituloNormal">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="left" valign="top" width="18%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="26%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="1%">
                                                        </td>
                                                    <td align="left" valign="top" width="28%">
                                                        &nbsp;<asp:Label ID="lblToVBPF0" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Valor Bruto "></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top" width="26%">
                                                        <asp:TextBox ID="txtTotalValorBrutoPF" runat="server" 
                                                            CssClass="LabelNormalNumero" ReadOnly="True" ValidationGroup="valida2" 
                                                            Width="98%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="18%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="26%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="28%">
                                                        <asp:Label ID="lblToIPF0" runat="server" CssClass="LabelTituloNormal" 
                                                        Text="Total Iva"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top" width="26%">
                                                        <asp:TextBox ID="txtTotalIvaPF" runat="server" 
                                                        CssClass="LabelNormalNumero" ValidationGroup="valida2" Width="98%" 
                                                        ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="18%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="26%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="28%">
                                                        <asp:Label ID="lblToVBPF2" runat="server" CssClass="LabelTituloNormal" 
                                                        Text="Valor Bruto con Iva"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top" width="26%">
                                                        <asp:TextBox ID="txtValorBrutoconIvaPF" runat="server" CssClass="LabelNormalNumero" 
                                                        ReadOnly="True" ValidationGroup="valida2" Width="98%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="18%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="26%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="28%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="26%">
                                                        &nbsp;</td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="18%">
                                                        <asp:Label ID="lblValLet" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Valor en Letras"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top" width="26%">
                                                        </td>
                                                    <td align="left" valign="top" width="1%">
                                                        </td>
                                                    <td align="left" valign="top" width="28%">
                                                        <asp:Label ID="lblValNPF" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Total Valor Neto"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="top" width="26%">
                                                        <asp:TextBox ID="txtTotalValorNetoPF" runat="server" 
                                                            CssClass="LabelNormalNumeroAzul" ReadOnly="True" ValidationGroup="valida2" 
                                                            Width="98%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" width="1%">
                                                        </td>
                                                </tr>
                                            </table>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="right" valign="top" width="99%">
                                                        <asp:TextBox ID="txtValorEnLetrasPF" runat="server" 
                                                        CssClass="LabelValorLetrasAzul" ReadOnly="True" Width="99%"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" width="1%">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="left" height="35" valign="middle" width="130">
                                                        <asp:ImageButton ID="btnCerrarD" runat="server" 
                                                        ImageUrl="../Imagenes/btnCerrar.png" onclick="btnCerrarD_Click" 
                                                        ToolTip="Clic para Cerrar la Factura de Venta." Visible="False" />
                                                    </td>
                                                    <td align="left" height="35" valign="middle" width="110">
                                                        <asp:ImageButton ID="btnReporte" runat="server" 
                                                        ImageUrl="../Imagenes/btnImprimir.png" onclick="btnReporte_Click" 
                                                        ToolTip="Clic para Ver la Factura." ValidationGroup="consultar" 
                                                        Visible="false" />
                                                    </td>
                                                    <td align="left" height="35" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:ImageButton ID="btnRegresar" runat="server" 
                        ImageUrl="~/imagenes/regresar.jpg" />
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Width="60%">
                           <table border="0" cellpadding="1" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td width="15">
                                        <asp:Image ID="imgFlecha" runat="server" ImageUrl="../Imagenes/arrow.gif" 
                                Height="12px" Width="13px" />
                                    </td>
                                    <td style="text-align: justify">
                                        <asp:Label ID="lbl1" runat="server" CssClass="LabelPequeno" 
                                                    ForeColor="SteelBlue"  Text="Seleccione sus opciones de búsqueda y/o digite su búsqueda en la caja de texto y haga clic en el botón Buscar."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="width:100%;">
                                <tr>
                                    <td align="left" valign="top" width="140">
                                        <asp:Label ID="lblTb" runat="server" Text="Cliente" 
                                        CssClass="LabelTituloNormal"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 372px" valign="top">
                                                   <table border="0" cellpadding="0" cellspacing="0" style="width: 371px;">
                                                    <tr>
                                                        <td align="left" valign="top" width="351">
                                                          <asp:TextBox ID="txtclienteb" runat="server" Width="350px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                                                             runat="server" enabled="True" servicepath="~/autocompletar.asmx" 
                                                             minimumprefixlength="2" servicemethod="ObtListaClientes"
                                                             enablecaching="true" targetcontrolid="txtclienteb" 
                                                             usecontextkey="True" completionsetcount="10"
                                                             completioninterval="200" >
                                                            </cc1:AutoCompleteExtender> </td>
                                                        <td align="center" valign="top" width="20">
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                    </td>
                                    <td align="left" valign="top" width="110">
                                        &nbsp;</td>
                                    <td align="left" valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="140">
                                        <asp:Label ID="lblEb" runat="server" Text="Estado" 
                                        CssClass="LabelTituloNormal"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 372px" valign="top">
                                        <asp:DropDownList ID="ddlEstadoBD" runat="server" 
                                        AppendDataBoundItems="True" 
                                        Width="350px" CssClass="LabelNormal">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" valign="top" width="110">
                                        &nbsp;</td>
                                    <td align="left" valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="140">
                                        <asp:Label ID="lblFecB" runat="server" Text="Fecha" 
                                        CssClass="LabelTituloNormal"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 372px" valign="top">
                                        <asp:TextBox ID="txtFechaBD" runat="server" CssClass="LabelNormal" 
                                        Width="320px" ReadOnly="True">Todos</asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        TargetControlID="txtFechaBD"  PopupButtonID="btnCalendarBD"  
                                        PopupPosition="Right">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="btnCalendarBD" runat="server" 
                                        ImageUrl="../Imagenes/imgCalendar.gif" 
                                        ToolTip="Clic para seleccionar la Fecha de Búsqueda." />
                                    </td>
                                    <td align="left" valign="top" width="110">
                                        &nbsp;</td>
                                    <td align="left" valign="top">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" valign="top" width="510">
                                        <asp:UpdatePanel ID="uplBusquedaD" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td align="left" valign="top" width="140">
                                                            <asp:Label ID="lblOb" runat="server" Text="Opción de Búsqueda" 
                                        CssClass="LabelTituloNormal"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 360px" valign="top">
                                                            <asp:DropDownList ID="ddlOpcionBusquedaBD" runat="server" 
                                        AppendDataBoundItems="True" 
                                        Width="350px" CssClass="LabelNormal" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlOpcionBusquedaBD_SelectedIndexChanged" 
                                                                Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 145px" valign="top" width="140">
                                                            <asp:Label ID="lblBus" runat="server" Text="Búsqueda" 
                                        CssClass="LabelTituloNormal"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 360px" valign="top">
                                                            <asp:TextBox ID="txtBuscarBD" runat="server" MaxLength="200" 
                                        ValidationGroup="busca" Width="344px" CssClass="LabelNormal"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td align="left" valign="bottom">
                                        <table style="width:100%;">
                                            <tr>
                                                <td align="center" valign="top" width="100">
                                                    &nbsp;</td>
                                                <td align="left" valign="top">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="bottom" width="100">
                                                    <asp:ImageButton ID="btnBuscarD" runat="server" 
                                        ImageUrl="../Imagenes/btnBuscar.png" 
                                        ToolTip="Clic para Buscar las Facturas." onclick="btnBuscarD_Click" />
                                                </td>
                                                <td align="left" valign="bottom">
                                                    <asp:LinkButton ID="lbnVerTodosD" runat="server" CssClass="LinkAtenuado" 
                                Font-Underline="False" 
                                ToolTip="Clic para ver todos los Documentos." onclick="lbnVerTodosD_Click" 
                                        Visible="False">Ver Todos</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td valign="top" align="left">
                                      
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <asp:GridView ID="gvwDocumentos" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" DataKeyNames="registro,fecha_ven_fac,observaciones,tipo_fac" 
                                HorizontalAlign="Center" 
                                SkinID="SkinGridView" Width="98%" 
                    onpageindexchanging="gvwDocumentos_PageIndexChanging" 
                    onrowcommand="gvwDocumentos_RowCommand" 
                    onrowdatabound="gvwDocumentos_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="registro" 
                                        HeaderText="IdDocumento" Visible="False" />
                                                <asp:TemplateField HeaderText="Documentos">
                                                    <ItemTemplate>
                                                        <asp:Panel ID="pnlContenedor" runat="server">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td align="left" valign="top" width="107">
                                                                        <asp:Label ID="lblFeccg" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Factura Número"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblNumeroSistema" runat="server" CssClass="LabelNormal" 
                                                                Text='<%# DataBinder.Eval(Container, "DataItem.registro") %>'></asp:Label>
                                                                        &nbsp;<asp:Label ID="lblFeccg0" runat="server" CssClass="LabelTituloNormal" 
                                                                Text="del"></asp:Label>
                                                                        &nbsp;<asp:Label ID="lblFechaHoraCreacion" runat="server" CssClass="LabelNormal" 
                                                            
                                                                Text='<%# String.Format("{0:D}", DataBinder.Eval(Container, "DataItem.fecha_fac")) %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="107">
                                                                        <asp:Label ID="lblTerg" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Cliente:"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTercero" runat="server" CssClass="LabelNormal" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.cliente") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="107">
                                                                        <asp:Label ID="lblSwCg" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Cerrado:"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSwCerrado" runat="server" CssClass="LabelNormal" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.SwCerrado") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="107">
                                                                        <asp:Label ID="lblValnD" runat="server" CssClass="LabelTituloNormal" 
                                                            Text="Valor Factura:"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblTotalValorNeto" runat="server" CssClass="LabelNormal" 
                                                            Text='<%# DataBinder.Eval(Container, "DataItem.valor_total_fac") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IbnAgregar" runat="server" 
                                                CommandArgument='<%# DataBinder.Eval(Container, "DataItem.registro") & "-" & DataBinder.Eval(Container, "DataItem.tipo_fac")%>' 
                                                CommandName="Ver" ImageUrl="../Imagenes/nuevo.png" 
                                                ToolTip="Clic para ver la Factura." Width="30" Height="30" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IbnEditar" runat="server" 
                                                CommandArgument='<%# DataBinder.Eval(Container, "DataItem.registro") & "-" & DataBinder.Eval(Container, "DataItem.tipo_fac") %>' 
                                                CommandName="Editar" ImageUrl="../Imagenes/editar.gif" 
                                                ToolTip="Clic paraModificar la Factura de Venta." />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="IbnEliminar" runat="server" 
                                                CommandArgument='<%# DataBinder.Eval(Container, "DataItem.registro") & "-" & DataBinder.Eval(Container, "DataItem.tipo_fac") %>' 
                                                CommandName="Eliminar" ImageUrl="../Imagenes/eliminar.gif" 
                                                onclientclick="return confirm('¿Está Seguro de Desactivar la Factura?');" 
                                                ToolTip="Clic para Desactivar la Factura de Venta." />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Image ID="imgAlertD" runat="server" 
                                Visible="False" />
                                        <br />
                                    </td>
                                </tr>
                            </table>   
                   <asp:ImageButton ID="btnRegresar1" runat="server" ImageUrl="~/imagenes/regresar.jpg" />         
                          
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Width="60%">
                            <table style="width:100%;">
                                <tr>
                                    <td align="left" valign="top" width="140">
                                        <asp:Label ID="lblTb0" runat="server" Text="Cliente" 
                                        CssClass="LabelTituloNormal"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 372px" valign="top">
                                                   <table border="0" cellpadding="0" cellspacing="0" style="width: 371px;">
                                                    <tr>
                                                        <td align="left" valign="top" width="351">
                                                          <asp:TextBox ID="txtclientereporte" runat="server" Width="350px"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" 
                                                             runat="server" enabled="True" servicepath="~/autocompletar.asmx" 
                                                             minimumprefixlength="2" servicemethod="ObtListaClientes"
                                                             enablecaching="true" targetcontrolid="txtclientereporte" 
                                                             usecontextkey="True" completionsetcount="10"
                                                             completioninterval="200" >
                                                            </cc1:AutoCompleteExtender> </td>
                                                        <td align="center" valign="top" width="20">
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                    </td>
                                    <td align="left" valign="top" width="110">
                                        <asp:ImageButton ID="btnBuscarReporte" runat="server" 
                                            ImageUrl="../Imagenes/btnBuscar.png" ToolTip="Clic para Buscar las Facturas." />
                                    </td>
                                    <td align="left" valign="top">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td valign="top" align="left">
                                       <asp:GridView ID="gvwFacturas" runat="server" AllowPaging="True" 
                               AutoGenerateColumns="False" 
                               DataKeyNames="registro,fecha_ven_fac,observaciones,SwCerrado,tipo_fac" 
                               HorizontalAlign="Center" SkinID="SkinGridView" Width="98%">
                               <Columns>
                                   <asp:BoundField DataField="registro" HeaderText="IdDocumento" Visible="False" />
                                   <asp:TemplateField HeaderText="Facturas">
                                       <ItemTemplate>
                                           <asp:Panel ID="pnlContenedor0" runat="server">
                                               <table style="width: 100%;">
                                                   <tr>
                                                       <td align="left" valign="top" width="107">
                                                           <asp:Label ID="lblFeccg1" runat="server" CssClass="LabelTituloNormal" 
                                                               Text="Factura Número"></asp:Label>
                                                       </td>
                                                       <td align="left" valign="top">
                                                           <asp:Label ID="lblNumeroSistema0" runat="server" CssClass="LabelNormal" 
                                                               Text='<%# DataBinder.Eval(Container, "DataItem.registro") %>'></asp:Label>
                                                           &nbsp;<asp:Label ID="lblFeccg2" runat="server" CssClass="LabelTituloNormal" 
                                                               Text="del"></asp:Label>
                                                           &nbsp;<asp:Label ID="lblFechaHoraCreacion0" runat="server" CssClass="LabelNormal" 
                                                               Text='<%# String.Format("{0:D}", DataBinder.Eval(Container, "DataItem.fecha_fac")) %>'></asp:Label>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td align="left" valign="top" width="107">
                                                           <asp:Label ID="lblSwCg0" runat="server" CssClass="LabelTituloNormal" 
                                                               Text="Cerrado:"></asp:Label>
                                                       </td>
                                                       <td align="left" valign="top">
                                                           <asp:Label ID="lblSwCerrado0" runat="server" CssClass="LabelNormal" 
                                                               Text='<%# DataBinder.Eval(Container, "DataItem.SwCerrado") %>'></asp:Label>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td align="left" valign="top" width="107">
                                                           <asp:Label ID="lblValnD0" runat="server" CssClass="LabelTituloNormal" 
                                                               Text="Valor Factura:"></asp:Label>
                                                       </td>
                                                       <td align="left" valign="top">
                                                           <asp:Label ID="lblTotalValorNeto0" runat="server" CssClass="LabelNormal" 
                                                               Text='<%# DataBinder.Eval(Container, "DataItem.valor_total_fac") %>'></asp:Label>
                                                       </td>
                                                   </tr>
                                               </table>
                                           </asp:Panel>
                                       </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Ver">
                                       <ItemTemplate>
                                           <asp:ImageButton ID="IbnAgregar0" runat="server" 
                                               CommandArgument='<%# DataBinder.Eval(Container, "DataItem.registro") &"-"& DataBinder.Eval(Container, "DataItem.tipo_fac")%>' 
                                               CommandName="Ver" Height="30" ImageUrl="../Imagenes/nuevo.png" 
                                               ToolTip="Clic para ver la Factura." Width="30" />
                                       </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
                                   </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center">
                                        <asp:Image ID="imgAlertD0" runat="server" 
                                Visible="False" />
                                        <br />
                                    </td>
                                </tr>
                            </table>   
                   <asp:ImageButton ID="btnRegresar2" runat="server" ImageUrl="~/imagenes/regresar.jpg" />         
                </asp:Panel>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top"></td>
       </tr>
    </table>
                

</asp:Content>

