using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.Classes;


namespace LibraryManagement.Account
{
    public partial class Login : System.Web.UI.Page
    {
        public string userDetail { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            userDetail = Constants.userExistDetail;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string script = "<script type='text/javascript'>alert('success msg');</script>"; 
            DbManager dbmanager = new DbManager();
            Member member = new Member();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            try
            {
                member = dbmanager.IsMember(username, password);
                if (member.UserName != null)
                {
                    lblErrorMsg.Visible = false;

                    Session["IsUserId"] = "true";
                    //ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", script);
                    //ClientScript.RegisterStartupScript(typeof(Page), "a key",
                    //"alert('success');");
                    Response.Redirect("/Default.aspx");

                }
                else
                {

                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Invalid Username or Password";
                    return;
                }
            }
            catch (Exception e)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Something went wrong. Error:" + e.Message;
            }
        }

    }}