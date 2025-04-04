<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Mwezi_POS.Sources.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
     <div class="content">
         <div class="row g-3" >
         <div class="col-md-4 col-md-offset-1">
        <div class="card mb-3">
              <div class="card-header">
                User Records <i class="fa fa-user-group"></i>
              </div>
              <div class="row g-0">
                <div class="col-md-10">
            <div class="card-body">
             <asp:LinkButton runat="server" CssClass="btn text-success text-bg-light btn-sm" OnClick="employeesRca"> <i class="fas fa-user-plus"></i> </asp:LinkButton>
            <asp:LinkButton runat="server" class="btn text-primary text-bg-light btn-sm" OnClick="employeesRc"><i class="fa fa-user"></i> <i class="fa fa-pencil"></i>  </asp:LinkButton>
            <asp:LinkButton runat="server" ID="passRcb" class="btn text-secondary text-bg-light btn-sm" OnClick="passRcb_Click"><i class="fa fa-user"></i>  <i class="fa fa-key"></i>  </asp:LinkButton>
        </div>
     </div>
    <div class="col-md-2 align-content-center">
    <asp:LinkButton runat="server" class="btn text-primary text-bg-light btn-sm"> <i class="fas fa-download"></i> </asp:LinkButton>
    </div>
    </div>
    </div>
   </div>
         <div class="col-md-4 col-md-offset-1">
        <div class="card mb-3">
            <div class="card-header">Recent Activities <i class="fas fa-history"></i></div>
              <div class="row g-0">
                <div class="col-md-10">
            <div class="card-body">
             <asp:LinkButton class="btn text-secondary text-bg-light btn-sm"  runat="server" OnClick="refDb"><i class="fas fa-sync"></i></asp:LinkButton>
           </div>
        </div>
            <div class="col-md-2 align-content-center">
            </div>
    </div>
</div>
</div>
         <div class="col-md-4 col-md-offset-1">
        <div class="card mb-3">
            <div class="card-header">Inventory <i class="fas fa-boxes-stacked"></i> </div>
              <div class="row g-0">
                <div class="col-md-10">
            <div class="card-body">
            <asp:LinkButton runat="server" class="btn text-secondary text-bg-light btn-sm" OnClick="invtRc"><i class="fas fa-file"></i> <i class="fas fa-plus"></i></asp:LinkButton>
              <asp:LinkButton runat="server" class="btn text-success text-bg-light btn-sm" OnClick="invtRce"><i class="fas fa-edit"></i></asp:LinkButton>
             <asp:LinkButton runat="server" class="btn text-primary text-bg-light btn-sm" OnClick="invtRcv"><i class="fas fa-file-alt"></i></asp:LinkButton>
            </div>
        </div>
            <div class="col-md-2 align-content-center">
        </div>
        </div>
    </div>
   </div>
</div>
</div>
</div>
</asp:Content>
