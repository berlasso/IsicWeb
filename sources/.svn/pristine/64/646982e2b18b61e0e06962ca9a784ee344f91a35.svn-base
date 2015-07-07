<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="True"
    CodeBehind="BusquedaGenerica.aspx.cs" Inherits="MPBA.PersonasBuscadas.Web.BusquedaGenerica"
    Culture="es-AR" UICulture="es-AR" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
 
    <style type="text/css">
        .style2
        {
            text-align: left;
            
        }
        .fotos
        {color:rgb(61, 132, 172) !important;
         font-size: 1.2em !important;
            }
            
            
          
    </style>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">


  <script type="text/javascript">
      function btnOkCantCoincidencias() {
          document.getElementById("accordion").style.visibility = 'visible';
              
          $("#accordion").accordion({
              collapsible: true
          });
        
      };

      $(document).ready(function () {



          $("#ctl00_Main_divResultados").removeClass();
          $("#ctl00_Main_divResultados").addClass("ui-accordion-content ui-helper-reset ui-corner-bottom ui-widget-content  ui-accordion-content-active");
          $("#accordion").removeClass();
          $("#accordion").addClass("ui-accordion ui-widget ui-helper-reset");
          $("#ResultadoBusqueda").removeClass();

          $("#ResultadoBusqueda").addClass("ui-accordion-header ui-helper-reset ui-state-default ui-accordion-icons ui-accordion-header-active ui-state-active ui-corner-top");
          $("#pnlResultados").addClass("FondoModal");
        

          $("#btnVerFotos").click(function () {
              $('#btnVerFotos').toggle();
              var pagina = "../PBFotos/FotoPersonalPagina";
              $("#mvcpartial").load(pagina);
            
              $(".fotos").show();
            
              $("#mvcpartial").show();
              $('#espera').toggle();
          });

          $("#accordion").accordion({
              collapsible: true
          });
      });
   </script>




    <table width="100%" style="padding: 10px">
        <tr>
            <td width="90%">
            </td>
            <td style="text-align: center">
                <asp:UpdatePanel ID="upFavoritos" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="btnBusquedasFavoritas" runat="server" OnClick="btnBusquedasFavoritas_Click"
                            CausesValidation="False">Mis Búsquedas</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upBuscar" runat="server">
    <ContentTemplate>
    <div style="overflow: auto;">
    <div align="left">
     <div align="left"  style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelTipoBusqueda" runat="server" align="center">
                    BUSCAR POR ...</h3>
            </div>
    </div>
        <asp:Button ID="btnBuscarIpp" runat="server" Text="Buscar Por IPP" OnClick="btnBuscarIpp_Click"
            Width="100px" CausesValidation="False" />
        <asp:Button ID="btnBuscarOtros" runat="server" Text="Buscar Por Otros" OnClick="btnBuscarOtros_Click"
            Width="100px" CausesValidation="False" />
        <br />
        <table id="tblBuscarIpp" runat="server" class="style2" width="100%" style="border-width: thin;
            border-top-style: solid; border-color: #000000" bgcolor="#E3DEE4">
            <tr>
                <td>
                    <asp:Label ID="lblIppB" runat="server">IPP</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIppB" runat="server" Width="114px"></asp:TextBox><br />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table id="tblBuscarOtros" runat="server" class="style2" width="98%" style="border-width: thin;
            border-top-style: solid; border-color: #000000" bgcolor="#C0D7D8">
            <tr>
                <td>
                    <asp:Label ID="lblAdnB" runat="server">Tiene ADN</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAdnB" runat="server" DataSourceID="odsBooleano" DataTextField="Descripcion"
                        DataValueField="Id">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblFechaDesdeB" runat="server">Fecha Desde</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaDesdeB" runat="server"></asp:TextBox><asp:MaskedEditExtender
                        ID="txtFechaDesdeB_MaskedEditExtender" runat="server" AutoComplete="False" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaDesdeB"
                        MessageValidatorTip="False">
                    </asp:MaskedEditExtender>
                    <asp:ImageButton ID="btnFechaDesdeB" runat="server" Height="16px" ImageUrl="~/App_Images/calendar.png"
                        Width="17px" CausesValidation="False" />
                    <asp:CalendarExtender ID="txtFechaDesdeB_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="txtFechaDesdeB" PopupButtonID="btnFechaDesdeB" Format="dd/MM/yyyy"
                        TodaysDateFormat="d MMMM, yyyy">
                    </asp:CalendarExtender>
                    <asp:MaskedEditValidator ID="mevFechaDesdeB" runat="server" ControlExtender="txtFechaDesdeB_MaskedEditExtender"
                        ControlToValidate="txtFechaDesdeB" ErrorMessage="mevFechaDesde" InvalidValueMessage="Fecha incorrecta"></asp:MaskedEditValidator>
                </td>
                <td>
                    <asp:Label ID="lblFechaHastaB" runat="server">Fecha Hasta</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaHastaB" runat="server"></asp:TextBox><asp:MaskedEditExtender
                        ID="txtFechaHastaB_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaHastaB">
                    </asp:MaskedEditExtender>
                    <asp:ImageButton ID="btnFechaHastaB" runat="server" Height="16px" ImageUrl="~/App_Images/calendar.png"
                        Width="17px" CausesValidation="False" />
                    <asp:CalendarExtender ID="txtFechaHastaB_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="txtFechaHastaB" PopupButtonID="btnFechaHastaB" TodaysDateFormat="d MMMM, yyyy"
                        Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                    <asp:MaskedEditValidator ID="mevFechaHastaB" runat="server" ControlExtender="txtFechaHastaB_MaskedEditExtender"
                        ControlToValidate="txtFechaHastaB" EmptyValueMessage="Ingrese una fecha" ErrorMessage="Fecha incorrecta"
                        InvalidValueMessage="mevFechaHasta" TooltipMessage="Ingrese una fecha"></asp:MaskedEditValidator>
                    <asp:CustomValidator ID="cvFechas" runat="server" ControlToValidate="txtFechaDesdeB"
                        ErrorMessage="Rango de fechas inválido"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEdadDesdeB" runat="server">Edad Desde</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEdadDesdeB" runat="server"></asp:TextBox><asp:MaskedEditExtender
                        ID="txtEdadDesdeB_MaskedEditExtender" runat="server" AutoComplete="False" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtEdadDesdeB">
                    </asp:MaskedEditExtender>
                    <asp:MaskedEditValidator ID="mevEdadDesdeB" runat="server" ControlExtender="txtEdadDesdeB_MaskedEditExtender"
                        ControlToValidate="txtEdadDesdeB" ErrorMessage="mevEdadDesdeB" InvalidValueMessage="Rango de edad incorrecto"></asp:MaskedEditValidator>
                </td>
                <td>
                    <asp:Label ID="lblEdadHastaB" runat="server">Edad Hasta</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEdadHastaB" runat="server"></asp:TextBox><asp:MaskedEditExtender
                        ID="txtEdadHastaB_MaskedEditExtender" runat="server" AutoComplete="False" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtEdadHastaB">
                    </asp:MaskedEditExtender>
                    <asp:MaskedEditValidator ID="mevEdadHastaB" runat="server" ControlExtender="txtEdadHastaB_MaskedEditExtender"
                        ControlToValidate="txtEdadHastaB" ErrorMessage="mevEdadHastaB" InvalidValueMessage="Rango de edad incorrecto"></asp:MaskedEditValidator><asp:CustomValidator
                            ID="cvEdades" runat="server" ControlToValidate="txtEdadHastaB" ErrorMessage="Rango de edad inválido"></asp:CustomValidator>
                </td>
                <td>
                    <asp:Label ID="lblSexoB" runat="server">Sexo</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstSexoB" runat="server" DataSourceID="odsSexo" DataTextField="Descripcion"
                        DataValueField="Id" Height="44px" SelectionMode="Multiple">
                        </asp:ListBox>
                        <br />
                        <asp:Button ID="btnLimiparListSexo" runat="server" Text="Desseleccionar" 
                        Font-Size="XX-Small" Height="20px" onclick="btnLimiparListSexo_Click" 
                        Width="80px" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTallaDesdeB" runat="server">Talla Desde</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTallaDesdeB" runat="server"></asp:TextBox><asp:MaskedEditExtender
                        ID="txtTallaDesdeB_MaskedEditExtender" runat="server" AutoComplete="False" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtTallaDesdeB">
                    </asp:MaskedEditExtender>
                    <asp:MaskedEditValidator ID="mevTallaDesdeB" runat="server" ControlExtender="txtTallaDesdeB_MaskedEditExtender"
                        ControlToValidate="txtTallaDesdeB" ErrorMessage="mevTallaDesdeB" InvalidValueMessage="Rango de tallas incorrecto"></asp:MaskedEditValidator>
                </td>
                <td>
                    <asp:Label ID="lblTallaHastaB" runat="server">Talla Hasta</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTallaHastaB" runat="server"></asp:TextBox><asp:MaskedEditExtender
                        ID="txtTallaHastaB_MaskedEditExtender" runat="server" AutoComplete="False" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtTallaHastaB">
                    </asp:MaskedEditExtender>
                    <asp:MaskedEditValidator ID="mevTallaHastaB" runat="server" ControlExtender="txtTallaHastaB_MaskedEditExtender"
                        ControlToValidate="txtTallaHastaB" ErrorMessage="mevTallaHastaB" InvalidValueMessage="Rango de talla incorrecto"></asp:MaskedEditValidator><asp:CustomValidator
                            ID="cvTallas" runat="server" ControlToValidate="txtTallaHastaB" ErrorMessage="Rango de talla inválido"></asp:CustomValidator>
                </td>
                <td>
                    <asp:Label ID="lblFaltanPiezasDentalesB" runat="server">Faltan Dientes</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlFaltanPiezasDentalesB" runat="server" DataSourceID="odsBooleano"
                        DataTextField="Descripcion" DataValueField="Id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPesoDesdeB" runat="server">Peso Desde</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPesoDesdeB" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtPesoDesdeB_MaskedEditExtender" runat="server" AutoComplete="False"
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                        CultureTimePlaceholder="" Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtPesoDesdeB">
                    </asp:MaskedEditExtender>
                    <asp:MaskedEditValidator ID="mevPesoDesdeB" runat="server" ControlExtender="txtPesoDesdeB_MaskedEditExtender"
                        ControlToValidate="txtPesoDesdeB" ErrorMessage="mevPesoDesdeB" InvalidValueMessage="Rango de peso incorrecto"></asp:MaskedEditValidator>
                </td>
                <td>
                    <asp:Label ID="lblPesoHastaB" runat="server">Peso Hasta</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPesoHastaB" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtPesoHastaB_MaskedEditExtender" runat="server" AutoComplete="False"
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                        CultureTimePlaceholder="" Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtPesoHastaB">
                    </asp:MaskedEditExtender>
                    <asp:MaskedEditValidator ID="mevPesoHastaB" runat="server" ControlExtender="txtPesoHastaB_MaskedEditExtender"
                        ControlToValidate="txtPesoHastaB" ErrorMessage="mevPesoHastaB" InvalidValueMessage="Rango de peso incorrecto">
                    </asp:MaskedEditValidator>
                    <asp:CustomValidator ID="cvPeso" runat="server" ControlToValidate="txtPesoHastaB"
                        ErrorMessage="Rango de peso inválido"></asp:CustomValidator>
                </td>
                <td>
                    <asp:Label ID="lblColorPielB" runat="server">Color Piel</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstColorPielB" runat="server" DataSourceID="odsColorPiel" DataTextField="Descripcion"
                        DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblColorCabelloB" runat="server">Color Cabello</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstColorCabelloB" runat="server" DataSourceID="odsColorCabello"
                        DataTextField="Descripcion" DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td>
                    <asp:Label ID="lblColorTenidoB" runat="server">Color Teñido</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstColorTenidoB" runat="server" DataSourceID="odsColorTenido" DataTextField="Descripcion"
                        DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td>
                    <asp:Label ID="lblLongitudCabelloB" runat="server">Longitud Cabello</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstLongitudCabelloB" runat="server" DataSourceID="odsLongitudCabello"
                        DataTextField="Descripcion" DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAspectoCabelloB" runat="server">Aspecto Cabello</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstAspectoCabelloB" runat="server" DataSourceID="odsAspectoCabello"
                        DataTextField="Descripcion" DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td>
                    <asp:Label ID="lblCalvicieB" runat="server">Calvicie</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstCalvicieB" runat="server" DataSourceID="odsCalvicie" DataTextField="Descripcion"
                        DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                </td>
                <td>
                    <asp:Label ID="lblColorOjosB" runat="server">Color Ojos</asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="lstColorOjosB" runat="server" DataSourceID="odsColorOjos" DataTextField="Descripcion"
                        DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
                  <tr>
                <td>
                    <asp:Label ID="lblApellidoB" runat="server">Apellido</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtApellidoB" runat="server"></asp:TextBox><br />
             
                </td>
                <td>
                 <asp:Label ID="lblNombresB" runat="server">Nombres</asp:Label>
                </td>
                <td align="left">
                  <asp:TextBox ID="txtNombresB" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label24" runat="server">Señas Particulares</asp:Label>
                </td>
                <td colspan="3">
                    <asp:GridView ID="gvSenasPartB" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                        OnRowEditing="gvSenasPart_RowEditing" ShowFooter="True" OnRowCancelingEdit="gvSenasPart_RowCancelingEdit"
                        OnRowDeleting="gvSenasPart_RowDeleting" 
                        OnRowUpdating="gvSenasPart_RowUpdating" BorderColor="Black">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                SortExpression="id" Visible="False" />
                            <asp:BoundField DataField="idPersona" HeaderText="idPersona" SortExpression="idPersona"
                                Visible="False" />
                            <asp:TemplateField HeaderText="Seña" SortExpression="idSeniaParticular">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSeniaPart" runat="server" DataSourceID="odsSeniaParticular"
                                        DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Eval("idSeniaParticular") %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlSeniaPartInsert" runat="server" DataSourceID="odsSeniaParticular"
                                        DataTextField="Descripcion" DataValueField="Id">
                                    </asp:DropDownList>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionSeniaParticular">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlUbicacionSenaPart" runat="server" DataSourceID="odsUbicacionSeniaParticular"
                                        DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Eval("idUbicacionSeniaParticular") %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlUbicacionSenaPartInsert" runat="server" DataSourceID="odsUbicacionSeniaParticular"
                                        DataTextField="Descripcion" DataValueField="Id">
                                    </asp:DropDownList>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" SortExpression="idTablaDestino"
                                Visible="False" />
                                  <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="Ok" CommandArgument="B"></asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkButton2"
                                            runat="server" CausesValidation="False" CommandName="Cancel" Text="X" CommandArgument="B"></asp:LinkButton></EditItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="btnAgregarSenia" runat="server" CausesValidation="False" OnClick="btnAgregarSenia_Click"
                                        Text="Incorporar" CommandArgument="B"></asp:LinkButton></FooterTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Editar" CommandArgument="B"></asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkButton2"
                                            runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" CommandArgument="B"></asp:LinkButton></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>
                                     <asp:Label runat="server" ID="lblSeniaPartH" Text="Seña"></asp:Label>
                                    </td>
                                    <td>
                                       <asp:Label runat="server" ID="lblUbicacionSeniaPartH" Text="Ubicación"></asp:Label>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                   
                                    <td>
                                        <asp:DropDownList ID="ddlSenasParticulares" runat="server" DataSourceID="odsSeniaParticular"
                                            DataTextField="Descripcion" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUbicacionSenasPart" runat="server" DataSourceID="odsUbicacionSeniaParticular"
                                            DataTextField="Descripcion" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                     <td>
                                        <asp:LinkButton runat="server" ID="btnSend" Text="Incorporar" CommandName="EmptyInsert"
                                            UseSubmitBehavior="false" OnClick="btnAgregarPrimeraSenia_Click" CommandArgument="B" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
                <td>
                </td>
                <td>
                </td>
                </tr>
          
         
         
        </table>
        <table width="98%" bgcolor="#D3E2D8">
            <tr>
                <td width="25%">
                </td>
                <td>
                    <asp:Label ID="lblTipoBusqueda" runat="server" Font-Bold="True" Font-Size="Small"
                        Text="Tipo Busqueda"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="True" DataSourceID="odsTipoBusqueda"
                        DataTextField="Descripcion" DataValueField="Id" Font-Bold="True" Font-Size="Small"
                        OnSelectedIndexChanged="ddlTipoBusqueda_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td width="25%">
                </td>
            </tr>
               <tr>
                <td colspan="6" align="center">
                    <asp:Label ID="lblAyudaSeleccionMultiple" runat="server" Text="Ayuda: -Para seleccionar varios items de las listas, tenga pulsada CTRL + click botón izquierdo sobre los items elegidos. Para desseleccionar: CTRL + botón izquierdo en el item deseado."
                        ForeColor="#666633" style="text-align: left"></asp:Label>
                </td>
            </tr>
        
        </table>
    </div>
  
    
        <div style="overflow: auto;" visible="false">
            <asp:Button ID="btnBorrarBusqueda" runat="server" OnClick="btnBorrarBusqueda_Click"
                Text="Borrar Busqueda" Width="110px" Visible="False" />
            <asp:Button ID="btnGuardarBusqueda" runat="server" OnClick="btnGuardarBusqueda_Click"
                Text="Guardar Busqueda" Width="110px" />
            <br />
            <asp:Label ID="lblGuardoExitoB" runat="server" ForeColor="#009933" Text="Se guardó existósamente"
                Visible="False"></asp:Label>
        </div>
        <div style="border: 1px solid #00CCFF; width: 350px;">
            <asp:Button ID="btnLimpiarB" runat="server" Text="Limpiar" 
                OnClick="btnLimpiarB_Click" Width="105px" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                Font-Bold="True" Font-Underline="True" Width="105px" />
               
               
            <asp:ConfirmButtonExtender ID="btnBuscar_ConfirmButtonExtender" runat="server" ConfirmText="Guarda la búsqueda?"
                Enabled="False" TargetControlID="btnBuscar">
            </asp:ConfirmButtonExtender>
           <asp:Button ID="btnSalir" runat="server" Text="Salir" Height="22px" Width="105px"
                                        UseSubmitBehavior="False" OnClick="btnSalir_Click" />
        </div>
        <br />
        <div align="left">
        <asp:Button runat="server" ID="btnAgregarBusquedaFavoritos" Text="Agregar a Mis Búsquedas"
                    OnClick="btnAgregarBusquedaFavoritos_Click" Width="157px" /><br />
                    <asp:Label runat="server" ID="lblCantResultados" Text="Resultados Encontrados"></asp:Label>
          </div>
    
            
        <div id="accordion" style="visibility:hidden; "> 
        <h3 id="ResultadoBusqueda" style="color:rgb(61, 132, 172);font-size: 1.2em;"> Resultado de la Búsqueda</h3>   
             <div id="divResultados" runat="server" align="left" 
                                style="overflow: auto;  margin-left: 0px; width: 950px; ">
                  <asp:Panel ID="pnlResultados" runat="server" CssClass="FondoModal" Width = "948px" style = "overflow:auto" >
                    <asp:GridView ID="gvResultadoBusquedaPersonasDesap" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="Id" OnSelectedIndexChanged="gvResultadoBusqueda_SelectedIndexChanged"
                    Caption="PERSONAS DESAPARECIDAS" CaptionAlign="Top"
                    OnRowDeleting="gvResultadoBusquedaParsonasDesap_RowDeleting">
                    <Columns>
                        <asp:CommandField CancelText="X" DeleteText="X" EditText="Editar" 
                                                InsertText="Insertar" InsertVisible="False" NewText="Nuevo" SelectText="Ver" 
                                                ShowCancelButton="False" ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Mis Busquedas" Visible="False">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkFavoritosD" runat="server" />
                                <asp:HiddenField ID="hfFavoritasD" Value='<%# Bind("Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="X" DeleteText="Borrar" EditText="Editar" InsertText="Insertar"
                            NewText="Nuevo" SelectText="Ver" ShowDeleteButton="False" 
                            Visible="False" />
                        <asp:TemplateField Visible="false" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="Borrar" OnClientClick="return confirm('Esta seguro?');"></asp:LinkButton></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                            SortExpression="Id" Visible="False" />
                        <asp:CheckBoxField DataField="esExtJurisdiccion" HeaderText="Ext.Jur." />
                        <asp:BoundField DataField="Ipp" HeaderText="IPP" SortExpression="Ipp" />
                        <asp:BoundField DataField="CoincidenciaCantidad" HeaderText="Coincidencias" SortExpression="CoincidenciaCantidad" />
                        <asp:BoundField DataField="UFI" HeaderText="UFI" SortExpression="UFI" Visible="False" />
                        <asp:TemplateField HeaderText="Señas Part." SortExpression="CoincidenciasSeniasParticulares">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Eval("CoincidenciaSeniasParticulares").ToString()%>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSenasPartGridD" runat="server" Text='<%#Eval("CoincidenciaSeniasParticulares").ToString() %>' ForeColor='<%# Convert.ToInt32(Eval("CoincidenciaSeniasParticulares").ToString())>0?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Eval("Apellido") + " " + Eval("Nombre") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoGridD" runat="server" Text='<%# Eval("Apellido") + " " + Eval("Nombre") %>' ForeColor='<%# Eval("coincidenciaNombreyApellido").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Org.Int." SortExpression="idOrganismoInterviniente">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("idOrganismoInterviniente") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseOrganismoIntervinienteManager.GetItem(Convert.ToInt32(Eval("idOrganismoInterviniente").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comisaria" SortExpression="idComisaria">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idComisaria") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#MPBA.SIAC.Bll.ComisariaManager.GetItem(Convert.ToInt32(Eval("idComisaria").ToString())).comisaria.ToLower() %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lugar Desap." SortExpression="idLugarDesaparicion">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("idLugarDesaparicion") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#MPBA.SIAC.Bll.LocalidadManager.GetItem(Convert.ToInt32(Eval("idLugarDesaparicion").ToString())).localidad.ToLower() %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Desap." SortExpression="FechaDesaparicion">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("FechaDesaparicion") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label25" runat="server" Text='<%# Eval("FechaDesaparicion")==null?"":Convert.ToDateTime(Eval("FechaDesaparicion")).ToString("dd/MM/yyyy") %>'
                                    ForeColor='<%# Eval("coincidenciaFecha").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaSexo").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nac." SortExpression="FechaNacimiento" />
                        <%-- <asp:BoundField DataField="EdadMomentoDesaparicion" HeaderText="Edad Desap." SortExpression="EdadMomentoDesaparicion" />--%>
                        <asp:TemplateField HeaderText="Edad Desap." SortExpression="EdadMomentoDesaparicion">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("EdadMomentoDesaparicion") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("EdadMomentoDesaparicion") %>'
                                    ForeColor='<%# Eval("CoincidenciaEdad").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" />
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" />--%>
                        <asp:TemplateField HeaderText="Talla" SortExpression="Talla">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label30" runat="server" Text='<%# Bind("Talla") %>' ForeColor='<%# Eval("coincidenciaTalla").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Peso" SortExpression="Peso">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Peso") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Bind("Peso") %>' ForeColor='<%# Eval("CoincidenciaPeso").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'
                                    Font-Bold='<%# Eval("CoincidenciaPeso").ToString()=="1"?true:false %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Faltan Dientes" SortExpression="FaltanPiezasDentales">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("FaltanPiezasDentales") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("FaltanPiezasDentales").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaFaltanDientes").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Piel" SortExpression="idColorPiel">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("idColorPiel") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseColorDePielManager.GetItem(Convert.ToInt32(Eval("idColorPiel").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorPiel").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Cabello" SortExpression="idColorCabello">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("idColorCabello") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorCabello").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorCabello").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Tenido" SortExpression="idColorTenido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("idColorTenido") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorTenido").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorTenido").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Long. Cabello" SortExpression="idLongitudCabello">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("idLongitudCabello") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(Eval("idLongitudCabello").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaLongitudCabello").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Aspecto Cabello" SortExpression="idAspectoCabello">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("idAspectoCabello") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(Eval("idAspectoCabello").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaAspectoCabello").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Calvicie" SortExpression="idCalvicie">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("idCalvicie") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseCalvicieManager.GetItem(Convert.ToInt32(Eval("idCalvicie").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaCalvicie").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Ojos" SortExpression="idColorOjos">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("idColorOjos") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorOjosManager.GetItem(Convert.ToInt32(Eval("idColorOjos").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorOjos").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CantidadDiasNoAfeitado" HeaderText="Dias No Afeitado"
                            SortExpression="CantidadDiasNoAfeitado" />
                        
                        </Columns>
                </asp:GridView>
                    <asp:GridView ID="gvResultadoBusquedaPersonasHalladas" runat="server" AutoGenerateColumns="False"
                    Caption="PERSONAS HALLADAS" CaptionAlign="Top"
                    DataKeyNames="Id" OnRowDeleting="gvResultadoBusquedaParsonasHalladas_RowDeleting"
                    OnSelectedIndexChanged="gvResultadoBusqueda_SelectedIndexChanged" width= "1050px" >
                    <Columns>
                        <asp:TemplateField HeaderText="Favoritos" Visible="False">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkFavoritosH" runat="server" />
                                <asp:HiddenField ID="hfFavoritasH" Value='<%# Bind("Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:CommandField CancelText="X" DeleteText="Borrar" EditText="Editar" InsertText="Insertar"
                            NewText="Nuevo" SelectText="Ver" ShowDeleteButton="False" 
                            Visible="False" />--%>
                        <asp:CommandField CancelText="X" DeleteText="X" EditText="Editar" InsertText="Insertar"
                                                NewText="Nuevo" SelectText="Ver" ShowSelectButton="True" ShowDeleteButton="False" />
                        <asp:TemplateField ShowHeader="False" Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('Esta seguro?');" Text="Borrar"></asp:LinkButton></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                            SortExpression="Id" Visible="False" />
                        <asp:CheckBoxField DataField="esExtJurisdiccion" HeaderText="Ext.Jur." />
                        <asp:BoundField DataField="Ipp" HeaderText="IPP" SortExpression="Ipp" />
                        <asp:BoundField DataField="CoincidenciaCantidad" HeaderText="Coincidencias" SortExpression="CoincidenciaCantidad" />
                         <asp:TemplateField HeaderText="Señas Part." SortExpression="CoincidenciasSeniasParticulares">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Eval("CoincidenciaSeniasParticulares").ToString()%>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSenasPartGridH" runat="server" Text='<%#Eval("CoincidenciaSeniasParticulares").ToString() %>' ForeColor='<%# Convert.ToInt32(Eval("CoincidenciaSeniasParticulares").ToString())>0?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre" SortExpression="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Eval("Apellido") + " " + Eval("Nombre")%>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoGridH" runat="server" Text='<%#Eval("Apellido") + " " + Eval("Nombre") %>' ForeColor='<%# Eval("coincidenciaNombreyApellido").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UFI" HeaderText="UFI" SortExpression="UFI" Visible="False" />
                        <asp:TemplateField HeaderText="Org.Int." SortExpression="idOrganismoInterviniente">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("idOrganismoInterviniente") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseOrganismoIntervinienteManager.GetItem(Convert.ToInt32(Eval("idOrganismoInterviniente").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comisaria" SortExpression="idComisaria">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idComisaria") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#MPBA.SIAC.Bll.ComisariaManager.GetItem(Convert.ToInt32(Eval("idComisaria").ToString())).comisaria.ToLower() %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lugar Hallazgo" SortExpression="idLugarHallazgo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("idLugarHallazgo") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#MPBA.SIAC.Bll.LocalidadManager.GetItem(Convert.ToInt32(Eval("idLugarHallazgo").ToString())).localidad.ToLower() %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Hallazgo" SortExpression="FechaHallazgo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("FechaHallazgo") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("FechaHallazgo")==null?"":Convert.ToDateTime(Eval("FechaHallazgo")).ToString("dd/MM/yyyy") %>'
                                    ForeColor='<%# Eval("coincidenciaFecha").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaSexo").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:BoundField DataField="EdadAparente" HeaderText="Edad Aparente" 
                                        SortExpression="EdadAparente" />--%>
                        <%--                                    <asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" />
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" />--%>
                        <asp:TemplateField HeaderText="Edad Aparente" SortExpression="EdadAparente">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("EdadAparente") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label22000" runat="server" Text='<%# Bind("EdadAparente") %>' ForeColor='<%# Eval("coincidenciaEdadAparente").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Talla" SortExpression="Talla">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label23" runat="server" Text='<%# Bind("Talla") %>' ForeColor='<%# Eval("coincidenciaTalla").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Peso" SortExpression="Peso">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Peso") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label24" runat="server" Text='<%# Bind("Peso") %>' ForeColor='<%# Eval("coincidenciaPeso").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Piel" SortExpression="idColorPiel">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("idColorPiel") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseColorDePielManager.GetItem(Convert.ToInt32(Eval("idColorPiel").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorPiel").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Cabello" SortExpression="idColorCabello">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("idColorCabello") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorCabello").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorCabello").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Tenido" SortExpression="idColorTenido">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("idColorTenido") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorTenido").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorTenido").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Long. Cabello" SortExpression="idLongitudCabello">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("idLongitudCabello") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(Eval("idLongitudCabello").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaLongitudCabello").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Aspecto Cabello" SortExpression="idAspectoCabello">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("idAspectoCabello") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(Eval("idAspectoCabello").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaAspectoCabello").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Calvicie" SortExpression="idCalvicie">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("idCalvicie") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseCalvicieManager.GetItem(Convert.ToInt32(Eval("idCalvicie").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaCalvicie").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Color Ojos" SortExpression="idColorOjos">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("idColorOjos") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorOjosManager.GetItem(Convert.ToInt32(Eval("idColorOjos").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaColorOjos").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rostro" SortExpression="idRostro">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("idRostro") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseRostroManager.GetItem(Convert.ToInt32(Eval("idRostro").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CantidadDiasNoAfeitado" HeaderText="Dias No Afeitado"
                            SortExpression="CantidadDiasNoAfeitado" />
                        <asp:TemplateField HeaderText="Faltan Dientes" SortExpression="FaltanPiezasDentales">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("FaltanPiezasDentales") %>'></asp:TextBox></EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("FaltanPiezasDentales").ToString())).Descripcion.ToLower() %>'
                                    ForeColor='<%# Eval("coincidenciaFaltanDientes").ToString()=="1"?System.Drawing.Color.Green:System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="ADN" HeaderText="ADN" SortExpression="ADN" />
                      
              </Columns>
                </asp:GridView>
                 
                 <asp:Label ID="Label32" runat="server" BackColor="#33CC33" BorderColor="Black" BorderWidth="2px"
                    ForeColor="#33CC33" Text="cc"></asp:Label><asp:Label ID="Label33" runat="server"
                        Text="Hay Coincidencia"></asp:Label>
                
        </asp:Panel>

                 </div>
                 <h3 class="fotos"> Fotos </h3>
                 <div id="mvcpartial" style="height:650px;  margin-left: 0px;margin-bottom: 0px;">
                  <div id="espera" style="vertical-align:middle; display:none">
                            <img alt="Esperar" src="../App_Images/wait.gif" />
                        </div>
                 <input type="button" id="btnVerFotos" style="width: 99px; height: 25px;" value="Visualiza Fotos"/>
                 
             
                  </div>
         </div>
     

                 <asp:UpdateProgress runat="server" ID="upWaitingResultadosBI" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Panel ID="pnlWaitingOverlayResultadosBI" CssClass="" runat="server">
                            <asp:Panel ID="pnlWaitingResultadosBI" CssClass="" runat="server">
                                <asp:Image ID="imgWaitingResultadosBI" runat="server" 
                                    ImageUrl="~/App_Images/loader.gif" Width="27px" />
                            </asp:Panel>
                        </asp:Panel>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                
      </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="upWaitingBusquedas" DisplayAfter="100">
        <ProgressTemplate>
            <asp:Panel ID="pnlWaitingOverlayBusquedas" CssClass="" runat="server">
                <asp:Panel ID="pnlWaitingBusquedas" CssClass="" runat="server">
                    <asp:Image ID="imgWaitingBusquedas" runat="server" 
                        ImageUrl="~/App_Images/loader.gif" Height="27px" Width="27px" />
                </asp:Panel>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ObjectDataSource ID="odsSenasParticulares" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SeniasParticulares"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.SeniasParticularesManager" UpdateMethod="Save">
        <SelectParameters>
            <asp:Parameter Name="idPersona" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsColorCabello" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseColorCabello"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTatuajesPersona" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.TatuajesPersonaManager">
        <SelectParameters>
            <asp:Parameter Name="idPersona" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTatuajes" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.ClaseTatuajeManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseTatuaje" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsRostro" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseRostro"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseRostroManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsOrgInt" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseOrganismoInterviniente"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseOrganismoIntervinienteManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsLocalidad" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Localidad"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.LocalidadManager" UpdateMethod="Save"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsLugarDesap" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Localidad"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.LocalidadManager" UpdateMethod="Save"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsColorTenido" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseColorCabello"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSexo" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseSexo"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseSexoManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsColorPiel" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseColorDePiel"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseColorDePielManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsUbicacionSeniaParticular" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseUbicacionSeniaPart"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsAspectoCabello" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseAspectoCabello"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseAspectoCabelloManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSeniaParticular" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseSeniaParticular"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.ClaseSeniaParticularManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsLongitudCabello" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseLongitudCabello"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseLongitudCabelloManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsColorOjos" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseColorOjos"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseColorOjosManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsBooleano" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCalvicie" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseCalvicie"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseCalvicieManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTipoBusqueda" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseTablaDestino"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.PBClaseTablaDestinoManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsDentadura" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.Dientes"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.PersonasBuscadas.Bll.DientesManager" UpdateMethod="Save"></asp:ObjectDataSource>
    <asp:HiddenField ID="hfExito" runat="server" />
    <asp:ModalPopupExtender ID="hfExito_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
        Drag="True" DynamicServicePath="" Enabled="True" CancelControlID="btnOkExito"
        PopupControlID="pnlExito" PopupDragHandleControlID="divHeaderExito" TargetControlID="hfExito">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hfAbrirResultadosBI" runat="server" />
    <asp:ModalPopupExtender ID="hfAbrirResultadosBI_ModalPopupExtender1" runat="server"
        BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
        Enabled="True" PopupControlID="pnlResultadosBI" PopupDragHandleControlID="divHeaderResultadosBI"
        TargetControlID="hfAbrirResultadosBI">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hfCantCoincidencias" runat="server" />
    <asp:ModalPopupExtender ID="hfCantCoincidencias_ModalPopupExtender" runat="server" 
                                 DynamicServicePath="" Enabled="True" TargetControlID="hfCantCoincidencias" 
                                 BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" PopupControlID="pnlCantCoincidencias" 
                                 PopupDragHandleControlID="divHeaderCantCoincidencias" 
                        CancelControlID="btnCancelarCantCoincidencias">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlExito" runat="server" CssClass="FondoModal" Width="243px">
        <div>
            <div id="divHeaderExito" class="ModalHeader">
                EXITO</div>
            <div style="position: relative; overflow: auto;" align="center">
                <table>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <asp:Label ID="Label31" runat="server" Text="Agregados a Mis Búsquedas"></asp:Label><br />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="padding-top: 10px; position: relative;">
                <asp:Button ID="btnOkExito" runat="server" Text="OK" />
                <br />
            </div>
            <br />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlResultadosBI" runat="server"  Width="600px">
        <div>
            <div id="divHeaderResultadosBI" class="ModalHeader">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" Text="MIS BUSQUEDAS FAVORITAS" ID="lblResultadosBI"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="height: 250px; position: relative; overflow: auto;">
                <asp:UpdatePanel ID="upResultadosBI" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left">
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:GridView ID="gvResultadosHalladasBI" runat="server" AutoGenerateColumns="False"
                                        Caption="PERSONAS HALLADAS" CaptionAlign="Top" DataKeyNames="Id" 
                                        OnRowDeleting="gvResultadosHalladasBI_RowDeleting">
                                        <Columns>
                                            <asp:CommandField DeleteText="X" ShowDeleteButton="True" Visible="False" />
                                            <asp:CommandField CancelText="X" DeleteText="X" EditText="Editar" InsertText="Insertar"
                                                NewText="Nuevo" SelectText="Ver" ShowSelectButton="True" Visible="False" />
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="Id" Visible="False" />
                                            <asp:BoundField DataField="Ipp" HeaderText="IPP" SortExpression="Ipp" />
                                            <asp:BoundField DataField="UFI" HeaderText="UFI" SortExpression="UFI" />
                                            <asp:BoundField DataField="CoincidenciaCantidad" HeaderText="Coincidencias" SortExpression="CoincidenciaCantidad" />
                                            <asp:TemplateField HeaderText="Org.Int." SortExpression="idOrganismoInterviniente">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("idOrganismoInterviniente") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseOrganismoIntervinienteManager.GetItem(Convert.ToInt32(Eval("idOrganismoInterviniente").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comisaria" SortExpression="idComisaria">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idComisaria") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label333" runat="server" Text='<%#MPBA.SIAC.Bll.ComisariaManager.GetItem(Convert.ToInt32(Eval("idComisaria").ToString())).comisaria.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lugar Hallazgo" SortExpression="idLugarHallazgo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("idLugarHallazgo") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%#MPBA.SIAC.Bll.LocalidadManager.GetItem(Convert.ToInt32(Eval("idLugarHallazgo").ToString())).localidad.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Hallazgo" SortExpression="FechaHallazgo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("FechaHallazgo") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label19" runat="server" Font-Bold='<%# Eval("Coincidenciafecha").ToString()=="1"?true:false %>'
                                                        Text='<%# Eval("FechaHallazgo")==null?"":Convert.ToDateTime(Eval("FechaHallazgo")).ToString("dd/MM/yyyy") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edad Aparente" SortExpression="EdadAparente">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("EdadAparente") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label26" runat="server" Text='<%# Bind("EdadAparente") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Talla" SortExpression="Talla">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# Bind("Talla") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Peso" SortExpression="Peso">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("Peso") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label220" runat="server" Text='<%# Bind("Peso") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" ControlStyle-Font-Bold= '<%# Eval("CoincidenciaTalla").ToString()=="1"?true:false %>'/>
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" ControlStyle-Font-Bold= '<%# Eval("CoincidenciaPeso").ToString()=="1"?true:false %>'/>--%><asp:TemplateField
                                            HeaderText="Color Piel" SortExpression="idColorPiel">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("idColorPiel") %>'></asp:TextBox></EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Font-Bold='<%# Eval("CoincidenciaColorPiel").ToString()=="1"?true:false %>'
                                                    Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseColorDePielManager.GetItem(Convert.ToInt32(Eval("idColorPiel").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Cabello" SortExpression="idColorCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("idColorCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Tenido" SortExpression="idColorTenido">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("idColorTenido") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorTenido").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Long. Cabello" SortExpression="idLongitudCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("idLongitudCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(Eval("idLongitudCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Aspecto Cabello" SortExpression="idAspectoCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("idAspectoCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(Eval("idAspectoCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Calvicie" SortExpression="idCalvicie">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("idCalvicie") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseCalvicieManager.GetItem(Convert.ToInt32(Eval("idCalvicie").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Ojos" SortExpression="idColorOjos">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("idColorOjos") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorOjosManager.GetItem(Convert.ToInt32(Eval("idColorOjos").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rostro" SortExpression="idRostro">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("idRostro") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label12" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseRostroManager.GetItem(Convert.ToInt32(Eval("idRostro").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CantidadDiasNoAfeitado" HeaderText="Dias No Afeitado"
                                                SortExpression="CantidadDiasNoAfeitado" />
                                            <asp:TemplateField HeaderText="Faltan Dientes" SortExpression="FaltanPiezasDentales">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("FaltanPiezasDentales") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("FaltanPiezasDentales").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="idDentadura" HeaderText="Dentadura" SortExpression="idDentadura" />--%><asp:TemplateField
                                                HeaderText="Fichas Dact." SortExpression="FichasDactilares">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("FichasDactilares") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("FichasDactilares").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Senia Part." SortExpression="idSeniaParticular">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("idSeniaParticular") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label14" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ubicacion Senia Part." SortExpression="idUbicacionSeniaParticular">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("idUbicacionSeniaParticular") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label18" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ADN" SortExpression="ADN">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("ADN") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label23" runat="server" Text='<%# Bind("ADN") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Foto" SortExpression="Foto">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("Foto") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label17" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("Foto").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" SortExpression="Apellido">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("Apellido") %> &amp; "," &amp; <%# Bind("Nombre") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2200" runat="server" Text='<%# Bind("Apellido") %> &amp; "," &amp; <%# Bind("Nombre") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Ropa" HeaderText="Ropa" SortExpression="Ropa" />
                                            <asp:BoundField DataField="ArticulosPersonales" HeaderText="Arts. Pers." SortExpression="ArticulosPersonales" />
                                            <asp:TemplateField HeaderText="Hay Radiog." SortExpression="ExistenRadiografia">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("ExistenRadiografia") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("ExistenRadiografia").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="FechaUltimaModificacion" HeaderText="FechaUltimaModificacion"
                                            SortExpression="FechaUltimaModificacion" Visible="False" />
                                        <asp:BoundField DataField="UsuarioUltimaModificacion" HeaderText="UsuarioUltimaModificacion"
                                            SortExpression="UsuarioUltimaModificacion" Visible="False" />
                                        <asp:CheckBoxField DataField="Baja" HeaderText="Baja" SortExpression="Baja" Visible="False" />--%></Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvResultadosDesapBI" runat="server" AutoGenerateColumns="False"
                                        Caption="PERSONAS DESAPARECIDAS" CaptionAlign="Top" DataKeyNames="Id" 
                                        OnRowDeleting="gvResultadosDesapBI_RowDeleting">
                                        <Columns>
                                            <asp:CommandField DeleteText="X" ShowDeleteButton="True" Visible="False" />
                                            <asp:CommandField CancelText="X" DeleteText="X" EditText="Editar" InsertText="Insertar"
                                                InsertVisible="False" NewText="Nuevo" SelectText="Ver" ShowCancelButton="False"
                                                ShowSelectButton="True" Visible="False" />
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="Id" Visible="False" />
                                            <asp:BoundField DataField="Ipp" HeaderText="IPP" SortExpression="Ipp" />
                                            <asp:BoundField DataField="UFI" HeaderText="UFI" SortExpression="UFI" />
                                            <asp:BoundField DataField="CoincidenciaCantidad" HeaderText="Coincidencias" SortExpression="CoincidenciaCantidad" />
                                            <asp:TemplateField HeaderText="Org.Int." SortExpression="idOrganismoInterviniente">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("idOrganismoInterviniente") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseOrganismoIntervinienteManager.GetItem(Convert.ToInt32(Eval("idOrganismoInterviniente").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comisaria" SortExpression="idComisaria">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("idComisaria") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label334" runat="server" Text='<%#MPBA.SIAC.Bll.ComisariaManager.GetItem(Convert.ToInt32(Eval("idComisaria").ToString())).comisaria.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lugar Desap." SortExpression="idLugarDesaparicion">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("idLugarDesaparicion") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%#MPBA.SIAC.Bll.LocalidadManager.GetItem(Convert.ToInt32(Eval("idLugarDesaparicion").ToString())).localidad.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Desap." SortExpression="FechaDesaparicion">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("FechaDesaparicion") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("FechaDesaparicion")==null?"":Convert.ToDateTime(Eval("FechaDesaparicion")).ToString("dd/MM/yyyy") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nac." SortExpression="FechaNacimiento" />
                                            <%--<asp:BoundField DataField="EdadMomentoDesaparicion" HeaderText="Edad Desap." SortExpression="EdadMomentoDesaparicion" />
                                        <asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" />
                                        <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" />--%><asp:TemplateField
                                            HeaderText="Edad Desap." SortExpression="EdadMomentoDesaparicion">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("EdadMomentoDesaparicion") %>'></asp:TextBox></EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label27" runat="server" Text='<%# Bind("EdadMomentoDesaparicion") %>'></asp:Label><br />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Talla" SortExpression="Talla">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label28" runat="server" Text='<%# Bind("Talla") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Peso" SortExpression="Peso">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Peso") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label29" runat="server" Text='<%# Bind("Peso") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Piel" SortExpression="idColorPiel">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("idColorPiel") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseColorDePielManager.GetItem(Convert.ToInt32(Eval("idColorPiel").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Cabello" SortExpression="idColorCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("idColorCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Tenido" SortExpression="idColorTenido">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("idColorTenido") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorTenido").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Long. Cabello" SortExpression="idLongitudCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("idLongitudCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(Eval("idLongitudCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Aspecto Cabello" SortExpression="idAspectoCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("idAspectoCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(Eval("idAspectoCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Calvicie" SortExpression="idCalvicie">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("idCalvicie") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseCalvicieManager.GetItem(Convert.ToInt32(Eval("idCalvicie").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Ojos" SortExpression="idColorOjos">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("idColorOjos") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorOjosManager.GetItem(Convert.ToInt32(Eval("idColorOjos").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CantidadDiasNoAfeitado" HeaderText="Dias No Afeitado"
                                                SortExpression="CantidadDiasNoAfeitado" />
                                            <asp:TemplateField HeaderText="Faltan Dientes" SortExpression="FaltanPiezasDentales">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("FaltanPiezasDentales") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("FaltanPiezasDentales").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Nombre" SortExpression="Apellido">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("Apellido") %> &amp; "," &amp; <%# Bind("Nombre") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label22" runat="server" Text='<%# Bind("Apellido") %> &amp; "," &amp; <%# Bind("Nombre") %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Ropa" HeaderText="Ropa" SortExpression="Ropa" />
                                            <asp:BoundField DataField="ArticulosPersonales" HeaderText="Arts. Pers." SortExpression="ArticulosPersonales" />
                                            <asp:TemplateField HeaderText="Hay Radiog." SortExpression="ExistenRadiografia">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("ExistenRadiografia") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("ExistenRadiografia").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="FechaUltimaModificacion" 
                                            HeaderText="FechaUltimaModificacion" SortExpression="FechaUltimaModificacion" 
                                            Visible="False" />
                                        <asp:BoundField DataField="UsuarioUltimaModificacion" 
                                            HeaderText="UsuarioUltimaModificacion" 
                                            SortExpression="UsuarioUltimaModificacion" Visible="False" />
                                        <asp:CheckBoxField DataField="Baja" HeaderText="Baja" SortExpression="Baja" Visible="False" />--%></Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="padding-top: 10px; position: relative; top: 0px; left: 0px; background-color: #C2D6D2;">
                <asp:UpdatePanel ID="upRresulBI" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr style="text-align: left">
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="text-align: center">
                                <td>
                                    <asp:Button ID="btnCancelarResultadosBI" runat="server" CausesValidation="False"
                                        OnClick="btnCancelarResultadosBI_Click" Text="Cerrar" UseSubmitBehavior="False"
                                        Width="50px" BorderStyle="Solid" />
                                    <br />
                                </td>
                                <td align="center">
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
          
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlCantCoincidencias" runat="server" CssClass="FondoModal" 
        Width="210px">
        <div>
            <div id="divHeaderCantConcidencias" class="ModalHeader">
                Cantidad Coincidencias</div>
            <div style="position: relative; overflow: auto;" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel runat="server" ID="upCantCoincidencias" >
                                <ContentTemplate>
                                    <br />
                             <asp:Label ID="lblMensajeCantCoincidencias" runat="server" Text="Indique cantidad mínima de criterios que deben coincidir:" 
                                        Font-Size="Small"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlCantCoincidencias" runat="server" DataSourceID="" 
                                            DataTextField="" DataValueField="" Font-Bold="False">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                        </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                  
                 
                </table>
            </div>
            <div style="padding-top: 10px; position: relative;">
            
              <asp:Button ID="btnCancelarCantCoincidencias" runat="server" Text="Cancelar" 
                    Width="60px" onclick="btnCancelarCantCoincidencias_Click" />
                <asp:Button ID="btnOkCantCoincidencias"  runat="server" Text="OK" Width="60px" 
                       onclick = "btnCantCoincidencias_Click" UseSubmitBehavior="False" />
                       
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlFichaPersHalladaBI" runat="server" CssClass="FondoModal" Width="600px">
        <div id="divHeaderFichaPersHalladaBI" class="ModalHeader">
            CONSULTANDO PERSONA HALLADA</div>
        <asp:UpdatePanel ID="upFichaPersHalladaBI" runat="server">
            <ContentTemplate>
                <div style="height: 350px; position: relative; overflow: auto;">
                    <table class="style2">
                        <tr align="left">
                            <td>
                                <asp:Label ID="lblIpBIH" runat="server">IPP</asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIppBIH" runat="server" ForeColor="Blue" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel4" runat="server">
                        <table class="style2">
                            <tr>
                                <td>
                                    <asp:Label ID="lblApeBIH" runat="server">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblApellidoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombBIH" runat="server">Nombres</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombresBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOrgInBIH" runat="server">Org. Int.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOrgIntBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="left">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label47" runat="server" Text="Foto General" Font-Underline="True"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label48" runat="server" Text="Foto Señas Part." Font-Underline="True"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        <asp:ImageButton ID="imgFotoGralBIH" runat="server" Height="80px" ImageUrl="~/App_Images/SinFoto.GIF"
                                                            Width="100px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnFotoSigGeneralBIH" runat="server" Text=">" OnClick="btnFotoSigGeneralBIH_Click"
                                                            Width="30px" />
                                                        <br />
                                                        <asp:Button ID="btnFotoPrevGeneralBIH" runat="server" Text="<" OnClick="btnFotoPrevGeneralBIH_Click"
                                                            Width="30px" />
                                                        <br />
                                                    </td>
                                                    <td width="30%">
                                                        <asp:ImageButton ID="imgFotoSenasBIH" runat="server" Height="80px" ImageUrl="~/App_Images/SinFoto.GIF"
                                                            Width="100px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnFotoSigSeniasBIH" runat="server" Text=">" OnClick="btnFotoSigSeniasBIH_Click"
                                                            Width="30px" />
                                                        <br />
                                                        <asp:Button ID="btnFotoPrevSeniasBIH" runat="server" Text="<" OnClick="btnFotoPrevSeniasBIH_Click"
                                                            Width="30px" />
                                                        <br />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNroFotoGralBIH" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNroFotoSenasBIH" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div align="center">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFichasDactBIH" runat="server">Fichas Dactilares</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFichasDactilaresBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr style="border: thin solid #000000;">
                                <td>
                                    <asp:Label ID="lblLugarHallazgBIH" runat="server">Lugar Desap.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLugarHallazgoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPartidoHallazgBIH" runat="server">Partido Desap.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPartidoHallazgoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProvHallazgBIH" runat="server">Prov. Desap.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProvHallazgoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr style="border: thin solid #000000;">
                                <td>
                                    <asp:Label ID="lblComisBIH" runat="server">Comisaria</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblComisariaBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDeptoComBIH" runat="server">Departamento Comisaria</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDeptoComisariaBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFechaHallazgBIH" runat="server">Fecha Hallazgo</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaHallazgoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSexBIH" runat="server">Sexo</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSexoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEdadCientificBIH" runat="server">Edad Científica</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEdadCientificaBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVivBIH" runat="server">Vive</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblViveBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEdadAparentBIH" runat="server">Edad Aparente</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEdadAparenteBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHayRadBIH" runat="server">Hay Radiografías</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHayRadiografiasBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTallBIH" runat="server">Talla</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTallaBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPesBIH" runat="server">Peso</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPesoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorPieBIH" runat="server">Color Piel</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorPielBIH" runat="server" ForeColor="Blue"></asp:Label><br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblColorCabellBIH" runat="server">Color Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorCabelloBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorTenidBIH" runat="server">Color Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorTenidoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLongCabelloBIH" runat="server">Longitud Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLongitudCabelloBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAspCabelloBIH" runat="server">Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAspectoCabelloBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCalvBIH" runat="server">Calvicie</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCalvicieBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOjosBIH" runat="server">Color Ojos</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorOjosBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRostBIH" runat="server">Rostro</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRostroBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCantDiasNoAfeitadoBIH" runat="server">Cant.días sin afeitar</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCantidadDiasNoAfeitadoBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFaltanPiezasDentBIH" runat="server">Faltan Dientes</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFaltanPiezasDentalesBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRopBIH" runat="server">Ropa</asp:Label><br />
                                </td>
                                <td>
                                    <asp:Label ID="lblRopaBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <%--<asp:Label ID="lblTatuajeBIH" runat="server" Text="Tatuajes" Font-Underline="True"></asp:Label>--%>
                                    <br />
                                    <asp:GridView ID="gvTatuajesBIH" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="id" Visible="False" />
                                            <asp:BoundField DataField="idPersona" HeaderText="idPersona" SortExpression="idPersona"
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="Tatuaje" SortExpression="idTatuaje">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label25" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseTatuajeManager.GetItem(Convert.ToInt32(Eval("idTatuaje").ToString())).descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionTatuaje">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionTatuaje").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" SortExpression="idTablaDestino"
                                                Visible="False" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblSeniaPartBIH" runat="server">Señas Particulares</asp:Label><br />
                                    <asp:GridView ID="gvSenasPartBIH" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="id" Visible="False" />
                                            <asp:BoundField DataField="idPersona" HeaderText="idPersona" SortExpression="idPersona"
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="Seña" SortExpression="idSeniaParticular">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label25" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionSeniaParticular">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" SortExpression="idTablaDestino"
                                                Visible="False" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAdnDBIH" runat="server">Tiene ADN</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCodigoAdnBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblArtPersonalesBIH" runat="server">Art. Personales</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblArticulosPersonalesBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="2" width="25%">
                        </td>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnCerrarBIH" runat="server" Text="Cerrar" Width="105px" CausesValidation="False"
                                UseSubmitBehavior="False" OnClick="btnCerrarBIH_Click" />
                            <asp:HiddenField ID="hfOkFichaBIH" runat="server" />
                        </td>
                        <td colspan="2" width="25%">
                        </td>
                    </tr>
                </table>
                <asp:UpdateProgress runat="server" ID="upWaitingFichaBIH" DisplayAfter="100" AssociatedUpdatePanelID = "UpdatePanel4">
                    <ProgressTemplate>
                        <asp:Panel ID="pnlWaitingOverlayFichaBIH" CssClass="" runat="server">
                            <asp:Panel ID="pnlWaitingFichaBIH" CssClass="" runat="server">
                                <asp:Image ID="imgWaitingBIH" runat="server" ImageUrl="~/App_Images/loader.gif" 
                                    Width="27px" />
                            </asp:Panel>
                        </asp:Panel>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
                <asp:HiddenField ID="hfGestionFichaPersHalladaBI" runat="server" />
                <asp:ModalPopupExtender ID="hfGestionFichaPersHalladaBI_ModalPopupExtender" runat="server"
                    BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
                    Enabled="True" PopupControlID="pnlFichaPersHalladaBI" PopupDragHandleControlID="divHeaderFichaPersHalladaBI"
                    RepositionMode="None" TargetControlID="hfGestionFichaPersHalladaBI" X="300" Y="-300">
                </asp:ModalPopupExtender>
                
    </asp:Panel>
    <asp:Panel ID="pnlFichaPersDesapBI" runat="server" CssClass="FondoModal" Width="600px">
        <div id="divHeaderFichaPersDesapBI" class="ModalHeader">
            CONSULTANDO PERSONA DESAPARECIDA</div>
        <asp:UpdatePanel ID="upFichaPersonaDesapBI" runat="server">
            <ContentTemplate>
                <div style="height: 350px; position: relative; overflow: auto;">
                    <table class="style2">
                        <tr align="left">
                            <td>
                                <asp:Label ID="lblIpBID" runat="server">IPP</asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIppBID" runat="server" ForeColor="Blue" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="pnlFichaPersonadesaparecidaBI" runat="server">
                        <table class="style2">
                            <tr>
                                <td>
                                    <asp:Label ID="lblApeBID" runat="server">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblApellidoBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombBID" runat="server">Nombres</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombresBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOrgIntBID" runat="server">Org. Int.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOrganismoIntervinienteBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="left">
                                    <asp:UpdatePanel ID="upSubirFotoGeneralBID" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFotoGeneralBID" runat="server" Text="Foto General" Font-Underline="True"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFotoSeBID" runat="server" Text="Foto Señas Part." Font-Underline="True"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                          <asp:ImageButton ID="imgFotoGeneralBID" runat="server" Height="80px" 
                                                    ImageUrl="~/App_Images/SinFoto.GIF" Width="100px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnFotoSigGeneralBID" runat="server" Text=">" 
                                                            OnClick="btnFotoSigGeneralBID_Click" Width="30px" />
                                                        <br />
                                                        <asp:Button ID="btnFotoPrevGeneralBID" runat="server" Text="<" 
                                                            OnClick="btnFotoPrevGeneralBID_Click" Width="30px" />
                                                        <br />
                                                    </td>
                                                    <td width="30%">
                                                         <asp:ImageButton ID="imgFotoSeniasBID" runat="server" Height="80px" 
                                                    ImageUrl="~/App_Images/SinFoto.GIF" Width="100px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnFotoSigSeniasBID" runat="server" Text=">" 
                                                            OnClick="btnFotoSigSeniasBID_Click" Width="30px" />
                                                        <br />
                                                        <asp:Button ID="btnFotoPrevSeniasBID" runat="server" Text="<" 
                                                            OnClick="btnFotoPrevSeniasBID_Click" Width="30px" />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNroFotoGralBID" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNroFotoSeniasBID" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div align="center">
                                    </div>
                                </td>
                            </tr>
                            <tr style="border: thin solid #000000;">
                                <td>
                                    <asp:Label ID="lblLugarDesapBI" runat="server">Lugar Desap.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLugarDesapPersonaBI" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPartidoBID" runat="server">Partido Desap.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPartidoDesaparicionBI" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProvinciaBID" runat="server">Prov. Desap.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProvinciaDesapBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr style="border: thin solid #000000;">
                                <td>
                                    <asp:Label ID="lblComisariaBID" runat="server">Comisaria</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblComisariaPersonaBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDepartamentoComBID" runat="server">Departamento Comisaria</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDepartamentoComisariaBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFechaDesapBID" runat="server">Fecha Desap</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaDesaparicionBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaNacBID" runat="server">Fecha Nac.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaNacimientoBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSexBID" runat="server">Sexo</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSexoBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEdaBID" runat="server">Edad</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEdadBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTallBID" runat="server">Talla</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTallaBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPesBID" runat="server">Peso</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPesoBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPielBID" runat="server">Color Piel</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorPielBID" runat="server" ForeColor="Blue"></asp:Label><br />
                                </td>
                                <td>
                                    <asp:Label ID="lblCabelloBID" runat="server">Color Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorCabelloBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTenidoBID" runat="server">Color Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorTenidoBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblLongCabelloBID" runat="server">Longitud Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLongitudCabelloBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAspCabelloBID" runat="server">Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAspectoCabelloBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCalvBID" runat="server">Calvicie</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCalvicieBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOjosBID" runat="server">Color Ojos</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorOjosBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRostBID" runat="server">Rostro</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRostroBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCantDiasNoAfeitadoBID" runat="server">Cant.días sin afeitar</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCantidadDiasNoAfeitadoBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <%--<asp:Label ID="lblSeniaPartBID" runat="server" Font-Underline="True">Señas Particulares</asp:Label>
                            <br />--%>
                                    <asp:GridView ID="gvSenasPartBID" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="id" Visible="False" />
                                            <asp:BoundField DataField="idPersona" HeaderText="idPersona" SortExpression="idPersona"
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="Seña" SortExpression="idSeniaParticular">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlSeniaPart" runat="server" DataSourceID="odsSeniaParticular"
                                                        DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Eval("idSeniaParticular") %>'>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label25" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionSeniaParticular">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlUbicacionSenaPart" runat="server" DataSourceID="odsUbicacionSeniaParticular"
                                                        DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Eval("idUbicacionSeniaParticular") %>'>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" SortExpression="idTablaDestino"
                                                Visible="False" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td colspan="2">
                                    <asp:GridView ID="gvTatuajesBID" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="id" Visible="False" />
                                            <asp:BoundField DataField="idPersona" HeaderText="idPersona" SortExpression="idPersona"
                                                Visible="False" />
                                            <asp:TemplateField HeaderText="Tatuaje" SortExpression="idTatuaje">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label25" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseTatuajeManager.GetItem(Convert.ToInt32(Eval("idTatuaje").ToString())).descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionTatuaje">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionTatuaje").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" SortExpression="idTablaDestino"
                                                Visible="False" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                    <asp:Label ID="lblFaltanPiezasDentBID" runat="server">Faltan Dientes</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFaltanPiezasDentalesBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAdnDBI" runat="server">Tiene ADN</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCodigoAdnBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                              
                                <td>
                                    <asp:Label ID="lblFichasDactBID" runat="server">Fichas Dactilares</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFichasDactilaresBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                  <td>
                                   
                                </td>
                                <td>
                                  
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRopBID" runat="server">Ropa</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRopaBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblArtPersonalesBID" runat="server">Art. Personales</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblArticulosPersonalesBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblExistenRadBID" runat="server">Hay Radiografías</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblExistenRadiografiasBID" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                                    </div>
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="2" width="25%">
                        </td>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnCerrarBID" runat="server" Text="Cerrar" Width="105px" CausesValidation="False"
                                UseSubmitBehavior="False" OnClick="btnCerrarBID_Click" />
                            <asp:HiddenField ID="hfOkFichaBID" runat="server" />
                        </td>
                        <td colspan="2" width="25%">
                        </td>
                    </tr>
                </table>
                <asp:UpdateProgress runat="server" ID="upWaitingFichaBID" DisplayAfter="100" AssociatedUpdatePanelID ="upSubirFotoGeneralBID">
                    <ProgressTemplate>
                        <asp:Panel ID="pnlWaitingOverlayFichaBID" CssClass="" runat="server">
                            <asp:Panel ID="pnlWaitingFichaBID" CssClass="" runat="server">
                                <asp:Image ID="imgWaitingBID" runat="server" ImageUrl="~/App_Images/loader.gif" 
                                    Width="27px" />
                            </asp:Panel>
                        </asp:Panel>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HiddenField ID="hfGestionFichaPersDesapBI" runat="server" />
                <asp:ModalPopupExtender ID="hfGestionFichaPersDesapBI_ModalPopupExtender" runat="server"
                BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
                Enabled="True" PopupControlID="pnlFichaPersDesapBI" PopupDragHandleControlID="divHeaderFichaPersDesapBI"
                RepositionMode="None" TargetControlID="hfGestionFichaPersDesapBI" X="300" Y="-300">
            </asp:ModalPopupExtender>
    </asp:Panel>
</asp:Content>
