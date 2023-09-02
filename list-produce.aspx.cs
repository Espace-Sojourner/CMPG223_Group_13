using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CMPG223_Group_13.DatabaseHandler;

namespace CMPG223_Group_13
{
    public partial class listProduce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGV("Select * FROM Produce", "Produce", ref gvProduce);
        }

        protected void gvProduce_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produce selProduce = Produce.RowToData(gvProduce.SelectedRow);
            if (File.Exists(selProduce.Image_Link))
            {
                imgProduce.ImageUrl = selProduce.Image_Link;
            }
            else
            {
                imgProduce.ImageUrl = "./Resources/ProduceImages/Default.png";
            }
        }

        protected void tbSubSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = $"Select * FROM Produce WHERE Produce_Name LIKE '%{tbSubSearch.Text}%'";
            LoadGV(sql, "Produce", ref gvProduce);
        }
    }
}