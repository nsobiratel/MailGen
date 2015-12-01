namespace MailGen.Classes.Auth
{
    using System;
    using System.Windows.Forms;

    using Logging.Loggers;

    using MailGen.Properties;

    using Microsoft.Exchange.WebServices.Data;
    using SecureDlg;

    // This sample is for demonstration purposes only.
    // Before you run this sample, make sure that the code meets the
    // coding requirements of your organization.

    static class CredentialHelper
    {
        // References:
        // http://msdn.microsoft.com/en-us/library/aa480470.aspx

        /// <summary>
        /// Accepts a user credentials if they haven't been saved or if they have changed, adds them to the credential cache, and makes
        /// a call to EWS to verify that the credentials work. If the credentials work, then a confirmation is sent to the credential
        /// manager and the credentials are provided back to the application to be used to make EWS calls.
        /// </summary>
        internal static bool AppLogin(IWin32Window owner, IUserData data, ref ExchangeService service)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data.UserName) ||
                    string.IsNullOrWhiteSpace(data.Password))
                {
                    // Create the credential prompt that will handle the user credentials. 
                    //CredPrompt prompt = new CredPrompt(@"Exchange Web Services (EWS)");
                    CredentialsDialog dlg = new CredentialsDialog(
                        @"Exchange Web Services (EWS)", "EWS credentials", "Enter your credentials");

                    // Show the prompt. This will either prompt for the user credentials or, if they 
                    // already exist on the system, it will load credentials from the cache in the CredDialog object.
                    //DialogResult result = prompt.ShowPrompt();
                    DialogResult result = dlg.Show(owner, true);

                    if (result == DialogResult.OK)
                    {
                        // Authenticate the credentials and if they work, confirm the credentials and provide the 
                        // ExchangeService object back to the application.
                        string[] parts = dlg.Name.Split('\\');
                        switch (parts.Length)
                        {
                            case 1:
                                data.UserName = parts[0];
                                break;
                            default:
                                data.Domain = parts[0];
                                data.UserName = parts[1];
                                break;
                        }
                        data.Password = dlg.Password;

                        if (Authenticate(data, ref service))
                        {
                            // The credentials were authenticated. Confirm that we want the 
                            // credential manager to save our credentials.
                            if (dlg.SaveChecked)
                                dlg.Confirm(true);
                            return true;
                        }
                        // The credentials were not authenticated.
                        try
                        {
                            dlg.Confirm(false);
                            return false;
                        }
                        catch (ApplicationException)
                        {
                            // Prompt user for credentials again. We may need to provide a way to break 
                            while (true)
                            {
                                DialogResult res = MessageBox.Show(
                                    LocalizibleStrings.RetryConnection,
                                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                return res == DialogResult.Yes && AppLogin(owner, data, ref service);
                            }
                        }
                    }

                    if (result != DialogResult.Cancel)
                    {
                        throw new ApplicationException(LocalizibleStrings.UnhandledCondition + result);
                    }
                }
                else
                {
                    return Authenticate(data, ref service);
                }
            }
            // This will capture errors stemming from CredUICmdLinePromptForCredentials.
            catch (ApplicationException exc)
            {
                Logger.Error(@"AppLogin", exc);
            }

            return false;
        }

        /// <summary>
        /// Authenticates using the credentials provided to the credential manager. It also 
        /// populates the ExchangeService object used by the application.
        /// </summary>
        /// <param name="data">users data : name, password, email, domain</param>
        /// <param name="service">The ExchangeService object for this application.</param>
        /// <returns>A value of true indicates that the client successfully authenticated with EWS.</returns>
        private static bool Authenticate(IUserData data, ref ExchangeService service)
        {
            bool authenticated = false;
            try
            {
                service.Credentials = new WebCredentials(data.UserName, data.Password, data.Domain);
                
                // Check if we have the service URL.
                if (service.Url == null 
                    || string.IsNullOrWhiteSpace(service.Url.OriginalString))
                {
                    Logger.Message(
                        LocalizibleStrings.StartAutodiscover, data.EmailAddress);
                    service.AutodiscoverUrl(
                        data.EmailAddress, Service.RedirectionUrlValidationCallback);
                    Logger.Message(LocalizibleStrings.AutodiscoverComplete);
                }

                // Once we have the URL, try a ConvertId operation to check if we can access the service. We expect that
                // the user will be authenticated and that we will get an error code due to the invalid format. Expect a
                // ServiceResponseException.
                Logger.Message(LocalizibleStrings.AttemptingConnectEws);
                service.ConvertId(new AlternateId(IdFormat.EwsId, @"Placeholder", data.UserName), IdFormat.EwsId);
            }
            // The user principal name is in a bad format.
            catch (FormatException fe)
            {
                Logger.Error(LocalizibleStrings.AuthInvalidUpn, fe);
            }
            catch (AutodiscoverLocalException ale)
            {
                Logger.Error(LocalizibleStrings.Auth, ale);
            }
            // The credentials were authenticated. We expect this exception since we are providing intentional bad data for ConvertId
            catch (ServiceResponseException)
            {
                Logger.Message(LocalizibleStrings.SuccConnection);
                authenticated = true;
            }
            // The credentials were not authenticated.
            catch (ServiceRequestException exc)
            {
                Logger.Error(LocalizibleStrings.CredNotAuth, exc);
            }
            return authenticated;
        }
    }
}
