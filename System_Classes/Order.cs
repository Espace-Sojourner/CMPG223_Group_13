using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Order
    {
        int Order_ID;
        int Client_ID;
        int Farmer_ID;
        int LP_ID;
        DateTime Order_Date;
        double Order_Price;
        int Bought_Quantity;

        public Order(int Order_ID, int Client_ID, int Farmer_Id, int LP_ID, DateTime Order_Date, double Order_Price, int Bought_Quantity)
        {
            this.Order_ID = Order_ID;
            this.Client_ID = Client_ID;
            this.Farmer_ID = Farmer_Id;
            this.LP_ID = LP_ID;
            this.Order_Date = Order_Date;
            this.Order_Price = Order_Price;
        }

        public void setClientID(int clientID)
        {
            Client_ID = clientID;
        }

        public void setFarmerID(int farmerID)
        {
            Farmer_ID = farmerID;
        }

        public void setLP_ID(int lpID)
        {
            LP_ID = lpID;
        }

        public void setDate(DateTime orderDate)
        {
            Order_Date = orderDate;
        }

        public void setOrderPrice(double price) 
        {
            Order_Price = price; 
        }

        public void setBoughtQuantity(int boughtQuantity)
        {
            Bought_Quantity = boughtQuantity;
        }

        public int getID()
        {
            return Order_ID;
        }

        public int getClientID()
        {
            return Client_ID;
        }

        public int getFarmerID()
        {
            return Farmer_ID;
        }

        public int getLP_ID()
        {
            return LP_ID;
        }

        public int GetOrder_ID()
        {
            return Order_ID;
        }

        public DateTime getDate()
        {
            return Order_Date;
        }

        public double getOrderPrice()
        {
            return Order_Price;
        }

        public int getBoughtQuantity()
        {
            return Bought_Quantity;
        }
    }
}
