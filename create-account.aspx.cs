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
        public static string Username = tbUsername.Text, User_Password = tbPassword.Text, User_Password = tbConfirmPassword.Text;
        public static string First_Name = tbFirstname.Text, Last_Name = tbLastname.Text, Email_Address = tbEmail.Text, Phone_Number = tbPhone;
        public static string Farm_Name = tbFarmName.Text;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}