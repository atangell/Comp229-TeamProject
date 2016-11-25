<%@ Page Language="C#" Title="Tracker" AutoEventWireup="true" MasterPageFile="~/masterpages/site.master" CodeBehind="Tracker.aspx.cs" Inherits="LibraryManagement.Tracking" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder">
    <div class="row-body">
        <div class="container">
         <%-- <h2>Books</h2>--%>
            <div class="itemDetail">
                <div class="itemImg">
                    <img src="/Assets/wallpaper7.jpg" />
                </div>
                <div class="itemDesc">
                    <div>
                        <asp:Label ID="lblName" runat="server" Text=" - "></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblDesc" runat="server" Text=" - "></asp:Label>
                    </div>
                </div>
            </div>

        </div>
       <%-- <div class="container">
            <h2>Music</h2>
        </div>--%>
    </div>
</asp:Content>
