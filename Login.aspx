<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mwezi_POS.Land.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link href="~/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/sweetalert.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="~/Scripts/jquery-3.7.0.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>  
    <script src="~/Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
    <script src="_content/CurrieTechnologies.Razor.SweetAlert2/sweetAlert2.min.js"></script>
    <title>MWEZI POS Login</title>
</head>
<body>
    <form id="form1" runat="server">
 <div class="container">
        <div class="landing-container">
            <div class="row g-3">
                       <div class="col-md-12 col-md-offset-2">
                           <div class="alert alert-success" role="alert">
                               <h2 class="alert-heading">MWEZI POS</h2>
                               <p>Enter username and password</p>
                           </div>
                       </div>
                        <div class="col-md-12 col-md-offset-2">
                              <div class="form form-floating">
                                   <input type="text" runat="server" id="username" enabled="true" class="form-control" cssclass="input-sm" placeholder="Username"/>
                                    <label for="username" class="col-form-label-sm">Username</label>
                                   <asp:RequiredFieldValidator ID="uname" runat="server" ControlToValidate="username" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div>
                         </div>
                           <div class="col-md-12 col-md-offset-2">
                                    <div class="form form-floating">
                                   <input type="password" runat="server" id="password" enabled="true" class="form-control" cssclass="input-sm" placeholder="password"/>
                                    <label for="password" class="col-form-label-sm">Password</label>
                                   <asp:RequiredFieldValidator ID="ppass" runat="server" ControlToValidate="password" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                              </div>                        
                        <div class="col-md-12 col-md-offset-2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" Width="100%" OnClick="btnLogin_Click"></asp:Button>
                        </div>
                    </div>
               </div>
        </div>
    </form>
</body>
<script>
    function myFunction() {
        var x = document.getElementById("myTopnav");
        if (x.className === "topnav") {
            x.className += " responsive";
        } else {
            x.className = "topnav";
        }
    }
    </script>
</html>
