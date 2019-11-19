<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="atl.aspx.cs" Inherits="saveasze.atl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Authority To Load</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a href="atlAdd.aspx">create new ATL</a>
                      </li>
                       
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <table id="datatable-buttons" class="table table-striped jambo_table table-bordered">
                      <thead>
                        <tr class="headings">
                          <th class="column-title" width="50"> Detailed View</th>
                          <th class="column-title">PO number</th>
                          <th class="column-title">Customer</th>
                          <th class="column-title">Sales Rep</th>
                          <th class="column-title">Products</th>
                          <th class="column-title" width="100">Product Density</th>
                          <th class="column-title">Tank</th>
                          <th class="column-title">Truck</th>
                          <th class="column-title">ATL Date</th>
                        </tr>
                      </thead>
<% createTableBody(); %>
                    </table>
                  </div>
                </div>
              </div>
</asp:Content>
