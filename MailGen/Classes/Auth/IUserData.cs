namespace MailGen.Classes.Auth
{

    //using Microsoft.Exchange.WebServices.Data;

    internal interface IUserData
    {
        string EmailAddress { get; }
        string Password { get; set; }
        string UserName { get; set; }
        string Domain { get; set; }
    }
}