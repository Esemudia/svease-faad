using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace saveasze
{
    public class Procedure
    {

        connString constring = new connString();
        public int existUser(string uname, string pwd, string connLocation, out string expMessage)
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
        public DataTable getUser(string uname, string connLocation, out string expMessage)
        {
            DataTable dt = new DataTable();
            string constr = constring.connstring(connLocation);
            // string constr = ConfigurationManager.ConnectionStrings["saveaseMySqlConnStr"].ConnectionString;
            string proc = "gettuser";
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
        //Menu Top Group
        public int accessControl(string uname, out string displayName, string connLocation, out string expMessage)
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
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                displayName = null;
            }
            return intRecord;
        }
        //Menu Top Group

        public int AccessControl(string uname, out string displayName, string connLocation, out string expMessage)
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
            }
            catch (Exception exp)
            {
                expMessage = exp.Message;
                displayName = null;
            }
            return intRecord;
        }

        public DataTable getMenuGroup(string connLocation, out string expMessage)
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

        public DataTable getMenuDetails(string inParentID, string connLocation, out string expMessage)
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
        public Int32 saveOrder(string in_card_pin,string in_cardpin_sn, string in_orderNumber, string in_cardType,double in_cardAmount,double in_chargeOnCard, string in_orderby, string in_computerName, string in_ipaddress, out string expObj)
        {
            Int32 k = 0;
            try
            {
            string constr = constring.connstring(connLocation);
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("insertOrderDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("in_card_pin", in_card_pin);
            cmd.Parameters.AddWithValue("in_cardpin_sn", in_cardpin_sn);
            cmd.Parameters.AddWithValue("in_orderNumber", in_orderNumber);
            cmd.Parameters.AddWithValue("in_cardType", in_cardType);
            cmd.Parameters.AddWithValue("in_cardAmount", in_cardAmount);
            cmd.Parameters.AddWithValue("in_chargeOnCard", in_chargeOnCard);
            cmd.Parameters.AddWithValue("in_orderby", in_orderby);
            cmd.Parameters.AddWithValue("in_computerName", in_computerName);
            cmd.Parameters.AddWithValue("in_ipaddress", in_ipaddress);
            con.Open();
             k = cmd.ExecuteNonQuery();
                expObj = "Record Inserted Succesfully into the Database";
            }
            catch(Exception exp)
            {
                k = 0;
                expObj ="Failed to insert record: "+ exp.Message;
            }
            con.Close();
        }

    }
}