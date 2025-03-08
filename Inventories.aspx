<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventories.aspx.cs" Inherits="Mwezi_POS.Sources.Inventory.Inventories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
               <div class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                <button class="btn btn-outline-success" type="submit">Search</button>
              </div>
        <br />
            <asp:GridView ID="InventoryTab" runat="server" EmptyDataText="No data available." CssClass="table" >
            </asp:GridView>
        </div>

</asp:Content>
