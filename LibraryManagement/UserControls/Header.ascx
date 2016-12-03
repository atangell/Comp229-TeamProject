<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="LibraryManagement.UserControls.Header" %>
<div class="row">
    <div class="banner">
        <div class="banner-left col-lg-10 col-md-10 col-sm-10 col-xs-10">
            <a href="/"><span>BGM Library Management</span></a>
        </div>
        <div class="banner-right col-lg-2 col-md-2 col-sm-2 col-xs-2">
            <asp:LinkButton ID="lnkLogout" Visible="false" class="menuLink" runat="server" Text="Logout" OnClick="lnkLogout_Click"></asp:LinkButton>
            <asp:HyperLink ID="lnkLogin" class="menuLink" runat="server" Text="Login" NavigateUrl="~/Account/Login.aspx"></asp:HyperLink>
            <asp:HyperLink ID="lnkSignup" class="menuLink" runat="server" Text="Signup" NavigateUrl="~/Account/Signup.aspx"></asp:HyperLink>

            
        </div>
        <div class="clear"></div>
    </div>
</div>
<div class="row">
    <div class="header col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <ul>
            <li><a href="/">Home</a></li>
            <li><a href="/tracker.aspx">Tracker</a></li>
            <li><a href="/contact.aspx">Contact</a></li>
        </ul>
    </div>
</div>
