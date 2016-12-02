<%@ Page Title="Home" Language="C#" EnableSessionState="True" MasterPageFile="~/masterpages/site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryManagement.Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder">
    <div class="row-body">
        <div class="container">
            
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="/Assets/musicImg.jpg" class="carouselImage" alt="Music" />
                    </div>

                    <div class="item">
                        <img src="/Assets/wallpaper7.jpg" class="carouselImage" alt="Books" />
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <div class="collSummaryContainer">
                <div class="collSummary">
                    <div>
                        <asp:Label ID="lblCollCount" class="lblCollSummary" runat="server" Text="Number of Items in Collection: "></asp:Label>
                        <asp:Label ID="lblCollCountValue" runat="server" Text="0"></asp:Label>
                    </div>

                    <div>
                        <asp:Label ID="lblRecentAdd" class="lblCollSummary" runat="server" Text="Recent Additions: "></asp:Label>
                        <asp:Label ID="lblRecentAddValue" runat="server" Text=" - "></asp:Label>
                    </div>

                    <div>
                        <asp:Label ID="lblCurrentlyLoaned" class="lblCollSummary" runat="server" Text="Currently Loaned: "></asp:Label>
                        <asp:Label ID="lblCurrentlyLoanedValue" runat="server" Text=" - "></asp:Label>
                    </div>
                </div>
                
                <div class="overlay-div">
                    <div class="blank-div">
                        <div class="popup-div">
                            <h2>Add to Collection</h2>
                            <a>
                                <img id="imgPopupClose" src="/Assets/x-mark-16.png" />
                            </a>
                            <div class="containerStyles">
                                <div>
                                    <span class="lblForm" id="lblId">Id:</span>
                                    <span><asp:TextBox ID="TextBox1"  class="formInput " runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox></span>
                                </div>
                                <div>
                                    <span class="lblForm" id="lblType">Item Type:</span>
                                    <span><asp:DropDownList ID="ddlItemType" class="formInput txtName"  runat="server" CausesValidation="True">
                                                <asp:ListItem>Book</asp:ListItem>
                                                <asp:ListItem>Music</asp:ListItem>
                                                <asp:ListItem>Other</asp:ListItem>
                                          </asp:DropDownList></span>
                                </div>
                                </asp:Content>