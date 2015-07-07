<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="BusquedaHalladaBaja.aspx.cs" Inherits="MPBA.PersonasBuscadas.Web.BusquedaHalladaBaja" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <br />
    <div align="left" style="background-color: #006381; color: #FFFFFF;">
        <h3 id="cartelConsultandoH" runat="server" align="center">
            BAJA DE PERSONA HALLADA</h3>
    </div>
    <br />
           <asp:Panel ID="pnlIPPH" runat="server" DefaultButton="btnBuscarIppH" Style="text-align: center"
                            BorderStyle="Solid" BorderWidth="4px">
                       
                                <div align="center">
                              
                              <asp:TabContainer ID="tcTipoJurisdiccion" runat="server" ActiveTabIndex="0" Width="290px"
                                        EnableViewState="True" Height="72px" AutoPostBack="True" 
                                        onactivetabchanged="tcTipoJurisdiccion_ActiveTabChanged">
                                        <asp:TabPanel runat="server" HeaderText="Poder Judicial" ID="tpPJ"><HeaderTemplate>Poder Judicial</HeaderTemplate><ContentTemplate><asp:Label ID="Label1" runat="server" Font-Bold="True" 
                            Font-Size="Large" style="vertical-align:middle; color: #13507d">IPP</asp:Label><asp:TextBox ID="txtIppBuscadoH" runat="server" Width="200px" 
                                BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                Font-Size="Large"></asp:TextBox><asp:CustomValidator ID="cvIppH" runat="server" ControlToValidate="txtIppBuscadoH"
                                ErrorMessage="Debe ingresar la IPP"></asp:CustomValidator><asp:MaskedEditExtender
                                ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" Mask="99-99-999999-99" MaskType="Number" OnBlurCssNegative="MaskedEditError"
                                TargetControlID="txtIppBuscadoH"></asp:MaskedEditExtender></ContentTemplate></asp:TabPanel>
                                        <asp:TabPanel ID="tpExtJur" runat="server" HeaderText="Extraña Jurisdiccion"><HeaderTemplate>Extraña Jurisdiccion</HeaderTemplate><ContentTemplate><asp:Label ID="lblCausa" runat="server" Font-Bold="True" 
                            Font-Size="Large" style="vertical-align:middle; color: #13507d">Nro. Causa</asp:Label><asp:TextBox ID="txtCausa" runat="server" Width="200px" 
                                BackColor="#FFFFFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                Font-Size="Large"></asp:TextBox><asp:CustomValidator ID="cvCausa" runat="server" ControlToValidate="txtCausa"
                                ErrorMessage="Debe ingresar el numero de causa"></asp:CustomValidator></ContentTemplate></asp:TabPanel>
                                        </asp:TabContainer>
                                     
                                        <asp:Button ID="btnBuscarIppH" runat="server" ForeColor="Black" OnClick="btnBuscarIppH_Click"
                                Text="Buscar" Width="76px" Font-Size="Medium" />
                       </div>
                            
                            <br />
                            <br />
                            <div align="center">
                            </div>
                            <br />
                              <div id="divPersonasH" runat="server" >
                             <table>
                             <tr align="left">
                             <td colspan="2">
                             <asp:Label ID="lblVariasPersonasH" runat="server" Text="Personas asociadas a la IPP:"></asp:Label>
                             </td>
                             </tr>
                             <tr>
                             <td width="50%">
                                    <asp:GridView ID="gvPersonasH" runat="server" AutoGenerateColumns="False"
                                                Width="968px" DataKeyNames="id" >
                                       <Columns>
                                           <asp:TemplateField ShowHeader="False">
                                               <ItemTemplate>
                                                   <asp:CheckBox ID="personaSeleccionada" runat="server" AutoPostBack="True" 
                                                       Checked="False" Text="&lt;Seleccione&gt;" TextAlign="Left" 
                                                       Visible='<%# !Convert.ToBoolean(Eval("Baja")) %>' />
                                                   <!--
                                                    <asp:Button ID="btnBorrarPersonaH" runat="server" CausesValidation="False" 
                                                       OnClientClick="return confirm('Seguro que desea borrar la foto?')" CommandName="Delete" Text="X" ForeColor="Red" Width="30px" /> -->
                                               </ItemTemplate>
                                               <ItemStyle ForeColor="Red" Width="5%" />
                                           </asp:TemplateField>
                                           <asp:BoundField DataField="Apellido" HeaderText="Apellido">
                                           <ItemStyle Width="20%" />
                                           </asp:BoundField>
                                           <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                           <ItemStyle Width="20%" />
                                           </asp:BoundField>
                                           <asp:BoundField DataField="DNI" HeaderText="Documento">
                                           <ItemStyle Width="10%" />
                                           </asp:BoundField>
                                           <asp:BoundField DataField="FechaHallazgo" HeaderText="Fecha Hallazgo" 
                                               SortExpression="FechaHallazgo" />
                                           <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                                               <EditItemTemplate>
                                                   <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox>
                                               </EditItemTemplate>
                                               <ItemTemplate>
                                                   <asp:Label ID="lblSexoH" runat="server" 
                                                       Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Baja" Visible="true">
                                               <ItemTemplate>
                                                   <asp:Label ID="lblBajaPersona" runat="server" Font-Bold="True" ForeColor="Red" 
                                                       Text="Dado de Baja: " Visible='<%# Convert.ToBoolean(Eval("Baja")) %>'></asp:Label>
                                                   <asp:Label ID="Label1" runat="server" 
                                                       Text='<%#MPBA.SIAC.Bll.ClaseBajaBusquedaPersonasManager.GetItem(Convert.ToInt32(Eval("MotivoDeBaja").ToString())).Descripcion.ToLower() %>' 
                                                       Visible='<%# Convert.ToBoolean(Eval("Baja")) %>'></asp:Label>
                                               </ItemTemplate>
                                           </asp:TemplateField>
                                       </Columns>
                            </asp:GridView>
                             </td>
                             <td width="50%">
                             </td>
                             </tr>
                             <tr>
                             <td colspan="2" align="left">
                                 &nbsp;</td>
                             </tr>
                           </table>
                            </div>
                            
                                <div id="divAgregandoPersona" runat="server">
                                <table>
                                <tr align="left">
                                <td>
                                
                                <br />
                                     
                                     </td>
                                     </tr>
                                     </table>
                                     </div>
                         </asp:Panel>

   
    <br />
  
    <table width="100%" style="margin: 15px">
        <tr>
            <td align="center">
                <asp:Panel ID="pnlBotones" runat="server">
                    <table width="100%" style="border: 1px solid #00CCFF;">
                        <tr>
                        <td>
                         <asp:Label ID="Motivo" runat="server" Font-Bold="True" 
                            Font-Size="Medium" style="vertical-align:middle; color: #13507d">Motivo de Baja</asp:Label>
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlMotivoBaja" style="vertical-align:middle;" runat="server" Width="150px" 
                                    DataSourceID="odsMotivoBaja" DataTextField="Descripcion" 
                                DataValueField="id"  AutoPostBack="True" 
                                OnSelectedIndexChanged="ddlMotivoBaja_Change" ></asp:DropDownList>
                           
                        <asp:ObjectDataSource ID="odsMotivoBaja" runat="server" 
                                    DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseBajaBusquedaPersonas" DeleteMethod="Delete" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                                    TypeName="MPBA.SIAC.Bll.ClaseBajaBusquedaPersonasManager" UpdateMethod="Save">
                                </asp:ObjectDataSource>
                        </td>
                        <td>
                         <asp:Label ID="LabelCoincidente" runat="server" Font-Bold="True" visible="false" 
                            Font-Size="Small" style="vertical-align:middle; color: #13507d">Coincidente con la IPP</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCoincideIPP" runat="server" Width="200px"  visible="false" 
                                BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                Font-Size="Medium"></asp:TextBox>
                                   <asp:CustomValidator ID="CustomCoincideIPP" runat="server" ControlToValidate="txtCoincideIPP"
                                ErrorMessage="Debe ingresar la IPP"></asp:CustomValidator>
                            <asp:MaskedEditExtender
                                ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" Mask="99-99-999999-99" MaskType="Number" OnBlurCssNegative="MaskedEditError"
                                TargetControlID="txtCoincideIPP">
                            </asp:MaskedEditExtender>
                        </td>
                            <td>
                                <asp:Button runat="server" ID="btnBorrarH" Text="Baja Logica" Height="22px" Width="105px"
                                    OnClick="btnBorrarH_Click" />
                                <asp:ConfirmButtonExtender ID="btnBorrarH_ConfirmButtonExtender" runat="server" ConfirmText="Confirma la baja?"
                                    Enabled="True" TargetControlID="btnBorrarH">
                                </asp:ConfirmButtonExtender>
                            </td>
                            <td>
                            <asp:Button ID="btnSalir" runat="server" Text="Salir" Height="22px" Width="105px"
                                        UseSubmitBehavior="False" OnClick="btnSalir_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
