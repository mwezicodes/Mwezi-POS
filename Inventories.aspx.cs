using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Mwezi_POS.Sources.Inventory
{

    public partial class Inventories : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        public void BindGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM iteminventory", Konn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            InventoryTab.DataSource = dt;
            InventoryTab.DataBind();
        }
    }
}