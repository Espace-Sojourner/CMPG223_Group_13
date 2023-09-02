using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CMPG223_Group_13.User;

namespace CMPG223_Group_13
{
    public partial class change_account_details : System.Web.UI.Page
    {
        User user;
        Bank_Account_Info bank;
        Farm farm;
        private bool isFarmer = false, isAdmin = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            // get all user details
            user = getSessionUser();
            if (user.UserType != UserType.Admin)
            {
                isAdmin = false;
                bank = Bank_Account_Info.getByID(user.User_ID);
            }
            if (user.UserType == UserType.Farmer)
            {
                isFarmer = true;
                farm = Farm.getByID(user.User_ID);
            }

            prefillData();
            
        }

        // NOTE: could possibly add the below method to the User class to be accessed by all forms
        protected User getSessionUser()
        {
            //returns user if logged in otherwise redirects to login
            if (Session["User"] == null) Response.Redirect("~/default.aspx");
            return (User)Session["User"];            
        }

        protected void prefillData()
        {
            // user data
            tbFirstname.Text = user.First_Name;
            tbLastname.Text = user.Last_Name;
            tbEmail.Text = user.Email_Address;
            tbPhone.Text = user.Phone_Number;
            tbShippingAddress.Text = user.Shipping_Address;

            // bank info
            tbBankName.Text = (isAdmin) ? "N/A" : bank.Bank_Name;
            tbAccountNumber.Text = (isAdmin) ? "N/A" : bank.Account_Number;

            // farm info
            tbFarmName.Text = (isFarmer) ? farm.Farm_Name : "N/A";
            tbFarmAddress.Text = (isFarmer) ? farm.Farm_Address : "N/A";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // --- entries ---
            // user details
            string firstName = tbFirstname.Text,
                lastName = tbLastname.Text,
                email = tbEmail.Text,
                phone = tbPhone.Text,
                address = tbShippingAddress.Text,
                oldPassword = tbOldPassword.Text;

            // validate old password
            string cmd = $"select * from {user.UserType} where Email_Address = {user.Email_Address} and Password = {oldPassword}";
            DataTable dt = DatabaseHandler.executeSelectToDT(cmd);
            // create new password
            string newPassword = (dt.Rows.Count != 0) ? tbNewPassword.Text : user.User_Password;

            // bank info
            string bankName = tbBankName.Text, accNumber = tbAccountNumber.Text;
            // farm info 
            string farmName = tbFarmName.Text, farmAddress = tbFarmAddress.Text;

            // create new user
            User newUser = new User(user.User_ID,user.UserType,firstName,lastName,email,phone,address,newPassword);

            //update user
            if (isFarmer)
            {
                updateFarmer(newUser);
                Farm newFarm = new Farm(farm.Farm_ID, user.User_ID, farmName, farmAddress);                
                Farm.updateInDB(newFarm);
                Session["User"] = getFarmerByID(user.User_ID); // update Session
            }
            else
            {
                updateClient(newUser);
                Session["User"] = getClientByID(user.User_ID); // update Session
            }

            // update bank if applicable
            if (!isAdmin)
            {
                Bank_Account_Info newBank = new Bank_Account_Info(bank.Bank_Account_ID, (isFarmer) ? user.User_ID : -1, (isFarmer) ? -1 : user.User_ID, bankName, accNumber);
                Bank_Account_Info.updateInDB(newBank);
            }

            // send to dashboard
            Response.Redirect("~/dashboard.aspx");
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