using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.Classes;

namespace LibraryManagement.Account
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                DbManager dbmanager = new DbManager();
                Member member = new Member();
                member.UserName = txtUsername.Text;
                member.Password = txtPassword.Text;
                member.Email = txtEmail.Text;
                int id = dbmanager.AddMember(member);
                if (id > 0)
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Successfully registered. Please login in to continue.";
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Something went wrong. Error:";
                }
            }
            catch (Exception e)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Something went wrong. Error:"+e.Message;
            }
           
        }
    }
}