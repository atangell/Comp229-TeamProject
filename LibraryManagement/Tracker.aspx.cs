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
                DbManager dbManager = new DbManager();
                List<Item> items = dbManager.GetItems();
                lblName.Text = items[0].Name;
                lblDesc.Text = items[0].ShortDesc;
            }

        }
    }
}