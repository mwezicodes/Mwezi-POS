using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mwezi_POS.Sources
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void employeesRca(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Employees/Employeereg.aspx");
        }
        public void employeesRc(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Employees/Employeesedit.aspx");
        }

        public void invtRc(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Inventory/Inventoryadd.aspx");
        }

        public void invtRce(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Inventory/Inventory.aspx");
        }
        public void invtRcv(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Inventory/Inventories.aspx");
        }
        public void refDb(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Dashboard.aspx");
        }

        protected void passRcb_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sources/Employees/Passman.aspx");
        }
    }
}