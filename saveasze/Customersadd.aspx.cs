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
    public partial class Customersadd : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        string svType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string expMessage = "";
                    strID = Request.QueryString["id"].ToString();
                    svType = "Update";
                    btnSubmit.Text = "Update Customer ";
                    DataTable dtrNo = dtproc.getCustomerByID1(strID, hosts, out expMessage);
                    txtCustName.Text = dtrNo.Rows[0]["customer_name"].ToString();
                    txtCompName.Text = dtrNo.Rows[0]["companyName"].ToString();
                    txtEmail.Value = dtrNo.Rows[0]["email"].ToString();
                    txtAdd.Text = dtrNo.Rows[0]["address"].ToString();
                    txtPhone.Text = dtrNo.Rows[0]["phone"].ToString();

                }
            }
        }

            protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string expMessage = "";
            string strCustName = txtCustName.Text;
            string strCompName = txtCompName.Text;
            string strEmail = txtEmail.Value;
            string strPhone = txtPhone.Text;
            string strAddress = txtAdd.Text;
            svType = (btnSubmit.Text.Contains("Update")) ? "Update" : "New";
            string strCustID = (!string.IsNullOrEmpty(Request.QueryString["id"]))? Request.QueryString["id"].ToString() : dtproc.genID();
            Int32 existCust = dtproc.existCustName2(strEmail, strCompName, out expMessage);
            if(!btnSubmit.Text.Contains("Update") && existCust > 0)
            {
                lblMessage.Text = "Error: "+ strCompName + " Record Exist, Contact Admin for more info " ;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
            //string in_email, string in_companyName,string in_phone, string connLocation, out string expMessage)
            string rsresult = dtproc.insertCustomers(svType,strCustID, strCustName, strAddress, strEmail,
                strCompName, strPhone,"",out expMessage);
            if (rsresult.Equals("Sussessful"))
            {
                lblMessage.Text = "Customer Database Updated";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Green;
            }
                 else
            {

                lblMessage.Text = "Error creating customer "+ expMessage;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}