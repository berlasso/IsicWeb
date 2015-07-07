<%@ Page Language="C#" AutoEventWireup="true" Inherits="LoginSIAC" Codebehind="LoginSIAC.aspx.cs" Debug="true" %>

<%@ Register Src="App_UserControl/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<link id="stylesheet" href="App_Themes/Theme1/styles.css"  rel="stylesheet" type="text/css"  />
<head runat="server">
<title>Sistema de Investigación y Análisis Criminal</title>
<script language="JavaScript" type="text/javascript"></script>
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
                        <td  style="height: 175px"
                           >
                        
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="height:30px; border-width: 0px; text-align:center; background-image: url('App_Images/Cortes/log_combo.png'); background-repeat:no-repeat; background-position:center center">                
                            <asp:TextBox ID="tbNombreUsuario" runat="server" Width="175px" 
                                CssClass="ContenidoLogin" BorderWidth="0px" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:center; color:#565656; width:230px; "  >
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Width="80px" class="LabelLogin"
                               ></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="height:30px; width:405px; border-width: 0px; text-align:center; background-image: url('App_Images/Cortes/log_combo.png'); background-repeat:no-repeat; background-position:center center">                
                            <asp:TextBox ID="tbClaveUsuario" runat="server" Width="175px" 
                                TextMode="Password" CssClass="ContenidoLogin" BorderWidth="0px" 
                                MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-width: 0px; text-align:center;  color:#565656;  width:230px;" >
                            <asp:Label ID="Label4" runat="server" Text="Contraseña" CssClass="LabelLogin" 
                                Width="80px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:40px; border-width: 0px; text-align:center;">
                            <asp:ImageButton ID="LBTNIngresar" runat="server" 
                                ImageUrl="~/App_Images/Cortes/log_ingresar.png"
                                    onmouseover="this.src='App_Images/Cortes/log_ingresar.png';"
                                    onmouseout="this.src='App_Images/Cortes/log_ingresar.png';" 
                                    onclick="LBTNIngresar_Click" Height="31" Width="119" />
                                  <%--  <asp:Button ID="btn" runat="server" Text="sic" onclick="btn_Click" />--%>
                                    <br />
                                    <%--<asp:Label ID="lblSic" runat="server" Text="OK conectado" ForeColor="Green" Visible="False"></asp:Label>--%>
                        </td>
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
