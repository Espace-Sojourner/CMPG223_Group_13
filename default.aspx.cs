using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public partial class _default : System.Web.UI.Page
    {
        //fields
        static char login_type; // C or F depending on login type. Is static to allow other forms to access it easier if needed
        string username;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //check if a radiobutton is selected
            if(rbtnClient.Checked || rbtnFarmer.Checked)
            {

            }
            else
            {
                lblError.Text = "Please select a login type";
            }
        }
    }
}