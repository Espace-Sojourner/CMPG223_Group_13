using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public class Farm
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

        public static Farm getByID(int ID)
        {
            string sql = $"SELECT * FROM Farm_ID WHERE Farm_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt?.Rows?.Count > 0) return RowToData(dt.Rows[0]);
            else return null;
        }

        public static bool Exists(Farm farm)
        {
            if (getByID(farm.Farm_ID) == null) return false;
            else return true;
        }

        public static void insertIntoDB(Farm farm)
        {
            if (Exists(farm))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Farm (Farmer_ID, Farm_Name, Farm_Address) " +
                    $"VALUES ({farm.Farmer_ID}, '{farm.Farm_Name}', '{farm.Farm_Address}')";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateInDB(Farm farm)
        {
            if (Exists(farm))
            {
                string sql = $"UPDATE Farm SET " +
                    $"Farmer_ID = {farm.Farmer_ID}, " +
                    $"Farm_Name = '{farm.Farm_Name}', " +
                    $"Farm_Address = '{farm.Farm_Address}' " +
                    $"WHERE Farm_ID = {farm.Farm_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling

            }
        }

        public static void deleteFromDB(Farm farm)
        {
            if (Exists(farm))
            {
                string sql = $"DELETE FROM Farm WHERE Farm_ID = {farm.Farm_ID}";
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
         * 1) Farm farm = RowToData(dataTable.Rows[rowIndex])
         * 
         */

        //Returns Farm object from DataRow
        public static Farm RowToData(DataRow Row)
        {
            return new Farm((int)Row["Farm_ID"], (int)Row["Farmer_ID"], Row["Farm_Name"].ToString(), Row["Farm_Address"].ToString());
        }



        /*
         * USAGE
         * 
         * 1) Farm farm = RowToData(gridView.SelectedRow)
         * 
         */

        //Returns Farm object from GridViewRow
        public static Farm RowToData(GridViewRow Row)
        {
            return getByID(int.Parse(Row.Cells[1].Text));
        }

    }
}
