<%@ Page Title="Employee add" Language="C#" AutoEventWireup="true" CodeBehind="Employeereg.aspx.cs" Inherits="Mwezi_POS.Sources.Employees.Employeereg" MasterPageFile="~/Site.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="container">
                     <div class="row g-3">
                       <div class="col-md-12 col-md-offset-1">
                           <div class="alert alert-success" role="alert">
                               <h3 class="alert-heading">Employee Registration Form</h3>
                               <p>Please fill in your information correctly</p>
                           </div>
                       </div>
                       <div class="col-md-6 col-md-offset-1">
                                <div class="form form-floating">
                                    <input type="number"  id="Idno" runat="server" name="idn" enabled="true" class="form-control" cssclass="input-sm" placeholder="ID Number"/>
                                    <label for="Idno" class="col-form-label-sm">Id Number</label>
                                    <asp:RequiredFieldValidator ID="ino" runat="server" ControlToValidate="Idno" ErrorMessage="Please enter Id Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                        </div>
                        <div class="col-md-6 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="email" id="Email" name="mail" runat="server" enabled="true" class="form-control" cssclass="input-sm" placeholder="Email"/>
                                    <label for="Email"  class="col-form-label-sm">Email</label>
                                   <asp:RequiredFieldValidator ID="maill" runat="server" ControlToValidate="Email" ErrorMessage="Please enter email" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                         </div>
                           <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" id="FirstName" runat="server" enabled="true" name="fname" class="form-control" cssclass="input-sm" placeholder="First Name"/>
                                    <label for="FirstName"  class="col-form-label-sm">First Name</label>
                                   <asp:RequiredFieldValidator ID="fname" runat="server" ControlToValidate="FirstName" ErrorMessage="Please enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                              </div>
                            <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" runat="server" id="MiddleName" enabled="true" name="midname" class="form-control" cssclass="input-sm" placeholder="Middle Name" />
                                    <label for="MiddleName"  class="col-form-label-sm">Middle Name</label>
                                   </div>
                             </div>                    
                           <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" runat="server" id="LastName" enabled="true" class="form-control" name="lname" cssclass="input-sm" placeholder="Last Name" />
                                    <label for="LastName"  class="col-form-label-sm">Last Name</label>
                                   <asp:RequiredFieldValidator ID="llname" runat="server" ControlToValidate="LastName" ErrorMessage="Please enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                              </div>
                        <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="number" runat="server" id="Phone" enabled="true" class="form-control" name="phne" cssclass="input-sm" placeholder="+25470000000"/>
                                    <label for="Phone"  class="col-form-label-sm">Phone Number</label>
                                   <asp:RequiredFieldValidator ID="fone" runat="server" ControlToValidate="Phone" ErrorMessage="Please enter phone" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                 </div> 
                           
                    <div class="col-md-4 col-md-offset-1">
                               <div class="form form-floating">
                                  <input type="date" runat="server" id="DOB" enabled="true" name="dateb" class="form-control" cssclass="input-sm"/>
                                    <label for="DOB"  class="col-form-label-sm">Date of Birth</label>
                                   <asp:RequiredFieldValidator ID="bday" runat="server" ControlToValidate="DOB" ErrorMessage="Please enter date of birth" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                              </div>
                       <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="date" runat="server" id="RD" enabled="true" name="dater" class="form-control" cssclass="input-sm"/>
                                   <label for="RD"  class="col-form-label-sm">Registration date</label>
                                  <asp:RequiredFieldValidator ID="rdate" runat="server" ControlToValidate="RD" ErrorMessage="Please enter date of registration" ForeColor="Red"></asp:RequiredFieldValidator>
                                  </div>
                              </div>
                        <div class="col-md-12 col-md-offset-1">
                            <div class="form form-floating">   
                                <asp:DropDownList id="Gender" CssClass="form-select"  runat="server">
                                    <asp:ListItem value="0">Select gender</asp:ListItem>
                                    <asp:ListItem value="1">Male</asp:ListItem>
                                    <asp:ListItem value="2">Female</asp:ListItem>
                                    </asp:DropDownList>
                                   <label for="Gender"  class="col-form-label-sm">Gender</label>
                                  <asp:RequiredFieldValidator ID="gendr" runat="server" ControlToValidate="Gender" InitialValue="0" ErrorMessage="Please select gender" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                          </div>  
    
                     <div class="col-md-12 col-md-offset-1">
                       <div class="form form-floating">
                          <input type="text" runat="server" id="Address" enabled="true" name="addrr" class="form-control" cssclass="input-sm" placeholder="1234 Nairobi"/>
                            <label for="Address"  class="col-form-label-sm">Address</label>
                           <asp:RequiredFieldValidator ID="addr" runat="server" ControlToValidate="Address" ErrorMessage="Please enter your address" ForeColor="Red"></asp:RequiredFieldValidator>
                           </div>
                      </div>
                    <div class="col-md-4 col-md-offset-1">
                       <div class="form form-floating">
                          <input type="text" runat="server" id="City" enabled="true" name="ctyy" class="form-control" cssclass="input-sm" placeholder="Nairobi"/>
                            <label for="City"  class="col-form-label-sm">City</label>
                           <asp:RequiredFieldValidator ID="citi" runat="server" ControlToValidate="City" ErrorMessage="Please enter your city of residence" ForeColor="Red"></asp:RequiredFieldValidator>
                           </div>
                      </div>
                 <div class="col-md-4">
                     <div class="form form-floating">   
                         <asp:DropDownList id="Country" CssClass="form-select"  runat="server">
                        <asp:ListItem value="">Select Country</asp:ListItem>
                         </asp:DropDownList>
                          <label for="Country"  class="col-form-label-sm">Country</label>
                          <asp:RequiredFieldValidator ID="Contr" runat="server" ControlToValidate="Country"  ErrorMessage="Please select country" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                   <div class="col-md-4">
                     <div class="form form-floating">   
                         <asp:DropDownList id="Role" CssClass="form-select"  runat="server">
                            <asp:ListItem value="0">Select role</asp:ListItem>
                            <asp:ListItem value="1">Admin</asp:ListItem>
                            <asp:ListItem value="2">Editor</asp:ListItem>
                            <asp:ListItem value="3">User</asp:ListItem>                      
                           </asp:DropDownList>
                          <label for="Role"  class="col-form-label-sm">Role</label>
                          <asp:RequiredFieldValidator ID="Rle" runat="server" ControlToValidate="Role" InitialValue="0"  ErrorMessage="Select Role" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-6 col-md-offset-1">
                      <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-success btn-sm" Width="100%" OnClick="btnSave_Click"></asp:Button>
                      </div>
          </div>
      </div>     
</asp:Content>
