<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="costcenterAdd.aspx.cs" Inherits="saveasze.costcenterAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
          
    
                    <table width="100%">
                        <tr>
                            <td>
                                
              <div class="col-md-8 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Add New FAAD Cost Centers</h2>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <div class="form-horizontal form-label-left">
                      <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label> 
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Company Name<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input id="txtCName" type="text" class="form-control" placeholder="Company Name" runat="server">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Company Address <span class="required">*</span>
                        </label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <textarea runat="server" id="txtcAddress" class="form-control" rows="3" placeholder="Company Address"></textarea>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Contact Phone Number </label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input runat="server" id="txtcphone" type="text" class="form-control" placeholder="Contact Phone Number">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Email Address</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input type="text" class="form-control" id="txtEmail" runat="server"  placeholder="Email Address">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">State</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input type="text" name="state" runat="server" id="txtstate" class="form-control col-md-10" placeholder="State"/>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">City</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input type="text" name="city" runat="server" id="txtcity" class="form-control col-md-10" placeholder="City"/>
                        </div>
                      </div>


                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3"><a href="costcenter.aspx">View All Cost Centers</a>
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
