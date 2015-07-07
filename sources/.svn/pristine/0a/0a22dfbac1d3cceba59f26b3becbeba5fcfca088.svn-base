<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeBehind="BusquedaPruebasPendientes.aspx.cs" Inherits="MPBA.AutoresIgnorados.Web.BusquedaPruebasPendientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


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
        .style49
        {
          width: 75%;
          text-align: left;
        }
        </style>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div>
        <div style="border-style: groove; border-color: #800000;" class="FondoAutoresIgnorados">
            <table class="style48">
             <tr>
                <td style="border-width: thin; border-bottom-style: solid; ">
                    <asp:Label ID="lblBusquedaPruebasPendientes" runat="server" Font-Bold="True" Font-Size="Large"
                       Text="Pruebas Pendientes"></asp:Label>
                </td>
             </tr>
             <tr>
                <td class="style49" valign="top">
                        <asp:Panel ID="pnlResultados" runat="server" Style="width: 100%;">
                          <table style="width: 100%">
                             <tr>
                                 <td>
                                   <asp:GridView ID="gvPrueba" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                        CellSpacing="-1" Caption="LISTADO DE PRUEBAS" CaptionAlign="Left">
                                       <RowStyle HorizontalAlign="Left" />
                                       <Columns>
                                           <asp:BoundField DataField="idCausa" HeaderText="IPP" SortExpression="idCausa">
                                               <ItemStyle HorizontalAlign="Left" />
                                           </asp:BoundField>
                                           <asp:TemplateField HeaderText="Rastro" SortExpression="idClaseRastro">
                                               <ItemTemplate>
                                                   <asp:Label ID="Label1" runat="server" 
                                                       Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseRastroManager.GetItem(Convert.ToInt32(Eval("idClaseRastro").ToString())).descripcion %>'></asp:Label>
                                               </ItemTemplate>
                                               <EditItemTemplate>
                                                   <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idClaseRastro") %>'></asp:TextBox>
                                               </EditItemTemplate>
                                           </asp:TemplateField>
                                           <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                                               SortExpression="Descripcion" />
                                           <asp:BoundField DataField="idUsuarioUltimaModificacion" HeaderText="Usuario" 
                                               SortExpression="idUsuarioUltimaModificacion" Visible="False" />
                                       </Columns>
                                       <EditRowStyle HorizontalAlign="Left" />
                                   </asp:GridView>
                                 </td>
                             </tr>
                           </table>      
                        </asp:Panel>
                </td>
             </tr>
            </table>
        </div>
        <asp:UpdatePanel ID="upBotones" runat="server">
        <ContentTemplate>
        <table class="style35">
            <tr>
                <td>
                    &nbsp;</td>
                <td align="right">
                   <asp:Button ID="btnBuscar" runat="server" Text="Buscar"
                        Width="69px" UseSubmitBehavior="False" Height="22px" Visible="False" />
                   <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="64px" 
                        Height="22px" UseSubmitBehavior="False" Visible="False" />
                   <asp:Button ID="btnSalir" runat="server" Text="Salir" Height="22px" Width="64px"
                        UseSubmitBehavior="False" OnClick="btnSalir_Click" />
               </td>
            </tr>
        </table>        
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>