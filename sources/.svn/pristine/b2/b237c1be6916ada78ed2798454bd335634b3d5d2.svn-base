<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NavegadorPersonas.aspx.cs" Inherits="MPBA.SIAC.Web.NavegadorPersonas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

<div/>
<style>
    .tituloFotos
    {
        font-family: Arial;
        font-size: 1.3em;
        font-weight: bold;
        color: #268bd2;
        padding: 6px 6px 6px 12px;
        background-color: rgb(207, 208, 224);
        width: 97%;
        height: 21px;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $("#mvcpartial").load("/PBFotos/NavegadorFotosPersonasFiltro");
       
    });
   </script>

<h1 class= "tituloFotos">Visualiza Fotos de Personas buscadas</h1>
<div id="mvcpartial" 
        style="text-aLIGN:left; margin-top:10px;margin-left:10px;padding-left:10px; margin-right:40px; width:100%; height: 30%"  
        class="FondoAutoresIgnorados">
     Cargando la pagina, espere un momento por favor..
</div>  
          

   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
