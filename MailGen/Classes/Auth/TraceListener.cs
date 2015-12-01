namespace MailGen.Classes.Auth
{
    using System;
    using System.IO;

    using MailGen.Classes.Logging.Loggers;
    using Properties;

    using Microsoft.Exchange.WebServices.Data;

    // This sample is for demonstration purposes only. Before you run this sample, make sure that the code meets the coding requirements of your organization.
    internal sealed class TraceListener : ITraceListener
    {
        public void Trace(string traceType, string traceMessage)
        {
            CreateXmlTextFile(traceType, traceMessage);
        }

        private static void CreateXmlTextFile(string fileName, string traceContent)
        {
            try
            {
                if (!Directory.Exists(@"..\\TraceOutput"))
                {
                    Directory.CreateDirectory(@"..\\TraceOutput");
                }

                File.WriteAllText(@"..\\TraceOutput\\" + fileName + DateTime.Now.Ticks + ".txt", traceContent);
            }
            catch (IOException exc)
            {
                Logger.Error(LocalizibleStrings.CannotCreateTrace, exc);
            }
        }
    }
}
