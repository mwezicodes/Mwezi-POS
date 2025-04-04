using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxMind.GeoIP2.Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Mwezi_POS.Sources.Employees
{
    public partial class Employeereg : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            getCountry();
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
        public void AlertSuccess()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Success!', 'Employee added successfuly!', 'success')", true);
        }
        public void AlertError()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Wrong Information!', 'error')", true);
        }
        public void AlertInfo()
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Info!', 'well!', 'info')", true);
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                string idn = Idno.Value.ToString();
                string lnam = LastName.Value.ToString();
                string fnam = FirstName.Value.ToString();
                string mnam = MiddleName.Value.ToString();
                string gend = Gender.SelectedItem.ToString();
                string pcd = Role.SelectedItem.ToString();
                string mal = Email.Value.ToString();
                string phn = Phone.Value.ToString();
                string addr = Address.Value.ToString();
                string bday = DOB.Value.ToString();
                string cty = City.Value.ToString();
                string regdat = RD.Value.ToString();
                string contry = Country.SelectedItem.ToString();
                string nam = fnam + " " + mnam + " " + lnam;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO Employees(Id, Email, Name, Phone, DOB, RD, Gender, Address, City, Country, Role) VALUES( '" + idn + "', '" + mal + "', '" + nam + "', '" + phn + "', '" + bday + "', '" + regdat + "', '" + gend + "', '" + addr + "', '" + cty + "','" + contry + "', '" + pcd + "')";
                cmd.Connection = Konn;
                Konn.Open();
                cmd.ExecuteNonQuery();
                Konn.Close();
                userS();
                AlertSuccess();
            }
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Dashboard.aspx");
        }
        protected void userS()
        {
            if (Request.HttpMethod == "POST")
            {
                string idn = Idno.Value.ToString();
                string mal = Email.Value.ToString();
                string lnam = LastName.Value.ToString();
                string fnam = FirstName.Value.ToString();
                string mnam = MiddleName.Value.ToString();
                string nam = fnam + " " + mnam + " " + lnam;
                string stats = "Active";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO users(Id, Email, Name, Password, Status) VALUES( '" + idn + "', '" + mal + "','" + nam + "', '" + idn + "','" + stats + "')";
                cmd.Connection = Konn;
                Konn.Open();
                cmd.ExecuteNonQuery();
                Konn.Close();
            }
        }
    }
}