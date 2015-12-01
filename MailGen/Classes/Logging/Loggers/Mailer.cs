namespace MailGen.Classes.Logging.Loggers
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Net.Mail;
    using System.Reflection;

    internal static class Mailer
    {
        private static readonly string Subject = @"MailGen [" + Dns.GetHostName() + @"] : ";
        private static string _mailFrom;
        private static string _mailTo;

        private static string _smtpServer;

        private static int _port;

        public static bool SendingEnabled;

        public static void SetParams(
            string mFrom, string mTo, string sServer, int sPort)
        {
            Mailer._mailFrom = mFrom;
            Mailer._mailTo = mTo;
            Mailer._smtpServer = sServer;
            Mailer._port = sPort;
        }


        public static void Send(object exc, string message = null)
        {
            if (!SendingEnabled)
                return;

            SmtpClient client = null;
            try
            {
                client = new SmtpClient(_smtpServer, _port)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Timeout = 15000,
                    Credentials = null
                };
                client.SendCompleted += Mailer.ClientOnSendCompleted;

                string body = string.Format(
                                  @"Message :\n{3}\n\nAssembly :\n{0}\n\nException :\n{1}\n\nStackTrace :\n{2}",
                                  Assembly.GetEntryAssembly(),
                                  exc ?? @"empty",
                                  Environment.StackTrace,
                                  message);

                client.Send(_mailFrom, _mailTo, exc == null ? Subject : Subject + exc.GetType(), body);
            }
            catch (Exception e)
            {
                Logger.Error(@"Mailer.Send", e, false, false);
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
        }

        private static void ClientOnSendCompleted(
            object sender, AsyncCompletedEventArgs arg)
        {
            if (arg.Error != null)
                Logger.Error(@"Mailer.ClientOnSendCompleted", arg.Error, false, false);
        }
    }
}
