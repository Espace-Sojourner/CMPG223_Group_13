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
        public int UOM_ID { get; set; }
        public Cart_Item(int LP_ID, string produceName, int quantity, int UOM_ID, double price) 
        {
            this.LP_ID = LP_ID;
            this.produceName = produceName;
            this.quantity = quantity; // Quantity to purchase
            this.UOM_ID = UOM_ID;
            this.price = price; // Calculated price based on quantity
        }

        override
        public string ToString()
        {
            return $"{produceName} {quantity}{Unit_of_Measure.getByID(UOM_ID)} {price:C}";
        }
    }
}