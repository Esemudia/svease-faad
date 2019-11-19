<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="saveasze.invoice" %>
<!DOCTYPE html>

<html>

  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>FAADInv</title>

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- jQuery custom content scroller -->
    <link href="vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.min.css" rel="stylesheet"/>
      
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- iCheck -->
    <link href="vendors/iCheck/skins/flat/green.css" rel="stylesheet">
    <!-- bootstrap-wysiwyg -->
    <link href="vendors/google-code-prettify/bin/prettify.min.css" rel="stylesheet">
    <!-- Select2 -->
    <link href="vendors/select2/dist/css/select2.min.css" rel="stylesheet">
    <!-- Switchery -->
    <link href="vendors/switchery/dist/switchery.min.css" rel="stylesheet">
    <!-- starrr -->
    <link href="vendors/starrr/dist/starrr.css" rel="stylesheet">
    <!-- bootstrap-daterangepicker -->
    <link href="vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">
    <!-- Datatables -->
    <link href="vendors/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet">
    <link href="vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">
  </head>
  
  <body class="nav-md">
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>


    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 left_col menu_fixed">
          <div class="left_col scroll-view">
            <div class="navbar nav_title" style="border: 0;">
              <a href="default.aspx" class="site_title"> <span><%appName(); %></span></a>
            </div>

            <!-- sidebar menu -->
            <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
              <div class="menu_section">
                <h3>General</h3>
                <ul class="nav side-menu">
                  <li><a><i class="fa fa-home"></i> Home <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="dashboard.aspx">Dashboard</a></li>
                      <li><a href="costcenter.aspx"> Branches</a></li>
                      <li><a href="po.aspx">PO</a></li>
                      <li><a href="atl.aspx">ATL</a></li>
                    </ul>
                  </li>
                </ul>
              </div>
                 <button class="btn btn-primary pull-left"  onserverclick="btnPrint_ServerClick" runat="server" id="btnPrint" ><i class="fa fa-print"></i> Print Invoice</button>
                 <button class="btn btn-success pull-left" runat="server" id="btnPayment" ><i class="fa fa-credit-card"></i> Submit Payment</button>
                        
            </div>
            <!-- /sidebar menu -->

 
          </div>
        </div>

        <!-- top navigation -->
        <div class="top_nav">
          <div class="nav_menu">
            <nav>
              <div class="nav toggle">
                <a id="menu_toggle"><i class="fa fa-bars">
                   </i></a>
              </div> <img src="<%retCostCenterLogo();%>" />

              
            </nav>
          </div>
        </div>
        <!-- /top navigation -->
       
        <div class="right_col" role="main">
          <div class="">
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                  <div class="x_content">

                    <section class="content invoice">
                      <!-- title row -->
                      <div class="row">
                        <div class="col-xs-12 invoice-header">
                          <h1>
                                          <i class="fa fa-globe"></i> Invoice.
                                          <small class="pull-right">Invoice Date: <asp:Label ID="lblInvDate" runat="server" Text="19/05/2019"></asp:Label> </small>
                                      </h1>
                        </div>
                        <!-- /.col -->
                      </div>
                      <!-- info row -->
                      <div class="row invoice-info">
                        <div class="col-sm-4 invoice-col">
                          From
                          <address>
                                          <strong><asp:Label ID="lblCostCenter" runat="server" Text="FAAD"></asp:Label></strong>
                                          <br><asp:Label ID="lblCSAddress" runat="server" Text=""></asp:Label>
                                          <br>Phone: <asp:Label ID="lblCSPhone" runat="server" Text=""></asp:Label>
                                          <br>Email: <asp:Label ID="lblCSEmail" runat="server" Text=""></asp:Label>
                                      </address>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-4 invoice-col">
                          To
                          <address>
                                        
                                          <strong><asp:Label ID="lblCustomer" runat="server" Text="FAAD"></asp:Label></strong>
                                          <br><asp:Label ID="lblCustAdd" runat="server" Text=""></asp:Label>
                                          <br>Phone: <asp:Label ID="lblCustPhone" runat="server" Text=""></asp:Label>
                                          <br>Email: <asp:Label ID="lblCustEmail" runat="server" Text=""></asp:Label>
                                      </address>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-4 invoice-col">
                          <b>Invoice <asp:Label ID="lblInvNo" runat="server" Text="123456"></asp:Label></b>
                          <br>
                          <br>
                          <b>Purchase Order:</b> <asp:Label ID="lblPONo" runat="server" Text="123456"></asp:Label>
                      
                        </div>
                        <!-- /.col -->
                      </div>
                      <!-- /.row -->

                      <!-- Table row -->
                      <div class="row">
                        <div class="col-xs-12 table">
                          <table class="table table-striped">
                            <thead>
                              <tr>
                                <th>Marketer</th>
                                <th>Product</th>
                                <th>Qty(Ltr)</th>
                                <th>Price/Ltr</th>
                                <th style="width: 59%">Description</th>
                                <th>PO Status</th>
                              </tr>
                            </thead>
                            <tbody>
                              <tr>
                                <td><asp:Label ID="lblMarketer" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblProduct" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblQty" runat="server" Text=""></asp:Label></td>
                                <td><asp:Label ID="lblPPL" runat="server" Text=""></asp:Label></td>
                                <td style="width: 59%"><textarea runat="server" id="txtDesc" style="width: 100%" readonly></textarea></td>
                                <td><asp:Label ID="lblStats" runat="server" Text=""></asp:Label></td>
                                
                              </tr>
                            </tbody>
                          </table>
                        </div>
                        <!-- /.col -->
                      </div>
                      <!-- /.row -->

                      <div class="row">
                        <!-- accepted payments column -->
                        <div class="col-xs-6">
                          <p class="lead">Payment Methods:</p>

                          <p class="text-muted well well-sm no-shadow" style="margin-top: 10px;">
                              <asp:DropDownList ID="drpPayment" runat="server"  style="width: 100%"  >
                                  <asp:ListItem Selected="True" Value="0">-Select Payment Type-</asp:ListItem>
                                  <asp:ListItem>Cash</asp:ListItem>
                                  <asp:ListItem>Card</asp:ListItem>
                                  <asp:ListItem>Transfer</asp:ListItem>
                                  <asp:ListItem>Cheque</asp:ListItem>
                                  <asp:ListItem>IOU</asp:ListItem>
                              </asp:DropDownList>
                              <textarea runat="server" id="txtPayDesc" style="width: 100%" placeholder="Payment Description" ></textarea>
                          </p>
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-6">
                          <p class="lead">Amount Due </p>
                          <div class="table-responsive">
                            <table class="table">
                              <tbody>
                                <tr>
                                  <th style="width:50%">Subtotal:</th>
                                  <td>N<asp:Label runat="server" ID="lblSubTotal" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                  <th>VAT (5%)</th>
                                  <td>N<asp:Label runat="server" ID="lblVat" Text=""></asp:Label></td>

                                </tr>
                                <tr>
                                  <th>Total:</th>
                                  <td>N<asp:Label runat="server" ID="lblTotal" Text=""></asp:Label></td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div>
                        <!-- /.col -->
                      </div>
                      <!-- /.row -->

                      <!-- this row will not appear when printing -->
                      <div class="row no-print">
                      </div>
                    </section>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
       

        <!-- footer content -->
        <footer>
          <div class="pull-right">
            Gentelella - Bootstrap Admin Template by <a href="https://colorlib.com">Colorlib</a>
          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
      </div>
    </div>

    <!-- jQuery -->
    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="vendors/nprogress/nprogress.js"></script>
    <!-- jQuery custom content scroller -->
    <script src="vendors/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>
    <!-- bootstrap-progressbar -->
    <script src="../vendors/bootstrap-progressbar/bootstrap-progressbar.min.js"></script>


    <!-- iCheck -->
    <script src="vendors/iCheck/icheck.min.js"></script>
    <!-- Datatables -->
    <script src="vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="vendors/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
    <script src="vendors/datatables.net-buttons/js/buttons.flash.min.js"></script>
    <script src="vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
    <script src="vendors/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
    <script src="vendors/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
    <script src="vendors/datatables.net-scroller/js/dataTables.scroller.min.js"></script>
    <script src="vendors/jszip/dist/jszip.min.js"></script>
    <script src="vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="vendors/pdfmake/build/vfs_fonts.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="vendors/moment/min/moment.min.js"></script>
    <script src="vendors/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap-wysiwyg -->
    <script src="vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js"></script>
    <script src="vendors/jquery.hotkeys/jquery.hotkeys.js"></script>
    <script src="vendors/google-code-prettify/src/prettify.js"></script>
    <!-- jQuery Tags Input -->
    <script src="vendors/jquery.tagsinput/src/jquery.tagsinput.js"></script>
    <!-- Switchery -->
    <script src="vendors/switchery/dist/switchery.min.js"></script>
    <!-- Select2 -->
    <script src="vendors/select2/dist/js/select2.full.min.js"></script>
    <!-- Parsley -->
    <script src="vendors/parsleyjs/dist/parsley.min.js"></script>
    <!-- Autosize -->
    <script src="vendors/autosize/dist/autosize.min.js"></script>
    <!-- jQuery autocomplete -->
    <script src="vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js"></script>
    <!-- starrr -->
    <script src="vendors/starrr/dist/starrr.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>
    </form>
  </body>
</html>


