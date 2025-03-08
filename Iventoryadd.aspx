<%@ Page Title="Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Iventoryadd.aspx.cs" Inherits="Mwezi_POS.Sources.Inventory.Iventoryadd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container">
            <h2>Add Inventory Item</h2>
                <div class="mb-3">
                <label class="form-label">Item No.</label>
                <asp:TextBox ID="Idprimary" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Item Name</label>
                <asp:TextBox ID="itname" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Price</label>
                <asp:TextBox ID="itprice" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <div class="mb-3">
                <label class="form-label">Quantity</label>
                <asp:TextBox ID="itquantity" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="btn btn-success" OnClick="btnAddItem_Click" />
        </div>
</asp:Content>
