using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Unit_of_Measure
    {
        int UOM_ID;
        string UOM_Name;
        string Abbreviation;

        public Unit_of_Measure(int UOM_ID, string UOM_Name, string Abbreviation)
        {
            this.UOM_ID = UOM_ID;
            this.UOM_Name = UOM_Name;
            this.Abbreviation = Abbreviation;
        }

        public void setName(string name)
        {
            UOM_Name = name;
        }

        public void setAbbreviation(string abbreviation)
        {
            Abbreviation = abbreviation;
        }

        public int getID()
        {
            return UOM_ID;
        }

        public string getName()
        {
            return UOM_Name;
        }

        public string getAbbreviation()
        {
            return Abbreviation;
        }


    }
}
