 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditUsuarioAutorizado.aspx.cs" Inherits="MPBA.SIAC.Web.EditUsuarioAutorizado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="App_UserControl/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="FondoAutoresIgnorados" >
     <asp:UpdatePanel ID="upNombreUsuario" runat="server">
                <ContentTemplate>
<table >
<tr align="left">
<td colspan="5">
<asp:Label ID="lblNuevo" runat="server" Text="NUEVO" Font-Bold="True" 
        ForeColor="#0033CC" Visible="False"></asp:Label>
<asp:Label ID="lblModificando" runat="server" Text="MODIFICANDO" Font-Bold="True" 
        ForeColor="#009900" Visible="False"></asp:Label>
</td>
</tr>
<tr style="height: 20px;">
                <td >
                    <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario" class="Label" ></asp:Label>
                </td>
                <td align="left" >
               
                    <asp:TextBox ID="txtNombreUsuario" runat="server" Width="189px"></asp:TextBox>
                    <asp:Button ID="btnTraerUsuario" runat="server" Text="Traer" 
                        onclick="btnTraerUsuario_Click" />
                    <br />
                    <asp:CustomValidator ID="CVNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" CssClass="Error"
                                ErrorMessage="Debe ingresar un nombre de usuario"></asp:CustomValidator>
                     
                </td>
                <td>
                <asp:Label ID="lblGrupo" runat="server" Text="Grupo" Width="100px" class="Label"></asp:Label>
                </td>
                <td align="left" >
                    <asp:DropDownList ID="ddlGrupo" runat="server"
                    DataSourceID="odsGrupoUsuario" DataTextField="descripcion" DataValueField="id">
                    </asp:DropDownList>
                </td>
                
                <td >
                       
                    </td>
</tr>
<tr style="height: 20px">
<td>
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido" Width="100px" class="Label"></asp:Label>
                </td>
                <td align="left" >
                    <asp:TextBox ID="txtApellido" runat="server" Width="189px"  style="text-align:left" ></asp:TextBox>
                    <asp:Button ID="btnApellidoMpbaABuscar" runat="server" 
                Text="buscar Apellido MPBA" onclick="btnApellidoMpbaABuscar_Click"  />
               
              
                </td>
               
                
                <td >
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="100px"  class="Label"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNombre" runat="server" Width="189px"></asp:TextBox>
                </td>
                <td></td>
</tr>
  <tr>
                <td colspan="5" align="left" valign="top">
                <asp:UpdatePanel ID="upResulApeMpba" runat="server">
                <ContentTemplate>
                  <div id="divResulApeMpba" runat="server" visible="false" style="background-color: #CCCCFF">
                <asp:Label ID="lblResultadosApellidosMpba" runat="server" Text="Apellidos base MPBA"></asp:Label>
                  <asp:TextBox  ID="txtResultadosApellidosMpba" runat="server" 
                Height="95px" ReadOnly="True" TextMode="MultiLine" 
                Width="400px" Font-Size="X-Small" Wrap="False"></asp:TextBox>
                </div>
                </ContentTemplate></asp:UpdatePanel>
                </tr>
<tr style="height: 20px">
                    <td>
                        <asp:Label ID="lblPuntoGestion" runat="server" Text="Punto de Gestión" class="Label" Width="100px" ></asp:Label>
                    </td>
                    <td >
                        <asp:UpdatePanel ID="upPuntoGestion" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblPuntoGestionValor" runat="server" class="Label"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                    <td >
                        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento" class="Label" Width="100px" ></asp:Label>
                    </td>
                    <td> 
                        <asp:UpdatePanel ID="upDepartamento" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblDepartamentoValor" runat="server" class="Label"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                    <td >
                        <asp:ImageButton ID="btnBuscarPuntoGestion" runat="server" AlternateText="+" CommandName=""
                            Height="16px" ImageUrl="~/App_Images/magnify.png" Width="16px" OnClick="btnBuscarPG_Click" />
                   
                    </td>

</tr>
</table>
    
<table width="100%">
<tr>

<td width="25%">
</td>
<td >
<asp:CheckBox ID ="chkActivo" runat ="server" 
        Text = "   Activo                                                                                           " 
        class="Label" style="vertical-align:bottom;" />
        </td>
        <td>
        </td>
        <td>
<asp:CheckBox ID ="chkMandarMail" runat ="server" Text = "Mandar Mail" 
        class="Label" style="vertical-align:bottom;" Checked="True" 
                oncheckedchanged="chkMandarMail_CheckedChanged" />

</td>
<td width="25%">
</td>

</tr>

