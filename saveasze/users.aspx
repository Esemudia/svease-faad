<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="saveasze.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Users/Staff Listings</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a href="usersadd.aspx">Create New System User</a>
                      </li>
                       
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <table id="datatable-buttons" class="table table-striped jambo_table table-bordered">
                      <thead>
                        <tr class="headings">
                          <th class="column-title" width="120">Staff Name</th>
                          <th class="column-title">Staff Type</th>
                          <th class="column-title"> Email</th>
                          <th class="column-title">Phone</th>
                          <th class="column-title">Contact Address</th>
                        </tr>
                      </thead>
<% createTableBody2(); %>
                    </table>
                  </div>
                </div>
              </div>
</asp:Content>

