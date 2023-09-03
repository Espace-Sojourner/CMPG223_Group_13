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
            if (Session["User"] != null)
            {
                // send to dashboard
                Response.Redirect("~/dashboard.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // user info
            string userPassword = tbPassword.Text,
                firstName = tbFirstname.Text,
                lastName = tbLastname.Text,
                email = tbEmail.Text.ToLower(),
                phoneNumber = tbPhone.Text,
                shippingAddress = tbShippingAddress.Text;
            bool isFarmer = cbFarmerAccount.Checked;

            // bank info
            string bankName = tbBankName.Text, accNumber = tbAccountNumber.Text;

            // farm info
            string farmName = tbFarmName.Text, farmAddress = tbFarmAddress.Text;

            // create user
            User user = new User(-1, (isFarmer) ? UserType.Farmer : UserType.Client, firstName, lastName, email, phoneNumber, shippingAddress, userPassword);

            // only add user if user doesn't exist
            int userID;
            if (getClientByEmail(email) == null && !isFarmer)
            {
                // add client
                insertClient(user);
                userID = getClientByEmail(email).User_ID;
            }
            else if (getFarmerByEmail(email) == null && isFarmer)
            {
                // add farmer
                insertFarmer(user);
                // add farm
                userID = getFarmerByEmail(email).User_ID;
                Farm farm = new Farm(-1, userID, farmName, farmAddress);
                Farm.insertIntoDB(farm);
            }
            else
            { 
                //another user is already registered with that email
                tbEmail.Focus();
                return; //exit function
            }

            // add bank account            
            Bank_Account_Info bankAccount = new Bank_Account_Info(-1, (isFarmer) ? userID : -1, (isFarmer) ? -1 : userID, bankName, accNumber);
            Bank_Account_Info.insertIntoDB(bankAccount);

            // set Session
            Session["User"] = (isFarmer) ? getFarmerByID(userID) : getClientByID(userID);
            Response.Redirect("~/dashboard.aspx");
        }
    }
}