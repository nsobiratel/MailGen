namespace MailGen.Classes.Auth.SecureDlg
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>Encapsulates dialog functionality from the Credential Management API.</summary>
    public sealed class CredentialsDialog
    {
        /// <summary>The only valid bitmap height (in pixels) of a user-defined banner.</summary>
        private const int ValidBannerHeight = 60;
        /// <summary>The only valid bitmap width (in pixels) of a user-defined banner.</summary>
        private const int ValidBannerWidth = 320;

        /// <summary>Initializes a new instance of the <see cref="T:MailGen.Classes.Auth.SecureDlg.CredentialsDialog"/> class
        /// with the specified target.</summary>
        /// <param name="target">The name of the target for the credentials, typically a server name.</param>
        public CredentialsDialog(string target)
            : this(target, null)
        { }
        /// <summary>Initializes a new instance of the <see cref="T:MailGen.Classes.Auth.SecureDlg.CredentialsDialog"/> class
        /// with the specified target and caption.</summary>
        /// <param name="target">The name of the target for the credentials, typically a server name.</param>
        /// <param name="caption">The caption of the dialog (null will cause a system default title to be used).</param>
        public CredentialsDialog(string target, string caption)
            : this(target, caption, null)
        { }
        /// <summary>Initializes a new instance of the <see cref="T:MailGen.Classes.Auth.SecureDlg.CredentialsDialog"/> class
        /// with the specified target, caption and message.</summary>
        /// <param name="target">The name of the target for the credentials, typically a server name.</param>
        /// <param name="caption">The caption of the dialog (null will cause a system default title to be used).</param>
        /// <param name="message">The message of the dialog (null will cause a system default message to be used).</param>
        public CredentialsDialog(string target, string caption, string message)
            : this(target, caption, message, null)
        { }
        /// <summary>Initializes a new instance of the <see cref="T:MailGen.Classes.Auth.SecureDlg.CredentialsDialog"/> class
        /// with the specified target, caption, message and banner.</summary>
        /// <param name="target">The name of the target for the credentials, typically a server name.</param>
        /// <param name="caption">The caption of the dialog (null will cause a system default title to be used).</param>
        /// <param name="message">The message of the dialog (null will cause a system default message to be used).</param>
        /// <param name="banner">The image to display on the dialog (null will cause a system default image to be used).</param>
        public CredentialsDialog(string target, string caption, string message, Image banner)
        {
            this.Target = target;
            this.Caption = caption;
            this.Message = message;
            this.Banner = banner;
        }

        /// <summary>
        /// Gets or sets if the dialog will be shown even if the credentials
        /// can be returned from an existing credential in the credential manager.
        /// </summary>
        public bool AlwaysDisplay { get; set; }

        private bool _excludeCertificates = true;
        /// <summary>Gets or sets if the dialog is populated with name/password only.</summary>
        public bool ExcludeCertificates
        {
            get
            {
                return this._excludeCertificates;
            }
            set
            {
                this._excludeCertificates = value;
            }
        }

        private bool _persist = true;
        /// <summary>Gets or sets if the credentials are to be persisted in the credential manager.</summary>
        public bool Persist
        {
            get
            {
                return this._persist;
            }
            set
            {
                this._persist = value;
            }
        }

        /// <summary>Gets or sets if the name is read-only.</summary>
        public bool KeepName { get; set; }

        private string _name = String.Empty;
        /// <summary>Gets or sets the name for the credentials.</summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != null)
                {
                    if (value.Length > Credui.MaxUsernameLength)
                    {
                        string message = String.Format(
                            Thread.CurrentThread.CurrentUICulture,
                            "The name has a maximum length of {0} characters.",
                            Credui.MaxUsernameLength);
                        throw new ArgumentException(message, "Name");
                    }
                }
                this._name = value;
            }
        }

        private string _password = String.Empty;
        /// <summary>Gets or sets the password for the credentials.</summary>
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (value != null)
                {
                    if (value.Length > Credui.MaxPasswordLength)
                    {
                        string message = String.Format(
                            Thread.CurrentThread.CurrentUICulture,
                            "The password has a maximum length of {0} characters.",
                            Credui.MaxPasswordLength);
                        throw new ArgumentException(message, "Password");
                    }
                }
                this._password = value;
            }
        }

        /// <summary>Gets or sets if the save checkbox status.</summary>
        public bool SaveChecked { get; set; }

        private bool _saveDisplayed = true;
        /// <summary>Gets or sets if the save checkbox is displayed.</summary>
        /// <remarks>This value only has effect if Persist is true.</remarks>
        public bool SaveDisplayed
        {
            get
            {
                return this._saveDisplayed;
            }
            set
            {
                this._saveDisplayed = value;
            }
        }

        private string _target = String.Empty;
        /// <summary>Gets or sets the name of the target for the credentials, typically a server name.</summary>
        public string Target
        {
            get
            {
                return this._target;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("The target cannot be a null value.", "Target");
                }
                if (value.Length > Credui.MaxGenericTargetLength)
                {
                    string message = String.Format(
                        Thread.CurrentThread.CurrentUICulture,
                        "The target has a maximum length of {0} characters.",
                        Credui.MaxGenericTargetLength);
                    throw new ArgumentException(message, "Target");
                }
                this._target = value;
            }
        }

        private string _caption = String.Empty;
        /// <summary>Gets or sets the caption of the dialog.</summary>
        /// <remarks>A null value will cause a system default caption to be used.</remarks>
        public string Caption
        {
            get
            {
                return this._caption;
            }
            set
            {
                if (value != null)
                {
                    if (value.Length > Credui.MaxCaptionLength)
                    {
                        string message = String.Format(
                            Thread.CurrentThread.CurrentUICulture,
                            "The caption has a maximum length of {0} characters.",
                            Credui.MaxCaptionLength);
                        throw new ArgumentException(message, "Caption");
                    }
                }
                this._caption = value;
            }
        }

        private string _message = String.Empty;
        /// <summary>Gets or sets the message of the dialog.</summary>
        /// <remarks>A null value will cause a system default message to be used.</remarks>
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                if (value != null)
                {
                    if (value.Length > Credui.MaxMessageLength)
                    {
                        string message = String.Format(
                            Thread.CurrentThread.CurrentUICulture,
                            "The message has a maximum length of {0} characters.",
                            Credui.MaxMessageLength);
                        throw new ArgumentException(message, "Message");
                    }
                }
                this._message = value;
            }
        }

        private Image _banner;
        /// <summary>Gets or sets the image to display on the dialog.</summary>
        /// <remarks>A null value will cause a system default image to be used.</remarks>
        public Image Banner
        {
            get
            {
                return this._banner;
            }
            set
            {
                if (value != null)
                {
                    if (value.Width != CredentialsDialog.ValidBannerWidth)
                    {
                        throw new ArgumentException("The banner image width must be 320 pixels.", "Banner");
                    }
                    if (value.Height != CredentialsDialog.ValidBannerHeight)
                    {
                        throw new ArgumentException("The banner image height must be 60 pixels.", "Banner");
                    }
                }
                this._banner = value;
            }
        }

        /// <summary>Shows the credentials dialog.</summary>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show()
        {
            return this.Show(null, this.Name, this.Password, this.SaveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified save checkbox status.</summary>
        /// <param name="saveChecked">True if the save checkbox is checked.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(bool saveChecked)
        {
            return this.Show(null, this.Name, this.Password, saveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified name.</summary>
        /// <param name="name">The name for the credentials.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(string name)
        {
            return this.Show(null, name, this.Password, this.SaveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified name and password.</summary>
        /// <param name="name">The name for the credentials.</param>
        /// <param name="password">The password for the credentials.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(string name, string password)
        {
            return this.Show(null, name, password, this.SaveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified name, password and save checkbox status.</summary>
        /// <param name="name">The name for the credentials.</param>
        /// <param name="password">The password for the credentials.</param>
        /// <param name="saveChecked">True if the save checkbox is checked.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(string name, string password, bool saveChecked)
        {
            return this.Show(null, name, password, saveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified owner.</summary>
        /// <param name="owner">The System.Windows.Forms.IWin32Window the dialog will display in front of.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(IWin32Window owner)
        {
            return this.Show(owner, this.Name, this.Password, this.SaveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified owner and save checkbox status.</summary>
        /// <param name="owner">The System.Windows.Forms.IWin32Window the dialog will display in front of.</param>
        /// <param name="saveChecked">True if the save checkbox is checked.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(IWin32Window owner, bool saveChecked)
        {
            return this.Show(owner, this.Name, this.Password, saveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified owner, name and password.</summary>
        /// <param name="owner">The System.Windows.Forms.IWin32Window the dialog will display in front of.</param>
        /// <param name="name">The name for the credentials.</param>
        /// <param name="password">The password for the credentials.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(IWin32Window owner, string name, string password)
        {
            return this.Show(owner, name, password, this.SaveChecked);
        }

        /// <summary>Shows the credentials dialog with the specified owner, name, password and save checkbox status.</summary>
        /// <param name="owner">The System.Windows.Forms.IWin32Window the dialog will display in front of.</param>
        /// <param name="name">The name for the credentials.</param>
        /// <param name="password">The password for the credentials.</param>
        /// <param name="saveChecked">True if the save checkbox is checked.</param>
        /// <returns>Returns a DialogResult indicating the user action.</returns>
        public DialogResult Show(IWin32Window owner, string name, string password, bool saveChecked)
        {
            if (Environment.OSVersion.Version.Major < 5)
            {
                throw new ApplicationException("The Credential Management API requires Windows XP / Windows Server 2003 or later.");
            }
            this.Name = name;
            this.Password = password;
            this.SaveChecked = saveChecked;

            return this.ShowDialog(owner);
        }

        /// <summary>Confirmation action to be applied.</summary>
        /// <param name="value">True if the credentials should be persisted.</param>
        public void Confirm(bool value)
        {
            switch (Credui.ConfirmCredentials(this.Target, value))
            {
                case Credui.ReturnCodes.NoError:
                    break;

                case Credui.ReturnCodes.ErrorInvalidParameter:
                    // for some reason, this is encountered when credentials are overwritten
                    break;

                default:
                    throw new ApplicationException("Credential confirmation failed.");
            }
        }

        /// <summary>Returns a DialogResult indicating the user action.</summary>
        /// <param name="owner">The System.Windows.Forms.IWin32Window the dialog will display in front of.</param>
        /// <remarks>
        /// Sets the name, password and SaveChecked accessors to the state of the dialog as it was dismissed by the user.
        /// </remarks>
        private DialogResult ShowDialog(IWin32Window owner)
        {
            // set the api call parameters
            StringBuilder name = new StringBuilder(Credui.MaxUsernameLength);
            name.Append(this.Name);

            StringBuilder password = new StringBuilder(Credui.MaxPasswordLength);
            password.Append(this.Password);

            int saveChecked = Convert.ToInt32(this.SaveChecked);

            Credui.Info info = this.GetInfo(owner);
            Credui.Flags flags = this.GetFlags();

            // make the api call
            Credui.ReturnCodes code = Credui.PromptForCredentials(
                ref info,
                this.Target,
                IntPtr.Zero, 0,
                name, Credui.MaxUsernameLength,
                password, Credui.MaxPasswordLength,
                ref saveChecked,
                flags
                );

            // clean up resources
            if (this.Banner != null) Gdi32.DeleteObject(info.HbmBanner);

            // set the accessors from the api call parameters
            this.Name = name.ToString();
            this.Password = password.ToString();
            this.SaveChecked = Convert.ToBoolean(saveChecked);

            return CredentialsDialog.GetDialogResult(code);
        }

        /// <summary>Returns the info structure for dialog display settings.</summary>
        /// <param name="owner">The System.Windows.Forms.IWin32Window the dialog will display in front of.</param>
        private Credui.Info GetInfo(IWin32Window owner)
        {
            Credui.Info info = new Credui.Info();
            if (owner != null) info.HwndParent = owner.Handle;
            info.PszCaptionText = this.Caption;
            info.PszMessageText = this.Message;
            if (this.Banner != null)
            {
                info.HbmBanner = new Bitmap(this.Banner, CredentialsDialog.ValidBannerWidth, CredentialsDialog.ValidBannerHeight).GetHbitmap();
            }
            info.CbSize = Marshal.SizeOf(info);
            return info;
        }

        /// <summary>Returns the flags for dialog display options.</summary>
        private Credui.Flags GetFlags()
        {
            Credui.Flags flags = Credui.Flags.GenericCredentials;

            // grrrr... can't seem to get this to work...
            // if (incorrectPassword) flags = flags | CredUI.CREDUI_FLAGS.INCORRECT_PASSWORD;

            if (this.AlwaysDisplay) flags = flags | Credui.Flags.AlwaysShowUi;

            if (this.ExcludeCertificates) flags = flags | Credui.Flags.ExcludeCertificates;

            if (this.Persist)
            {
                flags = flags | Credui.Flags.ExpectConfirmation;
                if (this.SaveDisplayed) flags = flags | Credui.Flags.ShowSaveCheckBox;
            }
            else
            {
                flags = flags | Credui.Flags.DoNotPersist;
            }

            if (this.KeepName) flags = flags | Credui.Flags.KeepUsername;

            return flags;
        }

        /// <summary>Returns a DialogResult from the specified code.</summary>
        /// <param name="code">The credential return code.</param>
        private static DialogResult GetDialogResult(Credui.ReturnCodes code)
        {
            DialogResult result;
            switch (code)
            {
                case Credui.ReturnCodes.NoError:
                    result = DialogResult.OK;
                    break;

                case Credui.ReturnCodes.ErrorCancelled:
                    result = DialogResult.Cancel;
                    break;

                case Credui.ReturnCodes.ErrorNoSuchLogonSession:
                    throw new ApplicationException("No such logon session.");

                case Credui.ReturnCodes.ErrorNotFound:
                    throw new ApplicationException("Not found.");

                case Credui.ReturnCodes.ErrorInvalidAccountName:
                    throw new ApplicationException("Invalid account name.");

                case Credui.ReturnCodes.ErrorInsufficientBuffer:
                    throw new ApplicationException("Insufficient buffer.");

                case Credui.ReturnCodes.ErrorInvalidParameter:
                    throw new ApplicationException("Invalid parameter.");

                case Credui.ReturnCodes.ErrorInvalidFlags:
                    throw new ApplicationException("Invalid flags.");

                default:
                    throw new ApplicationException("Unknown credential result encountered.");
            }
            return result;
        }
    }
}
