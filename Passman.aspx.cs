using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Mwezi_POS.Sources.Employees
{
    public partial class Passman : System.Web.UI.Page
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
            if (IsPostBack && Request["__EVENTTARGET"] == childCls.ClientID)
            {
                enablE();
            }
        }

        public void BindGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, Email, Status FROM users", Konn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            usersTab.DataSource = dt;
            usersTab.DataBind();

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            mainEdit.Visible = true;
            childEdit.Visible = false;
            
            LinkButton btnEdit = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
            string uiId = row.Cells[1].Text;
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Id='" + uiId + "'", Konn);
            Konn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Idpr.Value = uiId;
                name.Value = reader["Name"].ToString();
                mail.Value = reader["Email"].ToString();
                pass.Value = reader["Password"].ToString();
            }
            Konn.Close();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pass.Value))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Please enter valid password!', 'error')", true);
                return;
            }
            string userId = Idpr.Value.ToString();
            string nam = name.Value.ToString();
            string email = mail.Value.ToString();
            string password = pass.Value.ToString();
            SqlCommand cmd = new SqlCommand("UPDATE users SET  Password='" + password + "' WHERE Id='" + userId + "'", Konn);
            Konn.Open();
            cmd.ExecuteNonQuery();
            Konn.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Update Success!', 'success')", true);
            BindGrid();
            mainEdit.Visible = false;
            childEdit.Visible = true;
        }

        protected void Delete_Click()
        {
            string userId = Idpr.Value.ToString();
            string stats = "Disabled";
            SqlCommand cmd = new SqlCommand("UPDATE users SET  Status='"+stats+"' WHERE Id='" + userId + "'", Konn);
            Konn.Open();
            cmd.ExecuteNonQuery();
            Konn.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Update Success!', 'success')", true);
            BindGrid();
            mainEdit.Visible = false;
            childEdit.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "confirmDelete", @"
        Swal.fire({
            title: 'Are you sure?',
            text: 'This action will disable a user!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, disable user!'
        }).then((result) => {
            if (result.isConfirmed) {__doPostBack('" + btnDelete.ClientID + "', ''); }    });    ", true);
        }

        protected void childCls_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "confirmUpdate", @"
        Swal.fire({
            title: 'Are you sure?',
            text: 'This action will enable a user!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, enable user!'
        }).then((result) => {
            if (result.isConfirmed) {__doPostBack('" + childCls.ClientID + "', ''); }    });    ", true);
        }
        

        protected void enablE()
        {
            string userId = Idpr.Value.ToString();
            string stats = "Active";
            SqlCommand cmd = new SqlCommand("UPDATE users SET  Status='" + stats + "' WHERE Id='" + userId + "'", Konn);
            Konn.Open();
            cmd.ExecuteNonQuery();
            Konn.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Update Success!', 'success')", true);
            BindGrid();
            mainEdit.Visible = false;
            childEdit.Visible = true;
        }
    }
}