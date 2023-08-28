using System;
using System.Collections.Generic;
using System.Data;
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
        public Farm(int Farm_ID, int Farmer_ID, string Farm_Name, string Farm_Address)
        {
            this.Farm_ID = Farm_ID;
            this.Farmer_ID = Farmer_ID;
            this.Farm_Name = Farm_Name;
            this.Farm_Address = Farm_Address;
        }

        public Farm getByID(int ID)
        {
            string sql = $"SELECT * FROM Farm_ID WHERE Farm_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            return new Farm((int)dt.Rows[0]["Farm_ID"], (int)dt.Rows[0]["Farmer_ID"], dt.Rows[0]["Farm_Name"].ToString(), dt.Rows[0]["Farm_Address"].ToString());
        }

    }
}
