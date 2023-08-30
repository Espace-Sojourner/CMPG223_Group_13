using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public partial class createAccount : System.Web.UI.Page
    {
        public static string Username = "", User_Password = "";
        public static string First_Name = "", Last_Name = "", Email_Address = "", Phone_Number = "";
        public static string Farm_Name = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Username = tbUsername.Text;
            User_Password = tbPassword.Text;
            User_Password = tbConfirmPassword.Text;
            First_Name = tbFirstname.Text;
            Last_Name = tbLastname.Text;
            Email_Address = tbEmail.Text;
            Phone_Number = tbPhone.Text;

            if (cbFarmerAccount.Checked)
            {
                Farm_Name = tbFarmName.Text;
            }

        }
    }
}