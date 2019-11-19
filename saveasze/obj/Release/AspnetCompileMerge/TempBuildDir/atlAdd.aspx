<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="atlAdd.aspx.cs" Inherits="saveasze.atlAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                    <table width="100%">
                        <tr>
                            <td>
                                
              <div class="col-md-8 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Add New FAAD ATL</h2>
                    <div class="clearfix"></div>
                  </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                  <div class="x_content">
                    <div class="form-horizontal form-label-left">
                      <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblPO" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblcostCenterID" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblcostCenter" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblcustomerID" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblATLID" runat="server" Visible="false"></asp:Label> 
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">PO Number/Deal ID<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">

                            <asp:DropDownList ID="drppo" class="form-control chzn-select" runat="server" OnSelectedIndexChanged="drppo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          
                        </div>
	
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Customer<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:Label runat="server" ID="lblCustomer" class="form-control" Text="" ></asp:Label>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Sales Rep<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:Label runat="server" ID="lblSalesRep" class="form-control" Text="" Visible="false" ></asp:Label>
                            <asp:Label runat="server" ID="lblStaffName" class="form-control" Text="" ></asp:Label>
                        </div>
                      </div>
                     <div class="form-group">
                          <table align="center">
                              <thead>
                                  <tr>
                                      <td></td><td></td><td>Quantity(ltr)</td><td>Amount Per Liter(N)</td><td>Total(N)</td>
                                  </tr>
                              </thead>
                              <tbody>
                                  <tr>
                                      <td></td>
                                      <td><asp:CheckBox runat="server" ID="chkAGO" Text="AGO" Enabled="false" /></td>
                                      <td><asp:TextBox runat="server" ID="txtAGOQty" Enabled="false" ></asp:TextBox></td>
                                      <td><asp:TextBox runat="server" ID="txtAGOuPrice" Enabled="false"></asp:TextBox></td>
                                      <td><asp:Label runat="server" ID="lblTotAGOAmount"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td></td>
                                      <td><asp:CheckBox runat="server" ID="chkDPK" Text="DPK" Enabled="false"  /></td>
                                      <td style="display:none"><asp:Label runat="server" ID="lblDPK" Text="DPK"></asp:Label><asp:Label runat="server" ID="lblDPKID" Text="3" Visible="false"></asp:Label></td>
                                       <td><asp:TextBox runat="server" ID="txtDPKQty" Enabled="false"></asp:TextBox></td>
                                      <td><asp:TextBox runat="server" ID="txtDPKuPrice" Enabled="false" ></asp:TextBox></td>
                                      <td><asp:Label runat="server" ID="lblTotDPKAmount"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td></td>
                                      <td><asp:CheckBox runat="server" ID="chkOMS" Text="PMS" Enabled="false"  /></td>
                                      <td style="display:none"><asp:Label runat="server" ID="lblPMS" Text="PMS"></asp:Label><asp:Label runat="server" ID="lblPMSID" Text="1" Visible="false"></asp:Label></td>
                                      <td><asp:TextBox runat="server" ID="txtPMSQty" Enabled="false"></asp:TextBox></td>
                                      <td><asp:TextBox runat="server" ID="txtPMSuPrice" Enabled="false" ></asp:TextBox></td>
                                      <td><asp:Label runat="server" ID="lblTotPMSAmount"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td></td>
                                      <td></td>
                                      <td>
                                          <asp:RadioButtonList ID="radVat" runat="server" RepeatDirection="Horizontal" Enabled="false" >
                                              <asp:ListItem Selected="True" Value="VAT">VAT(5%)</asp:ListItem>
                                              <asp:ListItem>Withholding TAX(5%)</asp:ListItem>
                                          </asp:RadioButtonList></td>
                                       <td> <asp:CheckBoxList ID="chkNCD" runat="server" Enabled="false">
                                           <asp:ListItem Value="NCD">NCD (1%)</asp:ListItem>
                                           </asp:CheckBoxList>
                                      </td>
                                      <td></td>
                                  </tr>
                              </tbody>
                          </table>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Sub-Total Amount</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:Label runat="server" ID="txtSubTotal" class="form-control" Text="" ></asp:Label>                            
                          </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Total Amount + VAT</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:Label runat="server" ID="lblTotalAmt" class="form-control" Text="" ></asp:Label>                            
                          </div>
                      </div>
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Product Density</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input  type="text" class="form-control" id="txtDensity" runat="server" Value="0">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Delivery Address</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <textarea runat="server" id="txtDelAddress" class="form-control" rows="3" placeholder="Delivery Address" readonly></textarea>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Source Tank <span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpTank" class="form-control chzn-select" runat="server"></asp:DropDownList>
                            </div>
                      </div> 
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Truck <span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpTruck" class="form-control chzn-select" runat="server"></asp:DropDownList>
                            </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Remark/Comments</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                        <textarea runat="server" id="txtRemark" class="form-control" rows="3" placeholder="Remark/Comments"></textarea>
                        </div>
                      </div>


                      <div class="ln_solid"></div>
                      <div class="form-group">
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3"><a href="po.aspx">View All Purchase Order</a>
                          <button type="button" class="btn btn-primary">Cancel</button>
                          <button type="reset" class="btn btn-primary">Reset</button><asp:HiddenField runat="server" ID="hid" />
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
</asp:Content>
