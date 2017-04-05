<%@ Page Title="Create Job Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCreateJob.aspx.vb" Inherits="Telling___Administration__ASP.NET_.frmCreateJob" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
        <section class="featured">
                  <div class="create-job-content">                       
                      <h2 id="create-jobs-header">Create Jobs</h2>
                       <table class="create-jobs-table">
                           <tr class="table-content">
                               <td class="auto-style6"></td>
                               <td class="auto-style7"><asp:Label ID="Create_PartNum_lbl" runat="server" Text="Project Name:"></asp:Label> </td>
                               <td class="auto-style8">
                                   <asp:DropDownList ID="DDProjectNo" runat="server" Height="26px" Width="158px" AutoPostBack="True">
                                   </asp:DropDownList>
                               &nbsp;&nbsp;&nbsp; <asp:Label ID="Create_Quantity_lbl1" runat="server" Text="Filter:"></asp:Label>
                                   <asp:TextBox ID="txtProjectName" runat="server" Width="120px" AutoPostBack="True"></asp:TextBox>
                               </td>
                           </tr>
                           <tr class="table-content">
                               <td class="auto-style6"></td>
                               <td class="auto-style7">
                                   <asp:Label ID="Label5" runat="server" Text="Project No."></asp:Label>
                                   <br />
                                   <asp:Label ID="Label6" runat="server" Text="Order No."></asp:Label>
                               </td>
                               <td class="auto-style8"> 
                                   <asp:Label ID="lblProjectNo" runat="server" Width="174px"></asp:Label>
                                   <asp:Label ID="lblProjectNo0" runat="server" Width="89px">Schedule No.</asp:Label>
                                   <asp:Label ID="lblScheduleNo" runat="server" Width="174px"></asp:Label>
                                   <asp:Label ID="lblOrderNo" runat="server" Width="174px"></asp:Label>
                                   <asp:Label ID="lblProjectNo1" runat="server" Width="89px">Packing List:</asp:Label>
                                   <asp:Label ID="lblPackingList" runat="server"></asp:Label>
                               </td>
                              
                           </tr>
                           <tr>
                               <td class="auto-style9"></td>
                               <td class="auto-style10"><asp:Label ID="Create_Quantity_lbl0" runat="server" Text="Part No:"></asp:Label></td>
                               <td class="auto-style11">
                                   <asp:DropDownList ID="txtPartNum" runat="server" Height="26px" Width="158px" AutoPostBack="True">
                                   </asp:DropDownList>
                               &nbsp;&nbsp;&nbsp; <asp:Label ID="Create_Quantity_lbl2" runat="server" Text="Filter:"></asp:Label> 
                                   <asp:TextBox ID="txtPartNo" runat="server" Width="120px" AutoPostBack="True"></asp:TextBox>
                               </td>                              
                           </tr>
                           <tr>
                               <td class="auto-style9"></td>
                               <td class="auto-style10"><asp:Label ID="Create_Quantity_lbl" runat="server" Text="Quantity:"></asp:Label></td>
                               <td class="auto-style11">
                                   <asp:TextBox ID="txtQuantity" runat="server" Width="150px"></asp:TextBox>
                               </td>                              
                           </tr>
                           <tr>
                               <td class="auto-style9"></td>
                               <td class="auto-style10">
                                   <asp:Label ID="Label2" runat="server" Text="Phase/Block"></asp:Label>
                               </td>
                               <td class="auto-style11">
                                   <asp:TextBox ID="txtPhase" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                               </td>                              
                           </tr>
                           <tr>
                               <td class="auto-style9"></td>
                               <td class="auto-style10">
                                   <asp:Label ID="Label1" runat="server" Text="Level:"></asp:Label>
                               </td>
                               <td class="auto-style11">
                                   <asp:TextBox ID="txtLevel" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                               </td>                              
                           </tr>
                           <tr>
                               <td class="auto-style9"></td>
                               <td class="auto-style10">
                                   <asp:Label ID="Label3" runat="server" Text="Pallet Qty:"></asp:Label>
                               </td>
                               <td class="auto-style11">
                                   <asp:TextBox ID="txtPalletQty" runat="server" Width="150px">0</asp:TextBox>
                               </td>                              
                           </tr>
                           <tr class="table-content">
                               <td class="auto-style9"></td>
                               <td class="auto-style10">
                                   <asp:Label ID="Label4" runat="server" Text="Serial No."></asp:Label>
                               </td>
                               <td class="auto-style11">
                                   <asp:TextBox ID="txtSn" runat="server" Enabled="False" Width="150px"></asp:TextBox>
                               </td>                              
                           </tr>
                        </table>                         
                      <br />
                      <asp:GridView ID="dgvCreate_job" runat="server" Width="434px" AutoGenerateColumns="False">
                          <Columns>
                              <asp:BoundField HeaderText="Job Number" />
                              <asp:BoundField HeaderText="Part Number" />
                              <asp:BoundField HeaderText="Quantity" />
                              <asp:BoundField HeaderText="Project" />
                              <asp:ButtonField Text="Edit">
                              <ItemStyle Font-Bold="True" Font-Size="Small" />
                              </asp:ButtonField>
                          </Columns>                          
                      </asp:GridView>
                      <asp:button ID="Create_Job_btn" runat="server" Text="Create Job" />              
                      &nbsp;&nbsp;
                      <asp:Label ID="lblError" runat="server"></asp:Label>
                      <br />
                      <br />
                      <br />
                   </div>
        </section>
    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style6
        {
            height: 26px;
            width: 10px;
        }
        .auto-style7
        {
            width: 91px;
            height: 26px;
        }
        .auto-style8
        {
            height: 26px;
            width: 467px;
        }
        .auto-style9
        {
            height: 25px;
            width: 10px;
        }
        .auto-style10
        {
            width: 91px;
            height: 25px;
        }
        .auto-style11
        {
            height: 25px;
            width: 467px;
        }
    </style>
</asp:Content>
