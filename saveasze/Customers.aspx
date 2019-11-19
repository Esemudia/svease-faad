<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="saveasze.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Customers Listings</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a href="Customersadd.aspx">Create New Customer</a>
                      </li>
                       
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <table id="datatable-buttons" class="table table-striped jambo_table table-bordered">
                      <thead>
                        <tr class="headings">
                          <th class="column-title" width="120">Customer ID</th>
                          <th class="column-title">Customer Name</th>
                          <th class="column-title">Customer Address</th>
                          <th class="column-title">Email Address</th>
                          <th class="column-title">Company Name</th>
                          <th class="column-title">Customer Phone</th>
                          <th class="column-title">Created Date</th>
                        </tr>
                      </thead>
<% createTableBody2(); %>
                    </table>
                  </div>
                </div>
              </div>
</asp:Content>

