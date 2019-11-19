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
    public partial class Customers : System.Web.UI.Page
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
            DataTable dtCustomer = dtproc.getAllCustomers(hosts, out expMess);
            string tb_row = "";
            foreach (DataRow dr in dtCustomer.Rows)
            {
                string custID1 = dr["customer_id"].ToString();
                string custID2 = "<td><a href ='customersadd.aspx?id=" + custID1 + "'> " + custID1 + "</a></td>";
                string customerName = "<td>" + dr["customer_name"].ToString() + "</td>";
                string customerAdd = "<td>" + dr["address"].ToString() + "</td>";
                string customerEmail = "<td>" + dr["email"].ToString() + "</td>";
                DateTime tm = Convert.ToDateTime(dr["date_created"].ToString());
                var time = tm.ToString("dd/MM/yyyy h:mm:ss ", CultureInfo.InvariantCulture);
                string dateCreated = "<td>" + time + "</td>";
                string companyName = "<td>" + dr["companyname"].ToString() + "</td>";
                string customerPhone = "<td>" + dr["phone"].ToString() + "</td>";

                string viewQTDetails = "<td style='text-align:right;'><span title='Click Print Customer'><a href='CustPrint.aspx?id=" + custID1 + "'>" + "<img src='images/view.png' width='15' height='15' /></a></span></td>";

                tb_row = tb_row + "<tr>" + custID2 + customerName + customerAdd + customerEmail + companyName + customerPhone
                  + dateCreated + "</tr>";
            }
            Response.Write("<tbody>" + tb_row + "</tbody>");
            // return "<tbody>" + tb_row + "</tbody>";
        }
    }
}