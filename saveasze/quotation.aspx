<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="quotation.aspx.cs" Inherits="saveasze.quotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Quotation Listings</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a href="quotationadd.aspx">Create New Quotation</a>
                      </li>
                       
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <table id="datatable-buttons" class="table table-striped jambo_table table-bordered">
                      <thead>
                        <tr class="headings">
                          <th  ></th>
                          <th class="column-title" width="120">Quotation Status</th>
                          <th class="column-title">Quotation #</th>
                          <th class="column-title">Customer</th>
                          <th class="column-title">Quotation Amount</th>
                          <th class="column-title">Quotation Date</th>
                        </tr>
                      </thead>
<% createTableBody(); %>
                    </table>
                  </div>
                </div>
              </div>
</asp:Content>
