<%@ Page Language="C#" Title="Login" AutoEventWireup="true" EnableSessionState="True" MasterPageFile="~/masterpages/site.master" CodeBehind="Login.aspx.cs" Inherits="LibraryManagement.Account.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder">
    <div class="row-body">
        <div class="container">
            <div class="loginBlock">
                <asp:Label ID="lblIsUserExists" Visible="false" runat="server" class="lblIsUserExists"/>
                <asp:Label runat="server" Visible="false" ID="lblErrorMsg" class="error"/>
                <asp:TextBox runat="server" required ID="txtUsername" placeholder="Username" class="txtControl" />
                <asp:TextBox runat="server" required ID="txtPassword" placeholder="Password" TextMode="Password" class="txtControl" />
                <asp:Button runat="server" class="btnGroup" ID="btnLogin" Text="Login"  OnClick="btnLogin_Click" />
            </div>
        </div>

    </div>
</asp:Content>
