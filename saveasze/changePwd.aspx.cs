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
    public partial class changePwd : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        string svType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
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
            }*/
        }

            protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string expMessage = "";
            string strEmail = Session["usremail"].ToString();
            string strOldPWD = oldPwd.Value;
            string strNewPWD = newPwd.Value;
            string strConfNewPWD = confNewPwd.Value;
            
            if(strNewPWD!= strConfNewPWD)
            {
                lblMessage.Text = "Error: New password and confirm password do not match! ";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
            DataTable dtLogin = dtproc.getLogin(strEmail, strOldPWD, "", out expMessage);
            if (dtLogin.Rows.Count <= 0)
            {
                lblMessage.Text = "Error: Current password not valid password... try again ";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }

            string strChangePassword = dtproc.ChangePassword(strEmail, strNewPWD, "", out expMessage);
            if(strChangePassword.Equals("Sussessful"))
            {
                lblMessage.Text = "Password Changed Successful";
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Error: "+ strChangePassword;
                lblMessage.Visible = true;
                lblMessage.ForeColor = Color.OrangeRed;
                return;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("changePwd.aspx");
        }
    }
}