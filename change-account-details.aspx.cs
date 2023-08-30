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

        protected void Page_Load(object sender, EventArgs e)
        {
            // --- test user "logged in" ---
            //user = new User(12, UserType.Client, "User", "Resu", "user@gmail.com", "0722602483", "2 Home Street", "frikkieja");

            user = getSessionUser();

            //prefill user data
            tbFirstname.Text = user.First_Name;
            tbLastname.Text = user.Last_Name;
            tbEmail.Text = user.Email_Address;
            tbPhone.Text = user.Phone_Number;

        }

        //could possibly add the below method to the User class to be accessed by all forms
        protected User getSessionUser()
        {          
            //returns user if logged in otherwise redirects to login
            if (Session["User"] != null) return (User)Session["User"];                            
            else
            {
                Response.Redirect("~/default.aspx");
                return null; //won't execute but needed
            }              
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            /*
             * TODO:
             * - entries
             * -- validate entries (validation controls)
             * - controls
             * -- require shipping address and password fields
             * -- require farm fields
             * -- require bank fields
            */

            //entries
            string firstName = tbFirstname.Text,
                lastName = tbLastname.Text,
                email = tbEmail.Text,
                phone = tbPhone.Text;

            //create updated user
            User updated = new User(user.User_ID,user.UserType,firstName,lastName,email,phone,user.Shipping_Address,user.User_Password);

            //update user
            switch(user.UserType)
            {
                case UserType.Admin:
                case UserType.Client:
                    updateClient(updated);                    
                    break;
                case UserType.Farmer:
                    updateFarmer(updated);
                    break;
            }

            //set Session
            Session["User"] = updated;
        }
    }
}