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
            if (Session["User"] != null)
            {
                // send to dashboard
                Response.Redirect("~/dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //check if a radiobutton is selected
            if (rbtnClient.Checked || rbtnFarmer.Checked)
            {
                User user = null;
                string email = tbEmail.Text.ToLower();
                string password = tbPassword.Text;

                //find login type
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
                    Session["User"] = user;

                    // send to dashboard
                    Response.Redirect("~/dashboard.aspx");
                }
                else
                {
                    lblError.Text = "Invalid user info";
                }

            }
            else
            {
                lblError.Text = "Please select a login type";
            }
        }
    }
}