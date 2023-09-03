using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CMPG223_Group_13.User;

namespace CMPG223_Group_13
{
    public partial class createAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validating logged in user object
            if (Session["User"] != null)
            {
                //Redirecting to dashboard
                Response.Redirect("~/dashboard.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Getting user info from all textboxes
            string userPassword = tbPassword.Text,
                firstName = tbFirstname.Text,
                lastName = tbLastname.Text,
                email = tbEmail.Text.ToLower(),
                phoneNumber = tbPhone.Text,
                shippingAddress = tbShippingAddress.Text;
            bool isFarmer = cbFarmerAccount.Checked;

            //Getting bank information from textboxes
            string bankName = tbBankName.Text, accNumber = tbAccountNumber.Text;

            //Creating user obejct from entered information
            User user = new User(-1, (isFarmer) ? UserType.Farmer : UserType.Client, firstName, lastName, email, phoneNumber, shippingAddress, userPassword);

            if (user.isFarmer())
            {
                if (!farmerExists(user))
                {
                    //Adding farmer into the farmer table in database
                    insertFarmer(user);
                    //Getting farm information from textboxes
                    string farmName = tbFarmName.Text, 
                           farmAddress = tbFarmAddress.Text;

                    //Creating farm object from entered information
                    Farm farm = new Farm(-1, user.User_ID, farmName, farmAddress);

                    //Adding farm into the farm table in database
                    Farm.insertIntoDB(farm);
                }
            }
            else if (user.isClient())
            {
                if (!clientExists(user))
                {
                    //Adding user as a client in the Client table in database
                    insertClient(user);
                }
            }
            else
            {
                tbEmail.Focus();
                //Exiting method since user exists
                return;
            }

            

            //Creating and adding bank account info to bank account table in database          
            Bank_Account_Info bankAccount = new Bank_Account_Info(-1, user.isFarmer() ? user.User_ID : -1, user.isClient() ? user.User_ID : -1, bankName, accNumber);
            Bank_Account_Info.insertIntoDB(bankAccount);

            //Setting logged in session user object
            Session["User"] = user;

            //Redirecting to dashboard
            Response.Redirect("~/dashboard.aspx");
        }
    }
}