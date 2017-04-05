<%@ Page Title="Create Parts Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCreatePart.aspx.vb" Inherits="Telling___Administration__ASP.NET_.frmCreatePart" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
        <section class="featured">
                  <div class="create-parts-content">                      
                      <h2 id="create-parts-header">Create Parts</h2>
                       <table class="create-parts-table">
                           <tr class="table-content">
                               <td></td>
                               <td><asp:Label ID="Create_PartNum_lbl" runat="server" Text="Part Number:"></asp:Label> </td>
                               <td><asp:TextBox ID="txtPartNum" runat="server" Width="150px" AutoPostBack="True"></asp:TextBox>&nbsp;&nbsp;
                      <asp:Label ID="lblError0" runat="server"></asp:Label>
                                             
                               </td>                               
                               
                           </tr>
                           <tr>
                               <td class="auto-style1"></td>
                               <td class="auto-style1"><asp:Label ID="Create_PartDesc_lbl1" runat="server" Text="Phase:" Visible="False"></asp:Label></td>
                               <td class="auto-style1"> <asp:TextBox ID="txtPhase" runat="server" Width="150px" Visible="False">0</asp:TextBox></td>
                              
                           </tr>
                           <tr>
                               <td></td>
                               <td><asp:Label ID="Create_PartDesc_lbl2" runat="server" Text="Elevation:" Visible="False"></asp:Label></td>
                               <td> <asp:TextBox ID="txtElevation" runat="server" Width="150px" Visible="False">0</asp:TextBox></td>
                              
                           </tr>
                           <tr>
                               <td></td>
                               <td><asp:Label ID="Create_PartDesc_lbl0" runat="server" Text="Part Description:" Visible="False"></asp:Label></td>
                               <td> <asp:TextBox ID="txtPartDesc" runat="server" Width="150px" Visible="False">0</asp:TextBox></td>
                              
                           </tr>
                           <tr class="table-content">
                               <td></td>
                               <td>&nbsp;</td>
                               <td> &nbsp;</td>
                              
                           </tr>
                        </table>
                      <asp:button ID="Create_Part_btn" runat="server" Text="Create" />
                                             
                   &nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblError" runat="server"></asp:Label>
                                             
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                      <asp:button ID="cmdRemove" runat="server" Text="Remove" Height="26px" Width="65px" />
                                             
                   </div>
        </section>
    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1
        {
            height: 26px;
        }
    </style>
</asp:Content>
