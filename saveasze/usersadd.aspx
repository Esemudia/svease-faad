<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="usersadd.aspx.cs" Inherits="saveasze.usersadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
          
    
                    <table width="100%">
                        <tr>
                            <td>
                                
              <div class="col-md-8 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Add New Users/Staff</h2>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <div class="form-horizontal form-label-left">
                      <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label> 
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Staff Name<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input id="txtSName" type="text" class="form-control" placeholder="Staff Name" runat="server">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Staff Type <span class="required">*</span>
                        </label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpStaffType" runat="server" cssclass="form-control" >
                      <asp:ListItem Selected="True" Value="0"> Select Staff Type </asp:ListItem>
                  <asp:ListItem Value="1"> Accountant </asp:ListItem>
                  <asp:ListItem Value="2"> Admin Support </asp:ListItem>
                  <asp:ListItem Value="3"> Admin Support </asp:ListItem>
                  <asp:ListItem Value="4"> Customer Care Rep </asp:ListItem>
                  <asp:ListItem Value="5"> Driver </asp:ListItem>
                  <asp:ListItem Value="6"> Facility Manager </asp:ListItem>
                  <asp:ListItem Value="7"> GM </asp:ListItem>
                  <asp:ListItem Value="8"> Marketer </asp:ListItem>
                  <asp:ListItem Value="9"> Security </asp:ListItem>
                  <asp:ListItem Value="10"> Surveyor </asp:ListItem>
                  <asp:ListItem Value="11"> System Admin </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Email Address</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input type="text" class="form-control" id="txtEmail" runat="server"  placeholder="Email Address">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Contact Phone Number </label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input runat="server" id="txtcphone" type="text" class="form-control" placeholder="Contact Phone Number">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Contact Address <span class="required">*</span>
                        </label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <textarea runat="server" id="txtcAddress" class="form-control" rows="3" placeholder="Company Address"></textarea>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Password</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input type="password" name="txtPwd" runat="server" id="txtPwd" class="form-control col-md-10" placeholder="Password"/>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Confirm Password</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input type="password" name="confPwd" runat="server" id="confPwd" class="form-control col-md-10" placeholder="Confirm Password"/>
                        </div>
                      </div>


                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3"><a href="users.aspx">View All Users</a>
                          <button type="button" class="btn btn-primary">Cancel</button>
                          <button type="reset" class="btn btn-primary">Reset</button><asp:HiddenField runat="server" ID="hid" />
                          <button type="submit" class="btn btn-success" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick">Submit</button>
                        </div>
                      </div>

                    </div>
                  </div>
                </div>
              </div>
                            </td>
                        </tr>
                    </table>

</asp:Content>
