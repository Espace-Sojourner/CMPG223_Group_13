using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CMPG223_Group_13
{
    public partial class _default : System.Web.UI.Page
    {
        //fields
        public static string login_type; // Client or Farmer depending on login type. Is static to allow other forms to access it easier if needed
        string email;
        string password;
        public static Client user;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //check if a radiobutton is selected
            if(rbtnClient.Checked || rbtnFarmer.Checked)
            {
                //find login type
                if(rbtnClient.Checked)
                {
                    login_type = "Client";
                }
                else if(rbtnFarmer.Checked)
                {
                    login_type = "Farmer";
                }

                //grab input
                tbEmail.Text = email;
                tbPassword.Text = password;

                //check if inputted info is correct
                
            }
            else
            {
                lblError.Text = "Please select a login type";
            }
        }
    }
}