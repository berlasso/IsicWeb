<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EstadPersHalladaXFecha.aspx.cs" Inherits="MPBA.SIAC.Web.EstadPersHalladaXFecha" %>
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
       
            Cant. de Personas Halladas Por Departamento
    </div>
    </td>
    <td>
    <div align="left" runat="server" id="divCartelPHXDep" style="background-color: #006381; color: #FFFFFF;">
      
            Cant. de Personas Halladas Por Dependencia
    </div>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Chart ID="chrPersHalladasXDeptoXFecha" runat="server" 
            Palette="SeaGreen" DataSourceID="odsPersHalladaXDeptoXFecha">
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
        <asp:Chart ID="chrPersHalladasXDependenciaXFecha" runat="server" DataSourceID="odsPersHalladaXDependenciaXFecha" 
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
        <asp:GridView ID="gvPersHalladasXDeptoXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="departamento,cantidad" DataSourceID="odsPersHalladaXDeptoXFecha" 
            Width="463px">
            <Columns>
                <asp:BoundField DataField="departamento" HeaderText="departamento" 
                    ReadOnly="True" SortExpression="departamento" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsPersHalladaXDeptoXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="MPBA.PersonasBuscadas.Bll.PersHalladaCantXDeptoXFechaManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="fechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="fechaHasta" QueryStringField="h" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </td>
    <td>
        <asp:GridView ID="gvPersHalladasXDependenciaXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="dependencia,cantidad" DataSourceID="odsPersHalladaXDependenciaXFecha" 
            Width="463px">
            <Columns>
                <asp:BoundField DataField="dependencia" HeaderText="dependencia" 
                    ReadOnly="True" SortExpression="dependencia" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsPersHalladaXDependenciaXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="MPBA.PersonasBuscadas.Bll.PersHalladaCantXDependenciaXFechaManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="fechaDesde" QueryStringField="d" 
                    Type="String" />
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