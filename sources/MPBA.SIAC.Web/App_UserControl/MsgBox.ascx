<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UserControl_MsgBox" Codebehind="MsgBox.ascx.cs" %>
<script type="text/javascript" >
//Martín Pestaña, muestro el mensaje
alert('<%=Text%>');
</script>
<asp:Label ID="Label1" runat="server" BackColor="#FFFF66" Font-Bold="True" Font-Italic="True"
    Text="MsgBox" Visible="False"></asp:Label>