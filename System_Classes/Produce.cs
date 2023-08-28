using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Produce
    {
        public int Produce_ID { get; set; }
        public int UOM_ID { get; set; }
        public string Produce_Name { get; set; }
        public string Description { get; set; }
        public string Image_Link { get; set; }

        public Produce(int Produce_ID, int UOM_ID, string Produce_Name, string Description, string Image_Link)
        {
            this.Produce_ID = Produce_ID;
            this.UOM_ID = UOM_ID;
            this.Produce_Name = Produce_Name;
            this.Description = Description;
            this.Image_Link = Image_Link;
        }
    }
}
