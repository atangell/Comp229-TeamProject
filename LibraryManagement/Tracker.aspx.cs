using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.Classes;
using System.Configuration;

namespace LibraryManagement
{
    public partial class Tracking : System.Web.UI.Page
    {
        public string connectionString { get; set; }
        public string isUserId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            isUserId = Convert.ToString(Session["IsUserId"]);
            connectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            DbManager dbManager = new DbManager();
            List<Item> items = dbManager.GetItems(connectionString);
            rptItemList.DataSource = items;
            rptItemList.DataBind();


        }

        protected void rptItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            DbManager dbManager = new DbManager();
            Item item = new Item();
            if (e.CommandName == "Edit")
            {

                int id = Convert.ToInt32(e.CommandArgument);
                item = dbManager.GetItemDetail(id);
                item.ItemId = isUserId == "true" ? item.ItemId : 0;

                currentItemId.Text = Convert.ToString(item.ItemId);
                txtName.Text = item.Name;
                ddlItemType.SelectedValue = item.ItemType;
                txtShortDesc.Value = item.ShortDesc;
                txtAuthorName.Text = item.AuthorName;
                ddlIsCompleted.SelectedValue = Convert.ToString(item.IsCompleted);
                txtIsbn.Text = item.IsbnUpc;
                txtItemPlatform.Text = item.ItemPlatform;
                txtReview.Text = Convert.ToString(item.ReviewScore);
                txtLink.Text = item.Link;
                txtPublisherName.Text = item.PublisherName;
                ddlStatus.SelectedValue = item.ItemStatus;
                ClientScript.RegisterStartupScript(GetType(), "openPopup", "openPopup();", true);
            }
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            DbManager dbManager = new DbManager();
            item.Name = txtName.Text;
            item.ItemType = ddlItemType.SelectedValue;
            item.ShortDesc = txtShortDesc.Value;
            item.AuthorName = txtAuthorName.Text;
            item.IsCompleted = Convert.ToBoolean(ddlIsCompleted.SelectedValue);
            item.IsbnUpc = txtIsbn.Text;
            item.ItemPlatform = txtItemPlatform.Text;
            item.ReviewScore = !String.IsNullOrEmpty(txtReview.Text) ? Convert.ToDouble(txtReview.Text) : 0;
            item.Link = txtLink.Text;
            item.PublisherName = txtPublisherName.Text;
            item.ItemStatus = ddlStatus.SelectedValue;
            dbManager.UpdateItem(item, Convert.ToInt32(currentItemId.Text));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DbManager dbManager = new DbManager();
            dbManager.DeleteItem(Convert.ToInt32(currentItemId.Text));
            Response.Redirect("Tracker.aspx");
        }

        protected void rptItemList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (isUserId == "true")
                ((LinkButton)(e.Item.FindControl("editLink"))).Visible = true;

        }


    }
}