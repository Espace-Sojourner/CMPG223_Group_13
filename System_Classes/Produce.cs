using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public class Produce
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
            string sql = $"SELECT * FROM Produce WHERE Produce_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt?.Rows?.Count > 0) return RowToData(dt.Rows[0]);
            else return null;
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
                string sql = $"INSERT INTO Produce (Produce_Name, Description, Image_Link, UOM_ID) " +
                    $"VALUES ('{produce.Produce_Name}', '{produce.Description}', '{produce.Image_Link}', {produce.UOM_ID})";
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
                    $"UOM_ID = {produce.UOM_ID} " +
                    $"WHERE Produce_ID = {produce.Produce_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling

            }
        }

        public static void deleteFromDB(Produce produce)
        {
            if (Exists(produce))
            {
                string sql = $"DELETE FROM Produce WHERE Produce_ID = {produce.Produce_ID}";
                DatabaseHandler.executeDelete(sql);
            }
            else
            {
                //Error Handling

            }
        }



        /*
         * USAGE
         * 
         * 1) Produce produce = RowToFarmer(dataTable.Rows[rowIndex])
         * 
         */

        //Returns Produce object from DataRow
        public static Produce RowToData(DataRow Row)
        {
            return new Produce((int)Row["Produce_ID"], Row["Produce_Name"].ToString(), Row["Description"].ToString(), Row["Image_Link"].ToString(), (int)Row["UOM_ID"]);
        }



        /*
         * USAGE
         * 
         * 1) Produce produce = RowToData(gridView.SelectedRow)
         * 
         */

        //Returns Produce object from GridViewRow
        public static Produce RowToData(GridViewRow Row)
        {
            return RowToData((Row.DataItem as DataRowView).Row);
        }
    }
}
