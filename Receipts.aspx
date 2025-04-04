<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receipts.aspx.cs" Inherits="Mwezi_POS.Sources.Sales.Receipts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel runat="server" ID="MainV">
        <div class="row g-3">
            <div class="col-md-12 col-md-offset-1">
                <div class="alert alert-success" role="alert">
                    <h3 class="alert-heading">Receipts </h3>
                    <p>View all receipts - edit and print here</p>
                </div>
            </div>
            <div class="d-flex" role="search">
                <input type="text" id="srci" runat="server" class="form-control me-2" placeholder="Search" aria-label="Search" />
                <asp:Button runat="server" ID="Srch" CssClass="btn btn-outline-success" type="submit" Text="Search"></asp:Button>
            </div>
        <br />
    <div class="col-md-12 col-md-offset-1">
            <asp:GridView ID="ReceiptsTab" runat="server"  EmptyDataText="No receipts made yet." CssClass="table" OnRowDataBound="ReceiptsTab_RowDataBound" AutoGenerateColumns="false" OnRowCommand="ReceiptsTab_RowCommand" DataKeyNames="SaleId">
           <Columns>
        <asp:BoundField DataField="SaleItemId" HeaderText="SaleItemId" SortExpression="SaleItemId" Visible="False" />
        <asp:BoundField DataField="SaleId" HeaderText="SaleId" SortExpression="SaleId" />
        <asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" />
        <asp:BoundField DataField="Name" HeaderText="ItemName" SortExpression="Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"/>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="btnEdit" CssClass="btn text-secondary btn-sm" 
                    CommandName="EditRow" CommandArgument='<%# Eval("SaleItemId") %>'>
                    <i class="fas fa-edit"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
   </div>
     </div>
   </asp:Panel>
      <asp:Panel runat="server" ID="pnlEdit">
 <div class="row g-3">
                 <div class="col-md-12 col-md-offset-1">
                <div class="alert alert-warning" role="alert">
                    <h3 class="alert-heading">Receipts </h3>
                    <p>Edit and delete receipts here</p>
                </div>
            </div>
    <asp:GridView ID="ReceiptsTabe" runat="server" EmptyDataText="No receipts made yet." CssClass="table" AutoGenerateColumns="false" OnRowDataBound="ReceiptsTabe_RowDataBound" OnRowCommand="ReceiptsTabe_RowCommand" DataKeyNames="SaleItemId" >
       <Columns>
        <asp:BoundField DataField="SaleItemId" HeaderText="SaleItemId" SortExpression="SaleItemId"/>
        <asp:BoundField DataField="SaleId" HeaderText="SaleId" SortExpression="SaleId" />
        <asp:BoundField DataField="ItemId" HeaderText="ItemId" SortExpression="ItemId" />
        <asp:BoundField DataField="Name" HeaderText="ItemName" SortExpression="Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"/>
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:TextBox ID="txtQuantity" runat="server" AutoPostBack="true" TextMode="Number" Text='<%# Eval("Quantity") %>' CssClass="form-control" OnTextChanged="txtQuantity_TextChanged"/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="btnEdit" CssClass="btn text-secondary btn-sm" 
                    CommandName="EditRow" CommandArgument='<%# Eval("SaleItemId") %>'>
                    <i class="fas fa-trash"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
            </asp:GridView>
     </div>
           <label> Total: </label>
 <asp:Label ID="lblTotal" runat="server" Text="0.00"> </asp:Label>
 <asp:LinkButton ID="btnCompleteUp" runat="server" OnClick="btnCompleteUp_Click" CssClass="btn text-success text-bg-light" ><i class="fas fa-check-circle"></i> Complete Update </asp:LinkButton>  
<asp:LinkButton ID="btnClose" runat="server" OnClick="btnClose_Click" CssClass="btn text-secondary text-bg-light" ><i class="fas fa-check-circle"></i> Close </asp:LinkButton> 
 </asp:Panel>     
 </div>
</asp:Content>
