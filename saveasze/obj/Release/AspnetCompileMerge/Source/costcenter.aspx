<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="costcenter.aspx.cs" Inherits="saveasze.costcenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
            
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Company/Branches Listings</h2>
                    <ul class="nav navbar-right panel_toolbox">
                      <li><a href="costcenterAdd.aspx">Add New Company</a>
                      </li>
                       
                    </ul>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                  
                    <table id="datatable-buttons" class="table table-striped table-bordered">
                      <thead>
                        <tr>
                          <th>Company ID</th>
                          <th>Company Name</th>
                          <th>Company Address</th>
                          <th>State</th>
                          <th>LGA/City</th>
                          <th>Contact Phone</th>
                          <th>Email Address</th>
                        </tr>
                      </thead>
<% createTableBody(); %>
                    </table>
                  </div>
                </div>
              </div>
</asp:Content>
