<%@ Page Language="C#" Title="Signup" AutoEventWireup="true"  MasterPageFile="~/masterpages/site.master" CodeBehind="Signup.aspx.cs" Inherits="LibraryManagement.Account.Signup" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder">
    <div class="row-body">
        <div class="container">
          <div class="container">
            <div class="loginBlock">
                <asp:TextBox runat="server" required ID="txtEmail" TextMode="Email" placeholder="Email id" class="required txtControl" CausesValidation="True"  />
                <asp:TextBox runat="server" required ID="txtUsername" class="required txtControl" placeholder="Username" CausesValidation="True" />
                <asp:TextBox runat="server" required ID="txtPassword" TextMode="Password" placeholder="Password" CausesValidation="True" class="required txtControl"/>
                <asp:Button runat="server" required class="btnGroup" ID="btnSignup" Text="Sign Up" OnClick="btnSignup_Click" />
            </div>
        </div>  
        </div>
    </div>
</asp:Content>
