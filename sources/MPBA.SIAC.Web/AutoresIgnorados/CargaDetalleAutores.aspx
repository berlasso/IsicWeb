<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CargaDetalleAutores.aspx.cs" Inherits="MPBA.AutoresIgnorados.Web.CargaDetalleAutores" %>

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
            height: 842px;
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
            height: 406px;
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
        .style49
        {
            height: 101px;
        }
    </style>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="style8">
        <div class="style45" style="border-style: groove; border-color: #800000">
            <table class="style28">
                <tr>
                    <td colspan="5" style="border-width: thin; border-bottom-style: solid; background-color: #FFFFFF;">
                        <asp:Label ID="lblAutores" runat="server" Font-Bold="True" Font-Size="Large" Text="Autores"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        <asp:Label ID="lblNroAutor" runat="server" Text="Nro. Autor"></asp:Label>
                    </td>
                    <td class="style48">
                        <asp:TextBox ID="txtNroAutor" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        <asp:Label ID="lblEdad" runat="server" Text="Edad Aproximada"></asp:Label>
                    </td>
                    <td class="style48">
                        <asp:DropDownList ID="ddlEdad" runat="server" 
                            DataSourceID="ObjectDataSourceClaseEdad" DataTextField="descripcion" 
                            DataValueField="id">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSourceClaseEdad" runat="server" 
                            DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseEdadAproximada" 
                            DeleteMethod="Delete" InsertMethod="Save" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                            TypeName="MPBA.AutoresIgnorados.BusinessLogic.NNClaseEdadAproximadaManager" 
                            UpdateMethod="Save"></asp:ObjectDataSource>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
                    </td>
                    <td class="style48">
                        <asp:DropDownList ID="ddlSexo" runat="server" 
                            DataSourceID="ObjectDataSourceClaseSexo" DataTextField="descripcion" 
                            DataValueField="id">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSourceClaseSexo" runat="server" 
                            DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseSexo" 
                            DeleteMethod="Delete" InsertMethod="Save" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                            TypeName="MPBA.AutoresIgnorados.BusinessLogic.NNClaseSexoManager" 
                            UpdateMethod="Save"></asp:ObjectDataSource>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        <asp:Label ID="lblRostro" runat="server" Text="Rostro"></asp:Label>
                    </td>
                    <td class="style48">
                        <asp:DropDownList ID="ddlRostro" runat="server" 
                            DataSourceID="ObjectDataSourceClaseRostro" DataTextField="descripcion" 
                            DataValueField="id">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSourceClaseRostro" runat="server" 
                            DataObjectTypeName="MPBA.AutoresIgnorados.BusinessEntities.NNClaseRostro" 
                            DeleteMethod="Delete" InsertMethod="Save" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                            TypeName="MPBA.AutoresIgnorados.BusinessLogic.NNClaseRostroManager" 
                            UpdateMethod="Save"></asp:ObjectDataSource>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblRostroCon" runat="server" Text="con"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRostroCon" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        <asp:Label ID="lblSena" runat="server" Text="Seña Particular"></asp:Label>
                    </td>
                    <td class="style48">
                        <asp:DropDownList ID="ddlSena" runat="server" 
                            DataSourceID="ObjectDataSourceClaseSeniaParticular" DataTextField="descripcion" 
                            DataValueField="id">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSourceClaseSeniaParticular" runat="server" 
                            DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseSeniaParticular" 
                            DeleteMethod="Delete" InsertMethod="Save" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                            TypeName="MPBA.SIAC.BusinessLogic.ClaseSeniaParticularManager" 
                            UpdateMethod="Save"></asp:ObjectDataSource>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style49" colspan="2">
                        <asp:Panel ID="pnlTatuaje" runat="server" GroupingText="Tatuaje" Height="102px">
                            <table class="style35">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLugarCuerpo" runat="server" Text="Lugar del Cuerpo"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList1" runat="server" 
                                            DataSourceID="ObjectDataSourceClaseLugarTatuaje" DataTextField="descripcion" 
                                            DataValueField="id">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSourceClaseLugarTatuaje" runat="server" 
                                            DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseUbicacionSeniaPart" 
                                            DeleteMethod="Delete" InsertMethod="Save" 
                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                                            TypeName="MPBA.SIAC.BusinessLogic.ClaseUbicacionSeniaPartManager" 
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipo" runat="server" 
                                            DataSourceID="ObjectDataSourceClaseTipoTatuaje" DataTextField="descripcion" 
                                            DataValueField="id">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSourceClaseTipoTatuaje" runat="server" 
                                            DataObjectTypeName="MPBA.SIAC.BusinessEntities.ClaseTatuaje" 
                                            DeleteMethod="Delete" InsertMethod="Save" 
                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                                            TypeName="MPBA.SIAC.BusinessLogic.ClaseTatuajeManager" 
                                            UpdateMethod="Save"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOtro" runat="server" Text="Otro"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOtro" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <br />
                    </td>
                    <td class="style49">
                    </td>
                    <td class="style49">
                    </td>
                    <td class="style49">
                    </td>
                </tr>
                <tr>
                    <td class="style30">
                        <asp:Label ID="lblOtraCaracteristica" runat="server" Text="Otra Caracteristica"></asp:Label>
                    </td>
                    <td class="style48">
                        <asp:TextBox ID="txtOtraCaracteristica" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
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
                    <asp:Button ID="lblAceptar" runat="server" Text="Aceptar" />
                    <asp:Button ID="lblCancelar" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>
