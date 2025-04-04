using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mwezi_POS.Sources.Sales
{
    public partial class Viewsales : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT SaleId, SaleDate, TotalAmount, Cashier FROM Sales", Konn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            SalesTab.DataSource = dt;
            SalesTab.DataBind();
        }

        protected void SalesTab_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

    }
}