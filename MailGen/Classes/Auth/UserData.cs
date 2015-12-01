namespace MailGen.Classes.Auth
{
    internal sealed class UserData : IUserData
    {
        public UserData(
            string userName, 
            string email, 
            string password, 
            string domain)
        {
            this.UserName = userName;
            this.EmailAddress = email;
            this.Password = password;
            this.Domain = domain;
        }

        public string UserName { get; set; }
        public string Domain { get; set; }
        public string EmailAddress { get; private set; }
        public string Password { get; set; }
    }
}