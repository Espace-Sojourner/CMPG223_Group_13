using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Unit_of_Measure
    {
        public int UOM_ID { get; set; }
        public string UOM_Name { get; set; }
        public string Abbreviation { get; set; }

        public Unit_of_Measure(int UOM_ID, string UOM_Name, string Abbreviation)
        {
            this.UOM_ID = UOM_ID;
            this.UOM_Name = UOM_Name;
            this.Abbreviation = Abbreviation;
        }

        public Unit_of_Measure getByID(int ID)
        {
            string sql = $"SELECT * FROM UOM_ID WHERE UOM_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            return new Unit_of_Measure((int)dt.Rows[0]["UOM_ID"], dt.Rows[0]["UOM_Name"].ToString(), dt.Rows[0]["Abbreviation"].ToString());
        }
    }
}
