using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public partial class add_produce : System.Web.UI.Page
    {
        //List of all produce
        private List<Produce> produce = new List<Produce>();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DatabaseHandler.executeSelectToDT("SELECT * FROM Produce");
            foreach (DataRow dr in dt.Rows)
            {
                //Adding row to list of produce
                produce.Add(Produce.RowToData(dr));
                ddlProduce.Items.Add(dr["Produce_Name"].ToString());
            }
        }

        protected void btnSubmitListing_Click(object sender, EventArgs e)
        {
            //Validating that produce has not expired
            if(calExpirationDate.SelectedDate <= DateTime.Today)
            {
                //Showing error 
                lblError.Text = "Invalid Date. Produce is already expired or expires today cannot be posted";
            }
            else
            {
                int quantity;
                float price;

                //Validating input for valid integers
                if(int.TryParse(tbQuantity.Text, out quantity))
                {
                    if(float.TryParse(tbPrice.Text, out price))
                    {
                        if(quantity > 0)
                        {
                            if(price > 0)
                            {
                                //Getting the selected produce from drop down list
                                Produce prod = produce[ddlProduce.SelectedIndex];
                                int farmerid = ((User)Session["User"]).User_ID;
                                DateTime expiration = calExpirationDate.SelectedDate;

                                //Inserting Listed Produce into listed produce table in database
                                DatabaseHandler.executeInsert($"INSERT INTO Listed_Produce (Farmer_ID, Produce_ID, Price, Available_Quantity, Expiration_Dates) VALUES({farmerid}, {prod.Produce_ID}, {price}, {quantity}, '{expiration}')");
                                Response.Redirect("~/dashboard.aspx");
                            }
                            else
                            {
                                lblError.Text = "Price must be a positive value";
                            }
                        }
                        else
                        {
                            lblError.Text = "Quantity must be a positive value";
                        }

                    }
                    else
                    {
                        lblError.Text = "Price must be a valid decimal value";
                    }
                }
                else
                {
                    lblError.Text = "Quantity must be a valid integer value";
                }
                
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/dashboard.aspx");
        }
    }
}