<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="Telling___Administration__ASP.NET_._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <section class="login-wrapper">
            <div id=Login>

                <asp:Login ID="Login1" runat="server" Class="login-elements" Width="508px" MembershipProvider="DefaultMembershipProvider" DisplayRememberMe="False" BackColor="Black" BorderColor="#FA5C00" BorderPadding="8" BorderStyle="Solid" BorderWidth="3px" EnableTheming="True" Font-Names="Verdana" Font-Size="Small" ForeColor="#FA5C00" Height="155px" TextLayout="TextOnTop">
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <LoginButtonStyle BackColor="#FA5C00" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="3px" Font-Names="Verdana" Font-Size="Small" ForeColor="#000000" />
                    <TextBoxStyle Font-Size="0.8em" />
                    <TitleTextStyle BackColor="#FA5C00" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="25px" />
                </asp:Login>

            </div>            
        </section>
    </section>
</asp:Content>
