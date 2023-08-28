using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Order
    {
        public int Order_ID { get; set; }
        public int Client_ID { get; set; }
        public int Farmer_ID { get; set; }
        public int LP_ID { get; set; }
        public DateTime Order_Date { get; set; }
        public double Order_Price { get; set; }
        public int Bought_Quantity { get; set; }

        public Order(int Order_ID, int Client_ID, int Farmer_ID, int LP_ID, DateTime Order_Date, double Order_Price, int Bought_Quantity)
        {
            this.Order_ID = Order_ID;
            this.Client_ID = Client_ID;
            this.Farmer_ID = Farmer_ID;
            this.LP_ID = LP_ID;
            this.Order_Date = Order_Date;
            this.Order_Price = Order_Price;
            this.Bought_Quantity = Bought_Quantity;
        }

        public Order getByID(int ID)
        {
            string sql = $"SELECT * FROM Order_ID WHERE Order_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            return new Order((int)dt.Rows[0]["Order_ID"], (int)dt.Rows[0]["Client_ID"], (int)dt.Rows[0]["Farmer_ID"], (int)dt.Rows[0]["LP_ID"], (DateTime)dt.Rows[0]["Order_Date"], (double)dt.Rows[0]["Order_Price"], (int)dt.Rows[0]["Bought_Quantity"]);
        }
    }
}
