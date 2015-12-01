namespace MailGen.Classes.Auth.alter
{
    using System.Security;

    /// <summary>
    /// 
    /// </summary>
    internal sealed class PromptCredentialsSecureStringResult : IPromptCredentialsResult
    {
        public SecureString UserName { get; internal set; }

        public SecureString DomainName { get; internal set; }

        public SecureString Password { get; internal set; }

        public bool IsSaveChecked { get; set; }
    }
}