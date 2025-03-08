<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mwezi_POS.Land.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="~/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="landing-container">
                       <div class="col-md-12 col-md-offset-2">
                           <div class="alert alert-success" role="alert">
                               <h2 class="alert-heading">MWEZI POS</h2>
                               <p>Enter username and password</p>
                           </div>
                       </div>
                        <div class="row g-3">
                                    <div class="form form-floating">
                                   <input type="text" runat="server" id="username" enabled="true" class="form-control" placeholder="username"/>
                                    <label for="username">Username</label>
                                   <asp:RequiredFieldValidator ID="uname" runat="server" ControlToValidate="username" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                         </div>
                           <div class="row g-3">
                                    <div class="form form-floating">
                                   <input type="password" runat="server" id="password" enabled="true" class="form-control" cssclass="input-sm" placeholder="....."/>
                                    <label for="password">Password</label>
                                   <asp:RequiredFieldValidator ID="ppass" runat="server" ControlToValidate="password" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                              </div> 
                        <div class="row g-3">
                        <div class="form">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" Width="100%"></asp:Button>
                        </div>
                    </div>
               </div>
    </form>
</body>
</html>
