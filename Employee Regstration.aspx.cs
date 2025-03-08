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


namespace Mwezi_POS.Sources.Employees
{
    public partial class Employee_Regstration : System.Web.UI.Page
    {
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
            Country.Items.Insert(0, "Select");
        }
        public void Settings()
            {
        }
    }
}