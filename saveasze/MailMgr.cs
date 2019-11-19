using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace saveasze
{
    public class MailMgr
    {
        public string sendMail2Usr1(string msgTo,string msgBody,string msgSubj)
        {
           // msgTo = "jonathan.ataisi@gmail.com";
            string retMsg = "";
           string msgFrom = "noreply@savease.ng";
             //string msgFrom = "saveasealert@savease.ng";
            string pMsg = "S@ve@se2018";
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            m.From = new MailAddress(msgFrom);
            m.To.Add(msgTo);
            m.Subject = msgSubj;
            m.Body = msgBody;
            sc.Host = "mail.savease.ng";
            string str1 = "gmail.com";
            string str2 = "noreply@savease.ng";
           // string str2 = "saveasealert@savease.ng";
            try
            {
                sc.Port = 25;
                sc.Credentials = new System.Net.NetworkCredential(msgFrom, pMsg);
                sc.EnableSsl = false;
                sc.Send(m);
                retMsg="Email Send successfully";
            }
            catch (Exception ex)
            {
                retMsg="Please reconfirm email address";
                throw ex;
            }
            return "";
        }
        public string  sendMail2Usr(string msgTo,string msgBody,string msgSubj)
        {
            string retMsg = "";
            try
            {
                MailMessage mail = new MailMessage();
               // SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpClient SmtpServer = new SmtpClient("mail.savease.ng");

                mail.From = new MailAddress("Savease<noreply@savease.ng>");
                mail.To.Add(msgTo);
               // mail.Sender.DisplayName();//="ddd";
                mail.Subject = msgSubj;

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = msgBody;

                mail.Body = htmlBody;

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("noreply@savease.ng", "S@ve@se2018");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                retMsg = "Email Send successfully";
                // MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                retMsg = "Please reconfirm email address: "+ex.Message;
            }
            return retMsg;
        }
        public void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("noreply@savease.ng");
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(recepientEmail));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "mail.savease.ng";
                    smtp.EnableSsl = Convert.ToBoolean(false);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = "noreply@savease.ng";
                    NetworkCred.Password = "S@ve@se2018";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 25;
                    smtp.Send(mailMessage);
                }

            }
            catch(Exception exp)
            {
                string expp = exp.Message;
            }
        }
    }

}