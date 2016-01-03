using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Buddhika.GetMyPublicIp.Utility;
using System.Configuration;

namespace Buddhika.GetMyPublicIp.ActivityLibrary
{

    public sealed class SendIpRetrievalFailNotificationActivity : CodeActivity
    {
        // Define an activity input argument of type string
        
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            string toAddress = ConfigurationManager.AppSettings["ToAddress"];
            string subject = ConfigurationManager.AppSettings["FailSubject"];
            subject = string.Format(subject, DateTime.Now.ToString());
            string body = ConfigurationManager.AppSettings["FailBodyHtml"];
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            SendEmailWithGmail email = new SendEmailWithGmail(toAddress, subject, body, username, password);
            email.SendEmail();

        }
    }
}
