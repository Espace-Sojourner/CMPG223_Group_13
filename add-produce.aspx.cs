using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public partial class add_produce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseHandler.readToDDL(@"SELECT * FROM Produce", "Produce_Name", ref ddlProduce);
        }

        protected void btnSubmitListing_Click(object sender, EventArgs e)
        {
            //validate input
            if(calExpirationDate.SelectedDate <= DateTime.Today)
            {
                lblError.Text = "Invalid Date. Produce is already expired or expires today cannot be posted";
            }
            else
            {
                int quantity;
                float price;

                //validate input
                if(int.TryParse(tbQuantity.Text, out quantity))
                {
                    if(float.TryParse(tbPrice.Text, out price))
                    {
                        if(quantity > 0)
                        {
                            if(price > 0)
                            {
                                //grab input and save to database

                                Produce produce = Produce.getByID(ddlProduce.SelectedIndex + 1);
                                int farmerid = ((User)Session["User"]).User_ID;
                                DateTime expiration = calExpirationDate.SelectedDate;
                                DatabaseHandler.executeInsert($"INSERT INTO Listed_Produce (Farmer_ID, Produce_ID, Price, Available_Quantity, Expiration_Dates) VALUES({farmerid}, {produce.Produce_ID}, {price}, {quantity}, '{expiration}')");
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
    }
}