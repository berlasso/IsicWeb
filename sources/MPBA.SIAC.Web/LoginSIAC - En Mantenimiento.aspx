<%@ Page Language="C#" AutoEventWireup="true" Inherits="LoginSIACEnMantenimiento" Codebehind="LoginSIAC - En Mantenimiento.aspx.cs" %>

<%@ Register Src="App_UserControl/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<link id="stylesheet" href="App_Themes/Theme1/styles.css"  rel="stylesheet" type="text/css"  />
<head runat="server">
<title>Sistema de Investigación y Análisis Criminal</title>
<script language="JavaScript" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 175px;
            width: 315px;
        }
        .style2
        {
            width: 315px;
        }
        .style3
        {
            height: 40px;
            width: 315px;
            font-size: xx-small;
        }
    </style>
</head>
<body style="margin-left:0; margin-top:0; margin:0;vertical-align:middle" >
<script type="text/javascript">
//Martín Pestaña: abrir en ventana completa
function completa(){
    if (window.name != "")
    {
        top.window.location = "LoginSiac.aspx";
    }
}

completa();

</script>
<form id="form1" runat="server"
    style=" text-align:center; height:100%;  width:100%; background-image: url('App_Images/Cortes/fdo_estirar.png'); background-repeat:repeat-x; background-position:bottom left;  ">
<%--<div style="height:11%;   ">
</div>--%>
<br />
 <br />
 <br />

<div  style="vertical-align: middle;  height:468px; width:1024px;" >
 
    <br />
    <br />
    <br />
    <table align="center"   style="width: 405px; height: 330px; position:relative; vertical-align:middle;  background-image: url('App_Images/Cortes/log_caja.png'); background-repeat:no-repeat;   "  
        >
       
        <tr>
            <td style="text-align:center; ">     
                <table frame="void"  >
                    <tr>
                        <td class="style1"
                           >
                        
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="text-align:center; color:#565656; font-weight: 700;" 
                            class="style2"  >
                    
                            <br />
                            PAGINA EN MANTENIMIENTO</td>
                    </tr>
                    
                    <tr>
                        <td style="border-width: 0px; text-align:center;" class="style3">
                            REINTENTE MAS TARDE<%--<asp:Label ID="lblSic" runat="server" Text="OK conectado" ForeColor="Green" Visible="False"></asp:Label>--%></td>
                    </tr>                    
                </table>           
            </td>
        </tr>
    </table>    
</div>    
<%--<div style="height:11%">
</div>--%>
    <uc1:MsgBox ID="MsgBox1" runat="server" Visible="False" />     
</form>

</body>
