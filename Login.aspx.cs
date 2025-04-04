using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaxMind.GeoIP2.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Configuration;

namespace Mwezi_POS.Land
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = username.Value;
            string pwd = password.Value;
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Id='" + userId + "' AND Password='"+pwd+"'", Konn);
            Konn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Session["SIDUQ"] = Convert.ToString(reader["SID"]);
                Session["NAME"] = Convert.ToString(reader["Name"]);
                Session["UID"] = Convert.ToString(reader["Id"]);
                Response.Redirect("~/Sources/Dashboard.aspx");
                Konn.Close();
            }
            reader.Close();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Invalid username and password!', 'error')", true);
            Konn.Close();
        }
    }
}