<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master"  AutoEventWireup="true" CodeBehind="BusquedasFiscalia.aspx.cs" Inherits="MPBA.PersonasBuscadas.Web.BusquedasFiscalia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div runat="server" id="divStatus" style="border: 1px solid #66CCFF; right: 10px;
        display: table;" align="left">
        <asp:UpdatePanel runat="server" ID="upStatus">
            <ContentTemplate>
                <table>
                    <tr align="left">
                        <td>
                            <asp:LinkButton ID="btnBusquedasPendientes" runat="server" OnClick="btnBusquedasPendientes_Click">Búsquedas Activas</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="btnBusquedasViejas" runat="server" OnClick="btnBusquedasViejas_Click">Búsquedas Antiguas</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="btnCoincidenciasEncontradas" runat="server" OnClick="btnCoincidenciasEncontradas_Click">Coincidencias</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
    <asp:Panel ID="pnlBusquedasActivas" runat="server" Width="100%" CssClass="FondoModal"
        Height="250">
        <div>
            <div id="divHeaderBA" class="ModalHeader" >
                BUSQUEDAS ACTIVAS</div>
            <div style="position: relative; height: 200px; width: 100%">
                <asp:UpdatePanel ID="upBusquedasActivas" runat="server" >
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDesaparecidas" runat="server" Text="Desaparecidas"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblDesapCant" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnBusDesap" runat="server" OnClick="btnBusDesap_Click" Text="Ver" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblHalladas" runat="server" Text="Halladas"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblHalladasCant" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnDetalleBusHalladas" runat="server" OnClick="btnDetalleBusHalladas_Click"
                                        Text="Ver" />
                                </td>
                            </tr>
                            
                            
                        </table>
                        
                        <br />
                        <div style="overflow: auto; height: 120px;">
                        <asp:GridView runat="server" ID="gvBusqActivas" AutoGenerateColumns="False" DataKeyNames="Id"
                                OnSelectedIndexChanged="gvBusqActivas_SelectedIndexChanged" OnRowEditing="gvBusqActivas_RowEditing" >
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Update"></asp:LinkButton></EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Editar"></asp:LinkButton></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UFI" HeaderText="UFI" SortExpression="UFI" Visible ="false" />
                                    <asp:BoundField DataField="Ipp" HeaderText="IPP" SortExpression="Ipp" />
                                    <asp:BoundField DataField="FechaDesde" HeaderText="FechaDesde" SortExpression="FechaDesde" ApplyFormatInEditMode="true" DataFormatString="{0:dd-M-yyyy}" />
                                    <asp:BoundField DataField="FechaHasta" HeaderText="FechaHasta" SortExpression="FechaHasta" ApplyFormatInEditMode="true" DataFormatString="{0:dd-M-yyyy}"/>
                                    <asp:BoundField DataField="EdadDesde" HeaderText="EdadDesde" SortExpression="EdadDesde" />
                                    <asp:BoundField DataField="EdadHasta" HeaderText="EdadHasta" SortExpression="EdadHasta"  />
                                    <asp:TemplateField HeaderText="Sexo" SortExpression="idsexo">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idsexo") %>'></asp:TextBox></EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TallaDesde" HeaderText="TallaDesde" SortExpression="TallaDesde" />
                                    <asp:BoundField DataField="TallaHasta" HeaderText="TallaHasta" SortExpression="TallaHasta" />
                                    <asp:BoundField DataField="PesoDesde" HeaderText="PesoDesde" SortExpression="PesoDesde" />
                                    <asp:BoundField DataField="PesoHasta" HeaderText="PesoHasta" SortExpression="PesoHasta" />
                                    <asp:BoundField DataField="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True"
                                        ShowHeader="False" Visible="False">
                                        <ControlStyle Width="0px" />
                                        <FooterStyle Width="0px" Wrap="False" />
                                        <HeaderStyle Width="0px" Wrap="False" />
                                        <ItemStyle Width="0px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Fecha Consulta">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("FechaUltimaModificacion") %>'></asp:TextBox></EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label12" runat="server" Text='<%# Convert.ToDateTime(Eval("FechaUltimaModificacion")).ToString("dd/MM/yyyy") %>'></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <asp:UpdatePanel runat="server" ID="upBusqAct">
                    <ContentTemplate>
                        <asp:Button ID="btnCerrarBA" runat="server" Text="Cerrar" Width="63px" OnClick="btnCerrarBA_Click" />
                        <asp:HiddenField ID="hfBA" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
    </div>
    <div>
    <asp:Panel ID="pnlBusquedasViejas" runat="server" BorderStyle="Outset" Width="100%"
        CssClass="FondoModal">
        <div id="divHeaderBV" class="ModalHeader">
            BUSQUEDAS ANTIGUAS</div>
        <div style="position: relative; height: 200px;">
            <asp:UpdatePanel ID="upBusquedasViejas" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Cant. Busquedas Viejas:"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblCantBusqViejas" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div style="overflow: auto; height: 120px;">
                        <asp:GridView runat="server" ID="gvBusquedasViejas" AutoGenerateColumns="False" DataKeyNames="Id"
                            OnRowEditing="gvBusquedasViejas_RowEditing" OnSelectedIndexChanged="gvBusquedasViejas_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnActualizarBV" runat="server" CausesValidation="false" CommandArgument="Actualizar"
                                            CommandName="Select" OnClick="btnActualizarBV_Click" Text="Renovar"></asp:LinkButton></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkVerBV" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Ver"></asp:LinkButton></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnBorrarBV" runat="server" CausesValidation="False" CommandName="Select"
                                            OnClick="btnBorrarBV_Click" Text="Borrar"></asp:LinkButton></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo Consulta" SortExpression="idOrigen">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtOrigen" runat="server" Text='<%# Bind("idOrigen") %>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrigen" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseTablaDestinoManager.GetItem(Convert.ToInt32(Eval("idOrigen").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UFI" HeaderText="UFI" SortExpression="UFI" />
                                <asp:BoundField DataField="FechaDesde" HeaderText="FechaDesde" SortExpression="FechaDesde" ApplyFormatInEditMode="true" DataFormatString="{0:dd-M-yyyy}" />
                                <asp:BoundField DataField="FechaHasta" HeaderText="FechaHasta" SortExpression="FechaHasta" ApplyFormatInEditMode="true" DataFormatString="{0:dd-M-yyyy}" />
                                <asp:BoundField DataField="EdadDesde" HeaderText="EdadDesde" SortExpression="EdadDesde" />
                                <asp:BoundField DataField="EdadHasta" HeaderText="EdadHasta" SortExpression="EdadHasta" />
                                <asp:TemplateField HeaderText="Sexo" SortExpression="idsexo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idsexo") %>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# MPBA.PersonasBuscadas.Bll.PBClaseSexoManager.GetItem(Convert.ToInt32(Eval("idSexo").ToString())).Descripcion.ToLower() %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TallaDesde" HeaderText="TallaDesde" SortExpression="TallaDesde" />
                                <asp:BoundField DataField="TallaHasta" HeaderText="TallaHasta" SortExpression="TallaHasta" />
                                <asp:BoundField DataField="PesoDesde" HeaderText="PesoDesde" SortExpression="PesoDesde" />
                                <asp:BoundField DataField="PesoHasta" HeaderText="PesoHasta" SortExpression="PesoHasta" />
                                <asp:BoundField ControlStyle-Width="0" DataField="Id" FooterStyle-Width="0" FooterStyle-Wrap="False"
                                    HeaderStyle-Width="0" HeaderStyle-Wrap="False" InsertVisible="False" ItemStyle-Width="0"
                                    ItemStyle-Wrap="False" ReadOnly="True" ShowHeader="False" SortExpression="Id"
                                    Visible="False">
                                    <ControlStyle Width="0px" />
                                    <FooterStyle Width="0px" Wrap="False" />
                                    <HeaderStyle Width="0px" Wrap="False" />
                                    <ItemStyle Width="0px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Fecha Consulta">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("FechaUltimaModificacion") %>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Convert.ToDateTime(Eval("FechaUltimaModificacion")).ToString("dd/MM/yyyy") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="padding-top: 10px; position: relative;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnCerrarBusquedasViejas" runat="server" Text="Cerrar" Width="63px"
                        OnClick="btnCerrarBV_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    </div>
    <asp:HiddenField ID="hfBusquedasActivas" runat="server" />
    <asp:ModalPopupExtender ID="hfBusquedasActivas_ModalPopupExtender" runat="server"
        BackgroundCssClass="FondoOscuro" Drag="True" DropShadow="True" DynamicServicePath=""
        Enabled="True" PopupControlID="pnlBusquedasActivas" PopupDragHandleControlID="divHeaderBA"
        TargetControlID="hfBusquedasActivas">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="hfGestionBV" runat="server" />
    <asp:ModalPopupExtender ID="hfGestionBV_ModalPopupExtender" runat="server" DynamicServicePath=""
        Enabled="True" PopupControlID="pnlBusquedasViejas" TargetControlID="hfGestionBV"
        DropShadow="True" Drag="True" PopupDragHandleControlID="divHeaderBV" BackgroundCssClass="FondoOscuro">
    </asp:ModalPopupExtender>
</asp:Content>

