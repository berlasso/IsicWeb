<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteFormD.aspx.cs" Inherits="MPBA.PersonasBuscadas.Web.ReporteFormD" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="" InteractiveDeviceInfos="(Collection)" AsyncRendering="False" y SizeToReportContent="true"
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="">
            <LocalReport ReportPath="PersonasBuscadas\rptPersonaDesapConExJur.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsDesaparecidas" 
                        Name="PersonasBuscadasDataSet_PersonasDesaparecidasArmadoSelectSingleItem" />
                    <rsweb:ReportDataSource DataSourceId="odsSenasPart" 
                        Name="PersonasBuscadasDataSet_SeniasParticularesArmadoSelectByIdPersonaAndTablaDestino" />
                    <rsweb:ReportDataSource DataSourceId="odsTatuajes" 
                        Name="PersonasBuscadasDataSet_TatuajesArmadoSelectByIppAndTablaDestino" />
                    <rsweb:ReportDataSource DataSourceId="odsFotos" Name="PathFotos" />
                    <rsweb:ReportDataSource DataSourceId="odsExJur" Name="dsExtranaJurisdiccion" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
        
    
        <asp:ObjectDataSource ID="odsFotos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetListByIpp" 
            TypeName="MPBA.PersonasBuscadas.Bll.PBFotosManager" 
            DataObjectTypeName="MPBA.PersonasBuscadas.BusinessEntities.PBFotos" 
            DeleteMethod="Delete" UpdateMethod="Save">
            <SelectParameters>
                <asp:QueryStringParameter Name="ipp" QueryStringField="ipp" Type="String" />
                <asp:Parameter DefaultValue="1" Name="tipoPersona" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:ObjectDataSource>


        <asp:ObjectDataSource ID="odsSenasPart" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"  
            TypeName="MPBA.SIAC.Web.PersonasBuscadas.PersonasBuscadasDataSetTableAdapters.SeniasParticularesArmadoSelectByIdPersonaAndTablaDestinoTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="ipp" QueryStringField="ipp" Type="String" 
                    DefaultValue="" />
                <asp:Parameter Name="IdTablaDestino" Type="Int32" DefaultValue="1" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="odsTatuajes" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.PersonasBuscadas.PersonasBuscadasDataSetTableAdapters.TatuajesPersonaArmadoSelectByIdPersonaAndTablaDestinoTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="Ipp" QueryStringField="ipp" Type="String" />
                <asp:Parameter Name="IdTablaDestino" Type="Int32" DefaultValue="1" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
        
    
        <asp:ObjectDataSource ID="odsDesaparecidas" runat="server" 
            SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.PersonasBuscadas.PersonasBuscadasDataSetTableAdapters.PersonasDesaparecidasArmadoSelectSingleItemTableAdapter" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:QueryStringParameter Name="Ipp" QueryStringField="Ipp" Type="String" />
                <asp:QueryStringParameter Name="esExtJur" QueryStringField="esExJur" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    
        
    
        <asp:ObjectDataSource ID="odsExJur" runat="server" 
            SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.PersonasBuscadas.PersonasBuscadasDataSetTableAdapters.PBCausaExtranaJurisdiccionSelectSingleItemTableAdapter" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:QueryStringParameter Name="Ipp" QueryStringField="Ipp" Type="String" />
                <asp:Parameter DefaultValue="1" Name="idTipoBusqueda" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </form>
</body>
</html>
