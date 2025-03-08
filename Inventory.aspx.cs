using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mwezi_POS.Sources.Inventory
{
    public partial class Inventtory : System.Web.UI.Page
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




        protected void SaveInventory_Click(object sender, EventArgs e)
        {
            Button btnSave = (Button)sender;
            GridViewRow row = (GridViewRow)btnSave.NamingContainer;
            string itemId = ((TextBox)row.FindControl("itemId")).Text;
            string name = ((TextBox)row.FindControl("itemName")).Text;
            string price = ((TextBox)row.FindControl("itemPrice")).Text;
            string quantity = ((TextBox)row.FindControl("itemQuantity")).Text;
            SqlCommand cmd = new SqlCommand("UPDATE iteminventory SET Name = '" + name + "', Price = '" + price + "', Quantity = '" + quantity + "' WHERE ItemId = '" + itemId + "'");
            cmd.Connection = Konn;
            Konn.Open();
            cmd.ExecuteNonQuery();
            Konn.Close();
            BindGrid();
            AlertSuccesss();

        }

        protected void DeleteInventory_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            string itemId = ((TextBox)row.FindControl("itemId")).Text;
            SqlCommand cmd = new SqlCommand("DELETE FROM iteminventory WHERE ItemId = '" + itemId + "'");
            cmd.Connection = Konn;
            Konn.Open();
            cmd.ExecuteNonQuery();                
            BindGrid();
            AlertSuccessd();
        }

        public void AlertSuccesss()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Updated added!', 'success')", true);
        }
        public void AlertSuccessd()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Delete Success!', 'success')", true);
        }
        public void AlertWarning()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Warning!', 'Are you sure!', 'warning')", true);
        }
        public void AlertError()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Wrong Information!', 'error')", true);
        }
        public void AlertInfo()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Info!', 'well!', 'info')", true);
        }
    }
}