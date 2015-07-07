<%@ Page Title="Visualiza Mapa" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    Inherits="MPBA.SIAC.Web.VisualizaMapa" CodeBehind="VisualizaMapa.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

  
<asp:Content ID="Content1" class="heda" ContentPlaceHolderID="head" runat="Server">

<style type="text/css">
        
      v\:*{behavior:url(#default#VML);
                 }
 
 .tablaLegenda
{
    -moz-column-rule-style: dotted; /* Firefox */
    -webkit-column-rule-style: dotted; /* Safari and Chrome */
    -moz-column-gap: 20px; /* Firefox */
    -webkit-column-gap: 20px; /* Safari and Chrome */
    vertical-align:bottom;
    
}

.tablaLegenda, td
{ padding-top: 0.55em;
  padding-bottom:0.25em;
  width: 50em !important;
  vertical-align:top;
  font-family: Arial;
   font-size: 0.85em !important;
}
.tablaLegenda, img
{ 
     margin-left:auto;
     margin-right:auto;   }


    
   
 @media print {
        header * {
            display:none;
            }
            .HeaderMaster{
            display:none;
            }
            .InfoUsuario{
            display:none;
            }
                        
          .grafico{
            display:block;
            margin: 0px;
            padding:0px;
            align:left;
            }
}
.RadMenu ul.rmActive, .RadMenu ul.rmRootGroup {
display: none !important;
}

div
{
    margin-left:0px;
     margin-right:0px;}
   
 .grafico
{  margin-left: 0px;
   padding-left:0px;}
   
 .InfoMapa
{
vertical-align: top; 
text-align: left; 
margin-bottom: 0px;
font-weight:bold;
Color:#13507d;     
font-family: Arial;
font-size: 11px;
} 
</style>

</asp:Content>
<asp:Content ID="Content2" width="100%"  class="man" ContentPlaceHolderID="Main" runat="Server">
<script language="javascript" type"text/javascript">
    function toggleVisibility(newSection) {
        $(".section").not("#" + newSection).hide();
        $("#" + newSection).show();
    }
 

    function getQueryVariable(variable) {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0] == variable) { return pair[1]; }
        }
        return (false);
    }
 
</script>
<script type="text/javascript" src="https://maps.google.com/maps/api/js?sensor=false"></script>
<div id="idPrintArea" class="grafico" bgcolor="White">
 <table>
   <tr>
     <td  align="left">
 <label class="InfoMapa" >Deslice el slider para aumentar o disminuir el zoom</label>       
  <br>
  <label class="InfoMapa">Presione click sobre los marcadores para ver más detalles. Las direcciones que se repiten se señalizan una sola vez.</label>       
  <br>
  <asp:Label ID="lblCantResultados"  class="InfoMapa" runat="server" Text="Resultados Encontrados"></asp:Label>

 
     <cc1:GMap ID="GMap1" class="InfoMapa" runat="server" />
 
 </td>
 </tr>
 </table>
 <br />
   <asp:Button ID="btnOkay" runat="server" Font-Bold="True"  Text="Volver a la Búsqueda"   Width="220px" onclick="btnOkay_Click" Height="22px" />

   <input type="button" value="Imprimir MAPA" size="130px" Height="22px" onclick="javascript:window.print();" />
   <br />
<asp:Panel ID="legenda" runat="server">
   <table border="1"  class="tablaLegenda">
      <tr>
       <td >
        <img src="App_Images/arrebatar.png" alt="punguista" height="20" width="20">
        <p>
         Arrebatador-Punguista
         </p> 
       </td>
      
       <td>
       
          <img src="App_Images/auto.png" alt="Automotores" height="20" width="20">
          <p>   
           Robo-Hurto Automotores
         </p>
        </td>

        
       <td>
          
             <img src="App_Images/banco.png" alt="Automotores" height="20" width="20">
          <p>
              Banco
          </p>
         </td>

         <td>
         
             <img src="App_Images/bicileta.png" alt="Bicileta" height="20" width="20">
         <p>
              Robo-Hurto Bicileta
          </p>
         </td>

           <td >
           
             <img src="App_Images/boqueterosAmarillo.png" alt="Boqueteros" height="20" width="20">
           <p>
            Boqueteros
          </p>
         </td>
         <td >
          
             <img src="App_Images/cables.png" alt="Robo de Cables" height="20" width="20">

             <p>
              Robo Cables
           </p>
         </td>

          <td>
          
             <img src="App_Images/cuatrerismo.png" alt="Cuatrerismo" height="20" width="20">
          <p>
              Cuatrerismo
          </p>
         </td>
         <td >
         
             <img src="App_Images/money.png" alt="Cuatrerismo" height="20" width="20">
         <p>
              Extorsión
          </p>
         </td>
           <td>
           
             <img src="App_Images/hurto.png" alt="Hurto" height="20" width="20">
           <p>
              Hurto
           </p>
         </td>
            <td >
            
                <img src="App_Images/mechera.png" alt="Mechera" height="20" width="20">
            <p>
                Mechera
          </p>
         </td>
          <td >
          
            <img src="App_Images/medidores.png" alt="Medidores" height="20" width="20">
          <p>
            Robo Med.Gas
            </p>
         </td>
            <td>
            
                <img src="App_Images/luces.png" alt="Medidores" height="20" width="20">
            <p>
                Robo Med.Luz
            </p>
         </td>
         <td >
          
                <img src="App_Images/moto.png" alt="Medidores" height="20" width="20">
          <p>
                Robo/Hurto Motos
            </p>
         </td>
           <td >
           
            <img src="App_Images/piratasAsfalto.png" alt="Medidores" height="20" width="20">
           <p  style="white-space:nowrap">
            Piratas del Asfalto
            </p>
          </td>

          <td >
          
            <img src="App_Images/robo.png" alt="Robo" height="20" width="20">
          <p>
            Robo
            </p>
          </td>
          <td >
           
            <img src="App_Images/robosAncianos.png" alt="Robo de Ancianos" height="20" width="20">
           <p>
            Robos de Ancianos
            </p>
          </td>
          
          <td >
          
            <img src="App_Images/entradera2.jpg" alt="Salida Bancaria" height="20" width="20">
          <p>
            Salida Bancaria
            </p>
          </td>

           <td >
           
            <img src="App_Images/secuestro.png" alt="Secuestro" height="20" width="20">
            <p>
            Secuestro
            </p>
          </td>
          <td >
          
            <img src="App_Images/armas.png" alt="Secuestro" height="20" width="20">
          <p style="white-space:nowrap">
            Robo Bandas con Armas
            </p>
          </td>
          <td >
          
            <img src="App_Images/neumaticos.png" alt="Secuestro" height="20" width="20">
          <p>
            Robo de Neumáticos
            </p>
          </td>

          <td >
          
            <img src="App_Images/comercio.png" alt="Entradera" height="20" width="20">
          <p>
            Entradera
            </p>
          </td>
          <td >
          
            <img src="App_Images/googleMarker.png" alt="No define" height="20" width="20">
          <p>
            Sin Dato
            </p>
          </td>
                        
       </tr>
   </table>
  
</asp:Panel>
</div>
</asp:Content>
