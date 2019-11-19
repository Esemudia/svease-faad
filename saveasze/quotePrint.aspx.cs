using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace saveasze
{
    public partial class quotePrint : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        string strID = "";
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string expMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usr"] == null) Response.Redirect("login.aspx");
            if (Request.QueryString["qt"] == null) Response.Redirect("Default.aspx");
            strID = Request.QueryString["qt"].ToString();
            lblCostCenter.Text = Session["costCenterName"].ToString();
            lblCSAddress.Text = Session["costCenterAdd"].ToString();
            lblCSEmail.Text = Session["costCenterEmail"].ToString();
            lblCSPhone.Text = Session["costCenterPhone"].ToString();
            /*
            if(!Page.IsPostBack)
            {
                DataTable dtUpdPo = dtproc.getPOByID(strID, hosts, out expMessage);
                foreach (DataRow dr in dtUpdPo.Rows)
                {
                    lblQtNo.Text = dr["po_number"].ToString();
                    lblQtNo.Text= dr["po_number"].ToString();
                    DataTable dtCust = dtproc.getCustomerByID1(dr["CustomerID"].ToString(), hosts, out expMessage);
                    foreach (DataRow drr in dtCust.Rows)
                    {
                        lblCustomer.Text = drr["customer_name"].ToString();
                        lblCustAdd.Text = drr["address"].ToString();
                        lblCustPhone.Text = drr["phone"].ToString();
                        lblCustEmail.Text = drr["email"].ToString();
                            }
                }
            }
    */
        }
        public void showTableContent()
        {
            DataTable dtUpdQt = dtproc.getQtByQtNo(Request.QueryString["qt"].ToString(), hosts, out expMessage);
            double dblSubTotal = 0, dblTotal = 0, dblVatWitholding = 0, dblNCD = 0;
            string trv = "";
            int ctr = dtUpdQt.Rows.Count;
            foreach (DataRow drr in dtUpdQt.Rows)
            {
                trv = trv + "  <tr>";
                string tdv = "<td>" + dtproc.getProductById(drr["product_id"].ToString(), hosts, out expMessage) + "</td>";
                tdv = tdv + "<td>" + drr["amount_ltr"].ToString() + "</td>";
                tdv = tdv + "<td>" + drr["quantity"].ToString() + "</td>";
                double dblSubTotal1 = double.Parse(drr["amount_ltr"].ToString()) * double.Parse(drr["quantity"].ToString());
                dblSubTotal = dblSubTotal + dblSubTotal1;
                tdv = tdv + "<td>" + dblSubTotal1.ToString() + "</td>";
                tdv = tdv + "<td>" + drr["vat"].ToString() + "</td>";
                tdv = tdv + "<td>" + drr["witholding"].ToString() + "</td>";
                tdv = tdv + "<td>" + drr["NCD"].ToString() + "</td>";
                double dblTotal1 = dblSubTotal1 + double.Parse(drr["vat"].ToString()) + double.Parse(drr["witholding"].ToString())
                    + double.Parse(drr["NCD"].ToString());
                dblTotal = dblTotal + dblTotal1;
                tdv = tdv + "<td>" + dblTotal1.ToString() + "</td>";
                trv = trv + tdv + "</tr>";
            }

            dblVatWitholding = dblTotal * 0.05;
            lblVat.Text = dblVatWitholding.ToString();
            dblNCD = dblTotal * 0.01;
            lblNCD.Text = dblNCD.ToString();

            lblSubTotal.Text = dblTotal.ToString();
            dblTotal = dblVatWitholding + dblNCD + dblTotal;
            lblTotal.Text = dblTotal.ToString();
            Response.Write(trv);
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
            // Session["AppName"] = "FAADInv";
            Response.Write(Session["AppName"].ToString());
        }
        public void retCostCenterName()
        {
            // Session["costCenterName"] = "FAAD";
            Response.Write(Session["costCenterName"].ToString());
        }

        public void retCostCenterLogo()
        {
            // Session["logo"] = "images/" + "faad-logo.png";
            Response.Write(Session["logo"].ToString());
        }

        protected void btnPO_ServerClick(object sender, EventArgs e)
        {

        }
    }
}