<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="changePwd.aspx.cs" Inherits="saveasze.changePwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <table width="100%">
                        <tr>
                            <td>                                
              <div class="col-md-8 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2><label runat="server" id="lblTitle"></label><asp:HiddenField runat="server" ID="hideCID" /></h2>
                    <div class="clearfix"></div>
                  </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                  <div class="x_content">
                    <div class="form-horizontal form-label-left">
                      <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Old Password<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                <input type="password" id="oldPwd" class="form-control"  runat="server">       
                        </div>
                      </div>
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">New Password<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                <input type="password" id="newPwd" class="form-control"  runat="server">   
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Confirm New Password <span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                <input type="password" id="confNewPwd" class="form-control"  runat="server">           
                        </div>
                      </div>


                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
       <asp:Button  class="btn btn-primary" runat="server" id="btnReset" OnClick="btnReset_Click" Text="Reset" /><asp:HiddenField runat="server" ID="hid" />
       <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Change Password" cssclass="btn btn-success" />
                
                        </div>
                      </div>

                    </div>
                  </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
              </div>
                            </td>
                        </tr>
                    </table>
</asp:Content>

