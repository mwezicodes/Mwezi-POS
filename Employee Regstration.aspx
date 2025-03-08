<%@ Page Title="Employee add" Language="C#" AutoEventWireup="true" CodeBehind="Employee Regstration.aspx.cs" Inherits="Mwezi_POS.Sources.Employees.Employee_Regstration" MasterPageFile="~/Site.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="container">
                       <div class="col-md-12 col-md-offset-2">
                           <div class="alert alert-success" role="alert">
                               <h3 class="alert-heading">Employee Registration Form</h3>
                               <p>Please fill in your information correctly</p>
                           </div>
                       </div>
   </div> 
    
    <div class="container">
                   <div class="row g-3">
                       <div class="col-md-6 col-md-offset-1">
                                <div class="form form-floating">
                                    <input type="number" runat="server" id="Idno" enabled="true" class="form-control" placeholder="ID Number"/>
                                    <label for="Idno" class="col-form-label-sm">Id Number</label>
                                    <asp:RequiredFieldValidator id="ino" runat="server" ControlToValidate="Idno" ErrorMessage="Please enter Id Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                        </div>
                        <div class="col-md-6 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="email" runat="server" id="Email" enabled="true" class="form-control" placeholder="Email"/>
                                    <label for="Email">Email</label>
                                   <asp:RequiredFieldValidator ID="mail" runat="server" ControlToValidate="Email" ErrorMessage="Please enter email" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                         </div>
                           <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" runat="server" id="FirstName" enabled="true" class="form-control" cssclass="input-sm" placeholder="First Name"/>
                                    <label for="FirstName">First Name</label>
                                   <asp:RequiredFieldValidator ID="fname" runat="server" ControlToValidate="FirstName" ErrorMessage="Please enter First Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                              </div>
                            <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" runat="server" id="MiddleName" enabled="true" class="form-control" cssclass="input-sm" placeholder="Middle Name" />
                                    <label for="MiddleName">Middle Name</label>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LastName" ErrorMessage="Please enter Middle Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                             </div>                    
                           <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="text" runat="server" id="LastName" enabled="true" class="form-control" cssclass="input-sm" placeholder="Last Name" />
                                    <label for="LastName">Last Name</label>
                                   <asp:RequiredFieldValidator ID="lname" runat="server" ControlToValidate="LastName" ErrorMessage="Please enter Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                              </div>
                        <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="number" runat="server" id="Phone" enabled="true" class="form-control" cssclass="input-sm" placeholder="+25470000000"/>
                                    <label for="Phone">Phone Number</label>
                                   <asp:RequiredFieldValidator ID="fone" runat="server" ControlToValidate="Phone" ErrorMessage="Please enter phone" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                 </div> 
                           
                    <div class="col-md-4 col-md-offset-1">
                               <div class="form form-floating">
                                  <input type="date" runat="server" id="DOB" enabled="true" class="form-control" cssclass="input-sm"/>
                                    <label for="DOB">Date of Birth</label>
                                   <asp:RequiredFieldValidator ID="bday" runat="server" ControlToValidate="DOB" ErrorMessage="Please enter date of birth" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                              </div>
                       <div class="col-md-4 col-md-offset-1">
                                    <div class="form form-floating">
                                   <input type="date" runat="server" id="RD" enabled="true" class="form-control" cssclass="input-sm"/>
                                   <label for="RD">Registration date</label>
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
                                   <label for="Gender">Gender</label>
                                  <asp:RequiredFieldValidator ID="gendr" runat="server" ControlToValidate="Gender" InitialValue="0" ErrorMessage="Please select gender" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                          </div>  
    
                     <div class="col-md-12 col-md-offset-1">
                       <div class="form form-floating">
                          <input type="text" runat="server" id="Address" enabled="true" class="form-control" cssclass="input-sm" placeholder="1234 Nairobi"/>
                            <label for="Address">Address</label>
                           <asp:RequiredFieldValidator ID="addr" runat="server" ControlToValidate="Address" ErrorMessage="Please enter your address" ForeColor="Red"></asp:RequiredFieldValidator>
                           </div>
                      </div>
                    <div class="col-md-4 col-md-offset-1">
                       <div class="form form-floating">
                          <input type="text" runat="server" id="City" enabled="true" class="form-control" cssclass="input-sm" placeholder="Nairobi"/>
                            <label for="Address">City</label>
                           <asp:RequiredFieldValidator ID="citi" runat="server" ControlToValidate="City" ErrorMessage="Please enter your city of residence" ForeColor="Red"></asp:RequiredFieldValidator>
                           </div>
                      </div>
                 <div class="col-md-4">
                     <div class="form form-floating">   
                         <asp:DropDownList id="Country" CssClass="form-select"  runat="server">
                        <asp:ListItem value="">Select Country</asp:ListItem>
                         </asp:DropDownList>
                          <label for="Country" class="form-label">Country</label>
                          <asp:RequiredFieldValidator ID="Contr" runat="server" ControlToValidate="Country" InitialValue="Select" ErrorMessage="Please select country" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                      <div class="col-md-4">
                        <div class="form form-floating">
                        <input type="text" runat="server" id="Postcode" enabled="true" class="form-control" cssclass="input-sm" placeholder="Postal Code"/>
                        <label for="Postcode">Postal Code</label>
                         <asp:RequiredFieldValidator ID="pstc" runat="server" ControlToValidate="Postcode" ErrorMessage="Please enter your Postal Code" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                    </div>
                     <div class="col-md-6 col-md-offset-1">
                      <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-primary" Width="100%"></asp:Button>
                      </div>
                     <div class="col-md-6 col-md-offset-1">
                      <asp:Button runat="server" Text="Cancel" ID="btnExit" CssClass="btn btn-danger" Width="100%"></asp:Button>
                     </div>
          </div>
      </div>     
</asp:Content>
