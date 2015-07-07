<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    Inherits="MPBA.AutoresIgnorados.Web.BusquedaAutores" CodeBehind="BusquedaAutores.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link id="styleMenu" href='<%# ResolveUrl("~/App_Themes/Theme1/styles_accordion.css")%>' rel="stylesheet" type ="text/css" />
  <script type="text/javascript">
      function buscarAutores(tipo) {
          document.getElementById("autores").style.visibility = 'visible';
          document.getElementById("divAp").style.visibility = 'visible';
         

          $("#autores").show();
          $("#divAp").show();


          $('#espera').show();
          var tiempo = new Date();

          $("#divAp").load("../Autores/BusquedaAutoresCoincidentes?PorAutor="+tipo+"&tiempo="+ tiempo.getMilliseconds());
          document.getElementById("autores").style.visibility = 'visible';
         
          $("#autores").show();
      

          
       


      };
     
      $(document).ready(function () {

         
          $("#fondoPagina").removeClass();
          $("#fondoPagina").addClass("fondo");

              

          
        
      });
   </script>
 
    <style type="text/css">
        
      v\:*{behavior:url(#default#VML);
            }
                
        .style35
        {
            width: 75%;
        }
        .style48
        {
            width: 75%;
        }
        .style49
        +
        {
            width: 75%;
             
        }
        .style78
        {
            text-align: left;
        }
        .ingreso
          { padding-bottom: 15px ;
        }
         .fondo
        {
           background-image: none !important;
        }
           .fondoDivIgnorados
        {
           height: 500px;
        }
    </style>
    <%--                                                                                    <asp:Label ID="lblIdSenia" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">


    <div>
        <div style="width:90%;margin:0px; padding:0px;border-style: groove; border-color: #13507d; background-color: #FFFFFF;">
         <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelPrincipal" runat="server" align="center">
                    ANALISIS</h3>
                     
         </div>
            <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelResultadoBusqueda" runat="server" align="center" visible="False">
                    Resultado Búsqueda</h3>
                     
             </div>
                                 
        
            <table class="style48" width="100%" bgcolor="White">
               
                <tr>
                <td align="left">
                       <asp:Panel ID="pnlBusquedasGuardadas" runat="server" Style="width: 100%;" 
                                Visible="True" GroupingText="Busquedas Guardadas" ForeColor="#CCCCFF">
                        <asp:GridView ID="gvMisBusquedas" runat="server" AutoGenerateColumns="False" 
                               onselectedindexchanged="gvMisBusquedas_SelectedIndexChanged" 
                               DataKeyNames="id" onrowdeleting="gvMisBusquedas_RowDeleting">
                            <Columns>
                                <asp:CommandField SelectText="Usar" ShowSelectButton="True">
                                <ItemStyle Width="5%" />
                                </asp:CommandField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="Delete" Text="Borrar" OnClientClick="return confirm('Seguro que desea borrar?');"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha"   ItemStyle-Width="20%" />
                                <asp:BoundField DataField="descripcionBusqueda" HeaderText="Descripcion" 
                                    SortExpression="descripcionBusqueda">
                                <ItemStyle Width="70%" />
                                </asp:BoundField>
                            </Columns>
                    </asp:GridView>
                  
                    
                
                    </asp:Panel>
                    <br />
                </td>
                    <td valign="top" align="left" rowspan="2">
                        <asp:Panel ID="pnlCriterioBusqueda" runat="server" GroupingText="Criterio de Búsqueda"
                            Width="100%">
                            <asp:UpdatePanel ID="upTree" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TreeView ID="tvCriteriosBusqueda" runat="server" ForeColor="Black" ImageSet="Arrows">
                                        <ParentNodeStyle Font-Bold="False" />
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                            VerticalPadding="0px" />
                                        <NodeStyle Font-Names="Verdana" Font-Size="XX-Small" ForeColor="Black" HorizontalPadding="5px"
                                            NodeSpacing="0px" VerticalPadding="0px" />
                                    </asp:TreeView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="style49" valign="top">
                        <asp:Panel ID="pnlPrincipal" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="True" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:TabContainer ID="tcBusquedaAutores" runat="server" ActiveTabIndex="0" Width="100%"
                                        EnableViewState="True">
                                        <asp:TabPanel runat="server" HeaderText="Tiempo y Territorio" ID="tpTiempo">
                                            <HeaderTemplate>
                                                Tiempo y Territorio</HeaderTemplate>
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="style78">
                                                            <asp:Panel ID="pnlIpp" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
                                                                <asp:CheckBox ID="chkPorIpp" runat="server" Text="Por IPP" AutoPostBack="True" OnCheckedChanged="chkPorIpp_CheckedChanged" /><asp:TextBox
                                                                    ID="txtIpp" runat="server" Width="164px"></asp:TextBox><asp:MaskedEditExtender ID="txtIpp_MaskedEditExtender"
                                                                        runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                        CultureTimePlaceholder="" Enabled="True" Mask="99-99-999999-99" MaskType="Number"
                                                                        TargetControlID="txtIpp" InputDirection="RightToLeft">
                                                                    </asp:MaskedEditExtender>
                                                                <asp:RequiredFieldValidator ID="rfvIPP" runat="server" ControlToValidate="txtIpp"
                                                                    ErrorMessage="Ingrese la IPP">Datos invalidos</asp:RequiredFieldValidator>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Panel ID="pnlTiempo" runat="server" BorderStyle="Solid" BorderWidth="1px">
                                                                <asp:Panel ID="pnlOpcionesTiempo" runat="server">
                                                                <asp:UpdatePanel ID="upOpcionesFecha" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="pnlOpcionesFecha" runat="server">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style78" colspan="5">
                                                                                    <asp:CheckBox ID="chkBuscarPorTiempo" Text="Por Tiempo" runat="server" AutoPostBack="True"
                                                                                        CssClass="style78" OnCheckedChanged="chkBuscarPorTiempo_CheckedChanged" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style78">
                                                                                    <asp:RadioButton ID="rbPorFecha" runat="server" AutoPostBack="True" GroupName="rbTiempo"
                                                                                        OnCheckedChanged="rbPorFecha_CheckedChanged" Text="Por Fecha" />
                                                                                </td>
                                                                                <td align="left" class="style78">
                                                                                    <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Desde" Width="89px"></asp:Label>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:TextBox ID="txtFechaDesde" runat="server" Width="88px"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="txtFechaDesde_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaDesde"
                                                                                        DaysModeTitleFormat="MMMM,yyyy" TodaysDateFormat="d MMMM  yyyy" PopupButtonID="btnCalendarDesde">
                                                                                    </asp:CalendarExtender>
                                                                                    <asp:MaskedEditExtender ID="txtFechaDesde_MaskedEditExtender" runat="server" AutoComplete="False"
                                                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                                        CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999"
                                                                                        MaskType="Date" MessageValidatorTip="False" TargetControlID="txtFechaDesde">
                                                                                    </asp:MaskedEditExtender>
                                                                                    <asp:ImageButton ID="btnCalendarDesde" runat="server" CausesValidation="False" Height="16px"
                                                                                        ImageUrl="~/App_Images/calendar.png" Width="17px" />
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:MaskedEditValidator ID="mevFechaDesde" runat="server" ControlExtender="txtFechaDesde_MaskedEditExtender"
                                                                                        ControlToValidate="txtFechaDesde" EmptyValueBlurredText="*" EmptyValueMessage="Ingrese una fecha"
                                                                                        ErrorMessage="Fecha incorrecta" InvalidValueMessage="Fecha incorrecta" IsValidEmpty="False"
                                                                                        TooltipMessage="Ingrese una fecha" Enabled="False"></asp:MaskedEditValidator><br />
                                                                                    <asp:CustomValidator ID="cvFechas" runat="server" ControlToValidate="txtFechaDesde"
                                                                                        ErrorMessage="Rango de fechas inválido" Enabled="False"></asp:CustomValidator>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:RadioButton ID="rbMomentoDia" runat="server" AutoPostBack="True" GroupName="rbTiempo"
                                                                                        OnCheckedChanged="rbMomentoDia_CheckedChanged" Text="Por Momento del Dia" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style78">
                                                                                    &#160;&#160;
                                                                                </td>
                                                                                <td align="left" class="style78">
                                                                                    <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Hasta" Width="100px" Style="margin-right: 0px"></asp:Label>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:TextBox ID="txtFechaHasta" runat="server" Width="87px"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="txtFechaHasta_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaHasta"
                                                                                        PopupButtonID="btnCalendarHasta">
                                                                                    </asp:CalendarExtender>
                                                                                    <asp:MaskedEditExtender ID="txtFechaHasta_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                        Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaHasta">
                                                                                    </asp:MaskedEditExtender>
                                                                                    <asp:ImageButton ID="btnCalendarHasta" runat="server" CausesValidation="False" Height="16px"
                                                                                        ImageUrl="~/App_Images/calendar.png" Width="17px" />
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:MaskedEditValidator ID="mevFechaHasta" runat="server" ControlExtender="txtFechaHasta_MaskedEditExtender"
                                                                                        ControlToValidate="txtFechaHasta" ErrorMessage="Fecha incorrecta" InvalidValueMessage="Fecha incorrecta"
                                                                                        TooltipMessage="Ingrese una fecha" Enabled="False"></asp:MaskedEditValidator>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:DropDownList ID="ddlMomentoDia" runat="server" DataSourceID="ObjectDataSourceClaseMomentoDelDia"
                                                                                        DataTextField="descripcion" DataValueField="id" Width="129px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style78">
                                                                                    <asp:RadioButton ID="rbPorHora" runat="server" AutoPostBack="True" GroupName="rbTiempo"
                                                                                        OnCheckedChanged="rbPorHora_CheckedChanged" Text="Por Hora" />
                                                                                </td>
                                                                                <td align="left" class="style78">
                                                                                    <asp:Label ID="lblHoraDesde" runat="server" Text="Hora Desde" Width="100px"></asp:Label>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:TextBox ID="txtHoraDesde" runat="server" Width="87px"></asp:TextBox><asp:MaskedEditExtender
                                                                                        ID="txtHoraDesde_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtHoraDesde" UserTimeFormat="TwentyFourHour">
                                                                                    </asp:MaskedEditExtender>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:MaskedEditValidator ID="mevHoraDesde" runat="server" ControlExtender="txtHoraDesde_MaskedEditExtender"
                                                                                        ControlToValidate="txtHoraDesde" EmptyValueBlurredText="*" EmptyValueMessage="Ingrese Hora"
                                                                                        Enabled="False" ErrorMessage="Hora erronea" InvalidValueBlurredMessage="*" InvalidValueMessage="Hora incorrecta"
                                                                                        IsValidEmpty="False" MaximumValue="23:59" SetFocusOnError="True"></asp:MaskedEditValidator><br />
                                                                                    <asp:CustomValidator ID="cvHoras" runat="server" ControlToValidate="txtHoraDesde"
                                                                                        ErrorMessage="Rango horario  inválido" Enabled="False"></asp:CustomValidator>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    &#160;&#160;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style78">
                                                                                    &#160;&#160;
                                                                                </td>
                                                                                <td align="left" class="style78">
                                                                                    <asp:Label ID="lblHoraHasta" runat="server" Text="Hora Hasta" Width="100px"></asp:Label>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:TextBox ID="txtHoraHasta" runat="server" Width="87px"></asp:TextBox><asp:MaskedEditExtender
                                                                                        ID="txtHoraHasta_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtHoraHasta" UserTimeFormat="TwentyFourHour">
                                                                                    </asp:MaskedEditExtender>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:MaskedEditValidator ID="mevHoraHasta" runat="server" ControlExtender="txtHoraHasta_MaskedEditExtender"
                                                                                        ControlToValidate="txtHoraHasta" EmptyValueMessage="Ingrese Hora" Enabled="False"
                                                                                        ErrorMessage="Hora incorrecta" InvalidValueMessage="Hora incorrecta" IsValidEmpty="False"
                                                                                        MaximumValue="23:59" SetFocusOnError="True"></asp:MaskedEditValidator>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                    </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </asp:Panel>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Panel ID="pnlTerritorio" runat="server" BorderStyle="Solid" BorderWidth="1px">
                                                                <asp:Panel ID="pnlOpcionesTerritorio" runat="server">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td class="style78" colspan="8">
                                                                                <asp:CheckBox ID="chkPorTerritorio" runat="server" AutoPostBack="True" CssClass="style78"
                                                                                    OnCheckedChanged="chkPorTerritorio_CheckedChanged" Text="Por Territorio" ToolTip="Ingrese el domicilio Completo, a fin de visualizar el Mapa del Delito" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style78" colspan="2" valign="top">
                                                                                <asp:Label ID="lblPart" runat="server" Text="Partido" ToolTip="Complete el DOMICILIO, a fin de visualizar el Mapa del Delito"></asp:Label>
                                                                                <asp:ImageButton ID="btnBuscarPartido" runat="server" ToolTip="Ingrese el domicilio Completo, a fin de visualizar el Mapa del Delito"  AlternateText="+" Height="16px"
                                                                                    ImageUrl="~/App_Images/magnify.png" OnClick="btnBuscarPartido_Click" Width="16px" />
                                                                            </td>
                                                                            <td class="style78" colspan="2" style="text-align: left;">
                                                                                <asp:UpdatePanel ID="upPartidoGrilla" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="gvPartido" runat="server" AutoGenerateColumns="False" 
                                                                                            BorderStyle="Solid" DataKeyNames="id" OnRowDeleting="gvPartido_RowDeleting" 
                                                                                            ShowHeader="False">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                                                                                            CommandName="Delete" Text="X"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                                                                    ReadOnly="True" SortExpression="id" Visible="False" />
                                                                                                <asp:BoundField DataField="partido" HeaderText="Partido" 
                                                                                                    SortExpression="partido" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                            <td class="style78" colspan="2" valign="top">
                                                                                <asp:Label ID="lblLocal" runat="server" Text="Localidad" ToolTip="Complete el DOMICILIO, a fin de visualizar el Mapa del Delito"></asp:Label>
                                                                                <asp:ImageButton ID="btnBuscarLocalidad" runat="server" AlternateText="+" Height="16px"
                                                                                    ImageUrl="~/App_Images/magnify.png" OnClick="btnBuscarLocalidadL_Click" Width="16px" />
                                                                            </td>
                                                                            <td class="style78" colspan="2" >
                                                                                <asp:UpdatePanel ID="upLocalidadesGrilla" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="gvLocalidades" runat="server" AutoGenerateColumns="False" 
                                                                                            BorderStyle="Solid" DataKeyNames="id" OnRowDeleting="gvLocalidades_RowDeleting" 
                                                                                            ShowHeader="False">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                                                            CommandName="Delete" Text="X"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                                                                    ReadOnly="True" SortExpression="id" Visible="False" />
                                                                                                <asp:BoundField DataField="localidad" HeaderText="localidad" 
                                                                                                    SortExpression="localidad" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                            <td class="style78" valign="top">
                                                                                <asp:Label ID="lblDeptoJud" runat="server" Text="Depto. Judicial" Width="75px"></asp:Label>
                                                                                <asp:ImageButton ID="btnBuscarDeptoJud" runat="server" AlternateText="+" Height="16px"
                                                                                    ImageUrl="~/App_Images/magnify.png" OnClick="btnBuscarDeptoJud_Click" Width="16px" />
                                                                            </td>
                                                                            <td class="style78">
                                                                                <asp:UpdatePanel ID="upDeptoJudGrilla" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="gvDeptoJud" runat="server" AutoGenerateColumns="False" 
                                                                                            BorderStyle="Solid" DataKeyNames="id" OnRowDeleting="gvDeptoJud_RowDeleting" 
                                                                                            ShowHeader="False">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                                                                                            CommandName="Delete" Text="X"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                                                                    ReadOnly="True" SortExpression="id" Visible="False" />
                                                                                                <asp:BoundField DataField="departamento" HeaderText="Depto. Jud." 
                                                                                                    SortExpression="departamento" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style78">
                                                                                <asp:Label ID="lblCalle" runat="server" Text="Calle" ToolTip="Complete el DOMICILIO, a fin de visualizar el Mapa del Delito"></asp:Label>
                                                                            </td>
                                                                            <td class="style78" colspan="3" style="text-align: left; margin-left: 0;">
                                                                                <asp:TextBox ID="txtOtraCalle" runat="server" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                            <td class="style78" colspan="2">
                                                                                <asp:Label ID="lblEntre" runat="server" Text="entre"></asp:Label>
                                                                            </td>
                                                                            <td class="style78"colspan="2" style="text-align: left; margin-left: 0;">
                                                                                <asp:TextBox ID="txtOtraCalle1" runat="server" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                            <td class="style78">
                                                                                <asp:Label ID="lblYEntre" runat="server" Text="y entre"></asp:Label>
                                                                            </td>
                                                                            <td class="style78" style="text-align: left">
                                                                                <asp:TextBox ID="txtOtraCalle2" runat="server" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                            
                                                                            <tr>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:Label ID="lblNro" runat="server" Text="Nro"></asp:Label>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:TextBox ID="txtNro" runat="server" Width="35px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:Label ID="lblPiso" runat="server" Text="Piso"></asp:Label>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:TextBox ID="txtPiso" runat="server" Width="25px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:Label ID="lblDepto" runat="server" Text="Depto"></asp:Label>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:TextBox ID="txtDepto" runat="server" Width="25px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:Label ID="lblParaje0" runat="server" Text="Paraje/Barrio"></asp:Label>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:TextBox ID="txtParaje" runat="server" Width="120px"></asp:TextBox>
                                                                                    <br />
                                                                                </td>
                                                                                <td class="style78">
                                                                                    <asp:Label ID="lblComis" runat="server" Text="Comisaria de la Jurisdiccion"></asp:Label>
                                                                                </td>
                                                                                <td class="style78" style="text-align: left">
                                                                                    <asp:ImageButton ID="btnTraerComisaria" runat="server" AlternateText="+" Height="16px"
                                                                                        ImageUrl="~/App_Images/magnify.png" OnClick="btnTraerComisariaH_Click" Width="16px" />
                                                                                    <asp:GridView ID="gvComisarias" runat="server" AutoGenerateColumns="False" 
                                                                                            BorderStyle="Solid" DataKeyNames="id" OnRowDeleting="gvComisarias_RowDeleting" 
                                                                                            ShowHeader="False">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                                                                                            CommandName="Delete" Text="X"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                                                                    ReadOnly="True" SortExpression="id" Visible="False" />
                                                                                                <asp:BoundField DataField="Comisaria" HeaderText="Comisaria" 
                                                                                                    SortExpression="Comisaria" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    <asp:ObjectDataSource ID="odsComisaria" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Comisaria"
                                                                                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                                                                                        TypeName="MPBA.SIAC.Bll.ComisariaManager" UpdateMethod="Save"></asp:ObjectDataSource>
                                                                                </td>
                                                                            </tr>
                                                    
                                                </table>
                                                </asp:Panel> </asp:Panel> </td> </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Panel ID="pnlInmueble" runat="server" BorderStyle="Solid" BorderWidth="1px">
                                                            <asp:Panel ID="pnlOpcionesPorLugar" runat="server">
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td colspan="4" class="style78">
                                                                            <asp:CheckBox ID="chkPorLugar" runat="server" Text="Por Lugar y Rubro" AutoPostBack="True"
                                                                                OnCheckedChanged="chkPorLugar_CheckedChanged" CssClass="style78" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblLugar" runat="server" Text="Lugar"></asp:Label>
                                                                        </td>
                                                                        <td class="style78" colspan="3">
                                                                            <asp:DropDownList ID="ddlLugar" runat="server" DataSourceID="ObjectDataSourceClaseLugar"
                                                                                DataTextField="descripcion" DataValueField="id" Width="150px" AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblRubro" runat="server" Text="Rubro"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:DropDownList ID="ddlRubro" runat="server" DataSourceID="ObjectDataSourceClaseRubro"
                                                                                DataTextField="descripcion" DataValueField="id" Width="150px" AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblNombreReferencia" runat="server" Text="Nom. Ref. Lugar Rubro"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:TextBox ID="txtNomRef" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                            </asp:Panel>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel runat="server" HeaderText="Modus Operandi" ID="tpModusOperandi">
                                            <HeaderTemplate>
                                                Modus Operandi</HeaderTemplate>
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td class="style78">
                                                            <asp:Panel runat="server" ID="pnlModusOperandi" BorderStyle="Solid" BorderWidth="1px">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:CheckBox ID="chkPorModusOperandis" runat="server" AutoPostBack="True" OnCheckedChanged="chkPorModusOperandis_CheckedChanged"
                                                                                Text="Por Modus Operandi" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblModusOperandis" runat="server" Text="Clasificación" Width="100px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:DropDownList ID="ddlModusOperandis" runat="server" DataSourceID="ObjectDataSourceClaseModusOperandis"
                                                                                DataTextField="descripcion" DataValueField="id" Width="129px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblModoArriboHuida" runat="server" Text="Modo de Arribo/Huída" Width="100px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:DropDownList ID="ddlModoArriboHuida" runat="server" DataSourceID="ObjectDataSourceClaseModoArriboHuida"
                                                                                DataTextField="descripcion" DataValueField="id" Width="129px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblIngresaronPor" runat="server" Text="Ingresaron Por" Width="104px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:TextBox ID="txtIngresaronPor" runat="server" Width="129px" Height="20px"></asp:TextBox>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblHuboVictimas" runat="server" Text="¿Hubo víctimas presentes en el lugar?"
                                                                                Width="115px"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlHuboVictimas" runat="server" Width="129px" DataSourceID="ObjectDataSourceClaseBoolaen"
                                                                                DataTextField="Descripcion" DataValueField="Id" Height="20px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnlVehiculo" runat="server" BorderStyle="Solid" BorderWidth="1px">
                                                                <table style="width: 100%;">
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:CheckBox ID="chkPorDetalleModoArriboHuida" runat="server" Text="Por Vehículo Arribo Huida"
                                                                                AutoPostBack="True" CssClass="style78" OnCheckedChanged="chkPorDetalleModoArriboHuida_CheckedChanged" />
                                                                        </td>
                                                                        <td class="style78">
                                                                        </td>
                                                                        <td class="style78">
                                                                        </td>
                                                                        <td class="style78">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblPatente" runat="server" Text="Patente" Width="100px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:TextBox ID="txtPatente" runat="server" Width="129px" Height="20px"></asp:TextBox>
                                                                        </td>
                                                                        <td class="style78">
                                                                        </td>
                                                                        <td class="style78">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblMarca" runat="server" Text="Marca" Width="100px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:DropDownList ID="ddlMarcaMO" runat="server" DataSourceID="odsMarcaMO" DataTextField="Descripcion"
                                                                                DataValueField="id" Width="129px" AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                            <asp:ObjectDataSource ID="odsMarcaMO" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.MarcaVehiculo"
                                                                                DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                                                                                TypeName="MPBA.SIAC.Bll.MarcaVehiculoManager" UpdateMethod="Save">
                                                                            </asp:ObjectDataSource>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblModelo" runat="server" Text="Modelo" Width="100px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:DropDownList ID="ddlModeloMO" runat="server" DataSourceID="odsModeloMO" DataTextField="Descripcion"
                                                                                DataValueField="id" Width="129px">
                                                                            </asp:DropDownList>
                                                                            <asp:ObjectDataSource ID="odsModeloMO" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ModeloVehiculo"
                                                                                DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListByidMarcaVehiculo"
                                                                                TypeName="MPBA.SIAC.Bll.ModeloVehiculoManager" UpdateMethod="Save">
                                                                                <SelectParameters>
                                                                                    <asp:ControlParameter ControlID="ddlMarcaMO" Name="idMarcaVehiculo" PropertyName="SelectedValue"
                                                                                        Type="Int32" />
                                                                                </SelectParameters>
                                                                            </asp:ObjectDataSource>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblColor" runat="server" Text="Color" Width="100px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:DropDownList ID="ddlColorMO" runat="server" DataSourceID="odsColorMO" DataTextField="Descripcion"
                                                                                DataValueField="id" Width="129px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:Label ID="lblVidrio" runat="server" Text="Vidrio" Width="100px"></asp:Label>
                                                                        </td>
                                                                        <td class="style78">
                                                                            <asp:DropDownList ID="ddlClaseVidrio" runat="server" Width="129px" DataSourceID="ObjectDataSourceClaseVidrio"
                                                                                DataTextField="descripcion" DataValueField="id" Height="20px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style78">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tpAutores" runat="server" HeaderText="Autor/es">
                                            <HeaderTemplate>
                                                Por Autor</HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlAutor" runat="server" BorderStyle="Solid" BorderWidth="1px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="text-align: left" colspan="2">
                                                                <asp:CheckBox ID="chkPorAutor" runat="server" AutoPostBack="True" OnCheckedChanged="chkPorAutor_CheckedChanged"
                                                                    Text="Por Autor" CssClass="ctooltip" Tooltip="Todos estos campos se agregarán a las condiciones indicadas en otras solapas" />
                                                                    <div style="width:300px; margin-top:5px">
                                                                   
                                                                           <asp:CheckBox ID="chkAp" name="AutorAp" class ="Autor" 
                                                                           runat="server"  Enabled="false" Text="Aprehendido" />
                                                                             <asp:CheckBox ID="chkIg" name="AutorIg" class = "Autor" 
                                                                             runat="server"   Enabled="false"  Text="Ignorado" />
                                                                    </div>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan='5' style="text-align: left">
                                                        <asp:Panel ID="pnlAutorConocido" runat="server" GroupingText="Autor" 
                                                                HorizontalAlign="Left" Visible="False">
                    <asp:UpdatePanel ID="upIdentificacionAutor" runat="server">
                    <ContentTemplate>
                     <table width="100%">
                        <tr>
                            <td  width="10%" >
                            <asp:Label runat="server" ID="lblNombreAutor" Text="Nombre"></asp:Label>
                            </td>
                            <td width="20%">
                            <asp:TextBox runat="server" ID="txtNombreAutor"></asp:TextBox>
                            <td width="10%">
                            <asp:Label runat="server" ID="lblApellidoAutor" Text="Apellido"></asp:Label>
                            </td>
                             <td width="20%">
                              <asp:TextBox runat="server" ID="txtApellidoAutor"></asp:TextBox>
                             </td>
                            
                            </tr>
                            <tr>
                            <td width="10%">
                            <asp:Label runat="server" ID="lblApodoAutor" Text="Apodo"></asp:Label>
                             </td>
                             <td width="20%" >
                            <asp:TextBox runat="server" ID="txtApodoAutor"></asp:TextBox>
                             </td>
                          <!-- <td width="10%">
                             
                            <asp:Label runat="server" ID="lblTipoDniAutor" Visible="False">Tipo Doc.</asp:Label>
                             </td>
                             <td width="20%">
                           <asp:DropDownList runat="server" ID="ddlTipoDniAutor" Width="1px" Visible="False"></asp:DropDownList>                                                       
                            </td> -->  
                            <td width="10%">
                            <asp:Label runat="server" ID="lblDniAutor" Text="DNI"></asp:Label>
                            </td> <td width="20%">
                            <asp:TextBox runat="server" ID="txtDniAutor"></asp:TextBox>
                            <asp:MaskedEditExtender ID="meDocNroAutor" runat="server" MaskType="Number" 
                                     Mask="999999999" TargetControlID="txtDniAutor" Enabled="False"></asp:MaskedEditExtender>
                              <asp:RequiredFieldValidator ID="rfvDocNroAutor" runat="server" ControlToValidate="txtDniAutor"
                                ErrorMessage="Debe ingresar el Numero de Documento" Enabled="False"></asp:RequiredFieldValidator>
                            </td>
                            </tr>
                           
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                    </asp:Panel>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan='2' style="text-align: left">
                                                                <asp:Label ID="lblRostro" runat="server" Text="Rostro"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlClaseRostro" runat="server" DataSourceID="ObjectDataSourceRostro"
                                                                    DataTextField="descripcion" DataValueField="id" Width="129px" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlClaseRostro_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblCon" runat="server" Text="Con"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtCon" runat="server" Width="129px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left" colspan="2">
                                                                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlCantidadAutores" runat="server" Width="129px" DataSourceID="ObjectDataSourceClaseCantidadAutores"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblNroAutor" visible="False" runat="server" 
                                                                    Text="Número de Autor"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtNroAutor" visible="False" runat="server" Width="129px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td style="text-align: left" colspan="2">
                                                                <asp:Label ID="lblEdadAproximada" runat="server" Text="Edad Aproximada"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlEdadAproximada" runat="server" Width="129px" DataSourceID="ObjectDataSourceClaseEdadAproximada"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" >
                                                                <asp:DropDownList ID="ddlSexo" runat="server" Width="129px" DataSourceID="ObjectDataSourceClaseSexo"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td style="text-align: left" colspan="2">
                                                                <asp:Label ID="lblEstatura" runat="server" Text="Estatura"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlestatura" runat="server" Width="129px" DataSourceID="ObjectDataSourceSICClaseEstatura"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblRobustez" runat="server" Text="Robustez"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" >
                                                                <asp:DropDownList ID="ddlRobustez" runat="server" Width="129px" DataSourceID="ObjectDataSourceSICClaseRobustez"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                           <td style="text-align: left;white-space:nowrap" colspan="2">
                                                                <asp:Label ID="lblColorOjos" runat="server" Text="Color de Ojos"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlColorOjos" runat="server" Width="129px" DataSourceID="odsSICClaseColorOjos"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left; white-space:nowrap">
                                                                <asp:Label ID="lblColorPiel" runat="server" Text="Color de Piel"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; white-space:nowrap">
                                                                <asp:DropDownList ID="ddlColorPiel" runat="server" Width="129px" DataSourceID="odsSICCLaseColorPiel"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td style="text-align: left;  white-space:nowrap" colspan="2">
                                                                <asp:Label ID="lblColorCabello" runat="server" Text="Color de Cabello"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlColorCabello" runat="server" Width="129px" DataSourceID="odsSICClaseColorCabello"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td> 
                                                           <td style="text-align: left ;white-space:nowrap">
                                                                <asp:Label ID="lblTipoCabello" runat="server" Text="Tipo de Cabello"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlTipoCabello" runat="server" Width="129px" DataSourceID="odsSICClaseTipoCabello"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                           <td style="text-align: left ;white-space:nowrap" colspan="2">
                                                                <asp:Label ID="lblFormaCara" runat="server" Text="Forma de la Cara"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlFormaCara" runat="server" Width="129px" DataSourceID="odsSICClaseFormaCara"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left;white-space:nowrap">
                                                                <asp:Label ID="lblFormaMenton" runat="server" Text="Forma de Menton"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" >
                                                                <asp:DropDownList ID="ddlFormaMenton" runat="server" Width="129px" DataSourceID="odsSICCLaseFormaMenton"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                           <td style="text-align: left" colspan="2">
                                                                <asp:Label ID="lblFormaNariz" runat="server" Text="Forma de la Nariz"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlFormaNariz" runat="server" Width="129px" DataSourceID="odsSICClaseFormaNariz"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblFormaBoca" runat="server" Text="Forma de la Boca"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" >
                                                                <asp:DropDownList ID="ddlFormaBoca" runat="server" Width="129px" DataSourceID="odsSICCLaseFormaBoca"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left;">
                                                                <asp:Label ID="lblFormaLabioInferior" runat="server" 
                                                                    Text="Forma del Labio Inferior" ></asp:Label>
                                                            
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlFormaLabioInferior" runat="server" 
                                                                    DataSourceID="odsSICClaseFormaLabioInferior" DataTextField="descripcion" 
                                                                    DataValueField="id" Width="129px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblFormaLabioSuperior" runat="server" 
                                                                    Text="Forma del Labio Superior"></asp:Label>
                                                                
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlFormaLabioSuperior" runat="server" 
                                                                    DataSourceID="odsSICClaseFormaLabioSuperior" DataTextField="descripcion" 
                                                                    DataValueField="id" Width="129px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left;">
                                                                <asp:Label ID="lblFormaoreja" runat="server" 
                                                                    Text="Forma de la Oreja" ></asp:Label>
                                                            
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlFormaOreja" runat="server" 
                                                                    DataSourceID="odsSICClaseFormaOreja" DataTextField="descripcion" 
                                                                    DataValueField="id" Width="129px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblTipoDeCalvicie" runat="server" Text="Tipo de Calvicie"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" >
                                                                <asp:DropDownList ID="ddlTipoCalvicie" runat="server" Width="129px" DataSourceID="odsSICCLaseTipoCalvicie"
                                                                    DataTextField="descripcion" DataValueField="id">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                            <td colspan="2" style="text-align: left">
                                                                <asp:Label ID="lblTipoCeja" runat="server" Text="Tipo de Ceja"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlTipoCeja" runat="server" 
                                                                    DataSourceID="odsSICClaseCejaTipo" DataTextField="descripcion" 
                                                                    DataValueField="id" Width="129px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblCejaDimension" runat="server" Text="Dimensión de la Ceja"></asp:Label>
                                                            </td>
                                                            <td  style="text-align: left">
                                                                <asp:DropDownList ID="ddlCejaDimension" runat="server" 
                                                                    DataSourceID="odsSICClaseCejaDimension" DataTextField="descripcion" 
                                                                    DataValueField="id" Width="129px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        
                                                        <tr>
                                                            <td colspan="5">
                                                                <asp:Panel ID="pnlSenia" runat="server" GroupingText="Seña Particular">
                                                                    <asp:GridView ID="gvSenasPartD" runat="server" AutoGenerateColumns="False" 
                                                                        BorderColor="Black" DataKeyNames="id" 
                                                                        OnRowCancelingEdit="gvSenasPart_RowCancelingEdit" 
                                                                        OnRowDeleting="gvSenasPart_RowDeleting" OnRowEditing="gvSenasPart_RowEditing" 
                                                                        OnRowUpdating="gvSenasPart_RowUpdating" ShowFooter="True">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                                                ReadOnly="True" SortExpression="id" Visible="False" />
                                                                            <asp:BoundField DataField="idAutor" HeaderText="idAutor" 
                                                                                SortExpression="idAutor" Visible="False" />
                                                                            <asp:TemplateField HeaderText="Seña" SortExpression="idSeniaParticular">
                                                                                <EditItemTemplate>
                                                                                    <asp:DropDownList ID="ddlSeniaPart" runat="server" 
                                                                                        DataSourceID="ObjectDataSourceSeniaParticular" DataTextField="Descripcion" 
                                                                                        DataValueField="Id" SelectedValue='<%# Eval("idSeniaParticular") %>'>
                                                                                    </asp:DropDownList>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:DropDownList ID="ddlSeniaPartInsert" runat="server" 
                                                                                        DataSourceID="ObjectDataSourceSeniaParticular" DataTextField="Descripcion" 
                                                                                        DataValueField="Id">
                                                                                    </asp:DropDownList>
                                                                                </FooterTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddlSeniaPartItem" runat="server" 
                                                                                        DataSourceID="ObjectDataSourceSeniaParticular" DataTextField="Descripcion" 
                                                                                        DataValueField="Id" Enabled="false" 
                                                                                        SelectedValue='<%# Eval("idSeniaParticular") %>'>
                                                                                    </asp:DropDownList>
                                                                                    <%--                                                                                    <asp:Label ID="lblIdSenia" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Ubicación" 
                                                                                SortExpression="idUbicacionSeniaParticular">
                                                                                <EditItemTemplate>
                                                                                    <asp:DropDownList ID="ddlUbicacionSenaPart" runat="server" 
                                                                                        DataSourceID="ObjectDataSourceLugarCuerpo" DataTextField="Descripcion" 
                                                                                        DataValueField="Id" SelectedValue='<%# Eval("idUbicacionSeniaParticular") %>'>
                                                                                    </asp:DropDownList>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:DropDownList ID="ddlUbicacionSenaPartInsert" runat="server" 
                                                                                        DataSourceID="ObjectDataSourceLugarCuerpo" DataTextField="Descripcion" 
                                                                                        DataValueField="Id">
                                                                                    </asp:DropDownList>
                                                                                </FooterTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddlUbicacionSenaPartItem" runat="server" 
                                                                                        DataSourceID="ObjectDataSourceLugarCuerpo" DataTextField="Descripcion" 
                                                                                        DataValueField="Id" Enabled="false" 
                                                                                        SelectedValue='<%# Eval("idUbicacionSeniaParticular") %>'>
                                                                                    </asp:DropDownList>
                                                                                    <%--                                                                                    <asp:Label ID="lblIdUbicacion" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" 
                                                                                SortExpression="idTablaDestino" Visible="False" />
                                                                            <asp:TemplateField ShowHeader="False">
                                                                                <EditItemTemplate>
                                                                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" 
                                                                                        CommandName="Update" Text="Ok"></asp:LinkButton>
                                                                                    &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                                                                        CommandName="Cancel" Text="X"></asp:LinkButton>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:LinkButton ID="btnAgregarSeniaD" runat="server" CausesValidation="False" 
                                                                                        CommandArgument="D" OnClick="btnAgregarSenia_Click" Text="Agregar"></asp:LinkButton>
                                                                                </FooterTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                                                                                        CommandName="Edit" Text="Editar"></asp:LinkButton>
                                                                                    &nbsp;<asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" 
                                                                                        CommandName="Delete" Text="Borrar"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSeniaPartD" runat="server" Text="Seña"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblUbicacionSeniaPartD" runat="server" Text="Ubicación"></asp:Label>
                                                                                    </td>
                                                                                    <%--                                                                        <td>
                                                                                        <asp:Label ID="lblDescripion"  CssClass="ingreso" runat="server" Text="Descripción"></asp:Label>
                                                                                    </td>
--%>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlSenasParticulares" runat="server" 
                                                                                            DataSourceID="ObjectDataSourceSeniaParticular" DataTextField="Descripcion" 
                                                                                            DataValueField="Id"  CssClass="ctooltip" Tooltip="Debe presionar Agregar para que intervenga en la búsqueda" >
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlUbicacionSenasPart" runat="server" 
                                                                                            DataSourceID="ObjectDataSourceLugarCuerpo"  CssClass="ctooltip" Tooltip="Debe presionar Agregar para que intervenga en la búsqueda"  DataTextField="Descripcion" 
                                                                                            DataValueField="Id">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <%--                                                                         <td>
                                                                                            <asp:TextBox ID="descripcionSenaPart" CssClass="ingreso" runat="server" Text='<%# Eval("Descripcion") %>'/>
                                                                                        </td>
                --%>
                                                                                    <td>
                                                                                        <asp:LinkButton ID="btnSendD" runat="server" CommandArgument="D" 
                                                                                            CommandName="EmptyInsert" OnClick="btnAgregarPrimeraSenia_Click" Text="Agregar" 
                                                                                            UseSubmitBehavior="false" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:Panel ID="pnlTatuaje" runat="server" GroupingText="Tatuaje">
                                                                        <asp:GridView ID="gvTatuajesD" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                                            OnRowCancelingEdit="gvTatuajes_RowCancelingEdit" OnRowDeleting="gvTatuajes_RowDeleting"
                                                                            OnRowEditing="gvTatuajes_RowEditing" OnRowUpdating="gvTatuajes_RowUpdating" ShowFooter="True"
                                                                            BorderColor="Black">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                                                    SortExpression="id" Visible="False" />
                                                                                <asp:BoundField DataField="idPersona" HeaderText="idPersona" SortExpression="idPersona"
                                                                                    Visible="False" />
                                                                                <asp:TemplateField HeaderText="Tatuaje" SortExpression="idTatuaje">
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTatuajes" runat="server" DataSourceID="ObjectDataSourceTipoTatuaje" DataTextField="descripcion"
                                                                                            DataValueField="id"  CssClass="ctooltip" Tooltip="Debe presionar Agregar para que intervenga en la búsqueda" SelectedValue='<%# Eval("idTatuaje") %>'>
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:DropDownList ID="ddlTatuajeInsert" runat="server" DataSourceID="ObjectDataSourceTipoTatuaje"
                                                                                            DataTextField="descripcion" DataValueField="id">
                                                                                        </asp:DropDownList>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTatuajesItem" runat="server" DataSourceID="ObjectDataSourceTipoTatuaje" DataTextField="descripcion"  Enabled = "False"
                                                                                            DataValueField="id" SelectedValue='<%# Eval("idTatuaje") %>'>
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionTatuaje">
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlUbicacionTatuaje" runat="server" DataSourceID="ObjectDataSourceLugarCuerpo"
                                                                                            DataTextField="descripcion" DataValueField="id"  CssClass="ctooltip" Tooltip="Debe presionar Agregar para que intervenga en la búsqueda"  SelectedValue='<%# Eval("idUbicacionTatuaje") %>'>
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:DropDownList ID="ddlUbicacionTatuajeInsert" runat="server" DataSourceID="ObjectDataSourceLugarCuerpo"
                                                                                            DataTextField="descripcion" DataValueField="id">
                                                                                        </asp:DropDownList>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlUbicacionTatuajeItem" runat="server" DataSourceID="ObjectDataSourceLugarCuerpo" Enabled = "False"
                                                                                            DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Eval("idUbicacionTatuaje") %>'>
                                                                                        </asp:DropDownList>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" SortExpression="idTablaDestino"
                                                                                    Visible="False" />
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <EditItemTemplate>
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandArgument="D"
                                                                                            CommandName="Update" Text="Ok"></asp:LinkButton>
                                                                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument="D"
                                                                                            CommandName="Cancel" Text="X"></asp:LinkButton>
                                                                                    </EditItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:LinkButton ID="btnAgregarTatuaje" runat="server" CausesValidation="False" CommandArgument="D"
                                                                                            OnClick="btnAgregarTatuaje_Click" Text="Agregar"></asp:LinkButton>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument="D"
                                                                                            CommandName="Edit" Text="Editar"></asp:LinkButton>
                                                                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument="D"
                                                                                            CommandName="Delete" Text="Borrar"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTatuajeD" runat="server" Text="Tatuaje"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblUbicacionTatuajeD" runat="server" Text="Ubicación"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlTatuajes" runat="server" DataSourceID="ObjectDataSourceTipoTatuaje" DataTextField="descripcion"
                                                                                                    DataValueField="id">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlUbicacionTatuaje" runat="server" DataSourceID="ObjectDataSourceLugarCuerpo"
                                                                                                    DataTextField="Descripcion" DataValueField="Id">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:LinkButton ID="btnSend" runat="server" CommandArgument="D" CommandName="EmptyInsert"
                                                                                                    OnClick="btnAgregarPrimerTatuaje_Click" Text="Agregar" UseSubmitBehavior="false" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="tpBienesSustraidos" runat="server" HeaderText="Bienes Sustraídos">
                                            <HeaderTemplate>
                                                Por Bien Sustraído</HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:Panel runat="server" ID="pnlBienSustraido" BorderStyle="Solid" BorderWidth="1px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="style78">
                                                                <asp:CheckBox ID="chkPorBienSustraido" runat="server" Text="Por Bien Sustraído" AutoPostBack="True"
                                                                    OnCheckedChanged="chkPorBienSustraido_CheckedChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel ID="pnlEspecie" runat="server">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td class="style78" style="width: 25px">
                                                                    <asp:Label ID="lblEspecie" runat="server" Text="Especie" Width="120px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:DropDownList ID="ddlClaseBienSustraido" runat="server" Width="100px" Height="22px"
                                                                        AutoPostBack="True" DataSourceID="odsClaseBienSustraido" DataTextField="descripcion"
                                                                        DataValueField="id" OnSelectedIndexChanged="ddlClaseBienSustraido_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblMontoTotalEstimado" runat="server" Text="Monto Total Estimado"
                                                                        Width="122px"></asp:Label>
                                                                    <asp:TextBox ID="txtMontoTotalEstimado" runat="server" Width="100px"></asp:TextBox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtender1"
                                                                        runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                        CultureTimePlaceholder="" Enabled="True" Mask="999999" MaskType="Number"
                                                                        TargetControlID="txtMontoTotalEstimado" InputDirection="RightToLeft">
                                                                        </asp:MaskedEditExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlVehiculoSustraido" runat="server" GroupingText="Vehículo Sustraído">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblMarcaAutoSustraido" runat="server" Text="Marca" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:DropDownList ID="ddlMarcaBS" runat="server" DataSourceID="odsMarcaBS" DataTextField="Descripcion"
                                                                        DataValueField="id" Width="100px" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:ObjectDataSource ID="odsMarcaBS" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.MarcaVehiculo"
                                                                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                                                                        TypeName="MPBA.SIAC.Bll.MarcaVehiculoManager" UpdateMethod="Save">
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblModeloAutoSustraido" runat="server" Text="Modelo" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:DropDownList ID="ddlModeloBS" runat="server" Width="100px" DataSourceID="odsModeloBS"
                                                                        DataTextField="Descripcion" DataValueField="id" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:ObjectDataSource ID="odsModeloBS" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ModeloVehiculo"
                                                                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListByidMarcaVehiculo"
                                                                        TypeName="MPBA.SIAC.Bll.ModeloVehiculoManager" UpdateMethod="Save">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="ddlMarcaBS" Name="idMarcaVehiculo" PropertyName="SelectedValue"
                                                                                Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblAnioAutoSustraido" runat="server" Text="Año" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtAnioAutoSustraido" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblPatenteAutoSustraido" runat="server" Text="Patente" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtPatenteBS" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblColorAutoSustraido" runat="server" Text="Color" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:DropDownList ID="ddlColorBS" runat="server" DataSourceID="odsColorBS" DataTextField="Descripcion"
                                                                        DataValueField="id" Width="100px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblVidriosAutoSustraido" runat="server" Text="Vidrios" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:DropDownList ID="ddlVidriosVehiculo" runat="server" Width="100px" DataSourceID="ObjectDataSourceClaseVidrioAutoSustraido"
                                                                        DataTextField="descripcion" DataValueField="id" Height="22px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblValor" runat="server" Text="Valor" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtValor" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblNroMotor" runat="server" Text="Nro. de Motor" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtNroMotor" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblNroChasis" runat="server" Text="Nro. de Chasis" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtNroChasis" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblTieneGNC" runat="server" Text="Tiene GNC" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:DropDownList ID="ddlTieneGNC" runat="server" Width="100px" DataSourceID="ObjectDataSourceClaseBoolaen"
                                                                        DataTextField="Descripcion" DataValueField="Id" Height="22px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="1" class="style78">
                                                                </td>
                                                                <td class="style78">
                                                                </td>
                                                                <td class="style78">
                                                                </td>
                                                                <td class="style78">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlAnimalSustraido" runat="server" GroupingText="Animal Sustraído">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblClaseGanado" runat="server" Text="Clase de Ganado" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:DropDownList ID="ddlClaseGanado" runat="server" Width="100px" DataSourceID="ObjectDataSourceClaseGanado"
                                                                        DataTextField="descripcion" DataValueField="id" Height="22px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblCantidadAnimalSustraido" runat="server" Text="Cantidad" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtCantidadAnimalSustraido" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblMarcaAnimalSustraido" runat="server" Text="Marca" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtMarcaAnimalSustraido" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlOtroBienSustraido" runat="server" GroupingText="Otro Bien Sustraído">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblMarcaOtroBienSustraido" runat="server" Text="Marca" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtMarcaOtroBienSustraido" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblNroSerieOtroBienSustraido" runat="server" Text="Nro. de Serie"
                                                                        Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtNroSerieOtroBien" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:Label ID="lblCantidadOtroBienSustraido" runat="server" Text="Cantidad" Width="100px"></asp:Label>
                                                                </td>
                                                                <td class="style78">
                                                                    <asp:TextBox ID="txtCantidadOtroBien" runat="server" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                           
  
                        
                            <asp:Panel ID="pnlResultados" runat="server" Style="width: 100%;" Visible="False">
                                <table style="width: 100%">
                                    <tr>
                                        <td align="left">
                                            <%--<asp:UpdatePanel ID="upResultados" runat="server">
                            <ContentTemplate>--%>
                            
                            <asp:Label ID="lblCantResultados" Text="Resultados Encontrados" runat="server" 
                                                Font-Size="Small" Font-Underline="False"></asp:Label>
                            <hr width="100%">
                            
                                            <asp:GridView ID="gvResultadosGeneral" runat="server" DataKeyNames="idDelito" OnSelectedIndexChanged="gvResultadosGeneral_SelectedIndexChanged"
                                                OnRowDataBound="gvResultadosGeneral_RowDataBound">
                                                <Columns>
                                                    <asp:CommandField ButtonType="Button" InsertVisible="False" SelectText="Detalles"
                                                        ShowCancelButton="False" ShowSelectButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                            <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <table class="style35">
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <div>
                               

                                    <asp:Panel ID="pnlAuxiliar" runat="server" CssClass="FondoModal" Width="600px">
                                        <div>
                                            <div id="divHeader" class="ModalHeader">
                                                DETALLES DEL DELITO
                                            </div>
                                            <div style="height: 350px; position: relative; overflow: auto;">
                                            <table>
                                              <tr>
                                                     <td class="style78">
                                                         <asp:Label ID="lblUFI" runat="server" Text="UFI"></asp:Label>
                                                      </td>
                                                      
                                                      <td class="style78">
                                                         <asp:Label ID="lblResponsableUFI" runat="server" Text="Responsable"></asp:Label>
                                                      </td>
                                                      
                                                      <td class="style78">
                                                         <asp:Label ID="lblTitularUFI" runat="server" Text="Titular" ></asp:Label>
                                                      </td>
                                                      
                                                      <td class="style78">
                                                         <asp:Label ID="lblDepartamentoUFI" runat="server" Text="Departamento" ></asp:Label>
                                                      </td>
                                                      
                                                </tr>
                                                <tr>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtUFI" runat="server"  ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtResponsable" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtTitular" runat="server"  ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtDepartamento" runat="server"  ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td colspan = "4">
                                                  <asp:Label ID="lblDomicilio" runat="server" Text="DOMICILIO DEL DELITO"  > </asp:Label>
                                                </td>
                                                </tr>
                                                <tr>
                                                     <td class="style78">
                                                         <asp:Label ID="Label6" runat="server" Text="Calle" ></asp:Label>
                                                      </td>
                                                      
                                                      <td class="style78">
                                                         <asp:Label ID="Label7" runat="server" Text="Nro" ></asp:Label>
                                                      </td>
                                                      
                                                      <td class="style78">
                                                         <asp:Label ID="Label12" runat="server" Text="Piso" ></asp:Label>
                                                      </td>
                                                      
                                                      <td class="style78">
                                                         <asp:Label ID="Label13" runat="server" Text="Depto" ></asp:Label>
                                                      </td>
                                                      
                                                </tr>
                                                <tr>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtDomCalle" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtDomNro" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtDomPiso" runat="server"  ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="style78">
                                                        <asp:TextBox ID="txtDomDepto" runat="server"  ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                     <td class="style78" colspan="2">
                                                         <asp:Label ID="Label14" runat="server" Text="Localidad" ></asp:Label>
                                                      </td>
                                                      
                                                      <td class="style78" colspan="2">
                                                         <asp:Label ID="Label15" runat="server" Text="Partido" ></asp:Label>
                                                      </td>
                                                      
                                                                                                            
                                                </tr>
                                                <tr>
                                                    <td class="style78" colspan="2">
                                                        <asp:TextBox ID="txtDomLocalidad" runat="server"  ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td class="style78" colspan="2">
                                                        <asp:TextBox ID="txtDomPartido" runat="server"   ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                </table>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvPrueba" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                                CellSpacing="-1" Caption="LISTADO DE PRUEBAS" CaptionAlign="Left">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Clase Rastro" SortExpression="idClaseRastro">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label8" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseRastroManager.GetItem(Convert.ToInt32(Eval("idClaseRastro").ToString())).descripcion %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Estado Informe" SortExpression="idClaseEstadoInformeRastro">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseEstadoInformeRastroManager.GetItem(Convert.ToInt32(Eval("idClaseEstadoInformeRastro").ToString()), Convert.ToInt16(Request.QueryString["tipo"])).descripcion %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Susceptible Cotejo">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("SusceptibleCotejoRastro") %>'
                                                                                Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("SusceptibleCotejoRastro") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>

                                                            <asp:UpdatePanel ID="upDetalleBS" runat="server">
                                                                <ContentTemplate>
                                                                    <%--                                <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click1" />--%>
                                                                    <asp:GridView ID="gvBienesSustraidos" runat="server" AutoGenerateColumns="False"
                                                                        Caption="LISTADO DE BIENES SUSTRAIDOS" CaptionAlign="Left" CssClass="Grid" DataKeyNames="id"
                                                                        OnSelectedIndexChanged="gvBienesSustraidos_SelectedIndexChanged" 
                                                                        Width="100%" BackColor="White">
                                                                        <Columns>
                                                                            <asp:ButtonField CommandName="Select" Text="Detalle" />
                                                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                                                SortExpression="id" Visible="False" />
                                                                            <asp:BoundField DataField="idDelito" HeaderText="Delito" SortExpression="idDelito"
                                                                                Visible="false" />
                                                                            <asp:BoundField DataField="idCausa" HeaderText="IPP" SortExpression="idCausa" />
                                                                            <asp:TemplateField HeaderText="Bien Sustraido" SortExpression="idClaseBienSustraido">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTipoBS" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseBienSustraidoManager.GetItem(Convert.ToInt32(Eval("idClaseBienSustraido").ToString())).descripcion %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <asp:DetailsView ID="dvBSOtro" runat="server" AutoGenerateRows="False" CellPadding="4"
                                                                        DataKeyNames="id" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
                                                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                        <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
                                                                        <RowStyle BackColor="#E3EAEB" />
                                                                        <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
                                                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                        <Fields>
                                                                            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                                                            <asp:BoundField DataField="NroSerie" HeaderText="NroSerie" SortExpression="NroSerie" />
                                                                        </Fields>
                                                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#7C6F57" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:DetailsView>
                                                                    <asp:DetailsView ID="dvBSAnimal" runat="server" AutoGenerateRows="False" CellPadding="4"
                                                                        DataKeyNames="id" ForeColor="#333333" GridLines="None" Height="50px">
                                                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                        <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
                                                                        <RowStyle BackColor="#E3EAEB" />
                                                                        <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
                                                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                        <Fields>
                                                                            <asp:TemplateField HeaderText="Clase Ganado" SortExpression="idClaseGanado">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseGanadoManager.GetItem(Convert.ToInt32(Eval("idClaseGanado").ToString().ToLower())).descripcion %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                                                        </Fields>
                                                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#7C6F57" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:DetailsView>
                                                                    <asp:DetailsView ID="dvBSVehiculo" runat="server" AutoGenerateRows="False" CellPadding="4"
                                                                        DataKeyNames="id" ForeColor="#333333" GridLines="None" Height="50px">
                                                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                        <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
                                                                        <RowStyle BackColor="#E3EAEB" />
                                                                        <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
                                                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                        <Fields>
                                                                            <asp:TemplateField HeaderText="Marca" SortExpression="idMarcaVehiculo">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# MPBA.SIAC.Bll.MarcaVehiculoManager.GetItem(Convert.ToInt32(Eval("idMarcaVehiculo").ToString().ToLower())).Descripcion %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Modelo" SortExpression="idModeloVehiculo">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# MPBA.SIAC.Bll.ModeloVehiculoManager.GetItem(Convert.ToInt32(Eval("idModeloVehiculo").ToString().ToLower())).Descripcion %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Dominio" HeaderText="Dominio" SortExpression="Dominio" />
                                                                            <asp:BoundField DataField="NumeroChasis" HeaderText="Nro. Chasis" SortExpression="NumeroChasis" />
                                                                            <asp:BoundField DataField="NumeroMotor" HeaderText="Nro. Motor" SortExpression="NumeroMotor" />
                                                                            <asp:TemplateField HeaderText="Color" SortExpression="idColorVehiculo">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# MPBA.SIAC.Bll.ColorVehiculoManager.GetItem(Convert.ToInt32(Eval("idColorVehiculo").ToString().ToLower())).Descripcion %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="anio" HeaderText="Año" SortExpression="anio" />
                                                                            <asp:BoundField DataField="GNC" HeaderText="GNC" SortExpression="GNC" />
                                                                            <asp:BoundField DataField="IdentificacionGNC" HeaderText="Id. GNC" SortExpression="IdentificacionGNC" />
                                                                            <asp:TemplateField HeaderText="Vidrios" SortExpression="idClaseVidrioVehiculo">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager.GetItem(Convert.ToInt32(Eval("idClaseVidrioVehiculo").ToString().ToLower())).descripcion %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Fields>
                                                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#7C6F57" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:DetailsView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="padding-top: 10px; position: relative;">
                                                <asp:HiddenField ID="hfOkDetalles" runat="server" />
                                                <asp:HiddenField ID="hfExtender" runat="server" />
                                                <asp:ModalPopupExtender ID="hfExtender_ModalPopupExtender" runat="server" CancelControlID="btnOk"
                                                    DynamicServicePath="" Enabled="True" PopupControlID="pnlAuxiliar" PopupDragHandleControlID="divHeader"
                                                    TargetControlID="hfExtender" BackgroundCssClass="FondoOscuro" DropShadow="True">
                                                </asp:ModalPopupExtender>
                                                <table>
                                                <tr>
                                                <td>
                                                <asp:Button ID="btnOk" runat="server" CausesValidation="False" OnClick="btnOk_Click"
                                                    Text="Aceptar" UseSubmitBehavior="False" Width="100px" />
                                                    </td>
                                                    <td>
                                               <%-- <asp:Button ID="btnImprimirBusqueda" runat="server" Text="Imprimir" Width="100px" />--%>
                                                </td>
                                                </tr>
                                                </table>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </asp:Panel>
                        </asp:Panel>
                    </td>
                   
                
                </tr>
            </table>
        </div>
        <table class="style35">
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Errores Ocurridos:"
                        Width="193px" />
                                                    
                <table width="100%">
                <tr>
                <td align="center">
                
                    <asp:Label ID="label_visualiza" runat="server" Text="  Busca por los Criterios ingresados en todas las solapas.  Seleccione la opcion segun los datos resultantes" 
                        BackColor="#D4E8F7" ForeColor="#003300" BorderColor="#6699FF"  ToolTip="Con las condiciones definidas se visualizan los autores conocidos o Ignorados"
                        BorderStyle="Groove" Font-Bold="False" BorderWidth="3px" Width="34em"></asp:Label>
                
                     <br />
                    </td>  
                    </tr>
                    <tr>
                        <td align="center">
                          <asp:Button ID="btnBuscar" runat="server" Text="IPP segun Rastros" OnClick="btnBuscar_Click"
                                Width="109px" UseSubmitBehavior="False" Height="22px" 
                                
                                ToolTip="Despliega el detalle de los rastros, huellas, registros en Camaras de Seguridad, victimas que pueden reconocer a los autores y ADN" />
                               <asp:Button ID="btnMapaDelito" runat="server" 
                                Text="Mapa del Delito (Con Simbologia Modus Operandi)" OnClick="btnMapaDelito_Click"
                                Width="90px" UseSubmitBehavior="False" Height="22px" 
                                ToolTip="Despliega en el mapa los delitos sin diferenciar el Modus operandi" />
                                 <asp:Button ID="btnMapaDelitoSimbologia" runat="server" 
                                Text="Mapa del Delito Con Simbolos" OnClick="btnMapaDelitoSimbologia_Click"
                                Width="188px" UseSubmitBehavior="False" Height="22px" 
                                ToolTip="Despliega en el mapa un simbolo diferente para cada modus operandi" />
                              <asp:Button ID="btnAutores" visible="false"  onclick = "btnAutores_Click" UseSubmitBehavior="False"  runat="server" Text="Autores" Height="22px" 
                                  ToolTip="Despliega los autores Conocidos o Ignorados coincidentes con los filtros indicados" />
                                                            <asp:GridView ID="gvAutores" runat="server" 
                                AutoGenerateColumns="False" Caption="LISTADO DE AUTORES"
                                                                CaptionAlign="Left" CellSpacing="-1" DataKeyNames="id" 
                                                                EnableTheming="True" 
                                >
                                                                <Columns>
                                                                    <asp:BoundField DataField="Nro" HeaderText="Nro" SortExpression="Nro" />
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                                                                        SortExpression="Nombre" />
                                                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                                                                        SortExpression="Apellido" />
                                                                    <asp:TemplateField HeaderText="Edad" SortExpression="idClaseEdadAproximada">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label9" runat="server" 
                                                                                
                                                                                
                                                                                Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseEdadAproximadaManager.GetItem(Convert.ToInt32(Eval("idClaseEdadAproximada").ToString().ToLower())).descripcion %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sexo" SortExpression="idClaseSexo">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label10" runat="server" 
                                                                                
                                                                                
                                                                                Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseSexoManager.GetItem(Convert.ToInt32(Eval("idClaseSexo").ToString())).descripcion.ToLower() %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Rostro" SortExpression="idClaseRostro">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label11" runat="server" 
                                                                                
                                                                                
                                                                                Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseRostroManager.GetItem(Convert.ToInt32(Eval("idClaseRostro").ToString())).descripcion.ToLower() %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="CubiertoCon" HeaderText="Cubierto Con" 
                                                                        SortExpression="CubiertoCon" />
                                                                    <%--<asp:TemplateField HeaderText="Seña Part." 
                                                                        SortExpression="idClaseSeniaParticular">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label12" runat="server" 
                                                                                Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idClaseSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="UbicacionSeniaParticular" HeaderText="Lugar Seña" 
                                                                        SortExpression="UbicacionSeniaParticular" />
                                                                    <asp:TemplateField HeaderText="Lugar Tatuaje" 
                                                                        SortExpression="idClaseLugarDelCuerpo">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label13" runat="server" 
                                                                                Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idClaseLugarDelCuerpo").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Clase Tatuaje" SortExpression="idClaseTatuaje">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label14" runat="server" 
                                                                                Text='<%# MPBA.SIAC.Bll.ClaseTatuajeManager.GetItem(Convert.ToInt32(Eval("idClaseTatuaje").ToString())).descripcion.ToLower() %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="OtroTatuaje" HeaderText="OtroTatuaje" 
                                                                        SortExpression="OtroTatuaje" />
                                                                    <asp:BoundField DataField="OtraCaracteristica" HeaderText="OtraCarac." 
                                                                        SortExpression="OtraCaracteristica" />--%>
                                                                </Columns>
                                                            </asp:GridView>

                        </td>
                  
               
                </tr>


                <tr>
                <td align="center">
                  <br />
                <asp:Button ID="btnGuardarBusqueda" runat="server" Text="Guardar Busqueda" 
                        onclick="btnGuardarBusqueda_Click"  ToolTip="Guarde las búsquedas de uso frecuente"  Height="22px" />
                    <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver"
                        Height="22px" Visible="False" Width="64px" />

                 
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="64px" Height="22px"
                        OnClick="btnLimpiar_Click" UseSubmitBehavior="False" />
                    <asp:Button  ID="btnSalir" runat="server" Text="Salir" Height="22px" Width="64px"
                        UseSubmitBehavior="False" OnClick="btnSalir_Click" />
                    <!-- DIV con el MAPA del Delito -->
                                        
  
                </td>
            </tr>
                
        </table>
            <asp:Panel ID="pnlDescripcionBusqueda" runat="server" CssClass="FondoModal" 
        Width="250px">
        <div>
            <div id="divHeaderDescripcionBusqueda" class="ModalHeader">
                Guardar Busqueda</div>
            <div style="position: relative; overflow: auto;" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel runat="server" ID="upDescripcionBusqueda" >
                                <ContentTemplate>
                                    <br />
                             <asp:Label ID="lblDescripcionBusqueda" runat="server" Text="Descripcion:" 
                                        Font-Size="Small"></asp:Label>
                                        <asp:TextBox ID="txtDescripcionBusqueda" runat="server"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvDescripcionBusqueda" runat="server" ErrorMessage="Debe ingresar la descripcion"  
                                        ControlToValidate="txtDescripcionBusqueda" Enabled="False"></asp:RequiredFieldValidator>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                  
                 
                </table>
            </div>
            <div style="padding-top: 10px; position: relative;">
            
              <asp:Button ID="btnCancelarDescripcionBusqueda" runat="server" Text="Cancelar" 
                    Width="60px" CausesValidation="False" 
                    onclick="btnCancelarDescripcionBusqueda_Click" />
                <asp:Button ID="btnOkDescripcionBusqueda" runat="server" Text="OK" 
                    Width="60px" onclick="btnOkDescripcionBusqueda_Click" />
            </div>
        </div>
    </asp:Panel>
      <asp:HiddenField ID="hfDescripcionBusqueda" runat="server" 
                        />
        <asp:ModalPopupExtender ID="hfDescripcionBusqueda_ModalPopupExtender" runat="server"
            BackgroundCssClass="FondoOscuro" DropShadow="True" 
        DynamicServicePath="" Enabled="True"
            PopupControlID="pnlDescripcionBusqueda" TargetControlID="hfDescripcionBusqueda" Drag="True" 
        PopupDragHandleControlID="DivHeaderDescripcionBusqueda">
        </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlLugar" runat="server" DefaultButton="btnTraerLugar" 
                        CssClass="FondoModal" Width="350px">
                        <div>
                            <div id="divHeaderLocalidad" class="ModalHeader">
                                ELEGIR LOCALIDAD</div>
                            <div style="height: 250px; position: relative; overflow: auto;">
                                <asp:UpdatePanel ID="upLugarTraslado" runat="server">
                                    <ContentTemplate>
                                        <div style="height: 200px; overflow: auto">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLugarTraslado" runat="server" Text="Lugar"></asp:Label>
                                                        <asp:TextBox ID="txtLugar" runat="server" CausesValidation="True"></asp:TextBox>
                                                        <asp:Button ID="btnTraerLugar" runat="server" OnClick="btnTraerLugarTraslado_Click"
                                                            Text="Traer" Width="44px" />
                                                        <br />
                                                        <asp:Label ID="lblDemasiadosResultados" runat="server" ForeColor="#CC0000" Text="Demasiados resultados, amplie la busqueda"
                                                            Visible="False"></asp:Label>
                                                        <br />
                                                        <asp:GridView ID="gvLugar" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                            OnSelectedIndexChanged="gvLugar_SelectedIndexChanged">
                                                            <Columns>
                                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnElegirLugarTraslado" runat="server" CommandName="Select" Height="19px"
                                                                            Text="Elegir" Width="44px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                                    SortExpression="id" Visible="False" />
                                                                <asp:BoundField DataField="localidad" HeaderText="localidad" SortExpression="localidad" />
                                                                <asp:TemplateField HeaderText="Partido" SortExpression="Partido">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPartidoGrid" runat="server" Text='<%# MPBA.SIAC.Bll.PartidoManager.GetItem(Convert.ToInt32(Eval("partido").ToString())).partido %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CodigoPostal" HeaderText="CodigoPostal" SortExpression="CodigoPostal" />
                                                                <asp:TemplateField HeaderText="Provincia" SortExpression="Provincia">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProvinciaGrid" runat="server" Text='<%# MPBA.SIAC.Bll.ProvinciaManager.GetItem(Convert.ToInt32(Eval("Provincia").ToString())).provincia %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:GridView ID="gvVehiculos" runat="server" AutoGenerateColumns="False" Caption="LISTADO DE VEHICULOS"
                                                            CaptionAlign="Left" CellSpacing="-1" DataKeyNames="id" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Clase Vinculo" SortExpression="idClaseVinculoVehiculo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseVinculoVehiculoManager.GetItem(Convert.ToInt32(Eval("idClaseVinculoVehiculo").ToString())).descripcion.ToLower() %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Marca" SortExpression="idMarcaVehiculo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# MPBA.SIAC.Bll.MarcaVehiculoManager.GetItem(Convert.ToInt32(Eval("idMarcaVehiculo").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Modelo" SortExpression="idModeloVehiculo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# MPBA.SIAC.Bll.ModeloVehiculoManager.GetItem(Convert.ToInt32(Eval("idModeloVehiculo").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Dominio" HeaderText="Dominio" SortExpression="Dominio" />
                                                                <asp:BoundField DataField="NumeroChasis" HeaderText="Nro. Chasis" SortExpression="NumeroChasis" />
                                                                <asp:BoundField DataField="NumeroMotor" HeaderText="Nro. Motor" SortExpression="NumeroMotor" />
                                                                <asp:TemplateField HeaderText="Color" SortExpression="idColorVehiculo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# MPBA.SIAC.Bll.ColorVehiculoManager.GetItem(Convert.ToInt32(Eval("idColorVehiculo").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="anio" HeaderText="Año" SortExpression="anio" />
                                                                <asp:BoundField DataField="GNC" HeaderText="GNC" SortExpression="GNC" />
                                                                <asp:BoundField DataField="IdentificacionGNC" HeaderText="Id. GNC" SortExpression="IdentificacionGNC" />
                                                                <asp:TemplateField HeaderText="Vidrios" SortExpression="idClaseVidrioVehiculo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label5" runat="server" Text='<%#MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager.GetItem(Convert.ToInt32(Eval("idClaseVidrioVehiculo").ToString())).descripcion.ToLower() %>'></asp:Label>
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
                                        </div>
                                        <asp:UpdateProgress runat="server" ID="upWaitingBusquedaLocalidad" DisplayAfter="100">
                                <ProgressTemplate>
                                <asp:Panel ID="pnlWaitingOverlayBusquedaLocalidad" CssClass="" runat="server">
                                    <asp:Panel ID="pnlWaitingBusquedaLocalidad" CssClass="" runat="server">
                                        <asp:Image ID="imgWaitingBusquedaLocalidad" runat="server" ImageUrl="~/App_Images/loader.gif" />
                                    </asp:Panel>
                                </asp:Panel>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div style="padding-top: 10px; position: relative; top: 0px; left: 0px;">
                                <table width="100%">
                                    <tr style="text-align: center">
                                        <td>
                                            <asp:Button ID="btnCancelarLugar" runat="server" CausesValidation="False" OnClick="btnCancelarLugar_Click"
                                                Text="Cerrar" UseSubmitBehavior="False" Width="50px" />
                                            <br />
                                            <asp:HiddenField ID="hfLugar" runat="server" />
                                            <asp:HiddenField ID="hfAbrirLugar" runat="server" />
                                            <asp:ModalPopupExtender ID="hfAbrirLugar_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                                DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlLugar"
                                                TargetControlID="hfAbrirLugar" CancelControlID="btnCancelarLugar" OkControlID="hfLugar"
                                                Drag="True" PopupDragHandleControlID="divHeaderLocalidad">
                                            </asp:ModalPopupExtender>
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
                    <asp:Panel ID="pnlPartido" runat="server" DefaultButton="btnTraerPartido" 
                        CssClass="FondoModal" Width="350px">
                        <div>
                            <div id="divPartido" class="ModalHeader">
                                ELEGIR PARTIDO</div>
                            <div style="height: 250px; position: relative; overflow: auto;">
                                <asp:UpdatePanel ID="upPartido" runat="server">
                                    <ContentTemplate>
                                        <div style="height: 200px; overflow: auto">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblBuscaPartido" runat="server" Text="Partido"></asp:Label>
                                                        <asp:TextBox ID="txtPartido" runat="server" CausesValidation="True"></asp:TextBox>
                                                        <asp:Button ID="btnTraerPartido" runat="server" OnClick="btnTraerPartido_Click" Text="Traer"
                                                            Width="44px" />
                                                        <br />
                                                        <asp:Label ID="lblDemasiadosPartidos" runat="server" ForeColor="#CC0000" Text="Demasiados resultados, amplie la busqueda"
                                                            Visible="False"></asp:Label>
                                                        <br />
                                                        <asp:GridView ID="gvPartidos" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                            OnSelectedIndexChanged="gvPartidos_SelectedIndexChanged">
                                                            <Columns>
                                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnElegirPartido" runat="server" CommandName="Select" Height="19px"
                                                                            Text="Elegir" Width="44px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                                    SortExpression="id" Visible="False" />
                                                                <asp:BoundField DataField="partido" HeaderText="Partido" SortExpression="partido" />
                                                                <asp:TemplateField HeaderText="Provincia" SortExpression="idProvincia">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProvinciaGrid" runat="server" Text='<%# MPBA.SIAC.Bll.ProvinciaManager.GetItem(Convert.ToInt32(Eval("idProvincia").ToString())).provincia %>'></asp:Label>
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
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div style="padding-top: 10px; position: relative; top: 0px; left: 0px;">
                                <table width="100%">
                                    <tr style="text-align: center">
                                        <td>
                                            <asp:Button ID="btnCerrarPartido" runat="server" CausesValidation="False" OnClick="btnCerrarPartido_Click"
                                                Text="Cerrar" UseSubmitBehavior="False" Width="50px" />
                                            <br />
                                            <asp:HiddenField ID="hfPartido" runat="server" />
                                            <asp:HiddenField ID="hfAbrirPartido" runat="server" />
                                            <asp:ModalPopupExtender ID="hfAbrirPartido_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                                DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlPartido"
                                                TargetControlID="hfAbrirPartido" CancelControlID="btnCerrarPartido" OkControlID="hfPartido"
                                                Drag="True" PopupDragHandleControlID="divHeaderPartido">
                                            </asp:ModalPopupExtender>
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
                    <asp:Panel ID="pnlDeptoJud" runat="server" CssClass="FondoModal" Width="350px">
                        <div>
                            <div id="divDeptoJud" class="ModalHeader">
                                ELEGIR DEPARTAMENTO JUDICIAL</div>
                            <div style="height: 250px; position: relative; overflow: auto;">
                                <asp:UpdatePanel ID="upDeptoJud" runat="server">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: left">
                                                    <asp:CheckBoxList ID="cblDeptoJud" runat="server" DataSourceID="odsDeptoJud" DataTextField="departamento"
                                                        DataValueField="Id" RepeatColumns="2">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div style="padding-top: 10px; position: relative;">
                                <table width="100%">
                                    <tr style="text-align: center">
                                        <td>
                                            <asp:Button ID="btnAceptarDeptoJud" runat="server" CausesValidation="False" OnClick="btnAceptarDeptoJud_Click"
                                                Text="Aceptar" UseSubmitBehavior="False" />
                                            <asp:Button ID="btnCancelarDeptoJud" runat="server" CausesValidation="False" Text="Cancelar"
                                                UseSubmitBehavior="False" />
                                            <asp:HiddenField ID="hfAbrirDeptoJud" runat="server" />
                                            <asp:ModalPopupExtender ID="hfAbrirDeptoJud_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                                CancelControlID="btnCancelarDeptoJud" Drag="True" DropShadow="True" DynamicServicePath=""
                                                Enabled="True" OkControlID="btnAceptarDeptoJud" PopupControlID="pnlDeptoJud"
                                                PopupDragHandleControlID="divHeaderDeptoJud" TargetControlID="hfAbrirDeptoJud">
                                            </asp:ModalPopupExtender>
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
                    <asp:Panel ID="pnlComisariasH" runat="server" CssClass="FondoModal" Width="350px">
                        <div>
                            <div id="divHeaderComisaria" class="ModalHeader">
                                ELEGIR COMISARIA</div>
                            <div style="height: 250px; position: relative; overflow: auto;">
                                <asp:UpdatePanel ID="upComisaria" runat="server">
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
                                                    <asp:ObjectDataSource ID="odsDepartamento" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento"
                                                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                                                        TypeName="MPBA.SIAC.Bll.DepartamentoManager" UpdateMethod="Save">
                                                    </asp:ObjectDataSource>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvComisariasH" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                        Height="156px" OnSelectedIndexChanged="gvComisariasH_SelectedIndexChanged" PageSize="4"
                                                        Width="400px">
                                                        <RowStyle HorizontalAlign="Left" />
                                                        <Columns>
                                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
                                                                        Height="18px" Text="Elegir" Width="41px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                                SortExpression="id" Visible="False" />
                                                            <asp:BoundField DataField="comisaria" HeaderText="Comisaria" SortExpression="comisaria" />
                                                            <asp:BoundField DataField="idDepartamento" HeaderText="idDepartamento" SortExpression="idDepartamento"
                                                                Visible="False" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div style="padding-top: 10px; position: relative;">
                                <table width="100%">
                                    <tr style="text-align: center">
                                        <td>
                                            <asp:Button ID="btnCancelarComisariaH" runat="server" CausesValidation="False" OnClick="btnCancelarComisariaL_Click"
                                                Text="Cancelar" UseSubmitBehavior="False" />
                                            <asp:HiddenField ID="hfComisaria" runat="server" />
                                            <asp:HiddenField ID="hfAbrirComisaria" runat="server" />
                                            <asp:ModalPopupExtender ID="hfAbrirComisaria_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                                CancelControlID="btnCancelarComisariaH" Drag="True" DropShadow="True" DynamicServicePath=""
                                                Enabled="True" OkControlID="hfComisaria" PopupControlID="pnlComisariasH" PopupDragHandleControlID="divHeaderComisaria"
                                                TargetControlID="hfAbrirComisaria">
                                            </asp:ModalPopupExtender>
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
     
                  <div id="autores" style="visibility:hidden;width: 920px;">
                
                         <div id="divAp" style="visibility:hidden;margin-left:0px;margin-top:10px;margin-top:30px; margin-bottom: 0px;" >
                         <h3 id="H5" style="background-color:#186BA9 ;color:White;">Autores</h3>   
                                  <div id="espera" style="vertical-align:middle">
                                            <img alt="Esperar" src="../App_Images/wait.gif" />
                                     </div>
                        </div>   
                   
                   </div>          
               
   
        <asp:ObjectDataSource runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRubro"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRubroManager"
            UpdateMethod="Save" ID="ObjectDataSourceClaseRubro"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsColorMO" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ColorVehiculo"
            DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
            TypeName="MPBA.SIAC.Bll.ColorVehiculoManager" UpdateMethod="Save">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseBienSustraido"
            DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
            TypeName="MPBA.AutoresIgnorados.Bll.NNClaseBienSustraidoManager" UpdateMethod="Save"
            ID="odsClaseBienSustraido"></asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseMomentoDia"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseMomentoDiaManager"
            UpdateMethod="Save" ID="ObjectDataSourceClaseMomentoDelDia"></asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseLugar"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseLugarManager"
            UpdateMethod="Save" ID="ObjectDataSourceClaseLugar"></asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseModusOperandi"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseModusOperandiManager"
            UpdateMethod="Save" ID="ObjectDataSourceClaseModusOperandis"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsDeptoJud" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento"
            DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
            TypeName="MPBA.SIAC.Bll.DepartamentoManager" UpdateMethod="Save">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseVidrio" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseVidrioVehiculo"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseModoArriboHuida" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseModoArriboHuida"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseModoArriboHuidaManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseCantidadAutores" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseCantidadAutores"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseCantidadAutoresManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseEdadAproximada" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseEdadAproximada"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseEdadAproximadaManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseSexo" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseSexo"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseSexoManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:HiddenField ID="hfComisariaH" runat="server" />
        <asp:ObjectDataSource ID="odsColorBS" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ColorVehiculo"
            DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
            TypeName="MPBA.SIAC.Bll.ColorVehiculoManager" UpdateMethod="Save">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceRostro" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRostro"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRostroManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSeniaParticular" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" 
            TypeName="MPBA.SIAC.Bll.ClaseSeniaParticularManager" 
            ></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceLugarCuerpo" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" 
            TypeName="MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceTipoTatuaje" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseTatuaje"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.ClaseTatuajeManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseVidrioAutoSustraido" runat="server"
            DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseVidrioVehiculo"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseGanado" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseGanado"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseGanadoManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceClaseBoolaen" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseBoolean"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseBooleanManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsMisBusquedas" runat="server" 
                                                DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.BusquedaRobosDelitosSexuales" 
                                                DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
                                                SelectMethod="GetListByIdPuntoGestionTipoDelito" 
                                                TypeName="MPBA.AutoresIgnorados.Bll.BusquedaRobosDelitosSexualesManager" 
                                                UpdateMethod="Save">
                <SelectParameters>
                    <asp:SessionParameter Name="idPuntoGestion" SessionField="idPuntoGestion" 
                        Type="String" />
                    <asp:QueryStringParameter Name="tipoDelito" QueryStringField="tipo" 
                        Type="Int32" />
                </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseEstatura" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICCLaseEstatura"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICCLaseEstaturaManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSourceSICClaseRobustez" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseRobustez"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseRobustezManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSicClaseTipoCalvicie" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.SIAC.SicClaseTipoCalvicie"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SicClaseTipoCalvicieManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseColorOjos" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.SIAC.SICClaseColorOjos"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseColorOjosManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseColorPiel" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.SIAC.SICClaseColorPiel"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseColorPielManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICCLaseColorCabello" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICCLaseColorCabello"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICCLaseColorCabelloManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseTipoCabello" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseTipoCabello"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseTipoCabelloManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseCejaDimension" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseCejasDimension"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseCejasDimensionManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseCejaTipo" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseCejasTipo"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseCejasTipoManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseFormaBoca" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaBoca"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaBocaManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseFormaCara" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaCara"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaCaraManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseFormaLabioInferior" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaLabioInferior"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaLabioInferiorManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseFormaLabioSuperior" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ICClaseFormaLabioSuperior"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaLabioSuperiorManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseFormaMenton" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaMenton"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaMentonManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseFormaNariz" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaNariz"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaNarizManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odsSICClaseFormaOreja" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaOreja"
            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaOrejaManager"
            UpdateMethod="Save"></asp:ObjectDataSource>
    </div>
</asp:Content>
