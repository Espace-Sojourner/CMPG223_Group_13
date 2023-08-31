using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public partial class change_account_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChangePassword.Checked)
            {
                lblNewPassword.Visible = true;
                lblOldPassword.Visible = true;
                lblRepeatPassword.Visible = true;

                tbOldPassword.Visible = true;
                tbNewPassword.Visible = true;
                tbConfirmNewPassword.Visible = true;
            }
            else
            {
                lblNewPassword.Visible = false;
                lblOldPassword.Visible = false;
                lblRepeatPassword.Visible = false;

                tbOldPassword.Visible = false;
                tbNewPassword.Visible = false;
                tbConfirmNewPassword.Visible = false;
            }
        }
    }
}