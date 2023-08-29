using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Listed_Produce
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
            string sql = $"SELECT * FROM LP_ID WHERE LP_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            return new Listed_Produce((int)dt.Rows[0]["LP_ID"], (int)dt.Rows[0]["Farmer_ID"], (int)dt.Rows[0]["Produce_ID"], (double)dt.Rows[0]["Price"], (int)dt.Rows[0]["Available_Quantity"], (DateTime)dt.Rows[0]["Expiration_Dates"]);
        }
    }
}
