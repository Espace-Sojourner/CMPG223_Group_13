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
        Listed_Produce listing;
        User farmer;
        Produce produce;
        Unit_of_Measure uom;
        static Cart_Item prevItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            // create new cart if it doesn't exists
            if (Session["Cart"] == null) Session["Cart"] = new ArrayList();

            // check if listing selected
            if (Session["LP_ID"] == null) Response.Redirect("~/browse-produce.aspx");

            listing = Listed_Produce.getByID((int)Session["LP_ID"]);
            farmer = getFarmerByID(listing.Farmer_ID);
            produce = Produce.getByID(listing.Produce_ID);
            uom = Unit_of_Measure.getByID(produce.UOM_ID);

            // --- FILL LISTING DETAILS ---

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
            lblAdded.Visible = true;
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            // add & take to cart
            addListingToCart();
            Response.Redirect("~/cart.aspx");
        }

        protected void addListingToCart()
        {
            int quantity; // to be purchased
            double price; // quantity times price per UOM
            bool isCorrect = false; // quantity validation
            if (int.TryParse(tbQuantity.Text, out quantity))
                if (quantity <= listing.Available_Quantity && quantity > 0)
                {
                    isCorrect = true;         
                    price = quantity * listing.Price;
                    
                    Cart_Item item;
                    if (prevItem != null)
                    {
                        // remove previous item
                        ((ArrayList)Session["Cart"]).Remove(prevItem);
                        // create updated cart item with new quantity and price
                        item = new Cart_Item(listing.LP_ID, produce.Produce_Name, quantity + prevItem.quantity, uom.Abbreviation, price + prevItem.price);
                    }
                    else
                    {
                        // create cart item
                        item = new Cart_Item(listing.LP_ID, produce.Produce_Name, quantity, uom.Abbreviation, price);                                           
                    }
                    // add item to cart  
                    ((ArrayList)Session["Cart"]).Add(item);
                    prevItem = item;
                }           

            // wrong format or quantity more than available
            if (!isCorrect) tbQuantity.Focus();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // redirect to listings
            Session["LP_ID"] = null;
            Response.Redirect("~/browse-produce.aspx");
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            // redirect to cart
            Session["LP_ID"] = null;
            Response.Redirect("~/cart.aspx");
        }

        protected void btnBacktoBrowse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/browse-produce.aspx");
        }
    } 
}