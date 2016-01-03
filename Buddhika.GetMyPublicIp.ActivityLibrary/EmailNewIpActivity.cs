using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Buddhika.GetMyPublicIp.Utility;
using System.Configuration;


namespace Buddhika.GetMyPublicIp.ActivityLibrary
{

    public sealed class EmailNewIpActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> NewIp { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string newIp = context.GetValue(this.NewIp);
            string toAddress = ConfigurationManager.AppSettings["ToAddress"];
            string subject = ConfigurationManager.AppSettings["Subject"];
            subject = string.Format(subject, DateTime.Now.ToString());
            string body = ConfigurationManager.AppSettings["SuccessBodyHtml"];
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            body = string.Format(body, newIp);
            SendEmailWithGmail email = new SendEmailWithGmail(toAddress, subject, body, username, password);
            email.SendEmail();
        }
    }
}
