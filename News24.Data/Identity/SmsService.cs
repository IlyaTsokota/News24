using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace News24.Data.Identity
{
    public class SmsService : ISmsService
    {
        private readonly string _accountSid = "AC4226aafe1e3596d437e4064ca888f755";
        private readonly string _authToken = "c6e0073f405d8d6ecb1a064ab222cda7";
        private readonly string _fromNumber = "+16822221904";
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
            ///

            TwilioClient.Init(_accountSid, _authToken);
            var result = MessageResource.CreateAsync(
                body: message.Body,
                from: new PhoneNumber(_fromNumber),
                to: new PhoneNumber(message.Destination)
            );
            return Task.FromResult(result);
        }
    }
}
