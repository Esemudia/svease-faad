<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="Customersadd.aspx.cs" Inherits="saveasze.Customersadd" %>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Customer Name<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                         <asp:TextBox runat="server" ID="txtCustName"  class="form-control" ></asp:TextBox>
                        </div>
                      </div>
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Company Name<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                         <asp:TextBox runat="server" ID="txtCompName"  class="form-control" ></asp:TextBox>

                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Contact Email <span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                <input type="email" id="txtEmail" class="form-control"  runat="server">         
                        </div>
                      </div>
                       <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Contact Phone <span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                         <asp:TextBox runat="server" ID="txtPhone"  class="form-control" ></asp:TextBox>          
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Contact Address<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <asp:TextBox runat="server" ID="txtAdd" TextMode="MultiLine" Rows="3" class="form-control" ></asp:TextBox>
                        </div>
                      </div>


                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3"><a href="customers.aspx">View All Customers</a>
       <asp:Button  class="btn btn-primary" runat="server" id="btnReset" OnClick="btnReset_Click" Text="Reset" /><asp:HiddenField runat="server" ID="hid" />
       <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Create Customer" cssclass="btn btn-success" />
                
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

