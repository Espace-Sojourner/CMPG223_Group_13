using CMPG223_Group_13.System_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using static CMPG223_Group_13.User;

namespace CMPG223_Group_13
{
    public partial class check_out : System.Web.UI.Page
    {
        private List<Cart_Item> cartItems;
        private User user;
        private double totalPrice;
        private string awaitingPayments;

        protected void Page_Load(object sender, EventArgs e)
        {
            // check login
            if (Session["User"] == null) Response.Redirect("~/default.aspx");
            totalPrice = 0;
            awaitingPayments = "";
            user = (User)Session["User"];
            cartItems = (List<Cart_Item>)Session["Cart"];
            if (cartItems?.Count > 0)
            {
                txtSummary.Value = string.Format("{0,-15}{1,-10}{2,-10}{3,10}\n","Produce","Quantity","UOM","Price");
                foreach (Cart_Item item in cartItems)
                {
                    // display item summary
                    txtSummary.Value += item.ToString("order") + "\n";
                    // increase total
                    totalPrice += item.price;
                    // add to pending payments
                    int farmerID = Listed_Produce.getByID(item.LP_ID).Farmer_ID;
                    Bank_Account_Info farmerAccount = Bank_Account_Info.getByUserID(farmerID);
                    string banking = farmerAccount.Bank_Name + ": " + farmerAccount.Account_Number;
                    awaitingPayments += $"Payment of {item.price:C} to {banking}\n";
                }
                //order total
                txtSummary.Value += string.Format("{0}\n{1,-35}{2,10}", new string('=', 45), "Total order price:", totalPrice.ToString("C"));

                //set buttons
                btnBack.Visible = true;
                btnConfirm.Visible = true;
                btnDashboard.Visible = false;
            }
            else
            {
                Response.Redirect("~/cart.aspx");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //foreach (Cart_Item item in cartItems)
            //{
            for (int i = 0; i < cartItems.Count; i++)
            { 
                Cart_Item item = (Cart_Item)cartItems[i];
                // add order
                Order order = new Order(-1, user.User_ID,item.LP_ID, DateTime.Now,totalPrice,item.quantity);
                Order.insertIntoDB(order);

                // reduce listing quantity / remove listing
                Listed_Produce listed = Listed_Produce.getByID(item.LP_ID);
                int newQuantity = listed.Available_Quantity - item.quantity;
                if (newQuantity > 0)
                {
                    //update available quantity
                    Listed_Produce updated = new Listed_Produce(listed.LP_ID,listed.Farmer_ID,listed.Produce_ID,listed.Price,newQuantity,listed.Expiration_Dates);
                    Listed_Produce.updateInDB(updated);
                }
                else
                {
                    Listed_Produce.deleteFromDB(listed);
                }

                // Order summary
                string orderSummary = txtSummary.Value + "\n" + new string('=', 45) + "\nAwaiting payments to:\n" + awaitingPayments;
                txtSummary.Value = orderSummary;
                // navigation
                btnBack.Visible = false;
                btnConfirm.Visible = false;
                btnDashboard.Visible = true;
                // reset cart
                cartItems.Clear();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/cart.aspx");
        }

        protected void btnReturnToDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}