<%@ Page Language="C#" Title="Tracker" EnableSessionState="True" AutoEventWireup="true" MasterPageFile="~/masterpages/site.master" CodeBehind="Tracker.aspx.cs" Inherits="LibraryManagement.Tracking" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder">
    <div class="row-body">
        <div class="container">
            <%-- <h2>Books</h2>--%>

            <asp:Repeater ID="rptItemList" runat="server" OnItemCommand="rptItemList_ItemCommand" OnItemDataBound="rptItemList_ItemDataBound">
                <ItemTemplate>
                    <div class="itemDetail">
                        <div>
                            <div class="itemImg">
                                <img src="/Assets/wallpaper7.jpg" />
                            </div>
                            <div class="itemDesc">
                                <div>
                                    <asp:Label ID="lblName" runat="server" Text=" - "><%#Eval("Name") %></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblDesc" runat="server" Text=" - "><%#Eval("ShortDesc") %></asp:Label>
                                </div>
                                
                            </div>
                            <div class="itemEdit" id="editBtn">
                                    <asp:LinkButton runat="server" ID="editLink" Visible="false" CommandName="Edit" CommandArgument='<%#Eval("ItemId") %>'>
                                    Edit</asp:LinkButton>

                                </div>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>
        <%-- <div class="container">
            <h2>Music</h2>
        </div>--%>

        <div>
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
                                <span>
                                    <asp:Label ID="currentItemId" class="formInput " runat="server"></asp:Label></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblType">Item Type:</span>
                                <span>
                                    <asp:DropDownList ID="ddlItemType" class="formInput txtName" runat="server" CausesValidation="True">
                                        <asp:ListItem>Book</asp:ListItem>
                                        <asp:ListItem>Music</asp:ListItem>
                                        <asp:ListItem>Games</asp:ListItem>
                                    </asp:DropDownList></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblName">Name:</span>
                                <span>
                                    <asp:TextBox ID="txtName" class="formInput " runat="server" required="required" CausesValidation="True"></asp:TextBox></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblShortDesc">Short Description:</span>
                                <span>
                                    <textarea runat="server" class="formInput " name="txtShortDesc" id="txtShortDesc" /></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblAuthorName">Author Name:</span>
                                <span>
                                    <asp:TextBox class="formInput" runat="server" ID="txtAuthorName" required="required"></asp:TextBox></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblPublisherName">Publisher Name:</span>
                                <span>
                                    <asp:TextBox class="formInput" runat="server" ID="txtPublisherName" required="required" CausesValidation="True"></asp:TextBox></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblIsbn">Isbn/UPC:</span>
                                <span>
                                    <asp:TextBox class="formInput" runat="server" ID="txtIsbn"></asp:TextBox></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblItemPlatform">Item Platform:</span>
                                <span>
                                    <asp:TextBox class="formInput" runat="server" ID="txtItemPlatform"></asp:TextBox></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblStatus">Status:</span>
                                <span>
                                    <asp:DropDownList ID="ddlStatus" class="formInput " runat="server">
                                        <asp:ListItem>Owned</asp:ListItem>
                                        <asp:ListItem>Loaned</asp:ListItem>
                                        <asp:ListItem>Wanted</asp:ListItem>
                                    </asp:DropDownList></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblCompleted">Is Completed:</span>
                                <span>
                                    <asp:DropDownList ID="ddlIsCompleted" class="formInput " runat="server">
                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                        <asp:ListItem Value="false">No</asp:ListItem>
                                    </asp:DropDownList></span>
                            </div>

                            <div>
                                <span class="lblForm" id="lblReview">Review Score:</span>
                                <span>
                                    <asp:TextBox class="formInput" runat="server" ID="txtReview" CausesValidation="True" TextMode="Number"></asp:TextBox></span>
                            </div>
                            <div>
                                <span class="lblForm" id="lblLink">Link:</span>
                                <span>
                                    <asp:TextBox class="formInput" runat="server" ID="txtLink"></asp:TextBox></span>
                            </div>
                            <div class="btnControls">
                                <div>
                                    <asp:Button runat="server" class="btnSaveItem btnGroup" ID="btnSaveItem" Text="Save" OnClick="btnSaveItem_Click" /></div>
                                <div>
                                    <asp:Button runat="server" class="btnDelete btnGroup" Text="Delete" ID="btnDelete" OnClientClick="return confirm('Do you want to delete?')" OnClick="btnDelete_Click" /></div>
                                <div>
                                    <asp:Button runat="server" class="btnCancel btnGroup" Text="Cancel" ID="btnCancel" /></div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

