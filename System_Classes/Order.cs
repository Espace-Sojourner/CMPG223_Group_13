using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public class Order
    {
        public int Order_ID { get; set; }
        public int Client_ID { get; set; }
        public int LP_ID { get; set; }
        public DateTime Order_Date { get; set; }
        public double Order_Price { get; set; }
        public int Bought_Quantity { get; set; }

        public Order(int Order_ID, int Client_ID, int LP_ID, DateTime Order_Date, double Order_Price, int Bought_Quantity)
        {
            this.Order_ID = Order_ID;
            this.Client_ID = Client_ID;
            this.LP_ID = LP_ID;
            this.Order_Date = Order_Date;
            this.Order_Price = Order_Price;
            this.Bought_Quantity = Bought_Quantity;
        }

        public static Order getByID(int ID)
        {
            string sql = $"SELECT * FROM Order_ID WHERE Order_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0) return null;
            else return RowToData(dt.Rows[0]);
        }

        public static bool Exists(Order order)
        {
            if (getByID(order.Order_ID) == null) return false;
            else return true;
        }

        public static void insertIntoDB(Order order)
        {
            if (Exists(order))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Order (Order_ID, Client_ID, LP_ID, Order_Date, Order_Price, Bought_Quantity) " +
                    $"VALUES ({order.Order_ID}, {order.Client_ID}, {order.LP_ID}, '{order.Order_Date}', {order.Order_Price}, {order.Bought_Quantity})";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateInDB(Order order)
        {
            if (Exists(order))
            {
                string sql = $"UPDATE Order SET " +
                    $"Client_ID = {order.Client_ID}, " +
                    $"LP_ID = {order.LP_ID}, " +
                    $"Order_Date = '{order.Order_ID}' " +
                    $"Order_Price = {order.Order_Price}" +
                    $"Bought_Quantity = {order.Bought_Quantity} " +
                    $"WHERE Order_ID = {order.Order_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling

            }
        }

        public static void deleteFromDB(Order order)
        {
            if (Exists(order))
            {
                string sql = $"DELETE FROM Order WHERE Order_ID = {order.Order_ID}";
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
         * 1) Order order = RowToData(dataTable.Rows[rowIndex])
         * 
         */

        //Returns Order object from DataRow
        public static Order RowToData(DataRow Row)
        {
            return new Order((int)Row["Order_ID"], (int)Row["Client_ID"], (int)Row["LP_ID"], (DateTime)Row["Order_Date"], (double)Row["Order_Price"], (int)Row["Bought_Quantity"]);
        }



        /*
         * USAGE
         * 
         * 1) Order order = RowToData(gridView.SelectedRow)
         * 
         */

        //Returns Order object from GridViewRow
        public static Order RowToData(GridViewRow Row)
        {
            return RowToData((Row.DataItem as DataRowView).Row);
        }
    }
}
