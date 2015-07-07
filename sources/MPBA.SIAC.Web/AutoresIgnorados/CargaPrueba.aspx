<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    Inherits="MPBA.AutoresIgnorados.Web.CargaPrueba" CodeBehind="CargaPrueba.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
        <style type="text/css">
                .style28
                {
                    width: 100%;
                    table-layout: auto;
                }
                .style35
                {
                    width: 100%;
                }
                .style46
                {
                    position: relative;
                    left: 2px;
                    top: 2px;
                    width: 332px;
                    height: 30px;
                }
                .style51
                {
                  width: 427px;
                  text-align: left;
                }
                  .style52
                 {
                    width: 171px;
                 }
                .style53
                {
                    text-align: left;
                }
                .style54
                {
                    width: 102px;
                    height: 24px;
                }
                .style55
                {
                    width: 42px;
                }
                .style56
                {
                    position: relative;
                    left: 2px;
                    top: 2px;
                    width: 332px;
                    height: 128px;
                }
                .style57
                {
                    height: 128px;
                }
        </style>
<%--<link href="App_Css/styles.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    
    <div>
        <div style="border-style: groove; border-color: #13507d" class="FondoAutoresIgnorados">
        <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelPrincipal" runat="server" align="center">
                    AUTORES IGNORADOS</h3>
         </div>
            <asp:Image ID="imgCartelVictimas" runat="server" 
            ImageUrl="~/App_Images/cartelPruebas.png" Height="50px" Width="858px" />
            <div class="style9">
            <table style="width: 100%">
                <tr>
                    <td style="border-width: thin; border-bottom-style: solid; 
                        text-align: left;">
                        <asp:Label ID="lblCondicionCarga" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="border-width: thin; border-bottom-style: solid;" 
                        align="center">
                      <%--  <asp:Label ID="lblModus" runat="server" Font-Bold="True" Font-Size="Large" Text="Modus Operandi"></asp:Label>--%>
                    </td>
                </tr>
            </table>
           
        </div>
            <asp:Panel ID="pnlPruebas" runat="server">
           
                <table class="style28">
                <tr>
                    <td>
                        <asp:Panel ID="pnlReconocimiento" runat="server" 
                            GroupingText="Reconocimiento/s en rueda de personas">
                            <br />
                            <table class="style35">
                                <tr>
                                    <td class="style51">
                                        <asp:Label ID="lblCantVictimas" runat="server" 
                                            Text="Hay víctimas y/o testigos que podrían realizar reconocimientos en rueda de personas?" 
                                            style="text-align: left"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCantidadVictimas" runat="server" DataSourceID="odsCantVictimas"
                                            DataTextField="descripcion" DataValueField="id">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style51">
                                        <asp:Label ID="lblCantAutores" runat="server" Text="Cantidad de autores que podrían ser reconocidos"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCantidadAutoresRec" runat="server" DataSourceID="odsCantAutores"
                                            DataTextField="descripcion" DataValueField="id">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="pnlRastros" runat="server" GroupingText="Rastros">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvPrueba" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id"
                            OnRowDeleting="gvPrueba_RowDeleting" 
                            OnSelectedIndexChanged="gvPrueba_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Update" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="Editar" />
                                        &nbsp;<asp:Button ID="btnBorrar" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Borrar" />
                                        <asp:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="Desea borrar?"
                                            Enabled="True" TargetControlID="btnBorrar">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Clase Rastro" SortExpression="idClaseRastro">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsClaseRastro"
                                            DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Bind("idClaseRastro") %>'>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsClaseRastro" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRastro"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRastroManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseRastroManager.GetItem(Convert.ToInt32(Eval("idClaseRastro").ToString())).descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado Informe" SortExpression="idClaseEstadoInformeRastro">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource1"
                                            DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Bind("idClaseEstadoInformeRastro") %>'>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseEstadoInformeRastro"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseEstadoInformeRastroManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseEstadoInformeRastroManager.GetItem(Convert.ToInt32(Eval("idClaseEstadoInformeRastro").ToString())).descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField DataField="SusceptibleCotejoRastro" 
                                    HeaderText="Susceptible Cotejo" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnNuevo0" runat="server" Text="Agregar" 
                            onclick="btnNuevo0_Click" />
                        <%--<asp:ModalPopupExtender ID="btnNuevo0_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                            Drag="True" DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="PanelPrueba"
                            PopupDragHandleControlID="divHeader" TargetControlID="btnNuevo0" 
                            CancelControlID="btnCancelarRastro">
                        </asp:ModalPopupExtender>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            </asp:Panel>
        </div>
         <asp:UpdatePanel ID="upBotones" runat="server">
        <ContentTemplate>
        <table class="style35">
            <tr>
                <td class="style46">
                    <br />
                </td>
                <td align="right" valign="top">
                    <asp:Button ID="btnAnterior" runat="server" Height="26px" Text="&lt;  Anterior" 
                        OnClick="btnAnterior_Click" Width="75px" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente  &gt;" Visible="False" 
                        height="26px" width="75px" />
                    <asp:Button ID="btnGuardarDelito" runat="server" Text="Guardar" 
                        OnClick="btnGuardarDelito_Click" Font-Size="Large" Height="34px" 
                        Width="90px" />
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
            <table>
              <tr>
                <td colspan="2" align="right" class="style47">
                 <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Verdana" 
                         Font-Size="0.8em" PathSeparator="&gt;">
                         <CurrentNodeStyle ForeColor="#333333" />
                         <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
                         <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
                         <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
                     </asp:SiteMapPath>
                </td>
                </tr>
            <tr>
                <td class="style56">
                    <asp:ObjectDataSource ID="odsTipoRastro" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRastro"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRastroManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCantAutores" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseCantAutorReconocidos"
                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseCantAutorReconocidosManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCantVictimas" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseBoolean"
                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                        TypeName="MPBA.AutoresIgnorados.Bll.NNClaseBooleanManager" 
                        UpdateMethod="Save" InsertMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsEstadoInforme" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseEstadoInformeRastro"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseEstadoInformeRastroManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                </td>
                <td align="center" valign="top" class="style57">
                                        

                <asp:Panel ID="pnlGuardoBien" runat="server" BackColor="White" Width="177px" 
                        BorderColor="#3333CC" BorderStyle="Solid">
                    <table>
                        <tr>
                            <td class="style55" align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td class="style55">
                            <asp:Image ID="Image1" runat="server" Height="39px" 
                                ImageUrl="~/App_Images/exito.png" Width="35px" />
                        </td>
                            <td align="center" class="style52">
                                <asp:Label ID="lblCargaExitosa" runat="server" Font-Bold="True" Font-Size="Medium"
                                    Text="Los datos se guardaron exitosamente"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style55">
                                
                            </td>
                            <td class="style55">
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
                
                </td>
            </tr>
        </table>
         <asp:Panel ID="PanelPrueba" runat="server" CssClass="FondoModal" Width="300px">
            <div>
             <div id="divHeader" class="ModalHeader">CARGA DE PRUEBAS</div>
             <div style="position:relative; overflow:auto;">
             <asp:UpdatePanel ID="upGestionPrueba" runat="server">
             <ContentTemplate>
             <table style="width: 100%;">
                <tr>
                    <td class="style53">
                        <asp:Label ID="lblRastro" runat="server" Text="Rastro"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:DropDownList ID="ddlRastro" runat="server" DataSourceID="odsTipoRastro" DataTextField="descripcion"
                            DataValueField="id" AutoPostBack="True" 
                            onselectedindexchanged="ddlRastro_SelectedIndexChanged" 
                            ondatabound="ddlRastro_DataBound" Width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style53">
                        <asp:Label ID="lblEstadoInforme" runat="server" Text="Estado Informe"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:DropDownList ID="ddlEstadoInforme" runat="server" DataSourceID="odsEstadoInforme"
                            DataTextField="descripcion" DataValueField="id" width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style53">
                        <asp:Label ID="lblSusceptibleCotejo" runat="server" Text="Susceptible Cotejo"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:DropDownList ID="ddlSusceptibleCotejo" runat="server" width="150px">
                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                            <asp:ListItem Value="1">Si</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style53">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtDescripcion" runat="server" width="150px"></asp:TextBox>
                    </td>
                </tr>
             </table>
             </ContentTemplate>
             </asp:UpdatePanel>
            </div>
            <div  style="padding-top:10px; position:relative;">
                <asp:Button ID="btnOkPrueba" runat="server" Text="Aceptar" 
                        OnClick="btnOkPrueba_Click" />
                <asp:Button ID="btnCancelarRastro" runat="server" Text="Cancelar" CausesValidation="False"
                    Style="margin-left: 0px" Width="63px" onclick="btnCancelarRastro_Click" 
                        height="22px" />
                <asp:HiddenField ID="hfGestionPrueba" runat="server" />
                  <asp:ModalPopupExtender ID="hfGestionPrueba_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="PanelPrueba"
                            TargetControlID="hfGestionPrueba"
                            CancelControlID="btnCancelarRastro" OkControlID="hfGestionPrueba"
                            RepositionMode="None" Drag="True" 
                    PopupDragHandleControlID="DivHeader">
                  </asp:ModalPopupExtender>        
            </div>
         </div>
        </asp:Panel>
        <br />
    </div>
</asp:Content>
