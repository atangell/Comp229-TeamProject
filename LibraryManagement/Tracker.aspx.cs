using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.Classes;

namespace LibraryManagement
{
    public partial class Tracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //DbManager dbManager = new DbManager();
                //List<Item> items = dbManager.GetItems();
                //lblName.Text = items[0].Name;
                //lblDesc.Text = items[0].ShortDesc;

                isUserId = Convert.ToString(Session["IsUserId"]);
                connectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
                DbManager dbManager = new DbManager();
                List<Item> items = dbManager.GetItems(connectionString);
                rptItemList.DataSource = items;
                rptItemList.DataBind();

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

    }
}