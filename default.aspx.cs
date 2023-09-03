using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using static CMPG223_Group_13.User;

namespace CMPG223_Group_13
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Validating User session object
            if (Session["User"] != null)
            {
                //Redirecting to Dashboard page
                Response.Redirect("~/dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            User user = null;
            string email = tbEmail.Text.ToLower();
            string password = tbPassword.Text;

            //Getting correct UserType
            if (rbtnClient.Checked)
            {
                user = getClientByEmail(email);
            }
            else if (rbtnFarmer.Checked)
            {
                user = getFarmerByEmail(email);
            }

            if (user.User_Password == password)
            {
                //Setting User session object
                Session["User"] = user;

                //Redirecting to Dashboard page
                Response.Redirect("~/dashboard.aspx");
            }
            else
            {
                //Showing error and resetting password field
                lblError.Text = "Invalid user information has been entered, try again.";
                tbPassword.Text = "";
                tbPassword.Focus();
            }

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            //Redirecting to Create Account page
            Response.Redirect("~/create-account.aspx");
        }
    }
}