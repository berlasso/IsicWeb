<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportEstadisticasCargas.aspx.cs" Inherits="MPBA.SIAC.Web.EstadisticasCargas" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 612px; ">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"  
            Font-Size="8pt" Height="" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="" AsyncRendering="false" SizeToReportContent="true">


            <LocalReport ReportPath="Estadisticas\rptListadoIppsXFecha.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsEstadDelitosTodosDeptos" 
                        Name="dsEstadDelitosTotalDepto" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="odsListadoIppsXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.ListadoIppsXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="idDepto" QueryStringField="dpto" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstadDelitosTodosDeptos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.DelitosCantXDependenciaXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="ClaseDelito" QueryStringField="t" 
                    Type="Int32" />
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstadPHTodosDeptos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.PersonasHalladasCantXDependenciaXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstadPDTodosDeptos" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.PersonasDesaparecidasCantXDependenciaXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstadDelitoTotalDepto" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.DelitosCantXDependenciaXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="ClaseDelito" QueryStringField="t" 
                    Type="Int32" />
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstadPersHalladas" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.PersonasHalladasCargasXUsuarioXDependenciaXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstadPersDesap" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.PersonasDesaparecidasCargasXUsuarioXDependenciaXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstadDelitosOperador" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            
            TypeName="MPBA.SIAC.Web.dsEstadisticasDeCargasTableAdapters.DelitosCargasXUsuarioXDependenciaXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
                <asp:QueryStringParameter Name="idClaseDelito" QueryStringField="t" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
