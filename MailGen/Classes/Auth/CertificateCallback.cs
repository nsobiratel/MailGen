namespace MailGen.Classes.Auth
{
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using Logging.Loggers;

    // This sample is for demonstration purposes only. Before you run this sample, make sure that the code meets the coding requirements of your organization.
    internal static class CertificateCallback
    {
        public static void Initialize()
        {
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
        }

        // SECURITY NOTE: This certificate callback function is meant for an on-premise
        //                test installation of Exchange that uses the default self-signed
        //                certificate. We included this callback function to make it 
        //                possible to run the Exchange 101 code samples without needing
        //                to install a signed certificate.
        //
        //                In production, the Exchange server should have a valid, signed 
        //                certificate. This code should not be used on a server that has 
        //                a signed certificate, and it should not be used on a production 
        //                server.
        //                
        //                To activate the callback method, remove the code comments as
        //                instructed below.
        private static bool CertificateValidationCallBack(
             object sender,
             X509Certificate certificate,
             X509Chain chain,
             SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == 0)
            {
                return false;
            }

            if (chain == null)
                return false;

            bool all = true;
            foreach (X509ChainStatus status in chain.ChainStatus)
            {
                if ((certificate.Subject == certificate.Issuer)
                    && (status.Status == X509ChainStatusFlags.UntrustedRoot))
                {
                    Logger.Message("Certificate for " + certificate.Subject + " is selfsigned");
                    continue;
                }

                if (status.Status == X509ChainStatusFlags.NoError)
                {
                    Logger.Message("Certificate for " + certificate.Subject + " valid");
                    continue;
                }

                Logger.Warning("Certificate for " + certificate.Subject + " have bad status : " + status.StatusInformation);
                all = false;
                break;
            }

            return all;
        }
    }
}
