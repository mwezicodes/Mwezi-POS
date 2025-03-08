<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Mwezi_POS.Sources.Inventory.Inventtory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function () {
            $(".edit-btn").click(function () {
                var row = $(this).closest("tr");
                row.find("input").prop("disabled", false);
                row.find(".save-btn").prop("hidden", false);
                row.find(".save-btn").show();
                $(this).hide();
            });           

        });
    </script>
        

    <div class="container">
               <div class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                <button class="btn btn-outline-success" type="submit">Search</button>
              </div>
        <br />
            <asp:GridView ID="InventoryTab" runat="server" EmptyDataText="No data available." AutoGenerateColumns="False" CssClass="table" >
            <Columns>
                  <asp:TemplateField HeaderText="ItemId">
                    <ItemTemplate>
                        <asp:TextBox ID="itemId" CssClass="grid-input" ReadOnly="true" runat="server" Text='<%# Bind("ItemId") %>' ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:TextBox ID="itemName" CssClass="grid-input" runat="server" Text='<%# Bind("Name") %>' Disabled="true"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:TextBox ID="itemPrice" CssClass="grid-input" runat="server" Text='<%# Bind("Price") %>' Disabled="true"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Quantity">
                  <ItemTemplate>
                      <asp:TextBox ID="itemQuantity" CssClass="grid-input" runat="server" Text='<%# Bind("Quantity") %>' Disabled="true"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <div class="action-buttons">
                        <button type="button" class="edit-btn">Edit</button>
                        <asp:Button runat="server" Text="Save" CssClass="save-btn" OnClick="SaveInventory_Click"  Hidden="true"></asp:Button>
                        <asp:Button runat="server" Text="Delete" CssClass="delete-btn"  ></asp:Button>
                        </div>
                        </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>
