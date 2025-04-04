using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Linq;

namespace Mwezi_POS.Sources.Sales
{
    public partial class Receipts : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                pnlEdit.Visible = false; 
            }
        }

        private void BindGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SaleItems", Konn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            ReceiptsTab.DataSource = dt;
            ReceiptsTab.DataBind();
        }

        protected void ReceiptsTab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int saleItemId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = row.RowIndex;
                if (ReceiptsTab.DataKeys[rowIndex].Value != null && int.TryParse(ReceiptsTab.DataKeys[rowIndex].Value.ToString(), out int saleId))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM SaleItems WHERE SaleId = @SaleId", Konn))
                    {
                        cmd.Parameters.AddWithValue("@SaleId", saleId);
                        SqlDataAdapter sd = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        ReceiptsTabe.DataSource = dt;
                        ReceiptsTabe.DataBind();
                        CalculateTotal();
                    }
                    MainV.Visible = false;
                    pnlEdit.Visible = true;

                }
            }
        }


        protected void ReceiptsTab_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ReceiptsTabe_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ReceiptsTabe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int saleItemId = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = row.RowIndex;
                if (ReceiptsTabe.DataKeys[rowIndex].Value != null && int.TryParse(ReceiptsTabe.DataKeys[rowIndex].Value.ToString(), out int saleItem))
                {
                        string saleId = row.Cells[1].Text.Trim();
                        SqlCommand cmd = new SqlCommand("DELETE FROM SaleItems WHERE SaleItemId = @SaleItemId", Konn);
                        cmd.Parameters.AddWithValue("@SaleItemId", saleItem);
                        cmd.Connection = Konn;
                        Konn.Open();
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("SELECT * FROM SaleItems WHERE SaleId = @SaleId", Konn);
                        cmd.Parameters.AddWithValue("@SaleId", saleId);
                        SqlDataAdapter sd = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        ReceiptsTabe.DataSource = dt;
                        ReceiptsTabe.DataBind();
                        CalculateTotal();

                        cmd = new SqlCommand("UPDATE Sales SET TotalAmount = '" + lblTotal.Text + "'  WHERE SaleId = @SaleId");
                        cmd.Parameters.AddWithValue("@SaleId", saleId);
                        cmd.Connection = Konn;
                        cmd.ExecuteNonQuery();


                    MainV.Visible = false;
                    pnlEdit.Visible = true;
                }
            }
        }


        protected void btnCompleteUp_Click(object sender, EventArgs e)
        {
            GridView existsDt = new GridView();

            if (Konn.State == ConnectionState.Closed)
            {
                Konn.Open();
            }

            foreach (GridViewRow row in ReceiptsTabe.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string salesId = row.Cells[0].Text.Trim(); 
                    string saleId = row.Cells[1].Text.Trim(); 
                    int quantity = Convert.ToInt32(((TextBox)row.FindControl("txtQuantity")).Text);
                   
                    using (SqlCommand cmda = new SqlCommand("UPDATE SaleItems SET Quantity = @Quantity WHERE SaleItemId = @SaleItemId", Konn))
                    {
                        cmda.Parameters.AddWithValue("@SaleItemId", salesId);
                        cmda.Parameters.AddWithValue("@Quantity", quantity);
                        cmda.ExecuteNonQuery();
                       
                    }

                    using (SqlCommand cmdb = new SqlCommand("SELECT * FROM SaleItems WHERE SaleId = @SaleId", Konn))
                    {
                        cmdb.Parameters.AddWithValue("@SaleId", saleId);
                        SqlDataAdapter sd = new SqlDataAdapter(cmdb);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        ReceiptsTabe.DataSource = dt;
                        ReceiptsTabe.DataBind();
                        CalculateTotal();
                    }

                    using (SqlCommand cmd = new SqlCommand("UPDATE Sales SET TotalAmount = @TotalAmount WHERE SaleId = @SaleId", Konn))
                    {
                        cmd.Parameters.AddWithValue("@TotalAmount", lblTotal.Text);
                        cmd.Parameters.AddWithValue("@SaleId", saleId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    
                    string totalAmount = lblTotal.Text;
                    string Cashier = Convert.ToString(Session["NAME"]);
                    string txhId = saleId;
                    GenerateReceipt(existsDt, totalAmount, Cashier, txhId);

                    MainV.Visible = false;
                    pnlEdit.Visible = true;
                }
            }

            Konn.Close();
        }




        protected void GenerateReceipt(GridView existingDt, string totalAmount, string Cashier, string txhId)
        {
           string receiptHtml = $@"
        <html>
        <head>
            <title>Receipt</title>
            <style>
                body {{ font-family: Arial, sans-serif; text-align: center; }}
                table {{ width: 100%; border-collapse: collapse; margin-top: 10px; }}
                th, td {{ border: 1px solid black; padding: 8px; text-align: left; }}
                th {{ background-color: #f2f2f2; }}
                .total-row {{ font-weight: bold; }}
            </style>
        </head>
        <body>
     <div class='container'>
        <h2>Receipt</h2> 
        <p><strong>Date (Edited):</strong> {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>
        <p><strong>Receipt No:</strong> {txhId}</p>
        <p><strong>Cashier:</strong> {Cashier}</p>
        <table>
            <tr>
                <th>Item</th>
                <th>Price</th>
                <th>Quantity</th>
                <th>Total</th>
            </tr>";

            foreach (GridViewRow row in ReceiptsTabe.Rows)
            {
                
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string itemName = row.Cells[3].Text; 
                    decimal price = Convert.ToDecimal(row.Cells[4].Text); 
                    int quantity = Convert.ToInt32(((TextBox)row.Cells[5].FindControl("txtQuantity")).Text);
                    decimal rowTotal = price * quantity;

                  
                    receiptHtml += $@"
            <tr>
                <td>{itemName}</td>
                <td>{price:F2}</td>  <!-- Format price to 2 decimal places -->
                <td>{quantity}</td>
                <td>{rowTotal:F2}</td>  <!-- Format row total to 2 decimal places -->
            </tr>";
                }
            }

            receiptHtml += $@"
        <tr class='total-row'>
            <td colspan='3'><strong>Total</strong></td>
            <td>{Convert.ToDecimal(totalAmount):F2}</td>
        </tr>
    </table>
    <br/>
    <button class='btn text-secondary btn-sm' onclick='window.print();'>Print Receipt</button>
</div>
</body>
</html>";
 string encodedHtml = HttpUtility.JavaScriptStringEncode(receiptHtml);

          
 string script = $@"
    var myWindow = window.open('', 'Receipt', 'width=600,height=400');
    myWindow.document.write('{encodedHtml}');
    myWindow.document.close();";

            ClientScript.RegisterStartupScript(this.GetType(), "PrintReceipt", script, true);
}


        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (GridViewRow row in ReceiptsTabe.Rows) 
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    decimal price = 0;
                    if (decimal.TryParse(row.Cells[4].Text.Trim(), out decimal parsedPrice)) 
                    {
                        price = parsedPrice;
                    }

                    TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;
                    int quantity = 1; 

                    if (txtQuantity != null && int.TryParse(txtQuantity.Text, out int parsedQuantity))
                    {
                        quantity = parsedQuantity;
                    }
                    total += quantity * price;
                }
            }

            lblTotal.Text = total.ToString();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            MainV.Visible = true;
            pnlEdit.Visible = false;
            BindGrid();
        }
    }

}