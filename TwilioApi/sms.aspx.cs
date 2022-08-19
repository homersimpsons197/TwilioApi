using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioApi
{
    public partial class sms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string From = Request["From"];
            string To = Request["To"];
            string Body = Request["Body"];

            string smsFolder = (@"C:\Sms");

            if (!Directory.Exists(smsFolder))
            {
                Directory.CreateDirectory(smsFolder);
            }

            string smsCounter = String.Format(@"C:\Sms\{0}.txt", From);

            if (!File.Exists(smsCounter))
            {
                using (StreamWriter sw = File.CreateText(smsCounter))
                {
                    sw.Write("0");
                }
            }

            Reply(From, Body);
        }

        public void Reply(String From, String Body)
        {
            var accountSid = "xxxb6494f727a36c93894202f2e49d78ad";
            var authToken = "xxx2082c34329451adacbd392c421cdc";
            TwilioClient.Init(accountSid, authToken);

            String regCode = From[2].ToString() + From[3].ToString() + From[4].ToString();

            var to = new PhoneNumber(From);
            var from = new PhoneNumber("+1xxx2033206");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Merci pour le sms");
        }
    }
}
