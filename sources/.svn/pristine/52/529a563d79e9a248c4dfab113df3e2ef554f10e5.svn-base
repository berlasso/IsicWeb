<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Inherits="MPBA.AutoresIgnorados.Web.CargaBienesSustraidos" CodeBehind="CargaBienesSustraidos.aspx.cs"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="System.Web.Ajax" Namespace="System.Web.UI" TagPrefix="asp" %>
--%><asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style28
        {
            width: 100%;
            table-layout: auto;
        }
        .style48
        {
            width: 152px;
            height: 26px;
        }
        .style49
        {
            margin-left: 0px;
        }
        .style50
        {
            width: 143px;
            height: 26px;
        }
        .style51
        {
            height: 26px;
        }
        .style52
        {
            height: 176px;
        }
        .style53
        {
            width:100%;
            border-top-style: solid;
        }
        .style60
        {
            height: 4px;
            width: 152px;
            text-align: left;
        }
        .style64
        {
            text-align: left;
            width: 96px;
        }
    </style>
    <%--<link href="App_Css/styles.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <div>
     
        <div style="border-style: groove; border-color: #13507d;" class="FondoAutoresIgnorados">
        <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelPrincipal" runat="server" align="center">
                    AUTORES DESCONOCIDOS</h3>
         </div>
        <asp:Image ID="imgCartelVictimas" runat="server" 
            ImageUrl="~/App_Images/cartelBsSust.png" Height="50px" Width="858px" />
            <table style="width:100%">
                <tr>
                  <td style="border-width: thin; border-bottom-style: solid; text-align: left; width: auto;">
                    <asp:Label ID="lblCondicionCarga" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td colspan="4" 
                        style="border-width: thin; border-bottom-style: solid;  text-align: center;">
                       <%-- <asp:Label ID="lblBienesSustraidos" runat="server" Font-Bold="True" Font-Size="Large"
                            Text="Bienes Sustraídos"></asp:Label>--%>
                    </td>
                </tr>
                </table>
                  <asp:Panel ID="pnlBienesSustraidos" runat="server">
                <table class="style28">
                <tr>
                    <td colspan="4">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvBienesSustraidos" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="id"
                                    CssClass="Grid" onrowdeleting="gvBienesSustraidos_RowDeleting" 
                                    onselectedindexchanged="gvBienesSustraidos_SelectedIndexChanged" 
                                    CellSpacing="-1" 
                                    onrowdatabound="gvBienesSustraidos_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                                                    CommandName="Select" Text="Editar" UseSubmitBehavior="False" />
                                                &nbsp;<asp:Button ID="btnBorrar" runat="server" CausesValidation="False" 
                                                    CommandName="Delete" Text="Borrar" />
                                                <asp:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                                                    ConfirmText="Desea borrar?" Enabled="True" TargetControlID="btnBorrar">
                                                </asp:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bien Sustraido" SortExpression="idClaseBienSustraido">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" 
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseBienSustraidoManager.GetItem(Convert.ToInt32(Eval("idClaseBienSustraido").ToString())).descripcion %>' 
                                                    Font-Bold="True"></asp:Label>
                                                                     <asp:GridView ID="gvBSOtros" runat="server" 
                                                    AutoGenerateColumns="False" DataKeyNames="id">
                                                                         <Columns>
                                                                             <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                                                             <asp:BoundField DataField="NroSerie" HeaderText="Nro. Serie" 
                                                                                 SortExpression="NroSerie" />
                                                                             <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
                                                                                 SortExpression="Cantidad" />
                                                                         </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvBSAnimales" runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="id">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Tipo" SortExpression="IdClaseGanado">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdClaseGanado") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseGanadoManager.GetItem(Convert.ToInt32(Eval("idClaseGanado").ToString().ToLower())).descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" 
                                                            SortExpression="Cantidad" />
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvBSVehiculos" runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="id">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Marca" SortExpression="idMarcaVehiculo">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idMarcaVehiculo") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%# MPBA.SIAC.Bll.MarcaVehiculoManager.GetItem(Convert.ToInt32(Eval("idMarcaVehiculo").ToString().ToLower())).Descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Modelo" SortExpression="idModeloVehiculo">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" 
                                                                    Text='<%# Bind("idModeloVehiculo") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" 
                                                                    Text='<%# MPBA.SIAC.Bll.ModeloVehiculoManager.GetItem(Convert.ToInt32(Eval("idModeloVehiculo").ToString().ToLower())).Descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Dominio" HeaderText="Patente" 
                                                            SortExpression="Dominio" />
                                                        <asp:BoundField DataField="NumeroChasis" HeaderText="Chasis" 
                                                            SortExpression="NumeroChasis" />
                                                        <asp:BoundField DataField="NumeroMotor" HeaderText="Motor" 
                                                            SortExpression="NumeroMotor" />
                                                        <asp:TemplateField HeaderText="Color" SortExpression="idColorVehiculo">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idColorVehiculo") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" 
                                                                    Text='<%# MPBA.SIAC.Bll.ColorVehiculoManager.GetItem(Convert.ToInt32(Eval("idColorVehiculo").ToString().ToLower())).Descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="anio" HeaderText="Año" SortExpression="anio" />
                                                        <asp:TemplateField HeaderText="Vidrios" SortExpression="idClaseVidrioVehiculo">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox4" runat="server" 
                                                                    Text='<%# Bind("idClaseVidrioVehiculo") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" 
                                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager.GetItem(Convert.ToInt32(Eval("idClaseVidrioVehiculo").ToString().ToLower())).descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IdentificacionGNC" HeaderText="Id. GNC" />
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvBSArma" runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="id">
                                                    <Columns>
                                                        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                                        <asp:BoundField DataField="NroSerie" HeaderText="NroSerie" 
                                                            SortExpression="NroSerie" />
                                                        <asp:TemplateField HeaderText="Tipo" SortExpression="clase_tipo">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("clase_tipo") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseTipoArmaFuegoManager.GetItem(Convert.ToInt32(Eval("clase_tipo").ToString().ToLower())).descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Diámetro" SortExpression="diametro_calibre">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("diametro_calibre") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseDiametroArmaFuegoManager.GetItem(Convert.ToInt32(Eval("diametro_calibre").ToString().ToLower())).descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvBSTelefono" runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="id">
                                                    <Columns>
                                                        <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                                        <asp:BoundField DataField="Nro" HeaderText="Nro" 
                                                            SortExpression="Nro" />
                                                            <asp:BoundField DataField="NroSerie" HeaderText="NroSerie" 
                                                            SortExpression="NroSerie" />
                                                            <asp:BoundField DataField="IMEI" HeaderText="IMEI" 
                                                            SortExpression="IMEI" />
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvBSDinero" runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="id">
                                                    <Columns>
                                                        <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="Monto" DataFormatString="{0:######,###}" />
                                                        <asp:TemplateField HeaderText="Tipo Moneda" SortExpression="idTipoMoneda">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idTipoMoneda") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseMonedaManager.GetItem(Convert.ToInt32(Eval("idTipoMoneda").ToString().ToLower())).descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="descripcionMoneda" HeaderText="descripcionMoneda" 
                                                            SortExpression="descripcionMoneda" />
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvBSCheque" runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="id">
                                                    <Columns>
                                                        <asp:BoundField DataField="Monto" HeaderText="Monto" SortExpression="Monto" DataFormatString="{0:######,###}" />
                                                        <asp:BoundField DataField="Banco" HeaderText="Banco" SortExpression="Banco" />
                                                        <asp:BoundField DataField="NroSerie" HeaderText="NroSerie" SortExpression="NroSerie" />
                                                        <asp:TemplateField HeaderText="Tipo Moneda" SortExpression="idTipoMoneda">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idTipoMoneda") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" 
                                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseMonedaManager.GetItem(Convert.ToInt32(Eval("idTipoMoneda").ToString().ToLower())).descripcion %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="descripcionMoneda" HeaderText="descripcionMoneda" 
                                                            SortExpression="descripcionMoneda" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
        
        
                   </td>
                </tr>
                <tr>
                    <td align="justify" class="style48">
                        <asp:Label ID="lblMontoEstimadoBienes" runat="server" Text="Monto Total Estimado"></asp:Label>
                    </td>
                    <td align="right" class="style50">
                        <asp:TextBox ID="txtMontoEstimadoBienes" runat="server" CssClass="style49" Width="152px"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtMontoEstimadoBienes_MaskedEditExtender" 
                            runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            ErrorTooltipEnabled="True" Mask="999999,999" MaskType="Number" 
                            TargetControlID="txtMontoEstimadoBienes" InputDirection="RightToLeft">
                        </asp:MaskedEditExtender>
                    </td>
                    <td align="justify" class="style51">
                        <asp:MaskedEditValidator ID="mevMonto" runat="server" 
                            ControlExtender="txtMontoEstimadoBienes_MaskedEditExtender" 
                            ControlToValidate="txtMontoEstimadoBienes" ErrorMessage="Monto invalido" InitialValue="0" 
                            InvalidValueBlurredMessage="*" InvalidValueMessage="Monto invalido" 
                            MinimumValue="0" MinimumValueMessage="Monto invalido"></asp:MaskedEditValidator>
                    </td>
                    <td align="justify" class="style51">
                    </td>
                </tr>
                <tr>
                <td>
                                <asp:Button ID="btnNuevo" runat="server" Text="Agregar" 
                            onclick="btnNuevo_Click" />
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                </tr>
            </table>
            </asp:Panel>
        </div>
         <asp:UpdatePanel ID="upBotones" runat="server">
        <ContentTemplate>
        <table width="100%">
        <tr>
        <td>
        </td>
          <td class="style52" colspan="3" align="right" style="height: auto" valign="top">
                   <br />
                    <asp:Button ID="btnAnterior" runat="server" Height="26px" Text="&lt;  Anterior" 
                        onclick="btnAnterior_Click" Width="75px" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente  &gt;" 
                        onclick="btnSiguiente_Click" height="26px" width="75px" />
                    <asp:Button ID="btnGuardarDelito" runat="server" Text="Guardar" 
                        OnClick="btnGuardarDelito_Click" Font-Size="Large" Height="34px" 
                        Width="90px" Visible="False" />
                    <asp:ModalPopupExtender ID="btnGuardarDelito_ModalPopupExtender" runat="server" 
                        BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" 
                        DynamicServicePath="" Enabled="False" PopupControlID="pnlGuardoBien" 
                        PopupDragHandleControlID="pnlGuardoBien" 
                        TargetControlID="btnGuardarDelito">
                    </asp:ModalPopupExtender>
                    <asp:ConfirmButtonExtender ID="btnGuardarDelito_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirma la carga?" Enabled="True" 
                        TargetControlID="btnGuardarDelito">
                    </asp:ConfirmButtonExtender>
                    <asp:Button ID="btnCerrar" runat="server" Text="Salir" height="26px" 
                        width="57px" onclick="btnCerrar_Click" />
                    <asp:ConfirmButtonExtender ID="btnCerrar_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Desea cerrar?" Enabled="True" TargetControlID="btnCerrar">
                    </asp:ConfirmButtonExtender>
                </td>
        </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
        <table width="100%">
            <tr>
                <td>
                    <asp:Panel ID="pnlBienSustraido" runat="server" BorderStyle="Outset" Width="250px" 
                        CssClass="FondoModal" Height="340px">
                    <div style="height: 300px; width: 244px">
                    <div id="divHeaderBS" class="ModalHeader">
                        DETALLES DEL BIEN SUSTRAIDO</div>
                    <asp:UpdatePanel ID="upGestionBS" runat="server">
                    <ContentTemplate>
                       <%--<--este panel incluye los valores de cada tipo de bien sustraido!-->--%>
                    <div style="height: 280px; position: relative; overflow: auto;">
                        <asp:Label ID="lblBienSustraido" runat="server" Style="vertical-align: middle" Text="Bien Sustraido"></asp:Label>
                        <asp:DropDownList ID="ddlBienSustraido" runat="server" DataSourceID="odsClaseBS"
                            DataTextField="descripcion" DataValueField="id" Height="23px" Width="98px" 
                            onselectedindexchanged="ddlBienSustraido_SelectedIndexChanged" AutoPostBack="True" 
                            >
                        </asp:DropDownList>
                        <asp:Panel ID="pnlOtroBien" runat="server">
                        <table class="style53">
                        <tr>
                          <td class="style64"><asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label></td>
                          <td class="style60"><asp:TextBox ID="txtMarca" runat="server" Width="114px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID ="lblCantidad" runat="server" Text="Cantidad"></asp:Label></td>                         
                          <td class="style60"><asp:TextBox ID ="txtCantidad" runat="server" width="114px" ></asp:TextBox></td>
                          <asp:MaskedEditExtender ID="txtCantidad_MaskedEditExtender" 
                            runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            ErrorTooltipEnabled="True" Mask="999999" MaskType="Number" 
                            TargetControlID="txtCantidad" InputDirection="RightToLeft">
                        </asp:MaskedEditExtender>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID ="lblNroSerie" runat="server" Text="Nro. de Serie"></asp:Label></td>                         
                          <td class="style60"><asp:TextBox ID ="txtNroSerie" runat="server" width="114px" ></asp:TextBox></td>
                        </tr>   
                        </table>
                        </asp:Panel> 
                        <asp:Panel ID="pnlBienAnimal" runat="server">
                        <table class="style53">
                        <tr>
                          <td class="style64"><asp:Label ID="lblTipoGanado" runat="server" Text="Tipo de Ganado"></asp:Label></td>
                          <td class="style60">
                              <asp:DropDownList ID="ddlTipoGanado" runat="server" DataSourceID="odsClaseGanado" 
                                DataTextField="descripcion" DataValueField="id" width="114px"></asp:DropDownList></td>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID ="lblMarcaGanado" runat="server" Text="Marca"></asp:Label> </td>                        
                          <td class="style60"><asp:TextBox ID ="txtMarcaGanado" runat="server" width="114px" ></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID ="lblCantidadGanado" runat="server" Text="Cantidad"></asp:Label></td>                         
                          <td class="style60"><asp:TextBox ID ="txtCantidadGanado" runat="server" 
                                  width="114px" ></asp:TextBox></td>
                          <asp:MaskedEditExtender ID="txtCantganado_MaskedEditExtender" 
                            runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            ErrorTooltipEnabled="True" Mask="999999" MaskType="Number" 
                            TargetControlID="txtCantidadGanado" InputDirection="RightToLeft">
                          </asp:MaskedEditExtender>  
                        </tr>  
                        </table>  
                        </asp:Panel>
                        <asp:Panel ID="pnlVehiculo" runat="server">
                        <table class="style53">
                        <tr>
                          <td class="style64"><asp:Label ID="lblMarcaVehiculo" runat="server" Text="Marca"></asp:Label></td>
                          <td class="style60">
                              <asp:DropDownList ID="ddlmarcaVehiculo" runat="server" 
                                DataSourceID="odsMarcaVehiculo" DataTextField="Descripcion" 
                                DataValueField="id" AutoPostBack="True" width="114px"></asp:DropDownList></td>
                         </tr>
                         <tr> 
                          <td class="style64"><asp:Label ID="lblModeloVehiculo" runat="server" Text="Modelo"></asp:Label></td>
                          <td class="style60"><asp:DropDownList ID="ddlModeloVehiculo" runat="server" AutoPostBack="True" 
                                DataSourceID="odsModeloVehiculo" DataTextField="Descripcion" 
                                DataValueField="id"></asp:DropDownList></td>
                         </tr>
                         <tr>
                          <td class="style64"><asp:Label ID ="lblDominio" runat="server" Text="Dominio"></asp:Label></td>                         
                          <td class="style60"><asp:TextBox ID ="txtDominio" runat="server" width="69px" ></asp:TextBox>
                          <asp:Label ID="Label5" runat="server" 
                                     Text="Ej: ABC123" Font-Italic="True" Font-Size="X-Small"></asp:Label>
                                     </td>
                         </tr>
                         
                         <%--<tr>
                             <td class="style64">
                             </td>
                             <td class="style64">
                                 <asp:Label ID="Label6" runat="server" 
                                     Text="Ej: ABC123" Font-Italic="True"></asp:Label>
                             </td>
                         <tr>--%>
                            </tr>
                         <tr>
                          <td class="style64"><asp:Label ID ="lblNroChasis" runat="server" 
                                  Text="Nro. de Chasis"></asp:Label></td>                         
                          <td class="style60"><asp:TextBox ID ="txtNroChasis" runat="server" width="114px" ></asp:TextBox></td>
                             <tr>
                                 <td class="style64">
                                     <asp:Label ID="lblNroMotor" runat="server" Text="Nro. de Motor"></asp:Label>
                                 </td>
                                 <td class="style60">
                                     <asp:TextBox ID="txtNroMotor" runat="server" width="114px"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style64">
                                     <asp:Label ID="lblColorVehiculo" runat="server" Text="Color"></asp:Label>
                                 </td>
                                 <td class="style60">
                                     <asp:DropDownList ID="ddlColorVehiculo" runat="server" 
                                         DataSourceID="odsColorVehiculo" DataTextField="Descripcion" DataValueField="id">
                                     </asp:DropDownList>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style64">
                                     <asp:Label ID="lblAnio" runat="server" Text="Año"></asp:Label>
                                 </td>
                                 <td class="style60">
                                     <asp:TextBox ID="txtAnio" runat="server"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style64">
                                     <asp:Label ID="lblGNC" runat="server" Text="Tiene GNC"></asp:Label>
                                 </td>
                                 <td class="style60">
                                     <asp:DropDownList ID="ddlTieneGNC" runat="server" DataSourceID="odsTieneGNC" 
                                         DataTextField="Descripcion" DataValueField="Id">
                                     </asp:DropDownList>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style64">
                                     <asp:Label ID="lblIdentificacionGNC" runat="server" Text="Identificación GNC"></asp:Label>
                                 </td>
                                 <td class="style60">
                                     <asp:TextBox ID="txtIdentificacionGNC" runat="server"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style64">
                                     <asp:Label ID="lblVidrio" runat="server" Text="Vidrios"></asp:Label>
                                 </td>
                                 <td class="style60">
                                     <asp:DropDownList ID="ddlClaseVidrio" runat="server" 
                                         DataSourceID="odsVidriosVehiculo" DataTextField="descripcion" 
                                         DataValueField="id">
                                     </asp:DropDownList>
                                 </td>
                             </tr>
                         </tr>
                        </table>         
                        </asp:Panel>
                        <asp:Panel ID="pnlArma" runat="server">
                        <table class="style53">
                        <tr>
                          <td class="style64"><asp:Label ID="lblMarcaArma" runat="server" Text="Marca"></asp:Label></td>
                          <td class="style60"><asp:TextBox ID="txtMarcaArma" runat="server" Width="114px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID ="lblNroSerieArma" runat="server" Text="Nro. de Serie"></asp:Label></td>                         
                          <td class="style60"><asp:TextBox ID ="txtNroSerieArma" runat="server" width="114px" ></asp:TextBox></td>
                        </tr>   
                       
                        <tr>
                          <td class="style64"><asp:Label ID="lblTipoArma" runat="server" Text="Clase/Tipo"></asp:Label></td>
                          <td class="style60">
                              <asp:DropDownList ID="ddlTipoArmaFuego" runat="server" 
                                DataSourceID="odsTipoArmaFuego" DataTextField="Descripcion" 
                                DataValueField="id" AutoPostBack="True" width="114px"></asp:DropDownList></td>
                         </tr>
                         <tr> 
                             <td class="style64">
                                 <asp:Label ID="lblDiametro" runat="server" Text="Diámetro/Calibre"></asp:Label>
                             </td>
                             <td class="style60">
                                 <asp:DropDownList ID="ddlDiametro" runat="server" AutoPostBack="True" 
                                     DataSourceID="odsDiametroArmaFuego" DataTextField="Descripcion" 
                                     DataValueField="id" width="114px">
                                 </asp:DropDownList>
                             </td>
                          </table>
                        </asp:Panel>
                        <asp:Panel  ID="pnlDinero" runat="server">
                        <table>
                            <tr>
                                <td align="justify" class="style48">
                                    <asp:Label ID="lblMontoSustraido" runat="server" Text="Monto"></asp:Label>
                                </td>
                                <td align="right" class="style50">
                                    <asp:TextBox ID="txtMontoSustraido" runat="server" CssClass="style49" Width="152px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" 
                                        runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        ErrorTooltipEnabled="True" Mask="999999,999" MaskType="Number" 
                                        TargetControlID="txtMontoSustraido" InputDirection="RightToLeft">
                                    </asp:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="style64"><asp:Label ID="lblMoneda" runat="server" Text="Moneda"></asp:Label></td>
                                <td class="style60">
                                    <asp:DropDownList ID="ddlMoneda" runat="server" 
                                    DataSourceID="odsTipoMoneda" DataTextField="Descripcion" 
                                    DataValueField="id" AutoPostBack="True" width="114px"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="style64"><asp:Label ID="lblMonedaExtranjera" runat="server" Text="Tipo de Moneda"></asp:Label></td>
                                <td class="style60"><asp:TextBox ID="txtTipoMonedaExtranjera" runat="server" Width="114px"></asp:TextBox></td>
                            </tr>
                            
                        </table>
                        </asp:Panel>
                        <asp:Panel  ID="pnlCheque" runat="server">
                        <table>
                            <tr>
                                <td align="justify" class="style48">
                                    <asp:Label ID="lblMontoChequeSustraido" runat="server" Text="Monto"></asp:Label>
                                </td>
                                <td align="right" class="style50">
                                    <asp:TextBox ID="txtMontoChequeSustraido" runat="server" CssClass="style49" Width="152px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" 
                                        runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        ErrorTooltipEnabled="True" Mask="999999,999" MaskType="Number" 
                                        TargetControlID="txtMontoChequeSustraido" InputDirection="RightToLeft">
                                    </asp:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="style64"><asp:Label ID="lblMonedaChequeSustraido" runat="server" Text="Moneda"></asp:Label></td>
                                <td class="style60">
                                    <asp:DropDownList ID="ddlMonedaChequeSustraido" runat="server" 
                                    DataSourceID="odsTipoMoneda" DataTextField="Descripcion" 
                                    DataValueField="id" AutoPostBack="True" width="114px"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="style64"><asp:Label ID="lblTipoMonedaExtranjeraCh" runat="server" Text="Tipo de Moneda"></asp:Label></td>
                                <td class="style60"><asp:TextBox ID="txtTipoMonedaExtranjeraCh" runat="server" Width="114px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="style64"><asp:Label ID="lblBanco" runat="server" Text="Banco"></asp:Label></td>
                                <td class="style60"><asp:TextBox ID="txtBanco" runat="server" Width="114px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="style64"><asp:Label ID ="lblNroSerieCheque" runat="server" Text="Nro. de Serie"></asp:Label></td>                         
                                <td class="style60"><asp:TextBox ID ="txtNroSerieCheque" runat="server" width="114px" ></asp:TextBox></td>
                            </tr>   
                        </table>
                        </asp:Panel>
                        <asp:Panel  ID="pnlTelefono" runat="server">
                        <table>
                        <tr>
                          <td class="style64"><asp:Label ID="lblMarcaTel" runat="server" Text="Marca"></asp:Label></td>
                          <td class="style60"><asp:TextBox ID="txtMarcatel" runat="server" Width="114px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID="lblNroTel" runat="server" Text="Número"></asp:Label></td>
                          <td class="style60"><asp:TextBox ID="txtNroTel" runat="server" Width="114px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID="lblNroSerieTel" runat="server" Text="Nro. de Serie"></asp:Label></td>
                          <td class="style60"><asp:TextBox ID="txtNroSerieTel" runat="server" Width="114px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td class="style64"><asp:Label ID="lblIMEI" runat="server" Text="IMEI"></asp:Label></td>
                          <td class="style60"><asp:TextBox ID="txtIMEI" runat="server" Width="114px"></asp:TextBox></td>
                        </tr>
                        </table>
                        </asp:Panel>

                        <br />
                        </div>
                     </ContentTemplate>
                   </asp:UpdatePanel>
                        <div style="padding-top: 10px; position: relative;">
                            <asp:Button ID="btnOkBien" runat="server" OnClick="btnOkBien_Click" Text="Aceptar" 
                                  Width="63px" />
                            <asp:Button ID="btnCancelarBien" runat="server" Text="Cancelar"
                                 CausesValidation="False" onclick="btnCancelarBien_Click" width="63px" />
                         </div>
                          <asp:HiddenField ID="hfGestionBS" runat="server" />
                          <asp:ModalPopupExtender ID="hfGestionBS_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                    DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlBienSustraido"
                                    TargetControlID="hfGestionBS"
                                    CancelControlID="btnCancelarBien" OkControlID="hfGestionBS"
                                    RepositionMode="None" Drag="True" 
                            PopupDragHandleControlID="DivHeaderBS">
                             </asp:ModalPopupExtender>
                        </div>
                       
                   </asp:Panel>
                           <asp:Panel ID="pnlGuardoBien" runat="server" BackColor="White" Width="177px" 
                        BorderColor="#3333CC" BorderStyle="Solid">
                    <table>
                        <tr>
                            <td class="style55" align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" Height="39px" 
                                ImageUrl="~/App_Images/exito.png" Width="35px" />
                        </td>
                            <td align="center">
                                <asp:Label ID="lblCargaExitosa" runat="server" Font-Bold="True" Font-Size="Medium"
                                    Text="Los datos se guardaron exitosamente"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                        <td class="style55"> 
                        </td>
                            <td align="center" class="style55">
                                <asp:Button ID="btnAceptarCartelExito" runat="server" OnClick="btnAceptarCartelExito_Click"
                                    Style="text-align: center" Text="Aceptar" />
                            </td>
                        </tr>
                    </table>
                     </asp:Panel>
                    <asp:ObjectDataSource ID="odsBienesSustraidos" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.BienesSustraidos"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.BienesSustraidosManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsClaseBS" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseBienSustraido"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseBienSustraidoManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsDetalleBienes" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.BienesSustraidos"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetItem" TypeName="MPBA.AutoresIgnorados.Bll.BienesSustraidosManager"
                        UpdateMethod="Save">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="gvBienesSustraidos" Name="id" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsClaseGanado" runat="server" 
                        DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseGanado" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseGanadoManager" UpdateMethod="Save">
                   </asp:ObjectDataSource>
                   <asp:ObjectDataSource ID="odsMarcaVehiculo" runat="server" 
                      DataObjectTypeName="MPBA.SIAC.BusinessEntities.MarcaVehiculo" 
                      DeleteMethod="Delete" InsertMethod="Save" 
                      OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                      TypeName="MPBA.SIAC.Bll.MarcaVehiculoManager" UpdateMethod="Save">
                   </asp:ObjectDataSource>
                   <asp:ObjectDataSource ID="odsModeloVehiculo" runat="server" 
                        DataObjectTypeName="MPBA.SIAC.BusinessEntities.ModeloVehiculo" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetListByidMarcaVehiculo" 
                        TypeName="MPBA.SIAC.Bll.ModeloVehiculoManager" UpdateMethod="Save">
                        <SelectParameters>
                             <asp:ControlParameter ControlID="ddlmarcaVehiculo" Name="idMarcaVehiculo" 
                                 PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                   </asp:ObjectDataSource> 
                   <asp:ObjectDataSource ID="odsColorVehiculo" runat="server" 
                        DataObjectTypeName="MPBA.SIAC.BusinessEntities.ColorVehiculo" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.SIAC.Bll.ColorVehiculoManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsTieneGNC" runat="server" 
                         DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseBoolean" 
                         DeleteMethod="Delete" InsertMethod="Save" 
                         OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                         TypeName="MPBA.AutoresIgnorados.Bll.NNClaseBooleanManager" UpdateMethod="Save">
                     </asp:ObjectDataSource>    
                     <asp:ObjectDataSource ID="odsVidriosVehiculo" runat="server" 
                         DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseVidrioVehiculo" 
                         DeleteMethod="Delete" InsertMethod="Save" 
                         OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                         TypeName="MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager" 
                         UpdateMethod="Save">
                      </asp:ObjectDataSource>  
                     <asp:ObjectDataSource ID="odsTipoArmaFuego" runat="server" 
                         DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseTipoArmaFuego" 
                         DeleteMethod="Delete" InsertMethod="Save" 
                         OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                         TypeName="MPBA.AutoresIgnorados.Bll.NNClaseTipoArmaFuegoManager" UpdateMethod="Save">
                     </asp:ObjectDataSource>  
                     <asp:ObjectDataSource ID="odsDiametroArmaFuego" runat="server" 
                         DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseDiametroArmaFuego" 
                         DeleteMethod="Delete" InsertMethod="Save" 
                         OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                         TypeName="MPBA.AutoresIgnorados.Bll.NNClaseDiametroArmaFuegoManager" UpdateMethod="Save">
                     </asp:ObjectDataSource>
                     <asp:ObjectDataSource ID="odsTipoMoneda" runat="server" 
                         DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseMoneda" 
                         DeleteMethod="Delete" InsertMethod="Save" 
                         OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                         TypeName="MPBA.AutoresIgnorados.Bll.NNClaseMonedaManager" UpdateMethod="Save">
                     </asp:ObjectDataSource>   
                     
                </td>
              <td>
              </td>
            </tr>
            <tr>
                <td colspan="4" align="right" class="style47">
                 <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Verdana" 
                         Font-Size="0.8em" PathSeparator="&gt;">
                         <CurrentNodeStyle ForeColor="#333333" />
                         <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
                         <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
                         <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
                     </asp:SiteMapPath>
                </td>
                </tr>
              
        </table>
    </div>
</asp:Content>
