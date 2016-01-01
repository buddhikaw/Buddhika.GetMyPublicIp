using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Buddhika.GetMyPublicIp.ActivityLibrary
{

    public sealed class GetNewIpActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InOutArgument<string> NewIp { get; set; }
        public OutArgument<bool> IsSuccess { get; set; }
        private readonly string ipRegEx = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            try
            {
                string url = "http://freegeoip.net/json/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string jsonStr = new StreamReader(response.GetResponseStream()).ReadToEnd();
                JObject jObj = JObject.Parse(jsonStr);
                string ipAddress = jObj["ip"].ToString();
                if(Regex.IsMatch(ipAddress, ipRegEx))
                {
                    context.SetValue(NewIp, ipAddress);
                }
                else
                {
                    context.SetValue(IsSuccess, false);
                }
            }
            catch (Exception)
            {
                context.SetValue(IsSuccess, false);                
            }
           
        }
    }
}
