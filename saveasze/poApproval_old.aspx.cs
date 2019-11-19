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
    public partial class poApproval_old : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Remove later
            Session["usrApproval"] = "1";

            if (Session["usrApproval"] == null)
            {
                tblApproval.Visible = false;
                divApproval.Visible = true;
                return;
            }
            else if (string.IsNullOrEmpty(Session["usrApproval"].ToString()))
            {
                tblApproval.Visible = false;
                divApproval.Visible = true;
                return;
            }
            else
            {
                tblApproval.Visible = true;
                divApproval.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["st"]))
                {
                    if (Request.QueryString["st"].ToString().Trim() == "AA")
                    {
                        drpApprovalType.Visible = true;
                        drpApprovalType2.Visible = false;
                    }
                    else
                    {
                        drpApprovalType.Visible = false;
                        drpApprovalType2.Visible = true;
                    }
                }
                costCenterOpt();
                productOpt();
                CustomerOpt();

                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //DataTable getPOByID(string id, string connLocation, out string expMessage)
                    string expMessage = "";
                    strID = Request.QueryString["id"].ToString();
                    btnSubmit.InnerText = "Approve Order";
                    //getCostCentersByID(string id, string connLocation, out string )
                    DataTable dtUpdPo = dtproc.getPOByID(strID, hosts, out expMessage);
                    foreach (DataRow dr in dtUpdPo.Rows)
                    {
                        drpCostCenter.SelectedValue = dr["CostCenterID"].ToString();
                        drpCustomer.SelectedValue = dr["CustomerID"].ToString();
                        drpProduct.SelectedValue = dr["Product_id"].ToString();
                        txtQty.Text = dr["Qty"].ToString();
                        txtAmtLtr.Text = dr["Amount_ltr"].ToString();
                        txtTotalAmt.Value = dr["total_amount"].ToString();
                        txtDelAddress.Value = dr["deliveryAddress"].ToString();
                        txtRemark.Value = dr["remarks"].ToString();
                        lblPO.Text = dr["po_number"].ToString();

                        double totAmt = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtAmtLtr.Text);
                        double vat = totAmt * 0.05;
                        txtVat.Value = vat.ToString();
                        double totAmtVat = vat + totAmt;
                        txtTotalAmt.Value = totAmtVat.ToString();
                    }

                }
            }
        }
        public void costCenterOpt()
        {
            string expMess = "";
            //getCostCenters
            DataTable dtOptions = dtproc.getCostCenters(hosts, out expMess);

            drpCostCenter.DataSource = dtOptions;
            drpCostCenter.CssClass = "form-control";
            drpCostCenter.DataTextField = "CostCenter";
            drpCostCenter.DataValueField = "CostCenterID";
            drpCostCenter.DataBind();
            drpCostCenter.Items.Insert(0, new ListItem("Select Cost Center", "-1"));
        }
        public void productOpt()
        {
            string expMess = "";
            //getCostCenters
            DataTable dtOptions = dtproc.getProduct(hosts, out expMess);

            drpProduct.DataSource = dtOptions;
            drpProduct.CssClass = "form-control";
            drpProduct.DataTextField = "productName";
            drpProduct.DataValueField = "product_id";
            drpProduct.DataBind();
            drpProduct.Items.Insert(0, new ListItem("Select Product", "-1"));
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
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string approvedType = "";
            string approvedTypeValue = "";
            if (drpApprovalType.Visible == true)
            {
                approvedType = drpApprovalType.SelectedIndex.Equals(0) ? "Awaiting GM's Approval" : "Decline";
                approvedTypeValue = drpApprovalType.SelectedValue;
            }
            else
            {
                approvedType = drpApprovalType2.SelectedIndex.Equals(0) ? "Approved" : "Decline";
                approvedTypeValue = drpApprovalType2.SelectedValue;
            }
            string expMess = "";

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


        protected void drpApprovalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpApprovalType.SelectedIndex == 0)
                btnSubmit.InnerText = "Approve Order";
            else
                btnSubmit.InnerText = "Decline Order";

        }
    }
}