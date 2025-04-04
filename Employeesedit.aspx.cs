using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Globalization;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Mwezi_POS.Sources.Employees
{
    public partial class Employeesedit : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                getCountry();
                mainEdit.Visible = false;
            }
            if (IsPostBack && Request["__EVENTTARGET"] == btnDelete.ClientID)
            {
                Delete_Click();
            }

        }

        private void BindData()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, Email, Name, Role FROM Employees", Konn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            lvUsers.DataSource = dt;
            lvUsers.DataBind();
        }


        protected void Edit_Click(object sender, EventArgs e)
        {
                mainEdit.Visible = true;
                childEdit.Visible = false;
                LinkButton btnEdit = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btnEdit.NamingContainer;
                string userId = row.Cells[1].Text;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE Id='" + userId + "'", Konn);
                Konn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Idno.Value = userId;
                    Email.Value = Convert.ToString(reader["Email"]);
                    Name.Value = Convert.ToString(reader["Name"]);
                    Phone.Value = Convert.ToString(reader["Phone"]);
                    DOB.Value = Convert.ToString(reader["DOB"]);
                    RD.Value = Convert.ToString(reader["RD"]);
                    Gender.SelectedValue = Convert.ToString(reader["Gender"]);
                    Address.Value = Convert.ToString(reader["Address"]);
                    City.Value = Convert.ToString(reader["City"]);
                    Country.SelectedValue = Convert.ToString(reader["Country"]);
                    Role.SelectedValue = Convert.ToString(reader["Role"]);
                }
                reader.Close();
            
        }

        public List<string> GetCountry()
        {
            List<string> list = new List<string>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo info in cultures)
            {
                RegionInfo info2 = new RegionInfo(info.LCID);
                if (!list.Contains(info2.EnglishName))
                {
                    list.Add(info2.EnglishName);
                    list.Sort();
                }
            }
            return list;
        }
        public void getCountry()
        {
            Country.DataSource = GetCountry();
            Country.DataBind();
            Country.SelectedValue = "Kenya";
        }

        public void AlertSuccesss()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'User Updated!', 'success')", true);
        }

        protected void childCls_Click(object sender, EventArgs e)
        {
            mainEdit.Visible = false;
            childEdit.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                string idn = Idno.Value.ToString();
                string nam = Name.Value.ToString();
                string gend = Gender.SelectedItem.ToString();
                string pcd = Role.SelectedItem.ToString();
                string mal = Email.Value.ToString();
                string phn = Phone.Value.ToString();
                string addr = Address.Value.ToString();
                string bday = DOB.Value.ToString();
                string cty = City.Value.ToString();
                string regdat = RD.Value.ToString();
                string contry = Country.SelectedItem.ToString();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Employees SET  Email = '"+mal+"', Name = '"+nam+"', Phone = '"+phn+"', DOB = '"+bday+"', RD = '"+regdat+"', Gender = '"+gend+"', Address = '"+addr+"', City = '"+cty+"', Country = '"+contry+"', Role = '"+pcd+"' WHERE Id = '"+idn+"' ";
                cmd.Connection = Konn;
                Konn.Open();
                cmd.ExecuteNonQuery();
                Konn.Close();
                userS();
                BindData();
                AlertSuccesss();
            }
        }
        protected void userS()
        {
            if (Request.HttpMethod == "POST")
            {
                string idn = Idno.Value.ToString();
                string nam = Name.Value.ToString();
                string mal = Email.Value.ToString();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE users SET  Email = '" + mal + "', Name = '" + nam + "' WHERE Id = '" + idn + "' ";
                cmd.Connection = Konn;
                Konn.Open();
                cmd.ExecuteNonQuery();
                Konn.Close();
            }
        }
        private void Delete_Click()
        {
                string idn = Idno.Value.ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE Id = '" +idn+ "'");
                cmd.Connection = Konn;
                Konn.Open();
                cmd.ExecuteNonQuery();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Delete Success!', 'success')", true);
                userD();
                BindData();
                mainEdit.Visible = false;
                childEdit.Visible = true;

        }

        private void userD()
        {
            if (Request.HttpMethod == "POST")
            {
                string idn = Idno.Value.ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE Id = '" + idn + "'");
                cmd.Connection = Konn;
                Konn.Open();
                cmd.ExecuteNonQuery();
                Konn.Close();
            }
        }
        public void AlertSuccessd()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Record Delete Success!', 'success')", true);
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
