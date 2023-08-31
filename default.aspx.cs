using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CMPG223_Group_13
{
    public partial class _default : System.Web.UI.Page
    {
        //fields
        string login_type; // Client or Farmer depending on login type. Is static to allow other forms to access it easier if needed
        string email;
        string password;
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                // send to dashboard
                Response.Redirect("~/dashboard.aspx");
            }
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
                email = tbEmail.Text;
                password = tbPassword.Text;

                //check if inputted info is correct
                string sql = $"SELECT * FROM {login_type} WHERE Email_Address = {email} AND Password = {password}";
                DataTable dt = DatabaseHandler.executeSelectToDT(sql);
                if (dt.Rows.Count == 0)
                {
                    lblError.Text = "Invalid user info";
                }
                else
                {
                    //grab all user info
                    foreach (DataRow row in dt.Rows)
                    {
                        int id;
                        if(login_type == "Farmer")
                        {
                            id = (int)row["Farmer_ID"];
                        }
                        else //if client
                        {
                            id = (int)row["Client_ID"];
                        }

                        string firstname = (string)row["First_Name"];
                        string lastname = (string)row["Last_Name"];
                        string number = (string)row["Phone_Number"];

                        UserType usertype;
                        string address;

                        if(login_type == "Farmer")
                        {
                            usertype = UserType.Farmer;
                            address = null;
                        }
                        else //if client
                        {
                            usertype = (UserType)row["Client_Type"];
                            address = (string)row["Shipping_Address"];
                        }

                        //create user object
                        user = new User(id, usertype, firstname, lastname, email, number, address, password);
                        Session["User"] = user;

                        // send to dashboard
                        Response.Redirect("~/dashboard.aspx");
                    }
                }

            }
            else
            {
                lblError.Text = "Please select a login type";
            }
        }
    }
}