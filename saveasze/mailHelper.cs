using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace saveasze
{
    public class mailHelper
    {
        MailMgr mailMessenger = new MailMgr();
        public string PopulateBody(string userName, string title, string url, string description, string filepath, string mailtype)
        {
            string body = string.Empty;
           
            body = body + " <div style = 'width: 500px; background: whitesmoke; margin-right: auto; margin-left: auto;' >";
            body = body + " <div  style = 'margin-left: auto;margin-right: auto;width: 350px;background: white;' >";
            body = body + "<div  style='height: 70px; background:whitesmoke;'>";
            body = body + "</div>";
            body = body + "<div style = 'width: 195px;margin-left: auto;margin-right: auto;'>";
            body = body + " <img src = 'http://www.faadsolutions.com.ng/logo/logo.png' style = 'margin-top: 20px' >";
            body = body + "</div><br><br>";
            body = body + "<div>";
            body = body + "<h3 style = 'text-align: center;font-family:calibri;font-size: 18px;' > Complete your Registration</h3><br><br>";
            body = body + "<p style = 'margin-left: 15px; font-family:calibri;font-size: 11px' > Please click button below to verify your and complete your registration</p>";
            body = body + "</div><br><br>";
            body = body + " <div style = ' width: 250px;height: 70px;margin-right: auto;margin-left: auto;' >";
            body = body + " <a href='" + url + "'><input type= 'submit' name= '' value= 'Complete Registration' style= 'background: #fa9928;color: white;margin-left: 30px;margin-right: 30px;margin-top: 20px;border-radius: 4px;height:35px;width: 200px;' ></ a >";
            body = body + " </div ><br ><p style= 'color: #212435; text-align: center;font-family:calibri;font-size: 10px;'> or Copy Link</p>" + url;
            body = body + " <br><br><hr><br><br><br>";
            body = body + "  <div>";
            body = body + "<h4 style = 'color: #fa9928;text-align: center;font-family:calibri; font-size: 12px;' > Questions ? Get your answer here:&nbsp;<a href = 'faq.aspx' style='color: blue; font-size: smaller;font-family:calibri; font-size: 9px;'>Help Center</a></h4>";
            body = body + "</div><br><br><br>";
            body = body + "<div>";
            body = body + "<h5 style = 'color: #212435; text-align: center;font-family:calibri;font-size: 10px;' > You may contact us through any of the option:</h5>";
            body = body + "</div>";
            body = body + "<div>";
            body = body + " <p style = 'color: #212435; text-align: center;font-family:calibri;font-size: 10px;' > Phone: 0700SAVEASE, 07032599897,08056161069</p>";
            body = body + "</div>";
            body = body + " <div style = 'text-align: center;font-size: 10px;' >";
            body = body + "<p style= 'color: #212435; text-align: center;font-family:calibri;' > care@savease.ng, enquiry @savease.ng";
            body = body + "</div>";
            body = body + "  <div style = 'text-align: center;color: #212435;font-family:calibri;font-size: 10px;font-weight: bold;' >";
            body = body + " &copy; 2018 Savease.All Rights Reserved.";
            body = body + "</div>";
            body = body + "<div style = 'text-align: center; font-family: calibri;color:#212435;font-size: 10px;font-weight: bolder; '>";
            body = body + "|<a href='doc/TnC.pdf' target='_blank'>Privacy Policy</a> | <a href = 'doc/TnC.pdf' target= '_blank' > General Terms and Condition</a>";
            body = body + " </div>";
            body = body + " </div>";
            body = body + "</div>";
            return body;
        }
        public string populateBody2(string strBenBank,string strBenName,string strBenAcct,string strTransDate)
        {
            string strBody = "";
            strBody = strBody + "<div class='container'>";
            strBody = strBody + "<div class='header'>";
            strBody = strBody + " <div class='empty' style='height: 70px; background:whitesmoke;'>";

            strBody = strBody + " </div>";
            strBody = strBody + " <div class='logo'>";
            strBody = strBody + " <img src = 'http://www.savease.ng/logo/logo.png' style = 'margin-top: 20px' >";
            strBody = strBody + " </div><br><br>";
            strBody = strBody + " <div class='text'>";
            strBody = strBody + " <h3 style='font-family:calibri;'>Hello &nbsp;<label></label>,</h3><br><br>";
            strBody = strBody + " <p style='/*margin-left: 15px;*/font-size: 12px; font-family:calibri;'>Your deposit transaction was successfull</p>";
            strBody = strBody + " </div><br><br>";
            strBody = strBody + "<h3 style='font-family:calibri;font-size: 12px;font-weight: bolder;'>Transaction Details<label></label></h3><br><br>";
            strBody = strBody + " <div class='button'>";
            strBody = strBody + "<p>Beneficiary Bank:</p>&nbsp;&nbsp;&nbsp;&nbsp;"+strBenBank;
            strBody = strBody + " <p>Beneficiary Name:</p>&nbsp;&nbsp;&nbsp;&nbsp;"+strBenName;
            strBody = strBody + " <p>Beneficiary Account:</p>&nbsp;&nbsp;&nbsp;&nbsp;"+strBenAcct;
            strBody = strBody + "<p>Transaction Date:</p>&nbsp;&nbsp;&nbsp;&nbsp;"+strTransDate;
            strBody = strBody + " <hr>";
            strBody = strBody + "<p>Transaction Narrative:</p>&nbsp;&nbsp;&nbsp;&nbsp;<label></label>";
            strBody = strBody + "<p style='background:#212435;color: white; margin-top: -11px;'>Transaction ";
            strBody = strBody + "Narrative:</p>&nbsp;&nbsp;&nbsp;&nbsp;<label></label>";
            strBody = strBody + "</div><br><br>";
            strBody = strBody + "<div class='quest'>";
            strBody = strBody + " <h4 style='color: #fa9928;font-family:calibri;'><a href='' style='color: blue; ";
            strBody = strBody + "font-size:12px;font-family:calibri;'>Please click here to provide freedback on your experience</a></h4>";
            strBody = strBody + "<h4 style='color: #fa9928;font-family:calibri; font-weight: bolder;'><a href='' style='color: blue; ";
            strBody = strBody + "font-size:12px;font-family:calibri;'>Thank you for using Savease.</a></h4>";
            strBody = strBody + " <h4 style='color: #fa9928;font-family:calibri;font-size:10px;'><a href='' style='color: blue; ";
            strBody = strBody + "font-size:12px;font-family:calibri;'>This is an automated email. Please do not reply.</a></h4>";
            strBody = strBody + "</div><br><br><br>";
            strBody = strBody + "<div class='footer'>";
            strBody = strBody + " <h5 style='color: #212435; font-family:calibri;font-size:12px;'>You may contact us through any of the option:</h5>";
            strBody = strBody + "</div>";
            strBody = strBody + " <div class='phone'>";
            strBody = strBody + " <p style='color: #212435; font-family:calibri;font-size:12px;'>Phone: 0700SAVEASE, 07032599897,08056161069</p>";
            strBody = strBody + " </div>";
            strBody = strBody + " <div class='email'>";
            strBody = strBody + " <p style='color: #212435;font-family:calibri;font-size:12px;'>care@savease.ng, enquiry@savease.ng";
            strBody = strBody + " </div>";
            strBody = strBody + " <div style='color: #212435;font-family:calibri;font-size:12px;'>";
            strBody = strBody + "  &copy; 2018 Savease. All Rights Reserved.";
            strBody = strBody + " </div>";
            strBody = strBody + "  <div style=' font-family: calibri;color:#212435;font-size:12px; '>";
            strBody = strBody + "|<a href=''>Privacy Policy</a> | <a href=''>General Terms and Condition</a>";
            strBody = strBody + " </div>";
            strBody = strBody + " </div>";
            strBody = strBody + "</div>";
            return strBody;
        }
        public string populatBuyPin(string strTransDate, string tablez)
        {
            string strBody = "";
            strBody = strBody + "<div class='container'>";
            strBody = strBody + "<div class='header'>";
            strBody = strBody + " <div class='empty' style='height: 70px; background:whitesmoke;'>";

            strBody = strBody + " </div>";
            strBody = strBody + " <div class='logo'>";
            strBody = strBody + " <img src = 'http://www.savease.ng/logo/logo.png' style = 'margin-top: 20px' >";
            strBody = strBody + " </div><br><br>";
            strBody = strBody + " <div class='text'>";
            strBody = strBody + " <h3 style='font-family:calibri;'>Hello &nbsp;<label></label>,</h3><br><br>";
            strBody = strBody + " <p style='/*margin-left: 15px;*/font-size: 12px; font-family:calibri;'>Your deposit transaction was successfull</p>";
            strBody = strBody + " </div><br><br>";
            strBody = strBody + "<h3 style='font-family:calibri;font-size: 12px;font-weight: bolder;'>Transaction Details<label></label></h3><br><br>";
            strBody = strBody + " <div class='button'>";

            strBody = strBody + " <hr>";
            strBody = strBody + "<p>Transaction Narrative:</p>&nbsp;&nbsp;&nbsp;&nbsp;<label></label>";
            strBody = strBody + "<p style='background:#212435;color: white; margin-top: -11px;'>Transaction ";
            strBody = strBody + "Narrative:</p>&nbsp;&nbsp;&nbsp;&nbsp;<label></label>";
            strBody = strBody + tablez;
            strBody = strBody + "<p>Transaction Date:</p>&nbsp;&nbsp;&nbsp;&nbsp;" + strTransDate;
            strBody = strBody + "</div><br><br>";
            strBody = strBody + "<div class='quest'>";
            strBody = strBody + " <h4 style='color: #fa9928;font-family:calibri;'><a href='' style='color: blue; ";
            strBody = strBody + "font-size:12px;font-family:calibri;'>Please click here to provide freedback on your experience</a></h4>";
            strBody = strBody + "<h4 style='color: #fa9928;font-family:calibri; font-weight: bolder;'><a href='' style='color: blue; ";
            strBody = strBody + "font-size:12px;font-family:calibri;'>Thank you for using Savease.</a></h4>";
            strBody = strBody + " <h4 style='color: #fa9928;font-family:calibri;font-size:10px;'><a href='' style='color: blue; ";
            strBody = strBody + "font-size:12px;font-family:calibri;'>This is an automated email. Please do not reply.</a></h4>";
            strBody = strBody + "</div><br><br><br>";
            strBody = strBody + "<div class='footer'>";
            strBody = strBody + " <h5 style='color: #212435; font-family:calibri;font-size:12px;'>You may contact us through any of the option:</h5>";
            strBody = strBody + "</div>";
            strBody = strBody + " <div class='phone'>";
            strBody = strBody + " <p style='color: #212435; font-family:calibri;font-size:12px;'>Phone: 0700SAVEASE, 07032599897,08056161069</p>";
            strBody = strBody + " </div>";
            strBody = strBody + " <div class='email'>";
            strBody = strBody + " <p style='color: #212435;font-family:calibri;font-size:12px;'>care@savease.ng, enquiry@savease.ng";
            strBody = strBody + " </div>";
            strBody = strBody + " <div style='color: #212435;font-family:calibri;font-size:12px;'>";
            strBody = strBody + "  &copy; 2018 Savease. All Rights Reserved.";
            strBody = strBody + " </div>";
            strBody = strBody + "  <div style=' font-family: calibri;color:#212435;font-size:12px; '>";
            strBody = strBody + "|<a href=''>Privacy Policy</a> | <a href=''>General Terms and Condition</a>";
            strBody = strBody + " </div>";
            strBody = strBody + " </div>";
            strBody = strBody + "</div>";
            return strBody;
        }
        public Int32 sendmail(string regEmail, string msgBody, string msgSubjB)
        {
            try
            {
 mailMessenger.sendMail2Usr(regEmail, msgBody, msgSubjB);
                return 1;
            }
           catch(Exception exp)
            {
                return 0;
            }

        }
    }
}