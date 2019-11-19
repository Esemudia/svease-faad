<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="saveasze.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title> inventory Mgt System | </title>

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet" />
    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet" />

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet" />
    
  </head>
<body class="login">
    <form id="form1" runat="server" style="background-image: url('images/tanker1.png')">
        
    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form ">
          <section class="login_content">
         
              <h1>Login Form</h1>
              <div>
                <input type="text" class="form-control" placeholder="Enter Email To Login" required="" runat="server" id="txtEmail"/>
              </div><br />
              <div>
                <input type="password" class="form-control" placeholder="Password" required="" runat="server" id="txtPwd"/>
              </div><br />
              <div>
           <asp:DropDownList ID="drpCC" class="form-control" runat="server"></asp:DropDownList>
              </div>
              <div><br />
                  <asp:Button runat="server" ID="btnLogin" Text="Login" cssclass="btn btn-default submit" OnClick="btnLogin_Click"  />
              </div>
              <div>
                  <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
              </div>

              <div class="clearfix"></div>

              <div class="separator">

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="fa fa-paw"></i> Product Inventory Management System!</h1>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                  <p>©2019 All Rights Reserved. </p>
                </div>
              </div>
           
          </section>
        </div>

      </div>
    </div>
    </form>
</body>

</html>
