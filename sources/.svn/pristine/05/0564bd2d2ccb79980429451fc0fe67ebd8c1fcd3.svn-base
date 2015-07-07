<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="BusquedaDesaparecidaBaja.aspx.cs" Inherits="MPBA.PersonasBuscadas.Web.BusquedaDesaparecidaBaja" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<script type="text/javascript">
    function Confirmacion(msm) {
        alert(msm);
        return;
    }
 </script>
    <br />
    <div align="left" style="background-color: #006381; color: #FFFFFF;">
        <h3 id="cartelConsultandoD" runat="server" align="center">
            BAJA DE PERSONA DESAPARECIDA</h3>
    </div>
    <br />
              <asp:Panel ID="pnlIPPD" runat="server" DefaultButton="btnBuscarIppD" Style="text-align: center"
                            BorderStyle="Solid" BorderWidth="4px">
                              <div align="center">
                            <asp:TabContainer ID="tcTipoJurisdiccion" runat="server" ActiveTabIndex="0" Width="290px"
                                EnableViewState="True" Height="72px" AutoPostBack="True" OnActiveTabChanged="tcTipoJurisdiccion_ActiveTabChanged">
                                <asp:TabPanel runat="server" HeaderText="Poder Judicial" ID="tpPJ">
                                    <HeaderTemplate>
                                        Poder Judicial</HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Label ID="lblIppBuscadoD" runat="server" Font-Size="Large" Font-Bold="True"
                                            Style="vertical-align: middle; color: #13507d">IPP</asp:Label>
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
                            </div>
                    
                            <br />
                            <br />
                            <div align="center">
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
                                            <asp:GridView ID="gvPersonasD" runat="server" AutoGenerateColumns="False"
                                                Width="968px" DataKeyNames="id" >
                                                <Columns>
                                                 <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                   <asp:CheckBox id="personaSeleccionada" 
                                                    AutoPostBack="True"
                                                     Visible='<%# !Convert.ToBoolean(Eval("Baja")) %>'
                                                    Text="<Seleccione>"  TextAlign="Left"  Checked="False"  runat="server"/>
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
                                                 
                                                          <asp:BoundField DataField="FechaDesaparicion" HeaderText="Fecha Desap." 
                                                        SortExpression="FechaDesaparicion" />
                                                     <asp:TemplateField HeaderText="Sexo" SortExpression="idSexo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idSexo") %>'></asp:TextBox></EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSexoD" runat="server" Text='<%#MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                    <asp:BoundField DataField="Talla" HeaderText="Talla" />
                                                    <asp:BoundField DataField="Peso" HeaderText="Peso" />
                                                   
                                                   
                                                     <asp:TemplateField  Visible=true HeaderText="Baja">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBajaPersona" runat="server" Text="Dado de Baja: " 
                                                                Font-Bold="True" ForeColor="Red" 
                                                                Visible='<%# Convert.ToBoolean(Eval("Baja")) %>'></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%#MPBA.SIAC.Bll.ClaseBajaBusquedaPersonasManager.GetItem(Convert.ToInt32(Eval("MotivoDeBaja").ToString())).Descripcion.ToLower() %>' Visible='<%# Convert.ToBoolean(Eval("Baja")) %>'></asp:Label>
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
                             <asp:Button runat="server" ID="btnBorrarD" Text="Baja Logica" Height="22px" Width="105px"
                                    OnClick="btnBorrarD_Click" />
                                <asp:ConfirmButtonExtender ID="btnBorrarD_ConfirmButtonExtender" runat="server" ConfirmText="Confirma la baja?"
                                    Enabled="True" TargetControlID="btnBorrarD">
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
