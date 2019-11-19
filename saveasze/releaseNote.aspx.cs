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
    public partial class releaseNote : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";
        string utype = "CC";
        string utype1 = "MD";
        string strtankName = "";
        string strtankCapacity = "";
        string strVolInTank = "";
        string strProductType = "";
        string expMess = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // DataTable dtTanks = dtproc.getAllTanks(Session["costcenterID"].ToString(), hosts, out expMess);
            }
        }
        public void createTableBody()
        {
            string expMess = "";
            string strCostcenter = "";
            //getAllTanks(string cs,string connLocation, out string expMessage)
            //geTankNameByID(string tid, string connLocation, out string expMessage)

            DataTable dtReleaseNote = dtproc.getAllReleasenote(hosts, out expMess);//get atl based on costcenter
            string tb_row = "";
            foreach (DataRow dr in dtReleaseNote.Rows)
            {
                // string csnmame = dtproc.getCostCentersByName(dr["CostCenterID"].ToString(), hosts, out expMess);
                string customerName = dtproc.getCustomerByID(dr["customerID"].ToString(), hosts, out expMess);
                // string customerName = dtproc.getCustomerByID("100100", hosts, out  expMess);
                string staffName = dtproc.getStaffByID(dr["salesRep"].ToString(), hosts, out expMess);
                //string product = dtproc.getProductByID(dr["product_id"].ToString(), hosts, out  expMess);
                string product = dtproc.getProductTypeByTankID(dr["tanks_id"].ToString(), hosts, out expMess);
                string tanks = dtproc.geTankNameByID(dr["tanks_id"].ToString(), hosts, out expMess);
                string realeaseNotePO = dr["po"].ToString();//hide cost center 
                string cs = "";//hide cost center 
                               /*
                                <div class="tooltip">Hover over me
                     <span class="tooltiptext">Tooltip text</span>
                   </div>*/
                               //String statusCode = dr["statusCode"].ToString().Trim();
                string rsView = "<td><span title='Detailed View Of Release'><a href='releaseNoteView.aspx?id=" + dr["atlID"].ToString() + "'>View</a></span></td>";
                string atl_po = "<td>" + realeaseNotePO + "</td>";
                string atl_cu = "<td>" + customerName + "</td>";
                string atl_st = "<td>" + staffName + "</td>";
                string atl_prd = "<td>" + product + "</td>";
                string atl_prdDen = "<td>" + dr["productDensity"].ToString() + "</td>";
                string atl_Tank = "<td>" + tanks + "</td>";
                string atl_vehicle = "<td>" + dr["vehicleNumber"].ToString() + "</td>";
                string rsTotalizer = "<td>" + dr["totalizerReading"].ToString() + "</td>";
                string rsDipping = "<td>" + dr["dippingChart"].ToString() + "</td>";
                string rsvariance = "<td>" + dr["variance"].ToString() + "</td>";
                string rsQtyLoaded = "<td>" + dr["quntityLoaded"].ToString() + "</td>";
                // string atlByid = 
                DateTime tm = Convert.ToDateTime(dr["atlDate"].ToString());
                var time = tm.ToString("dd/MM/yyyy h:mm:ss ", CultureInfo.InvariantCulture);
                string atl_date = "<td>" + time + "</td>";
                DateTime rstm = Convert.ToDateTime(dr["relDate"].ToString());
                var rstime = rstm.ToString("dd/MM/yyyy h:mm:ss ", CultureInfo.InvariantCulture);
                string rs_date = "<td>" + rstime + "</td>";
                //string po_date = "<td>" + dr["poDate"].ToString() + "</td>";

                tb_row = tb_row + "<tr>" + rsView + atl_po + atl_cu + atl_st + atl_prd + atl_Tank + atl_vehicle
                   + rsTotalizer + rsDipping + rsvariance + rsQtyLoaded + rs_date + "</tr>";
            }
            Response.Write("<tbody>" + tb_row + "</tbody>");
            // return "<tbody>" + tb_row + "</tbody>";
        }
    }
}