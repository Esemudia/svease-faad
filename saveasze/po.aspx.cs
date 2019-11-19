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
    public partial class po : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        string utype = "CC";
        //string utype1 = "MD";
        string utype1 ="";

        protected void Page_Load(object sender, EventArgs e)
        {
         utype1 = Session["usrType"].ToString();
        }
        public void createTableBody()
        {
            string expMess = "";
            DataTable dtCostCenter = dtproc.getAllPO(hosts, out expMess);
            string tb_row = "";
            foreach (DataRow dr in dtCostCenter.Rows)
            {
                string csnmame = dtproc.getCostCentersByName(dr["CostCenterID"].ToString(), hosts, out expMess);
                string customerName = dtproc.getCustomerByID(dr["customerID"].ToString(), hosts, out expMess);
                // string customerName = dtproc.getCustomerByID("100100", hosts, out  expMess);
                string staffName = dtproc.getStaffByID(dr["salesRep"].ToString(), hosts, out expMess);
                //string product = dtproc.getProductByID(dr["product_id"].ToString(), hosts, out  expMess);
                // string cs = "<td>" + csnmame + "</td>";//hide cost center 
                string cs = "";//hide cost center 
                               /*
                                <div class="tooltip">Hover over me
                     <span class="tooltiptext">Tooltip text</span>
                   </div>*/
                string ttAMT = dr["total_amount"].ToString();
                String statusCode = dr["statusCode"].ToString().Trim();
                string vwToolTip = dr["po_number"].ToString() + "- " + customerName + "(Amount:" + ttAMT + ")";
                string qtno = dr["quoteNo"].ToString().Trim();
                string poinvoice = dr["invoiceNo"].ToString().Trim();
                // string viewPo = "<td style='text-align:right;'><span title='"+ vwToolTip+"'><a href='poVw.aspx?id=" + dr["pi_id"].ToString() + "'>" + "<img src='images/view.png' width='15' height='15' /></a></span></td>";
                string viewPo = "<td style='text-align:right;'><span title='Click For Detaled Purchase Order View'><a href='invoice.aspx?id=" + dr["pi_id"].ToString() + "'>" + "<img src='images/view.png' width='15' height='15' /></a></span></td>";
                string po_no = "";
                if (statusCode != "AA")
                    po_no = "<td>" + dr["po_number"].ToString() + "</td>";
                else
                    po_no = "<td><span title='tooltiptext'><a href='poAdd.aspx?id=" + dr["pi_id"].ToString() + "'>" + dr["po_number"].ToString() + "</a></span></td>";
                string po_cs = "<td>" + customerName + "</td>";
                string po_st = "<td>" + staffName + "</td>";
                string po_qtno = "<td>" + qtno + "</td>";
                string po_invoiceno = "<td>" + poinvoice + "</td>";
                string po_amtltot = "<td>" + ttAMT + "</td>";
                string po_delAdd = "<td>" + dr["deliveryAddress"].ToString() + "</td>";
                DateTime tm = Convert.ToDateTime(dr["poDate"].ToString());
                var time = tm.ToString("dd/MM/yyyy h:mm:ss ", CultureInfo.InvariantCulture);
                string po_date = "<td>" + time + "</td>";
                //string po_date = "<td>" + dr["poDate"].ToString() + "</td>";
                string statusColor = "", statusvalue = "", statusvalueTooltip = "";
                statusCode = statusCode.Trim();
                string str_pi_id = dr["pi_id"].ToString();
                if (statusCode.Equals("AA"))
                {
                    statusColor = "<td bgcolor='yellow'>";
                    if (utype1 == "Accountant")
                        statusvalue = "<a href='poApproval.aspx?id=" + str_pi_id + "&st=" + "AA" + "'>AA</a>";//Awaiting Approval
                                                                                                              // statusvalue = "<a href='poApproval.aspx?id=" + dr["pi_id"].ToString() + "'>Awaiting Approval</a>";
                    else
                        statusvalue = "AA";
                    statusvalueTooltip = "Awaiting Account Approval";
                }
                if (statusCode.Equals("AGM"))
                {
                    statusColor = "<td bgcolor='chartreuse'>";
                    if (utype1 == "GM" || utype1 == "MD")
                        statusvalue = "<a href='poApproval.aspx?id=" + str_pi_id + "&st=" + "AGM" + "'>AGM</a>";//Awaiting Approval
                                                                                                               // statusvalue = "<a href='poApproval.aspx?id=" + dr["pi_id"].ToString() + "'>Awaiting Approval</a>";
                    else
                        statusvalue = "AGM";
                    statusvalueTooltip = "Awaiting GM's Approval";
                }
                if (statusCode.Equals("AMD"))
                {
                    statusColor = "<td bgcolor='chartreuse'>";
                    if (utype1 == "GM" || utype1 == "MD")
                        statusvalue = "<a href='poApproval.aspx?id=" + str_pi_id + "&st=" + "AMD" + "'>AMD</a>";//Awaiting Approval
                                                                                                               // statusvalue = "<a href='poApproval.aspx?id=" + dr["pi_id"].ToString() + "'>Awaiting Approval</a>";
                    else
                       statusvalue = "AMD";
                    statusvalueTooltip = "Awaiting MD's Approval";
                }
                /*else if (statusCode.Equals("A"))
                {
                    statusColor = "<td bgcolor='aqua'>";
                    statusvalue = "A";//Approved
                    statusvalueTooltip = "Approved";
                }*/
                else if (statusCode.Equals("ATL"))
                {
                    statusColor = "<td bgcolor='aqua'>";
                    statusvalue = "ATL";//Approved
                    statusvalueTooltip = "Approved for ATL";
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
                }
                //<div class="tooltip">Hover over me<span class='tooltiptext'>Tooltip text</span></div>
                string strTooltip1 = "<div class='tooltip'>" + statusvalue + "<span class='tooltiptext'>" + statusvalueTooltip + "</span></div>";
                string strTooltip2 = "<Span title='" + statusvalueTooltip + "'>" + statusvalue + "</span>";
                //string po_status = statusColor + dr["status"].ToString() + "</td>";
                string po_status = statusColor + strTooltip2 + "</td>";
                // string po_status = statusColor + statusvalue + "</td>";
                tb_row = tb_row + "<tr>" + viewPo + po_status + po_qtno + po_no + po_cs + po_st + po_invoiceno + po_amtltot
                   + po_date + "</tr>";
                //+ po_delAdd + po_date + "</tr>";
            }
            Response.Write("<tbody>" + tb_row + "</tbody>");
            // return "<tbody>" + tb_row + "</tbody>";
        }
    }
}