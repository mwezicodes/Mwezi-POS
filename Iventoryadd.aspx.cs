using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Mwezi_POS.Sources.Inventory
{
    public partial class Iventoryadd : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void AlertSuccess() 
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(),"alert", "swal('Success!', 'Inventory added!', 'success')", true);
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

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO iteminventory(ItemId, Name, Price, Quantity) VALUES( '"+ Idprimary.Text.ToString() + "', '"+itname.Text.ToString()+"', '"+itprice.Text.ToString()+"', '"+itquantity.Text.ToString()+"')";
            cmd.Connection = Konn;
            Konn.Open();
            cmd.ExecuteNonQuery();
            Konn.Close();
            AlertSuccess();
        }
    }
}