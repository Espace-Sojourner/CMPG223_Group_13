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
            if (Session["User"] != null)
            {
                lblWelcome.Text = "Welcome, " + ((User)Session["User"]).First_Name + " " + ((User)Session["User"]).Last_Name;
                //check if user is farmer or not and hide/show buttons accordingly
                if (((User)Session["User"]).UserType == UserType.Farmer)
                {
                    btnManageListings.Visible = true;
                    btnBrowse.Visible = false;
                    btnAddPRoduce.Visible = true;
                }
                else if (((User)Session["User"]).UserType == UserType.Client)
                {
                    btnManageListings.Visible = false;
                    btnBrowse.Visible = true;
                    btnAddPRoduce.Visible = false;
                }
                else if (((User)Session["User"]).UserType == UserType.Admin)
                {
                    btnManageListings.Visible = true;
                    btnBrowse.Visible = true;
                    btnAddPRoduce.Visible = true;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/default.aspx");
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/change-account-details.aspx");
        }

        protected void btnManageListings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/list-produce.aspx");
        }

        protected void btnBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/browse-produce.aspx");
        }

        protected void btnAddPRoduce_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/add-produce.aspx");
        }
    }
}