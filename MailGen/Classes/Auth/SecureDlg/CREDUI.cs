namespace MailGen.Classes.Auth.SecureDlg
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class Credui
    {
        /// <summary>http://msdn.microsoft.com/library/default.asp?url=/library/en-us/secauthn/security/authentication_constants.asp</summary>
        public const int MaxMessageLength = 100;
        public const int MaxCaptionLength = 100;
        public const int MaxGenericTargetLength = 100;
        public const int MaxDomainTargetLength = 100;
        public const int MaxUsernameLength = 100;
        public const int MaxPasswordLength = 100;

        /// <summary>
        /// http://www.pinvoke.net/default.aspx/Enums.CREDUI_FLAGS
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnnetsec/html/dpapiusercredentials.asp
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/secauthn/security/creduipromptforcredentials.asp
        /// </summary>
        [Flags]
        public enum Flags
        {
            IncorrectPassword = 0x1,
            DoNotPersist = 0x2,
            RequestAdministrator = 0x4,
            ExcludeCertificates = 0x8,
            RequireCertificate = 0x10,
            ShowSaveCheckBox = 0x40,
            AlwaysShowUi = 0x80,
            RequireSmartcard = 0x100,
            PasswordOnlyOk = 0x200,
            ValidateUsername = 0x400,
            CompleteUsername = 0x800,
            Persist = 0x1000,
            ServerCredential = 0x4000,
            ExpectConfirmation = 0x20000,
            GenericCredentials = 0x40000,
            UsernameTargetCredentials = 0x80000,
            KeepUsername = 0x100000
        }

        /// <summary>http://www.pinvoke.net/default.aspx/Enums.CredUIReturnCodes</summary>
        public enum ReturnCodes
        {
            NoError = 0,
            ErrorInvalidParameter = 87,
            ErrorInsufficientBuffer = 122,
            ErrorInvalidFlags = 1004,
            ErrorNotFound = 1168,
            ErrorCancelled = 1223,
            ErrorNoSuchLogonSession = 1312,
            ErrorInvalidAccountName = 1315
        }

        /// <summary>
        /// http://www.pinvoke.net/default.aspx/Structures.CREDUI_INFO
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/secauthn/security/credui_info.asp
        /// </summary>
        public struct Info
        {
            public int CbSize;
            public IntPtr HwndParent;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string PszMessageText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string PszCaptionText;
            public IntPtr HbmBanner;
        }

        /// <summary>
        /// http://www.pinvoke.net/default.aspx/credui.CredUIPromptForCredentialsW
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/secauthn/security/creduipromptforcredentials.asp
        /// </summary>
        [DllImport("credui", EntryPoint = "CredUIPromptForCredentialsW", CharSet = CharSet.Unicode)]
        public static extern ReturnCodes PromptForCredentials(
            ref Info creditUr,
            string targetName,
            IntPtr reserved1,
            int iError,
            StringBuilder userName,
            int maxUserName,
            StringBuilder password,
            int maxPassword,
            ref int iSave,
            Flags flags
            );

        /// <summary>
        /// http://www.pinvoke.net/default.aspx/credui.CredUIConfirmCredentials
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/secauthn/security/creduiconfirmcredentials.asp
        /// </summary>
        [DllImport("credui.dll", EntryPoint = "CredUIConfirmCredentialsW", CharSet = CharSet.Unicode)]
        public static extern ReturnCodes ConfirmCredentials(
            string targetName,
            bool confirm
            );
    }
}