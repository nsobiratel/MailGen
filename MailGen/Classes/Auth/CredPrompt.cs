using MailGen.Classes.Logging.Loggers;

namespace MailGen.Classes.Auth
{
    using System;
    using System.Security;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    using alter;
    using Properties;

    /// <summary>Encapsulates the Credential Management API functionality for the the command line.</summary>
    internal sealed class CredPrompt
    {
        public CredPrompt(string target)
        {
            this.Target = target;
        }

        private string _name = string.Empty;

        private SecureString _password = new SecureString();
        private string _target = @"Exchange Web Services (EWS)";

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (value != null)
                {
                    if (value.Length > Credmgmtui.MaxUsernameLength)
                    {
                        string message = string.Format(
                            Thread.CurrentThread.CurrentUICulture,
                            LocalizibleStrings.NameMaxLength,
                            Credmgmtui.MaxUsernameLength);
                        throw new ArgumentException(message, "Name");
                    }
                }
                this._name = value;
            }
        }

        /// <summary>
        /// Gets or sets the password for the credentials.
        /// </summary> 
        public SecureString Password
        {
            get
            {
                return this._password;
            }
            private set
            {
                if (value != null)
                {
                    if (value.Length > Credmgmtui.MaxPasswordLength)
                    {
                        string message = string.Format(
                            Thread.CurrentThread.CurrentUICulture,
                            LocalizibleStrings.PasswordLength,
                            Credmgmtui.MaxPasswordLength);
                        throw new ArgumentException(message, "Password");
                    }
                }
                this._password = value;
            }
        }

        /// <summary>
        /// Gets or sets if the save checkbox status.
        /// </summary>
        public bool SaveChecked { get; private set; }

        /// <summary>
        /// Gets or sets the name of the target for the credentials.
        /// </summary>
        private string Target
        {
            get
            {
                return this._target;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(LocalizibleStrings.TargetNotNull, "Target");
                }
                if (value.Length > Credmgmtui.MaxGenericTargetLength)
                {
                    string message = string.Format(
                        Thread.CurrentThread.CurrentUICulture,
                        LocalizibleStrings.TargetNameLength,
                        Credmgmtui.MaxGenericTargetLength);
                    throw new ArgumentException(message, "Target");
                }
                this._target = value;
            }
        }

        /// <summary>
        /// Calls the CredUIConfirmCredentials function which confirms that the credentials
        /// provided for the target should be kept in the case they are persisted.</summary>
        /// <param name="value">A value of true if the credentials should be persisted.</param>
        public void Confirm(bool value)
        {
            Credmgmtui.ReturnCodes res = Credmgmtui.ConfirmCredentials(this.Target, value);
            if (res != Credmgmtui.ReturnCodes.NoError
                && res != Credmgmtui.ReturnCodes.ErrorInvalidParameter)
            {
                GenericLogger<CredPrompt>.Error(
                    LocalizibleStrings.ConfirmationFailed + res);
            }
        }

        /// <summary>
        /// Calls the CredUICmdLinePromptForCredentials function that will either prompt for
        /// credentials or get the stored credentials for the specified target.
        /// </summary>
        /// <returns>The DialogResult that indicates the results of using CredUI.</returns>
        /// <remarks>
        /// Sets the user name, password and persistence state of the dialog.
        /// </remarks>
        internal DialogResult ShowPrompt()
        {
            /*StringBuilder locName = new StringBuilder(Credmgmtui.MaxUsernameLength);
            StringBuilder pwd = new StringBuilder(Credmgmtui.MaxPasswordLength);
            StringBuilder domain = new StringBuilder(100);
            bool saveChecked = this.SaveChecked;
            Credmgmtui.Flags flags = GetFlags();*/

            lock (this)
            {
                // Call CredUi.dll to prompt for credentials. If the credentials for the target have already
                // been saved in the credential manager, then this method will return the credentials 
                // and the UI will not be displayed. 
                /*Credmgmtui.ReturnCodes code = Credmgmtui.CredUICmdLinePromptForCredentials(
                    this.Target,
                    IntPtr.Zero, 0,
                    locName, Credmgmtui.MaxUsernameLength,
                    pwd, Credmgmtui.MaxPasswordLength,
                    ref saveChecked,
                    flags
                    );*/

                /*Credmgmtui.CREDUI_INFO credUi = new Credmgmtui.CREDUI_INFO
                {
                    pszCaptionText = "Enter your credentials, please",
                    pszMessageText = "Enter your Exchange Online user principal name for the Exchange Web Services stored credential (user@domain.com)..."
                };
                credUi.cbSize = Marshal.SizeOf(credUi);*/

                /*uint authPackage = 0;
                IntPtr outCredBuffer = new IntPtr();
                uint outCredSize;*/

                /*Credmgmtui.ReturnCodes code = Credmgmtui.CredUIPromptForWindowsCredentials(
                    ref credUi, 1, ref  authPackage, IntPtr.Zero, 0, out outCredBuffer, out outCredSize, ref saveChecked, flags);*/

                PromptCredentialsResult res = 
                    CredentialUi.Prompt(LocalizibleStrings.EwsLogin, LocalizibleStrings.InputYourCred);

                if (res == null)
                    return DialogResult.Cancel;

                // Convert the password returned by the credential manager to a secure string. 
                this.Password = ConvertToSecureString(new StringBuilder(res.Password));

                // Get the user name stored in the credential manager.
                this.Name = res.UserName;

                // Get the value that indicates whether the credentials are persisted 
                // in the credential manager.
                this.SaveChecked = res.IsSaveChecked;

                return DialogResult.OK;
                //return GetCredPromptResult(res.);
            }
        }

        /// <summary>
        /// Converts a string to a SecureString object.
        /// </summary>
        /// <param name="password">The unprotected password returned by CredUI.</param>
        /// <returns>The password as a SecureString object.</returns>
        private static SecureString ConvertToSecureString(StringBuilder password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            SecureString securePassword = new SecureString();
            for (int i = 0; i < password.Length; i++)
            {
                securePassword.AppendChar(password[i]);
                password[i] = '\x0000';
            }

            securePassword.MakeReadOnly();
            password.Clear();
            return securePassword;
        }

        /*/// <summary>
        /// Provides the flags that specify how the Windows credential manager handles the credentials.
        /// </summary>
        private static Credmgmtui.Flags GetFlags()
        {
            const Credmgmtui.Flags Flags = Credmgmtui.Flags.GenericCredentials |
                                Credmgmtui.Flags.ExpectConfirmation |
                                Credmgmtui.Flags.ExcludeCertificates;
            return Flags;
        } */

        /*/// <summary>
        /// Returns a DialogResult based on the code returned by the credential manager.
        /// </summary>
        /// <param name="code">The credential return code provided by the credential manager.</param>
        private static DialogResult GetCredPromptResult(Credmgmtui.ReturnCodes code)
        {
            DialogResult result;
            switch (code)
            {
                case Credmgmtui.ReturnCodes.NoError:
                    result = DialogResult.OK;
                    break;

                case Credmgmtui.ReturnCodes.ErrorCancelled:
                    result = DialogResult.Cancel;
                    break;

                case Credmgmtui.ReturnCodes.ErrorNoSuchLogonSession:
                    throw new ApplicationException("The credential manager cannot be used.");

                case Credmgmtui.ReturnCodes.ErrorInvalidParameter:
                    throw new ApplicationException(@"Invalid parameter. See http://msdn.microsoft.com/en-us/library/windows/desktop/aa375177(v=vs.85).aspx");

                case Credmgmtui.ReturnCodes.ErrorInvalidFlags:
                    throw new ApplicationException("Invalid flags.");

                default:
                    throw new ApplicationException("The credential manager returned an unknown return code.");
            }
            return result;
        }*/
    }
}