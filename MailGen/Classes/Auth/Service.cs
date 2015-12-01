using System.Windows.Forms;

namespace MailGen.Classes.Auth
{
    using System;
    //using System.Net;

    //using MailGen.Classes.Logging.Loggers;

    using Microsoft.Exchange.WebServices.Data;

    // This sample is for demonstration purposes only. Before you run this sample, make sure that the code meets the coding requirements of your organization.
    internal static class Service
    {
        static Service()
        {
            CertificateCallback.Initialize();
        }

        // The following is a basic redirection validation callback method. It 
        // inspects the redirection URL and only allows the Service object to 
        // follow the redirection link if the URL is using HTTPS. 
        //
        // This redirection URL validation callback provides sufficient security
        // for development and testing of your application. However, it may not
        // provide sufficient security for your deployed application. You should
        // always make sure that the URL validation callback method that you use
        // meets the security requirements of your organization.
        internal static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            return new Uri(redirectionUrl).Scheme == "https";
        }

        internal static bool TryConnectToService(
            IWin32Window owner,
            ConnectionParams param, 
            out ExchangeService service)
        {
            ExchangeService locService = new ExchangeService(param.Version);

            //locService.PreAuthenticate = true;
            Uri uri;
            if (Uri.TryCreate(param.AutodiscoverUrl, UriKind.RelativeOrAbsolute, out uri))
            {
                locService.Url = uri;
            }

            if (param.TraceToFile)
                locService.TraceListener = new TraceListener();
            else
            {
                locService.TraceEnabled = true;
                locService.TraceFlags = TraceFlags.All;
                locService.TraceEnablePrettyPrinting = true;
            }

            if (UserDataFromConsole.GetUserDataFromConsoleCredUi(
                    owner, param.Data, ref locService))
            {
                service = locService;
                return true;
            }
            service = null;
            return false;
        }

        /*public static ExchangeService ConnectToService(IUserData userData, ITraceListener listener = null)
        {
            ExchangeService service = new ExchangeService(userData.Version);

            if (listener != null)
            {
                service.TraceListener = listener;
                service.TraceFlags = TraceFlags.All;
                service.TraceEnabled = true;
            }

            service.Credentials = new NetworkCredential(userData.EmailAddress, userData.Password);

            if (userData.AutodiscoverUrl == null)
            {
                Logger.Message("Using Autodiscover to find EWS URL for {0}. Please wait... ", userData.EmailAddress);

                service.AutodiscoverUrl(userData.EmailAddress, RedirectionUrlValidationCallback);
                userData.AutodiscoverUrl = service.Url;

                Logger.Message("Autodiscover Complete");
            }
            else
            {
                service.Url = userData.AutodiscoverUrl;
            }

            return service;
        }*/

        /*public static ExchangeService ConnectToServiceWithImpersonation(
          IUserData userData,
          string impersonatedUserSmtpAddress)
        {
            return ConnectToServiceWithImpersonation(userData, impersonatedUserSmtpAddress, null);
        }*/

        /*public static ExchangeService ConnectToServiceWithImpersonation(
          IUserData userData,
          string impersonatedUserSmtpAddress,
          ITraceListener listener)
        {
            ExchangeService service = new ExchangeService(userData.Version);

            if (listener != null)
            {
                service.TraceListener = listener;
                service.TraceFlags = TraceFlags.All;
                service.TraceEnabled = true;
            }

            service.Credentials = new NetworkCredential(userData.EmailAddress, userData.Password);

            ImpersonatedUserId impersonatedUserId =
              new ImpersonatedUserId(ConnectingIdType.SmtpAddress, impersonatedUserSmtpAddress);

            service.ImpersonatedUserId = impersonatedUserId;

            if (userData.AutodiscoverUrl == null)
            {
                service.AutodiscoverUrl(userData.EmailAddress, RedirectionUrlValidationCallback);
                userData.AutodiscoverUrl = service.Url;
            }
            else
            {
                service.Url = userData.AutodiscoverUrl;
            }

            return service;
        } */
    }
}
