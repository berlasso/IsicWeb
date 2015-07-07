<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Manuales.aspx.cs" Inherits="MPBA.SIAC.Web.Manuales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

<div/>
<div style="text-aLIGN:left;margin-left:30px;" class="FondoAutoresIgnorados">
    <br />
    <asp:GridView ID="GridViewManuales" runat="server" AutoGenerateColumns="False"
                    Width="280px" 
                     AllowSorting="True"  
                      CssClass="Grid" AllowPaging="True" 
                     PageSize="18" EnableModelValidation="True" 
                     
                      >
                    <RowStyle CssClass="GridItem" Height="30px"/>
                    <AlternatingRowStyle CssClass="GridItemAlter" Height="30px"/>                    
                    <HeaderStyle CssClass="HeaderGrillaAlter" Height="30px" HorizontalAlign="Center"  VerticalAlign="Middle"/>                                     
                    <Columns >            
                        <asp:BoundField  HeaderText="Manuales"  DataField="Nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" > 
                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="" >
                          <ItemTemplate>    
                               <a href='<%#Eval("Link")%>' target="_blank" > <img src="App_Images/ico_ver.png" alt="ver" /> </a>                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                    </Columns>       
                </asp:GridView>
                <br />
    <asp:GridView ID="GridViewVideos" runat="server" AutoGenerateColumns="False"
                    Width="280px" 
                     AllowSorting="True"  
                      CssClass="Grid" AllowPaging="True" 
                     PageSize="18" EnableModelValidation="True" 
                     
                      >
                    <RowStyle CssClass="GridItem" Height="30px"/>
                    <AlternatingRowStyle CssClass="GridItemAlter" Height="30px"/>                    
                    <HeaderStyle CssClass="HeaderGrillaAlter" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle"/>                                     
                    <Columns >            
                        <asp:BoundField  HeaderText="Videos"  DataField="Nombre" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" > 
                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="" >
                          <ItemTemplate>    
                               <a href='<%#Eval("Link")%>' target="_blank" > <img src="App_Images/ico_ver.png"  alt="ver" /> </a>                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                    </Columns>       
                </asp:GridView>
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
