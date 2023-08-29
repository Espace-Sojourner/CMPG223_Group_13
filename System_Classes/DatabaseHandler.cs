using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CMPG223_Group_13
{
    public class DatabaseHandler
    {
        private static string conString = "@\"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\App_Data\\Databases.mdf;Integrated Security=True\"";
        private static SqlConnection con = new SqlConnection(conString);

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

        public static Boolean verifyUserInfo(string tablename, string email, string password)
        {
            int count = 0;
            con.Open();

            //count how many users in tablename match the info
            using (SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM " + tablename + " WHERE Email_Address LIKE @email AND Password LIKE @password", con))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                count = (int)cmd.ExecuteScalar();
            }

            if(count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}