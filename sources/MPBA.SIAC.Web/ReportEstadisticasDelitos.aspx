<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportEstadisticasDelitos.aspx.cs" Inherits="MPBA.SIAC.Web.EstadisticasDelitos" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 1094px">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="rvDelitos" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="" InteractiveDeviceInfos="(Collection)" AsyncRendering="False" y SizeToReportContent="true"
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="">
            <LocalReport ReportPath="Estadisticas\rptEstadDelitosxModusOperandi.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="odsDelitosMO" 
                        Name="dsEstadisticasDelitos" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="odsDelitosMO" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="MPBA.SIAC.Web.dsEstadisticasDelitosTableAdapters.DelitosModusOperandiCargasXDeptoXFechaTableAdapter">
            <SelectParameters>
                <asp:QueryStringParameter Name="FechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="FechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="IdDepartamento" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
