using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxMind.GeoIP2.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

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
                mainEdit.Visible = false;
            }
            if (IsPostBack && Request["__EVENTTARGET"] == btnDelete.ClientID)
            {
                Delete_Click();
            }

            if (IsPostBack && Request["__EVENTTARGET"] == btnSave.ClientID)
            {
                Save_Click();
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


        protected void Edit_Click(object sender, EventArgs e) 
        {
            mainEdit.Visible = true;
            childEdit.Visible = false;
            LinkButton btnEdit = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
            string itmId = row.Cells[1].Text;
            SqlCommand cmd = new SqlCommand("SELECT * FROM iteminventory WHERE ItemId='" + itmId + "'", Konn);
            Konn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Idpr.Value = itmId;
                itnam.Value = Convert.ToString(reader["Name"]);
                itprc.Value = Convert.ToString(reader["Price"]);
                itqty.Value = Convert.ToString(reader["Quantity"]);
            }
            reader.Close();
        }

        private void Save_Click()
        {
            string itemId = Idpr.Value.ToString();
            string name = itnam.Value.ToString();
            string price = itprc.Value.ToString();
            string quantity = itqty.Value.ToString();
            SqlCommand cmd = new SqlCommand("UPDATE iteminventory SET Name = '" + name + "', Price = '" + price + "', Quantity = '" + quantity + "' WHERE ItemId = '" + itemId + "'");
            cmd.Connection = Konn;
            Konn.Open();
            cmd.ExecuteNonQuery();
            Konn.Close();
            BindGrid();
            AlertSuccesss();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "confirmUpdate", @"
            Swal.fire({
            title: 'Are you sure?',
            text: 'This action will update a record!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, Update record!'
             }).then((result) => {
            if (result.isConfirmed) {__doPostBack('" + btnSave.ClientID + "', ''); }    });    ", true);
        }

        private void Delete_Click()
        {
            string itmId = Idpr.Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM iteminventory WHERE ItemId = '" + itmId + "'");
            cmd.Connection = Konn;
            Konn.Open();
            cmd.ExecuteNonQuery(); 
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Delete Success!', 'success')", true);
            mainEdit.Visible = false;
            childEdit.Visible = true;
            BindGrid();
        }

        protected void childCls_Click(object sender, EventArgs e)
        {
            mainEdit.Visible = false;
            childEdit.Visible = true;
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "confirmDelete", @"
        Swal.fire({
            title: 'Are you sure?',
            text: 'This action cannot be undone!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {__doPostBack('" + btnDelete.ClientID + "', ''); }    });    ", true);

        }
    }
    
}