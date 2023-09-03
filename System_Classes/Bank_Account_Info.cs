using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public class Bank_Account_Info
    {
        /*
         * Example:
         * get methods - instead of "Object.getBank_Account_ID()" only use "Object.Bank_Account_ID"
         * set methods - instead of "Object.setBank_Account_ID(value)" only use "Object.Bank_Account_ID = value"
        */
        public int Bank_Account_ID { get; set; }
        public int Client_ID { get; set; }
        public int Farmer_ID { get; set; }
        public string Bank_Name { get; set; }
        public string Account_Number { get; set; }
        public Bank_Account_Info(int Bank_Account_ID,int Farmer_ID , int Client_ID, string Bank_Name, string Account_Number)
        {
            this.Bank_Account_ID = Bank_Account_ID;
            this.Farmer_ID = Farmer_ID;
            this.Client_ID = Client_ID;
            this.Bank_Name = Bank_Name;
            this.Account_Number = Account_Number;
        }

        public static Bank_Account_Info getByID(int ID)
        {
            string sql = $"SELECT * FROM Bank_Account_Info WHERE Bank_Account_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt?.Rows?.Count > 0) return RowToData(dt.Rows[0]);
            else return null;
        }

        public static Bank_Account_Info getByUserID(int ID)
        {
            string sql = $"SELECT * FROM Bank_Account_Info WHERE Farmer_ID = {ID} OR Client_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt?.Rows?.Count > 0) return RowToData(dt.Rows[0]);
            else return null;
        }

        public static bool Exists(Bank_Account_Info info)
        {
            if (getByID(info.Bank_Account_ID) == null) return false;
            else return true;
        }

        public static void insertIntoDB(Bank_Account_Info info)
        {
            if (Exists(info))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Bank_Account_Info (Farmer_ID, Client_ID, Bank_name, Account_Number) " +
                    $"VALUES ({(info.Farmer_ID == -1 ? "NULL" : info.Farmer_ID)}, {(info.Client_ID == -1 ? "NULL" : info.Client_ID)}, '{info.Bank_Name}', '{info.Account_Number}')";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateInDB(Bank_Account_Info info)
        {
            if (Exists(info))
            {
                string sql = $"UPDATE Bank_Account_Info SET " +
                    $"Farmer_ID = {(info.Farmer_ID == -1 ? null : info.Farmer_ID)}, " +
                    $"Client_ID = {(info.Client_ID == -1 ? null : info.Client_ID)}, " +
                    $"Bank_name = '{info.Bank_Name}' " +
                    $"Account_Number = '{info.Account_Number}' " +
                    $"WHERE Bank_Account_ID = {info.Bank_Account_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling

            }
        }

        public static void deleteFromDB(Bank_Account_Info info)
        {
            if (Exists(info))
            {
                string sql = $"DELETE FROM Bank_Account_Info WHERE Bank_Account_ID = {info.Bank_Account_ID}";
                DatabaseHandler.executeDelete(sql);
            }
            else
            {
                //Error Handling

            }
        }



        /*
         * USAGE
         * 
         * 1) Bank_Account_Info bao = RowToData(dataTable.Rows[rowIndex])
         * 
         */

        //Returns Bank_Account_Info object from DataRow
        public static Bank_Account_Info RowToData(DataRow Row)
        { 
            return new Bank_Account_Info((int)Row["Bank_Account_ID"], (!Row.IsNull("Farmer_ID")) ? (int)Row["Farmer_ID"] : -1, (!Row.IsNull("Client_ID")) ? (int)Row["Client_ID"] : -1, Row["Bank_Name"].ToString(), Row["Account_Number"].ToString());
        }



        /*
         * USAGE
         * 
         * 1) Bank_Account_Info bao = RowToData(gridView.SelectedRow)
         * 
         */

        //Returns Bank_Account_Info object from GridViewRow
        public static Bank_Account_Info RowToData(GridViewRow Row)
        {
            return getByID(int.Parse(Row.Cells[1].Text));
        }

    }
}
