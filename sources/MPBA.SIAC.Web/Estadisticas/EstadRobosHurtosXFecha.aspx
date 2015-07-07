<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EstadRobosHurtosXFecha.aspx.cs" Inherits="MPBA.SIAC.Web.EstadRobosHurtosXFecha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

     <div class="FondoAutoresIgnorados" align="center" style="border-style: groove; border-color: #800000;  height: auto;">
     
    <table>
    <tr>
    <td>
    <div align="left" style="background-color: #006381; color: #FFFFFF;">
       
            Cant. de Robos y Hurtos Por Departamento
    </div>
    </td>
    <td>
    <div align="left" runat="server" id="divCartelRHXDep" style="background-color: #006381; color: #FFFFFF;">
      
            Cant. de Robos y Hurtos Por Dependencia
    </div>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Chart ID="chrRHXDeptoXFecha" runat="server"
            Palette="SeaGreen" DataSourceID="odsDelitosXDeptoXFecha">
            <Series>
                <asp:Series ChartType="Doughnut" Name="Series1" XValueMember="departamento" 
                    YValueMembers="cantidad">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    <br />
    <br />
    <br />
    </td>
    <td>
        <asp:Chart ID="chrRHXDepenenciaXFecha" runat="server" DataSourceID="odsRHXDependenciaXFecha" 
            Palette="SeaGreen">
            <Series>
                <asp:Series Name="Series1" XValueMember="dependencia" 
                    YValueMembers="cantidad">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    <br />
    <br />
    <br />
    </td>
    </tr>
    <tr>
    <td>
        <asp:GridView ID="gvRHXDeptoXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="departamento,cantidad" DataSourceID="odsDelitosXDeptoXFecha" 
            Width="463px">
            <Columns>
                <asp:BoundField DataField="departamento" HeaderText="departamento" 
                    ReadOnly="True" SortExpression="departamento" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsDelitosXDeptoXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="MPBA.AutoresIgnorados.Bll.DelitosCantXDeptoXFechaManager">
            <SelectParameters>
            <asp:QueryStringParameter Name="claseDelito" QueryStringField="t" 
                    Type="Int32" DefaultValue="1" />
                <asp:QueryStringParameter Name="fechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="fechaHasta" QueryStringField="h" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </td>
    <td>
        <asp:GridView ID="gvRHXDependenciaXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="dependencia,cantidad" DataSourceID="odsRHXDependenciaXFecha" 
            Width="463px">
            <Columns>
                <asp:BoundField DataField="dependencia" HeaderText="dependencia" 
                    ReadOnly="True" SortExpression="dependencia" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsRHXDependenciaXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="MPBA.AutoresIgnorados.Bll.DelitosCantXDependenciaXFechaManager">
            <SelectParameters>
            <asp:QueryStringParameter Name="claseDelito" QueryStringField="t" 
                    Type="Int32" DefaultValue="1" />
                <asp:QueryStringParameter Name="fechaDesde" QueryStringField="d" 
                    Type="String" DefaultValue="" />
                <asp:QueryStringParameter Name="fechaHasta" QueryStringField="h" 
                    Type="String" />
                <asp:QueryStringParameter Name="idDepto" QueryStringField="dpto" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </td>
    </tr>
    </table>

    </div>
   </form>
</body>
</html>