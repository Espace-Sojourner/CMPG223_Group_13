﻿using CMPG223_Group_13.System_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public partial class cart : System.Web.UI.Page
    {
        private List<Cart_Item> cartItems;

        protected void Page_Load(object sender, EventArgs e)
        {            
            //Getting logged in user object from session
            if (Session["User"] == null) Response.Redirect("~/default.aspx");

            //Getting Cart object from session
            cartItems = (List<Cart_Item>)Session["Cart"];

            //Testing if pageload isn't a postback
            if (!IsPostBack)
            {
                if (cartItems?.Count > 0) setCartPage(true);
                else setCartPage(false);
            }
        }

        protected void setCartPage(bool val)
        {
            //Chaning visibility of components if cart isn't empty
            lstCart.Visible = val;
            btnRemove.Visible = val;
            btnCheckOut.Visible = val;
            btnClearCart.Visible = val;
            if (val)
            {
                //Adding all cart items to list
                lstCart.Items.Clear();
                foreach (Cart_Item item in cartItems) lstCart.Items.Add(item.ToString());
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            //Removing selected item from cart
            if (lstCart.SelectedIndex >= 0)
            {
                cartItems.RemoveAt(lstCart.SelectedIndex);
                lstCart.Items.RemoveAt(lstCart.SelectedIndex);
            }            
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            //Redirecting to browse produce page
            Response.Redirect("~/browse-produce.aspx");
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            //Clearing cart
            lstCart.Items.Clear();
            cartItems.Clear();
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            //Redirecting to checkout page
            Response.Redirect("~/check-out.aspx");
        }
    }
}