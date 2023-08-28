using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Listed_Produce
    {
        int LP_ID;
        int Farmer_ID;
        int Produce_ID;
        double Price;
        int Available_Quantity;
        DateTime Expiration_Dates;

        public Listed_Produce(int LP_ID, int Farmer_ID, int Produce_ID, double Price, int Available_Quantity)
        {
            this.LP_ID = LP_ID;
            this.Farmer_ID = Farmer_ID;
            this.Produce_ID = Produce_ID;
            this.Price = Price;
            this.Available_Quantity = Available_Quantity;
        }

        public void setFarmerID(int farmer_ID) 
        {
            Farmer_ID = farmer_ID;
        }

        public void setProduceID(int produce_ID)
        {
            Produce_ID = produce_ID;
        }

        public void setPrice(double price)
        {
            Price = price;
        }

        public void setAvailableQuantity(int quantity)
        {
            Available_Quantity = quantity;
        }

        public void setExpirationDates(DateTime expirationDate)
        {
            Expiration_Dates = expirationDate;
        }

        public int getID()
        {
            return LP_ID;
        }

        public int getFarmerID()
        {
            return Farmer_ID;
        }

        public int getProduceID()
        {
            return Produce_ID;
        }

        public double getPrice()
        {
            return Price;
        }

        public int getAvailableQuantity()
        {
            return Available_Quantity;
        }

        public DateTime getExpirationDates()
        {
            return Expiration_Dates;
        }
    }
}
