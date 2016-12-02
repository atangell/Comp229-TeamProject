using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.Classes;
using System.Configuration;

namespace LibraryManagement
{
    public partial class Default : System.Web.UI.Page
    {
        public string connectionString { get; set; }
        public string isUserId { get; set; }
        public string isLogout { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            isLogout = Request.QueryString["l"];
            if (isLogout != null)
                Session["IsUserId"] = isLogout == "1" ? "false" : "";
            isUserId = Convert.ToString(Session["IsUserId"]);
            btnOpenPopup.Visible = isUserId == "true" ? true : false;
            connectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            if (!IsPostBack)
            {
                DbManager dbManager = new DbManager();
                int itemCount = dbManager.GetCollectionCount(connectionString);
                lblCollCountValue.Text = Convert.ToString(itemCount);
                //var itemLoanedCount = dbManager.GetLoanedItemCount();
                //lblCurrentlyLoanedValue.Text = Convert.ToString(itemLoanedCount);
                //var itemRecentlyAdded = dbManager.GetRecentAddition();
                //lblRecentAddValue.Text = Convert.ToString(itemRecentlyAdded.Name);
            }
        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Item newItem = new Item();
                DbManager dbManager = new DbManager();
                newItem.Name = txtName.Text;
                newItem.ItemType = ddlItemType.SelectedValue;
                newItem.ShortDesc = txtShortDesc.Value;
                newItem.AuthorName = txtAuthorName.Text;
            }
        
}