<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Passman.aspx.cs" Inherits="Mwezi_POS.Sources.Employees.Passman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <div class="container">
      <div class="row g-3">
        <div class="col-md-12 col-md-offset-1">
         <div class="alert alert-success" role="alert">
             <h3 class="alert-heading">Password Manager</h3>
                  <p>Update disable and enable user here</p>
              </div>
           </div>
       </div>
      <asp:Panel runat="server" ID="mainEdit">
            <div class="needs-validation">
                <div class="mb-3">
                <label class="form-label">Id</label>
                 <input type="number"  id="Idpr" runat="server" readonly="true" enabled="true" class="form-control" cssclass="input-sm" required="required"/>
                <div class="invalid-tooltip">
                Please enter valid item id.
              </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Name</label>
                <input type="text"  id="name" runat="server" enabled="true" class="form-control" cssclass="input-sm" required="required"/>
                <div class="invalid-tooltip">
                Please enter valid  name.
                </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                 <input type="email"  id="mail" runat="server"  enabled="true" class="form-control" cssclass="input-sm" required="required"/>
                <div class="invalid-tooltip">
                Please enter valid price.
              </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                 <input type="password"  id="pass" runat="server"  enabled="true" class="form-control" cssclass="input-sm"/>
                <div class="invalid-tooltip">
                Please enter valid password.
              </div>
        </div>
    </div>
 <div class="row g-3">
        <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnAddItem" runat="server" Text="Update Password" CssClass="btn btn-success btn-sm" OnClick="Save_Click" Width="100%" />
        </div>
             <div class="col-md-4 col-md-offset-1">
            <asp:Button ID="btnDelete" runat="server" Text="Disable" CssClass="btn btn-danger btn-sm" OnClick="btnDelete_Click" Width="100%" />
        </div>
       <div class="col-md-4 col-md-offset-1">
          <asp:Button runat="server" ID="childCls" Text="Enable" OnClick="childCls_Click" CssClass="btn btn-primary btn-sm" Width="100%"></asp:Button>
        </div>
   </div>
      </asp:Panel>
        <asp:Panel runat="server" ID="childEdit">
            <div class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                <button class="btn btn-success btn-sm" type="submit">Search</button>
              </div>
        <br />
            <asp:GridView ID="usersTab" runat="server" EmptyDataText="No data available."  CssClass="table" >
            <Columns>
                 <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="editbtn" CssClass="btn text-success btn-sm" OnClick="Edit_Click"><i class="fa fa-key text-secondary"></i></asp:LinkButton>
                        </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       </asp:Panel>
      </div>

</asp:Content>
