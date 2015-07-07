<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="True"
    CodeBehind="Baja.aspx.cs" Inherits="MPBA.AutoresIgnorados.Web.Baja" %>

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
        <h3 id="cartelConsultando" runat="server" align="center">
            BAJA DE PERSONA DESAPARECIDA</h3>
    </div>
    <br />
              <asp:Panel ID="pnlIPP" runat="server" DefaultButton="btnBuscarIpp" Style="text-align: center"
                            BorderStyle="Solid" BorderWidth="4px">
                              <div align="center">
                              <table>
                              <tr>
                              <td colspan="3">
                              <asp:Panel runat="server" ID="pnlTipoAutor" GroupingText="Tipo de Autor" 
                                      HorizontalAlign="Center">
                              <asp:RadioButtonList runat="server" ID="rblTipoAutor" RepeatDirection="Horizontal" 
                                      AutoPostBack="True" onselectedindexchanged="rblTipoAutor_SelectedIndexChanged" >
                                  <asp:ListItem Value="AI">Autor Ignorado</asp:ListItem>
                                  <asp:ListItem Value="AA">Autor Aprehendido</asp:ListItem>
                                  </asp:RadioButtonList>
                                  <br />
                                  </asp:Panel>
                                  </td>
                                  </tr>
                                  <tr>
                                  <td>
                              <asp:Label ID="lblIppBuscado" runat="server" Font-Size="Large" Font-Bold="True"
                                            Style="vertical-align: middle; color: #13507d">IPP</asp:Label>
                                            </td>
                                            <td>
                                        <asp:TextBox ID="txtIppBuscado" runat="server" Width="200px" BorderColor="Black"
                                            BorderStyle="Solid" BorderWidth="1px" Font-Size="Large"></asp:TextBox>
                                       
                                       <asp:MaskedEditExtender ID="txtIpp_MaskedEditExtender" runat="server" 
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99-99-999999-99" MaskType="Number" onblurcssnegative="MaskedEditError" 
                                TargetControlID="txtIppBuscado">
                                  </asp:MaskedEditExtender>
                            </td>
                            <td>
                            <asp:Button ID="btnBuscarIpp" runat="server" OnClick="btnBuscarIpp_Click" Text="Buscar"
                                Width="76px" ForeColor="Black" Font-Size="Medium" />
                                </td>
                            </tr>
                            <tr>
                            <td colspan="3">
                             <asp:CustomValidator ID="cvIpp" runat="server" ControlToValidate="txtIppBuscado"
                                            ErrorMessage="Debe ingresar la IPP"></asp:CustomValidator>
                                            </td>
                            </tr>
                            </table>
                            
                            </div>
                    
                            <br />
                            <br />
                           
                            
                            <div id="divBaja" runat="server">
                                <div align="center">
                                    <%--<asp:Label ID="lblDelitoEncontrado" Text="Delito Encontrado" runat="server" 
                                        Visible="True" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                    <br />--%>
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
                                <table width="100%" style="border: 1px solid #00CCFF;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Motivo" runat="server" Font-Bold="True" 
                                                Font-Size="Medium" style="vertical-align:middle; color: #13507d">Motivo de Baja</asp:Label>
                      
                                            <asp:TextBox ID="txtMotivoBaja" runat="server" Width="300px" 
                                                BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                                                Font-Size="Medium"></asp:TextBox>
                          
                      
                                            <asp:Button runat="server" ID="btnBorrar" Text="Dar de Baja" Height="22px" Width="105px"
                                                OnClick="btnBorrar_Click" />
                                            <asp:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="Confirma la baja?"
                                                Enabled="True" TargetControlID="btnBorrar">
                                            </asp:ConfirmButtonExtender>
                                                               
                                        </td>
                                    </tr> 
                            </table>
                            <br />
                        </div>
                        </asp:Panel>
    <br />
    
    <table width="100%" style="margin: 15px">
        <tr>
            <td align="center">
                <asp:Panel ID="pnlBotones" runat="server">
                   
                           
                                <asp:Button ID="btnSalir" runat="server" Text="Salir" Height="22px" Width="105px"
                                        UseSubmitBehavior="False" OnClick="btnSalir_Click" />
                          
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
