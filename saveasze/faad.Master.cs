using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace saveasze
{
    public partial class faad : System.Web.UI.MasterPage
    {
        string costcntername = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usr"] == null)
                Response.Redirect("login.aspx");
            /*
            Session["usr"] = "jo@jo.com";
            Session["usremail"] = "jo@jo.com";
            Session["usrID"] = "2";
            Session["usrType"] = "Customer Care";
            Session["usrFullName"] = "Jonathan Ataisi";
            Session["usrAccessCtrl"] = "0";
            Session["usrApproval"] = "";
            Session["address"] = "Cost Center Address";
            Session["costCenterName"] = "FAAD";
            Session["costCenterPhone"] = "08035529398";
            Session["costCenterAdd"] = "1 GRA phc";
            Session["costCenterEmail"] = "info@faad.com";
    */
            // retCostCenterName();
            retCostCenterID();
        }
        public void appName()
        {
            // = "FAADInv";
            Response.Write(Session["AppName"].ToString());
        }
        public void retCostCenterName()
        {

            Response.Write(Session["costCenterName"].ToString());
        }
        public void retCostCenterID()
        {
            // Session["costCenterID"].ToString();
            // Response.Write(Session["costCenterID"].ToString());
        }
        public void fullname()
        {
            Response.Write(Session["usrFullName"].ToString());
        }
        public void retCostCenterLogo()
        {
            // Session["logo"] = "images/"+"faad-logo.png";
            Response.Write(Session["logo"].ToString());
        }
    }

}