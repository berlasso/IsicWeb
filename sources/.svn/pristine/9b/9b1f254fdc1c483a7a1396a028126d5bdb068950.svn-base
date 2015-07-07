<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="EstadisticasSeleccion.aspx.cs" Inherits="MPBA.SIAC.Web.EstadisticasSeleccion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
       <div class="FondoAutoresIgnorados" style="border-style: groove; border-color: #800000;  height: auto;">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblModulo" Text="Modulo" runat="server"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModulo" runat="server">
                    <asp:ListItem Value="bpd">Personas Desaparecidas</asp:ListItem>
                    <asp:ListItem Value="bph">Personas Halladas</asp:ListItem>
                    <asp:ListItem Value="rh">Robos y Hurtos</asp:ListItem>
                    <asp:ListItem Value="ds">Delitos Sexuales</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
          
            <td>
            <asp:Label ID="lblDepto" runat="server" Text="Departamento Judicial"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="ddlDepto" runat="server" DataSourceID="odsDepto" 
                    DataTextField="departamento" DataValueField="Id" Width="150px"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsDepto" runat="server" 
                    DataObjectTypeName="MPBA.SIAC.BusinessEntities.Departamento" 
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetList" TypeName="MPBA.SIAC.Bll.DepartamentoManager" 
                    UpdateMethod="Save"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFechaDesde" Text="Desde" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFechaDesde"></asp:TextBox>
                <asp:CalendarExtender ID="txtFechaDesde_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtFechaDesde" PopupButtonID="btnCalendarDesde">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:MaskedEditExtender ID="txtFechaDesde_MaskedEditExtender" runat="server" AutoComplete="False"
                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaDesde"
                    MessageValidatorTip="False">
                </asp:MaskedEditExtender>
                <asp:ImageButton ID="btnCalendarDesde" runat="server" Height="16px" ImageUrl="~/App_Images/calendar.png"
                    Width="17px" CausesValidation="False" />
                <asp:MaskedEditValidator ID="mevFechaDesde" runat="server" ControlExtender="txtFechaDesde_MaskedEditExtender"
                    ControlToValidate="txtFechaDesde" EmptyValueMessage="Ingrese una fecha" ErrorMessage="mevFechaDesde"
                    InvalidValueMessage="Fecha incorrecta" IsValidEmpty="False"></asp:MaskedEditValidator>
            </td>
            <td>
                <asp:Label ID="lblFechaHasta" Text="Hasta" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaHasta" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnCalendarHasta" runat="server" Height="16px" ImageUrl="~/App_Images/calendar.png"
                    Width="17px" CausesValidation="False" />
                <asp:CalendarExtender ID="txtFechaHasta_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtFechaHasta" PopupButtonID="btnCalendarHasta">
                </asp:CalendarExtender>
                <asp:MaskedEditExtender ID="txtFechaHasta_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                    Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFechaHasta">
                </asp:MaskedEditExtender>
                <asp:MaskedEditValidator ID="mevFechaHasta" runat="server" ControlExtender="txtFechaHasta_MaskedEditExtender"
                    ControlToValidate="txtFechaHasta" EmptyValueMessage="Ingrese una fecha" ErrorMessage="Fecha incorrecta"
                    InvalidValueMessage="Fecha incorrecta" IsValidEmpty="False" TooltipMessage="Ingrese una fecha"></asp:MaskedEditValidator>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Limpiar" runat="server" ID="btnLimpiar" />
            </td>
            <td>
                <asp:Button Text="Generar" runat="server" ID="btnEstadistica" OnClick="btnEstadistica_Click" />
            </td>
        </tr>
    </table>
      <iframe runat="server" id="ifEstadisticas" height="450px" name="I1" width="100%" 
               visible="True" >                            
                        El explorador no admite los marcos flotantes o no esta configurado actualmente para mostrarlos. 
                    </iframe>      
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
