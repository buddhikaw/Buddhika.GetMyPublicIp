using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Buddhika.GetMyPublicIp.Utility;

namespace Buddhika.GetMyPublicIp.ActivityLibrary
{

    public sealed class SendIpRetrievalFailNotificationActivity : CodeActivity
    {
        // Define an activity input argument of type string
        
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            string toAddress = Properties.GetMyPublicIp.Default.ToAddress;
            string subject = Properties.GetMyPublicIp.Default.FailSubject;
            subject = string.Format(subject, DateTime.Now.ToString());
            string body = Properties.GetMyPublicIp.Default.FailBodyHtml;
            string username = Properties.GetMyPublicIp.Default.Username;
            string password = Properties.GetMyPublicIp.Default.Password;
            SendEmailWithGmail email = new SendEmailWithGmail(toAddress, subject, body, username, password);
            email.SendEmail();

        }
    }
}
