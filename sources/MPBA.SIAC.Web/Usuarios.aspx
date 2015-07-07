<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MPBA.SIAC.Web.Usuarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
                 

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="FondoAutoresIgnorados" style="width:990px">
     <table  border="0" width="980px"  >                         
     <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Departamento"></asp:Label>
            <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" DataSourceID="odsDepartamento"
                 DataTextField="departamento" DataValueField="Id" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
            </asp:DropDownList>
         </td>
     </tr>
     <tr align="center">
          <td>
                    
                        <asp:GridView runat="server" DataKeyNames="idUsuario" AutoGenerateColumns="False"
                            OnRowDeleting="gvUsuarios_RowDeleting" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged"
                            EnableTheming="True" ShowFooter="True" ID="gvUsuarios"
                            OnSorting="gvUsuarios_Sorting"
                            EmptyDataText="No hay datos para mostrar"              
                            CellPadding="4"  RowStyle-Height="15px"                                      
                            GridLines="Horizontal" 
                            AllowSorting="False"> 
                            <Columns>
                                <asp:CommandField CancelText="X" DeleteText="Borrar" EditText="Editar" InsertText="Insertar"
                                    NewText="Nuevo" SelectText="Ver"  />
                                <%--<asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonDelet" runat="server" CausesValidation="False" CommandName="Delete"
                                         OnClientClick="return confirm('Desea Eliminar el automotor?');">
                                         <asp:Image ID="imgFolder" runat="server" ImageUrl="~/App_Images/ico_eliminar.png"  Height="15px" />
                                        </asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" 
                                             >
                                             <asp:Image ID="imgFolderEdit" runat="server" ImageUrl="~/App_Images/ico_ver.png"  Height="15px" />

                                                   
                                            </asp:LinkButton>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                <%--<asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                   SortExpression="Id" Visible="False" />--%>
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                <asp:TemplateField HeaderText="Grupo" SortExpression="idGrupoUsuario">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlgrupo" runat="server" DataSourceID="odsGrupo"
                                         DataTextField="Descripcion" DataValueField="id" SelectedValue='<%# Bind("idGrupoUsuario") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrupousuario" runat="server" Text='<%# MPBA.ConfigurationCL.BusinessLogic.GrupoUsuarioManager.GetItem((Eval("idGrupoUsuario").ToString())).Descripcion %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Punto de Gestión" SortExpression="idPuntoGestion">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlPuntoGestion" runat="server" DataSourceID="odsPuntoGestion"
                                            DataTextField="Descripcion" DataValueField="id" SelectedValue='<%# Bind("idPuntoGestion") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPuntoGestion" runat="server" Text='<%# MPBA.SIAC.Bll.PuntoGestionManager.GetItem(Eval("idPuntoGestion").ToString()).Descripcion %>'></asp:Label>
                                        <%--<asp:Label ID="lblPuntoGestion" runat="server" Text='<%# Bind("idPuntoGestion") %>'></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="activo" />
                            </Columns>
                        </asp:GridView>
           </td>
      </tr>
                 <tr>
                    <td>                        
                        
                        <asp:ObjectDataSource ID="odsGrupoUsuario" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.GrupoUsuario"
                            DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                            TypeName="MPBA.ConfigurationCL.BusinessLogic.GrupoUsuarioManager" UpdateMethod="Save">
                        </asp:ObjectDataSource>
                         <asp:ObjectDataSource ID="odsPuntoGestion" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.PuntoGestion"
                             DeleteMethod="Delete" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
                             SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.PuntoGestionManager"
                             UpdateMethod="Save"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsDepartamento" runat="server" DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento"
                                DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" SelectMethod="GetList"
                                TypeName="MPBA.SIAC.Bll.DepartamentoManager" UpdateMethod="Save">
                        </asp:ObjectDataSource>                    
                         
                        
                    </td>
                </tr>
        </table>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" 
                                    onclick="btnNuevoUsuario_Click" />
                                    <asp:Button ID="btnSalir" runat="server" Text="Salir" 
                                    onclick="btnSalir_Click" />

    </div>

</asp:Content>

