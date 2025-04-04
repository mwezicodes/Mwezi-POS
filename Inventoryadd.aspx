<%@ Page Title="Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventoryadd.aspx.cs" Inherits="Mwezi_POS.Sources.Inventory.Inventoryadd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container">
            <h2>Add Inventory Item</h2>
           <div class="needs-validation" >
                <div class="mb-3">
                <label class="form-label">Item No.</label>
                 <input type="number"  id="Idpr" runat="server" enabled="true" class="form-control" required="required"/>
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
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="btn btn-success" OnClick="btnAddItem_Click" />
        </div>
        </div>
</asp:Content>
