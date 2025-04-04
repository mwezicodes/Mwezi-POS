using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Mwezi_POS
{
    public partial class Site : System.Web.UI.MasterPage
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && Request["__EVENTTARGET"] == btnUpdate.ClientID)
            {
                Update();
               
            }
            if (IsPostBack && Request["__EVENTTARGET"] == btnpss.ClientID)
            {
                Passup();
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Land/Login.aspx");
            Session["UID"] = "";
            Session["SIDUQ"] = "";
            Session["NAME"] = "";

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

        protected void LinkButn_Click(object sender, EventArgs e)
        {
            mainEdit.Visible = true;
            ContentPlaceHolder1.Visible = false; 
            mainEditp.Visible = false;
            getCountry();
            string userId = Convert.ToString(Session["UID"]);
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

        protected void btnLink_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder1.Visible = false;
            mainEditp.Visible = true;
            mainEdit.Visible = false;
            string uiId = Convert.ToString(Session["UID"]);
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Id='" + uiId + "'", Konn);
            Konn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Idpr.Value = uiId;
                nam.Value = reader["Name"].ToString();
                mail.Value = reader["Email"].ToString();
                pass.Value = reader["Password"].ToString();
            }
            Konn.Close();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "confirmUpdate", @"
            Swal.fire({
            title: 'Are you sure?',
            text: 'This action will update your record!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, update it!'
            }).then((result) => {
            if (result.isConfirmed) {__doPostBack('" + btnUpdate.ClientID + "', ''); }    });    ", true);

        }
        protected void Update()
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
                cmd.CommandText = "UPDATE Employees SET  Email = '" + mal + "', Name = '" + nam + "', Phone = '" + phn + "', DOB = '" + bday + "', RD = '" + regdat + "', Gender = '" + gend + "', Address = '" + addr + "', City = '" + cty + "', Country = '" + contry + "', Role = '" + pcd + "' WHERE Id = '" + idn + "' ";
                cmd.Connection = Konn;
                Konn.Open();
                cmd.ExecuteNonQuery();
                Konn.Close();
                userS();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alert", "swal('Success!', 'Record Update Success!', 'success');", true);

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


        protected void childCls_Click(object sender, EventArgs e)
        {
            mainEditp.Visible = false;
            mainEdit.Visible = false;
            ContentPlaceHolder1.Visible = true;
        }

        protected void btnpss_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "confirmUpdatePass", @"
            Swal.fire({
            title: 'Are you sure?',
            text: 'This action will update your password!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, update it!'
            }).then((result) => {
            if (result.isConfirmed) {__doPostBack('" + btnpss.ClientID + "', ''); }    });    ", true);

        }
        protected void Passup()
        {
            if (string.IsNullOrWhiteSpace(pass.Value))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alert", "swal('Error!', 'Please enter a valid password!', 'error');", true);
                return;
            }
            string userId = Idpr.Value.ToString();
            string password = pass.Value.ToString();
            SqlCommand cmd = new SqlCommand("UPDATE users SET  Password='" + password + "' WHERE Id='" + userId + "'", Konn);
            Konn.Open();
            cmd.ExecuteNonQuery();
            Konn.Close();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alert", "swal('Success!', 'Record Update Success!', 'success');", true);

        }



        protected void cls_Click(object sender, EventArgs e)
        {
            mainEditp.Visible = false;
            mainEdit.Visible = false;
            ContentPlaceHolder1.Visible = true;
        }

        protected void hmeb_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Dashboard.aspx");
        }

        protected void addub_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Employees/Employeereg.aspx");
        }

        protected void passb_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Employees/Passman.aspx");
        }

        protected void usereb_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Employees/Employeesedit.aspx");
        }

        protected void addib_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Inventory/Inventoryadd.aspx");
        }

        protected void editib_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Inventory/Inventory.aspx");
        }

        protected void recib_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Inventory/Inventories.aspx");
        }

        protected void btSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Sales/Makesale.aspx");
        }

        protected void btView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Sales/Viewsales.aspx");
        }

        protected void Recpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Sales/Receipts.aspx");
        }
    }
}