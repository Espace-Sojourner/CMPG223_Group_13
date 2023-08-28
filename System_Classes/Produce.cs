using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Classes
{
    class Produce
    {
        int Produce_ID;
        int UOM_ID;
        string Produce_Name;
        string Description;
        string Image_Link;

        public Produce(int Produce_ID, int UOM_ID, string Produce_Name, string Description, string Image_Link)
        {
            this.Produce_ID = Produce_ID;
            this.UOM_ID = UOM_ID;
            this.Produce_Name = Produce_Name;
            this.Description = Description;
            this.Image_Link = Image_Link;
        }

        public void setName(string name)
        {
            Produce_Name = name;
        }

        public void setDescription(string description)
        {
            Description = description;
        }

        public void setImageLink(string imageLink)
        {
            Image_Link = imageLink;
        }

        public void setUOMID(int uomID)
        {
            UOM_ID = uomID;
        }

        public int getID()
        {
            return Produce_ID;
        }

        public int getUOMID()
        {
            return UOM_ID;
        }

        public string getName()
        {
            return Produce_Name;
        }

        public string getDescription()
        {
            return Description;
        }

        public string getImageLink()
        {
            return Image_Link;
        }


    }
}
