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
        private User user;
        private Bank_Account_Info bank;
        private Farm farm;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting logged in user object from session
            user = getSessionUser();

            //Validating UserType and getting relative information
            if (user.isAdmin())
            {
                bank = Bank_Account_Info.getByUserID(user.User_ID);
            }
            if (user.isFarmer())
            {
                farm = Farm.getByID(user.User_ID);
            }

            //Filling in data if the PageLoad is not a postback
            if(!Page.IsPostBack)
            {
                prefillData();
            }
            
        }

        protected User getSessionUser()
        {
            //Returns user if logged in otherwise redirects to login
            if (Session["User"] == null) Response.Redirect("~/default.aspx");
            return (User)Session["User"];            
        }

        protected void prefillData()
        {
            //Filling textboxes with data from logged in user
            tbFirstname.Text = user.First_Name;
            tbLastname.Text = user.Last_Name;
            tbEmail.Text = user.Email_Address;
            tbPhone.Text = user.Phone_Number;
            tbShippingAddress.Text = user.Shipping_Address;

            tbBankName.Text = user.isAdmin() ? "N/A" : bank.Bank_Name;
            tbAccountNumber.Text = user.isAdmin() ? "N/A" : bank.Account_Number;

            tbFarmName.Text = user.isFarmer() ? farm.Farm_Name : "N/A";
            tbFarmAddress.Text = user.isFarmer() ? farm.Farm_Address : "N/A";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //Getting data from textboxes and storing them in varbiales
            string firstName = tbFirstname.Text,
                lastName = tbLastname.Text,
                email = tbEmail.Text,
                phone = tbPhone.Text,
                address = tbShippingAddress.Text,
                password = user.User_Password;

            //Validating that the old password is the users current password
            if (user.User_Password == tbOldPassword.Text)
            {
                password = tbNewPassword.Text;
            }

            //Getting entered bank account information

            string bankName = tbBankName.Text, 
                accNumber = tbAccountNumber.Text;

            //Getting entered farm information
            string farmName = tbFarmName.Text, 
                farmAddress = tbFarmAddress.Text;

            //Creating user with updated information
            User newUser = new User(user.User_ID,user.UserType,firstName,lastName,email,phone,address,password);

            //Validating UserType to update the correct table
            if (user.isFarmer())
            {
                //Updating farmer with entered data
                updateFarmer(newUser);

                //Updating farm type with the new details
                Farm newFarm = new Farm(farm.Farm_ID, user.User_ID, farmName, farmAddress);
                Farm.updateInDB(newFarm);             
            }
            else
            {
                //Updating client with entered data
                updateClient(newUser);
            }

            //Updating Session user object
            Session["User"] = newUser;
            
            //Updating bank account information if applicable
            if (user.isAdmin())
            {
                //Creating bank account info object from entered data
                Bank_Account_Info newBank = new Bank_Account_Info(bank.Bank_Account_ID, user.isFarmer() ? user.User_ID : -1, user.isClient() ? user.User_ID : -1, bankName, accNumber);
                Bank_Account_Info.updateInDB(newBank);
            }

            //Redirecting to dashboard page
            Response.Redirect("~/dashboard.aspx");
        }

        protected void cbChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            //Chaning the visibility of new password and old password text field according to checkbox
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