</table>
<div style="padding-top: 10px; position: relative;">
            <asp:Button ID="btnAceptarUsuario" runat="server" OnClick="btnAceptarUsuario_Click" Text="Aceptar"
                           Height="26px" Width="63px" />
            <asp:Button ID="btnCancelarUsuario" runat="server" Height="26px" Text="Cancelar" CausesValidation="False"
                         OnClick="btnCancelarUsuario_Click" />
                         <asp:Button ID="btnNuevoUsuario" runat="server" Height="26px" 
                Text="Nuevo" CausesValidation="True"
                         OnClick="btnNuevoUsuario_Click" UseSubmitBehavior="True" />
                         <br />
                         <br />
                       
                         <div id="divMailing" runat="server" visible="true" style="background-color: #CCCCFF">
                         <asp:Label ID="lblAsuntoMail" runat="server" Text="Asunto                                                   "></asp:Label>
                         <asp:TextBox ID="txtAsuntoMail" runat="server" Width="391px">Alta de Usuario SIAC</asp:TextBox>
                         <br />
                         <br />
                         <asp:Label ID="lblTextoMial" runat="server" Text="Texto del Mail    "></asp:Label>
                       <asp:TextBox  ID="txtTextoMail"  runat="server" 
                        Height="95px" TextMode="MultiLine" 
                       Width="400px"></asp:TextBox>
                         
                           <br />
                         <asp:Button ID="btnMandarMail" runat="server" Height="26px" 
                Text="Mandar Mail" CausesValidation="True" onclick="btnMandarMail_Click" />
                </div>
                       
                         <br />
                         
</div>
<uc1:MsgBox ID="MsgBoxNoGrabo" runat="server" Visible="False" />
       </ContentTemplate>
                           
                                </asp:UpdatePanel> 
                                <asp:HiddenField ID="hfDependencia" runat="server" />
            <asp:ModalPopupExtender ID="btnBuscarPuntoGestion_ModalPopupExtender" runat="server"
                            BackgroundCssClass="FondoOscuro" CancelControlID="btnCancelarPuntoGestion" DropShadow="True"
                            DynamicServicePath="" Enabled="True" OkControlID="hfPuntoGestion" PopupControlID="pnlPuntoGestion"
                            TargetControlID="hfDependencia" Drag="True" PopupDragHandleControlID="divHeaderPuntoGestion">
              </asp:ModalPopupExtender>
<asp:ObjectDataSource ID="odsGrupoUsuario" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.GrupoUsuario"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.ConfigurationCL.BusinessLogic.GrupoUsuarioManager" UpdateMethod="Save">
                </asp:ObjectDataSource>
                
</div>
<div>
<asp:ObjectDataSource ID="odsDepartamento" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento"
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                    TypeName="MPBA.SIAC.Bll.DepartamentoManager" UpdateMethod="Save">
                </asp:ObjectDataSource>
 <asp:HiddenField ID="hfPuntoGestion" runat="server" />               
<asp:Panel ID="pnlPuntoGestion" runat="server" CssClass="FondoModal" Width="450px" DefaultButton="btnBuscarDep">
                  <div>
                     <div id="divHeaderPuntoGestion" class="ModalHeader">ELEGIR PUNTO DE GESTION</div>
                    <div style="height:250px; position:relative; overflow:auto;">
                    
                    <asp:UpdatePanel ID="upPanelPuntoGestion" runat="server">
                        <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Departamento"></asp:Label>
                                            <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" DataSourceID="odsDepartamento"
                                                DataTextField="departamento" DataValueField="Id" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                        
                                    </tr>
                                  <tr>
                                  <td>
                                        <asp:Label ID="lblDependencia" runat="server" Text="Dependencia"></asp:Label>
                                     </td>
                                     <td>
                                        <asp:TextBox ID="txtDependencia" runat="server" AutoPostBack="True" ></asp:TextBox>
                                                <asp:Button ID="btnBuscarDep" Text="Buscar" runat="server" 
                                             onclick="btnBuscarDep_Click" UseSubmitBehavior="False" />
                                                </td>

                                    </tr>
                                    <tr>
                                    <td colspan="2">
                                  
                                    </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="gvPuntoGestion" runat="server" AutoGenerateColumns="False" 
                                                DataKeyNames="id" Height="156px" 
                                                OnSelectedIndexChanged="gvPuntoGestion_SelectedIndexChanged" PageSize="4" 
                                                Width="400px">
                                                <RowStyle HorizontalAlign="Left" />
                                                <Columns>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                                                                CommandName="Select" Height="18px" Text="Elegir" Width="61px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                                                        ReadOnly="True" SortExpression="id" Visible="False" />
                                                    <asp:BoundField DataField="descripcion" HeaderText="PuntoGestion" 
                                                        SortExpression="descripcion" />
                                                    <asp:BoundField DataField="idDepartamento" HeaderText="idDepartamento" 
                                                        SortExpression="idDepartamento" Visible="False" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                 
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="gvPuntoGestion" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </div>
                     <div style="padding-top: 10px; position: relative;">
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <asp:Button ID="btnCancelarPuntoGestion" runat="server" CausesValidation="False" OnClick="btnCancelarPuntoGestion_Click"
                                    Text="Cancelar" UseSubmitBehavior="False" />
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
</div>

</asp:Content>
