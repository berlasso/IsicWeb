<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeBehind="BusquedaSic.aspx.cs" Inherits="MPBA.AutoresIgnorados.Web.BusquedaSic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style35
        {
            width: 100%;
        }
        .style48
        {
            width: 100%;
        }
        </style>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div>
        <div style="border-style: groove; border-color: #13507d;" class="FondoAutoresIgnorados">
            <table class="style48">
             <tr>
                <td style="border-width: thin; border-bottom-style: solid; ">
                    <asp:Label ID="lblBusquedaPruebasPendientes" runat="server" Font-Bold="True" Font-Size="Large"
                       Text="Busqueda en el SIC"></asp:Label>
                </td>
             </tr>
             <tr>
             <td valign="top">
                  
            <div>
                <div id="divHeaderAutor" class="ModalHeader">
                    DETALLES DEL AUTOR</div>
                <asp:UpdatePanel ID="upGestionAutor" runat="server">
                    <ContentTemplate>
                        <div style="overflow: auto; border-bottom-style: solid; border-bottom-width: thin;">
                          
                   
                     <table width="100%" align="left">
                        <tr align="left">
                            <td >
                            <asp:Label runat="server" ID="lblNombreAutor" Text="Nombre"></asp:Label>
                            </td>
                            <td >
                            <asp:TextBox runat="server" ID="txtNombreAutor"></asp:TextBox>
                            </td>
                            <td>
                            <asp:Label runat="server" ID="lblApellidoAutor" Text="Apellido"></asp:Label>
                              
                            </td>
                             <td>
                            <asp:TextBox runat="server" ID="txtApellidoAutor"></asp:TextBox>
                          

                            </td>
                          
                            <td>
                                <asp:Label ID="lblDniAutor" runat="server" Text="DNI"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDniAutor" runat="server"></asp:TextBox>
                                <asp:MaskedEditExtender ID="meDocNroAutor" runat="server" Enabled="False" 
                                    Mask="999999999" MaskType="Number" TargetControlID="txtDniAutor">
                                </asp:MaskedEditExtender>
                            </td>
                           
                             <td>
                                 <asp:Label ID="lblLocalidadSic" runat="server" Text="Localidad"></asp:Label>
                                 </td>
                             <td>
                                 <asp:TextBox ID="txtLocalidadSic" runat="server" Width="150px"></asp:TextBox>
                                 </td>
                          
                          
                            </tr >
                        
                                
                                   <tr align="left">
                                <td>
                                        <asp:Label ID="lblFisGral" runat="server" Text="Fiscalia Gral."></asp:Label>
                                </td>
                                <td>
                                <asp:DropDownList ID="ddlFisGral" runat="server" DataSourceID="odsFisGral" 
                                        DataTextField="departamento" DataValueField="Id" Width="150px"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsFisGral" runat="server" 
                                        DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento" 
                                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
                                        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.DepartamentoManager" 
                                        UpdateMethod="Save"></asp:ObjectDataSource>
                                </td>
                                

                                    <td>
                                        <asp:Label ID="lblEdadSic" runat="server" Text="Edad Aproximada"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEdadSic" runat="server" DataSourceID="ObjectDataSourceClaseEdad"
                                            DataTextField="descripcion" DataValueField="idSICEdad" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    
                                    <td>
                                        <asp:Label ID="lblSexoSic" runat="server" Text="Sexo"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSexoSic" runat="server" DataSourceID="ObjectDataSourceClaseSexo"
                                            DataTextField="descripcion" DataValueField="id" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    
                                    <td>
                                        <asp:Label ID="lblTatuajeSic" runat="server" Text="Tatuaje"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTatuajeSic" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                               <tr>
                               <td colspan="8" align="left">
                               <asp:CheckBox ID="chkBuscaPorDatosSomaticos" 
                                     Text="Buscar en registros que tengan cargados los datos somáticos." 
                                     Checked="false" runat="server" AutoPostBack="True" 
                                     oncheckedchanged="chkBuscaPorDatosSomaticos_CheckedChanged" />
                               <div runat="server" id="divDatosSomaticos" visible="false">
                                    <table bgcolor="#DCF0F5" style="border: thin solid #13507d">
                                <tr>
                                  <td class="style52">
                                        <asp:Label ID="lblEstaturaSic" runat="server" Text="Estatura"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlEstaturaSic" runat="server" DataSourceID="ObjectDataSourceSICClaseEstatura"
                                            DataTextField="descripcion" DataValueField="id" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblRobustezSic" runat="server" Text="Robustez"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlRobustezSic" runat="server" DataSourceID="ObjectDataSourceSICClaseRobustez"
                                            DataTextField="descripcion" DataValueField="id" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblColorPielSic" runat="server" Text="Color de Piel"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlColorPielSic" runat="server" DataSourceID="ObjectDataSourceSICClaseColorPiel"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblColorOjosSic" runat="server" Text="Color de Ojos"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlColorOjosSic" runat="server" DataSourceID="ObjectDataSourceSICClaseColorOjos"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblColorCabelloSic" runat="server" Text="Color de Cabello"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlColorCabelloSic" runat="server" DataSourceID="ObjectDataSourceSICClaseColorCabello"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblTipoCabelloSic" runat="server" Text="Tipo de Cabello"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlTipoCabelloSic" runat="server" DataSourceID="ObjectDataSourceSICClaseTipoCabello"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblCalvicieSic" runat="server" Text="Calvicie"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlCalvicieSic" runat="server" DataSourceID="ObjectDataSourceSICClaseTipoCalvicie"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblFormaCaraSic" runat="server" Text="Forma de la Cara"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlFormaCaraSic" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaCara"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblDimensionCejaSic" runat="server" Text="Dimensión de la Ceja"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlDimensionCejaSic" runat="server" DataSourceID="ObjectDataSourceSICClaseCejasDimension"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblTipoCejaSic" runat="server" Text="Tipo de la Ceja"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlTipoCejaSic" runat="server" DataSourceID="ObjectDataSourceSICClaseCejasTipo"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblFormaMentonSic" runat="server" Text="Forma Del Mentón"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlFormaMentonSic" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaMenton"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblFormaOrejaSic" runat="server" Text="Forma de la Oreja"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlFormaOrejaSic" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaOreja"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblFormaNarizSic" runat="server" Text="Forma de la Nariz"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlFormaNarizSic" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaNariz"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblFormaBocaSic" runat="server" Text="Forma de la Boca"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlFormaBocaSic" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaBoca"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblLabioInfSic" runat="server" Text="Forma del Labio Inferior"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlLabioInfSic" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaLabioInferior"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblLabioSupSic" runat="server" Text="Forma del labio Superior"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlLabioSupSic" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaLabioSuperior"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                             </table>
                               </div>
                               </td>
                               </tr>
                              
                             
                            </table>
                        </div>
                          <asp:UpdateProgress runat="server" ID="upWaitingPersonas" DisplayAfter="100">
                                <ProgressTemplate>
                                    <asp:Panel ID="pnlWaitingOverlayPersonas" CssClass="" runat="server">
                                        <asp:Panel ID="pnlWaitingPersonas" CssClass="" runat="server">
                                        </asp:Panel>
                                    </asp:Panel>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                    </ContentTemplate>
                 
                </asp:UpdatePanel>
                    
       

            </div>
      
             </td>
             </tr>
             </table>
             <table width="100%">
             <tr>
             <td>
                 <asp:UpdatePanel ID="upBotones" runat="server">
        <ContentTemplate>
        <table class="style35">
            <tr>
          <td>
          </td>
                <td align="right">
                   <asp:Button ID="btnBuscarDatos" runat="server" Text="Buscar Datos"
                        Width="95px" UseSubmitBehavior="False" Height="22px" 
                        onclick="btnBuscarDatos_Click" />
                        <asp:Button ID="btnBuscarFotos" runat="server" Text="Ver Fotos Por Fiscalia"
                        Width="140px" UseSubmitBehavior="False" Height="22px" 
                        onclick="btnBuscarFotos_Click" />
                   <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="64px" 
                        Height="22px" UseSubmitBehavior="False" onclick="btnLimpiar_Click" />
                   <asp:Button ID="btnSalir" runat="server" Text="Salir" Height="22px" Width="64px"
                        UseSubmitBehavior="False" OnClick="btnSalir_Click" />
               </td>
               </tr>
               <tr>
               <td>
               </td>
               <td align="right">
                   &nbsp;</td>
               </tr>
               <tr>
                     <td>
                    <asp:ObjectDataSource ID="odsAutores" runat="server" 
                        DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.Autores" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.AutoresIgnorados.Bll.AutoresManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseSexo" runat="server" 
                        DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseSexo" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseSexoManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseEdad" runat="server" 
                        DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseEdadAproximada" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseEdadAproximadaManager" 
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseRostro" runat="server" 
                        DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRostro" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRostroManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseSeniaParticular" runat="server" 
                        DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseSeniaParticular" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.SIAC.Bll.ClaseSeniaParticularManager" 
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseLugarTatuaje" runat="server" 
                        DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseUbicacionSeniaPart" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager" 
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseTipoTatuaje" runat="server" 
                        DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseTatuaje" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.SIAC.Bll.ClaseTatuajeManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCantidadAutores" runat="server" 
                        DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseCantidadAutores" 
                        DeleteMethod="Delete" InsertMethod="Save" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseCantidadAutoresManager" 
                        UpdateMethod="Save"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseEstatura" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseEstaturaManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseEstatura" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseRobustez" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseRobustezManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseRobustez" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseColorPiel" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseColorPielManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseColorPiel" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseColorOjos" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseColorOjosManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseColorOjos" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseColorCabello" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseColorCabelloManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseColorCabello" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseTipoCabello" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseTipoCabelloManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseTipoCabello" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseTipoCalvicie" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseTipoCalvicieManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseTipoCalvicie" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseFormaCara" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaCaraManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaCara" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseFormaMenton" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaMentonManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaMenton" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseFormaOreja" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaOrejaManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaOreja" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseFormaNariz" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaNarizManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaNariz" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseFormaBoca" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaBocaManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaBoca" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseFormaLabioInferior" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaLabioInferiorManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaLabioInferior" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseFormaLabioSuperior" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseFormaLabioSuperiorManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseFormaLabioSuperior" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource> 
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseCejasDimension" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseCejasDimensionManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseCejasDimension" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSICClaseCejasTipo" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SICClaseCejasTipoManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.SICClaseCejasTipo" DeleteMethod="Delete"
        UpdateMethod="Save"></asp:ObjectDataSource>
                </td>
                <td>
                </td>
            </tr>
        </table>        
        </ContentTemplate>
        </asp:UpdatePanel>
             <asp:UpdatePanel ID="upResultadosSic" runat="server" UpdateMode="Conditional">
             <ContentTemplate>
                        <asp:Panel ID="pnlResultados" runat="server" Style="width: 100%;">
                          <table style="width: 100%">
                             <tr align="left">
                                 <td>
                                 <asp:Label runat="server" ID="lblLimiteResultadosSic" 
                                Text="Solo se muestran los primeros 50 resultados" ForeColor="Red" 
                                Visible="False"></asp:Label>
                                <br />
                                    <asp:GridView ID="gvDelitosSIC" runat="server" 
                                onrowdatabound="gvDelitosSIC_RowDataBound" AutoGenerateColumns="False" Caption="DELITOS EN LA BASE DEL SIC">
                                <Columns>
                                    <asp:HyperLinkField DataNavigateUrlFields="LinkSic" HeaderText="Reporte" 
                                        SortExpression="LinkSic" Target="_blank" Text="Reporte del SIC" >
                                    <ItemStyle Width="100px" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="NroCarpeta" HeaderText="NroCarpeta" 
                                        SortExpression="NroCarpeta" />
                                    <asp:BoundField DataField="ProntuarioSic" HeaderText="ProntuarioSic" 
                                        SortExpression="ProntuarioSic" />
                                    <asp:BoundField DataField="Tatuaje" HeaderText="Tatuaje" 
                                        SortExpression="Tatuaje" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                                        SortExpression="Apellido" />
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" 
                                        SortExpression="Nombres" />
                                    <asp:BoundField DataField="TipoDoc" HeaderText="TipoDoc" 
                                        SortExpression="TipoDoc" />
                                    <asp:BoundField DataField="DocNro" HeaderText="DocNro" 
                                        SortExpression="DocNro" />
                                    <asp:BoundField DataField="FeNac" HeaderText="FeNac" SortExpression="FeNac" />
                                    <asp:BoundField DataField="LugarNac" HeaderText="LugarNac" 
                                        SortExpression="LugarNac" />
                                    <asp:BoundField DataField="PciaNac" HeaderText="PciaNac" 
                                        SortExpression="PciaNac" />
                                    <asp:BoundField DataField="PaisNac" HeaderText="PaisNac" 
                                        SortExpression="PaisNac" />
                                    <asp:BoundField DataField="CodBarra" HeaderText="CodBarra" 
                                        SortExpression="CodBarra" />
                                    <asp:BoundField DataField="Caratula" HeaderText="Caratula" 
                                        SortExpression="Caratula" />
                                    <asp:BoundField DataField="Fecha" HeaderText="FechaDelito" 
                                        SortExpression="Fecha" />
                                    <asp:BoundField DataField="Ipp" HeaderText="Ipp" SortExpression="Ipp" />
                                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsDelitosSic" runat="server" SelectMethod="ToArray" 
                                TypeName="MPBA.SIAC.BusinessEntities.DelitoSICList"></asp:ObjectDataSource>
                           
                                 </td>
                             </tr>
                           </table>      
                        </asp:Panel>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
             </tr>
            </table>
       
    
        </div>
    </div>
</asp:Content>