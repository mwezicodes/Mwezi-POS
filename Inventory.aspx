<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Mwezi_POS.Sources.Inventory.Inventtory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <div class="container">
      <asp:Panel runat="server" ID="mainEdit">
            <h2>Add Inventory Item</h2>
           <div class="needs-validation">
                <div class="mb-3">
                <label class="form-label">Item No.</label>
                 <input type="number"  id="Idpr" runat="server" readonly="true" enabled="true" class="form-control" required="required"/>
                <div class="invalid-tooltip">
                Please enter valid item id.
              </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Item Name</label>
                <input type="text"  id="itnam" runat="server" enabled="true" class="form-control" required="required"/>
                <div class="invalid-tooltip">
                Please enter valid item name.
                </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Price</label>
                 <input type="number"  id="itprc" runat="server"  enabled="true" class="form-control" required="required"/>
                <div class="invalid-tooltip">
                Please enter valid price.
              </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Quantity</label>
                 <input type="number"  id="itqty" runat="server"  enabled="true" class="form-control" required="required"/>
                <div class="invalid-tooltip">
                Please enter quantity.
              </div>
        </div>
    </div>
 <div class="row g-3">
        <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnSave" runat="server" Text="Update Item" CssClass="btn btn-success btn-sm" OnClick="btnSave_Click" Width="100%" />
        </div>
             <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnDelete" runat="server" Text="Delete Item" CssClass="btn btn-danger btn-sm" OnClick="btnDelete_Click" Width="100%" />
        </div>
       <div class="col-md-4 col-md-offset-1">
          <asp:Button runat="server" ID="childCls" Text="Close" OnClick="childCls_Click" CssClass="btn btn-primary btn-sm" Width="100%"></asp:Button>
        </div>
   </div>
      </asp:Panel>
        <asp:Panel runat="server" ID="childEdit">
               <div class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                <button class="btn btn-success btn-sm" type="submit">Search</button>
              </div>
        <br />
            <asp:GridView ID="InventoryTab" runat="server" EmptyDataText="No data available."  CssClass="table" >
            <Columns>
                 <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="editbtn" CssClass="btn text-primary btn-sm" OnClick="Edit_Click"><i class="fas fa-edit"></i></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       </asp:Panel>
      </div>
</asp:Content>
