﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CMPG223_Group_13.User;
using static CMPG223_Group_13.Listed_Produce;
using static CMPG223_Group_13.DatabaseHandler;


namespace CMPG223_Group_13
{
    public partial class browse_produce : System.Web.UI.Page
    {
        //Current logged in user variable
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Getting current logged in user object from session
            user = getSessionUser();
            if (!Page.IsPostBack)
            {
                string sql = $"SELECT p.Produce_ID as ID, p.Produce_Name as Name, p.Description, l.LP_ID as [Listed Produce], l.Price, l.Available_Quantity as [Available Quantity], l.Expiration_Dates as [Expiration Dates] FROM Produce p, Listed_Produce l WHERE (p.Produce_ID = l.Produce_ID)";
                //Loading gridview with all listed produce
                LoadGV(sql, "Listed_Produce", ref gvProduce);
            }
        }

        protected User getSessionUser()
        {
            //returns user if logged in otherwise redirects to login
            if (Session["User"] == null) Response.Redirect("~/default.aspx");
            return (User)Session["User"];
        }

        protected void btnBacktoDash_Click(object sender, EventArgs e)
        {
            //Redirecting to dashboard page
            Response.Redirect("~/dashboard.aspx");
        }

        protected void gvProduce_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Getting Listed Produce ID from row data
            int LP_ID = int.Parse(gvProduce.SelectedRow.Cells[4].Text);
            //Setting Listed Produce ID in session
            Session["LP_ID"] = LP_ID;

            //Redirecting to listing details page
            Response.Redirect("~/listing-details.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT Produce_ID as ID, Produce_Name as Name, Description, LP_ID as [Listed Produce], Price, Available_Quantity as [Available Quantity], Expiration_Dates as [Expiration Dates] FROM Produce p, Listed_Produce l WHERE (p.Produce_ID = l.Produce_ID) AND (Produce_Name LIKE '%{tbSubSearch.Text}%')";
            
            //Loading listed produce into datagridview
            LoadGV(sql, "Listed_Produce", ref gvProduce);
        }

    }
}