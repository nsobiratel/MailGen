using Microsoft.Exchange.WebServices.Data;

namespace MailGen.Classes.Auth
{
    internal sealed class ConnectionParams
    {
        public ExchangeVersion Version { get; private set; }
        public string AutodiscoverUrl { get; private set; }
        public bool TraceToFile { get; private set; }
        
        public IUserData Data { get; private set; }

        public ConnectionParams(
            ExchangeVersion version,
            string autodiscoverUri,
            IUserData data,
            bool traceToFile)
        {
            this.Version = version;
            this.AutodiscoverUrl = autodiscoverUri;
            this.Data = data;
            this.TraceToFile = traceToFile;
        }
    }
}
