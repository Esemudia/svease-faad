<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="po.aspx.cs" Inherits="saveasze.po" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Purchase Order Listings</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a href="poAdd.aspx">Add New Purchase Order</a>
                      </li>
                       
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <table id="datatable-buttons" class="table table-striped jambo_table table-bordered">
                      <thead>
                        <tr class="headings">
                          <th  ></th>
                          <th class="column-title" width="40">PO Status</th>
                          <th class="column-title">Quotation number</th>
                          <th class="column-title">PO number</th>
                          <th class="column-title">Customer</th>
                          <th class="column-title">Marketer</th>
                          <th class="column-title">Invoice Number</th>
                          <th class="column-title">Total Amount</th>
                          <th class="column-title">PO Date</th>
                        </tr>
                      </thead>
<% createTableBody(); %>
                    </table>
                  </div>
                </div>
              </div>
</asp:Content>

