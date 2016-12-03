using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        public string isUserId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            isUserId = Convert.ToString(Session["IsUserId"]);
            lnkLogout.Visible = isUserId == "true" ? true : false;
            lnkLogin.Visible = isUserId == "true" ? false : true;

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["isUserId"] = "false";

            Session.Clear();
            Response.Redirect("~/Default.aspx?l=1");
            
        }
    }
}