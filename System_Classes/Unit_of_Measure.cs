using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace CMPG223_Group_13
{
    public class Unit_of_Measure
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

        public static Unit_of_Measure getByID(int ID)
        {
            string sql = $"SELECT * FROM Unit_Of_Measure WHERE UOM_ID = {ID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt?.Rows?.Count > 0) return RowToData(dt.Rows[0]);
            else return null;
        }

        public static bool Exists(Unit_of_Measure uom)
        {
            if (getByID(uom.UOM_ID) == null) return false;
            else return true;
        }

        public static void insertIntoDB(Unit_of_Measure uom)
        {
            if (Exists(uom))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Unit_Of_Measure (UOM_Name, Abbreviation) " +
                    $"VALUES ('{uom.UOM_Name}', '{uom.Abbreviation}')";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateInDB(Unit_of_Measure uom)
        {
            if (Exists(uom))
            {
                string sql = $"UPDATE Unit_Of_Measure SET " +
                    $"UOM_Name = '{uom.UOM_Name}', " +
                    $"Abbreviation = '{uom.Abbreviation}' " +
                    $"WHERE UOM_ID = {uom.UOM_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling

            }
        }

        public static void deleteFromDB(Unit_of_Measure uom)
        {
            if (Exists(uom))
            {
                string sql = $"DELETE FROM Unit_Of_Measure WHERE UOM_ID = {uom.UOM_ID}";
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
         * 1) Unit_of_Measure uom = RowToData(dataTable.Rows[rowIndex])
         * 
         */

        //Returns Unit_of_Measure object from DataRow
        public static Unit_of_Measure RowToData(DataRow Row)
        {
            return new Unit_of_Measure((int)Row["UOM_ID"], Row["UOM_Name"].ToString(), Row["Abbreviation"].ToString());
        }



        /*
         * USAGE
         * 
         * 1) Unit_of_Measure uom = RowToData(gridView.SelectedRow)
         * 
         */

        //Returns Unit_of_Measure object from GridViewRow
        public static Unit_of_Measure RowToData(GridViewRow Row)
        {
            return RowToData((Row.DataItem as DataRowView).Row);        
        }
    }
}
