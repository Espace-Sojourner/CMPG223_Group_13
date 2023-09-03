using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting logged in User object from session
            User user = (User)Session["User"];

            //Validating logged in user
            if (user != null)
            {
                lblWelcome.Text = "Welcome, " + user.First_Name + " " + user.Last_Name;
                //Displaying correct buttons according to the UserType of the logged in User
                if (user.isFarmer())
                {
                    btnManageListings.Visible = true;
                    btnBrowse.Visible = false;
                    btnAddPRoduce.Visible = true;
                }
                else //if (user.isClient())
                {
                    btnBrowse.Visible = true;

                    //Validating if user is Admin
                    if (!user.isAdmin())
                    {
                        btnManageListings.Visible = false;
                        btnAddPRoduce.Visible = false;
                    }
                    else
                    {
                        btnManageListings.Visible = true;
                        btnAddPRoduce.Visible = true;
                    }             
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Setting User session object to null and redirecting to login page
            Session["User"] = null;
            Response.Redirect("~/default.aspx");
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            //Redirecting to change account details page
            Response.Redirect("~/change-account-details.aspx");
        }

        protected void btnBrowse_Click(object sender, EventArgs e)
        {
            //Redirecting to browse produce page
            Response.Redirect("~/browse-produce.aspx");
        }

        protected void btnAddPRoduce_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/add-produce.aspx");
        }
    }
}