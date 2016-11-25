using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.Classes;

namespace LibraryManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbManager dbManager = new DbManager();
                int itemCount = dbManager.GetCollectionCount();
                lblCollCountValue.Text = Convert.ToString(itemCount);
                //var itemLoanedCount = dbManager.GetLoanedItemCount();
                //lblCurrentlyLoanedValue.Text = Convert.ToString(itemLoanedCount);
                //var itemRecentlyAdded = dbManager.GetRecentAddition();
                //lblRecentAddValue.Text = Convert.ToString(itemRecentlyAdded.Name);
            }
        }
    }
}