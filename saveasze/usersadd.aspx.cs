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
    public partial class usersadd : System.Web.UI.Page
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
                    DataTable dtUpdCC = dtproc.getStaffByID1(strID, hosts, out expMessage);
                    foreach (DataRow dr in dtUpdCC.Rows)
                    {
                      txtSName.Value = dr["staff_name"].ToString();
                      drpStaffType.SelectedItem.Text = dr["staff_type"].ToString();
                        txtEmail.Value = dr["staff_email"].ToString();
                        txtcphone.Value = dr["staff_phone"].ToString();
                        txtcAddress.Value = dr["staff_address"].ToString();
                        txtPwd.Disabled = true;
                        txtEmail.Disabled = true;
                        confPwd.Disabled = true;
                      //  txtcity.Value = dr["lga"].ToString();
                    }
                }
                hid.Value = strID;
            }

        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string expMessage = "";
            if (string.IsNullOrEmpty(txtSName.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Staff Name";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(txtcAddress.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Staff Address";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(txtcphone.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Staff Phone Number";
                return;
            }
            else lblMessage.Visible = false;
            if (drpStaffType.SelectedItem.Text.Contains("Staff Type"))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Select Valid Staff Type";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(txtEmail.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Staff Email Address";
                return;
            }
            else lblMessage.Visible = false;
            Int32 extCust = 0;
            if (String.IsNullOrEmpty(Request.QueryString["id"]))
            {
            if (string.IsNullOrEmpty(txtPwd.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Password";
                return;
            }
            else lblMessage.Visible = false;
            if (string.IsNullOrEmpty(confPwd.Value))
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Enter Confirm Password";
                return;
            }
            else lblMessage.Visible = false;
            if (txtPwd.Value!=confPwd.Value)
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = "Password and Confirm Password must be same";
                return;
            }
            else lblMessage.Visible = false;
                extCust = dtproc.existuser1(txtEmail.Value, hosts, out expMessage);
            }
            if (extCust > 0)
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                lblMessage.Text = " Staff/User information already exist";
                return;
            }
            else
            {
                //byte b = null;
                /*
                 insertstaff(string saveType, string staffType, string staffName, string staffPhone
            , string password, string email,string accCtrl, string status,string address,
            out string expMessage)
                 */
                string successRpt = dtproc.insertstaff(btnSubmit.InnerText.Contains("Update") ? "Update" : "New", 
                  drpStaffType.SelectedItem.Text,txtSName.Value,txtcphone.Value,txtPwd.Value,txtEmail.Value,
                   drpStaffType.SelectedItem.Value,"1", txtcAddress.Value, out expMessage);
                if (successRpt == "Sussessful")
                {
                    lblMessage.Visible = true;
                    if (String.IsNullOrEmpty(Request.QueryString["id"]))
                        lblMessage.Text = "New User/Staff -" + txtSName.Value + "- added...";
                    else
                        lblMessage.Text = " User/Staff -" + txtSName.Value + "- updated...";
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