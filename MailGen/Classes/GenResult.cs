using Microsoft.Exchange.WebServices.Data;

namespace MailGen.Classes
{
    internal struct GenResult
    {
        public EmailMessage msg;
        public ResponseMessage response;
        public ResponseMessage reply;
    }
}
