<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="True"
    Inherits="MPBA.AutoresIgnorados.Web.CargaVictimas" CodeBehind="CargaVictimas.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<script type="text/javascript"> 

    function confirmContinuar(valor) {

        x= confirm("Mensaje: La dirección está incompleta y no podrá visualizarce en el Mapa del Delito.Continúa de todos modos?");
        if (x) {
            document.location.href = "./CargaModusOperandi.aspx?c=0";
        }
       
    }

</script>"

    <style type="text/css">
        .style8
        {
            height: auto;
            width: auto;
            overflow: auto;
        }
        .style35
        {
            width: 98%;
        }
        .style46
        {
            position: relative;
            left: 2px;
            top: 2px;
            width: 332px;
            height: 30px;
        }
        .style47
        {
            height: 30px;
        }
        .style59
        {
            width: 119px;
            height: 22px;
        }
        .style60
        {
            width: 35px;
            height: 22px;
        }
        .style62
        {
            width: 2px;
            height: 22px;
        }
        .style79
        {
            width: 35px;
            height: 2px;
        }
        .style81
        {
            width: 108px;
            height: 2px;
        }
        .style82
        {
            width: 183px;
            height: 2px;
        }
        .style83
        {
            height: 2px;
        }
        .style84
        {
            height: 4px;
        }
        .style87
        {
            width: 108px;
            height: 4px;
        }
        .style88
        {
            width: 183px;
            height: 4px;
        }
        .style90
        {
            width: 324px;
        }
    </style>
    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div class="style8">
        <div class="FondoAutoresIgnorados" style="border-style: groove; border-color: #13507d;  height: auto;">
            <%--  <table width="100%">
            <tr>
            <td style="background-position: center; background-image: url('../App_Images/cartelVictimas.png'); background-repeat: no-repeat; background-attachment: fixed;" 
                    height="70" width="100%" valign="bottom"></td>
            
            </tr>
            </table>--%>
          <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelPrincipal" runat="server" align="center">
                    AUTORES DESCONOCIDOS</h3>
              </div>
                        
           
        
        


            <asp:Image ID="imgCartelVictimas" runat="server" 
            ImageUrl="~/App_Images/cartelVictimas.png" Height="50px" Width="858px" />

            <%-- <div style="background-image: url('../App_Images/cartelVictimas.png'); background-repeat: no-repeat; background-attachment: fixed; height: 60px;"></div>--%>
            <div class="FondoAutoresIgnorados">
                <%--<asp:UpdatePanel ID="upBuscarIpp" runat="server">
                        <ContentTemplate>--%>
                <table style="width: 100%; table-layout: auto;" class="FondoAutoresIgnorados">
                    <tr>
                     <input id="ResultadoValidacion" type="hidden" name="Hidden1" runat="server" value="False"/>
                    
                    <td style="border-width: thin; border-bottom-style: solid;" >
                    <asp:Label ID="lblCondicionCarga" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                        <td  style="border-width: thin; border-bottom-style: solid;" >
                            <%--<asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Large" Text="Víctimas, Tiempo y Territorio"></asp:Label>--%>
                            
                        </td>
                    </tr>
                    <tr>
                        <td valign="bottom">
                            <asp:Label ID="lblIpp" runat="server" Text="IPP" Font-Bold="True" 
                                Font-Size="Medium"></asp:Label>
                        </td>
                        <td align="left">
                       
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnBuscarIpp">
                            <asp:TextBox ID="txtIpp" runat="server" CssClass="ctooltip" Tooltip="<%$ Resources:WebResources,ingreso_IPP_Autores %>" Width="261px" Font-Size="Medium"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtIpp_MaskedEditExtender" runat="server" 
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99-99-999999-99" MaskType="Number" onblurcssnegative="MaskedEditError" 
                                TargetControlID="txtIpp">
                            </asp:MaskedEditExtender>
                            <asp:Button ID="btnBuscarIpp" runat="server" onclick="btnBuscarIpp_Click" 
                                Text="Buscar" CssClass="ButtonImage" Width="76px" 
                                ForeColor="Black" />
                            <%--<asp:ImageButton ID="btnBuscarIpp" runat="server" 
                                ImageUrl="App_Images/btn_Buscar_off.gif"
                                onmouseover="this.src='App_Images/btn_Buscar_on.gif';"
                                onmouseout="this.src='App_Images/btn_Buscar_off.gif';" 
                                onclick="btnBuscarIpp_Click" Height="28" Width="76" ImageAlign="AbsBottom" />--%>   
                            <asp:RequiredFieldValidator ID="rfvIpp" runat="server" ControlToValidate="txtIpp"
                                ErrorMessage="Debe ingresar la Ipp" Enabled="False"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnPasarAAutorCon" runat="server" Enabled="False" 
                                onclick="btnPasarAAutorCon_Click" Text="&gt;&gt; A Autor Conocido" 
                                Font-Size="XX-Small" />
                                <asp:ConfirmButtonExtender ID="ConfirmPasarAAutorCon" runat="server" ConfirmText="Pasa de Autor Desconocido a Autor Aprehendido?"
                        Enabled="True" TargetControlID="btnPasarAAutorCon">
                    </asp:ConfirmButtonExtender>
                            </asp:Panel>
                          
                        </td>
                    </tr>
                </table>
                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
            </div>
            <asp:Panel ID="pnlVictimasGral" runat="server">
            <div class="FondoAutoresIgnorados" style="text-align: left; height:124px" >
                <br />
                <table >
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlVictimas" runat="server" Width="437px" Height="91px" GroupingText="Víctimas / Denunciantes">
                            <asp:GridView ID="gvVictimas" runat="server" 
                            AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <%--<asp:BoundField DataField="ID" HeaderText="Id" />--%>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                            </asp:Panel>
                            
                        </td>
                        <td>
                            <asp:Panel ID="pnlDelitos" runat="server" Height="92px" GroupingText="Delitos" Width="253px">
                                <asp:GridView ID="gvDelitos" runat="server">
                                </asp:GridView>
                                <br />
                                <br />
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Errores Ocurridos:"
                                Width="193px" />
                        </td>
                    </tr>
                </table>
            </div>
            
            <br />
            <div class="FondoAutoresIgnorados">
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
              
                <asp:Panel ID="pnlTiempo" runat="server" GroupingText="Tiempo" HorizontalAlign="Left"
                    Enabled="True">
                    <table style="table-layout: auto">
                        <tr>
                            <td>
                            <asp:UpdatePanel ID="upFechas" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlFecha" runat="server" GroupingText="Fecha">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="rblFecha" runat="server"  OnSelectedIndexChanged="rblFecha_SelectedIndexChanged"
                                                    AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="descripcion"
                                                    DataValueField="id" RepeatDirection="Horizontal" 
                                                    ondatabound="rblFecha_DataBound">
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <asp:Panel ID="pnlFechaDesdeHasta" runat="server" Visible="False" Width="353px">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblFechaDesde" runat="server" Text="Desde"></asp:Label>
                                                            </td>
                                                            <td class="style90" style="text-align:left">
                                                            <table>
                                                            <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtFechaDesde" CssClass="ctooltip"  runat="server"    tooltip="<%$ Resources:WebResources,fecha_desde %>"  Width="88px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="txtFechaDesde_CalendarExtender" runat="server" Enabled="True"
                                                                    TargetControlID="txtFechaDesde" PopupButtonID="btnCalendarDesde">
                                                                </asp:CalendarExtender>
                                                                </td>
                                                                
                                                                <td>
                                                                <asp:MaskedEditExtender ID="txtFechaDesde_MaskedEditExtender" runat="server" AutoComplete="False"
                                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" 
                                                                        TargetControlID="txtFechaDesde" MessageValidatorTip="False">
                                                                </asp:MaskedEditExtender>
                                                                    <asp:ImageButton ID="btnCalendarDesde" runat="server" Height="16px" 
                                                                        ImageUrl="~/App_Images/calendar.png" Width="17px" 
                                                                        CausesValidation="False" />
                                                                    <asp:MaskedEditValidator ID="mevFechaDesde" runat="server" 
                                                                        ControlExtender="txtFechaDesde_MaskedEditExtender" 
                                                                        ControlToValidate="txtFechaDesde" EmptyValueMessage="Ingrese una fecha" 
                                                                        ErrorMessage="mevFechaDesde" InvalidValueMessage="Fecha incorrecta" 
                                                                        IsValidEmpty="False"></asp:MaskedEditValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                </tr>
                                                                <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                <asp:CustomValidator ID="cvFechas" runat="server" ControlToValidate="txtFechaDesde"
                                                                    ErrorMessage="Rango de fechas inválido"></asp:CustomValidator>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblFechaHasta" runat="server" Text="Hasta"></asp:Label>
                                                            </td>
                                                            <td class="style90" style="text-align">
                                                                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="ctooltip" Tooltip="<%$ Resources:WebResources,fecha_hasta %>" Width="87px"></asp:TextBox>
                                                                <asp:ImageButton ID="btnCalendarHasta" runat="server" Height="16px" 
                                                                    ImageUrl="~/App_Images/calendar.png" Width="17px" 
                                                                    CausesValidation="False" />
                                                                <asp:CalendarExtender ID="txtFechaHasta_CalendarExtender" runat="server" Enabled="True"
                                                                    TargetControlID="txtFechaHasta" PopupButtonID="btnCalendarHasta">
                                                                </asp:CalendarExtender>
                                                                <asp:MaskedEditExtender ID="txtFechaHasta_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                    Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaHasta">
                                                                </asp:MaskedEditExtender>
                                                                <asp:MaskedEditValidator ID="mevFechaHasta" runat="server" ControlExtender="txtFechaHasta_MaskedEditExtender"
                                                                    ControlToValidate="txtFechaHasta" EmptyValueMessage="Ingrese una fecha"
                                                                    ErrorMessage="Fecha incorrecta" InvalidValueMessage="Fecha incorrecta" IsValidEmpty="False"
                                                                    CssClass="ctooltip" TooltipMessage="Ingrese una fecha"></asp:MaskedEditValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: auto">
                            <asp:UpdatePanel ID="upHoras" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlHora" runat="server" GroupingText="Hora">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="rblHora" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblHora_SelectedIndexChanged"
                                                    AutoPostBack="True" DataSourceID="odsHora" DataTextField="descripcion" 
                                                    DataValueField="id" ondatabound="rblHora_DataBound"
                                                   >
                                                </asp:RadioButtonList>
                                            </td>
                                            <td valign="top">
                                                <asp:Panel ID="pnlHoraDesdeHasta" runat="server" Visible="False" Width="370px">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlMomentoDelDia" runat="server" 
                                                                    DataSourceID="odsMomentoDia" DataTextField="descripcion" DataValueField="id" 
                                                                    Width="112px">
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblHoraDesde" runat="server" Text="Desde"></asp:Label>
                                                            </td>
                                                            <td>
                                                            <table>
                                                            <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtHoraDesde" runat="server" Width="87px"></asp:TextBox>
                                                                <asp:MaskedEditExtender ID="txtHoraDesde_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                    Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtHoraDesde" 
                                                                    UserTimeFormat="TwentyFourHour">
                                                                </asp:MaskedEditExtender>
                                                                </td>
                                                                <td>
                                                                <asp:MaskedEditValidator ID="mevHoraDesde" runat="server" ControlExtender="txtHoraDesde_MaskedEditExtender"
                                                                    ControlToValidate="txtHoraDesde" EmptyValueMessage="Ingrese Hora" InvalidValueMessage="Hora incorrecta"
                                                                    IsValidEmpty="False" MaximumValue="23:59" Enabled="False" 
                                                                        ErrorMessage="Hora erronea"></asp:MaskedEditValidator>
                                                                    </td>
                                                                    </tr>
                                                                    <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                <asp:CustomValidator ID="cvHoras" runat="server" ControlToValidate="txtHoraDesde"
                                                                    ErrorMessage="Rango horario  inválido"></asp:CustomValidator>
                                                                    </td>
                                                                    </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblHoraHasta" runat="server" Text="Hasta"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtHoraHasta" runat="server" Width="87px"></asp:TextBox>
                                                                <asp:MaskedEditExtender ID="txtHoraHasta_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                    Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtHoraHasta" 
                                                                    UserTimeFormat="TwentyFourHour">
                                                                </asp:MaskedEditExtender>
                                                                <asp:MaskedEditValidator ID="mevHoraHasta" runat="server" ControlExtender="txtHoraHasta_MaskedEditExtender"
                                                                    ControlToValidate="txtHoraHasta" EmptyValueMessage="Ingrese Hora" InvalidValueMessage="Hora incorrecta"
                                                                    IsValidEmpty="False" MaximumValue="23:59" Enabled="False"></asp:MaskedEditValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
            <br />
            <div style="text-align: left" class="FondoAutoresIgnorados">
            <table style="margin-right: 0px; table-layout: auto;" >
                <tr>
                    <td align="left">
                        <asp:Label ID="lblLocalidad" runat="server" Text="Localidad"></asp:Label>
                         </td>
                    <td class="style59" colspan="2">
                    <asp:UpdatePanel ID="upLocalidadH" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblLocalidadH" runat="server"></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style60">
                            <asp:ImageButton  ID="btnBuscarLocalidadH" runat="server" class="ctooltip"   tooltip="<%$ Resources:WebResources,ingrese_localidad %>"  AlternateText="+" 
                            CommandName="" Height="16px" ImageUrl="~/App_Images/magnify.png" 
                            Width="16px" onclick="btnBuscarLocalidadH_Click" />
                        <asp:ModalPopupExtender ID="btnBuscarLocalidadH_ModalPopupExtender" 
                            runat="server" BackgroundCssClass="FondoOscuro" 
                            CancelControlID="btnCancelarLugar" DropShadow="True" DynamicServicePath="" 
                            Enabled="True" OkControlID="hfLugar" PopupControlID="pnlLugar" 
                            TargetControlID="btnBuscarLocalidadH" Drag="True" PopupDragHandleControlID="divHeaderLocalidad">
                        </asp:ModalPopupExtender>
                         
        
                    </td>
                    <td align="left">
                        <asp:Label ID="lblPartido" runat="server" Text="Partido"></asp:Label>
                    </td>
                    <td class="style62" align="left">
                    <asp:UpdatePanel ID="upPartidoH" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblPartidoH" runat="server"></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio"></asp:Label>
                                
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtBarrio" runat="server" Width="119px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblCalle" runat="server" Text="Calle"></asp:Label>
                    </td>
                    <td class="style59" colspan="2">
                        <asp:TextBox ID="txtCalle" runat="server" width="119px"></asp:TextBox>
                    </td>
                    <td class="style60">
                    </td>
                    <td align="left">
                        <asp:Label ID="lblEntre" runat="server" Text="entre"></asp:Label>
                    </td>
                    <td class="style62" align="left">
                        <asp:TextBox ID="txtEntreCalle" runat="server" width="119px"></asp:TextBox>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblYentre" runat="server" Text="y entre"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtYEntreCalle" runat="server" Width="119px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblNro" runat="server" Text="Nro."></asp:Label>
                    </td>
                    <td class="style59" colspan="2">
                        <asp:TextBox ID="txtNro" runat="server" Width="119px"></asp:TextBox>
                    </td>
                    <td class="style60">
                    </td>
                    <td align="left">
                        <asp:Label ID="lblPiso" runat="server" Text="Piso"></asp:Label>
                    </td>
                    <td class="style62" align="left">
                        <asp:TextBox ID="txtPiso" runat="server" width="119px"></asp:TextBox>
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblDepto" runat="server" Text="Departamento"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDepto" runat="server" Width="119px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="style83" align="left">
                        <asp:Label ID="lblComisaria" runat="server" Text="Comisaría de la Jurisdicción"></asp:Label>
                    </td>
                    <td class="style79">
                    </td>
                    <td align="left">
                    <asp:UpdatePanel ID="upComisariaH" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblComisariaH" runat="server"></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style81" align="left">
                        <asp:ImageButton ID="btnTraerComisariaH" class="ctooltip"   tooltip="<%$ Resources:WebResources,ingrese_comisaria %>" runat="server" AlternateText="+" 
                            CommandName="" Height="16px" ImageUrl="~/App_Images/magnify.png" 
                            Width="16px" onclick="btnTraerComisariaH_Click" />

                        <asp:ModalPopupExtender ID="btnTraerComisariaH_ModalPopupExtender" runat="server"
                            BackgroundCssClass="FondoOscuro" CancelControlID="btnCancelarComisariaH" DropShadow="True"
                            DynamicServicePath="" Enabled="True" OkControlID="hfComisariaH" PopupControlID="pnlComisariasH"
                            TargetControlID="btnTraerComisariaH" Drag="True" PopupDragHandleControlID="divHeaderComisaria">
                        </asp:ModalPopupExtender>
                    </td>
                    <td class="style82" align="right">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblLugar" runat="server" Text="Lugar"></asp:Label>
                    </td>
                    <td colspan="2" align="left">
                        <asp:DropDownList ID="ddlLugar" runat="server" DataSourceID="ObjectDataSource2" DataTextField="descripcion"
                            DataValueField="id" AutoPostBack="True"><%-- Width="100px"--%>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblRubro" runat="server" Text="Tipo de Lugar"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlRubro" runat="server" DataSourceID="ObjectDataSourceClaseRubro"
                            DataTextField="descripcion" DataValueField="id">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left;">
                        <asp:Label ID="lblNomRef" runat="server" Text="Nom. Ref. Lugar Rubro"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNomRef" runat="server" Width="119px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="style84" align="left">
                        &nbsp;</td>
                    <td colspan="2" align="left">
                        &nbsp;</td>
                    <td class="style87" align="right">
                    </td>
                    <td class="style88">
                    </td>
                </tr>
            </table>
            </div>
            </asp:Panel>
        </div>
       <asp:UpdatePanel ID="upBotones" runat="server">
        <ContentTemplate>
         <table width="100%">
               <tr>
               <td>
               </td>
                <td align="right" class="style47">
              
                    <asp:Button ID="btnAnterior" runat="server" Height="26px" Text="&lt;  Anterior" 
                        PostBackUrl="~/Home.aspx" UseSubmitBehavior="False" Visible="False" 
                        width="75px" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente  &gt;" OnClick="btnSiguiente_Click"
                        Height="26px" Width="75px" Enabled="False"   />

                     <asp:Button ID="btnCerrar" runat="server" Text="Salir" Height="26px" Width="57px"
                        OnCommand="btnCerrar_Command" UseSubmitBehavior="False" 
                        onclick="btnCerrar_Click" CausesValidation="False" />
                    <asp:ConfirmButtonExtender ID="btnCerrar_ConfirmButtonExtender" runat="server" ConfirmText="Desea cerrar?"
                        Enabled="True" TargetControlID="btnCerrar">
                    </asp:ConfirmButtonExtender>
                </td>
            </tr>
    </table>
   
     </ContentTemplate>
        </asp:UpdatePanel>
        <table class="style35">
         <tr>
                <td class="style46">
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseLugar"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseLugarManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseRubro" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRubro"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetListByidClaseLugar" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRubroManager"
                        UpdateMethod="Save">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlLugar" Name="idClaseLugar" 
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsMomentoDia" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseMomentoDia"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseMomentoDiaManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsHora" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseHora"
                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseHoraManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseFecha"
                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseFechaManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDepartamento" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.SIAC.Bll.DepartamentoManager" UpdateMethod="Save">
                </asp:ObjectDataSource>
                                <asp:HiddenField ID="hfLugar" runat="server" />
                                <asp:HiddenField ID="hfComisariaH" runat="server" />
                    <br />

                </td>
               </tr>
               </table>
   
    <table>
            <tr>
            <td>
                <asp:Panel ID="pnlLugar" runat="server" DefaultButton="btnTraerLugarHecho" 
                    CssClass="FondoModal" Width="350px">
                    <div>
                                       <div id="divHeaderLocalidad" class="ModalHeader">ELEGIR LOCALIDAD</div>
                    <div style="height:250px; position:relative; overflow:auto;">
                    <asp:UpdatePanel ID="upLugarTraslado" runat="server">
                        <ContentTemplate>
                   
                            <table width="100%">
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLugarTraslado" runat="server" Text="Lugar"></asp:Label>
                                        <asp:TextBox ID="txtLugar" runat="server" CausesValidation="True" Width="100px"></asp:TextBox>
                                        <asp:Button ID="btnTraerLugarHecho" runat="server" OnClick="btnTraerLugarHecho_Click"
                                            Text="Traer" Width="44px" />
                                        <br />
                                        <asp:Label ID="lblDemasiadosResultados" runat="server" ForeColor="#CC0000" 
                                            Text="Demasiados resultados, amplie la busqueda" Visible="False"></asp:Label>
                                        <br />
                                        <asp:GridView ID="gvLugar" runat="server" AutoGenerateColumns="False" 
                                            DataKeyNames="id" OnSelectedIndexChanged="gvLugar_SelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnElegirLugarTraslado" runat="server" CommandName="Select" 
                                                            Height="19px" Text="Elegir" Width="44px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                    ReadOnly="True" SortExpression="id" Visible="False" />
                                                <asp:BoundField DataField="localidad" HeaderText="localidad" 
                                                    SortExpression="localidad" />
                                                <asp:TemplateField HeaderText="Partido" SortExpression="Partido">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPartidoGrid" runat="server" 
                                                            Text='<%# MPBA.SIAC.Bll.PartidoManager.GetItem(Convert.ToInt32(Eval("partido").ToString())).partido %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CodigoPostal" HeaderText="CodigoPostal" 
                                                    SortExpression="CodigoPostal" />
                                                <asp:TemplateField HeaderText="Provincia" SortExpression="Provincia">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProvinciaGrid" runat="server" 
                                                            Text='<%# MPBA.SIAC.Bll.ProvinciaManager.GetItem(Convert.ToInt32(Eval("Provincia").ToString())).provincia %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                            </div>                    
                    <div style="padding-top:10px; position:relative;">
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <asp:Button ID="btnCancelarLugar" runat="server" CausesValidation="False" OnClick="btnCancelarLugar_Click"
                                    Text="Cancelar" UseSubmitBehavior="False" />
                                <br />
                            </td>
                            <td align="center">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    </div>
                    </div>
                </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="pnlComisariasH" runat="server" CssClass="FondoModal" Width="350px">
                  <div>
                                       <div id="divHeaderComisaria" class="ModalHeader">ELEGIR COMISARIA</div>
                    <div style="height:250px; position:relative; overflow:auto;">
                    <asp:UpdatePanel ID="upPanelComisaria" runat="server">
                        <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"></asp:Label>
                                            <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" DataSourceID="odsDepartamento"
                                                DataTextField="departamento" DataValueField="Id" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="gvComisariasH" runat="server" AutoGenerateColumns="False" 
                                                DataKeyNames="id" Height="156px" 
                                                OnSelectedIndexChanged="gvComisariasH_SelectedIndexChanged" PageSize="4" 
                                                Width="400px">
                                                <RowStyle HorizontalAlign="Left" />
                                                <Columns>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                                                                CommandName="Select" Height="18px" Text="Elegir" Width="41px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                        ReadOnly="True" SortExpression="id" Visible="False" />
                                                    <asp:BoundField DataField="comisaria" HeaderText="Comisaria" 
                                                        SortExpression="comisaria" />
                                                    <asp:BoundField DataField="idDepartamento" HeaderText="idDepartamento" 
                                                        SortExpression="idDepartamento" Visible="False" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="gvComisariasH" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </div>
                     <div style="padding-top: 10px; position: relative;">
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <asp:Button ID="btnCancelarComisariaH" runat="server" CausesValidation="False" OnClick="btnCancelarComisariaL_Click"
                                    Text="Cancelar" UseSubmitBehavior="False" />
                            </td>
                            <td align="center">
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    </div>
                    </div>
                </asp:Panel>
            </td>
            </tr>
        </table>
          
       
    </div>
</asp:Content>
