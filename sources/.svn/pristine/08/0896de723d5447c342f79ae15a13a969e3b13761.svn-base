<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EstadPersDesapXFecha.aspx.cs" Inherits="MPBA.SIAC.Web.EstadPersDesapXFecha" %>
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
       
            Cant. de Personas Desaparecidas Por Departamento
    </div>
    </td>
    <td>
    <div align="left" runat="server" id="divCartelPDXDep" style="background-color: #006381; color: #FFFFFF;">
      
            Cant. de Personas Desaparecidas Por Dependencia
    </div>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Chart ID="chrPersDesapXDeptoXFecha" runat="server"  Palette="SeaGreen" DataSourceID="odsPersDesapXDeptoXFecha" 
            >
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
        <asp:Chart ID="chrPersDesapXDepenenciaXFecha" runat="server" Palette="SeaGreen" DataSourceID="odsPersDesapXDependenciaXFecha" 
           >
            <Series>
                <asp:Series Name="Series1" XValueMember="dependencia" YValueMembers="cantidad">
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
    
        <asp:GridView ID="gvPersDesapXDeptoXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="departamento,cantidad" 
            Width="463px" DataSourceID="odsPersDesapXDeptoXFecha" >
            <Columns>
                <asp:BoundField DataField="departamento" HeaderText="departamento" 
                    ReadOnly="True" SortExpression="departamento" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsPersDesapXDeptoXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            
            
            TypeName="MPBA.PersonasBuscadas.Bll.PersDesapCantXDeptoXFechaManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="fechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="fechaHasta" QueryStringField="h" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </td>
    <td>
    
        <asp:GridView ID="gvPersDesapXDependenciaXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="dependencia,cantidad"  
            Width="463px" DataSourceID="odsPersDesapXDependenciaXFecha">
            <Columns>
                <asp:BoundField DataField="dependencia" HeaderText="dependencia" 
                    ReadOnly="True" SortExpression="dependencia" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsPersDesapXDependenciaXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            
            
            TypeName="MPBA.PersonasBuscadas.Bll.PersDesapCantXDependenciaXFechaManager">
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