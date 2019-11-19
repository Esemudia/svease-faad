using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace saveasze
{
    public partial class invoice : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        string strID = "";
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string expMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usr"] == null) Response.Redirect("login.aspx");
            if (Request.QueryString["id"] == null) Response.Redirect("Default.aspx");
            strID = Request.QueryString["id"].ToString();
            lblCostCenter.Text = Session["costCenterName"].ToString();
            lblCSAddress.Text = Session["costCenterAdd"].ToString();
            lblCSEmail.Text = Session["costCenterEmail"].ToString();
            lblCSPhone.Text = Session["costCenterPhone"].ToString();
            if (!Page.IsPostBack)
            {
                DataTable dtUpdPo = dtproc.getPOByID(strID, hosts, out expMessage);
                foreach (DataRow dr in dtUpdPo.Rows)
                {
                    lblPONo.Text = dr["po_number"].ToString();
                    lblInvNo.Text = "INV/" + dr["po_number"].ToString();
                    //drpCostCenter.SelectedValue=dr["CostCenterID"].ToString();
                    // getCustomerByID(dr["CustomerID"].ToString(), host, out  expMessage)
                    DataTable dtCust = dtproc.getCustomerByID1(dr["CustomerID"].ToString(), hosts, out expMessage);
                    foreach (DataRow drr in dtCust.Rows)
                    {
                        lblCustomer.Text = drr["customer_name"].ToString();
                        lblCustAdd.Text = drr["address"].ToString();
                        lblCustPhone.Text = drr["phone"].ToString();
                        lblCustEmail.Text = drr["email"].ToString();
                    }
                    lblMarketer.Text = dtproc.getStaffByID(dr["salesRep"].ToString(), hosts, out expMessage);
                    //getProductById(string pid, string connLocation, out string expMessage)
                    lblProduct.Text = dtproc.getProductById(dr["product_id"].ToString(), hosts, out expMessage);
                    lblQty.Text = dr["Qty"].ToString();
                    lblPPL.Text = dr["amount_ltr"].ToString();
                    double dblSubTotal = Double.Parse(dr["Qty"].ToString()) * Double.Parse(dr["amount_ltr"].ToString());
                    double vvat = dblSubTotal * 0.05;
                    double dblTotal = dblSubTotal + vvat;
                    lblSubTotal.Text = dblSubTotal.ToString();
                    lblVat.Text = vvat.ToString();
                    lblTotal.Text = dblTotal.ToString();
                    txtDesc.Value = dr["remarks"].ToString();

                    /*
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
                    txtTotalAmt.Value = totAmtVat.ToString();*/
                }
            }
        }

        protected void btnPrint_ServerClick(object sender, EventArgs e)
        {
            //btnPayment.Visible = false;
            //btnPdf.Visible = false;
            //btnPrint.Visible = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "print", "window.print();", true);
            //btnPayment.Visible = true;
            // btnPdf.Visible = true;
            //btnPrint.Visible = true;
        }

        public void appName()
        {
            Session["AppName"] = "FAADInv";
            Response.Write(Session["AppName"].ToString());
        }
        public void retCostCenterName()
        {
            Session["costCenterName"] = "FAAD";
            Response.Write(Session["costCenterName"].ToString());
        }

        public void retCostCenterLogo()
        {
            // Session["logo"] = "images/" + "faad-logo.png";
            Response.Write(Session["logo"].ToString());
        }
    }
}