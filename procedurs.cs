//using Sql.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace saveasze
{
    public class procedurs
    {
        connString constring = new connString();

        public int existUser(string uname, string pwd, string connLocation,out string expMessage)
        {
            string userid = uname;
            string password = pwd;
            Int32 intRecord = 0;
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring.connstring(connLocation);
                con.Open();
                //string subPWD = "";
                //subPWD = (password.Length > 30)?password.Substring(0, 30): password;
                string query = "select username,password from [users] where username='" + userid + "'and password='" + pwd + "'and status='1'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    intRecord = dt.Rows.Count;
                    //  MessageBox.Show("Login sucess Welcome to Homepage http://krishnasinghprogramming.nlogspot.com");
                    //  System.Diagnostics.Process.Start("http://krishnasinghprogramming.blogspot.com");
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
        public string getPawword(string uname, string pwd, out string mail, string connLocation,out string expMessage)
        {
            string userid = uname;
            string password = pwd, pwdReturn="";
            Int32 intRecord = 0;
                mail = "";
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring.connstring(connLocation);
                con.Open();
                //string subPWD = "";
                //subPWD = (password.Length > 30)?password.Substring(0, 30): password;
                string query = "select username,password,email from [users] where username='" + userid + "'and password='" + pwd + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    pwdReturn = dr["password"].ToString();
                    mail = dr["email"].ToString();
                }
                
                expMessage = "";
                con.Close();
            }
            catch (Exception ee)
            {
                expMessage = ee.Message;
            }

            return pwdReturn;
        }
        //Menu Top Group

        public int existUser1(string uname, string pwd, string connLocation,out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = (string.IsNullOrEmpty(pwd)) ? "existuser" : "existuserpwd";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_uname", uname);
                        //if (!string.IsNullOrEmpty(pwd)) cmd.Parameters.AddWithValue("@in_pwd", pwd);
                        if(proc.Equals("existuserpwd")) cmd.Parameters.AddWithValue("@in_pwd", pwd);
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



         public DataTable getUserDetails(string in_uname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "gettuser";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
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

        /*public int exisToken(string token, string connLocation,out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = (string.IsNullOrEmpty(pwd)) ? "existuser" : "existuserpwd";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_uname", uname);
                        if (!string.IsNullOrEmpty(pwd)) cmd.Parameters.AddWithValue("@in_pwd", pwd);

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
        
        public int exisToken(string token, string connLocation, out string expMessage)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;

            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("exisToken", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_token", token);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                //k = 1;
                con.Close();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                // dt = null;
            }
            return k;
        }
*/
        public int exisToken1(string token, string connLocation,out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "exisToken";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_token", token);

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


        public int exisbatchNo(string in_batch, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "exisBatch";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_batch", in_batch);

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

        public DataTable getUserbyToken(string token, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getUserByToken";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_token", token);
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
        public DataTable getMenuGroup(string connLocation,out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getMenuGroup";
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
                intRecord = Int32.Parse(dt.Rows[0]["counts"].ToString());
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }

        public DataTable getMenuDetails(string inParentID,string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getMenuDetails";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MENUID", inParentID);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }

        public Int32 accessControl(string uname, out string displayName, string connLocation, out string strEmail, out string strPhone, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
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
                displayName = dt.Rows[0]["fName"].ToString() + "  " + dt.Rows[0]["lName"].ToString();
                strEmail = dt.Rows[0]["email"].ToString();
                strPhone = dt.Rows[0]["phone"].ToString();
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
        public DataTable getLeftNavigation(Int32 accesscontrol, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "getLeftNavigation";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }


        public string Updatepassword(string uname, string password, string connLocation)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            string expMessage = "";

            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updatePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_uname", uname);
                cmd.Parameters.AddWithValue("@in_password", password);
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


        public string RegisterUser(Int32 accesscontrol,string fname, string lname,string phone, string email, string username, string password,string createdBy, string connLocation,string token,string status, string Bvn)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            string expMessage = "";
            //string saveaseid = genSaveaseID();
            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("RegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_fname", fname);
                cmd.Parameters.AddWithValue("@in_lname", lname);
                cmd.Parameters.AddWithValue("@in_dname", lname + " " + fname);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_saveaseid", phone);
                //cmd.Parameters.AddWithValue("@in_saveaseid", saveaseid);
                cmd.Parameters.AddWithValue("@in_createdBy", createdBy);
                cmd.Parameters.AddWithValue("@in_userlvl", accesscontrol);
                cmd.Parameters.AddWithValue("@in_token", token);
                cmd.Parameters.AddWithValue("@in_status", status);
                cmd.Parameters.AddWithValue("@in_Bvn", Bvn);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expMessage = "Sussessful";
                con.Close();
            }
            catch (Exception exp)
            {
                //expMessage = exp.Message;
                expMessage = "Fail";
               // dt = null;
            }
            return expMessage;
        }



        public string registerVendor1( string fname, string lname, string phone, string email, string username, string password, string createdBy, 
            string companyname,string passport, string caccert,  string cacdoc, string identitfication,  string vatreg,   string taxid,
            string address, string connLocation, string token, string status, string saveaseid)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            Int32 accesscontrol = 2;
            string expMessage = "";
            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("RegisterVendor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_fname", fname);
                cmd.Parameters.AddWithValue("@in_lname", lname);
                cmd.Parameters.AddWithValue("@in_dname", lname + " " + fname);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_saveaseid", saveaseid);
                cmd.Parameters.AddWithValue("@in_createdBy", createdBy);
                cmd.Parameters.AddWithValue("@in_userlvl", accesscontrol);
                cmd.Parameters.AddWithValue("@in_token", token);
                cmd.Parameters.AddWithValue("@in_status", status);

                cmd.Parameters.AddWithValue("@in_identificationType", identitfication);
                cmd.Parameters.AddWithValue("@in_passport", passport);
                cmd.Parameters.AddWithValue("@in_cacDoc", caccert);
                cmd.Parameters.AddWithValue("@in_allCAC", cacdoc);
                cmd.Parameters.AddWithValue("@in_VATReg", vatreg);
                cmd.Parameters.AddWithValue("@in_taxCert", taxid);

                cmd.Parameters.AddWithValue("@in_company", companyname);
                cmd.Parameters.AddWithValue("@in_CompanyAddress", address);
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

        public string registerVendor2(string fname, string lname, string phone, string email, string username, string password, string createdBy,
           string companyname, string address, string connLocation, string token, string status, string saveaseid,string in_bvn,string in_cacRegNo)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            Int32 accesscontrol = 2;
            string expMessage = "";
            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("RegisterVendor3", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_fname", fname);
                cmd.Parameters.AddWithValue("@in_lname", lname);
                cmd.Parameters.AddWithValue("@in_dname", lname + " " + fname);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_saveaseid", saveaseid);
                cmd.Parameters.AddWithValue("@in_createdBy", createdBy);
                cmd.Parameters.AddWithValue("@in_userlvl", accesscontrol);
                cmd.Parameters.AddWithValue("@in_token", token);
                cmd.Parameters.AddWithValue("@in_status", status);
                cmd.Parameters.AddWithValue("@in_company", companyname);
                cmd.Parameters.AddWithValue("@in_CompanyAddress", address);
                cmd.Parameters.AddWithValue("@in_bvn", in_bvn);
                cmd.Parameters.AddWithValue("@in_cacRegNo", in_cacRegNo);
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

        public string registerVendor( string fname, string lname, string phone, string email, string username, string password, string createdBy, 
            string companyname,string passport, Byte[] passportB, string caccert, Byte[] caccertB, string cacdoc, Byte[] cacdocB,
            string identitfication, Byte[] identitficationB, string vatreg,Byte[] vatregB,   string taxid, Byte[] taxidB,
            string address, string connLocation, string token, string status, string saveaseid)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            Int32 accesscontrol = 2;
            string expMessage = "";
            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("RegisterVendor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_fname", fname);
                cmd.Parameters.AddWithValue("@in_lname", lname);
                cmd.Parameters.AddWithValue("@in_dname", lname + " " + fname);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_saveaseid", saveaseid);
                cmd.Parameters.AddWithValue("@in_createdBy", createdBy);
                cmd.Parameters.AddWithValue("@in_userlvl", accesscontrol);
                cmd.Parameters.AddWithValue("@in_token", token);
                cmd.Parameters.AddWithValue("@in_status", status);

                cmd.Parameters.AddWithValue("@in_identificationType", identitfication);
                cmd.Parameters.AddWithValue("@in_identificationTypeB", identitficationB);
                cmd.Parameters.AddWithValue("@in_passport", passport);
                cmd.Parameters.AddWithValue("@in_passportB", passportB);
                cmd.Parameters.AddWithValue("@in_cacDoc", caccert);
                cmd.Parameters.AddWithValue("@in_cacDocB", caccertB);
                cmd.Parameters.AddWithValue("@in_allCAC", cacdoc);
                cmd.Parameters.AddWithValue("@in_allCACB", cacdocB);
                cmd.Parameters.AddWithValue("@in_VATReg", vatreg);
                cmd.Parameters.AddWithValue("@in_VATRegB", vatregB);
                cmd.Parameters.AddWithValue("@in_taxCert", taxid);
                cmd.Parameters.AddWithValue("@in_taxCertB", taxidB);

                cmd.Parameters.AddWithValue("@in_company", companyname);
                cmd.Parameters.AddWithValue("@in_CompanyAddress", address);
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


        public DataTable getProfiles(Int32 accesscontrol, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "getLeftNavigation";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }


        public DataTable getVendors(Int32 accesscontrol, string connLocation,string procc, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
           // string proc = "getAllActiveVendors";
            string proc = procc;
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
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }

        public DataTable loadBuyPinAll( string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            // string proc = "getAllActiveVendors";
            string proc = "getAllOrderByAdmin";
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
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }
        public Int32 saveOrder(string inorderstatus, string in_card_pin, string in_cardpin_sn, string in_orderNumber, string in_cardType, double in_cardAmount, double in_chargeOnCard,  double in_percentageCharg, string in_orderby, string in_computerName, string in_ipaddress, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
               // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertOrderDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);
                /* cmd.Parameters.AddWithValue("in_card_pin", genPin());
                cmd.Parameters.AddWithValue("in_cardpin_sn", genSN());*/
                cmd.Parameters.AddWithValue("in_orderNumber", in_orderNumber);
                cmd.Parameters.AddWithValue("in_cardType", in_cardType);
                cmd.Parameters.AddWithValue("in_cardAmount", in_cardAmount);
                cmd.Parameters.AddWithValue("in_chargeOnCard", in_chargeOnCard);
                cmd.Parameters.AddWithValue("@in_percentageCharg", in_percentageCharg);
                cmd.Parameters.AddWithValue("in_orderby", in_orderby);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_ipaddress", in_ipaddress);
                cmd.Parameters.AddWithValue("in_orderStatus", inorderstatus);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
            con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public DataTable getBalance(string inputParam, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            var theString = inputParam;
            bool digitsOnly = theString.All(char.IsDigit);
            string proc = (digitsOnly) ?"getBalance2":"getBalance";
            string paramValue = (digitsOnly) ? "@in_account" : "@in_uname";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(paramValue, inputParam);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public DataTable getBalance2(string inputParam, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getBalance2";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_account", inputParam);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }

        //Rebatch Pin

        public Int32 insertRebatch(string in_newOrderNumber,string in_newCardPin, string in_newSerialNumber,string in_oldOrderNumber, string in_oldCardPin, string in_oldSerialNumber, double in_amount, string in_orderby, string in_computerName, string in_ipaddress, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertRebatch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                //cmd.Parameters.AddWithValue("in_newOrderNumber", genPin());
                //cmd.Parameters.AddWithValue("in_cardpin_sn", genSN());
                cmd.Parameters.AddWithValue("in_newOrderNumber", in_newOrderNumber);
                cmd.Parameters.AddWithValue("in_newCardPin", in_newCardPin);
                cmd.Parameters.AddWithValue("in_newSerialNumber", in_newSerialNumber);
                cmd.Parameters.AddWithValue("in_oldOrderNumber", in_oldOrderNumber);
                cmd.Parameters.AddWithValue("in_oldCardPin", in_oldCardPin);
                cmd.Parameters.AddWithValue("in_oldSerialNumber", in_oldSerialNumber);
                cmd.Parameters.AddWithValue("in_amount", in_amount);
                cmd.Parameters.AddWithValue("in_rebatchBy", in_orderby);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_ipaddress", in_ipaddress);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public string genSN()
        {
            Random rnd = new Random();
            string rands = "";
            for (int i = 0; i < 2; i++)
            {
                int myRandomNo = rnd.Next(10000000, 99999999);
                rands = rands + myRandomNo;
            }
            return rands;
        }
  public string genPin()
        {
            Random rnd = new Random();
            string rands = "", rands1 = "";
            for (int i = 0; i < 2; i++)
            {
                int myRandomNo = rnd.Next(100000, 999999);
                rands = rands + myRandomNo;
            }
            return rands;
        }
        public string genSaveaseID()
        {
            Random rnd = new Random();
            string rands = "";
            for (int i = 0; i < 2; i++)
            {
                int myRandomNo = rnd.Next(10000, 99999);
                rands = rands + myRandomNo;
            }
            return rands;
        }
        public DataTable getAcct(string inputParam, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getAcct";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", inputParam);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public DataTable getEmail(string inputParam, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getEmail";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", inputParam);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public DataTable getBeneficiary(string inputParam, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getbeneficiary";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", inputParam);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public DataTable getBeneficiaryBank(string inputParam, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getbeneficiarybank";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", inputParam);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public int existBeneficiary(string in_saveaseID, string in_savedFor, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existBenificiary";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_saveaseID", in_saveaseID);
                        cmd.Parameters.AddWithValue("@in_savedFor", in_savedFor);
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
        public int existSaveaseId(string uname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existAccountNo2";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_accountNo", uname);
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
        public Int32 saveBeneficiary(string in_saveaseID, string savedFor,string bankname, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertSaveaseBeneficiary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("@in_saveaseID", in_saveaseID);
                cmd.Parameters.AddWithValue("@savedFor", savedFor);
                cmd.Parameters.AddWithValue("@BankName", bankname);
                con.Open();
                k = cmd.ExecuteNonQuery();
                k = 1;
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public Int32 saveBenficiary2(string in_uname, string savedFor, string bankname, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertSaveaseBeneficiary2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_uname", in_uname);
                cmd.Parameters.AddWithValue("savedFor", savedFor);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }
        public Int32 transferFund(float in_balB4Transfer, float amountTransfered, float balance, string beneficiaryAccount, string beneficaryName, string accountNo,
           string transferedBy, string in_computerName, string in_transferStatus, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string in_transferCode = "";
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("transferFund", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_transferCode", in_transferCode);
                cmd.Parameters.AddWithValue("amountTransfered", amountTransfered);
                cmd.Parameters.AddWithValue("balance", balance);
                cmd.Parameters.AddWithValue("beneficiaryAccount", beneficiaryAccount);
                cmd.Parameters.AddWithValue("beneficaryName", beneficaryName);
                cmd.Parameters.AddWithValue("accountNo", accountNo);
                cmd.Parameters.AddWithValue("transferedBy", transferedBy);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_transferStatus", in_transferStatus);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public DataTable getCardPin(string pin, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getPinDetails";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_pin", pin);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }

        //public DataTable usedPin(string pin, string connLocation, out string expMessage)
        //{
        //    DataTable dt = new DataTable();
        //    string constr = constring.connstring(connLocation);
        //    string proc = "UsedPin";
        //    Int32 intRecord = 0;
        //    try
        //    {

        //        using (SqlConnection con = new SqlConnection(constr))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(proc, con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@in_pin", pin);
        //                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                {
        //                    sda.Fill(dt);
        //                }
        //            }
        //        }
        //        expMessage = "";
        //    }
        //    catch (Exception exp)
        //    {
        //        expMessage = exp.Message;
        //    }
        //    if (dt.Rows.Count < 1)
        //        return null;
        //    else
        //        return dt;
        //}

        public int usedPin(string pin, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "UsedPin";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_pin", pin);
                        //if (!string.IsNullOrEmpty(pwd)) cmd.Parameters.AddWithValue("@in_pwd", pwd);
                        //if (proc.Equals("UsedPin")) cmd.Parameters.AddWithValue("@in_pin", pin);
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
        public DataTable getAcct2(string saveaseid, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getAcct2";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_saveaseID", saveaseid);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }


        public DataTable getName(string saveaseid, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getName_By_SaveaseID";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_saveaseID", saveaseid);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }

        public string getUserNam(string saveaseid, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getUserName";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_saveaseID", saveaseid);
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
            if (dt.Rows.Count < 1)
                return "";
            else
                return dt.Rows[0]["username"].ToString();
        }
        public DataTable getAllBankNames(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getAllBanks";
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public int existBeneficiary(string in_acctNo, string in_acctOwner,string in_bankName, string in_sender, string connLocation, out string expMessage)
        {
            Int32 intRecord = 0;
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring.connstring(connLocation);
                con.Open();
                string query = "select SELECT count_big(*) AS counts FROM beneficiaryBank where acctNo ='" + in_acctNo + "'and acctOwner='" + in_acctOwner + "' and bankName='"+ in_bankName + "' and sender='"+in_sender+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    intRecord = dt.Rows.Count;
                    //  MessageBox.Show("Login sucess Welcome to Homepage http://krishnasinghprogramming.nlogspot.com");
                    //  System.Diagnostics.Process.Start("http://krishnasinghprogramming.blogspot.com");
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

        public DataTable getBenBySenders(string in_uname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getbeneficiary2";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public DataTable getBenBySenders1(string in_uname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getbeneficiary4";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        public DataTable getSavedBenDeatials(string in_saveaseID,string in_sender, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            string proc = "getBenByAcctNo1";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_acctNo", in_saveaseID);
                        cmd.Parameters.AddWithValue("@in_sender", in_sender);
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
            if (dt.Rows.Count < 1)
                return null;
            else
                return dt;
        }
        //
        // Commision
        //

        public string getCommision(string in_chargeFor, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string charge = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getCommision";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_chargeFor", in_chargeFor);
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
            if(dt==null)
            { charge = ""; }
            else
             {
                foreach (DataRow dr in dt.Rows)
                {
                    charge = dr["charge"].ToString();
                }
             }
            return charge;
        }

        public Int32 saveCommision(string in_chargeType, double in_charge, string in_chargeFor, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertCommision", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_chargeType", in_chargeType);
                cmd.Parameters.AddWithValue("in_charge", in_charge);
                cmd.Parameters.AddWithValue("in_chargeFor", in_chargeFor);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public Int32 updateCommision(double in_charge, string in_chargefor, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Updpercentage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);*/
                cmd.Parameters.AddWithValue("in_charge", in_charge);
                cmd.Parameters.AddWithValue("in_chargefor", in_chargefor);
                // cmd.Parameters.AddWithValue("in_bal", in_bal);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
                k = 1;
            }
            return k;
        }

        //
        //  Make Deposit
        //

        public Int32 saveTransactiondetails(string in_tranRef, string in_transacType, string in_acctNo, string in_acctName, string in_depNum, 
       string in_depositor, double in_amount, double in_debit, double in_credit, string in_uname, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertTransactiondetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("@in_acctNo", in_acctNo);
                cmd.Parameters.AddWithValue("@in_acctName", in_acctName);
                cmd.Parameters.AddWithValue("@in_amount", in_amount);
                cmd.Parameters.AddWithValue("@in_depositor", in_depositor);
                cmd.Parameters.AddWithValue("@in_depNum", in_depNum);
                cmd.Parameters.AddWithValue("@in_tranRef", in_tranRef);
                cmd.Parameters.AddWithValue("@in_transacType", in_transacType);
                cmd.Parameters.AddWithValue("@in_credit", in_credit);
                cmd.Parameters.AddWithValue("@in_debit", in_debit);
                cmd.Parameters.AddWithValue("@in_uname", in_uname);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }



        public Int32 saveDeposit(string in_acctNo, string in_cardpin, string in_cardsn, string in_bankName, string in_acctName, double in_amount,
            string in_depositor, string in_computerName, string in_ipaddress,string in_tranRef, out string expObj,string in_naration)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertDeposit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_acctNo", in_acctNo);
                cmd.Parameters.AddWithValue("in_cardpin", in_cardpin);
                cmd.Parameters.AddWithValue("in_cardsn", in_cardsn);
                cmd.Parameters.AddWithValue("in_bankName", in_bankName);
                cmd.Parameters.AddWithValue("in_acctName", in_acctName);
                cmd.Parameters.AddWithValue("in_amount", in_amount);
                cmd.Parameters.AddWithValue("in_depositor", in_depositor);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_ipaddress", in_ipaddress);
                cmd.Parameters.AddWithValue("in_tranRef", in_tranRef);
                cmd.Parameters.AddWithValue("in_naration", in_naration);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }
        public Int32 saveSelfDeposit(string in_acctNo, string in_cardpin, string in_cardsn, string in_bankName, string in_acctName, double in_amount,
          string in_depositor, string in_computerName, string in_ipaddress, string in_tranRef, out string expObj,sting in_naration)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertDeposit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_acctNo", in_acctNo);
                cmd.Parameters.AddWithValue("in_cardpin", in_cardpin);
                cmd.Parameters.AddWithValue("in_cardsn", in_cardsn);
                cmd.Parameters.AddWithValue("in_bankName", in_bankName);
                cmd.Parameters.AddWithValue("in_acctName", in_acctName);
                cmd.Parameters.AddWithValue("in_amount", in_amount);
                cmd.Parameters.AddWithValue("in_depositor", in_depositor);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_ipaddress", in_ipaddress);
                cmd.Parameters.AddWithValue("in_tranRef", in_tranRef);
                cmd.Parameters.AddWithValue("in_naration", in_naration);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public Int32 transferFund(string in_transferCode, double in_balB4Transfer, double amountTransfered, double balance, string beneficiaryAccount, string beneficaryName,
            string accountNo, string transferedBy, string in_computerName, out string expObj,sting in_naration)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("transferFund", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_transferCode", in_transferCode);
                cmd.Parameters.AddWithValue("in_balB4Transfer", in_balB4Transfer);
                cmd.Parameters.AddWithValue("amountTransfered", amountTransfered);
                cmd.Parameters.AddWithValue("balance", balance);
                cmd.Parameters.AddWithValue("beneficiaryAccount", beneficiaryAccount);
                cmd.Parameters.AddWithValue("beneficaryName", beneficaryName);
                cmd.Parameters.AddWithValue("accountNo", accountNo);
                cmd.Parameters.AddWithValue("transferedBy", transferedBy);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_naration", in_naration);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }
        public Int32 inserttransactionLog(string in_referenceCode, string in_TransactionType, string in_TransactionDescription, string in_recipientID, string in_recipientName, string in_senderID,
                   string in_senderName,float in_amt, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("inserttransactionLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_referenceCode", in_referenceCode);
                cmd.Parameters.AddWithValue("in_TransactionType", in_TransactionType);
                cmd.Parameters.AddWithValue("in_TransactionDescription", in_TransactionDescription);
                cmd.Parameters.AddWithValue("in_recipientID", in_recipientID);
                cmd.Parameters.AddWithValue("in_recipientName", in_recipientName);
                cmd.Parameters.AddWithValue("in_senderID", in_senderID);
                cmd.Parameters.AddWithValue("in_senderName", in_senderName);
                cmd.Parameters.AddWithValue("in_amount", in_amt);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public Int32 composeMail(string in_sender,string in_subject, string in_content, string in_senderName, string in_reciverId, string in_reciverName,string in_orderNumber, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertMailbox", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);
                cmd.Parameters.AddWithValue("in_card_pin", genPin());
                */
                cmd.Parameters.AddWithValue("@in_senderid", in_sender);
                cmd.Parameters.AddWithValue("@in_subject ", in_subject);
                cmd.Parameters.AddWithValue("@in_content", in_content);
                cmd.Parameters.AddWithValue("@in_senderName", in_senderName);
                cmd.Parameters.AddWithValue("@in_reciverId", in_reciverId);
                cmd.Parameters.AddWithValue("@in_reciverName", in_reciverName);
                cmd.Parameters.AddWithValue("@in_orderNumber", in_orderNumber);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public Int32 saveBenDetails(string in_acctNo, string in_acctName, string in_bankName, string in_depositor, string in_cardpin, 
            string in_phoneNumber, string in_emailID, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertBankBeneficiary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_acctNo", in_acctNo);
                cmd.Parameters.AddWithValue("in_acctName", in_acctName);
                cmd.Parameters.AddWithValue("in_bankName", in_bankName);
                cmd.Parameters.AddWithValue("in_depositor", in_depositor);
                cmd.Parameters.AddWithValue("in_cardpin", in_cardpin);
                cmd.Parameters.AddWithValue("in_phoneNumber", in_phoneNumber);
                cmd.Parameters.AddWithValue("in_emailID", in_emailID);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        //
        // Valid Objects existence
        //
        public int existObjectsy(string tblName, string searchObj, string searchObjVal, string lastSerch, string connLocation, out string expMessage)
        {
            Int32 intRecord = 0;
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring.connstring(connLocation);
                con.Open();
                string query = " SELECT count_big(*) AS counts FROM "+tblName+" where "+ searchObj + " ='" + searchObjVal + "' "+lastSerch;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    intRecord = dt.Rows.Count;
                    //  MessageBox.Show("Login sucess Welcome to Homepage http://krishnasinghprogramming.nlogspot.com");
                    //  System.Diagnostics.Process.Start("http://krishnasinghprogramming.blogspot.com");
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


        public string getCardSerial(string in_cardpin, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getCardSerial";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_cardpin", in_cardpin);
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
            foreach(DataRow dr in dt.Rows)
            {
                sn = dr["cardpin_sn"].ToString();
            }

                return sn;
        }

        public DataTable getCardSerial2(string in_cardpin, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getCardSerial";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_cardpin", in_cardpin);
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
           /* foreach(DataRow dr in dt.Rows)
            {
                sn = dr["cardpin_sn"].ToString();
            }*/

                return dt;
        }
        public Int32 saveBank(string in_bankName, string connLocation, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertBank", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("in_bankName", in_bankName);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "Record Inserted Succesfully into the Database";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = "Failed to insert record: " + exp.Message;
            }
            return k;
        }

        public int existBank(string in_bankName, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "existBank";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_bankName", in_bankName);

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


        public int changepass(string in_uname, string in_newpwd, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "changepass";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_username", in_uname);
                        cmd.Parameters.AddWithValue("@in_newpwd", in_newpwd);
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


        public int existEmail(string in_email, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);

            string proc = "existEmail";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_email", in_email);

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

        public int gettMailunread(string in_SaveaseID, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);

            string proc = "gettMailunread";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_SaveaseID", in_SaveaseID);

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


        public int feedback(string in_username, string in_refnum, string in_descrip, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);

            string proc = "getfeedback";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_Username", in_username);
                        cmd.Parameters.AddWithValue("@in_refnum", in_refnum);
                        cmd.Parameters.AddWithValue("@in_descrip ", in_descrip);

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

        public int complains(string in_name, string in_username, string in_comtype, string in_complain, string in_image, string in_refnum, string in_status, string in_date, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);

            string proc = "getcomplains";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_name", in_name);
                        cmd.Parameters.AddWithValue("@in_username", in_username);
                        cmd.Parameters.AddWithValue("@in_comtype", in_comtype);
                        cmd.Parameters.AddWithValue("@in_complain", in_complain);
                        cmd.Parameters.AddWithValue("@in_image", in_image);
                        cmd.Parameters.AddWithValue("@in_refnum", in_refnum);
                        cmd.Parameters.AddWithValue("@in_status ", in_status);
                        cmd.Parameters.AddWithValue("@in_date", in_date);
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
        private DataTable GetData(string filterString, string connLocation)
        {
            SqlConnection connection = new SqlConnection(constring.connstring(connLocation));
            SqlCommand command = new SqlCommand("SELECT [ProductId], [ProductName] FROM [Products] WHERE [ProductName] LIKE '%' + @filterString + '%' ORDER BY [ProductId]");
            command.Parameters.AddWithValue("@filterString", filterString.Replace("%", "[%]").Replace("_", "[_]"));
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

       
        //Get pin table
        public DataTable getPinBybatch(string in_uname, string in_pin,string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            string proc = "getPinwithAmount";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
                        cmd.Parameters.AddWithValue("@in_pin", in_pin);
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
       public DataTable getPinBybatch1(string in_uname, string in_pin,string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            string proc = "getPinwithAmount1";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
                        cmd.Parameters.AddWithValue("@in_pin", in_pin);
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
        public string getPinAmount(string in_uname, string in_ostatus, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string strAmount = "";
            string constr = constring.connstring(connLocation);
            string proc = "getOrderAmount";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
                        cmd.Parameters.AddWithValue("@in_ostatus", in_ostatus);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";

                strAmount = dt.Rows[0]["Total"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return strAmount;
        }

        public DataTable SortPinby(string in_uname,string in_pin, string in_searchby,string dateFrom , string dateTo, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string strAmount = "";
            string constr = constring.connstring(connLocation);
            string proc = "getPinwithAmount3";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
                        cmd.Parameters.AddWithValue("@in_pin", in_pin);
                        cmd.Parameters.AddWithValue("@in_searchby", in_searchby);
                        cmd.Parameters.AddWithValue("@in_datefrom", dateFrom);
                        cmd.Parameters.AddWithValue("@in_dateTo", dateTo);
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


        public string getcardImageName(string connLocation, out string expMessage)
        {
            string strImageName = "";
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getCardImage";
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

                strImageName = dt.Rows[0]["imageName"].ToString();
                expMessage = "";
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return strImageName;
        }
        //GET BANK DEPOSIT
        public DataTable getTranssactionDetails(string in_bankname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getTransactionDetails1";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_bankname);
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

        public DataTable getTransfers(string in_uname,string in_transferRef, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getTransactionDetails2";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_uname);
                        cmd.Parameters.AddWithValue("@in_RefNumber", in_transferRef);
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

        public DataTable getBankDeposit(string in_bankname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getBankDeposit";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_bankname", in_bankname);
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
        public DataTable getBankDeposit4user(string in_bankname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getBankDeposit4user";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_bankname", in_bankname);
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
        public DataTable getBankDepositSelf(string in_depositor, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getBankDepositSelf";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_depositor", in_depositor);
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
        public DataTable getOrder(string in_depositor, string in_orderstatus, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getAllOrderByUser";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_depositor);
                        cmd.Parameters.AddWithValue("@in_orderstatus", in_orderstatus);
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

        public DataTable getOrderdetails(string in_depositor, string in_orderstatus, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getAllOrderByUser1";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_depositor);
                        cmd.Parameters.AddWithValue("@in_orderstatus", in_orderstatus);
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
        public DataTable getTransfer(string in_depositor, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getTransferByUser";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_uname", in_depositor);
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

        public string getDName(string in_username, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string strsaveaseID = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getDiplayName";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_username", in_username);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                strsaveaseID = dt.Rows[0]["dName"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return strsaveaseID;
        }

        public string getSaveaseID_By_Name(string in_username, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string strsaveaseID = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getSaveaseID_By_Name";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_username", in_username);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                strsaveaseID = dt.Rows[0]["saveaseID"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return strsaveaseID;
        }

        public string getUserLevel(string in_username, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string strUserlevel = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getUserLevel";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_username", in_username);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                strUserlevel = dt.Rows[0]["userlevel"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
            }
            return strUserlevel;
        }
        /*
        public Int32 updateStatus(string token, string connLocation)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            string expMessage = "";

            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updateStatus", con);
                cmd.Parameters.AddWithValue("@in_token", token);
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
            return k;
        }*/

        public Int32 updateInboxStatus(string in_notID, char in_statusType, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updMailbox2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);*/
                cmd.Parameters.AddWithValue("in_notID", in_notID);
                cmd.Parameters.AddWithValue("in_statusType", in_statusType);
               // cmd.Parameters.AddWithValue("in_bal", in_bal);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
                k = 1;
            }
            return k;
            }
        public Int32 updateBalance(string inuser, double in_bal, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updateBalance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_user", inuser);
                cmd.Parameters.AddWithValue("in_bal", in_bal);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
                k = 1;
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }
        public Int32 updateStatus(string in_token, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updateStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_token", in_token);
               // cmd.Parameters.AddWithValue("in_bal", in_bal);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
            }
        public Int32 updateCardpin(string in_cardpin, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updateCardpinstatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("in_cardpin", in_cardpin);
                // cmd.Parameters.AddWithValue("in_bal", in_bal);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        // mailbox

        //inbox

        public DataTable getMailInbox(string in_saveaseID, char statustype, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getMailBoxInbox";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_saveaseID", in_saveaseID);
                        //cmd.Parameters.AddWithValue("@in_saveaseID", "60139694953");
                        cmd.Parameters.AddWithValue("@in_statusType", statustype);
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

        public DataTable getMailSent(string in_saveaseID, char statustype, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getMailBoxsent";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_saveaseID", in_saveaseID);
                        //cmd.Parameters.AddWithValue("@in_saveaseID", "60139694953");
                        cmd.Parameters.AddWithValue("@in_statusType", statustype);
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

        public DataTable getReadMailInbox1(string in_saveaseID, char statustype, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getReadMailBox";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_saveaseID", in_saveaseID);
                        //cmd.Parameters.AddWithValue("@in_saveaseID", "60139694953");
                        cmd.Parameters.AddWithValue("@in_statusType", statustype);
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
        public void getMailCounters(string in_saveaseID, out string ctrInbox, out string ctrUnread, out string ctrRead, out string ctrSent, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);

            string proc = "CtrMailboxByUser";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_saveaseID", in_saveaseID);
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                ctrInbox = dt.Rows[0]["countInbox"].ToString();
                ctrUnread = dt.Rows[0]["countUnRead"].ToString();
                ctrRead = dt.Rows[0]["countRead"].ToString();
                ctrSent = dt.Rows[0]["countSent"].ToString();
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                ctrInbox = "0";
                ctrUnread = "0";
                ctrRead = "0";
                ctrSent = "0";
            }
        }

        public DataTable getMailByID4user(string notID,string in_saveaseID, char statustype, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getMailByID4user";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_notID", notID);
                        cmd.Parameters.AddWithValue("@in_saveaseID", in_saveaseID);
                        //cmd.Parameters.AddWithValue("@in_saveaseID", "60139694953");
                        cmd.Parameters.AddWithValue("@in_statusType", statustype);
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

        // ==================================== LOGS ========================================================================

        public Int32 LoginLog(string in_saveaseID, string in_loggedin, string in_loggedout, string in_status,  string in_computerName, string in_ipaddress,string in_createupdate, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertLoggedIn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("in_saveaseID", in_saveaseID);
                cmd.Parameters.AddWithValue("in_loggedin", in_loggedin);
                cmd.Parameters.AddWithValue("in_loggedout", in_loggedout);
                cmd.Parameters.AddWithValue("in_status", in_status);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_ipaddress", in_ipaddress);
                cmd.Parameters.AddWithValue("in_createupdate", in_createupdate);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }

        public Int32 SystemLog(string in_saveaseID, string in_actionPerformed,  string in_computerName, string in_ipaddress, string in_actionPage, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("insertLoggedIn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("in_saveaseID", in_saveaseID);
                cmd.Parameters.AddWithValue("in_actionPerformed", in_actionPerformed);
                cmd.Parameters.AddWithValue("in_computerName", in_computerName);
                cmd.Parameters.AddWithValue("in_ipaddress", in_ipaddress);
                cmd.Parameters.AddWithValue("in_actionPage", in_actionPage);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        }
        //==============================================================Admin Section=============================================================
        public int existAdmin(string uname, string pwd, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "Adminexistuserpwd";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_uname", uname);
                        cmd.Parameters.AddWithValue("@in_pwd", pwd);
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
        public DataTable getAdminUname(string dname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "getAdUserName1";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_saveaseID", dname);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }

        public DataTable getBlockpinrequest(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "AdmingetBlockpinreq";
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
        public Int32 AdminBlockpin(string in_pinType, string in_value, out string expObj)
        {
            Int32 k = 0;
            try
            {
                string constr = constring.connstring("");
                // string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("AdminblockPin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
                cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);*/
                cmd.Parameters.AddWithValue("@in_pinType", in_pinType);
                cmd.Parameters.AddWithValue("@in_value", in_value);
                con.Open();
                k = cmd.ExecuteNonQuery();
                expObj = "";
                k = 1;
                con.Close();
            }
            catch (Exception exp)
            {
                k = 0;
                expObj = exp.Message;
            }
            return k;
        } 
        public DataTable getVendorCount(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "countVendors";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }
        public DataTable getUserCount(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "countUsers";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }
        public DataTable getCardCount(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "countCardSgen";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }
        public DataTable getTotalAmount(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "TotalAmount";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }
        public DataTable getOnlineUsers(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "getlogedinUsers";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }
        public string RegisterAdmin(Int32 accesscontrol, string fname, string lname, string phone, string email, string username, string password, string createdBy, string connLocation, string status)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            string expMessage = "";
            string saveaseid = genSaveaseID();
            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("RegisterAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_fname", fname);
                cmd.Parameters.AddWithValue("@in_lname", lname);
                cmd.Parameters.AddWithValue("@in_dname", lname + " " + fname);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                cmd.Parameters.AddWithValue("@in_username", username);
                cmd.Parameters.AddWithValue("@in_password", password);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_createdBy", createdBy);
                cmd.Parameters.AddWithValue("@in_userlvl", accesscontrol);
                cmd.Parameters.AddWithValue("@in_status", status);
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
        public DataTable getUserByIDAdm(string in_ID, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string sn = "";
            string constr = constring.connstring(connLocation);
            //string proc = "getbeneficiary2";
            string proc = "getUserByUID_adm";
            Int32 intRecord = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_ID", in_ID);
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

        public string UpdateUsers(string id, string fname, string lname, string dname, string phone, string email, string address, string connLocation)
        {
            //  DataTable dt = new DataTable();
            Int32 k = 0;
            string expMessage = "";

            try
            {
                string constr = constring.connstring(connLocation);
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("updateUsersbyAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@in_id", id);
                cmd.Parameters.AddWithValue("@in_fname", fname);
                cmd.Parameters.AddWithValue("@in_lname", lname);
                cmd.Parameters.AddWithValue("@in_dname", dname);
                cmd.Parameters.AddWithValue("@in_phone", phone);
                cmd.Parameters.AddWithValue("@in_email", email);
                cmd.Parameters.AddWithValue("@in_address", address);
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

        public DataTable getusersOnline(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "getonlineinusers";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }

        public DataTable getOnlineVendors(string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "getonlineVendors";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@in_accessControl", accesscontrol);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }
        public DataTable rptTransferAdm(string str_dtFrom, string str_dtTo, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "rptTransferAdm";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_startDate", str_dtFrom);
                        cmd.Parameters.AddWithValue("@in_endDate", str_dtTo);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }

        public DataTable rptDepositAdm(string str_dtFrom, string str_dtTo, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "rptDepositAdm";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_startDate", str_dtFrom);
                        cmd.Parameters.AddWithValue("@in_endDate", str_dtTo);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }

        public DataTable rptvoucherAdm(string str_dtFrom, string str_dtTo, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseSqlConnStr"].ConnectionString;
            string proc = "rptVoucherAdm";
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(proc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@in_startDate", str_dtFrom);
                        cmd.Parameters.AddWithValue("@in_endDate", str_dtTo);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                expMessage = "";
                // intRecord = Int32.Parse(dt.Rows[0]["accessControl"].ToString());
                // return dt;
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                dt = null;
            }
            return dt;
        }

    }
}
