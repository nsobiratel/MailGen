namespace MailGen.Classes.Auth.alter
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class PromptCredentialsResult : IPromptCredentialsResult
    {
        public string UserName
        { get; internal set; }
        public string DomainName
        { get; internal set; }
        public string Password
        { get; internal set; }
        public bool IsSaveChecked
        { get; set; }
    }
}