<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EstadDelitosSexualesXFecha.aspx.cs" Inherits="MPBA.SIAC.Web.EstadDelitosSexualesXFecha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
     <div class="FondoAutoresIgnorados" align="center" style="border-style: groove; border-color: #800000;  height: auto;">
   
    <asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
    <table>
     <tr>
    <td>
    <div align="left" style="background-color: #006381; color: #FFFFFF;">
       
            Cant. de Delitos Sexuales Por Departamento
    </div>
    </td>
    <td>
    <div align="left" runat="server" id="divCartelDSXDep" style="background-color: #006381; color: #FFFFFF;">
      
            Cant. de Delitos Sexuales Por Dependencia
    </div>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Chart ID="chrtDSXDeptoXFecha" runat="server" DataSourceID="odsDSXDeptoXFecha" 
            Palette="SeaGreen">
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
        <asp:Chart ID="chrtDSXDependenciaXFecha" runat="server" DataSourceID="odsDSXDependenciaXFecha" 
            Palette="SeaGreen">
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
        <asp:GridView ID="gvDSXDeptoXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="departamento,cantidad" DataSourceID="odsDSXDeptoXFecha" 
            Width="463px">
            <Columns>
                <asp:BoundField DataField="departamento" HeaderText="departamento" 
                    ReadOnly="True" SortExpression="departamento" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsDSXDeptoXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="MPBA.AutoresIgnorados.Bll.DelitosCantXDeptoXFechaManager">
            <SelectParameters>
            <asp:QueryStringParameter Name="claseDelito" QueryStringField="t" 
                    Type="Int32" DefaultValue="2" />
                <asp:QueryStringParameter Name="fechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="fechaHasta" QueryStringField="h" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </td>
    <td>
        <asp:GridView ID="gvDSXDependenciaXFecha" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="departamento,cantidad" DataSourceID="odsDSXDeptoXFecha" 
            Width="463px">
            <Columns>
                <asp:BoundField DataField="departamento" HeaderText="departamento" 
                    ReadOnly="True" SortExpression="departamento" />
                <asp:BoundField DataField="cantidad" HeaderText="cantidad" 
                    InsertVisible="False" ReadOnly="True" SortExpression="cantidad" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsDSXDependenciaXFecha" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="MPBA.AutoresIgnorados.Bll.DelitosCantXDependenciaXFechaManager">
            <SelectParameters>
            <asp:QueryStringParameter Name="claseDelito" QueryStringField="t" 
                    Type="Int32" DefaultValue="2" />
                <asp:QueryStringParameter Name="fechaDesde" QueryStringField="d" 
                    Type="String" />
                <asp:QueryStringParameter Name="fechaHasta" QueryStringField="h" 
                    Type="String" />
               <asp:QueryStringParameter Name="idDepto" QueryStringField="dpto" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </td>
    </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
   </form>
</body>
</html>