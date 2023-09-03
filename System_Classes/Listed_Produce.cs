using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public class Listed_Produce
    {
        public int LP_ID { get; set; }
        public int Farmer_ID { get; set; }
        public int Produce_ID { get; set; }
        public double Price { get; set; }
        public int Available_Quantity { get; set; }
        public DateTime Expiration_Dates { get; set; }

        public Listed_Produce(int LP_ID, int Farmer_ID, int Produce_ID, double Price, int Available_Quantity, DateTime Expiration_Dates)
        {
            this.LP_ID = LP_ID;
            this.Farmer_ID = Farmer_ID;
            this.Produce_ID = Produce_ID;
            this.Price = Price;
            this.Available_Quantity = Available_Quantity;
            this.Expiration_Dates = Expiration_Dates;
        }
        public static Listed_Produce getByID(int ID)
        {
            string sql = $"SELECT * FROM Listed_Produce WHERE LP_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt?.Rows?.Count > 0) return RowToData(dt.Rows[0]);
            else return null;
        }

        public static bool Exists(Listed_Produce lp)
        {
            if (getByID(lp.LP_ID) == null) return false;
            else return true;
        }

        public static void insertIntoDB(Listed_Produce lp)
        {
            if (Exists(lp))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Listed_Produce (Farmer_ID, Produce_ID, Price, Available_Quantity, Expiration_Dates) " +
                    $"VALUES ({lp.Farmer_ID}, {lp.Produce_ID}, {lp.Price}, {lp.Available_Quantity}, '{lp.Expiration_Dates}')";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateInDB(Listed_Produce lp)
        {
            if (Exists(lp))
            {
                string sql = $"UPDATE Listed_Produce SET " +
                    $"Farmer_ID = {lp.Farmer_ID}, " +
                    $"Produce_ID = {lp.Produce_ID}, " +
                    $"Price = {lp.Price}, " +
                    $"Available_Quantity = {lp.Available_Quantity}, " +
                    $"Expiration_Dates = '{lp.Expiration_Dates}' " +
                    $"WHERE LP_ID = {lp.LP_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling

            }
        }

        public static void deleteFromDB(Listed_Produce lp)
        {
            if (Exists(lp))
            {
                string sql = $"DELETE FROM Listed_Produce WHERE LP_ID = {lp.LP_ID}";
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
         * 1) Listed_Produce lp = RowToData(dataTable.Rows[rowIndex])
         * 
         */

        //Returns Listed_Produce object from DataRow
        public static Listed_Produce RowToData(DataRow Row)
        {
            return new Listed_Produce((int)Row["LP_ID"], (int)Row["Farmer_ID"], (int)Row["Produce_ID"], (double)Row["Price"], (int)Row["Available_Quantity"], (DateTime)Row["Expiration_Dates"]);
        }



        /*
         * USAGE
         * 
         * 1) Listed_Produce lp = RowToData(gridView.SelectedRow)
         * 
         */

        //Returns Listed_Produce object from GridViewRow
        public static Listed_Produce RowToData(GridViewRow Row)
        {
            return getByID(int.Parse(Row.Cells[1].Text));
        }
    }
}
