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
    public partial class atlAdd : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // costCenterOpt();
                // productOpt();
                //CustomerOpt();
                getTrucks();
                // SearchPO1();
                dispPO();
                getAllTanks(lblcostCenterID.Text);
                /*
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //DataTable getPOByID(string id, string connLocation, out string expMessage)
                    string expMessage = "";
                    strID = Request.QueryString["id"].ToString();
                    btnSubmit.InnerText = "Update";
                    //getCostCentersByID(string id, string connLocation, out string )
                    DataTable dtUpdPo = dtproc.getPOByID(strID, hosts, out expMessage);
                    foreach (DataRow dr in dtUpdPo.Rows)
                    {
                        drpCostCenter.SelectedValue=dr["CostCenterID"].ToString();
                        drpCustomer.SelectedValue=dr["CustomerID"].ToString();
                        drpProduct.SelectedValue=dr["Product_id"].ToString();
                        txtQty.Text=dr["Qty"].ToString();
                        txtAmtLtr.Text=dr["Amount_ltr"].ToString();
                        txtTotalAmt.Value = dr["total_amount"].ToString();
                        txtDelAddress.Value = dr["deliveryAddress"].ToString();
                        txtRemark.Value = dr["remarks"].ToString();
                        lblPO.Text=dr["po_number"].ToString();

                        double totAmt = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtAmtLtr.Text);
                        double vat = totAmt * 0.05;
                        txtVat.Value = vat.ToString();
                        double totAmtVat = vat + totAmt;
                        txtTotalAmt.Value = totAmtVat.ToString();
                    }

                }*/
            }
        }
        /*
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]*/
        public void SearchPO1()
        {
            DataTable dt = new DataTable();
            string expMess = "";
            //getPOLike(string po, string connLocation, out string expMessage)
            dt = dtproc.getApprovedPO("", "A", "", out expMess);
            drppo.DataSource = dt;
            drppo.CssClass = "form-control";
            drppo.DataTextField = "pocompany";
            drppo.DataValueField = "po_number";
            drppo.DataBind();
            drppo.Items.Insert(0, new ListItem("Select Purchase Order", "-1"));
        }
        public void dispPO()
        {
            DataTable dt = new DataTable();
            string expMess = "";
            //getPOLike(string po, string connLocation, out string expMessage)
            dt = dtproc.getAllATLPO("","ATL","", out expMess);
            //dt = dtproc.getApprovedPO("", "A", "", out expMess);
            drppo.DataSource = dt;
            drppo.CssClass = "form-control";
            drppo.DataTextField = "drpPO";
            drppo.DataValueField = "po_number";
            drppo.DataBind();
            drppo.Items.Insert(0, new ListItem("Select Purchase Order", "-1"));
        }

        public void getTrucks()
        {
            string expMess = "";
            //getCostCenters
            //getAllTrucks(string connLocation, out string expMessage)
            DataTable dtOptions = dtproc.getAllTrucks(hosts, out expMess);

            drpTruck.DataSource = dtOptions;
            drpTruck.CssClass = "form-control";
            drpTruck.DataTextField = "capacity";
            drpTruck.DataValueField = "vehicle_number";
            drpTruck.DataBind();
            drpTruck.Items.Insert(0, new ListItem("Select Vehicle", "-1"));
        }
        public void getAllTanks(string cs)
        {
            string expMess = "";
            //getCostCenters
            //getTankByType(string cs,string type,string connLocation, out string expMessage)
            // DataTable dtOptions = dtproc.getAllTanks2(cs,hosts, out expMess);
            DataTable dtOptions = dtproc.getAllTanks2("0123456", hosts, out expMess);

            drpTank.DataSource = dtOptions;
            drpTank.CssClass = "form-control";
            drpTank.DataTextField = "tankDesc";
            drpTank.DataValueField = "Tanks_id";
            drpTank.DataBind();
            drpTank.Items.Insert(0, new ListItem("Select Source Tank", "-1"));
        }
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string strCostCenterID = lblcostCenterID.Text;
            string strAgoQTY = txtAGOQty.Text;
            string strAgoUprice = txtAGOuPrice.Text;
            string strAgoTotal= lblTotAGOAmount.Text;
            string strDPKQTY = txtDPKQty.Text;
            string strDPKUprice = txtDPKuPrice.Text;
            string strDPKTotal= lblTotDPKAmount.Text;
            string strPMSQTY = txtPMSQty.Text;
            string strPMSUprice = txtPMSuPrice.Text;
            string strPMSTotal= lblTotPMSAmount.Text;
            string strAtlID = lblATLID.Text;
            string strPo = drppo.SelectedValue;
            string strCustomer = lblcustomerID.Text;
            string strSalesRep = lblSalesRep.Text;
            string strproDens = txtDensity.Value;
            string strTank = drpTank.SelectedValue;
            string strTruck = drpTruck.SelectedValue;
            string comments = txtRemark.Value;
            string strStaffID = "2";
            string expMess = "";
            // string strTank = lblt

            Int32 ctrATL = dtproc.existATL(strPo, hosts, out expMess);
            if (ctrATL > 0 && strAtlID != "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "ATL " + strPo + " is created or already exist";
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
            if (validateField().Equals(false)) return;


            //insertATL( PONo,  in_customerID,  in_salesRep, 
            // in_product_den,  truckid,  tankid,  remarks,staffID,  inAtlID,  connLocation, out string expMessage)
            string strSaveATL = dtproc.insertATL(strPo, strCustomer, strSalesRep, strproDens, strTruck, strTank, comments, strStaffID, strAtlID, hosts, out expMess);
            if (strSaveATL == "Sussessful")
            {
                //Update PO Status

                lblMessage.Visible = true;
                if (String.IsNullOrEmpty(strAtlID))
                    lblMessage.Text = "New ATL for PO - " + strPo + "- Created...";
                else
                    lblMessage.Text = " ATL for PO -" + strPo + "- updated...";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Failed..." + expMess;
                lblMessage.ForeColor = Color.OrangeRed;
            }/**/
        }
        public bool validateField()
        {
            bool retValue = true;
            if (drppo.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Valid Purchase Order";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }
            if (drpTank.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Valid Source Tank";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }
            if (drpTruck.SelectedIndex == 0)
            {
                lblMessage.Text = "Select Valid Truck";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }
            if (String.IsNullOrEmpty(txtDensity.Value))
            {
                lblMessage.Text = "Input valid Product Density";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }
            if (String.IsNullOrEmpty(txtDelAddress.Value) || txtDelAddress.Value.Length <= 10)
            {
                lblMessage.Text = "Input valid delivery address";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }
            if (String.IsNullOrEmpty(txtRemark.Value) || txtDelAddress.Value.Length <= 1)
            {
                lblMessage.Text = "Input comments or remarks for transaction";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return false;
            }
            else
            {
                lblMessage.Visible = false;
                retValue = true;
            }
            return retValue;
        }
        protected void drppo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string expMess = "";
            //getPOLike(string po, string connLocation, out string expMessage)
           // dt = dtproc.getApprovedPO(drppo.SelectedValue, "ATL", "", out expMess);
            dt = dtproc.getApprovedPO_ATL(drppo.SelectedValue, "ATL", "", out expMess);
            foreach (DataRow dr in dt.Rows)
            {
                lblcostCenterID.Text = dr["costcenterid"].ToString();
                lblcostCenter.Text = dr["costcenter"].ToString();
                lblCustomer.Text = dr["companyName"].ToString();
                lblcustomerID.Text = dr["customerid"].ToString();
                //lblProductID.Text = dr["product_id"].ToString();
                //lblProduct.Text = dr["productName"].ToString();
                //lblQty.Text = dr["Qty"].ToString();
                //lblAmtLtr.Text = dr["Amount_ltr"].ToString();
               // lblTotalAmt.Text = dr["total_amount"].ToString();
                lblSalesRep.Text = dr["salesRep"].ToString();
                lblStaffName.Text = dr["staff_name"].ToString();
                txtDelAddress.Value = dr["deliveryaddress"].ToString();
                // drpTruck.SelectedValue=dr["Amount_ltr"].ToString();
                txtAGOQty.Text = dr["AGO_Qty"].ToString();
                txtAGOuPrice.Text = dr["AGO_uprice"].ToString();
                double dbAGO = double.Parse(dr["AGO_Qty"].ToString()) * double.Parse(dr["AGO_uprice"].ToString());
                lblTotAGOAmount.Text = dbAGO.ToString();
                txtDPKQty.Text = dr["DPK_Qty"].ToString();
                txtDPKuPrice.Text = dr["DPK_uprice"].ToString();
                double dbDPK = double.Parse(dr["DPK_Qty"].ToString()) * double.Parse(dr["DPK_uprice"].ToString());
                lblTotDPKAmount.Text = dbDPK.ToString();
                txtPMSQty.Text = dr["PMS_Qty"].ToString();
                txtPMSuPrice.Text = dr["PMS_uprice"].ToString();
                double dbPMS = double.Parse(dr["PMS_Qty"].ToString()) * double.Parse(dr["PMS_uprice"].ToString());
                lblTotPMSAmount.Text = dbPMS.ToString();
                string strVat = dr["vat"].ToString();
                string strwitholding = dr["witholding"].ToString();
                string strncd = dr["NCD"].ToString();
                double dblSubTotal = dbPMS + dbDPK + dbAGO;
                txtSubTotal.Text = dblSubTotal.ToString();
                double grandTotal = 0;
                if ((!strVat.Equals("0") || !strwitholding.Equals("0")) && strncd.Equals("0"))
                    grandTotal = dblSubTotal + (dblSubTotal * 0.05);
                else if ((!strVat.Equals("0") || !strwitholding.Equals("0")) && !strncd.Equals("0"))
                    grandTotal = dblSubTotal + (dblSubTotal * 0.05) + (dblSubTotal * 0.01);
                else if ((strVat.Equals("0") && strwitholding.Equals("0")) && !strncd.Equals("0"))
                    grandTotal = dblSubTotal + (dblSubTotal * 0.01);
                else if ((strVat.Equals("0") && strwitholding.Equals("0")) && strncd.Equals("0"))
                    grandTotal = dblSubTotal;
                lblTotalAmt.Text = grandTotal.ToString();
                if (!strVat.Equals("0"))
                {
                    radVat.SelectedIndex = 1;
                }
                else
                {
                    radVat.SelectedIndex = 0;
                }
                if (!strncd.Equals("0"))
                {
                    chkNCD.SelectedIndex = 0;
                }
            }
        }
    }
}