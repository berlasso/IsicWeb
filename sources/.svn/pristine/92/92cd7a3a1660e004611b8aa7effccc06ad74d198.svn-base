<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Inherits="MPBA.AutoresIgnorados.Web.ListaDelitos" CodeBehind="ListaDelitos.aspx.cs" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style5
        {
            height: 36px;
        }
        .style1
        {
            height: 1500px;
        }
        .style8
        {
            height: 376px;
        }
        .style28
        {
            width: 100%;
            table-layout: auto;
        }
        .style30
        {
            width: 139px;
        }
        .style45
        {
            height: 300px;
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
        .style47
        {
            height: 30px;
        }
    </style>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="style8">
        <div class="style45" 
            style="border-style: groove; border-color: #800000; clip: rect(auto, auto, auto, auto); height: auto;">
            <table class="style28">
                <tr>
                    <td colspan="2" style="border-width: thin; border-bottom-style: solid; background-color: #FFFFFF;">
                        <asp:Label ID="lblDelito" runat="server" Font-Bold="True" Font-Size="Large" 
                            Text="Delitos"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        &nbsp;
                        </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="justify" colspan="2">
                        <asp:ObjectDataSource ID="odsDelitos" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.Delitos"
                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.DelitosManager" 
                            UpdateMethod="Save">
                        </asp:ObjectDataSource>
                      
                                <asp:GridView ID="GridViewModusOp" runat="server" 
    Height="51px" Width="683px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="odsDelitos"
                            CellPadding="4" ForeColor="#333333" 
    GridLines="None">
                                    <RowStyle BackColor="#E3EAEB" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Button" CancelText="X" DeleteText="Borrar" EditText="Editar"
                                    InsertText="OK" NewText="Nuevo" SelectText="Elegir" 
                                    ShowDeleteButton="True" ShowEditButton="True" UpdateText="OK" />
                                        <asp:BoundField DataField="id" HeaderText="id" Visible="False" ReadOnly="True" 
                                    SortExpression="id" />
                                        <asp:BoundField DataField="idCausa" HeaderText="Causa" 
                                            SortExpression="idCausa" />
                                        <asp:TemplateField HeaderText="MomentoDelDia" 
                                    SortExpression="idClaseMomentoDelDia">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsMomentoDia"
                                            DataTextField="descripcion" DataValueField="id" 
                                            SelectedValue='<%# Bind("idClaseMomentoDelDia") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsMomentoDia" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseMomentoDia"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseMomentoDiaManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMomentoDia" runat="server" 
                                            
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseMomentoDiaManager.GetItem(Convert.ToInt32(Eval("idClaseMomentoDelDia").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="idClaseFecha" HeaderText="Fecha" 
                                    SortExpression="idClaseFecha" />
                                        <asp:BoundField DataField="FechaDesde" HeaderText="Desde" 
                                    SortExpression="FechaDesde" />
                                        <asp:BoundField DataField="FechaHasta" HeaderText="Hasta" 
                                    SortExpression="FechaHasta" />
                                        <asp:BoundField DataField="idClaseHora" HeaderText="Hora" 
                                    SortExpression="idClaseHora" />
                                        <asp:BoundField DataField="HoraDesde" HeaderText="HoraDesde" 
                                    SortExpression="HoraDesde" />
                                        <asp:BoundField DataField="HoraHasta" HeaderText="HoraHasta" 
                                    SortExpression="HoraHasta" />
                                        <asp:BoundField DataField="idPartido" HeaderText="Partido" 
                                    SortExpression="idPartido" />
                                        <asp:BoundField DataField="idLocalidad" HeaderText="Localidad" 
                                    SortExpression="idLocalidad" />
                                        <asp:BoundField DataField="idCalle" HeaderText="idCalle" Visible="False" 
                                    SortExpression="idCalle" />
                                        <asp:BoundField DataField="idOtraCalle" HeaderText="idOtraCalle" Visible="False"
                                    SortExpression="idOtraCalle" />
                                        <asp:BoundField DataField="idEntreCalle1" HeaderText="idEntreCalle1" Visible="False"
                                    SortExpression="idEntreCalle1" />
                                        <asp:BoundField DataField="idOtraEntreCalle" HeaderText="idOtraEntreCalle" Visible="False"
                                    SortExpression="idOtraEntreCalle" />
                                        <asp:BoundField DataField="idEntreCalle2" HeaderText="idEntreCalle2" Visible="False"
                                    SortExpression="idEntreCalle2" />
                                        <asp:BoundField DataField="idOtraEntreCalle2" HeaderText="idOtraEntreCalle2" Visible="False"
                                    SortExpression="idOtraEntreCalle2" />
                                        <asp:BoundField DataField="NroH" HeaderText="NroH" SortExpression="NroH" 
                                    Visible="False" />
                                        <asp:BoundField DataField="PisoH" HeaderText="PisoH" SortExpression="PisoH" 
                                    Visible="False" />
                                        <asp:BoundField DataField="DeptoH" HeaderText="DeptoH" Visible="False" 
                                    SortExpression="DeptoH" />
                                        <asp:BoundField DataField="ParajeBarrioH" HeaderText="ParajeBarrioH" Visible="False"
                                    SortExpression="ParajeBarrioH" />
                                        <asp:BoundField DataField="idComisariaH" HeaderText="Comisaria" 
                                    SortExpression="idComisariaH" />
                                        <asp:BoundField DataField="idClaseLugar" HeaderText="Lugar" 
                                    SortExpression="idClaseLugar" />
                                        <asp:BoundField DataField="idClaseRubro" HeaderText="Rubro" 
                                    SortExpression="idClaseRubro" />
                                        <asp:TemplateField HeaderText="Modo Arribo/Huida" 
                                    SortExpression="idClaseModoArriboHuida">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="odsModoArriboHuida"
                                            DataTextField="descripcion" DataValueField="id" 
                                            SelectedValue='<%# Bind("idClaseModoArriboHuida") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsModoArriboHuida" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseModoArriboHuida"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseModoArriboHuidaManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblModoArribo" runat="server" 
                                            
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseModoArriboHuidaManager.GetItem(Convert.ToInt32(Eval("idClaseModoArriboHuida").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="idClaseModusOperandis" HeaderText="ModusOperandis" 
                                    SortExpression="idClaseModusOperandis" />
                                        <asp:BoundField DataField="ExprUtilizadaComienzoDelHecho" Visible="False" HeaderText="ExprUtilizadaComienzoDelHecho"
                                    SortExpression="ExprUtilizadaComienzoDelHecho" />
                                        <asp:BoundField DataField="ExprReiteradaDuranteHecho" Visible="False" HeaderText="ExprReiteradaDuranteHecho"
                                    SortExpression="ExprReiteradaDuranteHecho" />
                                        <asp:BoundField DataField="IngresaronPor" HeaderText="IngresaronPor" Visible="False"
                                    SortExpression="IngresaronPor" />
                                        <asp:CheckBoxField DataField="VictimasEnElLugar" HeaderText="VictimasEnElLugar" Visible="False"
                                    SortExpression="VictimasEnElLugar" />
                                        <asp:CheckBoxField DataField="UsoDeArmas" HeaderText="UsoDeArmas" 
                                    SortExpression="UsoDeArmas" />
                                        <asp:TemplateField HeaderText="Arma" SortExpression="idClaseArma">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="odsArma" DataTextField="descripcion"
                                            DataValueField="id" SelectedValue='<%# Bind("idClaseArma") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsArma" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseArma"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseArmaManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" 
                                            
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseArmaManager.GetItem(Convert.ToInt32(Eval("idClaseArma").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CheckBoxField DataField="HuboAgresionFisicaAVictima" Visible="False" HeaderText="AgresionFisicaAVictima"
                                    SortExpression="HuboAgresionFisicaAVictima" />
                                        <asp:TemplateField HeaderText="Agresion" SortExpression="idClaseAgresion">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="odsAgresion" DataTextField="descripcion"
                                            DataValueField="id" SelectedValue='<%# Bind("idClaseAgresion") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsAgresion" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseAgresion"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseAgresionManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" 
                                            
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseAgresionManager.GetItem(Convert.ToInt32(Eval("idClaseAgresion").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ZonaCuerpoLesionada" 
                                    SortExpression="idClaseZonaCuerpoLesionada">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="odsZonaCuerpoLesionada"
                                            DataTextField="descripcion" DataValueField="id" 
                                            SelectedValue='<%# Bind("idClaseZonaCuerpoLesionada") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsZonaCuerpoLesionada" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseZonaCuerpoLesionada"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseZonaCuerpoLesionadaManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" 
                                            
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseZonaCuerpoLesionadaManager.GetItem(Convert.ToInt32(Eval("idClaseZonaCuerpoLesionada").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CheckBoxField DataField="VictimaTrasladadaAOtroLugar" Visible="False" HeaderText="VictimaTrasladadaAOtroLugar"
                                    SortExpression="VictimaTrasladadaAOtroLugar" />
                                        <asp:BoundField DataField="LugarTrasladoVictima" HeaderText="LugarTrasladoVictima"
                                    Visible="False" SortExpression="LugarTrasladoVictima" />
                                        <asp:BoundField DataField="idPartidoL" HeaderText="idPartidoL" Visible="False" 
                                    SortExpression="idPartidoL" />
                                        <asp:BoundField DataField="idLocalidadL" HeaderText="idLocalidadL" Visible="False"
                                    SortExpression="idLocalidadL" />
                                        <asp:BoundField DataField="idCalleL" HeaderText="idCalleL" Visible="False" 
                                    SortExpression="idCalleL" />
                                        <asp:BoundField DataField="idOtraCalleL" HeaderText="idOtraCalleL" Visible="False"
                                    SortExpression="idOtraCalleL" />
                                        <asp:BoundField DataField="idEntreCalle1L" HeaderText="idEntreCalle1L" Visible="False"
                                    SortExpression="idEntreCalle1L" />
                                        <asp:BoundField DataField="OtraEntreCalle1L" HeaderText="OtraEntreCalle1L" Visible="False"
                                    SortExpression="OtraEntreCalle1L" />
                                        <asp:BoundField DataField="idEntreCalle2L" HeaderText="idEntreCalle2L" Visible="False"
                                    SortExpression="idEntreCalle2L" />
                                        <asp:BoundField DataField="OtraEntreCalle2L" HeaderText="OtraEntreCalle2L" Visible="False"
                                    SortExpression="OtraEntreCalle2L" />
                                        <asp:BoundField DataField="ParajeBarrioL" HeaderText="ParajeBarrioL" Visible="False"
                                    SortExpression="ParajeBarrioL" />
                                        <asp:BoundField DataField="idComisariaL" HeaderText="idComisariaL" Visible="False"
                                    SortExpression="idComisariaL" />
                                        <asp:TemplateField HeaderText="CantidadAutores" 
                                            SortExpression="CantidadAutores">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList8" runat="server" 
                                                    DataSourceID="odsCantAutores" DataTextField="descripcion" DataValueField="id" 
                                                    SelectedValue='<%# Bind("idClaseCantidadAutores") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsCantAutores" runat="server" 
                                                    DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseCantidadAutores" 
                                                    DeleteMethod="Delete" InsertMethod="Save" 
                                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                                                    TypeName="MPBA.AutoresIgnorados.Bll.NNClaseCantidadAutoresManager" 
                                                    UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" 
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseCantidadAutoresManager.GetItem(Convert.ToInt32(Eval("idClaseCantidadAutores").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="MontoTotalEstimadoBienSustraido" Visible="False" HeaderText="MontoTotalEstimadoBienSustraido"
                                    SortExpression="MontoTotalEstimadoBienSustraido" />
                                        <asp:TemplateField HeaderText="CantVicTestRecRueda" 
                                    SortExpression="idClaseCantVicTestRecRueda">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="odsCantVicRueda"
                                            DataTextField="descripcion" DataValueField="id" 
                                            SelectedValue='<%# Bind("idClaseCantVicTestRecRueda") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsCantVicRueda" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseCantVictTestRecRueda"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseCantVictTestRecRuedaManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" 
                                            
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseCantVictTestRecRuedaManager.GetItem(Convert.ToInt32(Eval("idClaseCantVicTestRecRueda").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CantAutorReconocidos" 
                                    SortExpression="idClaseCantAutorReconocidos">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="odsCantAutorRec"
                                            DataTextField="descripcion" DataValueField="id" 
                                            SelectedValue='<%# Bind("idClaseCantAutorReconocidos") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsCantAutorRec" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseCantAutorReconocidos"
                                            DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseCantAutorReconocidosManager"
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" 
                                            
                                                    Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseCantAutorReconocidosManager.GetItem(Convert.ToInt32(Eval("idClaseCantAutorReconocidos").ToString())).descripcion %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="idUsuarioUltimaModificacion" Visible="False" HeaderText="idUsuarioUltimaModificacion"
                                    SortExpression="idUsuarioUltimaModificacion" />
                                        <asp:BoundField DataField="FechaUltimaModificacion" HeaderText="FechaUltimaModificacion"
                                    SortExpression="FechaUltimaModificacion" Visible="False" />
                                    </Columns>
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                        <tr>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table class="style35">
            <tr>
                <td class="style46">
                </td>
                <td align="right" class="style47">
                    <asp:Button ID="btnAnterior" runat="server" Height="26px" Text="Crear" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Modificar" />
                    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" />
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>
