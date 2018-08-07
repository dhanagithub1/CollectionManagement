using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.Common
{
    public class EmailMessageHelper
    {

        private string emailSender = ConfigurationManager.AppSettings["username"].ToString();
        private string emailSenderPassword = ConfigurationManager.AppSettings["password"].ToString();
        private string emailSenderHost = ConfigurationManager.AppSettings["smtpserver"].ToString();
        private int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["portnumber"]);
        private Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);

        public void SendEmail(EmailMessageModel emailMessageModel)
        {
            //Fetching Email Body Text from EmailTemplate File.  
            string filePath = "D:\\Client_PGB\\TestProject\\CollectionManagement\\CollectionManagement.WebProject\\Template\\EmailTemplate.html";
            StreamReader str = new StreamReader(filePath);
            string MailText = str.ReadToEnd();
            str.Close();

            //Repalce [newusername] = signup user name   
            MailText = MailText.Replace("{UserName}", emailMessageModel.ApplicantName).Replace("{txnId}", emailMessageModel.TransactionId);

            string subject = "Welcome to Collection Management System";

            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress(emailSender);

            //Set To Email ID  
            _mailmsg.To.Add(emailMessageModel.ReceiverEmailAddress);

            //Set Subject  
            _mailmsg.Subject = subject;

            //Set Body Text of Email   
            _mailmsg.Body = MailText;


            //Now set your SMTP   
            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            //Send Method will send your MailMessage create above.  
            _smtp.Send(_mailmsg);
        }
    }
}
