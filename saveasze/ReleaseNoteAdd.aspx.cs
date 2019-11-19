using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace saveasze
{
    public partial class ReleaseNoteAdd : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                quotationOpt();
                marketerOpt();
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    lblQoutNo.Text = dtproc.gen_PO_Req();
                    //DataTable getPOByID(string id, string connLocation, out string expMessage)
                    string expMessage = "";
                    strID = Request.QueryString["id"].ToString();
                    btnSubmit.Text = "Update";
                    double dblTots = 0, dblSubtotal = 0, dblTotPMS = 0, dblTotAGO = 0, dblTotDPK = 0;
                    //getCostCentersByID(string id, string connLocation, out string )
                    DataTable dtUpdPo = dtproc.getPOByID(strID, hosts, out expMessage);
                    // foreach (DataRow dr in dtUpdPo.Rows)
                    // {

                    lblTitle.InnerText = "Update Purchase Order " + dtUpdPo.Rows[0]["po_number"].ToString();
                    hidePO.Value = dtUpdPo.Rows[0]["po_number"].ToString();
                    //drpCostCenter.SelectedValue=dtUpdPo.Rows[0]["CostCenterID"].ToString();
                    //drpCustomer.SelectedValue=dtUpdPo.Rows[0]["CustomerID"].ToString();
                    drpQuote.SelectedValue = dtUpdPo.Rows[0]["QuoteNo"].ToString();
                    drpMarket.SelectedValue = dtUpdPo.Rows[0]["salesRep"].ToString();
                    txtAdd.Text = dtUpdPo.Rows[0]["deliveryAddress"].ToString();

                    drpQuote.Enabled = false;
                    //drpMarket.Enabled = false;
                    string strQty = dtUpdPo.Rows[0]["Qty"].ToString();
                    string struprice = dtUpdPo.Rows[0]["uprice"].ToString();

                    // string strProduct=dtUpdPo.Rows[0]["product_ID"].ToString();
                    CustomerOpt();
                    double dblNCD = double.Parse(dtUpdPo.Rows[0]["NCD"].ToString());
                    double dblVat = double.Parse(dtUpdPo.Rows[0]["vat"].ToString());
                    double dblwitholdin = double.Parse(dtUpdPo.Rows[0]["witholding"].ToString());
                    //dblTots = dblTots + dblTotPMS + dblTotDPK + dblTotAGO;
                    //dblSubtotal = dblSubtotal + dblTotPMS + dblTotDPK + dblTotAGO;
                    dblSubtotal = double.Parse(strQty) * double.Parse(struprice);// + dblTotPMS + dblTotDPK + dblTotAGO;
                    if (dblVat > 0)
                    {
                        radVat.SelectedIndex = 0;
                        lblVatWitholding2.Text = "VAT(5%)";
                        //double dblVAT = (dblTotPMS + dblTotDPK + dblTotAGO) * 0.05;
                        dblTots = dblSubtotal + dblVat;
                        lblVatWitholding2_1.Text = dblVat.ToString();
                        //lblVatWitholding2_1.Text = dblTots.ToString();
                    }
                    else
                    {
                        radVat.SelectedIndex = 1;
                        lblVatWitholding2.Text = "Witholding TAX(5%)";
                        //double dblVAT = (dblTotPMS + dblTotDPK + dblTotAGO) * 0.05;
                        dblTots = dblSubtotal + dblwitholdin;
                        lblVatWitholding2_1.Text = dblwitholdin.ToString();
                        //lblVatWitholding2_1.Text = dblTots.ToString();
                    }
                    if (dblNCD > 0)
                    {
                        chkNCD.SelectedIndex = 0;
                       // double dblNCD2 = (dblTotPMS + dblTotDPK + dblTotAGO) * 0.01;
                        dblTots = dblTots + dblNCD;
                        lblNCD.Text = dblNCD.ToString();
                    }

                  //  txtSubTotal.Text = dblSubtotal.ToString();
                    txtTotalAmt.Value = dblTots.ToString();
                    // txtDelAddress.Value = dtUpdPo.Rows[0]["deliveryAddress"].ToString();
                    txtRemark.Value = dtUpdPo.Rows[0]["remarks"].ToString();

                }
                else
                {
                    //  costCenterOpt();
                    // productOpt();
                    lblTitle.InnerText = "Add New Purchase Order ";
                    CustomerOpt();
                }
            }
        }
        public void quotationOpt()
        {
            string expMess = "";
            //getCostCenters
            //getStaffByType(string staffTpe, string connLocation, out string expMessage)
            //DataTable dtOptions = dtproc.getStaffByType("marketer",hosts, out expMess);
            DataTable dtOptions = dtproc.getQuotePO(Session["costCenterID"].ToString(), hosts, out expMess);

            drpQuote.Items.Clear();
            drpQuote.DataSource = dtOptions;
            drpQuote.CssClass = "form-control";
            drpQuote.DataTextField = "quoteID";
            drpQuote.DataValueField = "quotationID";
            drpQuote.DataBind();
            drpQuote.Items.Insert(0, new ListItem("Select Quotation", "-1"));
        }
        public void CustomerOpt()
        {
            string expMess = "";
            //getCostCenters
            string strOptions = dtproc.getCustomerByQuoteID(drpQuote.SelectedValue, hosts, out expMess);
            custIDHide.Value = strOptions;
            lblCustomer.Text = dtproc.getCustomerByID(strOptions, hosts, out expMess);
       
        }
        public void marketerOpt()
        {
            string expMess = "";
            //getCostCenters
            //getStaffByType(string staffTpe, string connLocation, out string expMessage)
            DataTable dtOptions = dtproc.getStaffByType("marketer", hosts, out expMess);

            drpMarket.DataSource = dtOptions;
            drpMarket.CssClass = "form-control";
            drpMarket.DataTextField = "staff_name";
            drpMarket.DataValueField = "id";
            drpMarket.DataBind();
            drpMarket.Items.Insert(0, new ListItem("Select Marketer", "-1"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string expMessage = "";
            string qteQty = lblQtQty.Value;
            double dblqteQty = double.Parse(qteQty);
            if(string.IsNullOrEmpty(qteQty))
            {
                lblMessage.Text = "Input Valid Product/Quantity";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
            
            // string strqtbo = (string.IsNullOrEmpty(txtQTNo.Text)) ? "Q" + lblQoutNo.Text : txtQTNo.Text;
            string strqtbo = drpQuote.SelectedValue;
            // string strCostCenterID = drpCostCenter.SelectedItem.Value;
            string strCostCenterID = Session["costCenterID"].ToString();
            string strCustomer = custIDHide.Value;
            // string strProductID = drpProduct.SelectedItem.Value;

            //string strSalesRep = drpMarket.SelectedItem.Value; 
            //string strAmtLtr=txtAmtLtr.Text,strTotAmt=txtTotalAmt.Value;
            string strrmk = txtRemark.Value;
            string uname = Session["usr"].ToString();
            
            string strSubVat = (radVat.SelectedIndex == 0) ? lblVatWitholding2_1.Text : "0";
            string strSubWitholding = (radVat.SelectedIndex == 1) ? lblVatWitholding2_1.Text : "0";
            string strSubNCD = (chkNCD.SelectedIndex == 0) ? lblNCD.Text : "0";
            if (validateField().Equals(false))
            {
                return;
            }
            string expMess = "";
            //string subSubTotal = txtSubTotal.Text;
            string subSubTotal = lblSubTots.Text;
            string strTotalAmount = txtTotalAmt.Value;
            string sveType = btnSubmit.Text.Contains("Update") ? "Update" : "New";
            string strSalesRep = drpMarket.SelectedValue;
            string strProdID =lblProdID.Text;
            string strtxtQty = txtlblprdQty.Text;
            double dblTxtQty = double.Parse(strtxtQty);
            if(dblTxtQty > dblqteQty)
            {
                lblMessage.Text = " Insufficient Quantity";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
            string strtxtAmt_ltr = txtlblUPrice.Text;
            // string sbstring = strqtbo.Substring(1);
            Session["btnSubmit"] = btnSubmit.Text;
            string poNumber = btnSubmit.Text.Contains("Update") ? hidePO.Value : "P" + dtproc.gen_PO_Req();
            //string poNumber = "P" + dtproc.gen_PO_Req();
            string strSavePO = dtproc.insertPO(sveType, poNumber, custIDHide.Value, strSalesRep, strProdID,
            strtxtQty, strtxtAmt_ltr, strSubVat, strSubWitholding, strSubNCD, subSubTotal, strTotalAmount,
                txtAdd.Text, strrmk, uname, strCostCenterID, hosts, out expMess, strqtbo, lblQtQty.Value);
            if (strSavePO.Equals("Sussessful"))
            {
                //Update value
                //updQuoteDetailsQty( string in_QuoteNo, string in_product_id, string in_quantity)
                Response.Redirect("poSuccess.aspx?qt=" + strqtbo);
            }
        }
        public bool validateField()
        {
            /**/
            bool retValue = true;
            /*if (txtQTNo.Text.Length <3)
            {
                lblMessage.Text = "Enter Valid Quotation Number";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }*/

            return retValue;
        }
        public void fillFormBasedOnQuotation()
        {
            //DataTable getPOByID(string id, string connLocation, out string expMessage)
            string expMessage = "";
            string qtno = drpQuote.SelectedValue;
            //if(qtno.Contains(","))
                //qtno=qtno.Substring(0,qtno.Length-2);
                //qtno=qtno.Replace(",", "");
            double dblTots = 0, dblSubtotal = 0,dblQty=0,dblUPrice=0;
            //getCostCentersByID(string id, string connLocation, out string )
            // DataTable dtUpdPo = dtproc.getPOByID(qtno, hosts, out expMessage);
            DataTable dtUpdPo = dtproc.getQtByQtNo(qtno, hosts, out expMessage);

            double dblVAT = 0;
            double dblNCD2 = 0;
            int ct = dtUpdPo.Rows.Count;
            foreach (DataRow dr in dtUpdPo.Rows)
            {
                //drpCostCenter.SelectedValue=dr["CostCenterID"].ToString();
                //drpCustomer.SelectedValue=dr["CustomerID"].ToString();
                // drpQuote.SelectedValue = dr["QuotationID"].ToString();
                string strProduct = dr["product_ID"].ToString();
                CustomerOpt();
                if(!string.IsNullOrEmpty(strProduct))
                {
                    lblProduct.Text = dtproc.getProductById(strProduct, "", out expMessage);
                    lblProdID.Text = strProduct;
                    txtlblprdQty.Text= dr["quantity"].ToString();
                    lblQtQty.Value= dr["quantity"].ToString();
                    dblQty = double.Parse(dr["quantity"].ToString());
                    txtlblUPrice.Text= dr["amount_ltr"].ToString();
                    dblUPrice= double.Parse(dr["amount_ltr"].ToString());
                    dblSubtotal = dblQty * dblUPrice;
                    lblSubTots.Text = dblSubtotal.ToString();

                double dblNCD = double.Parse(dr["NCD"].ToString());
                double dblVats = double.Parse(dr["vat"].ToString());
                double dblWitholding = double.Parse(dr["witholding"].ToString());
                    if (dblNCD <= 0)
                    {
                        chkNCD.ClearSelection();//=true;
                        lblNCD.Text = "0";
                    }
                    double dblVatwitholdin = dblVats;
                    if (dblVatwitholdin > 0)
                    {
                        radVat.SelectedIndex = 0;
                        lblVatWitholding2.Text = "VAT(5%)";
                    }
                    else
                    {
                        radVat.SelectedIndex = 1;
                        lblVatWitholding2.Text = "Witholding TAX(5%)";
                    }
                         dblVAT = dblSubtotal * 0.05;
                        dblTots = dblTots + dblVAT;
                        lblVatWitholding2_1.Text = dblVAT.ToString();
                    if (dblNCD > 0)
                    {
                        chkNCD.SelectedIndex = 0;
                         dblNCD2 = dblSubtotal * 0.01;
                        dblTots = dblTots + dblNCD2;
                        lblNCD.Text = dblNCD2.ToString();
                    }
                }
            }
            dblTots = dblSubtotal + dblVAT + dblNCD2;
            txtTotalAmt.Value = dblTots.ToString();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("poAdd.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("poAdd.aspx");

        }

     
        protected void radVat_ServerChange(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }
        public Int32 calculateProduct()
        {
            Int32 retVal = 1;

            double  totVat = 0; //double totVat = 0;
            double totNCD = 0; //double totVat = 0;
            double subTot = 0;
            double dbQTY = 0, dblamt_ltr = 0;
            double grandTot = 0;
            double dblqty =  Convert.ToDouble(txtlblprdQty.Text);
            //double dblqty =  Convert.ToDouble(txtlblUPrice.Text);
            if (dblqty < 1)
            {
                lblMessage.Text = "Input valid Quantity for AGO Field";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                retVal = 0;
                return 0;
            }
            else lblMessage.Visible = false;
            double dbluprice =  Convert.ToDouble(txtlblUPrice.Text);
           
            if (dbluprice < 1)
            {
                lblMessage.Text = "Input valid value for AGO Price Per Liter Field";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                retVal = 0;
                return 0;
            }
            else lblMessage.Visible = false;


            if (dblqty > double.Parse(lblQtQty.Value))
            {
                lblMessage.Text = "Insufficient Quantity";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                retVal = 0;
                return 0;
            }
            else lblMessage.Visible = false;
            subTot = dblqty * dbluprice;
            totVat = subTot * 0.05;
            grandTot = subTot + totVat;
            double lineTotal = 0;
            if (chkNCD.SelectedIndex == 0)
            {
                totNCD = subTot * 0.01;
            //grandTot = subTot + totNCD;
            grandTot = subTot + totVat + totNCD;
            }
            if (radVat.SelectedIndex == 0)
                lblVatWitholding2.Text = "VAT";
            else
                lblVatWitholding2.Text = "Witholding TAX";
            lblVatWitholding2_1.Text = totVat.ToString();
            lblNCD.Text = totNCD.ToString();

            //double subtotAmt = subTpms + subTDPK + subTAGO;
            //double dblDPKQTY = 0, dblDPKamt_ltr, dblAGOQty = 0, dblAGOamt_ltr = 0, dblPMSQty = 0, dblPMSamt_lyr = 0;
             //txtSubTotal.Text = subTot.ToString();
             lblSubTots.Text = subTot.ToString();
                txtTotalAmt.Value = grandTot.ToString();
            return retVal;
        }
        protected void radWitholding_ServerChange(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void chkNCD_ServerChange(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }
        
        protected void radVat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void chkNCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void drpQuote_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillFormBasedOnQuotation();
        }

        protected void txtlblprdQty_TextChanged(object sender, EventArgs e)
        {

            if (calculateProduct() < 1) return;
        }

        protected void txtlblUPrice_TextChanged(object sender, EventArgs e)
        {

            if (calculateProduct() < 1) return;
        }
    }
}