 
<%@ Page Title="Employees Edit" Language="C#" AutoEventWireup="true" CodeBehind="Employeesedit.aspx.cs" Inherits="Mwezi_POS.Sources.Employees.Employeesedit" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <div class="container">
     <asp:Panel runat="server" ID="mainEdit">
             <div  class="row g-3" >
              <div class="col-md-12 col-md-offset-1">
                        <div class="alert alert-success" role="alert">
                            <h3 class="alert-heading">Employee Update Form</h3>
                            <p>Please fill in your information correctly</p>
                        </div>
                    </div>
                       <div class="col-md-6 col-md-offset-1">
                                <div class="form form-floating">
                                    <input type="number"  id="Idno" runat="server" readonly="true" enabled="true" class="form-control" cssclass="input-sm" placeholder="Idno"/>
                                    <label for="Idno" class="col-form-label-sm">Id Number</label>
                                 </div>
                        </div>
                        <div class="col-md-6 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="email" id="Email" name="mail" runat="server" enabled="true" class="form-control" cssclass="input-sm" placeholder="Email"/>
                                    <label for="Email"  class="col-form-label-sm">Email</label>
                                    </div>
                         </div>
                           <div class="col-md-12 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" id="Name" runat="server" enabled="true" name="fname" class="form-control" cssclass="input-sm" placeholder="Name"/>
                                    <label for="Name"  class="col-form-label-sm">Name</label>
                                    </div>
                              </div>
                        <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" runat="server" id="Phone" enabled="true" class="form-control" name="phne" cssclass="input-sm" placeholder="+25470000000"/>
                                    <label for="Phone"  class="col-form-label-sm">Phone Number</label>
                                    </div>
                                 </div> 
                           
                    <div class="col-md-4 col-md-offset-1">
                               <div class="form form-floating">
                                  <input type="date" runat="server" id="DOB" enabled="true" name="dateb" class="form-control" cssclass="input-sm"/>
                                    <label for="DOB"  class="col-form-label-sm">Date of Birth</label>
                                   </div>
                              </div>
                       <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="date" runat="server" id="RD" enabled="true" name="dater" class="form-control" cssclass="input-sm"/>
                                   <label for="RD"  class="col-form-label-sm">Registration date</label>
                                  </div>
                              </div>
                        <div class="col-md-12 col-md-offset-1">
                            <div class="form form-floating">   
                                <asp:DropDownList id="Gender" CssClass="form-select"  runat="server">
                                    <asp:ListItem value="Male">Male</asp:ListItem>
                                    <asp:ListItem value="Female">Female</asp:ListItem>
                                    </asp:DropDownList>
                                   <label for="Gender"  class="col-form-label-sm">Gender</label>
                            </div>
                          </div>  
    
                     <div class="col-md-12 col-md-offset-1">
                       <div class="form form-floating">
                          <input type="text" runat="server" id="Address" enabled="true" name="addrr" class="form-control" cssclass="input-sm" placeholder="1234 Nairobi"/>
                            <label for="Address"  class="col-form-label-sm">Address</label>
                           </div>
                      </div>
                    <div class="col-md-4 col-md-offset-1">
                       <div class="form form-floating">
                          <input type="text" runat="server" id="City" enabled="true" name="ctyy" class="form-control" cssclass="input-sm" placeholder="Nairobi"/>
                            <label for="City"  class="col-form-label-sm">City</label>
                           </div>
                      </div>
                 <div class="col-md-4">
                     <div class="form form-floating">   
                         <asp:DropDownList id="Country" CssClass="form-select"  runat="server">
                        <asp:ListItem value="">Select Country</asp:ListItem>
                         </asp:DropDownList>
                          <label for="Country"  class="col-form-label-sm">Country</label>
                         </div>
                     </div>
                   <div class="col-md-4">
                     <div class="form form-floating">   
                         <asp:DropDownList id="Role" CssClass="form-select"  runat="server">
                            <asp:ListItem value="Admin">Admin</asp:ListItem>
                            <asp:ListItem value="Editor">Editor</asp:ListItem>
                            <asp:ListItem value="User">User</asp:ListItem>                      
                           </asp:DropDownList>
                          <label for="Role"  class="col-form-label-sm">Role</label>
                         </div>
                     </div>
                     <div class="col-md-4 col-md-offset-1">
                      <asp:Button runat="server" Text="Save" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-success btn-sm" Width="100%"></asp:Button>
                      </div>
                     <div class="col-md-4 col-md-offset-1">
                      <asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn btn-danger btn-sm" Width="100%"></asp:Button>
                      </div>
                     <div class="col-md-4 col-md-offset-1">
                      <asp:Button runat="server" ID="childCls" Text="Close" OnClick="childCls_Click" CssClass="btn btn-primary btn-sm" Width="100%"></asp:Button>
                     </div>
              </div>
         </asp:Panel>
<asp:Panel runat="server" ID="childEdit">
               <div class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                <asp:Button class="btn btn-outline-success" runat="server" Text="Search" type="submit" ></asp:Button>
              </div>
             <br />
<asp:GridView ID="lvUsers" runat="server"  CssClass="table" EmptyDataText="No data available.">
    <Columns>
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton  runat="server" OnClick="Edit_Click" Enabled="true" CssClass="btn text-primary btn-sm" > <i class="fas fa-user-edit"></i></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Panel>
</div>
</asp:Content>