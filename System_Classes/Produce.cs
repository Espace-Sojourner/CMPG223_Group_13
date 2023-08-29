using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Produce
    {
        public int Produce_ID { get; set; }
        public string Produce_Name { get; set; }
        public string Description { get; set; }
        public string Image_Link { get; set; }
        public int UOM_ID { get; set; }

        public Produce(int Produce_ID, string Produce_Name, string Description, string Image_Link, int UOM_ID)
        {
            this.Produce_ID = Produce_ID;
            this.Produce_Name = Produce_Name;
            this.Description = Description;
            this.Image_Link = Image_Link;
            this.UOM_ID = UOM_ID;
        }

        public static Produce getByID(int ID)
        {
            string sql = $"SELECT * FROM Produce_ID WHERE Produce_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            return new Produce((int)dt.Rows[0]["Produce_ID"], dt.Rows[0]["Produce_Name"].ToString(), dt.Rows[0]["Description"].ToString(), dt.Rows[0]["Image_Link"].ToString(), (int)dt.Rows[0]["UOM_ID"]);
        }

        public static bool Exists(Produce produce)
        {
            if (getByID(produce.Produce_ID) == null) return false;
            else return true;
        }

        public static void insertIntoDB(Produce produce)
        {
            if (Exists(produce))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Produce (Produce_ID, Produce_Name, Description, Image_Link, UOM_ID) " +
                    $"VALUES ({produce.Produce_ID}, '{produce.Produce_Name}', '{produce.Description}', '{produce.Image_Link}', {produce.UOM_ID})";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateInDB(Produce produce)
        {
            if (Exists(produce))
            {
                string sql = $"UPDATE Produce SET " +
                    $"Produce_Name = '{produce.Produce_Name}', " +
                    $"Description = '{produce.Description}', " +
                    $"Image_Link = '{produce.Image_Link}', " +
                    $"UOM_ID = {produce.UOM_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling

            }
        }
    }
}
