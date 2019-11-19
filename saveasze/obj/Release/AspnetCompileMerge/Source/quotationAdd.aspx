<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="quotationAdd.aspx.cs" Inherits="saveasze.quotationAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                    <table width="100%">
                        <tr>
                            <td>
                                
              <div class="col-md-8 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Add New Quotation</h2>
                    <div class="clearfix"></div>
                  </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                  <div class="x_content">
                    <div class="form-horizontal form-label-left">
                      <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblQoutNo" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblcostCenterID" runat="server" Visible="false"></asp:Label> 
                      <asp:Label ID="lblcostCenter" runat="server" Visible="false"></asp:Label> 
                        
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Quotation Number <span class="required" style="color:red">*</span>
                        </label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:TextBox runat="server" ID="txtQTNo" class="form-control"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Customer<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpCustomer" class="form-control" runat="server"></asp:DropDownList>
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
                                      <td><asp:CheckBox runat="server" ID="chkAGO" OnCheckedChanged="chkAGO_CheckedChanged" AutoPostBack="true" /></td>
                                      <td><asp:Label runat="server" ID="lblAGO" Text="AGO"></asp:Label><asp:Label runat="server" ID="lblAGOID" Text="2" Visible="false"></asp:Label></td>
                                      <td><asp:TextBox runat="server" ID="txtAGOQty" Enabled="false" OnTextChanged="txtAGOQty_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                      <td><asp:TextBox runat="server" ID="txtAGOuPrice" Enabled="false" OnTextChanged="txtAGOuPrice_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                      <td><asp:Label runat="server" ID="lblTotAGOAmount"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td><asp:CheckBox runat="server" ID="chkDPK" OnCheckedChanged="chkDPK_CheckedChanged" AutoPostBack="true" /></td>
                                      <td><asp:Label runat="server" ID="lblDPK" Text="DPK"></asp:Label><asp:Label runat="server" ID="lblDPKID" Text="3" Visible="false"></asp:Label></td>
                                       <td><asp:TextBox runat="server" ID="txtDPKQty" Enabled="false" OnTextChanged="txtAGOQty_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                      <td><asp:TextBox runat="server" ID="txtDPKuPrice" Enabled="false" OnTextChanged="txtDPKuPrice_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                      <td><asp:Label runat="server" ID="lblTotDPKAmount"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td><asp:CheckBox runat="server" ID="chkOMS" OnCheckedChanged="chkOMS_CheckedChanged" AutoPostBack="true" /></td>
                                      <td><asp:Label runat="server" ID="lblPMS" Text="PMS"></asp:Label><asp:Label runat="server" ID="lblPMSID" Text="1" Visible="false"></asp:Label></td>
                                      <td><asp:TextBox runat="server" ID="txtPMSQty" Enabled="false" OnTextChanged="txtPMSQty_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                      <td><asp:TextBox runat="server" ID="txtPMSuPrice" Enabled="false" OnTextChanged="txtPMSuPrice_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                      <td><asp:Label runat="server" ID="lblTotPMSAmount"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td></td>
                                      <td></td>
                                      <td>
                                          <asp:RadioButtonList ID="radVat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radVat_SelectedIndexChanged" RepeatDirection="Horizontal">
                                              <asp:ListItem Selected="True" Value="VAT">VAT(5%)</asp:ListItem>
                                              <asp:ListItem>Withholding TAX</asp:ListItem>
                                          </asp:RadioButtonList></td>
                                       <td> <asp:CheckBoxList ID="chkNCD" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkNCD_SelectedIndexChanged">
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
                            <asp:Label CssClass="form-control" runat="server" ID="txtSubTotal"></asp:Label>
                        </div>
                      </div>
                      <div class="form-group">
                          <table align="center">
                              <thead>
                              </thead>
                              <tbody>
                                  <tr>
                                      <td><asp:Label runat="server" ID="lblVatWitholding2"></asp:Label>: &nbsp; &nbsp;</td>
                                      <td><strong><asp:Label runat="server" ID="lblVatWitholding2_1"></asp:Label></strong> &nbsp; &nbsp; &nbsp; &nbsp;</td>
                                      <td>NCD: &nbsp; &nbsp;</td>
                                      <td><strong><asp:Label runat="server" ID="lblNCD"></asp:Label></strong></td>
                                  </tr>
                              </tbody>
                          </table>
                        
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Total Amount</label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <input  type="text" class="form-control" id="txtTotalAmt" runat="server" Value="0" readonly>
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
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3"><a href="quotation.aspx">View All Quotation</a>
                          <button type="reset" class="btn btn-primary" runat="server" id="btnReset" onserverclick="btnReset_ServerClick">Reset</button><asp:HiddenField runat="server" ID="hid" />
                          <button type="submit" class="btn btn-success" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick">Create Quotation</button>
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
