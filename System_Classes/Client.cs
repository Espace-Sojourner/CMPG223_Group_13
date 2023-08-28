using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    public enum ClientType
    {
        Client,
        Admin
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
            DataTable dt =  DatabaseHandler.executeSelectToDT(sql);
            return new Client((int)dt.Rows[0]["Client_ID"], (ClientType)dt.Rows[0]["Client_Type"], dt.Rows[0]["First_Name"].ToString(), dt.Rows[0]["Last_Name"].ToString(), dt.Rows[0]["Email_Address"].ToString(), dt.Rows[0]["Phone_Number"].ToString(), dt.Rows[0]["Shipping_Address"].ToString(), dt.Rows[0]["Password"].ToString());
        }
    }
}
