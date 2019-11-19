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
    public partial class quotationAdd : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  costCenterOpt();
                // productOpt();
                CustomerOpt();
                // marketerOpt();
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                   // lblQoutNo.Text = dtproc.gen_PO_Req();
                    //DataTable getPOByID(string id, string connLocation, out string expMessage)
                    string expMessage = "";
                    strID = Request.QueryString["id"].ToString();
                    btnSubmit.Text = "Update";
                    double dblTotPMS = 0, dblTotDPK=0, dblTotAGO=0;
                    double dblTots = 0, dblSubtotal=0;
                    //getCostCentersByID(string id, string connLocation, out string )
                    DataTable dtrqtNo = dtproc.getQuotationByID(strID, hosts, out expMessage);
                    string strqtNo = dtrqtNo.Rows[0]["quoteNo"].ToString(); //quoteNo
                    lblQoutNo.Text = strqtNo;
                    txtQTNo.Text = strqtNo;
                    txtQTNo.Enabled = false;
                    string strRmks = dtrqtNo.Rows[0]["remarks"].ToString();
                    txtRemark.Value = strRmks;
                    //DataTable dtUpdPo = dtproc.getPOByID(strID, hosts, out expMessage);
                    DataTable dtUpdPo = dtproc.getQuotationDetailsByID(strqtNo, hosts, out expMessage);
                    foreach (DataRow dr in dtUpdPo.Rows)
                    {
                        //drpCostCenter.SelectedValue=dr["CostCenterID"].ToString();
                        drpCustomer.SelectedValue = dr["CustomerID"].ToString();
                        txtTotalAmt.Value = dr["total_amount"].ToString();
                        string strproductName =  dr["productName"].ToString();
                        string strQty=dr["quantity"].ToString();
                        string struprice=dr["amount_ltr"].ToString();
                        if (!string.IsNullOrEmpty(strproductName) && !strQty.Equals("0") && strproductName.Equals("PMS"))
                        {
                            chkOMS.Checked = true;
                            lblPMSID.Text = "1";
                            txtPMSQty.Text = strQty;
                            txtPMSQty.Enabled = true;
                            txtPMSuPrice.Text = struprice;
                            txtPMSuPrice.Enabled = true;
                            double dbltootal = double.Parse(strQty) * double.Parse(struprice);
                            dblTotPMS = dbltootal;
                            lblTotPMSAmount.Text = dblTotPMS.ToString();
                        }
                        if(!string.IsNullOrEmpty(strproductName) && !strQty.Equals("0") && strproductName.Equals("DPK"))
                        {
                            chkDPK.Checked = true;
                            lblDPKID.Text = "3";
                            txtDPKQty.Text = strQty;
                            txtDPKQty.Enabled = true;
                            txtDPKuPrice.Text = struprice;
                            txtDPKuPrice.Enabled = true;
                            double dbltootal = double.Parse(strQty) * double.Parse(struprice);
                            dblTotDPK = dbltootal;
                            lblTotDPKAmount.Text = dblTotDPK.ToString();
                        }
                        if(!string.IsNullOrEmpty(strproductName) && !strQty.Equals("0") && strproductName.Equals("AGO"))
                        {
                            chkAGO.Checked = true;
                            lblAGOID.Text = "2";
                            txtAGOQty.Text = strQty;
                            txtAGOQty.Enabled = true;
                            txtAGOuPrice.Text = struprice;
                            txtAGOuPrice.Enabled = true;
                            double dbltootal = double.Parse(strQty) * double.Parse(struprice);
                            dblTotAGO = dbltootal;
                            lblTotAGOAmount.Text = dblTotAGO.ToString();
                        }
                        double dblNCD = double.Parse(dtUpdPo.Rows[0]["NCD"].ToString());
                        double dblVatwitholdin = double.Parse(dtUpdPo.Rows[0]["vat"].ToString());
                        dblTots = dblTots + dblTotPMS + dblTotDPK + dblTotAGO;
                        dblSubtotal = dblSubtotal + dblTotPMS + dblTotDPK + dblTotAGO;
                        if (dblVatwitholdin > 0)
                        {
                            radVat.SelectedIndex = 0;
                            lblVatWitholding2.Text = "VAT(5%)";
                            double dblVAT = (dblTotPMS + dblTotDPK + dblTotAGO) * 0.05;
                            dblTots = dblTots + dblVAT;
                            lblVatWitholding2_1.Text = dblTots.ToString();
                        }
                        else
                        {
                            radVat.SelectedIndex = 1;
                            lblVatWitholding2.Text = "Witholding TAX(5%)";
                            double dblVAT = (dblTotPMS + dblTotDPK + dblTotAGO) * 0.05;
                            dblTots = dblTots + dblVAT;
                            lblVatWitholding2_1.Text = dblTots.ToString();
                        }
                        if (dblNCD > 0)
                        {
                            chkNCD.SelectedIndex = 0;
                            double dblNCD2 = (dblTotPMS + dblTotDPK + dblTotAGO) * 0.01;
                            dblTots = dblTots + dblNCD2;
                            lblNCD.Text = dblNCD2.ToString();
                        }

                        txtSubTotal.Text = dblSubtotal.ToString();
                        txtTotalAmt.Value = dblTots.ToString();
                    }

                }
            }
        }
        public void CustomerOpt()
        {
            string expMess = "";
            //getCostCenters
            DataTable dtOptions = dtproc.getCustomer(hosts, out expMess);

            drpCustomer.DataSource = dtOptions;
            drpCustomer.CssClass = "form-control";
            drpCustomer.DataTextField = "customer_name";
            drpCustomer.DataValueField = "customer_id";
            drpCustomer.DataBind();
            drpCustomer.Items.Insert(0, new ListItem("Select Customer", "-1"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string expMessage = "";
            // string strqtbo = (string.IsNullOrEmpty(txtQTNo.Text)) ? "Q" + lblQoutNo.Text : txtQTNo.Text;
            string custNameStrip = drpCustomer.SelectedItem.Text;
            if(custNameStrip.Length>4)
            custNameStrip = custNameStrip.Substring(0, 4);
            string dd = DateTime.Today.Date.ToString("dd/MM/yy");
            string datess = dd ;
            string strqtbo = "Q" +"/"+ custNameStrip+"/"+ datess +"/"+ dtproc.gen_PO_Req();
            DataTable dtQuote = dtproc.getAllQuoteByQN(strqtbo, out expMessage);
            //if (dtQuote.Rows.Count > 0) return;
            if (chkAGO.Checked == false && chkDPK.Checked == false && chkOMS.Checked == false)
            {
                lblMessage.Text = "Eror creating quotation";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
            else lblMessage.Visible = false;
            // string strCostCenterID = drpCostCenter.SelectedItem.Value;
            string strCostCenterID = Session["costCenterID"].ToString();
            string strCustomer = drpCustomer.SelectedItem.Value;
            // string strProductID = drpProduct.SelectedItem.Value;

            //string strSalesRep = drpMarket.SelectedItem.Value; 
            //string strAmtLtr=txtAmtLtr.Text,strTotAmt=txtTotalAmt.Value;
            string strrmk = txtRemark.Value;
            string uname = Session["usr"].ToString();
            string strtxtAGOQty = "", strtxtAGOAmt_ltr = "", strtxtAGOVat_witolding = "", strtxtAGONcd = "", strAGOTotal = "";
            string strtxtDPKQty = "", strtxtDPKAmt_ltr = "", strtxtDPKVat_witolding = "", strtxtDPKNcd = "", strDPKTotal = "";
            string strtxtPMSQty = "", strtxtPMSAmt_ltr = "", strtxtPMSVat_witolding = "", strtxtPMSNcd = "", strPMSTotal = "";
            if (chkAGO.Checked && !string.IsNullOrEmpty(txtAGOQty.Text) && !string.IsNullOrEmpty(txtAGOuPrice.Text))
            {
                strtxtAGOQty = txtAGOQty.Text;
                strtxtAGOAmt_ltr = txtAGOuPrice.Text;
                strtxtAGOVat_witolding = ((double.Parse(strtxtAGOQty) * double.Parse(strtxtAGOAmt_ltr)) * 0.05).ToString();
                if (chkNCD.SelectedIndex == 0)
                    strtxtAGONcd = ((double.Parse(strtxtAGOQty) * double.Parse(strtxtAGOAmt_ltr)) * 0.01).ToString();
                else
                    strtxtAGONcd = "0";
                double lntotal = double.Parse(strtxtAGONcd) + double.Parse(strtxtAGOVat_witolding);
                strAGOTotal = ((double.Parse(strtxtAGOQty) * double.Parse(strtxtAGOAmt_ltr)) + lntotal).ToString();
            }
            if (chkDPK.Checked && !string.IsNullOrEmpty(txtDPKQty.Text) && !string.IsNullOrEmpty(txtDPKuPrice.Text))
            {
                strtxtDPKQty = txtDPKQty.Text;
                strtxtDPKAmt_ltr = txtDPKuPrice.Text;
                strtxtDPKVat_witolding = ((double.Parse(strtxtDPKQty) * double.Parse(strtxtDPKAmt_ltr)) * 0.05).ToString();
                if (chkNCD.SelectedIndex == 0)
                    strtxtDPKNcd = ((double.Parse(strtxtDPKQty) * double.Parse(strtxtDPKAmt_ltr)) * 0.01).ToString();
                else
                    strtxtDPKNcd = "0";
                double lntotal = double.Parse(strtxtDPKNcd) + double.Parse(strtxtDPKVat_witolding);
                strDPKTotal = ((double.Parse(strtxtDPKQty) * double.Parse(strtxtDPKAmt_ltr)) + lntotal).ToString();
            }

            if (chkOMS.Checked && !string.IsNullOrEmpty(txtPMSQty.Text) && !string.IsNullOrEmpty(txtPMSuPrice.Text))
            {
                strtxtPMSQty = txtPMSQty.Text;
                strtxtPMSAmt_ltr = txtPMSuPrice.Text;
                strtxtPMSVat_witolding = ((double.Parse(strtxtPMSQty) * double.Parse(strtxtPMSAmt_ltr)) * 0.05).ToString();
                if (chkNCD.SelectedIndex == 0)
                    strtxtPMSNcd = ((double.Parse(strtxtPMSQty) * double.Parse(strtxtPMSAmt_ltr)) * 0.01).ToString();
                else
                    strtxtPMSNcd = "0";
                double lntotal = double.Parse(strtxtPMSNcd) + double.Parse(strtxtPMSVat_witolding);
                strPMSTotal = ((double.Parse(strtxtPMSQty) * double.Parse(strtxtPMSAmt_ltr)) + lntotal).ToString();
            }
            if (validateField().Equals(false))
            {
                return;
            }
            string expMess = "";
            string strTotalAmount = txtTotalAmt.Value;
            //save entry to database
            //insertPO(  string
            //in_userrName, string in_costCID, string connLocation, out string expMessage)
            string sveType = btnSubmit.Text.Contains("Update") ? "Update" : "New";
            //insertQuote(string savetype,string in_QuoteNo, string in_customerID, string in_remark,string in_userrName, string in_costCID,string in_total_amount,string connLocation, out string expMessage)
            string sveQoute = dtproc.insertQuote(sveType, strqtbo, drpCustomer.SelectedValue, strrmk,
                uname, strCostCenterID, strTotalAmount, "", out expMess);
            if (sveQoute.Equals("Sussessful"))
            {
                //, string in_quantity, string in_vat,
                //string in_witholding,string in_NCD, string in_total_amount, string connLocation, out string expMessage)
                if (chkAGO.Checked && !string.IsNullOrEmpty(txtAGOQty.Text) && !string.IsNullOrEmpty(txtAGOuPrice.Text))
                {
                    double vt = (lblVatWitholding2_1.Text.Equals("VAT")) ? double.Parse(strtxtAGOVat_witolding) : 0;
                    double wt = (lblVatWitholding2_1.Text.Contains("TAX")) ? double.Parse(strtxtAGOVat_witolding) : 0;
                    dtproc.insertQuoteDetails(sveType, strqtbo, "2", txtAGOuPrice.Text, txtAGOQty.Text, vt.ToString(), wt.ToString(),
                       strtxtAGONcd, strAGOTotal, "", out expMess);
                }
                if (chkDPK.Checked && !string.IsNullOrEmpty(txtDPKQty.Text) && !string.IsNullOrEmpty(txtDPKuPrice.Text))
                {
                    double vt = (lblVatWitholding2_1.Text.Equals("VAT")) ? double.Parse(strtxtDPKVat_witolding) : 0;
                    double wt = (lblVatWitholding2_1.Text.Contains("TAX")) ? double.Parse(strtxtDPKVat_witolding) : 0;
                    dtproc.insertQuoteDetails(sveType, strqtbo, "3", txtDPKuPrice.Text, txtDPKQty.Text, vt.ToString(), wt.ToString(),
                       strtxtDPKNcd, strDPKTotal, "", out expMess);
                }
                if (chkOMS.Checked && !string.IsNullOrEmpty(txtPMSQty.Text) && !string.IsNullOrEmpty(txtPMSuPrice.Text))
                {
                    double vt = (lblVatWitholding2_1.Text.Equals("VAT")) ? double.Parse(strtxtPMSVat_witolding) : 0;
                    double wt = (lblVatWitholding2_1.Text.Contains("TAX")) ? double.Parse(strtxtPMSVat_witolding) : 0;
                    dtproc.insertQuoteDetails(sveType, strqtbo, "3", txtPMSuPrice.Text, txtPMSQty.Text, vt.ToString(), wt.ToString(),
                       strtxtPMSNcd, strPMSTotal, "", out expMess);
                }
               /* Response.Redirect("QuoteSuccess.aspx?qt=" + strqtbo);
                 */ lblMessage.Text = "Quotation "+ strqtbo+" Created ";
                  lblMessage.Visible = true;
                  lblMessage.ForeColor = Color.Green;
                  return;
            }
        }
        public bool validateField()
        {
            /**/
            bool retValue = true;
            if (drpCustomer.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Valid Customer";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }
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


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("quotationAdd.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("quotationAdd.aspx");

        }

        protected void chkAGO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAGO.Checked == true)
            {
                txtAGOQty.Enabled = true;
                txtAGOuPrice.Enabled = true;
            }
            else
            {
                txtAGOQty.Text = "";
                txtAGOuPrice.Text = "";
                txtAGOQty.Enabled = false;
                txtAGOuPrice.Enabled = false;
                lblTotAGOAmount.Text = "";
                if (calculateProduct() < 1) return;
            }
        }

        protected void chkDPK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDPK.Checked == true)
            {
                txtDPKQty.Enabled = true;
                txtDPKuPrice.Enabled = true;
            }
            else
            {
                txtDPKQty.Text = "";
                txtDPKuPrice.Text = "";
                txtDPKQty.Enabled = false;
                txtDPKuPrice.Enabled = false;
                lblTotDPKAmount.Text = "";
                if (calculateProduct() < 1) return;
            }
        }

        protected void chkOMS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOMS.Checked == true)
            {
                txtPMSQty.Enabled = true;
                txtPMSuPrice.Enabled = true;
            }
            else
            {
                txtPMSQty.Text = "";
                txtPMSuPrice.Text = "";
                txtPMSQty.Enabled = false;
                txtPMSuPrice.Enabled = false;
                lblTotPMSAmount.Text = "";
                if (calculateProduct() < 1) return;
            }
        }

        protected void radVat_ServerChange(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }
        public Int32 calculateProduct()
        {
            Int32 retVal = 1;

            double vatDPK = 0, vatAGO = 0, vatpms = 0, totVat = 0; //double totVat = 0;
            double NCDDPK = 0, NCDAGO = 0, NCDpms = 0, totNCD = 0; //double totVat = 0;
            double subTDPK = 0, subTAGO = 0, subTpms = 0;
            double dblDPKQTY = 0, dblDPKamt_ltr = 0, dblAGOQty = 0, dblAGOamt_ltr = 0, dblPMSQty = 0, dblPMSamt_lyr = 0;
            if (chkAGO.Checked)
            {
                double dblqty = (string.IsNullOrEmpty(txtAGOQty.Text)) ? 0 : Convert.ToDouble(txtAGOQty.Text);
                dblAGOQty = dblqty;
                if (dblqty < 1)
                {
                    lblMessage.Text = "Input valid Quantity for AGO Field";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.OrangeRed;
                    retVal = 0;
                    return 0;
                }
                else lblMessage.Visible = false;
                double dbluprice = (string.IsNullOrEmpty(txtAGOuPrice.Text)) ? 0 : Convert.ToDouble(txtAGOuPrice.Text);
                dblAGOamt_ltr = dbluprice;
                if (dbluprice < 1)
                {
                    lblMessage.Text = "Input valid value for AGO Price Per Liter Field";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.OrangeRed;
                    retVal = 0;
                    return 0;
                }
                else lblMessage.Visible = false;
                subTAGO = dblqty * dbluprice;
                vatAGO = subTAGO * 0.05;
                double lineTotal = 0;
                if (chkNCD.SelectedIndex == 0)
                {
                    NCDAGO = subTAGO * 0.01;
                    lineTotal = vatAGO + NCDAGO + subTAGO;
                    // lineTotal = vatAGO + NCDAGO;
                }
                else
                    lineTotal = vatAGO + subTAGO;
                lblTotAGOAmount.Text = lineTotal.ToString();
            }
            if (chkDPK.Checked)
            {
                double dblqty = (string.IsNullOrEmpty(txtDPKQty.Text)) ? 0 : Convert.ToDouble(txtDPKQty.Text);
                dblDPKQTY = dblqty;
                if (dblqty < 1)
                {
                    lblMessage.Text = "Input valid Quantity for DPK Field";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.OrangeRed;
                    retVal = 0;
                    return 0;
                }
                else lblMessage.Visible = false;
                double dbluprice = (string.IsNullOrEmpty(txtDPKuPrice.Text)) ? 0 : Convert.ToDouble(txtDPKuPrice.Text);
                dblDPKamt_ltr = dbluprice;
                if (dbluprice < 1)
                {
                    lblMessage.Text = "Input valid value for DPK Price Per Liter Field";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.OrangeRed;
                    retVal = 0;
                    return 0;
                }
                else lblMessage.Visible = false;
                subTDPK = dblqty * dbluprice;
                vatDPK = subTDPK * 0.05;

                double lineTotal = 0;
                if (chkNCD.SelectedIndex == 0)
                {
                    NCDDPK = subTDPK * 0.01;
                    // lineTotal = vatDPK + NCDDPK;
                    lineTotal = vatDPK + NCDDPK + subTDPK;
                }

                else
                    lineTotal = vatAGO + subTDPK;
                lblTotDPKAmount.Text = lineTotal.ToString();
            }
            if (chkOMS.Checked)
            {
                double dblqty = (string.IsNullOrEmpty(txtPMSQty.Text)) ? 0 : Convert.ToDouble(txtPMSQty.Text);
                dblPMSQty = dblqty;
                if (dblqty < 1)
                {
                    lblMessage.Text = "Input valid Quantity for PMS Field";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.OrangeRed;
                    retVal = 0;
                    return 0;
                }
                else lblMessage.Visible = false;
                double dbluprice = (string.IsNullOrEmpty(txtPMSuPrice.Text)) ? 0 : Convert.ToDouble(txtPMSuPrice.Text);
                dblPMSamt_lyr = dbluprice;
                if (dbluprice < 1)
                {
                    lblMessage.Text = "Input valid value for PMS Price Per Liter Field";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.OrangeRed;
                    retVal = 0;
                    return 0;
                }
                else lblMessage.Visible = false;
                subTpms = dblqty * dbluprice;
                vatpms = subTpms * 0.05;

                double lineTotal = 0;
                if (chkNCD.SelectedIndex == 0)
                {
                    // NCDpms = subTpms * 0.01;
                    NCDpms = subTpms * 0.01;
                    //lineTotal = vatpms + NCDpms;
                    lineTotal = vatpms + NCDpms + subTpms;
                }
                else
                    lineTotal = vatpms + subTpms;
                lblTotPMSAmount.Text = lineTotal.ToString();
            }
            if (radVat.SelectedIndex == 0)
                lblVatWitholding2.Text = "VAT";
            else
                lblVatWitholding2.Text = "Witholding TAX";
            totVat = vatAGO + vatDPK + vatpms;
            lblVatWitholding2_1.Text = totVat.ToString();
            totNCD = NCDAGO + NCDDPK + NCDpms;
            lblNCD.Text = totNCD.ToString();

            //double subtotAmt = subTpms + subTDPK + subTAGO;
            //double dblDPKQTY = 0, dblDPKamt_ltr, dblAGOQty = 0, dblAGOamt_ltr = 0, dblPMSQty = 0, dblPMSamt_lyr = 0;
            double subtotAmt = (dblDPKQTY * dblDPKamt_ltr) + (dblAGOQty * dblAGOamt_ltr) + (dblPMSQty * dblPMSamt_lyr);
            txtSubTotal.Text = subtotAmt.ToString();
            if (chkNCD.SelectedIndex == 0)
            {
                double dblTotAmount = subtotAmt + ((subtotAmt * 0.05) + (subtotAmt * 0.01));
                txtTotalAmt.Value = dblTotAmount.ToString();
            }
            else
            {
                double dblTotAmount = subtotAmt + (subtotAmt * 0.05);
                txtTotalAmt.Value = dblTotAmount.ToString();
            }

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

        protected void txtAGOQty_TextChanged(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void txtAGOuPrice_TextChanged(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void txtDPKQty_TextChanged(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void txtDPKuPrice_TextChanged(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void txtPMSQty_TextChanged(object sender, EventArgs e)
        {
            if (calculateProduct() < 1) return;
        }

        protected void txtPMSuPrice_TextChanged(object sender, EventArgs e)
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
    }
}