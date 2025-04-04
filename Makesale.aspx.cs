using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mwezi_POS.Sources.Sales
{
    public partial class Makesale : System.Web.UI.Page
    {
        SqlConnection Konn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            DataTable existingDt = ViewState["InventoryData"] as DataTable;
            if (existingDt == null)
            {
                return;
            }

            foreach (GridViewRow gRow in InventoryTab.Rows)
            {
                Label lblItemId = gRow.FindControl("lblItemId") as Label;
                TextBox txtQuantity = gRow.FindControl("txtQuantity") as TextBox;

                if (lblItemId != null && txtQuantity != null)
                {
                    string itemId = lblItemId.Text;
                    if (int.TryParse(txtQuantity.Text, out int newQuantity))
                    {
                        foreach (DataRow dataRow in existingDt.Rows)
                        {
                            if (dataRow["ItemId"].ToString() == itemId)
                            {
                                dataRow["Quantity"] = newQuantity;
                                break;
                            }
                        }
                    }
                }
            }

            ViewState["InventoryData"] = existingDt; 
            CalculateTotal(); 
        }


        protected void Srch_Click(object sender, EventArgs e)
        {
            string pid = srci.Value;
            if (string.IsNullOrEmpty(pid))
            {
                srci.Style["border"] = "2px solid red";
                return;
            }
            SqlCommand cmd = new SqlCommand("SELECT ItemId, Name, Price FROM iteminventory WHERE ItemId = @pid", Konn);
            cmd.Parameters.AddWithValue("@pid", pid);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            srci.Value = "";

            if (dt.Rows.Count == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'Enter correct Item ID or the item is missing!', 'error')", true);
                return;
            }
            DataTable existingDt = ViewState["InventoryData"] as DataTable;
            if (existingDt == null)
            {
                existingDt = new DataTable();
                existingDt.Columns.Add("ItemId", typeof(string));
                existingDt.Columns.Add("Name", typeof(string));
                existingDt.Columns.Add("Price", typeof(decimal));
                existingDt.Columns.Add("Quantity", typeof(int));
            }

            bool itemExists = false;
            foreach (GridViewRow gRow in InventoryTab.Rows)
            {
                Label lblItemId = gRow.FindControl("lblItemId") as Label;
                TextBox txtQuantity = gRow.FindControl("txtQuantity") as TextBox;

                if (lblItemId != null && txtQuantity != null && lblItemId.Text == pid)
                {
                    if (int.TryParse(txtQuantity.Text, out int currentQuantity))
                    {
                        int newQuantity = currentQuantity + 1;
                        txtQuantity.Text = newQuantity.ToString();
                        foreach (DataRow dataRow in existingDt.Rows)
                        {
                            if (dataRow["ItemId"].ToString() == pid)
                            {
                                dataRow["Quantity"] = newQuantity;
                                itemExists = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (!itemExists)
            {
                DataRow newRow = existingDt.NewRow();
                newRow["ItemId"] = dt.Rows[0]["ItemId"];
                newRow["Name"] = dt.Rows[0]["Name"];
                newRow["Price"] = dt.Rows[0]["Price"];
                newRow["Quantity"] = 1;
                existingDt.Rows.Add(newRow);
            }
            ViewState["InventoryData"] = existingDt;
            InventoryTab.DataSource = existingDt;
            InventoryTab.DataBind();

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (GridViewRow row in InventoryTab.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    decimal price = Convert.ToDecimal(row.Cells[2].Text.ToString());
                    TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                    int quantity = int.TryParse(txtQuantity.Text, out int qty) ? qty : 1;
                    total += quantity * price;
                }
            }
            lblTotal.Text = Convert.ToString(total);
        }

        protected void InventoryTab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                DataTable existingDt = ViewState["InventoryData"] as DataTable;

                if (existingDt != null && existingDt.Rows.Count > rowIndex)
                {
                    existingDt.Rows.RemoveAt(rowIndex);
                    ViewState["InventoryData"] = existingDt;
                    InventoryTab.DataSource = existingDt;
                    InventoryTab.DataBind();
                    CalculateTotal();
                }
            }
        }

        protected void CompleteSale_Click(object sender, EventArgs e)
        {
            DataTable existingDt = ViewState["InventoryData"] as DataTable;
            if (existingDt == null || existingDt.Rows.Count == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error!', 'No items in the cart!', 'error')", true);
                return;
            }

            int txh = 0;
            decimal totalAmount = Convert.ToDecimal(lblTotal.Text);
            int Sid = Convert.ToInt32(Session["SIDUQ"]);
            string Cashier = Convert.ToString(Session["NAME"]);

            try
            {
                if (Konn.State == ConnectionState.Closed)
                {
                    Konn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT MAX(SaleId) FROM Sales", Konn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader[0] != DBNull.Value)
                        {
                            txh = Convert.ToInt32(reader[0]);
                        }
                    }
                }

                int txhId = txh + 1; 

                
                using (SqlCommand cmdSale = new SqlCommand("INSERT INTO Sales (SaleId, TotalAmount, SID, Cashier) VALUES (@SaleId, @TotalAmount, @SID, @Cashier)", Konn))
                {
                    cmdSale.Parameters.AddWithValue("@SaleId", txhId);
                    cmdSale.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmdSale.Parameters.AddWithValue("@SID", Sid);
                    cmdSale.Parameters.AddWithValue("@Cashier", Cashier);
                    cmdSale.ExecuteNonQuery();
                }

                foreach (DataRow row in existingDt.Rows)
                {
                    using (SqlCommand cmdItem = new SqlCommand("INSERT INTO SaleItems (SaleId, ItemId, Name, Price, Quantity) VALUES (@SaleId, @ItemId, @Name, @Price, @Quantity)", Konn))
                    {
                        cmdItem.Parameters.AddWithValue("@SaleId", txhId);
                        cmdItem.Parameters.AddWithValue("@ItemId", row["ItemId"]);
                        cmdItem.Parameters.AddWithValue("@Name", row["Name"]);
                        cmdItem.Parameters.AddWithValue("@Price", row["Price"]);
                        cmdItem.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        cmdItem.ExecuteNonQuery();
                    }
                }

                GenerateReceipt(existingDt, totalAmount, Cashier, txhId);
               
                ViewState["InventoryData"] = null;
                InventoryTab.DataSource = null;
                InventoryTab.DataBind();
                lblTotal.Text = "0.00";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", $"swal('Error!', '{ex.Message}', 'error')", true);
            }
            finally
            {
                if (Konn.State == ConnectionState.Open)
                {
                    Konn.Close();
                }
            }
        }


        private void GenerateReceipt(DataTable dt, decimal totalAmount, string Cashier, double txhId)
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
            <div class=""container"">
            <h2>Receipt</h2> 
            <h9>Date: {DateTime.Now}</h9>
            <p><strong>Receipt No:</strong> {txhId} </p>
            <p><strong>Cashier:</strong> {Cashier}</p>
            <table>
                <tr>
                    <th>Item</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Total</th>
                </tr>";

            // Add rows dynamically
            foreach (DataRow row in dt.Rows)
            {
                decimal rowTotal = (decimal)row["Price"] * (int)row["Quantity"];
                receiptHtml += $@"
                <tr>
                    <td>{row["Name"]}</td>
                    <td>{row["Price"]}</td>
                    <td>{row["Quantity"]}</td>
                    <td>{rowTotal}</td>
                </tr>";
            }

            // Add total row
            receiptHtml += $@"
                <tr class='total-row'>
                    <td colspan='3'><strong>Total</strong></td>
                    <td>{totalAmount}</td>
                </tr>
            </table>
            <br/>
            <button class = ""btn text-secondary btn-sm"" onclick='window.print();'>Print Receipt</button>
        </div>
        </body>
        </html>";

            // Escape quotes properly
            receiptHtml = receiptHtml.Replace("'", "\\'").Replace("\n", "").Replace("\r", "");

            // JavaScript script to open the receipt in a new window
            string script = $@"
        var myWindow = window.open('', 'Receipt', 'width=600,height=400');
        myWindow.document.write('{receiptHtml}');
        myWindow.document.close();";

            ClientScript.RegisterStartupScript(this.GetType(), "PrintReceipt", script, true);
        }



    }

}