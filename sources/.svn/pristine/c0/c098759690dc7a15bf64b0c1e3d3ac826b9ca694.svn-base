<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="True" CodeBehind="PreguntasFrecuentes.aspx.cs" Inherits="MPBA.SIAC.Web.PreguntasFrecuentes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<style>
    dt {
color: #268bd2;
font-weight: bold;
cursor: pointer;
margin: 0 0 1em 0;
padding: 0 0 0 20px;
background: url(images/arrow-sprite.png) 0 0 no-repeat;
line-height: 16px;
}
dt:hover {
color: #2aa198;
background-position: 0 -32px;
}
dt.open {
background-position: 0 -64px;
}
dt.open:hover {
background-position: 0 -96px;}

</style>
<script type="text/javascript">
    $(document).ready(function () {
        $('dd').hide();
        $('dt').bind('click', function () {
            $(this).next().toggle('slow');
        });
    });


</script>

<h1 class= "tituloPreguntas">Preguntas Frecuentes</h1>
<div style="text-aLIGN:left; margin-top:30px;margin-left:30px;padding-left:30px; margin-right:10px; width:85%; height: 500px;font-size:1.2em"  class="FondoAutoresIgnorados">
     
<dl>
 
  <% foreach (var pregunta in MPBA.SIAC.Bll.PreguntasFrecuentesManager.GetList())
     {
        int j = pregunta.id;
          %>
     <dt> <%=pregunta.texto%> </dt>
     <dd><p><%=MPBA.SIAC.Bll.PreguntasFrecuentesManager.GetRespuesta(j).texto%></p>
      </dd>
  <%   }  %>
  


</div>
    <br />
    <table style="width: 100%;text-align:center">
            <tr>
                <td style="padding-top: 15px; text-align: left;">
                    <asp:LinkButton ID="btnVolver" runat="server" 
                            CssClass="ButtonBack" Height="26px" 
                                Width="26px"  style="margin-left:20px; margin-right:50px" 
                                CausesValidation="False" PostBackUrl="~/Home.aspx" ></asp:LinkButton>
                </td>        
            </tr>
    </table>  

    <div style="margin-top: 0px">
    
      
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
