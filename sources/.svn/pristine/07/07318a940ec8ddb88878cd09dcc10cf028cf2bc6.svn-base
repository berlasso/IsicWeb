<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    Inherits="MPBA.AutoresIgnorados.Web.CargaAutores" CodeBehind="CargaAutores.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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
        .style47
        {
            height: 30px;
        }
        .style48
        {
            width: 152px;
        }
        .style50
        {
            width: 100%;
            border-top-style: solid;
        }
        .style52
        {
            width: 96px;
            height: 8px;
            text-align: left;
        }
        .style57
        {
            width: 96px;
        }
        .style58
        {
            height: 27px;
        }
        .style59
        {
            text-align: left;
        }
        .style60
        {
            height: 4px;
            width: 102px;
            text-align: left;
        }
        .style63
        {
            height: 8px;
            text-align: left;
        }
        .style64
        {
            text-align: left;
            width: 94px;
        }
        .style65
        {
            text-align: left;
            width: 50px;
        }
        .style66
        {
            height: 8px;
            text-align: left;
            width: 57px;
        }
        .style68
        {
            width: 101px;
        }
        .ingreso
          {  padding: 0px 0px 0px 0px; margin-top: 0px; 
        }
    </style>
    <%--<td class="style65">
                        <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                    </td>
                    <td class="style59">
                        <asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox>
                    </td>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="Server">
    <div>
     
        <div class="FondoAutoresIgnorados" style="border-style: groove; border-color: #13507d">
        <div align="left" style="background-color: #13507d; color: #FFFFFF;">
                <h3 id="cartelPrincipal" runat="server" align="center">
                    AUTORES DESCONOCIDOS</h3>
         </div>
      <asp:Image ID="imgCartelVictimas" runat="server" 
            ImageUrl="~/App_Images/cartelAutores.png" Height="50px" Width="858px" />
            <table style="width: 100%">
                <tr>
                    <td style="text-align: left; border-width: thin; border-bottom-style: solid; "
                        class="style68">
                        <asp:Label ID="lblCondicionCarga" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td style="text-align: center; border-width: thin; border-bottom-style: solid; "
                        class="style58">
                        <%--<td class="style65">
                        <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                    </td>
                    <td class="style59">
                        <asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox>
                    </td>--%>
                       
                    </td>
                    
                </tr>
            </table>
          <asp:Panel ID="pnlAutores" runat="server">
            <table class="style28">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                        <%--<td class="style65">
                        <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                    </td>
                    <td class="style59">
                        <asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox>
                    </td>--%>
                        <asp:DropDownList ID="ddlCantidad" runat="server" Width="300px" DataSourceID="odsCantidadAutores"
                            DataTextField="descripcion" DataValueField="id">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                    
                    
 
                     
                   
                    </td>
                    
                    
                </tr>
                <tr>
                    <td align="justify" colspan="2" valign="top">
                    <asp:UpdatePanel ID="upgv" runat="server">
                       <ContentTemplate>     
                       
                        <asp:GridView ID="gvAutores" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                            OnRowDeleting="gvAutores_RowDeleting" OnSelectedIndexChanged="gvAutores_SelectedIndexChanged"
                            EnableTheming="True" ShowFooter="True" 
                            onrowdatabound="gvAutores_RowDataBound">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Update" />
                                        &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="Cancel" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditarGrid" runat="server" CommandName="Select" Text="Editar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Borrar" />
                                        <asp:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" ConfirmText="Desea Borrar?"
                                            Enabled="True" TargetControlID="Button1">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nro" HeaderText="Nro" SortExpression="Nro" />
                                <asp:TemplateField HeaderText="idPersona" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("idPersona") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPersona" runat="server" Text='<%# Bind("idPersona") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombrePersona" runat="server" Text='<%# Eval("idPersona") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApellidoPersona" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Doc. Nro.">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocNroPersona" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apodo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxApodo" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApodoPersona" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edad Aprox." SortExpression="idClaseEdadAproximada">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEdadAproximada1" runat="server" DataSourceID="ObjectDataSourceClaseEdad"
                                            DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Bind("idClaseEdadAproximada") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseEdadAproximadaManager.GetItem(Convert.ToInt32(Eval("idClaseEdadAproximada").ToString())).descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sexo" SortExpression="idClaseSexo">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ObjectDataSourceClaseSexo"
                                            DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Bind("idClaseSexo") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseSexoManager.GetItem(Convert.ToInt32(Eval("idClaseSexo").ToString())).descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rostro" SortExpression="idClaseRostro">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSourceClaseRostro"
                                            DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Bind("idClaseRostro") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# MPBA.AutoresIgnorados.Bll.NNClaseRostroManager.GetItem(Convert.ToInt32(Eval("idClaseRostro").ToString())).descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Cubierto Con" DataField="CubiertoCon" 
                                    SortExpression="CubiertoCon" />
                                                             
                                <asp:BoundField DataField="OtraCaracteristica" HeaderText="OtraCaract." SortExpression="OtraCaracteristica" />
                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                    SortExpression="id" Visible="False" />
                                <asp:BoundField DataField="idDelito" HeaderText="idDelito" SortExpression="idDelito"
                                    Visible="False" />
                                <asp:BoundField DataField="idCausa" HeaderText="idCausa" SortExpression="idCausa"
                                    Visible="False" />
                                <asp:CheckBoxField DataField="Baja" HeaderText="Baja" SortExpression="Baja" Visible="False" />
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="Update" />
                                        &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="Cancel" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnBuscarSIC" runat="server" CommandName="Select" Text="Buscar en el SIC"
                                            Width="100" OnClick="btnBuscarSIC_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                      <br />
                           <asp:UpdateProgress runat="server" ID="upBusquedaSic" DisplayAfter="100">
                                <ProgressTemplate>
                                <asp:Panel ID="pnlWaitingOverlayBusquedaSic" CssClass="" runat="server">
                                    <asp:Panel ID="pnlWaitingBusquedaSic" CssClass="" runat="server">
                                        <asp:Image ID="imgWaitingBusquedaSic" runat="server" 
                                            ImageUrl="~/App_Images/loader.gif" Width="27px" />
                                    </asp:Panel>
                                </asp:Panel>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
                          
                        </ContentTemplate>
                          </asp:UpdatePanel>
                          <asp:Button ID="btnNuevo" runat="server" Text="Agregar" 
                            OnClick="btnNuevo_Click" />
 
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </div>
         <asp:UpdatePanel ID="upBotones" runat="server">
        <ContentTemplate>
        <table width="100%">
        <tr>
        <td>
        </td>
                        <td align="right" class="style47">
                    <asp:Button ID="btnAnterior" runat="server" Height="26px" Text="&lt;  Anterior" 
                                onclick="btnAnterior_Click" Width="75px" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente  &gt;" OnClick="btnSiguiente_Click"
                        Height="26px" Width="75px" />
                    <asp:Button ID="btnCerrar" runat="server" Text="Salir" Height="26px" Width="57px"
                        OnClick="btnCerrar_Click" />
                    <asp:ConfirmButtonExtender ID="btnCerrar_ConfirmButtonExtender" runat="server" ConfirmText="Desea cerrar?"
                        Enabled="True" TargetControlID="btnCerrar">
                    </asp:ConfirmButtonExtender>
                </td>

        </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
        <table class="style35">
            <tr>
                <td class="style46">
                    <asp:ObjectDataSource ID="odsAutores" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.Autores"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.AutoresManager" UpdateMethod="Save">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseSexo" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseSexo"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseSexoManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseEdad" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseEdadAproximada"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseEdadAproximadaManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseRostro" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRostro"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseRostroManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceClaseSeniaParticular" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.SeniasParticularesManager"></asp:ObjectDataSource>
                   
                    
                    <asp:ObjectDataSource ID="odsCantidadAutores" runat="server" DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseCantidadAutores"
                        DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetList" TypeName="MPBA.AutoresIgnorados.Bll.NNClaseCantidadAutoresManager"
                        UpdateMethod="Save"></asp:ObjectDataSource>
                </td>
                <td>
                </td>
            </tr>
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
        </table>
        <asp:Panel ID="pnlCargaAutores" runat="server" CssClass="FondoModal" 
            Width="580px"  DefaultButton="btnAceptar">
            <div>
                <div id="divHeaderAutor" class="ModalHeader">
                    DETALLES DEL AUTOR</div>
                <asp:UpdatePanel ID="upGestionAutor" runat="server">
                    <ContentTemplate>
                        <div style="height: 450px; position: relative; overflow: auto; border-bottom-style: solid; border-bottom-width: thin;">
                            <table class="style50">
                                <tr>
                                    <td colspan="4" style="border-width: thin; border-bottom-style: solid; background-color: #FFFFFF;">
                                        <asp:Label ID="lblAutores0" runat="server" Font-Bold="True" Font-Size="Large" Text="Autores"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style64">
                                        <asp:Label ID="lblNroAutor" runat="server" Text="Nro. Autor"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:TextBox ID="txtNroAutor" CssClass="ctooltip" Tooltip="<%$ Resources:WebResources,juri %>"  runat="server"></asp:TextBox>
                                    </td>
                                    <td class="style65">
                                        &nbsp;
                                    </td>
                                    <td class="style59">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                <td colspan="4">
                   <asp:Panel ID="pnlAutor" runat="server" GroupingText="Autor" HorizontalAlign="Left"
                    Enabled="True" Visible="False">
                    <asp:UpdatePanel ID="upIdentificacionAutor" runat="server">
                    <ContentTemplate>
                     <table width="100%">
                        <tr>
                            <td>
                            <asp:Label runat="server" ID="lblNombreAutor" Text="Nombre"></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox runat="server" ID="txtNombreAutor"></asp:TextBox>
                             <%--<asp:RequiredFieldValidator ID="rfvNombreAutor" runat="server" ControlToValidate="txtNombreAutor"
                                ErrorMessage="Debe ingresar el Nombre" Enabled="False"></asp:RequiredFieldValidator>
                            </td>--%>
                            <td>
                            <asp:Label runat="server" ID="lblApellidoAutor" Text="Apellido"></asp:Label>
                              
                            </td>
                             <td>
                            <asp:TextBox runat="server" ID="txtApellidoAutor"></asp:TextBox>
                            <br />

                            <asp:RequiredFieldValidator ID="rfvApellidoAutor" runat="server" ControlToValidate="txtApellidoAutor"
                                ErrorMessage="Debe ingresar el Apellido" Enabled="False"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            <asp:Label runat="server" ID="lblTipoDniAutor" Visible="False">Tipo Doc.</asp:Label>
                            </td>
                            <td>
                            <asp:ComboBox runat="server" ID="cboTipoDniAutor" Width="50px" Visible="False"></asp:ComboBox>
                            </td>
                            
                            </tr>
                            <tr>
                            <td>
                            <asp:Label ID="lblApodoAutor" runat="server" Text="Apodo"></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox runat="server" ID="txtApodoAutor"></asp:TextBox>
                            </td>


                             <td>
                            <asp:Label runat="server" ID="lblDniAutor" Text="DNI"></asp:Label>
                            </td>
                             <td colspan="3">
                            <asp:TextBox runat="server" ID="txtDniAutor" MaxLength="9"></asp:TextBox>
                            <asp:MaskedEditExtender ID="meDocNroAutor" runat="server" MaskType="Number" 
                                     Mask="999999999" TargetControlID="txtDniAutor" Enabled="False"></asp:MaskedEditExtender>
                                     <br />
                              <asp:RequiredFieldValidator ID="rfvDocNroAutor" runat="server" ControlToValidate="txtDniAutor"
                                ErrorMessage="Debe ingresar el Numero de Documento" Enabled="False"></asp:RequiredFieldValidator>
                                <br />
                                 <asp:CustomValidator ID="cvDniAutor" runat="server" 
                                     ControlToValidate="txtDniAutor" ErrorMessage="Demasiados dígitos">Demasiados dígitos</asp:CustomValidator>
                            </td>
                            </tr>
                            <tr>
                            <td align="right" colspan="4">
                                <asp:Label ID="lblCartelAutorDelSimp" runat="server" Text="Datos traidos del SIMP" ForeColor="Green" Visible="false"></asp:Label>
                                <asp:Button ID="btnVerPersonasSimp" runat="server" Text="Traer del SIMP" 
                                    Visible="false" CausesValidation="False" onclick="btnVerPersonasSimp_Click" /> 
                               
                            </td>
                            </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                    </asp:Panel>
                                </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblEdad" runat="server" Text="Edad Aproximada"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlEdad" runat="server" DataSourceID="ObjectDataSourceClaseEdad"
                                            DataTextField="descripcion" DataValueField="id" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlSexo" runat="server" DataSourceID="ObjectDataSourceClaseSexo"
                                            DataTextField="descripcion" DataValueField="id" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                   <td class="style52">
                                        <asp:Label ID="lblEstatura" runat="server" Text="Estatura"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlEstatura" runat="server" DataSourceID="ObjectDataSourceSICClaseEstatura"
                                            DataTextField="descripcion" DataValueField="id" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblRobustez" runat="server" Text="Robustez"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlRobustez" runat="server" DataSourceID="ObjectDataSourceSICClaseRobustez"
                                            DataTextField="descripcion" DataValueField="id" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblColorPiel" runat="server" Text="Color de Piel"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlColorPiel" runat="server" DataSourceID="ObjectDataSourceSICClaseColorPiel"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblColorOjos" runat="server" Text="Color de Ojos"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlColorOjos" runat="server" DataSourceID="ObjectDataSourceSICClaseColorOjos"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblColorCabello" runat="server" Text="Color de Cabello"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlColorCabello" runat="server" DataSourceID="ObjectDataSourceSICClaseColorCabello"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblTipoCabello" runat="server" Text="Tipo de Cabello"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlTipoCabello" runat="server" DataSourceID="ObjectDataSourceSICClaseTipoCabello"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblTipoCalvicie" runat="server" Text="Calvicie"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlTipoCalvicie" runat="server" DataSourceID="ObjectDataSourceSICClaseTipoCalvicie"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblFormaCara" runat="server" Text="Forma de la Cara"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlFormaCara" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaCara"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblCejasDimensión" runat="server" Text="Dimensión de la Ceja"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlCejasDimension" runat="server" DataSourceID="ObjectDataSourceSICClaseCejasDimension"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblCejasTipo" runat="server" Text="Tipo de la Ceja"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlTipoCeja" runat="server" DataSourceID="ObjectDataSourceSICClaseCejasTipo"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblFormaMenton" runat="server" Text="Forma Del Mentón"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlFormaMenton" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaMenton"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblFormaOreja" runat="server" Text="Forma de la Oreja"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlFormaOreja" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaOreja"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblFormaNariz" runat="server" Text="Forma de la Nariz"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlFormaNariz" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaNariz"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblFormaBoca" runat="server" Text="Forma de la Boca"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlFormaBoca" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaBoca"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblFormaLabioInferior" runat="server" Text="Forma del Labio Inferior"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlFormaLabioInferior" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaLabioInferior"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblFormaLabioSuperior" runat="server" Text="Forma del labio Superior"></asp:Label>
                                    </td>
                                    <td class="style60">
                                         <asp:DropDownList ID="ddlFormaLabioSuperior" runat="server" DataSourceID="ObjectDataSourceSICClaseFormaLabioSuperior"
                                            DataTextField="descripcion" DataValueField="id" Width="100px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style52">
                                        <asp:Label ID="lblRostro" runat="server" Text="Rostro"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlRostro" runat="server" DataSourceID="ObjectDataSourceClaseRostro"
                                            DataTextField="descripcion" DataValueField="id" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlRostro_SelectedIndexChanged" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style64">
                                        <asp:Label ID="lblRostroCon" runat="server" Text="con" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:TextBox ID="txtRostroCon" runat="server" Visible="False" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>

                                
                      <%--          <tr>
                                    <td class="style64">
                                        <asp:Label ID="lblSena" runat="server" Text="Seña Particular"></asp:Label>
                                    </td> </tr> --%>

                 <tr>
                  <td align="left" colspan="3">
                            <asp:Label ID="lblSeniaParticularD" runat="server">Señas Particulares</asp:Label>
                                        
                       
                            <asp:GridView ID="gvSenasPartD" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                OnRowCancelingEdit="gvSenasPart_RowCancelingEdit" OnRowDeleting="gvSenasPart_RowDeleting"
                                OnRowEditing="gvSenasPart_RowEditing" OnRowUpdating="gvSenasPart_RowUpdating"
                                ShowFooter="True" BorderColor="Black">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                                        SortExpression="id" Visible="False" />
                                    <asp:BoundField DataField="idAutor" HeaderText="idAutor"  SortExpression="idAutor"
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
                                            <asp:TextBox ID="descripcionSenaPart" CssClass="ingreso" runat="server" Text='<%# Eval("Descripcion") %>'/>
                                         </EditItemTemplate>
                                        <FooterTemplate>
                                           <asp:TextBox CssClass="ingreso" ID="descripcionInsert" runat="server" />
                                       </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2133" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
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
                                                OnClick="btnAgregarSenia_Click" Text="Agregar"></asp:LinkButton>
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
                                                <asp:Label ID="lblDescripion"  CssClass="ingreso" runat="server" Text="Descripción"></asp:Label>
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
                                                <asp:TextBox ID="descripcionSenaPart" CssClass="ingreso" runat="server" Text='<%# Eval("Descripcion") %>'/>
                                            </td>

                                            <td>
                                                <asp:LinkButton ID="btnSendD" runat="server" CommandArgument="D" CommandName="EmptyInsert"
                                                    OnClick="btnAgregarPrimeraSenia_Click" Text="Agregar" UseSubmitBehavior="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                         <td width="40%" align="left" valign="middle">
                             <asp:CustomValidator ID="cvSenaSinIncorporar" runat="server" 
                                 ErrorMessage="Pulse 'Incorporar' o bien indique 'Seleccionar' tanto en Seña como Ubicación"></asp:CustomValidator>
                        </td>
                  <tr>
                  <td align="left" colspan="3">
                                         
                            <asp:Label ID="lblTatuajesD" runat="server">Tatuajes</asp:Label>
                               <asp:GridView ID="gvTatuajesD" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                OnRowCancelingEdit="gvTatuajes_RowCancelingEdit" OnRowDeleting="gvTatuajes_RowDeleting"
                                OnRowEditing="gvTatuajes_RowEditing" OnRowUpdating="gvTatuajes_RowUpdating" ShowFooter="True"
                                BorderColor="Black">
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
                                            <asp:TextBox ID="descripcionTatuajePart" CssClass="ingreso" runat="server" Text='<%# Eval("Descripcion") %>'/>
                                         </EditItemTemplate>
                                        <FooterTemplate>
                                           <asp:TextBox ID="descripcionTatuajeInsert" CssClass="ingreso" runat="server" />
                                       </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTatuaje" CssClass="ingreso" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
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
                                                OnClick="btnAgregarTatuaje_Click" Text="Agregar"></asp:LinkButton>
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
                                                <asp:DropDownList ID="ddlUbicacionTatuaje" runat="server" DataSourceID="odsUbicacionSeniaParticular"
                                                    DataTextField="Descripcion" DataValueField="Id">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="descripcionTatuajeInsert" CssClass="ingreso" runat="server" />
                                             </td>
                                            <td>
                                                <asp:LinkButton ID="btnSend" runat="server" CommandArgument="D" CommandName="EmptyInsert"
                                                    OnClick="btnAgregarPrimerTatuaje_Click" Text="Agregar" UseSubmitBehavior="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                         <td width="40%" align="left" valign="middle">
                              
                                <asp:CustomValidator ID="cvTatuajeSinIncorporar" runat="server" 
                                    ErrorMessage="Pulse 'Incorporar' o bien indique 'Seleccionar' tanto en Tatuaje como Ubicación"></asp:CustomValidator>
                        </td>
                    </tr>
                                   
                                    <%--   <td class="style60">
                                        <asp:DropDownList ID="ddlSena" runat="server" DataSourceID="ObjectDataSourceClaseSeniaParticular"
                                            DataTextField="descripcion" DataValueField="id">
                                        </asp:DropDownList>
                                    </td> --%>
                                    <%--<td class="style65">
                        <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                    </td>
                    <td class="style59">
                        <asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox>
                    </td>--%>
                                  
                                    <tr>
                                        <td class="style57" style="padding: 3px; text-align: left;">
                                            <asp:Label ID="lblOtraCaracteristica" runat="server" Text="Otra Caracteristica"></asp:Label>
                                        </td>
                                        <td class="style48" style="padding: 3px; text-align: left;">
                                            <asp:TextBox ID="txtOtraCaracteristica" runat="server" Width="120px"></asp:TextBox>
                                        </td>
                                        <td class="style65" style="padding: 3px">
                                            &nbsp;
                                        </td>
                                        <td class="style59" style="padding: 3px">
                                            &nbsp;
                                        </td>
                                    </tr>
                            </table>
                        </div>
                         <asp:Label ID="lblCartelFaltanDatosPersona" runat="server" Text="Debe ingresar al menos Nro. de documento o Apellido" ForeColor="Red" Visible="false"></asp:Label>
                         <br />
                      <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar"
                        Height="26px" Width="63px" />
                                
                        <asp:Button ID="btnCancelar" runat="server" Height="26px" Text="Cancelar"
                        OnClick="btnCancelar_Click" Width="58px" CausesValidation="False" />
                          <asp:UpdateProgress runat="server" ID="upWaitingPersonas" DisplayAfter="100">
                                <ProgressTemplate>
                                    <asp:Panel ID="pnlWaitingOverlayPersonas" CssClass="" runat="server">
                                        <asp:Panel ID="pnlWaitingPersonas" CssClass="" runat="server">
                                            <asp:Image ID="imgWaitingPersonas" runat="server" 
                                                ImageUrl="~/App_Images/loader.gif" Width="27px" />
                                        </asp:Panel>
                                    </asp:Panel>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnCancelarPersonasEncontradas" 
                            EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
             <asp:HiddenField ID="hfGestionPersonasEncontradas" runat="server" />
               <asp:ModalPopupExtender ID="hfGestionPersonasEncontradas_ModalPopupExtender" 
            runat="server" BackgroundCssClass="FondoOscuro"
            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlPersonasEncontradas"
            TargetControlID="hfGestionPersonasEncontradas" 
            CancelControlID="" OkControlID="" Drag="True" 
            PopupDragHandleControlID="divHeaderPersonas" X="50" Y="50">
        </asp:ModalPopupExtender>
                <div style="padding-top: 10px; position: relative;">
               
                       
                    
                </div>
                  <asp:HiddenField ID="hfPersonaElegida" runat="server" />
                    
       

            </div>
        </asp:Panel>
         <asp:HiddenField ID="hfGestionAutor" runat="server" />
                         
                <asp:ModalPopupExtender ID="hfGestionAutor_ModalPopupExtender" 
            runat="server" BackgroundCssClass="FondoOscuro"
                    DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlCargaAutores"
                    TargetControlID="hfGestionAutor" OkControlID="hfAutor"
                    RepositionMode="None" Drag="True" 
                    PopupDragHandleControlID="DivHeaderAutor">
                </asp:ModalPopupExtender>
          <asp:Panel ID="pnlPersonasEncontradas" runat="server" CssClass="FondoModal" 
            Width="450px">
            <div>
                <div id="divHeaderPersonas" class="ModalHeader" runat="server">
                    PERSONAS ENCONTRADAS</div>
                <asp:UpdatePanel ID="upPersonasEcontradas" runat="server">
                    <ContentTemplate>
                        <div style="height: 100px; position: relative; overflow: auto;">
                            <asp:GridView ID="gvPersonasEncontradas" runat="server" 
                                AutoGenerateColumns="False" 
                                onselectedindexchanged="gvPersonasEncontradas_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnElegirPersona" runat="server" CausesValidation="False" 
                                                CommandName="Select" Text="Elegir"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id" SortExpression="id" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                                        SortExpression="Nombre" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                                        SortExpression="Apellido" />
                                    <asp:BoundField DataField="Apodo" HeaderText="Apodo" SortExpression="Apodo" />
                                    <asp:BoundField DataField="DocumentoNumero" HeaderText="DocumentoNumero" 
                                        SortExpression="DocumentoNumero" />
                                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" SortExpression="Sexo" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" 
                                        SortExpression="Direccion" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" 
                                        SortExpression="FechaNacimiento" />
                                    <asp:BoundField DataField="Localidad" HeaderText="Localidad" 
                                        SortExpression="Localidad" />
                                    <asp:BoundField DataField="Padre" HeaderText="Padre" SortExpression="Padre" />
                                    <asp:BoundField DataField="Madre" HeaderText="Madre" SortExpression="Madre" />
                                    <asp:BoundField DataField="Conyuge" HeaderText="Conyuge" 
                                        SortExpression="Conyuge" />
                                    <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
                                    <asp:BoundField DataField="idTipoPersona" 
                                        HeaderText="idTipoPersona" SortExpression="idTipoPersona" 
                                        Visible="False" />
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsPersonas" runat="server" SelectMethod="GetList" 
                                TypeName="MPBA.SIAC.Bll.PersonaManager" 
                                DataObjectTypeName="MPBA.SIAC.BusinessEntities.Persona" DeleteMethod="Delete" 
                                OldValuesParameterFormatString="original_{0}" UpdateMethod="Save">
                                <UpdateParameters>
                                    <asp:Parameter Name="myPersona" Type="Object" />
                                    <asp:Parameter Name="myCommand" Type="Object" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                         
                                               
                        </div>
                        <div style="border-width: 1px; padding-top: 10px; position: relative; top: 0px; left: 0px;
                border-top-style: solid;">
               
               
                <table width="100%">
                    <tr style="text-align: center">
                        <td>
                      <asp:Button ID="btnElegirPersonaEncontrada" runat="server" CausesValidation="False"
                                Text="Alta Nueva" UseSubmitBehavior="False" Width="70px" 
                                onclick="btnElegirPersonaEncontrada_Click" />
                            <asp:Button ID="btnCancelarPersonasEncontradas" runat="server" CausesValidation="False"
                                Text="Cancelar" UseSubmitBehavior="True" Width="70px" 
                                onclick="btnCancelarPersonasEncontradas_Click" />
                            <br />
                        </td>
                      
                    </tr>
                </table>
               
            </div>
                 </ContentTemplate>
                </asp:UpdatePanel>      
                        <div style="padding-top: 10px; position: relative;">
                            <asp:HiddenField ID="hfIdPersonaEncontrada" runat="server" />
                            </div>
                              
                </div>
                </asp:Panel>

        <asp:Panel ID="pnlResultadosDatosSic" runat="server" CssClass="FondoModal" 
            Width="450px" DefaultButton="btnBuscarDelitosSIC">
            <div>
                <div id="DivHeaderResultadosDatosSic" class="ModalHeader">
                    DELITOS EN BASE DEL SIC</div>
                <asp:UpdatePanel ID="upDelitosSIC" runat="server">
                    <ContentTemplate>
                        <div style="height: 250px; position: relative; overflow: auto;">
                            <asp:GridView ID="gvDelitosSIC" runat="server" 
                                onrowdatabound="gvDelitosSIC_RowDataBound" AutoGenerateColumns="False">
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
                            <br />
                            <asp:Label ID="lblNoHayResultadosSic" Text="No se encontraron registros" runat="server"></asp:Label>
                            <br />
                                               
                        </div>
                        <div style="border-width: 1px; padding-top: 10px; position: relative; top: 0px; left: 0px;
                border-top-style: solid;">
                <asp:Label runat="server" ID="lblLimiteResultadosSic" 
                                Text="Solo se muestran los primeros 50 resultados" ForeColor="Red" 
                                Visible="False"></asp:Label>
                  <div align="left" style="border-style: solid; border-width: 1px; background-color: #DFDFFF">
                            <asp:Label ID="lblConsultarSIC" runat="server" Text="Para mayor informacion consultar en WWW.SIC.MPBA.GOV.AR"
                                Font-Size="X-Small"></asp:Label>
                        </div>
                <table width="100%">
                    <tr style="text-align: center">
                        <td>
                            <asp:Button ID="btnCerrarResultadosDatosSic" runat="server" CausesValidation="False"
                                Text="Cerrar" UseSubmitBehavior="False" Width="50px" 
                                onclick="btnCerrarResultadosDatosSic_Click" />
                                
                            <br />
                        </td>
                      
                    </tr>
                </table>
            </div>
                      
                        <div style="padding-top: 10px; position: relative;">
                            
                            </div>
                               </ContentTemplate>
                </asp:UpdatePanel>
                </div>
                </asp:Panel>
                        <asp:Panel ID="pnlServerSicOcupado" runat="server" CssClass="FondoModal" 
        Width="193px">
        <div>
            <div id="divHeaderServerSicOcupado" class="ModalHeader">
                Salir</div>
            <div style="position: relative; overflow: auto;" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel runat="server" ID="upServerSicOcupado" >
                                <ContentTemplate>
                                    <br />
                             <asp:Label ID="lblMensajeServerSicOcupado" runat="server" Text="El servidor esta sobrecargado, reintente en unos instantes." 
                                        Font-Size="Small"></asp:Label>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                  
                 
                </table>
            </div>
            <div style="padding-top: 10px; position: relative;">
            
             
                <asp:Button ID="btnOkServerSicOcupado" runat="server" Text="OK" Width="60px" onclick="btnOkServerSicOcupado_Click" 
                    />
            </div>
        </div>
    </asp:Panel>
      
                <asp:Panel ID="pnlDelitosSIC" runat="server" CssClass="FondoModal" 
            Width="400px">
            
                <div id="DivHeaderDelitosSIC" class="ModalHeader">
                    BUSQUEDA DE DELITOS EN BASE DEL SIC</div> 
                <div>
                <asp:UpdatePanel ID="upBusquedaBaseSic" runat="server">
                <ContentTemplate>
                            <div>
                            <table class="style50">
                                <tr>
                                    <td colspan="4" align="center">
                                      
                          
                                        <asp:Label ID="lblTituloSic" Text="Refinar Búsqueda" runat="server" Font-Underline="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                <td colspan="2">
                                <asp:Panel ID="pnlAutorSic" runat="server" GroupingText="Autor" HorizontalAlign="Left"
                    Enabled="True" Visible="False">
                     <table width="100%">
                        <tr>
                            <td>
                            <asp:Label runat="server" ID="lblNombreBusquedaSic" Text="Nombre"></asp:Label>
                            </td>
                            <td>
                            <asp:TextBox runat="server" ID="txtNombreBusquedaSic"></asp:TextBox>
                            <td>
                            <asp:Label runat="server" ID="lblApellidoBusquedaSic" Text="Apellido"></asp:Label>
                              
                            </td>
                             <td>
                            <asp:TextBox runat="server" ID="txtApellidoBusquedaSic"></asp:TextBox>
 
                            </td>
                            </tr>
                            <tr>
                            <td>
                            
                            </td>
                            <td>
                            
                            </td>
                             <td>
                            <asp:Label runat="server" ID="lblDniBusquedaSic" Text="DNI"></asp:Label>
                            </td>
                             <td>
                            <asp:TextBox runat="server" ID="txtDniBusquedaSic"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtDniBusquedaSic_MaskedEditExtender" runat="server" MaskType="Number" 
                                     Mask="999999999" TargetControlID="txtDniBusquedaSic" Enabled="False"></asp:MaskedEditExtender>
                            </td>
                            </tr>
                            <tr>
                            <td align="right" colspan="4">
                               
                            </td>
                            </tr>
                            </table>
         
                    </asp:Panel>
                                </td>
                                </tr>
                                <tr>
                                <td class="style52">
                                        <asp:Label ID="lblFisGral" runat="server" Text="Fiscalia Gral."></asp:Label>
                                </td>
                                <td class="style60">
                                <asp:DropDownList ID="ddlFisGral" runat="server" DataSourceID="odsFisGral" 
                                        DataTextField="departamento" DataValueField="Id" Width="150px"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsFisGral" runat="server" 
                                        DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento" 
                                        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
                                        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.DepartamentoManager" 
                                        UpdateMethod="Save"></asp:ObjectDataSource>
                                </td>
                                </tr>
                                <tr>

                                    <td class="style52">
                                        <asp:Label ID="lblEdadSic" runat="server" Text="Edad Aproximada"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlEdadSic" runat="server" DataSourceID="ObjectDataSourceClaseEdad"
                                            DataTextField="descripcion" DataValueField="id" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style66">
                                        &nbsp;
                                    </td>
                                    <td class="style63">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style64">
                                        <asp:Label ID="lblSexoSic" runat="server" Text="Sexo"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        <asp:DropDownList ID="ddlSexoSic" runat="server" DataSourceID="ObjectDataSourceClaseSexo"
                                            DataTextField="descripcion" DataValueField="id" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style65">
                                        &nbsp;
                                    </td>
                                    <td class="style59">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style59">
                                        <asp:Label ID="lblTatuajeSic" runat="server" Text="Tatuaje"></asp:Label>
                                    </td>
                                    <td class="style59">
                                        <asp:TextBox ID="txtTatuajeSic" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style57" style="padding: 3px; text-align: left;">
                                        <asp:Label ID="lblLocalidadSic" runat="server" Text="Localidad"></asp:Label>
                                    </td>
                                    <td class="style48" style="padding: 3px; text-align: left;">
                                        <asp:TextBox ID="txtLocalidadSic" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td class="style57" style="padding: 3px; text-align: left;">
                                    </td>
                                    <td class="style48" style="padding: 3px; text-align: left;">
                                    </td>
                                </tr>
                             <tr>
                             <td colspan="4" align="left">
                             <asp:CheckBox ID="chkBuscaPorDatosSomaticos" 
                                     Text="Buscar en registros que tengan cargados los datos somáticos." 
                                     Checked="false" runat="server" AutoPostBack="True" 
                                     oncheckedchanged="chkBuscaPorDatosSomaticos_CheckedChanged" />
                             </td>
                             </tr>
                             <tr>
                             <td colspan="4" align="left">
                                 <div runat="server" id="divDatosSomaticos" visible="false">
                                <%--   <table bgcolor="#F2E0DF" style="border: thin solid #FF0000">--%>
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
                          <asp:UpdateProgress runat="server" ID="upWaitingSic" DisplayAfter="100">
                                <ProgressTemplate>
                                    <asp:Panel ID="pnlWaitingOverlaySic" CssClass="" runat="server">
                                        <asp:Panel ID="pnlWaitingSic" CssClass="" runat="server">
                                            <asp:Image ID="imgWaitingSic" runat="server" ImageUrl="~/App_Images/loader.gif" 
                                                Width="27px" />
                                        </asp:Panel>
                                    </asp:Panel>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:Button ID="btnBuscarDelitosSIC" runat="server" Text="Traer Datos" OnClick="btnBuscarDelitosSIC_Click"
                                UseSubmitBehavior="False" Width="100px" />
                               <asp:Button ID="btnMostrarFotosSic" runat="server" Text="Traer Fotos" Width="100px" 
                                UseSubmitBehavior="False" 
                                onclick="btnMostrarFotosSic_Click" />
                                <br />
                                
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
               
            </div>
            <div style="border-width: 1px; padding-top: 10px; position: relative; top: 0px; left: 0px;
                border-top-style: solid;">
                <table width="100%">
                    <tr style="text-align: center">
                        <td>
                            <asp:Button ID="btnCerrarDelitosSIC" runat="server" CausesValidation="False"
                                Text="Cerrar" UseSubmitBehavior="False" Width="50px" />
                            <br />
                            <asp:HiddenField ID="hfSic" runat="server" />
                            <asp:HiddenField ID="hfResultadosDatosSic" runat="server" />
        <asp:ModalPopupExtender ID="hfResultadosDatosSic_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlResultadosDatosSic"
            TargetControlID="hfResultadosDatosSic"
            RepositionMode="None" Drag="True" PopupDragHandleControlID="DivHeaderResultadosDatosSic">
        </asp:ModalPopupExtender>
       
                        </td>
                        <td align="center">
                        </td>
                        <td>
                         
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfServerSicOcupado" runat="server" />
        <asp:ModalPopupExtender ID="hfServerSicOcupado_ModalPopupExtender" runat="server"
            BackgroundCssClass="FondoOscuro" DropShadow="True" 
        DynamicServicePath="" Enabled="True"
            PopupControlID="pnlServerSicOcupado" TargetControlID="hfServerSicOcupado" Drag="True" 
        PopupDragHandleControlID="DivHeaderServerSicOcupado">
        </asp:ModalPopupExtender>
        <asp:HiddenField ID="hfGestionSIC" runat="server" />
        <asp:HiddenField ID="hfAutor" runat="server" />
        <asp:ModalPopupExtender ID="hfGestionSIC_ModalPopupExtender" runat="server" BackgroundCssClass="FondoOscuro"
            DropShadow="True" DynamicServicePath="" Enabled="True" PopupControlID="pnlDelitosSIC"
            TargetControlID="hfGestionSIC" CancelControlID="btnCerrarDelitosSIC" OkControlID="hfSic"
            RepositionMode="None" Drag="True" PopupDragHandleControlID="DivHeaderDelitosSIC">
        </asp:ModalPopupExtender>
       

    
    </div>
      <asp:ObjectDataSource ID="odsSeniaParticular" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseSeniaParticular"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.ClaseSeniaParticularManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
        
   
    <asp:ObjectDataSource ID="odsUbicacionSeniaParticular" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseUbicacionSeniaPart"
        DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
        TypeName="MPBA.SIAC.Bll.ClaseUbicacionSeniaPartManager" UpdateMethod="Save">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsTatuajesPersona" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetListByidAutor" TypeName="MPBA.SIAC.Bll.TatuajesPersonaManager">
    </asp:ObjectDataSource>

     <asp:ObjectDataSource ID="odsTatuajes" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.ClaseTatuajeManager"
        DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseTatuaje" DeleteMethod="Delete"
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
    
</asp:Content>
