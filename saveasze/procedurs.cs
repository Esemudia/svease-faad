//using Sql.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;

namespace saveasze
{

    /// <summary>
    /// Summary description for procedurs
    /// </summary>
    public class procedurs
    {
        connString conn = new connString();
        public procedurs()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public int existUser(string uname, string pwd, string connLocation, out string expMessage)
        {
            string userid = uname;
            string password = pwd;
            Int32 intRecord = 0;
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = conn.connstring(connLocation);

                string query = "select staff_email,staff_password from [staff] where staff_email='" + userid + "'and staff_password='" + pwd + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    intRecord = dt.Rows.Count;

                }
                else
                {
                    intRecord = 0;
                }
                expMessage = "";
                con.Close();
            }
            catch (Exception ee)
            {
                expMessage = ee.Message;
            }

            return intRecord;
        }

        public DataTable getLogin(string uname, string pwd, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getStaffLogin";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@emailID", uname);
                        cmd.Parameters.AddWithValue("@pwd", pwd);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        public string ChangePassword(string uname, string pwd, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            //string constr = conn.connstring(connLocation);
            //string proc = "getbeneficiary2";
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("ChangePassword", con);

                cmd.Parameters.AddWithValue("@password", pwd);
                cmd.Parameters.AddWithValue("@email", uname);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        public int accessControl(string uname, out string displayName, string connLocation, out string strEmail, out string strPhone, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "accessControl";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_uname", uname);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                displayName = dt.Rows[0]["staff_name"].ToString();
                strEmail = dt.Rows[0]["staff_email"].ToString();
                strPhone = dt.Rows[0]["staff_phone"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                strEmail = "";
                strPhone = "";
                displayName = null;
            }
            return intRecord;
        }

        public string RegisterStaff(string accesscontrol, string staffid, string uname, string fname, string lname, string phone, string email, string position, string password, string address, string connLocation, out string expMessage)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("RegisterStaff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_staffid", staffid);
                cmd.Parameters.AddWithValue("@in_fname", fname);
                cmd.Parameters.AddWithValue("@in_lname", lname);
                cmd.Parameters.AddWithValue("@in_dname", lname + " " + fname);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                cmd.Parameters.AddWithValue("@in_username", uname);
                cmd.Parameters.AddWithValue("@in_password", password);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_position", position);
                cmd.Parameters.AddWithValue("@in_userlvl", accesscontrol);
                cmd.Parameters.AddWithValue("@in_status", 1);
                cmd.Parameters.AddWithValue(" @in_address", address);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }

        public string RegisterCustomer(string customerId, string customer_name, string address, string phone, string email, string Compa, string password, string connLocation, out string expMessage)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            //string saveaseid = genSaveaseID();
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("RegisterCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_Customerid ", customerId);
                cmd.Parameters.AddWithValue("@in_customer_name", customer_name);
                cmd.Parameters.AddWithValue("@in_address", address);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_password", password);
                cmd.Parameters.AddWithValue("@in_CompanyName", Compa);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        public DataTable getAllStaff(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getAllStaffs";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@in_uname", in_depositor);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        /*
        public int existCos(string custId, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existCustID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@incustid", custId);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                intRecord = Int32.Parse(dt.Rows[0]["counts"].ToString());
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return intRecord;
        }
    */
        public int existCos(string company, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existCustName";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@incompanyName", company);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                intRecord = Int32.Parse(dt.Rows[0]["counts"].ToString());
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return intRecord;
        }

        //
        //Start Product
        public DataTable getProduct(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getAllproduct";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@in_uname", in_depositor);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public string getProductById(string pid, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getProductByID";
            Int32 intRecord = 0;
            string pname = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", pid);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            foreach (DataRow dr in dt.Rows)
            {
                pname = dr["productName"].ToString();
            }
            return pname;
        }
        //End Product
        public DataTable getCustomer(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getAllCustomer";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@in_uname", in_depositor);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        public string insertSupply(string suplyid, string product, string datesup, string quantity, string supby, string price, string connLocation, out string expMessage)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            //string saveaseid = genSaveaseID();
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("InsertSupply", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_supid", suplyid);
                cmd.Parameters.AddWithValue("@in_prod", product);
                cmd.Parameters.AddWithValue("@in_datesup", datesup);
                cmd.Parameters.AddWithValue("@in_quantity", quantity);
                cmd.Parameters.AddWithValue("@in_supby", supby);
                cmd.Parameters.AddWithValue("@in_price", price);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }

        public int existsuplid(string supid, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existsupid";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@insupid", supid);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                intRecord = Int32.Parse(dt.Rows[0]["counts"].ToString());
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return intRecord;
        }
        //
        //Start Tank
        public DataTable geTankName(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            string proc = "getAllTank";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public string geTankNameByID(string tid, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            string proc = "getTankNameByID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", tid);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            string tname = "";
            foreach (DataRow dr in dt.Rows)
            {
                tname = dr["tankName"].ToString();
            }
            return tname;
        }
        public DataTable getAllTanks(string cs, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            string proc = "getTanksByCS";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@cs", cs);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getAllTanks2(string cs, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            string proc = "getAllTank";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_cs", cs);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getTankByType(string cs, string type, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            string proc = "getTankByType";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@cs", cs);
                        cmd.Parameters.AddWithValue("@prodType", type);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        //end Tank
        public string getCompanyName(string name, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getCompanyName";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return name;
        }

        public string genID()
        {
            Random rnd = new Random();
            string rands = "";
            // for (int i = 0; i < 2; i++)
            // {
            int myRandomNo = rnd.Next(10000, 99999);
            rands = rands + myRandomNo;
            // }
            return rands;
        }
        public string gen_PO_Req()
        {
            Random rnd = new Random();
            string rands = "";
            // for (int i = 0; i < 2; i++)
            // {
            int myRandomNo = rnd.Next(1000, 9999);
            rands = rands + myRandomNo;
            // }
            return rands;
        }
        public string retDateStrings()
        {
            string dtMonth = DateTime.Today.Month.ToString();
            string dtday = DateTime.Today.Day.ToString();
            string dtyear = DateTime.Today.Year.ToString();
            return dtday + dtMonth + dtyear;
        }
        public string insertOrder(string custname, string product, string comname, string quantity, string connLocation, out string expMessage)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("InsertOrderTbl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_custname", custname);
                cmd.Parameters.AddWithValue("@in_product", product);
                cmd.Parameters.AddWithValue("@in_comname", comname);
                cmd.Parameters.AddWithValue("@in_quantity", quantity);
                cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        //
        // FAAD
        //

        //start cost center
        public DataTable getCostCenters(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getAllCostCenters";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //    cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getCostCentersByID(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getCostCenterByID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public string getCostCentersByName(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getCostCenterByID";
            string name = "";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                name = dt.Rows[0]["CostCenter"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return name;
        }

        public int exisCostCenter(string cname, string connLocation, out string expMessage)
        {
            string compName = cname;
            Int32 intRecord = 0;
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = conn.connstring(connLocation);

                string query = "select costcenter from costcenter where costcenter='" + compName + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    intRecord = dt.Rows.Count;

                }
                else
                {
                    intRecord = 0;
                }
                expMessage = "";
                con.Close();
            }
            catch (Exception ee)
            {
                expMessage = ee.Message;
            }

            return intRecord;
        }
        public string insertCostCenter(string type, string cc, string address, string phone, string stremail,
           /* Byte logo,*/string state, string city, string connLocation, out string expMessage, string idd)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                string ctype = (type.Equals("Update", StringComparison.InvariantCultureIgnoreCase)) ? "updCostcenter" : "insertCostCenter";
                SqlCommand cmd = new SqlCommand(ctype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (string.IsNullOrEmpty(idd))
                    cmd.Parameters.AddWithValue("@in_CostCenterID", genID());
                else
                    cmd.Parameters.AddWithValue("@in_ID", idd);
                cmd.Parameters.AddWithValue("@in_CostCenter", cc);
                cmd.Parameters.AddWithValue("@in_adress", address);
                cmd.Parameters.AddWithValue("@in_contactPhone", phone);
                cmd.Parameters.AddWithValue("@in_emailAddress", stremail);
                //cmd.Parameters.AddWithValue("@in_logo", null);
                cmd.Parameters.AddWithValue("@in_state", state);
                cmd.Parameters.AddWithValue("@in_lga", city);
                //  cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }

        // end cost center
        // 
        //Start PO

        public DataTable getAllPO(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getAllPO";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //    cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getApprovedPO(string poNo, string appCode, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getPos";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_poNo", poNo);
                        cmd.Parameters.AddWithValue("@statusCode", appCode);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getApprovedPO_ATL(string poNo, string appCode, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getATLPO_drop";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_poNo", poNo);
                        cmd.Parameters.AddWithValue("@statusCode", appCode);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getPOByID(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getPOByID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getPOLike(string po, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getPoLike";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@po", po);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
     

        public string insertPO(string type, string PONo, string in_customerID, string in_salesRep, 
        string in_product_id, string in_quantity, string in_amount_ltr,string strVat,string strWitholding,
        string atrNCD,string subtotal,string in_total_amount, string in_deliveryAddress, string in_remark,
        string in_userrName, string in_costCID, string connLocation, out string expMessage,string in_quoteNo, 
        string oldQty)
        {
            Int32 k = 0;
            string iid = "";
            if (PONo.Contains(","))
            {
                string[] idz = PONo.Split(',');
                PONo = idz[0].ToString();
            }
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                string ctype = (type.Equals("Update", StringComparison.InvariantCultureIgnoreCase)) ? "updPO" : "InsertPO";
                SqlCommand cmd = new SqlCommand(ctype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                // if (string.IsNullOrEmpty(idd))
                cmd.Parameters.AddWithValue("@in_po_number", PONo);
                cmd.Parameters.AddWithValue("@in_customerID", in_customerID);
                cmd.Parameters.AddWithValue("@in_salesRep", in_salesRep);
                cmd.Parameters.AddWithValue("@in_product_id", in_product_id);
                cmd.Parameters.AddWithValue("@in_quantity", in_quantity);
                cmd.Parameters.AddWithValue("@in_amount_ltr", in_amount_ltr);
                cmd.Parameters.AddWithValue("@in_total_amount", in_total_amount);
                cmd.Parameters.AddWithValue("@in_deliveryAddress", in_deliveryAddress);
                cmd.Parameters.AddWithValue("@in_remark", in_remark);
                cmd.Parameters.AddWithValue("@in_computerName", computerName());
                cmd.Parameters.AddWithValue("@in_userrName", in_userrName);
                cmd.Parameters.AddWithValue("@in_costCID", in_costCID);
                if (in_quoteNo.Contains(","))
                {
                    string[] idz = in_quoteNo.Split(',');
                    in_quoteNo = idz[0].ToString();
                }
                cmd.Parameters.AddWithValue("@in_quoteNo", in_quoteNo);
                //  cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                double dblstrtxtQty = double.Parse(oldQty) - double.Parse(in_quantity);
                updQuoteDetailsQty(in_quoteNo, in_product_id, dblstrtxtQty.ToString());

                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }

        public string insertPO(string type, string PONo, string in_customerID, string in_salesRep, string strAGOID,
                string strDPKID, string strPMSID, string strtxtAGOQty, string strtxtDPKQty, string strtxtPMSQty,
                string strtxtAGOAmt_ltr, string strtxtDPKAmt_ltr, string strtxtPMSAmt_ltr, string strSubVat,
                string strSubWitholding, string strSubNCD, string subSubTotal, string strTotalAmount,
                string in_deliveryAddress, string in_remark, string in_userrName, string in_costCID,
                string connLocation, out string expMessage, string qtNo)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                string ctype = (type.Equals("Update", StringComparison.InvariantCultureIgnoreCase)) ? "updPONew" : "InsertPONew";
                SqlCommand cmd = new SqlCommand(ctype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                // if (string.IsNullOrEmpty(idd))
                cmd.Parameters.AddWithValue("@in_po_number", PONo);
                cmd.Parameters.AddWithValue("@in_customerID", in_customerID);
                cmd.Parameters.AddWithValue("@in_salesRep", in_salesRep);
                cmd.Parameters.AddWithValue("@in_AGO_ID", strAGOID);
                cmd.Parameters.AddWithValue("@in_AGO_Qty", strtxtAGOQty);
                cmd.Parameters.AddWithValue("@in_AGO_uprice", strtxtAGOAmt_ltr);
                cmd.Parameters.AddWithValue("@in_DPK_ID", strDPKID);
                cmd.Parameters.AddWithValue("@in_DPK_Qty", strtxtDPKQty);
                cmd.Parameters.AddWithValue("@in_DPK_uprice", strtxtDPKAmt_ltr);
                cmd.Parameters.AddWithValue("@in_PMS_ID", strPMSID);
                cmd.Parameters.AddWithValue("@in_PMS_Qty", strtxtPMSQty);
                cmd.Parameters.AddWithValue("@in_PMS_uprice", strtxtPMSAmt_ltr);
                cmd.Parameters.AddWithValue("@in_vat", strSubVat);
                cmd.Parameters.AddWithValue("@in_witholding", strSubWitholding);
                cmd.Parameters.AddWithValue("@in_NCD", strSubNCD);
                cmd.Parameters.AddWithValue("@in_subTotal", subSubTotal);
                cmd.Parameters.AddWithValue("@in_total_amount", strTotalAmount);
                cmd.Parameters.AddWithValue("@in_deliveryAddress", in_deliveryAddress);
                cmd.Parameters.AddWithValue("@in_remark", in_remark);
                cmd.Parameters.AddWithValue("@in_computerName", computerName());
                cmd.Parameters.AddWithValue("@in_userrName", in_userrName);
                cmd.Parameters.AddWithValue("@in_costCID", in_costCID);
                if (ctype.Equals("InsertPONew")) cmd.Parameters.AddWithValue("@in_quoteNo", qtNo);
                //  cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        public string updPO_status(string PONo, string in_statusCode, string in_status, string in_remarks, string connLocation, out string expMessage)
        {
            string po_status_code = "";
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                string ctype = "updPO_status";
                SqlCommand cmd = new SqlCommand(ctype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                // if (string.IsNullOrEmpty(idd))
                cmd.Parameters.AddWithValue("@in_po_number", PONo);
                if (in_statusCode.Equals("AA"))
                    in_statusCode = "AGM";
                else if (in_statusCode.Equals("AGM"))
                    in_statusCode = "AMD";
                else if (in_statusCode.Equals("AMD"))
                   // in_statusCode = "ATL";
                    in_statusCode = "RELN";
                cmd.Parameters.AddWithValue("@in_statusCode", in_statusCode);
                cmd.Parameters.AddWithValue("@in_status", in_status);
                cmd.Parameters.AddWithValue("@in_remarks", in_remarks);
                //  cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        //Get ComputerName

        public string computerName()
        {
            return Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
        //End PO
        // 
        //Start Customer
        public string getCustomerByQuoteID(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string iid = "";
            if (id.Contains(","))
            {
                string[] idz = id.Split(',');
                iid = idz[0].ToString();
            }
            else iid = id;
                
            string constr = conn.connstring(connLocation);
            string proc = "getCustomerByQuoteID";
            Int32 intRecord = 0;
            string name = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", iid);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                name = dt.Rows[0]["customerID"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return name;
        }
        public string getCustomerByID(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getCustomerByID";
            Int32 intRecord = 0;
            string name = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return name;
        }
        public DataTable getCustomerByID1(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getCustomerByID";
            Int32 intRecord = 0;
            string name = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        //end customer
        // 
        //Start Staff
        public string getStaffByID(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getStaffByID";
            Int32 intRecord = 0;
            string name = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                if (dt.Rows.Count > 0)
                    name = dt.Rows[0]["staff_name"].ToString();
                else name = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return name;
        }

        public DataTable getStaffByID1(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getStaffByID";
            Int32 intRecord = 0;
            string name = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                //name = dt.Rows[0]["staff_name"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getStaffByType(string staffTpe, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getStaffByType";
            Int32 intRecord = 0;
            string name = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_stafftype", staffTpe);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                //  name = dt.Rows[0]["staff_name"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        public string insertstaff(string saveType, string staffType, string staffName, string staffPhone
            , string password, string email,string accCtrl, string status,string address,
            out string expMessage)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            //string saveaseid = genSaveaseID();
            try
            {
                string constr = conn.connstring("");
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertstaff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_savetype", saveType);
                cmd.Parameters.AddWithValue("@in_staff_type", staffType);
                cmd.Parameters.AddWithValue("@in_staff_name", staffName);
                cmd.Parameters.AddWithValue("@in_staff_phone", staffPhone);
                cmd.Parameters.AddWithValue("@in_staff_password", password);
                cmd.Parameters.AddWithValue("@in_staff_email", email);
                cmd.Parameters.AddWithValue("@in_accesscontrol", accCtrl);
                cmd.Parameters.AddWithValue("@in_status", status);
                cmd.Parameters.AddWithValue("@in_staff_address", address);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }

        //end Staff
        // 
        //Start Product
        public string getProductByID(string id, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getProductByID";
            Int32 intRecord = 0;
            string name = "";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                name = dt.Rows[0]["productName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return name;
        }

        public string getProductTypeByTankID(string tid, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring(connLocation);
            string proc = "getTankNameByID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", tid);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            string tname = "";
            foreach (DataRow dr in dt.Rows)
            {
                tname = dr["product_type"].ToString();
            }
            return tname;
        }
        //end product
        //
        // Start ATL

        public int existuser1(string email, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existuser";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_uname", email);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                intRecord = dt.Rows.Count;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return intRecord;
        }
        public int existATL(string po, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existAtl";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@po", po);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                intRecord = Int32.Parse(dt.Rows[0]["counts"].ToString());
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return intRecord;
        }
        public DataTable getAllATL(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getAllATL";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //    cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getAllATLPO(string pono,string statusCode, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getATLPO_drop";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //    cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@in_poNo", pono);
                        cmd.Parameters.AddWithValue("@statusCode", statusCode);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getATLByID(string atlID, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getATLByID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", atlID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getATLByPO(string po, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getATLByPO";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@po", po);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        public string insertATL(string PONo, string in_customerID, string in_salesRep,
            string in_product_den, string truckid, string tankid, string remarks,
             string staffID, string inAtlID, string connLocation, out string expMessage)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                string ctype = "insertATL";
                SqlCommand cmd = new SqlCommand(ctype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                // if (string.IsNullOrEmpty(idd))
                cmd.Parameters.AddWithValue("@in_atlid", inAtlID);
                cmd.Parameters.AddWithValue("@in_po_number", PONo);
                cmd.Parameters.AddWithValue("@in_customerID", in_customerID);
                cmd.Parameters.AddWithValue("@in_salesRep", in_salesRep);
                cmd.Parameters.AddWithValue("@in_product_dens", in_product_den);
                cmd.Parameters.AddWithValue("@in_vehicle_id", truckid);
                cmd.Parameters.AddWithValue("@in_tank_id", tankid);
                cmd.Parameters.AddWithValue("@in_comment", remarks);
                cmd.Parameters.AddWithValue("@in_staff_id", staffID);
                //  cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
                updPO_statusATL(PONo,"ATLC","ATL Created", connLocation);
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        public void updPO_statusATL(string PONo,string statusCode,string status, string connLocation)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                string ctype = "updPO_stats";
               // string ctype = "updPO_statusATL";
                SqlCommand cmd = new SqlCommand(ctype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                // if (string.IsNullOrEmpty(idd))
                cmd.Parameters.AddWithValue("@in_po_number", PONo);
                cmd.Parameters.AddWithValue("@in_statusCode", statusCode);
                cmd.Parameters.AddWithValue("@in_status", status);
                //  cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception exp)
            {
                // expMessage = exp.Message;
                // dt = null;
            }
        }
        //End ATL
        //
        //start Vehicle

        public DataTable getAllTrucks(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getAllTrucks";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //    cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        //end vehicle

        //
        // Start Releasenote

        public DataTable getAllRelNotePO(string pono, string statusCode, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getRelPO_drop";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //    cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@in_poNo", pono);
                        cmd.Parameters.AddWithValue("@statusCode", statusCode);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        public DataTable getAllReleasenote(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getAllReleasenote";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //    cmd.Parameters.AddWithValue("@name", name);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        public string insertReleaseNote(string svaeType, string PONo, string in_customerID, string in_salesRep,
            string in_product_den, string truckid, string tankid, string remarks,
             string staffID, string inAtlID,string in_totalizer,string in_dipping,
             string in_variance, string in_quantity_loaded, string connLocation, out string expMessage)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                string ctype = (svaeType.Equals("New"))?"InsertReleaseNote":"";
                SqlCommand cmd = new SqlCommand(ctype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                // if (string.IsNullOrEmpty(idd))
                cmd.Parameters.AddWithValue("@in_po_number", PONo);
                cmd.Parameters.AddWithValue("@in_customerID", in_customerID);
                cmd.Parameters.AddWithValue("@in_salesRep", in_salesRep);
                cmd.Parameters.AddWithValue("@in_product_dens", in_product_den);
                cmd.Parameters.AddWithValue("@in_vehicle_id", truckid);
                cmd.Parameters.AddWithValue("@in_tank_id", tankid);
                cmd.Parameters.AddWithValue("@in_atlid", inAtlID);
                cmd.Parameters.AddWithValue("@in_totalizer", in_totalizer);
                cmd.Parameters.AddWithValue("@in_dipping", in_dipping);
                cmd.Parameters.AddWithValue("@in_variance", in_variance);
                cmd.Parameters.AddWithValue("@in_quantity_loaded", in_quantity_loaded);
                cmd.Parameters.AddWithValue("@in_comment", remarks);
                cmd.Parameters.AddWithValue("@in_staff_id", staffID);
                //  cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
                updPO_statusATL(PONo,"REL","Release Note Created", connLocation);
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        //End ReleaseNote
        //
        //Quotation
        //

        public DataTable getQuotePO(string costCenterID, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getQuotePO";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@costCenterID", costCenterID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getQuotationByID(string ID, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getQuotationByID";
            string qtNo = "";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", ID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                qtNo = dt.Rows[0]["quoteNo"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getQuotationDetailsByID(string ID, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getQuotationDetailsByID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ID", ID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public DataTable getAllQuote(string costCenterID, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getAllQuote";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_costCenter", costCenterID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        public DataTable getAllQuoteByQN(string QuoteNo, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = conn.connstring("");
            //string proc = "getbeneficiary2";
            string proc = "getAllQuoteByQN";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@QuoteNo", QuoteNo);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        public string insertQuote(string savetype, string in_QuoteNo, string in_customerID, string in_remark, string in_userrName, string in_costCID, string in_total_amount, string connLocation, out string expMessage)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                savetype = (savetype.Contains("Update")) ? "updQuote" : "InsertQuote";
                SqlCommand cmd = new SqlCommand(savetype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_QuoteNo", in_QuoteNo);
                cmd.Parameters.AddWithValue("@in_customerID", in_customerID);
                cmd.Parameters.AddWithValue("@in_remark", in_remark);
                cmd.Parameters.AddWithValue("@in_computerName", computerName());
                cmd.Parameters.AddWithValue("@in_userrName", in_userrName);
                cmd.Parameters.AddWithValue("@in_costCID", in_costCID);
                cmd.Parameters.AddWithValue("@in_total_amount", in_total_amount);
                // cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }
        public string insertQuoteDetails(string savetype, string in_QuoteNo, string in_product_id, string in_amount_ltr, string in_quantity, string in_vat,
            string in_witholding, string in_NCD, string in_total_amount, string connLocation, out string expMessage)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                savetype = (savetype.Contains("Update")) ? "updQuoteDetails" : "InsertQuoteDetails";
                SqlCommand cmd = new SqlCommand(savetype, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_QuoteNo", in_QuoteNo);
                cmd.Parameters.AddWithValue("@in_product_id", in_product_id);
                cmd.Parameters.AddWithValue("@in_amount_ltr", in_amount_ltr);
                cmd.Parameters.AddWithValue("@in_quantity", in_quantity);
                cmd.Parameters.AddWithValue("@in_vat", in_vat);
                cmd.Parameters.AddWithValue("@in_witholding", in_witholding);
                cmd.Parameters.AddWithValue("@in_NCD", in_NCD);
                cmd.Parameters.AddWithValue("@in_total_amount", in_total_amount);
                // cmd.Parameters.AddWithValue("@in_quantity", "PO/" + genID() + retDateStrings());
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }

        public string updQuoteDetailsQty( string in_QuoteNo, string in_product_id, string in_quantity)
        {
            Int32 k = 0;
            string expMessage = "";
            try
            {
                string constr = conn.connstring("");
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updQuoteDetailsQty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_QuoteNo", in_QuoteNo);
                cmd.Parameters.AddWithValue("@in_product_id", in_product_id);
                cmd.Parameters.AddWithValue("@in_quantity", in_quantity);
                con.Open();
                k = cmd.ExecuteNonQuery();
                con.Close();
                expMessage = "1";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }


        public DataTable getQtByQtNo(string id, string connLocation, out string expMessage)
        {
            string proc = ""; string prodID = ""; string qid = "";
            if (id.Contains(","))
            {
            string[] words = id.Split(',');
             qid = words[0].ToString();
             prodID = words[1].ToString();
             proc = "getQtByQtNo1";

            }
            else
            {
                qid = id;
             proc = "getQtByQtNo";

            }
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@quotation", qid);
                        if(id.Contains(","))
                        cmd.Parameters.AddWithValue("@productID", prodID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
        //Start Customer
        //Get All Customers grid Content
        public DataTable getAllCustomers(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getAllCustomers";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@in_costCenter", costCenterID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }

        //insert/update customer record
        public string insertCustomers(string svType,string in_custid, string in_customername, string in_customerAdd,
            string in_email, string in_companyName,string in_phone, string connLocation, out string expMessage)
        {
            Int32 k = 0;
            try
            {
                string constr = conn.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("InsertCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_savetype", svType);
                cmd.Parameters.AddWithValue("@in_custid", in_custid);
                cmd.Parameters.AddWithValue("@in_customername", in_customername);
                cmd.Parameters.AddWithValue("@in_customerAdd", in_customerAdd);
                cmd.Parameters.AddWithValue("@in_email", in_email);
                cmd.Parameters.AddWithValue("@in_companyName", in_companyName);
                cmd.Parameters.AddWithValue("@in_phone", in_phone);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return expMessage;
        }

        //exist customer record
        public Int32 existCustName2(string in_email, string in_companyName, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = conn.connstring("");
            string proc = "existCustName2";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@incompanyName", in_companyName);
                        cmd.Parameters.AddWithValue("@inemail", in_email);
                        //cmd.Parameters.AddWithValue("@in_costCenter", costCenterID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                intRecord = Int32.Parse(dt.Rows[0]["counts"].ToString());
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return intRecord;
        }
       
        /*
        public DataTable getQtByQtNo(string id, string connLocation, out string expMessage)
        {
            string[] words = id.Split(',');
            string qid = words[0].ToString();
            string prodID = words[1].ToString();
            DataTable dt = new DataTable();
            string constr = conn.connstring(connLocation);
            string proc = "getQtByQtNo";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@quotation", id);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // name = dt.Rows[0]["companyName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return dt;
        }
*/
        //End Quotation

    }
}
