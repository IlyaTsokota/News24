using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace News24.Data.Identity
{
    public class SmsService : ISmsService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //var accountSid = ConfigurationManager.AppSettings["SMSAccountIdentification"];
            //var authToken = ConfigurationManager.AppSettings["SMSAccountPassword"];
            //var fromNumber = ConfigurationManager.AppSettings["SMSAccountFrom"];

            //TwilioClient.Init(accountSid, authToken);

            //MessageResource result = MessageResource.Create(
            //    new PhoneNumber(message.Destination),
            //    from: new PhoneNumber(fromNumber),
            //    body: message.Body
            //);

            ////Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
            //Trace.TraceInformation(result.Status.ToString());
            ////Twilio doesn't currently have an async API, so return success.
            return Task.FromResult(0);
        }
    }
}
