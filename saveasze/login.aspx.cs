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
    public partial class login : System.Web.UI.Page
    {
        string strEmail = "";
        string strPwd = "";
        string expMessage = "";
        procedurs dtproc = new procedurs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["usr"] = null;
                Session["usremail"] = null;
                Session["usrID"] = null;
                Session["usrType"] = null;
                Session["usrFullName"] = null;
                Session["usrAccessCtrl"] = null;
                Session["usrApproval"] = null;
                CCOpt();
            }
        }
        public void CCOpt()
        {
            string expMess = "";
            //getCostCenters
            DataTable dtOptions = dtproc.getCostCenters("", out expMess);

            drpCC.DataSource = dtOptions;
            drpCC.CssClass = "form-control";
            drpCC.DataTextField = "costCenter";
            drpCC.DataValueField = "costcenterID";
            drpCC.DataBind();
            drpCC.Items.Insert(0, new ListItem("Select Company", "-1"));
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            strEmail = txtEmail.Value;
            strPwd = txtPwd.Value;
            if (drpCC.SelectedIndex == 0)
            {

                lblMessage.Text = "Select Valid Company";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            DataTable dtLogin = dtproc.getLogin(strEmail, strPwd, "", out expMessage);
            if (dtLogin.Rows.Count > 0)
            {
                foreach (DataRow dr in dtLogin.Rows)
                {
                    Session["usr"] = dr["staff_email"].ToString();
                    Session["usremail"] = dr["staff_email"].ToString();
                    Session["usrID"] = dr["id"].ToString();
                    Session["usrType"] = dr["staff_type"].ToString();
                    Session["usrFullName"] = dr["staff_name"].ToString();
                    Session["usrAccessCtrl"] = dr["accesscontrol"].ToString();
                    Session["usrApproval"] = "";
                    Session["address"] = dr["staff_address"].ToString();
                    DataTable dtCC = dtproc.getCostCentersByID(drpCC.SelectedValue, "", out expMessage);
                    foreach (DataRow drr in dtCC.Rows)
                    {
                        Session["costCenterName"] = drr["costcenter"].ToString();
                        Session["costCenterID"] = drr["costCenterID"].ToString();
                        Session["costCenterPhone"] = drr["contactphone"].ToString();
                        Session["costCenterAdd"] = drr["adress"].ToString();
                        Session["costCenterEmail"] = drr["emailAddress"].ToString();
                        Session["AppName"] = drr["costcenter"].ToString() + "Inv";
                        Session["logo"] = "images/logo/" + drr["logo"].ToString();
                    }
                }
                Response.Redirect("default.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Login, confirm login details and retry or contact system support";
                lblMessage.ForeColor = Color.Red;
                return;
            }

        }
    }
}