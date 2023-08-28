using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Bank_Account_Info
    {
        /*
         * Example:
         * get methods - instead of "Object.getBank_Account_ID()" only use "Object.Bank_Account_ID"
         * set methods - instead of "Object.setBank_Account_ID(value)" only use "Object.Bank_Account_ID = value"
        */
        public int Bank_Account_ID { get; set; }
        public int User_ID { get; set; }
        public int Farmer_ID { get; set; }
        public string Bank_Name { get; set; }
        public string Account_Number { get; set; }
        public Bank_Account_Info(int Bank_Account_ID,int Farmer_ID , int User_ID, string Bank_Name, string Account_Number)
        {
            this.Bank_Account_ID = Bank_Account_ID;
            this.Farmer_ID = Farmer_ID;
            this.User_ID = User_ID;
            this.Bank_Name = Bank_Name;
            this.Account_Number = Account_Number;
        }

        public Bank_Account_Info getByID(int ID)
        {
            string sql = $"SELECT * FROM Bank_Account_Info WHERE Bank_Account_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            return new Bank_Account_Info((int)dt.Rows[0]["Bank_Account_ID"], (int)dt.Rows[0]["Farmer_ID"], (int)dt.Rows[0]["User_ID"], dt.Rows[0]["Bank_Name"].ToString(), dt.Rows[0]["Account_Number"].ToString());
        }

    }
}
