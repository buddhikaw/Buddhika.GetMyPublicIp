using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Buddhika.GetMyPublicIp.Utility
{
    public class SendEmailWithGmail
    {
        string toAddress;
        string subject;
        string body;
        string username;
        string password;

        public SendEmailWithGmail(string toAddress, string subject, string body, string username, string password)
        {
            this.toAddress = toAddress;
            this.subject = subject;
            this.body = body;
            this.username = username;
            this.password = password;
        }

        public void SendEmail()
        {
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(username, password),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(username, toAddress, subject, body);
                message.IsBodyHtml = true;
                smtp.Send(message);

            }
            catch (Exception)
            {

            }
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        SendEmailWithGmail email = new SendEmailWithGmail("bnwimalasena@gmail.com", "test mail", "test body");
    //        email.SendEmail();
    //    }
    //}
}
