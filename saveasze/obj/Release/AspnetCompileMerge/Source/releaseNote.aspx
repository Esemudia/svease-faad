<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="releaseNote.aspx.cs" Inherits="saveasze.releaseNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Release Note</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a href="releasenoteAdd.aspx">create new Release Note</a>
                      </li>
                       
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <table id="datatable-buttons" class="table table-striped jambo_table table-bordered">
                      <thead>
                        <tr class="headings">
                          <th class="column-title" width="50">  View</th>
                          <th class="column-title">PO </th>
                          <th class="column-title">Customer</th>
                          <th class="column-title">Marketer</th>
                          <th class="column-title">Product</th>
                          <th class="column-title">Tank</th>
                          <th class="column-title">Truck</th>
                          <th class="column-title">Totalizer</th>
                          <th class="column-title">Dipping</th>
                          <th class="column-title">Variance</th>
                          <th class="column-title">Quantity Loaded</th>
                          <th class="column-title" width="100"> Date</th>
                        </tr>
                      </thead>
<% createTableBody(); %>
                    </table>
                  </div>
                </div>
              </div>
</asp:Content>
