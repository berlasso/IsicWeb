<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    Inherits="MPBA.AutoresIgnorados.Web.CargaModusOperandi" CodeBehind="CargaModusOperandi.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style9
        {
            height: 29px;
        }
        .style28
        {
            width: 100%;
            table-layout: auto;
        }
        .style29
        {
            width: 142px;
        }
        .style30
        {
            width: 139px;
        }
        .style35
        {
            width: 100%;
        }
        .style36
        {
            text-align: left;
        }
        .style37
        {
            width: 54px;
        }
        .style40
        {
            width: 99px;
            text-align: left;
        }
        .style41
        {
            width: 86px;
            text-align: left;
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
        .style52
        {
            margin-top: 3px;
        }
        .style53
        {
            text-align: left;
        }
        .style55
        {
            text-align: left;
            width: 184px;
        }
        .style56
        {
            width: 104px;
        }
        .style57
        {
            text-align: left;
            width: 937px;
        }
        .style58
        {
        }
        .style59
        {
            width: 134px;
        }
        .style61
        {
            text-align: left;
        }
        .style62
        {
            text-align: left;
            width: 71px;
        }
        .style63
        {
            width: 71px;
        }
        .style64
        {
            height: 4px;
        }
    </style>
    <%--<form id="form2" runat="server">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    
    <div class="FondoAutoresIgnorados" style="border-style: groove; border-color: #13507d; text-align: left;
        padding-left: 10px; height: auto;">
         <asp:Image ID="imgCartelVictimas" runat="server" 
            ImageUrl="~/App_Images/cartelMO.png" Height="50px" Width="858px" />
            <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelPrincipal" runat="server" align="center">
                    AUTORES DESCONOCIDOS</h3>
         </div>
        <div class="style9">
            <table style="width: 100%">
                <tr>
                    <td style="border-width: thin; border-bottom-style: solid; 
                        text-align: left;" class="style56">
                        <asp:Label ID="lblCondicionCarga" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="border-width: thin; border-bottom-style: solid; 
                        align="center">
                      <%--  <asp:Label ID="lblModus" runat="server" Font-Bold="True" Font-Size="Large" Text="Modus Operandi"></asp:Label>--%>
                    </td>
                </tr>
            </table>
           
        </div>
        <asp:Panel ID="pnlModusOperandi" runat="server">
        <table class="style28">
            <tr>
                <td class="style30" align="left" style="border-bottom-style: solid; border-width: thin">
                    <asp:Label ID="lblClasificacion" runat="server" Text="Clasificación"></asp:Label>
                </td>
                <td class="style57" style="border-bottom-style: solid; border-width: thin">
                    <asp:DropDownList ID="ddlClasificacion" runat="server" Width="300px" DataSourceID="ObjectDataSourceTipoModOp"
                        DataTextField="descripcion" DataValueField="id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style29" align="left">
                    <asp:Label ID="lblArribo" runat="server" Text="Modo de Arribo/Huída"></asp:Label>
                </td>
                <td class="style57">
                    <asp:DropDownList ID="ddlArribo" runat="server" Width="300px" DataSourceID="ObjectDataSourceModoArribo"
                        DataTextField="descripcion" DataValueField="id" AutoPostBack="True" 
                        onselectedindexchanged="ddlArribo_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlVehiculo" runat="server" Style="text-align: left; overflow: auto;"
            GroupingText="Vehículo utilizado en el Arribo">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvVehiculos" runat="server" AutoGenerateColumns="False" DataKeyNames="id,idMarcaVehiculo,idModeloVehiculo,idClaseVidriovehiculo,idColorvehiculo"
                            OnRowDeleting="gvVehiculos_RowDeleting" 
                            OnSelectedIndexChanged="gvVehiculos_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="Editar" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Update" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                       <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" 
                                            Text="Borrar" />
                                        <asp:ConfirmButtonExtender ID="Button2_ConfirmButtonExtender" runat="server" ConfirmText="Está seguro?"
                                            Enabled="True" TargetControlID="Button2">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marca" SortExpression="idMarcaVehiculo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# MPBA.SIAC.Bll.MarcaVehiculoManager.GetItem(Convert.ToInt32(Eval("idMarcaVehiculo").ToString())).Descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modelo" SortExpression="idModeloVehiculo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# MPBA.SIAC.Bll.ModeloVehiculoManager.GetItem(Convert.ToInt32(Eval("idModeloVehiculo").ToString())).Descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vidrios" SortExpression="idClaseVidrioVehiculo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager.GetItem(Convert.ToInt32(Eval("idClaseVidrioVehiculo").ToString())).descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Color" SortExpression="idColorVehiculo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# MPBA.SIAC.Bll.ColorVehiculoManager.GetItem(Convert.ToInt32(Eval("idColorVehiculo").ToString())).Descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Patente" SortExpression="Dominio">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Dominio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Dominio") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="Dominio" HeaderText="Patente" SortExpression="Dominio" />
                                <asp:BoundField DataField="NumeroChasis" HeaderText="Chasis" SortExpression="NumeroChasis" />
                                <asp:BoundField DataField="NumeroMotor" HeaderText="Motor" SortExpression="NumeroMotor" />
                                <asp:BoundField DataField="anio" HeaderText="Año" SortExpression="anio" />
                                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible = "false" ReadOnly = "true" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btnNuevoVehiculo" runat="server" OnClick="btnNuevoVehiculo_Click"
                            Text="Nuevo" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table>
            <tr>
                <td colspan="2" class="style61">
                    <asp:Label ID="lblHuboVictimas" runat="server" Text="¿Hubo víctimas presentes en el lugar?"></asp:Label>
                </td>
               
                <td class="style58">
                    <asp:DropDownList ID="ddlHuboVictimas" runat="server" Width="50px" DataSourceID="odsClaseBoolean"
                        DataTextField="Descripcion" DataValueField="Id">
                    </asp:DropDownList>
                    <br />
                </td>
               
                <td class="style58">
                    
                </td>
               
               <td>
               </td>
               
            </tr>
            <tr>
                <td colspan="2" class="style61">
                    <asp:Label ID="lblHuboAgresion" runat="server" Text="¿Hubo agresión física contra las víctimas?"></asp:Label>
                </td>
               
               
             
                
               
               
                <%--<td class="style58" valign="middle">
                            <asp:Label ID="lblArmaUtilizada" runat="server" Text="Arma usada" Enabled="False" />
                </td>
               
               
                <td class="style58" valign="middle">
                            <asp:DropDownList ID="ddlArmaUtilizada" runat="server" DataSourceID="ObjectDataSourceTipoArma"
                                DataTextField="descripcion" DataValueField="id" Style="margin-bottom: 0px"
                                Enabled="False" Width="150px">
                            </asp:DropDownList>
                </td>--%>
              
              
                  <td class="style58" valign="middle">
                    <asp:DropDownList ID="ddlHuboAgresion" runat="server" Width="49px" CssClass="style52"
                        DataSourceID="odsClaseBoolean" DataTextField="Descripcion" 
                          DataValueField="Id" AutoPostBack="True" 
                          onselectedindexchanged="ddlHuboAgresion_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
               </td>
                <td>
               <asp:Label ID="lblTipoAgresion" runat="server" Text="Tipo de Agresión"></asp:Label>
               </td>
               <td class="style58">
                    <asp:DropDownList ID="ddlTipoAgresion" runat="server" Style="margin-left: 2px"
                        DataSourceID="odsTipoAgresion" DataTextField="descripcion" 
                        DataValueField="id" Width="150px" Enabled="False">
                        <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Sí</asp:ListItem>
                    </asp:DropDownList>
                </td>
               
            </tr>
            <tr>
            <td colspan="6">
                <asp:UpdatePanel ID="upArmas" runat="server">
                    <ContentTemplate>
                    <table width="100%">
                    <tr>
                        <td colspan="2" class="style61">
                            <asp:Label ID="lblUtilizaronArmas" runat="server" Text="¿Se utilizaron armas?"></asp:Label>
                        </td>
                        <td class="style58" >
                            <asp:DropDownList ID="ddlUtilizaronArmas" runat="server" Width="50px" DataSourceID="odsClaseBoolean"
                                DataTextField="Descripcion" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="ddlUtilizaronArmas_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                        </td>
                           <td class="style58" valign="middle">
                            <asp:Label ID="lblArmaUtilizada" runat="server" Text="Arma usada" Enabled="False" />
                        </td>
               
               
                        <td class="style58" valign="middle">
                            <asp:DropDownList ID="ddlArmaUtilizada" runat="server" DataSourceID="ObjectDataSourceTipoArma"
                                DataTextField="descripcion" DataValueField="id" Style="margin-bottom: 0px"
                                Enabled="False" Width="150px" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td class="style58" valign="middle">
                            <asp:Label ID="lblTipoArma" runat="server" Text="Tipo Arma"  />
                        </td>
               
               
                        <td class="style58" valign="middle">
                            <asp:DropDownList ID="ddlTipoArma" runat="server" DataSourceID="ObjectDataSourceSubTipoArma"
                                DataTextField="descripcion" DataValueField="id" Style="margin-bottom: 0px"
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                     
                        <%--<td>
                            &nbsp;
                            </td>--%>
                            </tr>
                            </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="style36" colspan="2">
                    <asp:Label ID="lblExpresionDelito" runat="server" Text="¿Expresión o palabra utlizada en el hecho delictivo?"></asp:Label>
                </td>
                <td class="style58" colspan="3">
                    <asp:TextBox ID="txtExpresionDelito" runat="server" Width="446px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style61" valign="top" colspan="2">
                    <asp:Label ID="lblIngresaronPor" runat="server" Text="Ingresaron por"></asp:Label>
                </td>
              
                <td colspan="3">
                    <asp:TextBox ID="txtIngresaronPor" runat="server" Width="446px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style61" valign="top">
                    <asp:Label ID="lblFueronTrasladadas" runat="server" 
                        Text="¿La/s víctima/s fue/ron trasladado/s a otro/s lugar/es?" Width="280px"></asp:Label>
                </td>
                <td colspan="4" class="style37" valign="top">
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlFueronTrasladadas" runat="server" Width="50px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlFueronTrasladadas_SelectedIndexChanged" DataSourceID="odsClaseBoolean"
                                    DataTextField="Descripcion" DataValueField="Id">
                                </asp:DropDownList>
                                <br />
                                <asp:Button ID="btnNuevoLugarTraslado" runat="server" Text="Agregar" OnClick="btnNuevoLugar_Click"
                                    CommandArgument="traslado" />
                            </td>
                            <td style="text-align: center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvLugarTraslado" runat="server" AutoGenerateColumns="False" CellSpacing="-1"
                                            OnRowDeleting="gvLugarTraslado_RowDeleting" PageSize="2" Width="230px" HorizontalAlign="Center">
                                            <Columns>
                                                <asp:CommandField ButtonType="Button" DeleteText="Borrar" ShowDeleteButton="True" />
                                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                    SortExpression="id" Visible="False" />
                                                <asp:BoundField DataField="idCausa" HeaderText="idCausa" SortExpression="idCausa"
                                                    Visible="False" />
                                                <asp:BoundField DataField="idDelito" HeaderText="idDelito" SortExpression="idDelito"
                                                    Visible="False" />
                                                <asp:TemplateField HeaderText="Localidad" SortExpression="idLocalidad">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# MPBA.SIAC.Bll.LocalidadManager.GetItem(Convert.ToInt32(Eval("idLocalidad").ToString())).localidad %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
               
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlLugarLiberacion" runat="server" GroupingText="Lugar de Liberación"
            Height="106px">
            <table style="width: 100%;">
                <tr>
                    <td class="style55">
                        <asp:Label ID="lblLocalidadLiberacion" runat="server" Text="Localidad"></asp:Label>
                    </td>
                    <td class="style41">
                        <asp:UpdatePanel ID="upLocalidadL" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblLocalidadL" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style53">
                        <asp:ImageButton ID="btnBuscarLocalidadL" runat="server" AlternateText="+" CommandName=""
                            Height="16px" ImageUrl="~/App_Images/magnify.png" Width="16px" OnClick="btnBuscarLocalidadL_Click" />
                    </td>
                    <td class="style53">
                        <asp:Label ID="lblPartidoLiberacion" runat="server" Text="Partido"></asp:Label>
                    </td>
                    <td class="style40">
                        <asp:UpdatePanel ID="upPartidoL" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblPartidoL" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style53">
                        <asp:ImageButton ID="btnBuscarPartido" runat="server" AlternateText="+" CommandName=""
                            Height="16px" ImageUrl="~/App_Images/magnify.png" OnClick="btnBuscarPartido_Click1"
                            Width="16px" />
                    </td>
                    <td class="style62">
                        <asp:Label ID="lblParaje" runat="server" Text="Paraje/Barrio"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtParaje" runat="server" Width="105px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style55">
                        &nbsp;</td>
                    <td class="style41">
                        &nbsp;</td>
                    <td class="style53">
                    </td>
                    <td class="style53">
                    </td>
                    <td class="style53">
                    </td>
                    <td class="style53">
                    </td>
                    <td class="style62">
                    </td>
                    <td class="style53">
                    </td>
                </tr>
                <tr>
                    <td class="style55">
                        <asp:Label ID="lblComisariaLiberacion" runat="server" Text="Comisaría de la Jurisdicción"></asp:Label>
                    </td>
                    <td class="style41">
                        <asp:UpdatePanel ID="upComisariaL" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblComisariaL" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="style53">
                        <asp:ImageButton ID="btnTraerComisariaL" runat="server" AlternateText="+" CommandName="bla"
                            Height="16px" ImageUrl="~/App_Images/magnify.png" Width="16px" ImageAlign="Left"
                            OnClick="btnTraerComisariaL_Click" />
                        <asp:ModalPopupExtender ID="btnTraerComisariaL_ModalPopupExtender" runat="server"
                            BackgroundCssClass="FondoOscuro" CancelControlID="btnCancelarComisariaL" DropShadow="True"
                            DynamicServicePath="" Enabled="True" OkControlID="hfComisariaL" PopupControlID="pnlComisariasL"
                            TargetControlID="btnTraerComisariaL" Drag="True" PopupDragHandleControlID="divHeaderComisaria">
                        </asp:ModalPopupExtender>
                    </td>
                    <td class="style53">
                    </td>
                    <td class="style53">
                    </td>
                    <td class="style53">
                    </td>
                    <td class="style63">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <br />
        <br />
        </asp:Panel>
    </div>
        
              <asp:UpdatePanel ID="upBotones" runat="server">
        <ContentTemplate>
            <table width="100%">
            <tr>
            <td align="right" class="style47">
                <asp:Button ID="btnAnterior" runat="server" Height="26px" OnClick="btnAnterior_Click"
                    Width="75px" Text="&lt;  Anterior" />
                <asp:Button ID="btnSiguiente" runat="server" OnClick="btnSiguiente_Click" Height="26px"
                    Width="75px" Text="Siguiente  &gt;" />
                <asp:Button ID="btnCerrar" runat="server" Text="Salir" Height="26px" Width="57px"
                    OnClick="btnCerrar_Click" />
                <asp:ConfirmButtonExtender ID="btnCerrar_ConfirmButtonExtender" runat="server" ConfirmText="Desea cerrar?"
                    Enabled="True" TargetControlID="btnCerrar">
                </asp:ConfirmButtonExtender>
                <%--<form id="form2" runat="server">--%>
            </td>
        </tr>
        </table>
           </ContentTemplate>
    </asp:UpdatePanel>
    <table class="style35">
        <tr>
            <td class="style46">
                <asp:ObjectDataSource ID="ObjectDataSourceTipoModOp" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseModusOperandi"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.AutoresIgnorados.Bll.NNClaseModusOperandiManager" UpdateMethod="Save">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsTipoAgresion" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseAgresion"
                    DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseAgresionManager"
                    UpdateMethod="Save"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSourceVidrios" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseVidrioVehiculo"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.AutoresIgnorados.Bll.NNClaseVidrioVehiculoManager" UpdateMethod="Save">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMiembroAgredido" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseZonaCuerpoLesionada"
                    DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseZonaCuerpoLesionadaManager"
                    UpdateMethod="Save"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsPartido" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.Partido"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.AutoresIgnorados.Bll.PartidoManager" UpdateMethod="Save"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsLugaresTrasladoVictimas" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.LugaresDeTrasladoDeVictimas"
                    InsertMethod="Save" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.AutoresIgnorados.Bll.LugaresDeTrasladoDeVictimasManager"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsVehiculos" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.Vehiculos"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.AutoresIgnorados.Bll.VehiculosManager" UpdateMethod="Save">
                    <UpdateParameters>
                        <asp:Parameter Name="myVehiculos" Type="Object" />
                        <asp:Parameter Name="myCommand" Type="Object" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsProvincia" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Provincia"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.SIAC.Bll.ProvinciaManager" UpdateMethod="Save"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSourceModoArribo" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseModoArriboHuida"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.AutoresIgnorados.Bll.NNClaseModoArriboHuidaManager" 
                    UpdateMethod="Save" InsertMethod="Save">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsDepartamento" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.SIAC.Bll.DepartamentoManager" UpdateMethod="Save">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSourceTipoArma" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseArma"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.AutoresIgnorados.Bll.NNClaseArmaManager" UpdateMethod="Save">
                </asp:ObjectDataSource>
                 <%--<asp:ObjectDataSource ID="ObjectDataSourceClaseRubro" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRubro"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetListByidClaseLugar" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRubroManager"
                        UpdateMethod="Save">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlTipoArma" Name="idClaseArma" 
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                 </asp:ObjectDataSource>--%>
                <asp:ObjectDataSource ID="ObjectDataSourceSubTipoARma" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseSubtipoArma"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetListByidTipoArma"
                    TypeName="MPBA.AutoresIgnorados.Bll.NNClaseSubtipoArmaManager" UpdateMethod="Save">
                    <SelectParameters>
                            <asp:ControlParameter ControlID="ddlArmaUtilizada" Name="idClaseArma" 
                                PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsClaseBoolean" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseBoolean"
                    DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseBooleanManager"
                    UpdateMethod="Save"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsMarcaVehiculo" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.MarcaVehiculo"
                    DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.MarcaVehiculoManager"
                    UpdateMethod="Save"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsColorVehiculo" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.SIAC.ColorVehiculo"
                    DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.ColorVehiculoManager"
                    UpdateMethod="Save"></asp:ObjectDataSource>
            </td>
            </tr>
            </table>
   
        <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlVehiculos" runat="server" DefaultButton="btnAceptarVehiculo" 
                    CssClass="FondoModal" Width="350px">
                    <div>
                        <div id="divHeaderVehiculos" class="ModalHeader">
                            DATOS DEL VEHICULO</div>
                        <div style="height: 250px; position: relative; overflow: auto;">
                            <asp:UpdatePanel ID="upLugarTraslado1" runat="server">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td class="style59">
                                            </td>
                                            <td>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="style59">
                                                <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlMarcaVehiculo" runat="server" AutoPostBack="True" DataSourceID="odsMarcaVehiculo"
                                                    DataTextField="Descripcion" DataValueField="id" Height="22px" Width="105px" OnSelectedIndexChanged="ddlMarcaVehiculo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="style59">
                                                <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlModeloVehiculo" runat="server" DataTextField="Descripcion"
                                                    DataValueField="id" Height="22px" Width="105px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="style59">
                                                <asp:Label ID="lblColor" runat="server" Text="Color"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlColorVehiculo" runat="server" DataSourceID="odsColorVehiculo"
                                                    DataTextField="Descripcion" DataValueField="id" Height="22px" Width="105px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="style59">
                                                <asp:Label ID="lblVidrios" runat="server" Text="Vidrios"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlVidrios" runat="server" DataSourceID="ObjectDataSourceVidrios"
                                                    DataTextField="descripcion" DataValueField="id" Width="105px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="style59">
                                                <asp:Label ID="lblPatente" runat="server" Text="Patente"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDominio" runat="server" Width="56px"></asp:TextBox>
                                                <br>
                                                
                                                <asp:Label ID="Label6" runat="server" 
                                                     Text="Ej: ABC123" Font-Italic="True" Font-Size="X-Small"></asp:Label>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                             <td align="left" class="style59">
                                             </td>
                                             <td align="left">
                                                 
                                             </td>
                                         <tr>--%>
                                        <tr>
                                            <td align="left" class="style59">
                                                <asp:Label ID="lblAnio" runat="server" Text="Año"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAnio" runat="server" Width="56px"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="txtAnio_MaskedEditExtender" runat="server" 
                                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                    Mask="9999" MaskType="Number" TargetControlID="txtAnio">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <tr>
                                                <td align="left" class="style59">
                                                    <asp:Label ID="lblChasis" runat="server" Text="Nro. Chasis"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtChasis" runat="server" Width="134px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style59">
                                                    <asp:Label ID="lblMotor" runat="server" Text="Nro. Motor"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMotor" runat="server" Width="134px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style59">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="padding-top: 10px; position: relative;">
                            <table width="100%">
                                <tr style="text-align: center">
                                    <td>
                                        <asp:Button ID="btnAceptarVehiculo" runat="server" CausesValidation="False" OnClick="btnAceptarVehiculo_Click"
                                            Text="Aceptar" UseSubmitBehavior="False" Width="50px" Height="22px" />
                                        <asp:Button ID="btnCancelarVehiculo" runat="server" CausesValidation="False" Text="Cancelar"
                                            UseSubmitBehavior="False" Width="50px" 
                                             />
                                        <br />
                                        <asp:HiddenField ID="hfVehiculos" runat="server" />
                                        <asp:HiddenField ID="hfAbrirPanelVehiculos" runat="server" />
                                        <asp:ModalPopupExtender ID="hfVehiculosExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlVehiculos"
                                            TargetControlID="hfAbrirPanelVehiculos" CancelControlID="btnCancelarVehiculo"
                                            OkControlID="hfVehiculos" RepositionMode="None" Drag="True" PopupDragHandleControlID="divHeaderVehiculos">
                                        </asp:ModalPopupExtender>
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
                <br />
                <br />
                <asp:Panel ID="pnlLugar" runat="server" DefaultButton="btnTraerLugar" CssClass="FondoModal">
                    <div>
                        <div id="divHeaderLocalidad" class="ModalHeader">
                            ELEGIR LOCALIDAD</div>
                        <div style="height: 250px; position: relative; overflow: auto;">
                            <asp:UpdatePanel ID="upLugarTraslado" runat="server">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLugarTraslado" runat="server" Text="Lugar"></asp:Label>
                                                <asp:TextBox ID="txtLugar" runat="server" CausesValidation="True" Width="125px"></asp:TextBox>
                                                <asp:Button ID="btnTraerLugar" runat="server" OnClick="btnTraerLugarTraslado_Click"
                                                    Text="Traer" Width="44px" />
                                                <br />
                                                <asp:Label ID="lblDemasiadosResultados" runat="server" ForeColor="#CC0000" Text="Demasiados resultados, amplie la busqueda"
                                                    Visible="False"></asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                                <asp:GridView ID="gvLugar" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                    OnSelectedIndexChanged="gvLugar_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnElegirLugarTraslado" runat="server" CommandName="Select" Height="19px"
                                                                    Text="Elegir" Width="44px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                                            SortExpression="id" Visible="False" />
                                                        <asp:BoundField DataField="localidad" HeaderText="localidad" SortExpression="localidad" />
                                                        <asp:TemplateField HeaderText="Partido" SortExpression="Partido">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPartidoGrid" runat="server" Text='<%# MPBA.SIAC.Bll.PartidoManager.GetItem(Convert.ToInt32(Eval("partido").ToString())).partido %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CodigoPostal" HeaderText="CodigoPostal" SortExpression="CodigoPostal" />
                                                        <asp:TemplateField HeaderText="Provincia" SortExpression="Provincia">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProvinciaGrid" runat="server" Text='<%# MPBA.SIAC.Bll.ProvinciaManager.GetItem(Convert.ToInt32(Eval("Provincia").ToString())).provincia %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="padding-top: 10px; position: relative;">
                            <table width="100%">
                                <tr style="text-align: center">
                                    <td>
                                        <asp:Button ID="btnCancelarLugar" runat="server" CausesValidation="False" OnClick="btnCancelarLugar_Click"
                                            Text="Cerrar" UseSubmitBehavior="False" Width="50px" />
                                        <br />
                                        <asp:HiddenField ID="hfLugar" runat="server" />
                                        <asp:HiddenField ID="hfAbrirLugar" runat="server" />
                                        <asp:ModalPopupExtender ID="hfAbrirLugar_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlLugar"
                                            TargetControlID="hfAbrirLugar" CancelControlID="btnCancelarLugar" OkControlID="hfLugar"
                                            RepositionMode="None" Drag="True" PopupDragHandleControlID="divHeaderLocalidad">
                                        </asp:ModalPopupExtender>
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
            </td>
            <td>
                <asp:Panel ID="pnlComisariasL" runat="server" CssClass="FondoModal">
                    <div>
                        <div id="divHeaderComisaria" class="ModalHeader">
                            ELEGIR COMISARIA</div>
                        <div style="height: 250px; position: relative; overflow: auto;">
                            <asp:UpdatePanel ID="upLugarTraslado0" runat="server">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDepartamento" runat="server" Text="Departamento"></asp:Label>
                                                <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" DataSourceID="odsDepartamento"
                                                    DataTextField="departamento" DataValueField="Id" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <br />
                                                <asp:GridView ID="gvComisariasL" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                    OnSelectedIndexChanged="gvComisariasL_SelectedIndexChanged" Height="156px" PageSize="4"
                                                    Width="400px">
                                                    <Columns>
                                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
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
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="gvLugarTraslado" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div style="padding-top: 10px; position: relative;">
                            <table width="100%">
                                <tr style="text-align: center">
                                    <td>
                                        <asp:Button ID="btnCancelarComisariaL" runat="server" CausesValidation="False" OnClick="btnCancelarComisariaL_Click"
                                            Text="Cerrar" UseSubmitBehavior="False" Width="50px" Height="22px" />
                                        <br />
                                        <asp:HiddenField ID="hfComisariaL" runat="server" />
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
                <asp:Panel ID="pnlPartido" runat="server" CssClass="FondoModal" Width="366px" 
                    DefaultButton="btnTraerPartido">
                    <div>
                        <div id="divHeaderPartido" class="ModalHeader">
                            ELEGIR PARTIDO</div>
                        <div style="height: 250px; position: relative; overflow: auto;">
                            <asp:UpdatePanel ID="upLugarTraslado2" runat="server">
                                <ContentTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPartido" runat="server" Text="Partido"></asp:Label>
                                                <asp:TextBox ID="txtPartido" runat="server" CausesValidation="True" Width="125px"></asp:TextBox>
                                                <asp:Button ID="btnTraerPartido" runat="server" OnClick="btnTraerPartido_Click" Text="Traer"
                                                    Width="44px" />
                                                <br />
                                                <asp:Label ID="lblDemasiadosPartidos" runat="server" ForeColor="#CC0000" Text="Demasiados resultados, amplie la busqueda"
                                                    Visible="False"></asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                                <asp:GridView ID="gvPartidos" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                                    OnSelectedIndexChanged="gvPartidos_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnElegirPartido" runat="server" CausesValidation="False" CommandName="Select"
                                                                    Height="18px" Text="Elegir" Width="41px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="partido" HeaderText="Partido" SortExpression="partido" />
                                                        <asp:TemplateField HeaderText="Provincia" SortExpression="idProvincia">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idProvincia") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("idProvincia") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="padding-top: 10px; position: relative;">
                            <table width="100%">
                                <tr style="text-align: center">
                                    <td>
                                        <asp:Button ID="btnCancelarPartido" runat="server" CausesValidation="False" OnClick="btnCancelarPartido_Click"
                                            Text="Cerrar" UseSubmitBehavior="False" Width="50px" />
                                        <br />
                                        <asp:HiddenField ID="hfPartido" runat="server" />
                                        <asp:HiddenField ID="hfAbrirPartido" runat="server" />
                                        <asp:ModalPopupExtender ID="hfAbrirPartido_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
                                            CancelControlID="btnCancelarPartido" Drag="True" DropShadow="True" DynamicServicePath=""
                                            Enabled="True" OkControlID="hfPartido" PopupControlID="pnlPartido" PopupDragHandleControlID="divHeaderPartido"
                                            RepositionMode="None" TargetControlID="hfAbrirPartido">
                                        </asp:ModalPopupExtender>
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
            </td>
        </tr>
    </table>
 
</asp:Content>
