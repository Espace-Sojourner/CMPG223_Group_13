using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace CMPG223_Group_13.System_Classes
{
    public class Cart_Item
    {
        public int LP_ID { get; set; }
        public string produceName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string UOM { get; set; }
        public Cart_Item(int LP_ID, string produceName, int quantity, string UOM, double price) 
        {
            this.LP_ID = LP_ID;
            this.produceName = produceName;
            this.quantity = quantity; // Quantity to purchase
            this.UOM = UOM;
            this.price = price; // Calculated price based on quantity
        }

        override
        public string ToString()
        {
            return $"{produceName} {quantity}{UOM} {price:C}";
        }

        public string ToString(string type)
        {
            // create formatted text for output on order summary
            if (type.ToLower() == "order") return string.Format("{0,-15}{1,-10}{2,-10}{3,10}", produceName, quantity, UOM, price.ToString("C"));
            else return ToString();
        }
    }
}