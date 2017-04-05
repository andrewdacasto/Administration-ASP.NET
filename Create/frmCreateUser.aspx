<%@ Page Title="Create Users Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCreateUser.aspx.vb" Inherits="Telling___Administration__ASP.NET_.frmCreateUser" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
        <section class="featured">
                  <div class="create-user">                       
                      <h2 id="create-user-header">Create User</h2>
                      <asp:CreateUserWizard ID="RegisterUserWithRoles" runat="server" BackColor="Black" BorderColor="#FA5C00" BorderStyle="Solid" BorderWidth="3px" ContinueDestinationPageUrl="~/Create/frmCreateUser.aspx" Font-Names="Verdana" Font-Size="Small" ForeColor="#FA5C00" LoginCreatedUser="False" RequireEmail="False" Width="507px">
                          <ContinueButtonStyle BackColor="Black" BorderColor="#FA5C00" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
                          <CreateUserButtonStyle BackColor="#FA5C00" BorderColor="#FA5C00" BorderStyle="Solid" BorderWidth="3px" Font-Names="Verdana" ForeColor="Black" Height="40px" Width="89px" />
                          <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                          <WizardSteps>
                              <asp:CreateUserWizardStep ID="CreateUserWizardStep2" runat="server" EnableTheming="True">
                              </asp:CreateUserWizardStep>
                              <asp:WizardStep ID="SpecifyRolesStep" runat="server" AllowReturn="False" StepType="Step" Title="Specify Roles">
                                  <asp:CheckBoxList ID="Rolelist" runat="server" AutoPostBack="true" />
                              </asp:WizardStep>
                              <asp:CompleteWizardStep ID="CompleteWizardStep2" runat="server">
                              </asp:CompleteWizardStep>
                          </WizardSteps>
                          <HeaderStyle BackColor="#FA5C00" BorderColor="#FA5C00" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                          <NavigationButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
                          <SideBarButtonStyle ForeColor="White" />
                          <SideBarStyle BackColor="#1C5E55" Font-Size="0.9em" VerticalAlign="Top" />
                          <StepStyle BorderWidth="0px" />
                      </asp:CreateUserWizard>
                   </div>
        </section>
    
</asp:Content>