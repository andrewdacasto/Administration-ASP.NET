<%@ Page Title="Create Projects Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCreateProject.aspx.vb" Inherits="Telling___Administration__ASP.NET_.frmCreateProject" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
        <section class="featured">
                  <div class="create-projects-content">                      
                      <h2 id="create-projects-header">Create Projects</h2>
                       <table class="create-projects-table">
                           <tr class="table-content">
                               <td class="auto-style1"></td>
                               <td class="auto-style1"><asp:Label ID="Create_Project_Name_lbl" runat="server" Text="Project Name:"></asp:Label></td>
                               <td class="auto-style2"> <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
                                   <asp:Button ID="cmdSearch" runat="server" Text="Search" />
                               </td>
                               
                           </tr>
                           <tr class="table-content">
                               <td></td>
                               <td><asp:Label ID="Create_ProjectPacking_lbl" runat="server" Text="Project Number:"></asp:Label></td>
                               <td class="auto-style3"> <asp:TextBox ID="txtProjectNo" runat="server"  Width="150px"></asp:TextBox></td>
                               
                           </tr>
                           <tr class="table-content">
                               <td class="auto-style1"></td>
                               <td class="auto-style1"><asp:Label ID="Create_ProjectOrder_lbl" runat="server" Text="Project Order Number:"></asp:Label></td>
                               <td class="auto-style2"> <asp:TextBox ID="txtOrderNo" runat="server" Width="150px"></asp:TextBox></td>
                               
                           </tr>
                           <tr class="table-content">
                               <td></td>
                               <td><asp:Label ID="Create_ProjectSchedule_lbl" runat="server" Text="Project Schedule Number:"></asp:Label></td>
                               <td class="auto-style3"><asp:TextBox ID="txtScheduleNumber" runat="server" Width="150px"></asp:TextBox></td>
                               
                           </tr>
                           <tr>
                               <td class="auto-style1"></td>
                               <td class="auto-style1"><asp:Label ID="lblPackList0" runat="server" Text="Pallet Packing List:"></asp:Label></td>
                               <td class="auto-style2"><asp:TextBox ID="txtPackList" runat="server"  Width="150px"></asp:TextBox></td>
                               
                           </tr>
                           <tr class="table-content">
                               <td class="auto-style1"></td>
                               <td class="auto-style1"><asp:Label ID="lblPackList" runat="server" Text="Project Status:"></asp:Label></td>
                               <td class="auto-style2"><asp:Label ID="lblStatus" runat="server" Text="OPEN"></asp:Label></td>
                               
                           </tr>
                        </table>  
                        <asp:button ID="Create_Project_btn" runat="server" Text="Create"/>
                   &nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblError" runat="server"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                        <asp:button ID="Create_Project_btn0" runat="server" Text="Clear"/>
                      <br />
                   </div>
 <p>

        <asp:GridView ID="gvProject" runat="server" Visible="False" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField HeaderText="Project Name" />
                <asp:BoundField HeaderText="Project Number" />
                <asp:BoundField HeaderText="Order Number" />
                <asp:BoundField HeaderText="Schedule Number" />
                <asp:BoundField HeaderText="Packing List" />
                <asp:BoundField HeaderText="Status" />
            </Columns>
        </asp:GridView>

    </p>
                  <p>

                      &nbsp;</p>
        </section>
   
       </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1
        {
            height: 26px;
        }
        .auto-style2
        {
            height: 26px;
            width: 300px;
        }
        .auto-style3
        {
            width: 300px;
        }
    </style>
</asp:Content>
