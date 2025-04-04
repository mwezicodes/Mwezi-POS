<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viewsales.aspx.cs" Inherits="Mwezi_POS.Sources.Sales.Viewsales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <div class="row g-3">
             <div class="col-md-12 col-md-offset-1">
                 <div class="alert alert-success" role="alert">
                     <h3 class="alert-heading">View Sales </h3>
                     <p>View all sales made</p>
                 </div>
         <div class="d-flex" role="search">
             <input type="text" id="srci" runat="server" class="form-control me-2" placeholder="Search" aria-label="Search" />
             <asp:Button runat="server" ID="Srch" CssClass="btn btn-outline-success" type="submit" Text="Search" ></asp:Button>
         </div>
        </div>
         <br />
 <div class="col-md-12 col-md-offset-1">
         <asp:GridView ID="SalesTab" runat="server" EmptyDataText="No sales made yet." CssClass="table" AutoGenerateColumns="true" OnRowDataBound="SalesTab_RowDataBound">

         </asp:GridView>
            </div>
     </div>
   </div>
</asp:Content>
