namespace MailGen.Classes.Auth
{
    using System.Runtime.InteropServices;

    internal static class Credmgmtui
    {
        public const int MaxUsernameLength = 100;

        public const int MaxPasswordLength = 100;

        public const int MaxGenericTargetLength = 100;

        /*/// <summary>
        /// Provides the flags that specify how the Windows credential manager handles the credentials.
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa375177(v=vs.85).aspx
        /// </summary>
        [Flags]
        public enum Flags
        {
            ExcludeCertificates = 0x8,

            ExpectConfirmation = 0x20000,

            GenericCredentials = 0x40000
        }*/

        /// <summary>
        /// Provides the return code provided by the credential manager.
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa375177(v=vs.85).aspx
        /// </summary>
        public enum ReturnCodes
        {
            NoError = 0,

            ErrorInvalidParameter = 87,

            ErrorInvalidFlags = 1004,

            ErrorCancelled = 1223,

            ErrorNoSuchLogonSession = 1312,

            ErrorNotFound = 1168,

            ErrorInvalidAccountName = 1315,

            ErrorInsufficientBuffer = 122

        }

        /// <summary>
        /// Confirms that the credentials harvested by CredUICmdLinePromptForCredentialsW are valid and should be persisted.
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa375173(v=vs.85).aspx
        /// </summary>
        [DllImport(@"credui.dll", EntryPoint = "CredUIConfirmCredentialsW", CharSet = CharSet.Unicode)]
        public static extern ReturnCodes ConfirmCredentials(string targetName, bool confirm);

        /*/// <summary>
        /// Provides access to the Windows command line interface for storing user credentials.
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/aa375171(v=vs.85).aspx
        /// </summary>
        [DllImport("credui.dll", EntryPoint = "CredUICmdLinePromptForCredentialsW", CharSet = CharSet.Unicode)]
        public static extern ReturnCodes CredUICmdLinePromptForCredentials(
            string targetName,
            IntPtr reserved1,
            int iError,
            StringBuilder userName,
            int maxUserName,
            StringBuilder password,
            int maxPassword,
            ref int iSave,
            Flags flags); */

        /*[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct CREDUI_INFO
        {
            public int cbSize;

            public IntPtr hwndParent;

            public string pszMessageText;

            public string pszCaptionText;

            public IntPtr hbmBanner;
        }*/

        /*[DllImport("credui.dll", EntryPoint = "CredUIPromptForWindowsCredentials", CharSet = CharSet.Unicode)]
        internal static extern ReturnCodes CredUIPromptForWindowsCredentials(
            ref CREDUI_INFO creditUr,
            string targetName,
            ref IntPtr reserved1,
            int iError,
            StringBuilder userName,
            int maxUserName,
            StringBuilder password,
            int maxPassword,
            ref bool pfSave,
            Flags flags);*/


        /*[DllImport("credui.dll", CharSet = CharSet.Auto)]
        internal static extern ReturnCodes CredUIPromptForWindowsCredentials(
            ref CREDUI_INFO notUsedHere,
            int authError,
            ref uint authPackage,
            IntPtr InAuthBuffer,
            uint InAuthBufferSize,
            out IntPtr refOutAuthBuffer,
            out uint refOutAuthBufferSize,
            ref bool fSave,
            Flags flags);

        [DllImport("credui.dll", CharSet = CharSet.Auto)]
        internal static extern bool CredUnPackAuthenticationBuffer(
            int dwFlags,
            IntPtr pAuthBuffer,
            uint cbAuthBuffer,
            StringBuilder pszUserName,
            ref int pcchMaxUserName,
            StringBuilder pszDomainName,
            ref int pcchMaxDomainame,
            StringBuilder pszPassword,
            ref int pcchMaxPassword);*/
    }
}