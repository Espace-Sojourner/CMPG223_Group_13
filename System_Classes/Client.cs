using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public enum ClientType
    {
        Client,
        Admin,
        Farmer
    }

    class Client
    {
        public int Client_ID { get; set; }
        public ClientType Client_Type { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }
        public string Shipping_Address { get; set; }
        public string User_Password { get; set; }


        public Client(int Client_ID, ClientType Client_Type, string First_Name, string Last_Name, string Email_Address, string Phone_Number, string shipping_Address, string User_Password)
        {
            this.Client_ID = Client_ID;
            this.Client_Type = Client_Type;
            this.User_Password = User_Password;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Email_Address = Email_Address;
            this.Phone_Number = Phone_Number;
            this.Shipping_Address = shipping_Address;
        }

        public static Client getByID(int ID)
        {
            string sql = $"SELECT * FROM Client WHERE Client_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0)
            {
                sql = $"SELECT * FROM Farmers WHERE Farmer_ID = {ID}";
                dt = DatabaseHandler.executeSelectToDT(sql);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else return RowToFarmer(dt.Rows[0]);
            }
            else return RowToClient(dt.Rows[0]);
        }

        /*public static Client getByEmail(string Email)
        {
            string sql = $"SELECT * FROM Client WHERE Email_Address = {Email}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0) {
                sql = $"SELECT * FROM Farmers WHERE Email_Address = {Email}";
                dt = DatabaseHandler.executeSelectToDT(sql);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else return RowToClient(dt.Rows[0]);
            }            
            else return RowToClient(dt.Rows[0]); 
        }*/

        public static Client getClientByEmail(string Email)
        {
            string sql = $"SELECT * FROM Client WHERE Email_Address = {Email}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0) return null;
            else return RowToClient(dt.Rows[0]);
        }

        public static Client getFarmerByEmail(string Email)
        {
            string sql = $"SELECT * FROM Farmer WHERE Email_Address = {Email}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else return RowToClient(dt.Rows[0]);
        }

        public static Client RowToClient(DataRow Row)
        {
            return new Client((int)Row["Client_ID"], (ClientType)Row["Client_Type"], Row["First_Name"].ToString(), Row["Last_Name"].ToString(), Row["Email_Address"].ToString(), Row["Phone_Number"].ToString(), Row["Shipping_Address"].ToString(), Row["Password"].ToString());
        }
        public static Client RowToFarmer(DataRow Row)
        {
            return new Client((int)Row["Farmer_ID"], ClientType.Farmer, Row["First_Name"].ToString(), Row["Last_Name"].ToString(), Row["Email_Address"].ToString(), Row["Phone_Number"].ToString(), null, Row["Password"].ToString());
        }
    }
}
