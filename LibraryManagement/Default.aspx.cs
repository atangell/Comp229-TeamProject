﻿using System;
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
            connectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            if (!IsPostBack)
            {
                DbManager dbManager = new DbManager();
                int itemCount = dbManager.GetCollectionCount(connectionString);
                lblCollCountValue.Text = Convert.ToString(itemCount);
                var itemLoanedCount = dbManager.GetLoanedItemCount(connectionString);
                lblCurrentlyLoanedValue.Text = Convert.ToString(itemLoanedCount);
                var itemRecentlyAdded = dbManager.GetRecentAddition(connectionString);
                lblRecentAddValue.Text = Convert.ToString(itemRecentlyAdded.Name);
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