using System;
using System.Collections.Generic;
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

        public Listed_Produce(int LP_ID, int Farmer_ID, int Produce_ID, double Price, int Available_Quantity)
        {
            this.LP_ID = LP_ID;
            this.Farmer_ID = Farmer_ID;
            this.Produce_ID = Produce_ID;
            this.Price = Price;
            this.Available_Quantity = Available_Quantity;
        }
    }
}
