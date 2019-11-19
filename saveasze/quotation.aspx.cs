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
    public partial class quotation : System.Web.UI.Page
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
        public void createTableBody()
        {
            string expMess = "";
            DataTable dtQuote = dtproc.getAllQuote(Session["costCenterID"].ToString(), hosts, out expMess);
            string tb_row = "";
            foreach (DataRow dr in dtQuote.Rows)
            {
                string csnmame = dtproc.getCostCentersByName(dr["CostCenterID"].ToString(), hosts, out expMess);
                string customerName = dtproc.getCustomerByID(dr["customerID"].ToString(), hosts, out expMess);
                string strQuoteNo = "";
                string strstatusCode = "";

                string ttAMT = dr["total_amount"].ToString();
                double dbTamt = Convert.ToDouble(ttAMT);
                ttAMT ="N"+ dbTamt.ToString("n", CultureInfo.CurrentCulture);
                String statusCode = dr["status"].ToString().Trim();
                string viewQTDetails = "<td style='text-align:right;'><span title='Click Print Quotation'><a href='QuotePrint.aspx?qt=" + dr["quoteNo"].ToString() + "'>" + "<img src='images/view.png' width='15' height='15' /></a></span></td>";

                if (statusCode != "Qt")
                {
                    strQuoteNo = "<td>" + dr["quoteNo"].ToString() + "</td>";
                    strstatusCode = "<td>" + statusCode + "</td>";
                }
                else
                {
                    strstatusCode = "<td> New Quotation</td>";
                    strQuoteNo = "<td><span title='tooltiptext'><a href='quotationAdd.aspx?id=" + dr["pi_id"].ToString() + "'>" + dr["quoteNo"].ToString() + "</a></span></td>";
                }
                string po_cs = "<td>" + customerName + "</td>";
                string po_amtltot = "<td>" + ttAMT + "</td>";
                DateTime tm = Convert.ToDateTime(dr["qtDate"].ToString());
                var time = tm.ToString("dd/MM/yyyy h:mm:ss ", CultureInfo.InvariantCulture);
                string qt_date = "<td>" + time + "</td>";
                //string po_date = "<td>" + dr["poDate"].ToString() + "</td>";
                string statusColor = "", statusvalue = "", statusvalueTooltip = "";
                statusCode = statusCode.Trim();
                string str_pi_id = dr["pi_id"].ToString();
                /*
                if (statusCode.Equals("QT"))
                {
                    statusColor = "<td bgcolor='yellow'>";
                    if(utype1=="MD")
                    statusvalue = "<a href='poApproval.aspx?id=" + str_pi_id + "&st="+"AA"+"'>AA</a>";//Awaiting Approval
                    // statusvalue = "<a href='poApproval.aspx?id=" + dr["pi_id"].ToString() + "'>Awaiting Approval</a>";
                    else
                    statusvalue = "AA";
                    statusvalueTooltip = "Awaiting Account Approval";
                }
                if (statusCode.Equals("AGM"))
                {
                    statusColor = "<td bgcolor='chartreuse'>";
                    if(utype1=="AGM")
                    statusvalue = "<a href='poApproval.aspx?id=" + str_pi_id + "&st=" + "AA" + "'>AGM</a>";//Awaiting Approval
                    // statusvalue = "<a href='poApproval.aspx?id=" + dr["pi_id"].ToString() + "'>Awaiting Approval</a>";
                    else
                    statusvalue = "AGM";
                    statusvalueTooltip = "Awaiting GM's Approval";
                }
                else if (statusCode.Equals("A")) 
                {
                    statusColor = "<td bgcolor='aqua'>";
                    statusvalue = "A";//Approved
                    statusvalueTooltip = "Approved";
                }
                else if (statusCode.Equals("D")) 
                {
                    statusColor = "<td bgcolor='OrangeRed'>";
                    statusvalue = "D";//Declined
                    statusvalueTooltip = "Declined";
                }
                else if (statusCode.Equals("C")) 
                {
                    statusColor = "<td bgcolor='Green'>";
                    statusvalue = "C";//Completed
                    statusvalueTooltip = "Completed";
                }*/
                //<div class="tooltip">Hover over me<span class='tooltiptext'>Tooltip text</span></div>
                string strTooltip1 = "<div class='tooltip'>" + statusvalue + "<span class='tooltiptext'>" + statusvalueTooltip + "</span></div>";
                string strTooltip2 = "<Span title='" + statusvalueTooltip + "'>" + statusvalue + "</span>";
                //string po_status = statusColor + dr["status"].ToString() + "</td>";
                string po_status = statusColor + strTooltip2 + "</td>";
                // string po_status = statusColor + statusvalue + "</td>";
                //tb_row = tb_row + "<tr>"+ viewQTDetails + strQuoteNo+ po_status + po_cs + po_amtltot
                tb_row = tb_row + "<tr>" + viewQTDetails + strstatusCode+strQuoteNo + po_status +  po_cs + po_amtltot
                   + qt_date + "</tr>";
                //+ po_delAdd + po_date + "</tr>";
            }
            Response.Write("<tbody>" + tb_row + "</tbody>");
            // return "<tbody>" + tb_row + "</tbody>";
        }
    }
}