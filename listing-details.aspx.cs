using CMPG223_Group_13.System_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CMPG223_Group_13.User;

namespace CMPG223_Group_13
{
    public partial class listing_details : System.Web.UI.Page
    {
        private Listed_Produce listing;
        private User farmer;
        private Produce produce;
        private Unit_of_Measure uom;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Create Cart object session item
            if (!Page.IsPostBack) 
                if (Session["Cart"] == null) Session["Cart"] = new List<Cart_Item>();

            //Returning of no Listed Produce object is found
            if (Session["LP_ID"] == null) Response.Redirect("~/browse-produce.aspx");

            //Getting Listed Produce object from Session
            listing = Listed_Produce.getByID((int)Session["LP_ID"]);
            farmer = getFarmerByID(listing.Farmer_ID);
            produce = Produce.getByID(listing.Produce_ID);
            uom = Unit_of_Measure.getByID(produce.UOM_ID);

            //Chaning form to contain correct details
            lblAdded.Visible = false;
            imgProduce.ImageUrl = produce.Image_Link;
            lblProduceName.Text = produce.Produce_Name;
            lblFarmer.Text = $"Sold by {farmer.First_Name} {farmer.Last_Name}";
            lblDescription.Text = produce.Description;
            lblPrice.Text = $"{listing.Price:C} per {uom.Abbreviation}";
            lblAvailable.Text = listing.Available_Quantity.ToString();
            lblExpiration.Text = listing.Expiration_Dates.ToShortDateString();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            addListingToCart();
            
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            //Redirecting to cart page
            addListingToCart();
            Response.Redirect("~/cart.aspx");
        }

        protected void addListingToCart()
        {
            lblAdded.Visible = false;
            int quantity; //Quantity to be purchased
            double price; //Quantity times price per UOM
            if (int.TryParse(tbQuantity.Text, out quantity))
            {
                //Validating quantity
                if (quantity <= listing.Available_Quantity && quantity > 0)
                {
                    price = quantity * listing.Price;

                    //Creating quantity 
                    Cart_Item item = new Cart_Item(listing.LP_ID, produce.Produce_Name, quantity, uom.Abbreviation, price);

                    //Getting Cart object from session and setting local variable
                    List<Cart_Item> localList = (List<Cart_Item>)Session["Cart"];
                    if (localList.Contains(item))
                    {
                        //Updating cart item
                        Cart_Item updatedItem = localList[localList.IndexOf(item)];
                        updatedItem.quantity += quantity;

                        //Setting updated item in list
                        localList[localList.IndexOf(item)] = updatedItem;
                    }
                    else
                    {
                        //Adding cart item to cart item list
                        localList.Add(item);
                    }

                    //Setting Cart object session from local variable
                    Session["Cart"] = localList;
                    lblAdded.Visible = true;
                }
                else
                {
                    if (quantity > 0)
                    {
                        lblError.Text = "The quantity entered is more than what is currently available";
                    }
                    else
                    {
                        lblError.Text = "Enter a quantity more than 0";
                    }
                    tbQuantity.Text = "";
                    tbQuantity.Focus();
                }
            }
            else
            {
                lblError.Text = "Enter a valid number";
                tbQuantity.Text = "";
                tbQuantity.Focus();
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Redirecting to browse produce page
            Session["LP_ID"] = null;
            Response.Redirect("~/browse-produce.aspx");
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            //Redirecting to cart page
            Session["LP_ID"] = null;
            Response.Redirect("~/cart.aspx");
        }

        protected void btnBacktoBrowse_Click(object sender, EventArgs e)
        {
            //Redirecting to browse-produce page
            Response.Redirect("~/browse-produce.aspx");
        }
    } 
}