using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public class DatabaseHandler
    {
        private static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Databases.mdf;Integrated Security=True";
        private static SqlConnection con = new SqlConnection(conString);

        //Receives Update SQL Statement and handles Updating
        public static void executeUpdate(string updateCmd)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(updateCmd, con);

                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteReader();

                con.Close();
            }
            catch (SqlException er) { }
            finally { con.Close(); }
        }

        //Receives Insert SQL Statement and handles Inserting
        public static void executeInsert(string insertCmd)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(insertCmd, con);

                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = cmd;
                da.InsertCommand.ExecuteReader();

                con.Close();
            }
            catch (SqlException er) { }
            finally { con.Close(); }
        }


        //Receives SQL Select statement with table name and GridView that has to display data
        public static void LoadGV(string selectCmd, string tableName, ref GridView gvData)
        {
            DataSet ds = executeSelectToDS(selectCmd, tableName);
            gvData.DataSource = ds;
            gvData.DataBind();
        }

        //Receives Delete SQL Statement and handles Deleting
        public static void executeDelete(string deleteCmd)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(deleteCmd, con);

                SqlDataAdapter da = new SqlDataAdapter();
                da.DeleteCommand = cmd;
                da.DeleteCommand.ExecuteReader();

                con.Close();
            }
            catch (SqlException er) { }
            finally { con.Close(); }
        }

        //Receives Select SQL Statement and Database Table Name
        //Fills DataSet with data from SQL statement execution and return DataSet
        public static DataSet executeSelectToDS(string selectCmd, string tableName)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(selectCmd, con);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();

                da.Fill(ds, tableName);

                con.Close();

                return ds;
            }
            catch (SqlException er) { return null; }
            finally { con.Close(); }
        }

        /*
         * USAGE
         * 
         *  ----Loading Data To GridView-----
         *        
         *        1)  string sql = "SELECT * FROM TableName"
         *        2)  DataSet ds = DatabaseHandler.executeSelectToDS(sql, "TableName");
         *        3)  gridView.DataSource = ds;
         *        4)  gridView.DataBind();
         * 
         */

        //Receives Select SQL Statement
        //Creates DataTable with data from SQL statement execution and returns the DataTable
        public static DataTable executeSelectToDT(string selectCmd)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(selectCmd, con);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable tab = new DataTable();
                tab.Load(dr);

                con.Close();

                return tab;
            }
            catch (SqlException er) { return null; }
            finally { con.Close(); }
        }

        /*
         * USAGE
         * 
         *  ----Getting data from database-----
         * 
         *        string sql = $"SELECT * FROM TableName";
         *        DataTable dt = DatabaseHandler.executeSelectToDT(sql);
         *        if (dt.Rows.Count == 0)
         *        {
         *            //Database returned nothing
         *            return null;
         *        }
         *        else 
         *        {
         *            //Database returned at least one object
         *            foreach (DataRow row in dt.Rows)
         *            {
         *                //DataType variableName = row["ColumnName"];
         *                
         *                //e.g.
         *                string name = row["Name"];
         *                string surname = row["Surname"];
         *                int age = row["Age"];
         *            }
         *        }
         *        
         *        // If the only one object is needed or returned dt.Rows[0]["ColumnName"] can be used.
         * 
         */

    }
}