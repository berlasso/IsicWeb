<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="True"
    CodeBehind="BusquedaDesaparecida.aspx.cs" Inherits="MPBA.PersonasBuscadas.Web.BusquedaDesaparecida"
    Culture="es-AR" UICulture="es-AR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            text-align: left;
        }
        .style3
        {
            text-align: left;
            width: 15%;
        }
        .style4
        {
            text-align: left;
            width: 40%;
        }
         .ingreso
          { margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    
    <asp:UpdatePanel runat="server" ID="upPersonasDesaparecidas">
        <ContentTemplate>
            <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelConsultandoD" runat="server" align="center">
                    CONSULTANDO PERSONA DESAPARECIDA</h3>
            </div>
            <%--            <table class="style2" style="margin: 15px; border: 2px solid #006666; background-color: #8EAAB9">
            --%>
            <table class="style2" style="background-color: #d4e8f7" width="100%">
                <tr>
                    <%-- <td>
                        
                    </td>--%>
                    <td>
                        <asp:Panel ID="pnlIPPD" runat="server" DefaultButton="btnBuscarIppD" Style="text-align: center"
                            BorderStyle="Solid" BorderWidth="4px">
                              <div>
                              <table width="100%">
                              <tr>
                              <td width="20%"></td>
                              <td width="50%" align="center">
                            <asp:TabContainer ID="tcTipoJurisdiccion" runat="server" ActiveTabIndex="0" Width="290px"
                                EnableViewState="True" Height="72px" AutoPostBack="True" OnActiveTabChanged="tcTipoJurisdiccion_ActiveTabChanged">
                                <asp:TabPanel runat="server" HeaderText="Poder Judicial" ID="tpPJ">
                                    <HeaderTemplate>
                                        Poder Judicial</HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Label ID="lblIppBuscadoD" runat="server" Font-Size="Large" Font-Bold="True"
                                            Style=" text-align: center; vertical-align: middle; color: #13507d">IPP</asp:Label>
                                        <asp:TextBox ID="txtIppBuscadoD" runat="server" Width="200px" BorderColor="Black"
                                            BorderStyle="Solid" BorderWidth="1px" Font-Size="Large"></asp:TextBox>
                                        <asp:CustomValidator ID="cvIppD" runat="server" ControlToValidate="txtIppBuscadoD"
                                            ErrorMessage="Debe ingresar la IPP"></asp:CustomValidator>
                                        <asp:MaskedEditExtender ID="txtIppBuscadoD_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="99-99-999999-99" MaskType="Number" OnBlurCssNegative="MaskedEditError"
                                            TargetControlID="txtIppBuscadoD">
                                        </asp:MaskedEditExtender>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="tpExtJur" runat="server" HeaderText="Extraña Jurisdiccion">
                                    <HeaderTemplate>
                                        Extraña Jurisdiccion</HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Label ID="lblCausa" runat="server" Font-Bold="True" Font-Size="Large" Style="vertical-align: middle;
                                            color: #13507d">Nro. Causa</asp:Label>
                                        <asp:TextBox ID="txtCausa" runat="server" Width="200px" BackColor="#FFFFFF" BorderColor="Black"
                                            BorderStyle="Solid" BorderWidth="1px" Font-Size="Large"></asp:TextBox>
                                        <asp:CustomValidator ID="cvCausa" runat="server" ControlToValidate="txtCausa" ErrorMessage="Debe ingresar el numero de causa"></asp:CustomValidator>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                            <asp:Button ID="btnBuscarIppD" runat="server" OnClick="btnBuscarIppD_Click" Text="Buscar"
                                Width="76px" ForeColor="Black" Font-Size="Medium" />
                            <asp:HiddenField ID="hfCartelAlert" runat="server" />
                            </td>
                            <td align="right">
                         
                             <asp:GridView ID="gvMailsAsociados" runat="server" AutoGenerateColumns="False" 
                                      DataKeyNames="id" onrowdeleting="gvMailsAsociados_RowDeleting" 
                                    Width="100%">
                                 <Columns>
                                     <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:Button ID="btnBorrarMailAsociado" runat="server" CommandName="Delete" 
                                                 ForeColor="Red" 
                                                 onclientclick="return confirm('Seguro que desea borrar el mail?')" Text="X" 
                                                 ToolTip="Borrar" />
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:BoundField DataField="idPersonaBuscada" HeaderText="idPersonaBuscada" 
                                         SortExpression="idPersonaBuscada" Visible="False" />
                                     <asp:BoundField DataField="idTipoPersona" HeaderText="idTipoPersona" 
                                         SortExpression="idTipoPersona" Visible="False" />
                                     <asp:BoundField DataField="Mail" HeaderText="Mails de la causa" 
                                         SortExpression="Mail" />
                                     <asp:CheckBoxField DataField="seleccionado" HeaderText="seleccionado" 
                                         SortExpression="seleccionado" Visible="False" />
                                     <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                                         SortExpression="Apellido" />
                                     <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                                         SortExpression="Nombre" />
                                     <asp:BoundField DataField="FechaAlta" HeaderText="FechaAlta" 
                                         SortExpression="FechaAlta" Visible="False" />
                                     <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                         ReadOnly="True" SortExpression="id" Visible="False" />
                                 </Columns>
                                  </asp:GridView>
                    
                         </td>
                         </tr>
                         <tr>
                         <td colspan="3" align="right">
                                <asp:Button ID="btnAgregarMailAsociado" runat="server" Text="Agregar Mail" 
                                    onclick="btnAgregarMailAsociado_Click" CausesValidation="False" 
                                    UseSubmitBehavior="False" Visible="False" />   
                         </td>
                         </tr>
                         </table>
                            </div>
                           
                            <asp:ModalPopupExtender ID="hfCartelAlert_ModalPopupExtender" runat="server" DynamicServicePath=""
                                Enabled="True" TargetControlID="hfCartelAlert" BackgroundCssClass="FondoOscuro"
                                Drag="True" DropShadow="True" OkControlID="btnOkCartelAlert" PopupControlID="pnlCartelAlert"
                                PopupDragHandleControlID="divHeaderCartelAlert">
                            </asp:ModalPopupExtender>
                            <br />
                            <br />
                            <div align="center">
                                <asp:Panel ID="pnlExtranaJurisdiccion" runat="server" BorderStyle="Solid" BorderWidth="1px"
                                    GroupingText="Extraña Jurisdiccón" HorizontalAlign="Left" BackColor="#EDEAEE"
                                    Width="500px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCaratulaExtJur" runat="server" Text="Caratula"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCaratulaExtJur" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOrgReqExtJur" runat="server" Text="Organismo Requirente"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOrgReqExtJur" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblJurisdiccionExtJur" runat="server" Text="Jurisdiccion"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtJurisdiccionExtJur" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblProvinciaExtJur" runat="server" Text="Provincia"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlProvinciaExtJur" runat="server" Width="150px" DataSourceID="odsProvincia" DataTextField="provincia" DataValueField="id">
                                                </asp:DropDownList>
                                                  <asp:ObjectDataSource ID="odsProvincia" runat="server" 
                                    DataObjectTypeName="MPBA.SIAC.BusinessEntities.Provincia" DeleteMethod="Delete" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                                    TypeName="MPBA.SIAC.Bll.ProvinciaManager" UpdateMethod="Save"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTelefonoExtJur" runat="server" Text="Telefono"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTelefonoExtJur" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMailExtJur" runat="server" Text="Email"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMailExtJur" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <br />
                            <div id="divPersonasD" runat="server">
                                <table>
                                    <tr align="left">
                                        <td colspan="2">
                                            <asp:Label ID="lblVariasPersonasD" runat="server" Text="Personas asociadas a la IPP:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%">
                                            <asp:GridView ID="gvPersonasD" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="gvPersonasD_SelectedIndexChanged"
                                                Width="900px" DataKeyNames="id" OnRowDeleting="gvPersonasD_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                           
                                                            <asp:Button ID="btnBorrarPersonaD" runat="server" CausesValidation="False" OnClientClick="return confirm('Seguro que desea borrar?')"
                                                                CommandName="Delete" Text="X" ForeColor="Red" Width="30px" 
                                                                Visible="False" />
                                                                 <asp:Button ID="btnElegirPersonaD" runat="server" CausesValidation="False" CommandName="Select"
                                                                Text="Elegir" />
                                                        </ItemTemplate>
                                                        <ItemStyle ForeColor="Red" Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido">
                                                        <ItemStyle Width="20%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"> 
                                                        <ItemStyle Width="20%" />
                                                    </asp:BoundField>
                                                 
                                                          <asp:BoundField DataField="FechaDesaparicion" HeaderText="Fecha Desap." 
                                                        SortExpression="FechaDesaparicion" />
                                                     <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                    <asp:BoundField DataField="Talla" HeaderText="Talla" />
                                                    <asp:BoundField DataField="Peso" HeaderText="Peso" />

                                                    <asp:TemplateField  Visible=true>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBajaPersona" runat="server" Text="Dado de Baja" 
                                                                Font-Bold="True" ForeColor="Red"></asp:Label>
                                                         <asp:CheckBox ID="Baja" Visible=False Width="90px" 
                                                                Checked='<%# Convert.ToBoolean(Eval("Baja")) %>' runat="server" 
                                                                Text="Dado de Baja" Enabled="False" />
                                                        
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                                                                        
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                        </td>
                                        <td width="50%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <asp:Button ID="btnAgregarPersonaD" runat="server" OnClick="btnAgregarPersonaDD_Click"
                                                Text="Agregar" Width="76px" ForeColor="Black" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divAgregandoPersona" runat="server">
                                <table>
                                    <tr align="left">
                                        <td>
                                            <br />
                                            <asp:Label ID="lblAgregandoPersona" runat="server" Font-Size="Medium" Font-Bold="True"
                                                Font-Underline="True">Agregando Persona</asp:Label>
                                            <asp:LinkButton ID="btnCancelarAgregarPersonaD" runat="server" Text="(Cancelar)"
                                                OnClick="btnCancelarAgregarPersonaD_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <div style="text-align: left">
                <asp:Panel ID="pnlDatosWebServerD" runat="server" Style="overflow: auto;" GroupingText="Datos del SIMP"
                    CssClass="LabelPanel">
                    <asp:GridView ID="gvWebServerCausaD" runat="server" AutoGenerateColumns="True" Caption="Causa"
                        CaptionAlign="Left">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvWebServerPersonasD" runat="server" AutoGenerateColumns="True"
                        Caption="Personas" CaptionAlign="Left">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvWebServerDenuncianteD" runat="server" AutoGenerateColumns="True"
                        Caption="Denunciante" CaptionAlign="Left">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvWebServerVictimaD" runat="server" AutoGenerateColumns="True"
                        Caption="Victima" CaptionAlign="Left">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvWebServerImputadoD" runat="server" AutoGenerateColumns="True"
                        Caption="Imputado" CaptionAlign="Left">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvWebServerDelitoD" runat="server" AutoGenerateColumns="True" Caption="Delito"
                        CaptionAlign="Left">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
            <asp:Panel ID="pnlPersonadesaparecida" runat="server">
                <%-- <table width="100%" style="margin: 15px" bgcolor="#D3E2D8">--%>
                <table width="98%" bgcolor="#D3E2D8">
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblLugarDesap" runat="server">Lugar Desapariciön</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:Label ID="lblLugarDesapPersona" runat="server"></asp:Label>
                            <asp:ImageButton ID="btnBuscarLocalidadD" runat="server" AlternateText="+" CommandName=""
                                Height="16px" ImageUrl="~/App_Images/magnify.png" Width="16px" OnClick="btnBuscarLocalidadD_Click" />
                            <asp:HiddenField ID="hfLugarDId" runat="server" Value="0" />
                        </td>
                        <td align="left" class="style3">
                        </td>
                        <td align="left" class="style4">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblPartidoD" runat="server">Partido</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:Label ID="lblPartidoDesaparicion" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                        </td>
                        <td align="left" class="style4">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblProvinciaD" runat="server">Provincia</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:Label ID="lblProvinciaDesapD" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                        </td>
                        <td align="left" class="style4">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblFechaDesapD" runat="server">Fecha Desaparición</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtFechaDesapD" runat="server" Width="150px"></asp:TextBox>
                            <asp:ImageButton ID="btnFechaDesapD" runat="server" CausesValidation="False" Height="16px"
                                ImageUrl="~/App_Images/calendar.png" Width="17px" />
                            <asp:MaskedEditExtender ID="txtFechaDesapD_MaskedEditExtender" runat="server" AutoComplete="False"
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="False"
                                TargetControlID="txtFechaDesapD">
                            </asp:MaskedEditExtender>
                            <asp:MaskedEditValidator ID="mevFechaDesapD" runat="server" ControlExtender="txtFechaDesapD_MaskedEditExtender"
                                ControlToValidate="txtFechaDesapD" EmptyValueMessage="Ingrese una fecha" ErrorMessage="Fecha incorrecta"
                                InvalidValueMessage="Fecha incorrecta" TooltipMessage="Ingrese una fecha"></asp:MaskedEditValidator><br />
                            <asp:CustomValidator ID="cvFechaDesapD" runat="server" ControlToValidate="txtFechaDesapD"
                                ErrorMessage="Fecha incorrecta"></asp:CustomValidator>
                            <asp:CalendarExtender ID="txtFechaDesapD_CalendarExtender" runat="server" Enabled="True"
                                PopupButtonID="btnFechaDesapD" TargetControlID="txtFechaDesapD" Format="dd/MM/yyyy"
                                TodaysDateFormat="d MMMM, yyyy">
                            </asp:CalendarExtender>
                        </td>
                        <td align="left" class="style3">
                        </td>
                        <td align="left" class="style4">
                        </td>
                    </tr>
                </table>
                <br />
                <%-- <table width="100%" style="margin: 15px" bgcolor="#E3DEE4">--%>
                <table width="98%" bgcolor="#D3E2D8">
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblOrgIntD" runat="server">Organismo Interviniente</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlOrgIntD" runat="server" DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsOrgInt" Width="150px">
                            </asp:DropDownList>
                            <br />
                            <asp:CustomValidator ID="cvOrgIntD" runat="server" ControlToValidate="ddlOrgIntD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                        </td>
                        <td align="left" class="style4">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblComisariaD" runat="server">Seccional</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:Label ID="lblComisariaPersonaD" runat="server"></asp:Label>
                            <asp:ImageButton ID="btnTraerComisariaD" runat="server" AlternateText="+" CommandName=""
                                Height="16px" ImageUrl="~/App_Images/magnify.png" Width="16px" OnClick="btnTraerComisariaD_Click" />
                            <asp:HiddenField ID="hfComisariaDId" runat="server" Value="0" />
                            <br />
                            <asp:Label ID="lblSeccionalNoCoincide" runat="server" ForeColor="#666666" Text="La Comisaría no coincide con la cargada en el SIMP"></asp:Label>
                        </td>
                        <td align="left" class="style3">
                            &nbsp;
                        </td>
                        <td align="center" class="style4" style="padding: 15px 15px 15px 0px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            &nbsp;
                        </td>
                        <td align="left" class="style4">
                            &nbsp;
                        </td>
                        <td align="left" class="style3">
                        </td>
                        <td align="left" class="style4">
                        </td>
                    </tr>
                </table>
                <br />
                <%--<table width="100%" style="margin: 15px" bgcolor="#C0D7D8">--%>
                <table width="98%" bgcolor="#dee4e4">
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblApellidoD" runat="server">Apellido/s</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtApellidoD" CssClass="ctooltip" 
                                Tooltip="<%$ Resources:WebResources,ingresoDesaparecida %>" runat="server" 
                                Width="150px"></asp:TextBox>
                            <asp:CustomValidator ID="cvApellido" runat="server" ControlToValidate="txtApellidoD"
                                ErrorMessage="Ingreso Obligatorio"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblNombresD" runat="server">Nombre/s</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtNombresD" runat="server" Width="150px"></asp:TextBox>
                            <asp:CustomValidator ID="cvNombres" runat="server" ControlToValidate="txtApellidoD"
                                ErrorMessage="Ingreso Obligatorio"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="Label14" runat="server">Tipo Doc.</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlTipoDoc" runat="server" DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsTipoDocumento" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblDNI" runat="server">Nro Doc.</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtDNI" runat="server" Width="150px"></asp:TextBox>
                            
                        </td>
                        <asp:MaskedEditExtender ID="MaskedEditExtender_DNI" runat="server"
                                AutoComplete="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                CultureTimePlaceholder="" Enabled="True" Mask="999999999" MaskType="Number" TargetControlID="txtDNI">
                            </asp:MaskedEditExtender>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtDNI"
                                ErrorMessage="Numero incorrecto"></asp:CustomValidator>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblFechaNacD" runat="server">Fecha de Nacimiento</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtFechaNacD" runat="server" Width="150px"></asp:TextBox>
                            <asp:ImageButton ID="btnFechaNacD" runat="server" CausesValidation="False" Height="16px"
                                ImageUrl="~/App_Images/calendar.png" Width="17px" />
                            <asp:MaskedEditValidator ID="mevFechaNacD" runat="server" ControlExtender="txtFechaNacD_MaskedEditExtender"
                                ControlToValidate="txtFechaNacD" EmptyValueMessage="Ingrese una fecha" ErrorMessage="Fecha incorrecta"
                                InvalidValueMessage="Fecha incorrecta" TooltipMessage="Ingrese una fecha"></asp:MaskedEditValidator><br />
                            <asp:CustomValidator ID="cvFechaNacD" runat="server" ControlToValidate="txtFechaNacD"
                                ErrorMessage="Fecha incorrecta"></asp:CustomValidator>
                            <asp:CalendarExtender ID="txtFechaNacD_CalendarExtender" runat="server" Enabled="True"
                                PopupButtonID="btnFechaNacD" TargetControlID="txtFechaNacD" Format="dd/MM/yyyy"
                                TodaysDateFormat="d MMMM, yyyy">
                            </asp:CalendarExtender>
                            <asp:MaskedEditExtender ID="txtFechaNacD_MaskedEditExtender" runat="server" AutoComplete="False"
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaNacD"
                                MessageValidatorTip="False">
                            </asp:MaskedEditExtender>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblEdadD" runat="server">Edad</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtEdadD" runat="server" Width="150px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtEdadD_MaskedEditExtender" runat="server" AutoComplete="False"
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                CultureTimePlaceholder="" Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtEdadD">
                            </asp:MaskedEditExtender>
                            <asp:CustomValidator ID="cvEdadD" runat="server" ControlToValidate="txtEdadD" ErrorMessage="Edad incorrecta"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblSexoD"  runat="server">Sexo</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlSexoD" runat="server" DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsSexo" Width="150px" class="ctooltip" 
                                Tooltip="<%$ Resources:WebResources,ingresoSexo %>">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvSexoD" runat="server" ControlToValidate="ddlSexoD" ErrorMessage="Ingreso Obligatorio"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblCantidadDiasNoAfeitadoD" runat="server">Barba(en días)</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtCantDiasSinAfeitarD" runat="server" Width="150px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtCantDiasSinAfeitarD_MaskedEditExtender" runat="server"
                                AutoComplete="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                CultureTimePlaceholder="" Enabled="True" Mask="999" MaskType="Number" TargetControlID="txtCantDiasSinAfeitarD">
                            </asp:MaskedEditExtender>
                            <asp:CustomValidator ID="cvCantDiasSinAfeitarD" runat="server" ControlToValidate="txtCantDiasSinAfeitarD"
                                ErrorMessage="Numero incorrecto"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblTallaD" runat="server">Talla(cms.)</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtTallaD" class="ctooltip" 
                                Tooltip="<%$ Resources:WebResources,tallaPersona %>" runat="server" 
                                Width="150px"></asp:TextBox>
                            <asp:CustomValidator ID="cvtalla" runat="server" ControlToValidate="txtTallaD" ErrorMessage="Talla incorrecta"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblPesoD" runat="server">Peso</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtPesoD" class="ctooltip" 
                                Tooltip="<%$ Resources:WebResources,pesoPersona %>" runat="server" 
                                Width="150px"></asp:TextBox>
                            <asp:CustomValidator ID="cvPesoD" runat="server" ControlToValidate="txtPesoD" ErrorMessage="Peso incorrecto"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblColorPielD" runat="server">Color de Piel</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlColorPielD" runat="server" DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsColorPiel" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvColorPielD" runat="server" ControlToValidate="ddlColorPielD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblColorTenidoD" runat="server">Cabello Teñido</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlColorTenidoD" runat="server" DataSourceID="odsColorTenido"
                                DataTextField="Descripcion" DataValueField="Id" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvColorTenidoD" runat="server" ControlToValidate="ddlColorTenidoD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblColorCabelloD" runat="server">Color de Cabello</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlColorCabelloD" runat="server" DataTextField="Descripcion"
                                DataValueField="Id" DataSourceID="odsColorCabello" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvColorCabelloD" runat="server" ControlToValidate="ddlColorCabelloD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblLongitudCabelloD" runat="server">Corte de Cabello</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlLongitudCabelloD" runat="server" DataTextField="Descripcion"
                                DataValueField="Id" DataSourceID="odsLongitudCabello" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvLongitudCabelloD" runat="server" ControlToValidate="ddlLongitudCabelloD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblAspectoCabelloD" runat="server">Aspecto Cabello</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlAspectoCabelloD" runat="server" DataTextField="Descripcion"
                                DataValueField="Id" DataSourceID="odsAspectoCabello" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvAspectoCabelloD" runat="server" ControlToValidate="ddlAspectoCabelloD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblCalvicieD" runat="server">Calvicie</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlCalvicieD" runat="server" DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsCalvicie" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvCalvicieD" runat="server" ControlToValidate="ddlCalvicieD"
                                ErrorMessage="Debe seleccionar un dato, o el campo 'No tiene'"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblColorOjosD" class="ctooltip" Tooltip="<%$ Resources:WebResources,colorOjosPersona %>" runat="server">Color Ojos</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlColorOjosD"  runat="server" 
                                DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsColorOjos" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvColorOjosD" runat="server" ControlToValidate="ddlColorOjosD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblRostroD" runat="server">Rostro</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlRostroD" runat="server" DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsRostro" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvRostroD" runat="server" ControlToValidate="ddlRostroD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblArticulosPersonalesD" runat="server">Artículos Personales</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtArticulosPersonalesD" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblRopaD" runat="server">Ropa</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox ID="txtRopaD" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
           
                                      <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblAdnD" runat="server">Muestra ADN</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlAdnD" runat="server" DataTextField="Descripcion" DataValueField="Id"
                                DataSourceID="odsBooleano" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvTieneAdnD" runat="server" ControlToValidate="ddlAdnD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            <asp:Label ID="lblFichasDactilaresD" runat="server">Fichas Dactilares</asp:Label>
                        </td>
                        <td align="left" class="style4">
                            <asp:DropDownList ID="ddlFichasDactilaresD" runat="server" DataTextField="Descripcion"
                                DataValueField="Id" DataSourceID="odsBooleano" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvFichasDactilaresD" runat="server" ControlToValidate="ddlFichasDactilaresD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                    </tr>
                        
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblFaltanPiezasDentalesD" runat="server">Faltan Dientes</asp:Label>
                        </td>
                        <td align="left" class="style4">
                          <asp:DropDownList ID="ddlFaltanPiezasDentalesD" runat="server" DataSourceID="odsBooleano"
                                DataTextField="Descripcion" DataValueField="Id" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvFaltanDientesD" runat="server" ControlToValidate="ddlFaltanPiezasDentalesD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                         
                        </td>
                        <td align="left" class="style3">
                        
                            <asp:Label ID="lblExistenRadiografiasD" runat="server">Radiografías</asp:Label>
                        </td>
                        <td align="left" class="style4">
                               <asp:DropDownList ID="ddlExistenRadiografiasD" runat="server" DataTextField="Descripcion"
                                DataValueField="Id" DataSourceID="odsBooleano" Width="150px">
                            </asp:DropDownList>
                          
                            <asp:CustomValidator ID="cvExistenRadiografiasD" runat="server" ControlToValidate="ddlExistenRadiografiasD"
                                ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                    </tr>
                         <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblFotoD" runat="server" Visible="False">Foto</asp:Label>
                        </td>
                        <td align="left" class="style4">
                             <asp:DropDownList ID="ddlFotoD" runat="server" DataSourceID="odsBooleano" DataTextField="Descripcion"
                                DataValueField="Id" Visible="False" Width="150px">
                            </asp:DropDownList>
                            <asp:CustomValidator ID="cvFotoD" runat="server" ControlToValidate="ddlFotoD" ErrorMessage="Debe seleccionar un dato"></asp:CustomValidator>
                        </td>
                        <td align="left" class="style3">
                            &nbsp;</td>
                        <td align="left" class="style4">
                        
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblSeniaParticularD" runat="server">Señas Particulares</asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:GridView ID="gvSenasPartD" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                OnRowCancelingEdit="gvSenasPart_RowCancelingEdit" OnRowDeleting="gvSenasPart_RowDeleting"
                                OnRowEditing="gvSenasPart_RowEditing" OnRowUpdating="gvSenasPart_RowUpdating"
                                ShowFooter="True" BorderColor="Black" Width="100%">
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
                                            <asp:Label ID="Label25" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                        </ItemTemplate>
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
                                            <asp:Label ID="Label21" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Descripción" SortExpression="Descripcion">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="descripcionSenaPart" runat="server" Text='<%# Eval("Descripcion") %>' CssClass="ingreso"/>
                                         </EditItemTemplate>
                                        <FooterTemplate>
                                           <asp:TextBox ID="descripcionInsert" runat="server" CssClass="ingreso" />
                                       </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2133" runat="server" Text='<%# Eval("Descripcion") %>' CssClass="ingreso"></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" SortExpression="idTablaDestino"
                                        Visible="False" />
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Ok"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="X"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="btnAgregarSeniaD" runat="server" CausesValidation="False" CommandArgument="D"
                                                OnClick="btnAgregarSenia_Click" Text="<< Incorporar"></asp:LinkButton>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Editar"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Borrar"></asp:LinkButton>
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
                                            <td>
                                            <asp:Label ID="lblDescripion" CssClass="ingreso"  runat="server" Text="Descripción"></asp:Label>
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
                                                <asp:TextBox ID="descripcionSenaPart" CssClass="ingreso"  runat="server" Text='<%# Eval("Descripcion") %>' />
                                            </td>

                                            <td>
                                                <asp:LinkButton ID="btnSendD" runat="server" CommandArgument="D" CommandName="EmptyInsert"
                                                    OnClick="btnAgregarPrimeraSenia_Click" Text="<< Incorporar" UseSubmitBehavior="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                         <td width="20%" align="left" valign="top">
                             <asp:CustomValidator ID="cvSenaSinIncorporar" runat="server" 
                                 ErrorMessage="Pulse 'Incorporar' o bien indique 'Seleccionar' tanto en Seña como Ubicación"></asp:CustomValidator>
                        </td>
                    </tr>
                    



                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblTatuajesD" runat="server">Tatuajes</asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:GridView ID="gvTatuajesD" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                OnRowCancelingEdit="gvTatuajes_RowCancelingEdit" OnRowDeleting="gvTatuajes_RowDeleting"
                                OnRowEditing="gvTatuajes_RowEditing" 
                                OnRowUpdating="gvTatuajes_RowUpdating" ShowFooter="True"
                                BorderColor="Black" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                        SortExpression="id" Visible="False" />
                                    <asp:BoundField DataField="idPersona" HeaderText="idPersona" SortExpression="idPersona"
                                        Visible="False" />
                                    <asp:TemplateField HeaderText="Tatuaje" SortExpression="idTatuaje">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlTatuajes" runat="server" DataSourceID="odsTatuajes" DataTextField="descripcion"
                                                DataValueField="id" SelectedValue='<%# Eval("idTatuaje") %>'>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlTatuajeInsert" runat="server" DataSourceID="odsTatuajes"
                                                DataTextField="descripcion" DataValueField="id">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseTatuajeManager.GetItem(Convert.ToInt32(Eval("idTatuaje").ToString())).descripcion.ToLower() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionTatuaje">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlUbicacionTatuaje" runat="server" DataSourceID="odsUbicacionSeniaParticular"
                                                DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Eval("idUbicacionTatuaje") %>'>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlUbicacionTatuajeInsert" runat="server" DataSourceID="odsUbicacionSeniaParticular"
                                                DataTextField="descripcion" DataValueField="id">
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionTatuaje").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                       <asp:TemplateField HeaderText="Descripción" SortExpression="Descripcion">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="descripcionTatuajePart" runat="server" Text='<%# Eval("Descripcion") %>'  CssClass="ingreso"/>
                                         </EditItemTemplate>
                                        <FooterTemplate>
                                           <asp:TextBox ID="descripcionTatuajeInsert" runat="server"  CssClass="ingreso"/>
                                       </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTatuaje" runat="server" Text='<%# Eval("Descripcion") %>' CssClass="ingreso"></asp:Label>
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
                                                OnClick="btnAgregarTatuaje_Click" Text="<< Incorporar"></asp:LinkButton>
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
                                            <td>
                                            <asp:Label ID="LabelDescripcionTatuaje" runat="server" Text="Descripción"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlTatuajes" runat="server" DataSourceID="odsTatuajes" DataTextField="descripcion"
                                                    DataValueField="id">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlUbicacionTatuaje" runat="server" DataSourceID="odsUbicacionSeniaParticular"  CssClass="ingreso"
                                                    DataTextField="Descripcion" DataValueField="Id">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="descripcionTatuajeInsert" runat="server" />
                                             </td>
                                            <td>
                                                <asp:LinkButton ID="btnSend" runat="server" CommandArgument="D" CommandName="EmptyInsert"
                                                    OnClick="btnAgregarPrimerTatuaje_Click" Text="<< Incorporar" UseSubmitBehavior="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            </td>
                            <td width="20%" align="left" valign="top">
                              
                                <asp:CustomValidator ID="cvTatuajeSinIncorporar" runat="server" 
                                    ErrorMessage="Pulse 'Incorporar' o bien indique 'Seleccionar' tanto en Tatuaje como Ubicación"></asp:CustomValidator>
                        </td>
                       
                     
                        
                    </tr>
  
                </table>
                <br />
                <%-- <table width="100%" style="margin: 15px" bgcolor="#D7E3EC">--%>
                <table width="98%" bgcolor="#dee4e4">
                    <tr>
                        <td align="left" class="style3">
                            <asp:Label ID="lblImagenes" runat="server" Text="Imágenes"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <div align="left" style="margin: 15px; border-style: solid; border-width: 1px;">
                                <asp:UpdatePanel ID="upSubirFotoGeneralD" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td width="50%">
                                                    <asp:Label ID="lblFotoGeneralD" runat="server" Text="Foto General" Font-Underline="True"></asp:Label>
                                                </td>
                                                <td width="50%">
                                                    <asp:Label ID="lblFotoSeD" runat="server" Text="Foto Señas Particulares" Font-Underline="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="50%">
                                                    <asp:ImageButton ID="imgFotoGeneralD" runat="server" Height="80px" ImageUrl="~/App_Images/SinFoto.GIF"
                                                        Width="100px" />
                                                </td>
                                                <td width="50%">
                                                    <asp:ImageButton ID="imgFotoSeniasD" runat="server" Height="80px" ImageUrl="~/App_Images/SinFoto.GIF"
                                                        Width="100px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="50%">
                                                    <asp:Button ID="btnFotoPrevGeneralD" runat="server" Text="<" OnClick="btnFotoPrevGeneralD_Click"
                                                        Width="30px" />
                                                    <asp:Button ID="btnFotoSigGeneralD" runat="server" Text=">" OnClick="btnFotoSigGeneralD_Click"
                                                        Width="30px" />
                                                    <asp:Button ID="btnBorrarFotoGralD" runat="server" Text="X" OnClick="btnBorrarFotoGralD_Click"
                                                        OnClientClick="return confirm('Seguro que desea borrar la foto?')" Width="30px" />
                                                </td>
                                                <td width="50%">
                                                    <asp:Button ID="btnFotoPrevSeniasD" runat="server" Text="<" OnClick="btnFotoPrevSeniasD_Click"
                                                        Width="30px" />
                                                    <asp:Button ID="btnFotoSigSeniasD" runat="server" Text=">" OnClick="btnFotoSigSeniasD_Click"
                                                        Width="30px" />
                                                    <asp:Button ID="btnBorrarFotoSeniasD" runat="server" Text="X" OnClick="btnBorrarFotoSeniasD_Click"
                                                        OnClientClick="return confirm('Seguro que desea borrar la foto?')" Width="30px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="50%">
                                                    <asp:Label ID="lblNroFotoGralD" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td width="50%">
                                                    <asp:Label ID="lblNroFotoSeniasD" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label334" runat="server" Font-Underline="False" Text="Buscar foto a subir"
                                                        Font-Bold="True" Font-Italic="True"></asp:Label>
                                                    <br />
                                                    <asp:FileUpload runat="server" ID="fuFotoUploaderD" Enabled="False" Width="300px" />
                                                    <br />
                                                    <br />
                                                    <asp:Label ID="lblMesgErrorFotoD" runat="server" Style="color: red" Text="Subir foto con extension JPG."
                                                        Visible="False" />
                                                    <br />
                                                    <asp:Label runat="server" ID="lblPresioneBoton" Text="Presione el botón SUBIR IMAGEN."
                                                        ForeColor="Green"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div align="center" style="border-style: solid none none none; border-width: 1px">
                                    <asp:Button ID="btnSubirFotoD" runat="server" Text="Subir Imagen" OnClick="btnSubirFotoD_Click"
                                        Width="100px" Font-Bold="True" />
                                    <asp:HiddenField ID="hfElegirTipoFotoD" runat="server" />
                                    <asp:ModalPopupExtender ID="hfElegirTipoFotoD_ModalPopupExtender" runat="server"
                                        BackgroundCssClass="FondoOscuro" CancelControlID="btnCancelarTipoFoto" DynamicServicePath=""
                                        Enabled="True" PopupControlID="pnlGuardarFotos" TargetControlID="hfElegirTipoFotoD"
                                        Drag="True" PopupDragHandleControlID="divHeaderGuardarFotos">
                                    </asp:ModalPopupExtender>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:UpdateProgress runat="server" ID="upWaitingD" DisplayAfter="100">
                <ProgressTemplate>
                    <asp:Panel ID="pnlWaitingOverlayD" CssClass="" runat="server">
                        <asp:Panel ID="pnlWaitingD" CssClass="" runat="server">
                            <asp:Image ID="imgWaitingD" runat="server" ImageUrl="~/App_Images/loader.gif" 
                                Width="27px" />
                        </asp:Panel>
                    </asp:Panel>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubirFotoD" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upBotonesD" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlBotones" runat="server">
                <table width="100%" style="border: 1px solid #00CCFF;">
                    <tr>
                        <td width="20%">
                        </td>
                        <td width="10%">
                            <asp:Button ID="btnLimpiarD" runat="server" OnClick="btnLimpiarD_Click" Text="Limpiar"
                                Width="105px" />
                        </td>
                        <td width="10%">
                            <asp:Button ID="btnImprimirD" runat="server" Text="Imprimir" Width="105px" 
                                onclick="btnImprimirD_Click" />
                        </td>
                        <td width="10%">
                            <asp:Button ID="btnVerCriterioBusquedaD" runat="server" OnClick="btnVerCriterioBusquedaD_Click"
                                Text="Ver Criterio Busq." Width="105px" />
                        </td>
                        <td width="10%">
                            <asp:Button ID="btnVerResultadosD" runat="server" OnClick="btnVerResultadosD_Click"
                                Text="Buscar Resultados" Width="105px" />
                        </td>
                        <td width="10%">
                            <asp:Button ID="btnGuardarD" runat="server" Font-Bold="True" OnClick="btnGuardarD_Click"
                                Text="Guardar" Width="105px" />
                        </td>
                        <td width="10%">
                            <asp:Button ID="btnBorrarD" runat="server" OnClick="btnBorrarD_Click" Text="Eliminar" />
                        </td>
                        <td>
                            <asp:Button ID="btnSalir" runat="server" Text="Salir" Height="22px" Width="105px"
                                UseSubmitBehavior="False" OnClick="btnSalir_Click" />
                        </td>
                    </tr>
                    <tr>
                    <td colspan="8">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Errores Ocurridos:"
                        Width="193px" Height="56px" Visible="False" />
                    </td>
                    </tr>
                    <tr>
                        <td width="20%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="10%">
                            &nbsp;</td>
                        <td width="10%">
                            <asp:Label ID="lblGuardoExitoD" runat="server" ForeColor="#009933" Text="SE GUARDO EXITOSAMENTE"
                                Visible="False" Font-Bold="True"></asp:Label>
                        </td>
                        <td width="10%">
                        </td>
                        <td width="20%">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsSenasParticulares" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.SeniasParticulares"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.SeniasParticularesManager" 
        UpdateMethod="Save">
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
    <asp:ObjectDataSource ID="odsLocalidad" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.Localidad"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.LocalidadManager" UpdateMethod="Save"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsLugarDesap" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.Localidad"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.LocalidadManager" UpdateMethod="Save"></asp:ObjectDataSource>
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
   <asp:ObjectDataSource ID="odsTipoDocumento" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseTipoDNI"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.ClaseTipoDNIManager" UpdateMethod="Save"></asp:ObjectDataSource>
    <asp:HiddenField ID="hfAbrirComisarias" runat="server" />
    <asp:HiddenField ID="hfAbrirBusquedaIndividual" runat="server" />
    <asp:ModalPopupExtender ID="hfAbrirBusquedaIndividual_ModalPopupExtender" runat="server"
        BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
        Enabled="True" PopupControlID="pnlBusquedaIndividual" PopupDragHandleControlID="divHeaderBusquedaIndividual"
        TargetControlID="hfAbrirBusquedaIndividual">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hfVerCriterioBI" runat="server" />
    <asp:ModalPopupExtender ID="hfVerCriterioBI_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
        Drag="True" DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlVerCriterioBI"
        PopupDragHandleControlID="divHeaderVerCriterioBI" TargetControlID="hfVerCriterioBI">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hfAbrirResultadosBI" runat="server" />
    <asp:ModalPopupExtender ID="hfAbrirResultadosBI_ModalPopupExtender1" runat="server"
        BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
        Enabled="True" PopupControlID="pnlResultadosBI" PopupDragHandleControlID="divHeaderResultadosBI"
        TargetControlID="hfAbrirResultadosBI">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="hfAbrirComisarias_ModalPopupExtender" runat="server"
        BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
        Enabled="True" PopupControlID="pnlComisarias" PopupDragHandleControlID="divHeaderComisarias"
        TargetControlID="hfAbrirComisarias">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hfAbrirLugar" runat="server" />
    <asp:ModalPopupExtender ID="hfAbrirLugar_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
        CancelControlID="btnCancelarLugar" Drag="True" DropShadow="True" DynamicServicePath=""
        Enabled="True" OkControlID="hfLugar" PopupControlID="pnlLugar" PopupDragHandleControlID="divHeaderLocalidad"
        TargetControlID="hfAbrirLugar">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlGuardarFotos" runat="server" CssClass="FondoModal" Width="300px">
        <div>
            <div id="divHeaderGuardarFotos" class="ModalHeader">
                GUARDAR FOTOS</div>
            <div style="position: relative; overflow: auto;" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel runat="server" ID="upImage" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Image ID="imgFotoPreview" runat="server" Height="80px" ImageUrl="~/App_Images/SinFoto.GIF"
                                        Width="100px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label26" runat="server" Text="Indique tipo de fotos a guardar"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:RadioButtonList ID="rblTipoFotos" runat="server" DataSourceID="odsTipoFotos"
                                DataTextField="tipoFoto" DataValueField="id">
                            </asp:RadioButtonList>
                            <asp:ObjectDataSource ID="odsTipoFotos" runat="server" DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBClaseFoto"
                                DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                                TypeName="MPBA.PersonasBuscadas.Bll.PBClaseFotoManager" UpdateMethod="Save">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="padding-top: 10px; position: relative;">
                <asp:HiddenField ID="hfTipoFoto" runat="server" />
                <asp:ModalPopupExtender ID="hfTipoFoto_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                    CancelControlID="btnCancelarTipoFoto" Drag="True" DynamicServicePath="" Enabled="True"
                    PopupControlID="pnlGuardarFotos" PopupDragHandleControlID="divHeaderTipoFotos"
                    TargetControlID="hfTipoFoto">
                </asp:ModalPopupExtender>
                <asp:Button ID="btnOkTipoFoto" runat="server" Text="OK" OnClick="btnOkTipoFoto_Click"
                    Width="50px" />
                <asp:Button ID="btnCancelarTipoFoto" runat="server" Text="X" Width="50px" />
                
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlComisarias" CssClass="FondoModal" Width="500px">
        <div>
            <div id="divHeaderComisarias" class="ModalHeader">
                ELEGIR COMISARIA</div>
            <div style="height: 250px; position: relative; overflow: auto;">
                <asp:UpdatePanel ID="upComisarias" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress runat="server" ID="upWaitingComisaria" DisplayAfter="100">
                            <ProgressTemplate>
                                <asp:Panel ID="pnlWaitingOverlayComisaria" CssClass="" runat="server">
                                    <asp:Panel ID="pnlWaitingComisaria" CssClass="" runat="server">
                                        <asp:Image ID="imgWaitingComisaria" runat="server" 
                                            ImageUrl="~/App_Images/loader.gif" Width="27px" />
                                    </asp:Panel>
                                </asp:Panel>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <table width="100%">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblDepartamentoComisarias" runat="server" Text="Departamento"></asp:Label><asp:DropDownList
                                        ID="ddlDepartamentosComisarias" runat="server" DataSourceID="odsDepartamentos"
                                        DataTextField="departamento" DataValueField="Id" OnSelectedIndexChanged="ddlDepartamentosComisarias_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsDepartamentos" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento"
                                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                                        TypeName="MPBA.SIAC.Bll.DepartamentoManager" UpdateMethod="Save"></asp:ObjectDataSource>
                                    <br />
                                    <asp:GridView ID="gvComisarias" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                        OnSelectedIndexChanged="gvComisarias_SelectedIndexChanged" Height="156px" PageSize="4"
                                        Width="400px">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnElegirComisaria" runat="server" CausesValidation="False" CommandName="Select"
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
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="padding-top: 10px; position: relative;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr style="text-align: center">
                                <td>
                                    <asp:Button ID="btnCancelarComisarias" runat="server" OnClick="btnCancelarComisarias_Click"
                                        Text="Cerrar" Width="50px" Height="22px" UseSubmitBehavior="False" />
                                    <br />
                                    <asp:HiddenField ID="hfComisarias" runat="server" />
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
    <asp:Panel ID="pnlLugar" runat="server" DefaultButton="btnTraerLugar" CssClass="FondoModal"
        Width="500px">
        <div>
            <div id="divHeaderLocalidad" class="ModalHeader">
                ELEGIR LOCALIDAD</div>
            <div style="height: 250px; position: relative; overflow: auto;">
                <asp:UpdatePanel ID="upLugar" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress runat="server" ID="upWaitingLocalidad" DisplayAfter="100">
                            <ProgressTemplate>
                                <asp:Panel ID="pnlWaitingOverlayLocalidad" CssClass="" runat="server">
                                    <asp:Panel ID="pnlWaitingLocalidad" CssClass="" runat="server">
                                        <asp:Image ID="imgWaitingLocalidad" runat="server" 
                                            ImageUrl="~/App_Images/loader.gif" Width="27px" />
                                    </asp:Panel>
                                </asp:Panel>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div style="height: 200px; overflow: auto">
                            <table width="100%">
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLugar" runat="server" Text="Lugar"></asp:Label><asp:TextBox ID="txtLugar"
                                            runat="server" CausesValidation="True"></asp:TextBox><asp:Button ID="btnTraerLugar"
                                                runat="server" OnClick="btnTraerLugar_Click" Text="Traer" Width="44px" />
                                        <asp:HiddenField ID="hfLugarElegido" runat="server" />
                                        <br />
                                        <asp:Label ID="lblDemasiadosResultados" runat="server" ForeColor="#CC0000" Text="Demasiados resultados, amplie la busqueda"
                                            Visible="False"></asp:Label><br />
                                        <asp:GridView ID="gvLugar" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                            OnSelectedIndexChanged="gvLugar_SelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnElegirLugar" runat="server" CommandName="Select" Height="19px"
                                                            Text="Elegir" Width="44px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="id" Visible="False" />
                                                <asp:BoundField DataField="localidad" HeaderText="localidad" SortExpression="localidad" />
                                                <asp:TemplateField HeaderText="Partido" SortExpression="Partido">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPartidoGrid" runat="server" Text='<%# MPBA.SIAC.Bll.PartidoManager.GetItem(Convert.ToInt32(Eval("partido").ToString())).partido %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CodigoPostal" HeaderText="CodigoPostal" SortExpression="CodigoPostal" />
                                                <asp:TemplateField HeaderText="Provincia" SortExpression="Provincia">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProvinciaGrid" runat="server" Text='<%# MPBA.SIAC.Bll.ProvinciaManager.GetItem(Convert.ToInt32(Eval("Provincia").ToString())).provincia %>'></asp:Label></ItemTemplate>
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
                            <asp:Button ID="btnCancelarLugar" runat="server" CausesValidation="False" OnClick="btnCancelarLugar_Click"
                                Text="Cerrar" UseSubmitBehavior="False" Width="50px" />
                            <br />
                            <asp:HiddenField ID="hfLugar" runat="server" />
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
    <asp:Panel ID="pnlResultadosBI" runat="server" CssClass="FondoModal" Width="600px">
        <div>
            <div id="divHeaderResultadosBI" class="ModalHeader">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" Text="RESULTADOS DE LA BUSQUEDA" ID="lblResultadosBI"></asp:Label>
                        <asp:Label runat="server" ID="lblCantResultados" ></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="height: 250px; position: relative; overflow: auto;">
                <asp:UpdatePanel ID="upResultadosBI" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:GridView ID="gvResultadosHalladasBI" runat="server" AutoGenerateColumns="False"
                                        Caption="PERSONAS HALLADAS" CaptionAlign="Left" DataKeyNames="Id" OnSelectedIndexChanged="gvResultadosHalladasBI_SelectedIndexChanged"
                                        OnRowDeleting="gvResultadosHalladasBI_RowDeleting">
                                        <Columns>
                                            <asp:CommandField DeleteText="X" ShowDeleteButton="True" />
                                            <asp:CommandField CancelText="X" DeleteText="X" EditText="Editar" InsertText="Insertar"
                                                NewText="Nuevo" SelectText="Ver" ShowSelectButton="True" />
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="Id" Visible="False" />
                                            <asp:BoundField DataField="Ipp" HeaderText="IPP" SortExpression="Ipp" />
                                            <asp:BoundField DataField="UFI" HeaderText="UFI" SortExpression="UFI" />
                                            <asp:BoundField DataField="CoincidenciaCantidad" HeaderText="Coincidencias" SortExpression="CoincidenciaCantidad" />
                                            <asp:TemplateField HeaderText="Nombre" SortExpression="Apellido">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Apellido") %> & " , " & <%# Bind("Nombre") %>'></asp:TextBox></EditItemTemplate>
                                                 <ItemTemplate>
                                                   <%-- <asp:Label ID="lblNombre" runat="server" --%>
                                                        <%--Text='<%# Bind("Apellido") %> + " , " +  <%# Bind("Nombre") %>'></asp:Label>--%>
                                                        <asp:Label ID="lblApe" runat="server" 
                                                            Text='<%# Bind("Apellido") %>'
                                                             ForeColor='<%# Eval("CoincidenciaNombreyApellido").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#3399FF"):System.Drawing.Color.Black%>'></asp:Label> 
                                                        <asp:Label ID="Lblnomb" runat="server" 
                                                            Text='<%# Eval("Nombre") %>' ForeColor='<%# Eval("CoincidenciaNombreyApellido").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#3399FF"):System.Drawing.Color.Black%>'></asp:Label> 

                                                    <br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DNI" SortExpression="DNI">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox22" runat="server" 
                                                        Text='<%# Bind("DNI") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                        <asp:Label ID="lblDNI" runat="server" 
                                                            Text='<%# Bind("DNI") %>'   ForeColor='<%# Eval("CoincidenciaDNI").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#3399FF"):System.Drawing.Color.Black%>'></asp:Label> 
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
                                                    <asp:Label ID="Label19" runat="server" ForeColor='<%# Eval("coincidenciaFecha").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# Eval("FechaHallazgo")==null?"":Convert.ToDateTime(Eval("FechaHallazgo")).ToString("dd/MM/yyyy") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" ForeColor='<%# Eval("coincidenciaSexo").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edad Aparente" SortExpression="EdadAparente">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("EdadAparente") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label26" runat="server" Text='<%# Bind("EdadAparente")  %>' ForeColor='<%# Eval("coincidenciaEdadAparente").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Talla" SortExpression="Talla">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox21" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# Bind("Talla") %>' ForeColor='<%# Eval("coincidenciaTalla").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Peso" SortExpression="Peso">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("Peso") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label22" runat="server" Text='<%# Bind("Peso") %>' ForeColor='<%# Eval("coincidenciaPeso").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Piel" SortExpression="idColorPiel">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("idColorPiel") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" ForeColor='<%# Eval("coincidenciaColorPiel").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseColorDePielManager.GetItem(Convert.ToInt32(Eval("idColorPiel").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Cabello" SortExpression="idColorCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox6" runat="server" ForeColor='<%# Eval("coincidenciaColorCabello").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# Bind("idColorCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorCabello").ToString())).Descripcion.ToLower() %>' ForeColor='<%# Eval("coincidenciaColorCabello").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Tenido" SortExpression="idColorTenido">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("idColorTenido") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" ForeColor='<%# Eval("coincidenciaColorTenido").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorCabelloManager.GetItem(Convert.ToInt32(Eval("idColorTenido").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Long. Cabello" SortExpression="idLongitudCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("idLongitudCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" ForeColor='<%# Eval("coincidenciaLongitudCabello").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(Eval("idLongitudCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Aspecto Cabello" SortExpression="idAspectoCabello">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("idAspectoCabello") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" ForeColor='<%# Eval("coincidenciaAspectoCabello").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(Eval("idAspectoCabello").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Calvicie" SortExpression="idCalvicie">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("idCalvicie") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label10" runat="server" ForeColor='<%# Eval("coincidenciaCalvicie").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseCalvicieManager.GetItem(Convert.ToInt32(Eval("idCalvicie").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Color Ojos" SortExpression="idColorOjos">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("idColorOjos") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" ForeColor='<%# Eval("coincidenciaColorOjos").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseColorOjosManager.GetItem(Convert.ToInt32(Eval("idColorOjos").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
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
                                                    <asp:Label ID="Label13" runat="server" ForeColor='<%# Eval("coincidenciaFaltanDientes").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("FaltanPiezasDentales").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fichas Dact." SortExpression="FichasDactilares">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("FichasDactilares") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseBooleanManager.GetItem(Convert.ToInt32(Eval("FichasDactilares").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Señas Part." SortExpression="CoincidenciasSeniasParticulares">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox20" runat="server" Text='<%# Eval("CoincidenciaSeniasParticulares").ToString()%>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSenasPartGridD" runat="server" Text='<%#Eval("CoincidenciaSeniasParticulares").ToString() %>' ForeColor='<%# Convert.ToInt32(Eval("CoincidenciaSeniasParticulares").ToString())>0?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Tatuajes" SortExpression="CoincidenciasTatuajes">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox20" runat="server" Text='<%# Eval("CoincidenciasTatuajes").ToString()%>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTatuajesGridD" runat="server" Text='<%#Eval("CoincidenciasTatuajes").ToString() %>' ForeColor='<%# Convert.ToInt32(Eval("CoincidenciasTatuajes").ToString())>0?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'></asp:Label><br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ADN" SortExpression="ADN">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox23" runat="server" Text='<%# Bind("ADN") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label23" runat="server" ForeColor='<%# Eval("CoincidenciaADN").ToString()=="1"?System.Drawing.ColorTranslator.FromHtml("#669900"):System.Drawing.Color.Black %>'
                                                        Text='<%# Bind("ADN") %>'></asp:Label><br />
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
                                        </Columns>
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
                            <td >
                                    <asp:Label ID="lblLeyendaAzulBI" runat="server" BackColor="#3399FF" BorderColor="Black"
                                        BorderWidth="2px" ForeColor="#33CC33" Text = "cc" ></asp:Label><asp:Label ID="lblLeyendaAzul"
                                            runat="server" Text="Hay Coincidencia de Datos Filiatorios"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="lblLeyendaVerdeBI" runat="server" BackColor="#669900" BorderColor="Black"
                                        BorderWidth="2px" ForeColor="#33CC33"  Text = "cc"></asp:Label><asp:Label ID="lblLeyendaBI"
                                            runat="server" Text="Hay Coincidencia"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr style="text-align: center">
                                <td colspan="2">
                                    <asp:Button ID="btnCancelarResultadosBI" runat="server" CausesValidation="False"
                                        OnClick="btnCancelarResultadosBI_Click" Text="Cerrar" UseSubmitBehavior="False"
                                        Width="50px" BorderStyle="Solid" />
                                    <br />
                                </td>
                                <%--<td align="center">
                                </td>
                                <td>
                                    &nbsp;
                                </td>--%>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
            <asp:HiddenField ID="hfGestionFichaPersHalladaBI" runat="server" />
            <asp:ModalPopupExtender ID="hfGestionFichaPersHalladaBI_ModalPopupExtender" runat="server"
                BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
                Enabled="True" PopupControlID="pnlFichaPersHalladaBI" PopupDragHandleControlID="divHeaderFichaPersHalladaBI"
                RepositionMode="None" TargetControlID="hfGestionFichaPersHalladaBI" X="300" Y="-300">
            </asp:ModalPopupExtender>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlBusquedaIndividual" runat="server" CssClass="FondoModal" Width="900px">
        <div>
            <div id="divHeaderBusquedaIndividual" class="ModalHeader">
                DEFINIR CRITERIO DE BUSQUEDA</div>
            <div style="height: 400px; position: relative; overflow: auto;">
                
                <asp:UpdatePanel ID="upBusquedaIndividual" runat="server">
                    <ContentTemplate>
                        <table class="style2">
                            <tr>
                                <td align="right" colspan="3" width="85%">
                                    <asp:Label ID="lblCoincidencia" runat="server">Cantidad de coincidencias con los resultados mostrados</asp:Label>
                                    <asp:TextBox ID="txtCoincidenciaBI" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                                    <asp:NumericUpDownExtender ID="txtCoincidenciaBI_NumericUpDownExtender" 
                                        runat="server" Enabled="True" Maximum="30" Minimum="5" RefValues="" 
                                        ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" 
                                        TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtCoincidenciaBI" 
                                        Width="50">
                                    </asp:NumericUpDownExtender>
                                </td>
                                <td align="left">
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFechaBI" runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Size="Small" ForeColor="#0033CC">Fecha</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblValorFechaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">ValorFecha</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFechaDesdeBI" runat="server">Fecha Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaDesdeBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtFechaDesdeBI_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="False" 
                                        TargetControlID="txtFechaDesdeBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevFechaDesdeBI" runat="server" 
                                        ControlExtender="txtFechaDesdeBI_MaskedEditExtender" 
                                        ControlToValidate="txtFechaDesdeBI" ErrorMessage="mevFechaDesdeBI" 
                                        InvalidValueMessage="Fecha incorrecta"></asp:MaskedEditValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaHastaBI" runat="server">Fecha Hasta</asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtFechaHastaBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtFechaHastaBI_MaskedEditExtender" runat="server" 
                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaHastaBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevFechaHastaBI" runat="server" 
                                        ControlExtender="txtFechaHastaBI_MaskedEditExtender" 
                                        ControlToValidate="txtFechaHastaBI" EmptyValueMessage="Ingrese una fecha" 
                                        ErrorMessage="Fecha incorrecta" InvalidValueMessage="Fecha incorrecta" 
                                        TooltipMessage="Ingrese una fecha"></asp:MaskedEditValidator>
                                    <br />
                                    <asp:CustomValidator ID="cvFechasBI" runat="server" 
                                        ControlToValidate="txtFechaDesdeBI" ErrorMessage="Rango de fechas inválido"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEdadBI" runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Size="Small" ForeColor="#0033CC">Edad</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblValorEdadBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">ValorEdad</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblSexoPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Sexo</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSexoPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">ValorSexo</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEdadDesdeBI" runat="server">Edad Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEdadDesdeBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtEdadDesdeBI_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="999" MaskType="Number" TargetControlID="txtEdadDesdeBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevEdadDesdeBI" runat="server" 
                                        ControlExtender="txtEdadDesdeBI_MaskedEditExtender" 
                                        ControlToValidate="txtEdadDesdeBI" ErrorMessage="mevEdadDesdeBI" 
                                        InvalidValueMessage="Rango de edad incorrecto">
                                     </asp:MaskedEditValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblEdadHastaBI" runat="server">Edad Hasta</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEdadHastaBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtEdadHastaBI_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="999" MaskType="Number" TargetControlID="txtEdadHastaBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevEdadHastaBI" runat="server" 
                                        ControlExtender="txtEdadHastaBI_MaskedEditExtender" 
                                        ControlToValidate="txtEdadHastaBI" ErrorMessage="mevEdadHastaBI" 
                                        InvalidValueMessage="Rango de edad incorrecto"></asp:MaskedEditValidator>
                                    <asp:CustomValidator ID="cvEdadesBI" runat="server" 
                                        ControlToValidate="txtEdadHastaBI" ErrorMessage="Rango de edad inválido"></asp:CustomValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblSexoBI" runat="server">Sexo</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSexoBI" runat="server" DataSourceID="odsSexo" 
                                        DataTextField="Descripcion" DataValueField="Id">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cbSexo" runat="server" ControlToValidate="ddlSexoBI" 
                                        ErrorMessage="Ingreso Obligatorio">
                                    </asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTallaPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Talla</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTallaPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">ValorTalla</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblCalviciePersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Calvicie</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCalviciePersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">CalvicieValor</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTallaDesdeBI" runat="server">Talla Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTallaDesdeBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtTallaDesdeBI_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="999" MaskType="Number" TargetControlID="txtTallaDesdeBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevTallaDesdeBI" runat="server" 
                                        ControlExtender="txtTallaDesdeBI_MaskedEditExtender" 
                                        ControlToValidate="txtTallaDesdeBI" ErrorMessage="mevTallaDesdeBI" 
                                        InvalidValueMessage="Rango de tallas incorrecto"></asp:MaskedEditValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblTallaHastaBI" runat="server">Talla Hasta</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTallaHastaBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtTallaHastaBI_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="999" MaskType="Number" TargetControlID="txtTallaHastaBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevTallaHastaBI" runat="server" 
                                        ControlExtender="txtTallaHastaBI_MaskedEditExtender" 
                                        ControlToValidate="txtTallaHastaBI" ErrorMessage="mevTallaHastaBI" 
                                        InvalidValueMessage="Rango de talla incorrecto"></asp:MaskedEditValidator>
                                    <asp:CustomValidator ID="cvTallasBI" runat="server" 
                                        ControlToValidate="txtTallaHastaBI" ErrorMessage="Rango de talla inválido"></asp:CustomValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblCalvicieBI" runat="server">Calvicie</asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="lstCalvicieBI" runat="server" DataSourceID="odsCalvicie" 
                                        DataTextField="Descripcion" DataValueField="Id" SelectionMode="Multiple">
                                    </asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPesoPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Peso</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPesoPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">ValorPeso</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorPielpersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Color de Piel</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorPielPersonaValorBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Color de Piel</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPesoDesdeBI" runat="server">Peso Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPesoDesdeBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtPesoDesdeBI_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="999" MaskType="Number" TargetControlID="txtPesoDesdeBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevPesoDesdeBI" runat="server" 
                                        ControlExtender="txtPesoDesdeBI_MaskedEditExtender" 
                                        ControlToValidate="txtPesoDesdeBI" ErrorMessage="mevPesoDesdeBI" 
                                        InvalidValueMessage="Rango de peso incorrecto"></asp:MaskedEditValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPesoHastaBI" runat="server">Peso Hasta</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPesoHastaBI" runat="server" Width="70px"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtPesoHastaBI_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="999" MaskType="Number" TargetControlID="txtPesoHastaBI">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="mevPesoHastaBI" runat="server" 
                                        ControlExtender="txtPesoHastaBI_MaskedEditExtender" 
                                        ControlToValidate="txtPesoHastaBI" ErrorMessage="mevPesoHastaBI" 
                                        InvalidValueMessage="Rango de peso incorrecto"></asp:MaskedEditValidator>
                                    <asp:CustomValidator ID="cvPesosBI" runat="server" 
                                        ControlToValidate="txtPesoHastaBI" ErrorMessage="Rango de peso inválido"></asp:CustomValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorPielBI" runat="server">Color Piel</asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="lstColorPielBI" runat="server" DataSourceID="odsColorPiel" 
                                        DataTextField="Descripcion" DataValueField="Id" SelectionMode="Multiple">
                                    </asp:ListBox>
                                    <asp:CustomValidator ID="cbColorDePiel" runat="server" 
                                        ControlToValidate="lstColorPielBI" ErrorMessage="Ingreso Obligatorio   ">
                               </asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblColorCabelloPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Color de Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorCabelloPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Color de Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorTenidoPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Color de Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorTeñidoPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Color de Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLongCabelloPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Longitud de Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLongCabelloPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Color de Cabello</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblColorCabelloBI" runat="server">Color Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="lstColorCabelloBI" runat="server" 
                                        DataSourceID="odsColorCabello" DataTextField="Descripcion" DataValueField="Id" 
                                        SelectionMode="Multiple"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorTenidoBI" runat="server">Color Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="lstColorTenidoBI" runat="server" DataSourceID="odsColorTenido" 
                                        DataTextField="Descripcion" DataValueField="Id" SelectionMode="Multiple">
                                    </asp:ListBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblLongitudCabelloBI" runat="server">Longitud Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="lstLongitudCabelloBI" runat="server" 
                                        DataSourceID="odsLongitudCabello" DataTextField="Descripcion" 
                                        DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAspectoCabelloPersonaBi" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAspectoCabelloPersonaBiValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorOjosPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Color Ojos</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorOjosBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Color ojos</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAspectoCabelloBI" runat="server">Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                    <br />
                                    <asp:ListBox ID="lstAspectoCabelloBI" runat="server" 
                                        DataSourceID="odsAspectoCabello" DataTextField="Descripcion" 
                                        DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblColorOjosBI" runat="server">Color Ojos</asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="lstColorOjosBI" runat="server" DataSourceID="odsColorOjos" 
                                        DataTextField="Descripcion" DataValueField="Id" SelectionMode="Multiple">
                                    </asp:ListBox>
                                    <asp:CustomValidator ID="cbColorOjos" runat="server" 
                                        ControlToValidate="lstColorOjosBI" ErrorMessage="Ingreso Obligatorio">
                               </asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSeniasBI" runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Size="Small" ForeColor="#0033CC">Señas Particulares</asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblSeniasBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Seña</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSeniaParticularBI" runat="server">Señas Particulares</asp:Label>
                                </td>
                                <td colspan="5">
                                <asp:GridView ID="gvSenasPartBI" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="id" OnRowCancelingEdit="gvSenasPart_RowCancelingEdit" 
                    OnRowDeleting="gvSenasPart_RowDeleting" OnRowEditing="gvSenasPart_RowEditing" 
                    OnRowUpdating="gvSenasPart_RowUpdating" ShowFooter="True">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id" Visible="False" />
                        <asp:BoundField DataField="idPersona" HeaderText="idPersona" 
                            SortExpression="idPersona" Visible="False" />
                        <asp:TemplateField HeaderText="Seña" SortExpression="idSeniaParticular">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSeniaPart" runat="server" 
                                    DataSourceID="odsSeniaParticular" DataTextField="Descripcion" 
                                    DataValueField="Id" SelectedValue='<%# Eval("idSeniaParticular") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlSeniaPartInsert" runat="server" 
                                    DataSourceID="odsSeniaParticular" DataTextField="Descripcion" 
                                    DataValueField="Id">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" 
                                    Text='<%# MPBA.SIAC.Bll.ClaseSeniaParticularManager.GetItem(Convert.ToInt32(Eval("idSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ubicación" 
                            SortExpression="idUbicacionSeniaParticular">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlUbicacionSenaPart" runat="server" 
                                    DataSourceID="odsUbicacionSeniaParticular" DataTextField="Descripcion" 
                                    DataValueField="Id" SelectedValue='<%# Eval("idUbicacionSeniaParticular") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlUbicacionSenaPartInsert" runat="server" 
                                    DataSourceID="odsUbicacionSeniaParticular" DataTextField="Descripcion" 
                                    DataValueField="Id">
                                </asp:DropDownList>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" 
                                    Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionSeniaParticular").ToString())).Descripcion.ToLower() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" 
                            SortExpression="idTablaDestino" Visible="False" />
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandArgument="BI" CommandName="Update" Text="Ok"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandArgument="BI" CommandName="Cancel" Text="X"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAgregarSeniaBI" runat="server" CausesValidation="False" 
                                    CommandArgument="BI" OnClick="btnAgregarSenia_Click" Text="Agregar"></asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandArgument="BI" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandArgument="BI" CommandName="Delete" Text="Borrar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblSeniaPartH" runat="server" Text="Seña"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblUbicacionSeniaPartH" runat="server" Text="Ubicación"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSenasParticulares" runat="server" 
                                        DataSourceID="odsSeniaParticular" DataTextField="Descripcion" 
                                        DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUbicacionSenasPart" runat="server" 
                                        DataSourceID="odsUbicacionSeniaParticular" DataTextField="Descripcion" 
                                        DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnSend" runat="server" CommandArgument="BI" 
                                        CommandName="EmptyInsert" OnClick="btnAgregarPrimeraSenia_Click" Text="Agregar" 
                                        UseSubmitBehavior="false" />
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTatuajeBI" runat="server" Font-Bold="True" Font-Italic="True" 
                                        Font-Size="Small" ForeColor="#0033CC">Tatuajes</asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lblTatuajesBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Tatuaje</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style3">
                                    <asp:Label ID="Label3" runat="server">Tatuajes</asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:GridView ID="gvTatuajesBI" runat="server" AutoGenerateColumns="False" 
                                        BorderColor="Black" DataKeyNames="id" 
                                        OnRowCancelingEdit="gvTatuajes_RowCancelingEdit" 
                                        OnRowDeleting="gvTatuajes_RowDeleting" OnRowEditing="gvTatuajes_RowEditing" 
                                        OnRowUpdating="gvTatuajes_RowUpdating" ShowFooter="True">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                ReadOnly="True" SortExpression="id" Visible="False" />
                                            <asp:BoundField DataField="idPersona" HeaderText="idPersona" 
                                                SortExpression="idPersona" Visible="False" />
                                            <asp:TemplateField HeaderText="Tatuaje" SortExpression="idTatuaje">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlTatuajes" runat="server" DataSourceID="odsTatuajes" 
                                                        DataTextField="descripcion" DataValueField="id" 
                                                        SelectedValue='<%# Eval("idTatuaje") %>'>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlTatuajeInsert" runat="server" 
                                                        DataSourceID="odsTatuajes" DataTextField="descripcion" DataValueField="id">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" 
                                                        Text='<%# MPBA.SIAC.Bll.ClaseTatuajeManager.GetItem(Convert.ToInt32(Eval("idTatuaje").ToString())).descripcion.ToLower() %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ubicación" SortExpression="idUbicacionTatuaje">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlUbicacionTatuaje" runat="server" 
                                                        DataSourceID="odsUbicacionSeniaParticular" DataTextField="descripcion" 
                                                        DataValueField="id" SelectedValue='<%# Eval("idUbicacionTatuaje") %>'>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlUbicacionTatuajeInsert" runat="server" 
                                                        DataSourceID="odsUbicacionSeniaParticular" DataTextField="descripcion" 
                                                        DataValueField="id">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" 
                                                        Text='<%# MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager.GetItem(Convert.ToInt32(Eval("idUbicacionTatuaje").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Descripción" SortExpression="Descripcion">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="descripcionTatuajePart" runat="server" Text='<%# Eval("Descripcion") %>'  CssClass="ingreso"/>
                                                 </EditItemTemplate>
                                                <FooterTemplate>
                                                   <asp:TextBox ID="descripcionTatuajeInsert" runat="server"  CssClass="ingreso"/>
                                               </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelTatuaje" runat="server" Text='<%# Eval("Descripcion") %>' CssClass="ingreso"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="idTablaDestino" HeaderText="idTablaDestino" 
                                                SortExpression="idTablaDestino" Visible="False" />
                                            <asp:TemplateField ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                                        CommandArgument="BI" CommandName="Update" Text="Ok"></asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                        CommandArgument="BI" CommandName="Cancel" Text="X"></asp:LinkButton>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:LinkButton ID="btnAgregarTatuaje" runat="server" CausesValidation="False" 
                                                        CommandArgument="BI" OnClick="btnAgregarTatuaje_Click" 
                                                        Text="&lt;&lt; Incorporar"></asp:LinkButton>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                        CommandArgument="BI" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                        CommandArgument="BI" CommandName="Delete" Text="Borrar"></asp:LinkButton>
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
                                                    <td>
                                                        <asp:Label ID="LabelDescripcionTatuaje" runat="server" Text="Descripción"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTatuajes" runat="server" DataSourceID="odsTatuajes" 
                                                            DataTextField="descripcion" DataValueField="id">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlUbicacionTatuaje" runat="server" CssClass="ingreso" 
                                                            DataSourceID="odsUbicacionSeniaParticular" DataTextField="Descripcion" 
                                                            DataValueField="Id">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <%--<td>
                                                         <asp:TextBox ID="descripcionTatuajeInsert" runat="server" />
                                                     </td>--%>
                                                    <td>
                                                        <asp:LinkButton ID="btnSend" runat="server" CommandArgument="BI" 
                                                            CommandName="EmptyInsert" OnClick="btnAgregarPrimerTatuaje_Click" 
                                                            Text="&lt;&lt; Incorporar" UseSubmitBehavior="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFaltanDientesBIPersona" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Faltan Dientes</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFaltanDientesPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Faltan Dientes</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFaltanPiezasDentalesBI" runat="server">Faltan Dientes</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFaltanPiezasDentalesBI" runat="server" 
                                        DataSourceID="odsBooleano" DataTextField="Descripcion" DataValueField="Id" 
                                        Width="70">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDNIPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">DNI</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDNIPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor DNI</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblApellidoPersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblApellidoPersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombrePersonaBI" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Nombre</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombrePersonaBIValor" runat="server" Font-Bold="True" 
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Nombre</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <%-- <td class="style2">
                                    <asp:Label ID="lblIppBI" runat="server">IPP</asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtIppBI" runat="server"></asp:TextBox>
                                </td>--%>
                                <td align="left" class="style3">
                                    <asp:Label ID="lblDNIBI" runat="server">Nro Doc.</asp:Label>
                                </td>
                                <td align="left" class="style4">
                                    <asp:TextBox ID="txtDNIBI" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lblApellidoBI" runat="server">Apellido</asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtApellidoBI" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblNombresBI" runat="server">Nombres</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombresBI" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="border-style: groove none none none; padding-top: 10px; position: relative;
                top: 0px; left: 0px; background-color: #C2D6D2;">
                <asp:UpdatePanel ID="upBI" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblAyudaSeleccionMultiple" runat="server" Text="Ayuda: Para seleccionar varios items de las listas, tenga pulsada CTRL y haga click izquierdo sobre los items elegidos"
                                        ForeColor="#666633"></asp:Label>
                                </td>
                            </tr>
                            <tr style="text-align: center">
                                <td>
                                    <asp:Button ID="btnCerrarBI" runat="server" CausesValidation="False" Text="Cancelar"
                                        UseSubmitBehavior="False" Width="60px" OnClick="btnCerrarBI_Click" />
                                    <asp:HiddenField ID="hfBusquedaIndividual" runat="server" />
                                    <asp:Button ID="btnGuardarBusquedaBI" runat="server" OnClientClick="this.disabled=true;this.value = 'Guardando...';"
                                    OnClick="btnGuardarBusquedaBI_Click"
                                        Text="Guardar Busqueda" UseSubmitBehavior="false" Width="110px" />
                                        
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
                                        
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress runat="server" ID="upWaitingBI" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Panel ID="pnlWaitingOverlayBI" CssClass="" runat="server">
                            <asp:Panel ID="pnlWaitingBI" CssClass="" runat="server">
                                <asp:Image ID="imgWaitingBI" runat="server" ImageUrl="~/App_Images/loader.gif" 
                                    Width="27px" />
                            </asp:Panel>
                        </asp:Panel>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlVerCriterioBI" runat="server" CssClass="FondoModal" Width="900px">
        <div>
            <div id="divHeaderVerCriterioBI" class="ModalHeader">
                CRITERIO DE BUSQUEDA</div>
            <div style="height: 400px; position: relative; overflow: auto;">
                <asp:UpdatePanel ID="upVerCriterioBI" runat="server">
                    <ContentTemplate>
                        <table class="style2">
                            <tr>
                                <td align="right" colspan="3" width="85%">
                                    <asp:Label ID="lblVerCoincidencia" runat="server">Cantidad de coincidencias con los resultados mostrados</asp:Label>
                                    <asp:TextBox ID="txtVerCoincidenciaBI" runat="server" MaxLength="3" Width="50px"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerFechaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Fecha</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerValorFechaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">ValorFecha</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerFechaDesdeBI" runat="server">Fecha Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerFechaDesdeBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerFechaHastaBI" runat="server">Fecha Hasta</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerFechaHastaBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerEdadBI" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Small"
                                        ForeColor="#0033CC">Edad</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerValorEdadBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">ValorEdad</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerSexoPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Sexo</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerSexoPersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">ValorSexo</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerEdadDesdeBI" runat="server">Edad Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerEdadDesdeBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerEdadHastaBI" runat="server">Edad Hasta</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerEdadHastaBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerSexoBI" runat="server">Sexo</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerSexoBI" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerTallaPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Talla</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerTallaPersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">ValorTalla</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerCalviciePersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Calvicie</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerCalviciePersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">CalvicieValor</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerTallaDesdeBI" runat="server">Talla Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerTallaDesdeBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerTallaHastaBI" runat="server">Talla Hasta</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerTallaHastaBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerCalvicieBI" runat="server">Calvicie</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerCalvicieBI" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerPesoPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Peso</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerPesoPersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">ValorPeso</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorPielpersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Color de Piel</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorPielPersonaValorBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Valor Color de Piel</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerPesoDesdeBI" runat="server">Peso Desde</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerPesoDesdeBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerPesoHastaBI" runat="server">Peso Hasta</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerPesoHastaBI" runat="server" Width="70px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorPielBI" runat="server">Color Piel</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerColorPielBI" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerColorCabelloPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Color de Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorCabelloPersonaBIValor" runat="server" Font-Bold="True"
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Color de Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorTenidoPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Color de Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorTeñidoPersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Valor Color de Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerLongCabelloPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Longitud de Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerLongCabelloPersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Valor Color de Cabello</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerColorCabelloBI" runat="server">Color Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerColorCabelloBI" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorTenidoBI" runat="server">Color Teñido</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerColorTenidoBI" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerLongitudCabelloBI" runat="server">Longitud Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerLongitudCabelloBI" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerAspectoCabelloPersonaBi" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerAspectoCabelloPersonaBiValor" runat="server" Font-Bold="True"
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorOjosPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Color Ojos</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorOjosBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Valor Color ojos</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerAspectoCabelloBI" runat="server">Aspecto Cabello</asp:Label>
                                </td>
                                <td>
                                    <br />
                                    <asp:TextBox ID="txtVerAspectoCabelloBI" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerColorOjosBI" runat="server">Color Ojos</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerColorOjosBI" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="5">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerSenasPartBI" runat="server">Señas Particulares</asp:Label>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="txtVerSenasPartBI" runat="server" ReadOnly="True" TextMode="MultiLine"
                                        Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerTatuajeBI" runat="server">Tatuajes</asp:Label>
                                </td>
                                <td colspan="5">
                                    <asp:TextBox ID="txtVerTatuajesBI" runat="server" ReadOnly="True" TextMode="MultiLine"
                                        Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerFaltanDientesBIPersona" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Faltan Dientes</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerFaltanDientesPersonaBIValor" runat="server" Font-Bold="True"
                                        Font-Italic="True" Font-Size="Small" ForeColor="#0033CC">Valor Faltan Dientes</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerFaltanPiezasDentalesBI" runat="server">Faltan Dientes</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerFaltanPiezasDentalesBI" runat="server" ReadOnly="True" TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblVerDNIPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">DNI</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerDNIPersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Valor DNI</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerApellidoPersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerApellidoPersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Valor Apellido</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerNombrePersonaBI" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Nombre</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerNombrePersonaBIValor" runat="server" Font-Bold="True" Font-Italic="True"
                                        Font-Size="Small" ForeColor="#0033CC">Valor Nombre</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <%--<td class="style2">
                                    <asp:Label ID="lblVerIppBI" runat="server">IPP</asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtVerIppBI" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>--%>
                                <td class="style2">
                                    <asp:Label ID="lblVerDNIBI" runat="server">DNI</asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtVerDNIBI" runat="server"></asp:TextBox>
                                </td>
                                <td class="style2">
                                    <asp:Label ID="lblVerApellidoBI" runat="server">Apellido</asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtVerApellidoBI" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVerNombresBI" runat="server">Nombres</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVerNombresBI" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="border-style: groove none none none; padding-top: 10px; position: relative;
                top: 0px; left: 0px; background-color: #C2D6D2;">
                <asp:UpdatePanel ID="upVerBI" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="text-align: center">
                                <td>
                                    <asp:Button ID="btnCerrarVerBI" runat="server" CausesValidation="False" Text="Cerrar"
                                        UseSubmitBehavior="False" Width="60px" OnClick="btnCerrarVerBI_Click" />
                                    <asp:HiddenField ID="hfVerBusquedaIndividual" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress runat="server" ID="upWaitingVerBI" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Panel ID="pnlWaitingOverlayVerBI" CssClass="" runat="server">
                            <asp:Panel ID="pnlWaitingVerBI" CssClass="" runat="server">
                                <asp:Image ID="imgWaitingVerBI" runat="server" 
                                    ImageUrl="~/App_Images/loader.gif" Width="27px" />
                            </asp:Panel>
                        </asp:Panel>
                    </ProgressTemplate>
                </asp:UpdateProgress>
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
                                    <asp:Label ID="lblDNIBIH" runat="server">Nro. Doc.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDNINumeroBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOrgInBIH" runat="server">Org. Int.</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOrgIntBIH" runat="server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
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
                <asp:UpdateProgress runat="server" ID="upWaitingFichaBIH" DisplayAfter="100">
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
    </asp:Panel>
    <asp:Panel ID="pnlCartelAlert" runat="server" CssClass="FondoModal" Width="300px">
        <div>
            <div id="divHeaderCartelAlert" class="ModalHeader">
                Alerta</div>
            <div style="position: relative; overflow: auto;" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel runat="server" ID="upCartelAlert">
                                <ContentTemplate>
                                    <br />
                                    <asp:Label ID="lblMensajeCartelAlert" runat="server" Text="Mensaje" Font-Size="Medium"></asp:Label>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="padding-top: 10px; position: relative;">
                <asp:Button ID="btnOkCartelAlert" runat="server" Text="OK" Width="50px" />
            </div>
        </div>
    </asp:Panel>
      <asp:Panel ID="pnlMailAsociado" runat="server" CssClass="FondoModal" Width="350px" 
            DefaultButton="btnOkMailAsociado">
            <div>
                <div id="divHeaderMailAsociado" class="ModalHeader">
                    Alta de Mail Asociado</div>
                <div style="position: relative; overflow: auto;">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                          
                            <br />
                            <table width="100%">
                               
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblMailAsociado" runat="server" Text="Mail"></asp:Label>
                                    </td>
                                   <td align="left">
                                        <asp:TextBox  ID="txtMailAsociado" runat="server" Width="100px" 
                                            CssClass="InputLogin"></asp:TextBox>
                                            <asp:Label ID="lblMail" runat="server" Text="@mpba.gov.ar"></asp:Label>
                            <asp:CustomValidator ID="cvMailAsociado" runat="server" ErrorMessage="Debe Ingresar el mail" ControlToValidate="txtMailAsociado"></asp:CustomValidator>
                            <asp:CustomValidator ID="cvMailInvalido" runat="server" ErrorMessage="Mail invalido" ControlToValidate="txtMailAsociado"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblNombreMailAsociado" runat="server" Text="Nombre"></asp:Label>
                                    </td>
                                   <td align="left">
                                        <asp:TextBox ID="txtNombreMailAsociado" runat="server" Width="100px" 
                                            CssClass="InputLogin"></asp:TextBox>
                                         <asp:CustomValidator ID="cvNombreMailAsociado" runat="server" ErrorMessage="Debe ingresar el nombre" ControlToValidate="txtNombreMailAsociado"></asp:CustomValidator> 
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left">
                                        <asp:Label ID="lblApellidoMailAsociado" runat="server" Text="Apellido"></asp:Label>
                                    </td>
                                   <td align="left">
                                        <asp:TextBox ID="txtApellidoMailAsociado" runat="server" Width="100px" 
                                            CssClass="InputLogin"></asp:TextBox>
                                            <asp:CustomValidator ID="cvApellidoMailAsociado" runat="server" ControlToValidate="txtApellidoMailAsociado" ErrorMessage="Debe ingresar el apellido"></asp:CustomValidator>
                                          
                                    </td>
                                </tr>
                               
                            </table>
                          
                            <asp:Button ID="btnOkMailAsociado" runat="server" Text="OK" Width="50px"
                                OnClick="btnOkMailAsociado_Click" UseSubmitBehavior="False" />
                                
                                               
                        </ContentTemplate>
                      
                    </asp:UpdatePanel>
                </div>
                <div style="padding-top: 10px; position: relative;">
                    <asp:Button ID="btnCancelarMailAsociado" runat="server" Text="X" Width="50px" UseSubmitBehavior="False"
                        OnClick="btnCancelarMailAsociado_Click" />
                    <asp:HiddenField ID="hfMailAsociado" runat="server" />
                </div>
            </div>
        </asp:Panel>
            <asp:HiddenField ID="hfGestionMailAsociado" runat="server" />
        <asp:ModalPopupExtender ID="hfGestionMailAsociado_ModalPopupExtender" runat="server"
            BackgroundCssClass="FondoOscuro" DropShadow="True" 
        DynamicServicePath="" Enabled="True"
            PopupControlID="pnlMailAsociado" TargetControlID="hfGestionMailAsociado" CancelControlID="btnCancelarMailAsociado"
            OkControlID="hfMailAsociado" Drag="True" 
        PopupDragHandleControlID="DivHeaderMailAsociado">
        </asp:ModalPopupExtender>
</asp:Content>