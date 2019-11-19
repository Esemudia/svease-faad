<%@ Page Title="" Language="C#" MasterPageFile="~/faad.Master" AutoEventWireup="true" CodeBehind="ReleaseNoteAdd.aspx.cs" Inherits="saveasze.ReleaseNoteAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                    <table width="100%">
                        <tr>
                            <td>
                                
              <div class="col-md-8 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2><label runat="server" id="lblTitle"></label><asp:HiddenField runat="server" ID="hidePO" /></h2>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Quotation<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpQuote" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpQuote_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                      </div>
                        <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Select Marketer<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:DropDownList ID="drpMarket" class="form-control" runat="server" ></asp:DropDownList>
                          
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Customer<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                            <asp:Label ID="lblCustomer" class="form-control" runat="server"></asp:Label>
                            <asp:HiddenField ID="custIDHide" runat="server" />
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Delivery Address<span class="required" style="color:red">*</span></label>
                        <div class="col-md-9 col-sm-9 col-xs-12">
                          <asp:TextBox runat="server" ID="txtAdd" TextMode="MultiLine" Rows="3" class="form-control" ></asp:TextBox>
                        </div>
                      </div>

                      <div class="form-group">
                          <table align="center">
                              <thead>
                                  <tr>
                                      <td></td><td>Product</td><td>Quantity(ltr)</td><td>Amount Per Liter(N)</td><td>Total(N)</td>
                                  </tr>
                              </thead>
                              <tbody>
                                  <tr>
                                      <td></td>
                                      <td><asp:Label runat="server" ID="lblProduct" Width="100"></asp:Label></td>
                                      <td style="display:none"><asp:Label runat="server" ID="lblProdID" Text="2" Visible="false"></asp:Label></td>
                                      <td>
                                          <asp:TextBox runat="server" ID="txtlblprdQty" AutoPostBack="true" OnTextChanged="txtlblprdQty_TextChanged"></asp:TextBox>
                                          <asp:HiddenField ID="lblQtQty" runat="server"></asp:HiddenField>
                                      </td>
                                      <td>
                                          <asp:TextBox runat="server" ID="txtlblUPrice" AutoPostBack="true" OnTextChanged="txtlblUPrice_TextChanged"></asp:TextBox>

                                      </td>
                                      <td><asp:Label runat="server" ID="lblSubTots"></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td></td>
                                      <td></td>
                                      <td>
                                          <asp:RadioButtonList ID="radVat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radVat_SelectedIndexChanged" RepeatDirection="Horizontal">
                                              <asp:ListItem Selected="True" Value="VAT">VAT(5%)</asp:ListItem>
                                              <asp:ListItem>Withholding TAX(5%)</asp:ListItem>
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
                        <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3"><a href="po.aspx">View All Purchase Order</a>
                         <asp:Button cssclass="btn btn-primary" runat="server" ID="btnReset" OnClick="btnReset_Click" Text="Reset" /><asp:HiddenField runat="server" ID="hid" />
                         <asp:Button cssclass="btn btn-success" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Create Purchase Order" />
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
