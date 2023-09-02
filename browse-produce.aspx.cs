using System;
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
using System.Xml.Linq;
using static CMPG223_Group_13.DatabaseHandler;


namespace CMPG223_Group_13
{
    public partial class browseProduce : System.Web.UI.Page
    {

        User user;


        protected void Page_Load(object sender, EventArgs e)
        {
            user = getSessionUser();



            DatabaseHandler.LoadGV("SELECT * from Listed_Produce","Listed_Produce", ref gvProduce );
        }

        protected User getSessionUser()
        {
            //returns user if logged in otherwise redirects to login
            if (Session["User"] == null) Response.Redirect("~/default.aspx");
            return (User)Session["User"];
        }

        private void tbSubSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();     //produce ID
            string sql = $"Select Produce_ID FROM Produce WHERE Produce_Name LIKE '%{tbSubSearch.Text}%'";
            ds = executeSelectToDS(sql, "Produce");

            DataSet dt = new DataSet();     //farmer ID
            string sqll = $"Select Farmer_ID FROM Produce WHERE First_Name LIKE '%{tbSubSearch.Text}%'";
            dt = executeSelectToDS(sqll, "Farmer");


            if (ds != null)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                LoadGV("SELECT * FROM Listed_Produce WHERE Produce_ID like '" + dr["Produce_ID"] + "%'", "Listed_Produce", ref gvProduce);

            }
            else if(dt != null)
            {
                DataRow dv = dt.Tables[0].Rows[0];
                LoadGV("SELECT* FROM Listed_Produce WHERE Farmer_ID like '" + dv["Farmer_ID"] + "%'", "Listed_Produce", ref gvProduce);
                
            }


        }
    }
}