using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace saveasze
{
    public partial class poApproval : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string expMessage = "";
                    string approvalDBType = "";
                    strID = Request.QueryString["id"].ToString();
                    double dblTots = 0, dblSubtotal = 0, dblTotPMS = 0, dblTotAGO = 0, dblTotDPK = 0;
                    DataTable dtUpdPo = dtproc.getPOByID(strID, hosts, out expMessage);
                    lblPO.Text = dtUpdPo.Rows[0]["po_number"].ToString();
                    lblQoutNo.Text = dtUpdPo.Rows[0]["quoteNo"].ToString();
                    approvalDBType= dtUpdPo.Rows[0]["statusCode"].ToString();
                    lblMarket.Text= dtproc.getStaffByID(dtUpdPo.Rows[0]["salesRep"].ToString(), "", out  expMessage);
                    lblCustomer.Text= dtproc.getCustomerByID(dtUpdPo.Rows[0]["customerID"].ToString(), "", out  expMessage);
                    txtAdd.Text = dtUpdPo.Rows[0]["deliveryAddress"].ToString();
                    txtAGOQty.Text=dtUpdPo.Rows[0]["AGO_Qty"].ToString();
                    txtAGOuPrice.Text=dtUpdPo.Rows[0]["AGO_uprice"].ToString();
                    double dbAGO = double.Parse(dtUpdPo.Rows[0]["AGO_Qty"].ToString()) * double.Parse(dtUpdPo.Rows[0]["AGO_uprice"].ToString());
                    lblTotAGOAmount.Text= dbAGO.ToString();
                    txtDPKQty.Text=dtUpdPo.Rows[0]["DPK_Qty"].ToString();
                    txtDPKuPrice.Text=dtUpdPo.Rows[0]["DPK_uprice"].ToString();
                    double dbDPK = double.Parse(dtUpdPo.Rows[0]["DPK_Qty"].ToString()) * double.Parse(dtUpdPo.Rows[0]["DPK_uprice"].ToString());
                    lblTotDPKAmount.Text= dbDPK.ToString();
                    txtPMSQty.Text=dtUpdPo.Rows[0]["PMS_Qty"].ToString();
                    txtPMSuPrice.Text=dtUpdPo.Rows[0]["PMS_uprice"].ToString();
                    double dbPMS = double.Parse(dtUpdPo.Rows[0]["PMS_Qty"].ToString()) * double.Parse(dtUpdPo.Rows[0]["PMS_uprice"].ToString());
                    lblTotPMSAmount.Text= dbPMS.ToString();
                    string strVat = dtUpdPo.Rows[0]["vat"].ToString();
                    string strwitholding = dtUpdPo.Rows[0]["witholding"].ToString();
                    string strncd = dtUpdPo.Rows[0]["NCD"].ToString();
                    double dblSubTotal = dbPMS + dbDPK + dbAGO;
                    txtSubTotal.Text = dblSubTotal.ToString();
                    double grandTotal = 0;
                    if ((!strVat.Equals("0") || !strwitholding.Equals("0")) && strncd.Equals("0"))
                        grandTotal = dblSubTotal + (dblSubTotal * 0.05);
                    else if ((!strVat.Equals("0") || !strwitholding.Equals("0")) && !strncd.Equals("0"))
                        grandTotal = dblSubTotal + (dblSubTotal * 0.05) + (dblSubTotal * 0.01);
                    else if ((strVat.Equals("0") && strwitholding.Equals("0")) && !strncd.Equals("0"))
                        grandTotal = dblSubTotal +  (dblSubTotal * 0.01);
                    else if ((strVat.Equals("0") && strwitholding.Equals("0")) && strncd.Equals("0"))
                        grandTotal = dblSubTotal;
                    txtTotalAmt.Value = grandTotal.ToString();
                    if (!strVat.Equals("0"))
                    {
                        radVat.SelectedIndex = 1;
                    }
                    else
                    {
                        radVat.SelectedIndex = 0;
                    }
                    if(!strncd.Equals("0"))
                    {
                        chkNCD.SelectedIndex = 0;
                    }
                    if(approvalDBType.Trim()=="AA")
                    {
                        apprBy.Text = "Account Approval Page";
                        drpApprovalType.Items.Add(new ListItem("Approve This Purchase Order", "AA"));
                        drpApprovalType.Items.Add(new ListItem("Decline This Purchase Order", "D"));
                    }
                    else if(approvalDBType.Trim() == "AGM")
                    {
                        apprBy.Text = "GM's Approval Page";
                        drpApprovalType.Items.Add(new ListItem("Approve This Purchase Order", "AGM"));
                        drpApprovalType.Items.Add(new ListItem("Decline This Purchase Order", "D"));
                    }
                    else if(approvalDBType.Trim() == "AMD")
                    {
                        apprBy.Text = "MD's Approval Page";
                        drpApprovalType.Items.Add(new ListItem("Approve This Purchase Order", "AMD"));
                        drpApprovalType.Items.Add(new ListItem("Decline This Purchase Order", "D"));
                    }
                }
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {

            string approvedType = "";
            string approvedTypeValue = "";
            string expMess = "";
            approvedType = drpApprovalType.SelectedItem.Text;
            approvedTypeValue = drpApprovalType.SelectedValue;
            //updPO_status(string PONo,string in_statusCode, string in_status, string connLocation, out string expMessage)
            string strSavePO = dtproc.updPO_status(lblPO.Text, approvedTypeValue, approvedType, txtRemark.Value, hosts, out expMess);
            btnSubmit.Disabled = true;
            if (strSavePO == "Sussessful")
            {
                lblMessage.Visible = true;
                lblMessage.Text = " Purchase Order -" + lblPO.Text + "- " + approvedType + "...";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Failed..." + expMess;
                lblMessage.ForeColor = Color.OrangeRed;
            }
        }
    }
}