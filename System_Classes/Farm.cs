using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Farm
    {
        public int Farm_ID { get; set; }
        public int Farmer_ID { get; set; }
        public string Farm_Name { get; set; }
        public string Farm_Address { get; set; }
        public Farm(int Farm_ID, int Farmer_ID, String Farm_Name, String Farm_Address)
        {
            this.Farm_ID = Farm_ID;
            this.Farmer_ID = Farmer_ID;
            this.Farm_Name = Farm_Name;
            this.Farm_Address = Farm_Address;
        }
    }
}
