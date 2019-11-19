using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace saveasze
{
    public partial class costcenterAdd : System.Web.UI.Page
    {

        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string expMessage = "";
                    strID = Request.QueryString["id"].ToString();
                    btnSubmit.InnerText = "Update";
                    //getCostCentersByID(string id, string connLocation, out string )
                    DataTable dtUpdCC = dtproc.getCostCentersByID(strID, hosts, out expMessage);
                    foreach (DataRow dr in dtUpdCC.Rows)
                    {
                        txtCName.Value = dr["CostCenter"].ToString();
                        txtcAddress.Value = dr["adress"].ToString();
                        txtcphone.Value = dr["contactPhone"].ToString();
                        txtEmail.Value = dr["emailAddress"].ToString();
                        txtstate.Value = dr["state"].ToString();
                        txtcity.Value = dr["lga"].ToString();
                    }
                }
                hid.Value = strID;
            }

        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string expMessage = "";
            if (string.IsNullOrEmpty(txtCName.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Company Name";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(txtcAddress.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Company Address";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(txtcphone.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Company Phone Number";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(txtstate.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Company state";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(txtcity.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Company City";
                return;
            }
            else lblMessage.Visible = false;
            Int32 extCust = 0;
            if (String.IsNullOrEmpty(Request.QueryString["id"]))
                extCust = dtproc.exisCostCenter(txtCName.Value, hosts, out expMessage);
            if (extCust > 0)
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = " Company/Cost center already exist";
                return;
            }
            else
            {
                //byte b = null;
                string successRpt = dtproc.insertCostCenter(btnSubmit.InnerText.Equals("Update") ? "Update" : "New", txtCName.Value,
                    txtcAddress.Value, txtcphone.Value, txtEmail.Value, txtstate.Value, txtcity.Value, hosts, out expMessage, hid.Value);
                if (successRpt == "Sussessful")
                {
                    lblMessage.Visible = true;
                    if (String.IsNullOrEmpty(Request.QueryString["id"]))
                        lblMessage.Text = "New Cost center -" + txtCName.Value + "- added...";
                    else
                        lblMessage.Text = " Cost center -" + txtCName.Value + "- update...";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Failed..." + expMessage;
                    lblMessage.ForeColor = Color.OrangeRed;
                }
            }

        }
    }
}