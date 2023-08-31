using System;
using System.Collections.Generic;
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
            // PENDING: tbAddress.text = user.Shipping_Address;
            // PENDING: tbPassword.text = user.User_Password;

            // bank info
            // PENDING: tbBankName.text = (isAdmin) ? "N/A" : bank.Bank_Name;
            // PENDING: tbAccNumber.text = (isAdmin) ? "N/A" : bank.Account_Number;

            // farm info
            // PENDING: tbfarmName.Text = (isFarmer) ? farm.Farm_Name : "N/A";
            // PENDING: tbfarmAddress.Text = (isFarmer) ? farm.Farm_Address : "N/A";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // TODO: add required input controls & validation controls

            // --- entries ---
            // user details
            string firstName = tbFirstname.Text,
                lastName = tbLastname.Text,
                email = tbEmail.Text,
                phone = tbPhone.Text,
                address = "", //PENDING: tbAddress.text
                password = ""; //PENDING: tbPassword.text
            // bank info
            string bankName = "", //PENDING: tbBankName.text
                accNumber = ""; //PENDING: tbAccNumber.text
            // farm info 
            string farmName = "", //PENDING: tbFarmName.text
                farmAddress = ""; //PENDING: tbFarmAddress.text

            // create new user
            User newUser = new User(user.User_ID,user.UserType,firstName,lastName,email,phone,address,password);

            if (isFarmer)
            {
                updateFarmer(newUser);
                Farm newFarm = new Farm(farm.Farm_ID, user.User_ID, farmName, farmAddress);                
                Farm.updateInDB(newFarm);
                user = getFarmerByID(user.User_ID); // update Session
            }
            else
            {
                updateClient(newUser);
                user = getClientByID(user.User_ID); // update Session
            }

            if (!isAdmin)
            {
                Bank_Account_Info newBank = new Bank_Account_Info(bank.Bank_Account_ID, (isFarmer) ? user.User_ID : -1, (isFarmer) ? -1 : user.User_ID, bankName, accNumber);
                Bank_Account_Info.updateInDB(newBank);
            }

            // send to dashboard
            Response.Redirect("~/dashboard.aspx");
        }
    }
}