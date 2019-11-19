<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="poApproval_old.aspx.cs" Inherits="saveasze.poApproval_old" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                    <table width="100%" runat="server" id="tblApproval">
                        <tr>
                            <td>
                                
              <div class="col-md-8 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Approve/Decline Purchase Order (<asp:Label ID="lblPO" runat="server"></asp:Label>) </h2>
                    <div class="clearfix"></div>
                  </div>        
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                  <div class="x_content">
                      <div class="form-horizontal form-label-left" >

                      </div>
                    <div class="form-horizontal form-label-left">
                      <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label> 
                     
                      <asp:Label ID="lblcostCenterID" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblcostCenter" runat="server" Visible="false"></asp:Label> 

                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Select Cost Center<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpCostCenter" class="form-control" runat="server" Enabled="false"></asp:DropDownList>
                          
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Customer<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpCustomer" class="form-control" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Product<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpProduct" class="form-control" runat="server" Enabled="false"></asp:DropDownList>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Request Quantity <span class="required" style="color:red">*</span>
                        </label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:TextBox runat="server" ID="txtQty" ReadOnly="true" class="form-control" Text="0"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Amount Per Liter <span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:TextBox runat="server" ID="txtAmtLtr" class="form-control" ReadOnly="true" Text="0" ></asp:TextBox>
                        </div>
                      </div>
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Vat (5%)</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input  type="text" class="form-control" id="txtVat" runat="server" Value="0" readonly>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Total Amount</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input  type="text" class="form-control" id="txtTotalAmt" runat="server" Value="0" readonly>
                        </div>
                      </div>
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Perform Task on PO<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpApprovalType" class="form-control" runat="server" OnSelectedIndexChanged="drpApprovalType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="AGM">Approve This Purchase Order</asp:ListItem>
                                <asp:ListItem Value="D">Decline This Purchase Order</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpApprovalType2" class="form-control" runat="server" OnSelectedIndexChanged="drpApprovalType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="A">Approve This Purchase Order</asp:ListItem>
                                <asp:ListItem Value="D">Decline This Purchase Order</asp:ListItem>
                            </asp:DropDownList>
                          
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Delivery Address</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <textarea readonly runat="server" id="txtDelAddress" class="form-control" rows="3" placeholder="Delivery Address"></textarea>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Remark/Comments</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                        <textarea  runat="server" id="txtRemark" class="form-control" rows="3" placeholder="Remark/Comments"></textarea>
                        </div>
                      </div>


                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3"><a href="po.aspx">View All Purchase Order</a>
                         <asp:HiddenField runat="server" ID="hid" />
                          <button type="submit" class="btn btn-success" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick">Submit</button>
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
    <div class="container" runat="server" id="divApproval">
    <div class="row">
        <div class="col-md-12">
            <div class="error-template">
                <h1>
                    Oops!</h1>
                <h2>
                    403 Access Denied</h2>
                <div class="error-details">
                    Sorry, you do not have access to the Requested page, 
                    Please login with valid account or contact administrator!
                </div>
                <div class="error-actions">
                    <a href="default.aspx" class="btn btn-primary btn-lg"><span class="glyphicon glyphicon-home"></span>
                        Take Me Home </a><a href="admmessage.aspx" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-knight"></span> Contact Support </a>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
