<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Makesale.aspx.cs" Inherits="Mwezi_POS.Sources.Sales.Makesale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <div class="container">
                  <div class="row g-3">
                       <div class="col-md-12 col-md-offset-1">
                           <div class="alert alert-success" role="alert">
                               <h3 class="alert-heading">Quick Sale </h3>
                               <p>Enter correct Item Id for quick search </p>
                           </div>
                       </div>
             </div>
               <div class="d-flex" role="search">
                <input type="text" id="srci" runat="server" class="form-control me-2"  placeholder="Search" aria-label="Search"/>
                <asp:Button runat="server" ID="Srch" CssClass="btn btn-outline-success"  type="submit" Text="Search" OnClick="Srch_Click"></asp:Button>
              </div>
        <br />
            <asp:GridView ID="InventoryTab" runat="server" EmptyDataText="Enter item id to begin sales." CssClass="table" AutoGenerateColumns="False" OnRowCommand="InventoryTab_RowCommand">
              <Columns>
                  <asp:TemplateField HeaderText="Item Id">
                        <ItemTemplate>
                            <asp:Label ID="lblItemId" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Product Name" ReadOnly="True" />
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged" TextMode="Number" CssClass="form-control" Text='<%# Eval("Quantity") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="editbtn" CssClass="btn text-primary btn-sm" CommandName="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>'><i class="fas fa-trash"></i></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
                        <br />
            <label> Total:</label>
            <asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label>
            <asp:LinkButton ID="btnCompleteSal" runat="server" OnClick="CompleteSale_Click" CssClass="btn text-success text-bg-light" ><i class="fas fa-check-circle"></i> Complete Sale </asp:LinkButton>

        </div>
</asp:Content>
