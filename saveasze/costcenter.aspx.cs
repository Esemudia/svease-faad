using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace saveasze
{
    public partial class costcenter : System.Web.UI.Page
    {
        procedurs dtproc = new procedurs();
        SH1Encryption sh1 = new SH1Encryption();
        string hosts = "";
        string strID = "";


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void createTableBody()
        {
            string expMess = "";
            DataTable dtCostCenter = dtproc.getCostCenters(hosts, out expMess);
            string tb_row = "";
            foreach (DataRow dr in dtCostCenter.Rows)
            {
                string cs_id = "<td><a href='costcenterAdd.aspx?id=" + dr["id"].ToString() + "'>" + dr["CostCenterID"].ToString() + "</a></td>";
                string cs = "<td>" + dr["CostCenter"].ToString() + "</td>";
                string cs_add = "<td>" + dr["adress"].ToString() + "</td>";
                string cs_st = "<td>" + dr["state"].ToString() + "</td>";
                string cs_lg = "<td>" + dr["lga"].ToString() + "</td>";
                string cs_ph = "<td>" + dr["ContactPhone"].ToString() + "</td>";
                string cs_em = "<td>" + dr["emailAddress"].ToString() + "</td>";
                tb_row = tb_row + "<tr>" + cs_id + cs + cs_add + cs_st + cs_lg + cs_ph + cs_em + "</tr>";
            }
            Response.Write("<tbody>" + tb_row + "</tbody>");
            // return "<tbody>" + tb_row + "</tbody>";
        }
    }
}