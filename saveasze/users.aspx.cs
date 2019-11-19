using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace saveasze
{
    public partial class users : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        string utype = "CC";
        string utype1 = "MD";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void createTableBody2()
        {
            string expMess = "";
            DataTable dtStaff = dtproc.getAllStaff(hosts, out expMess);
            string tb_row = "";
            foreach (DataRow dr in dtStaff.Rows)
            {
                string userID1 = dr["id"].ToString();
                string uerName = dr["staff_name"].ToString();
                string userName2 = "<td><a href ='usersadd.aspx?id=" + userID1 + "'> " + uerName + "</a></td>";
                string staffType = "<td>" + dr["staff_type"].ToString() + "</td>";
                string staffEmail = "<td>" + dr["staff_email"].ToString() + "</td>";
                string staffPhone = "<td>" + dr["staff_phone"].ToString() + "</td>";
                string staffAdd = "<td>" + dr["staff_address"].ToString() + "</td>";
               

                string viewQTDetails = "<td style='text-align:right;'><span title='Click Print Users'><a href='usersPrint.aspx?id=" + userID1 + "'>" + "<img src='images/view.png' width='15' height='15' /></a></span></td>";

                tb_row = tb_row + "<tr>" + userName2 + staffType + staffEmail + staffPhone + staffAdd+ "</tr>";
            }
            Response.Write("<tbody>" + tb_row + "</tbody>");
            // return "<tbody>" + tb_row + "</tbody>";
        }
    }
}