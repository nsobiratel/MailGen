using System.Windows.Forms;

namespace MailGen.Classes.Auth
{
    /*using System;
    using System.Security;*/

    using Microsoft.Exchange.WebServices.Data;

    // This sample is for demonstration purposes only. Before you run this sample, make sure that the code meets the coding requirements of your organization.

    internal static class UserDataFromConsole/* : IUserData*/
    {
        //private static UserDataFromConsole userData;

        /*public static IUserData GetUserData(ref ExchangeService service)
        {
            if (userData == null)
            {
                GetUserDataFromConsoleCredUi(ref service);
            }

            return userData;
        }*/

        internal static bool GetUserDataFromConsoleCredUi(IWin32Window owner, IUserData data, ref ExchangeService service)
        {
            return CredentialHelper.AppLogin(owner, data, ref service);
        }

       /* private static void GetUserDataFromConsole()
        {
            userData = new UserDataFromConsole();

            Console.Write("Enter email address: ");
            userData.EmailAddress = Console.ReadLine();

            userData.Password = new SecureString();

            Console.Write("Enter password: ");

            while (true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                if (userInput.Key == ConsoleKey.Enter)
                {
                    break;
                }
                switch (userInput.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Backspace:
                        if (userData.Password.Length != 0)
                        {
                            userData.Password.RemoveAt(userData.Password.Length - 1);
                        }
                        break;
                    default:
                        userData.Password.AppendChar(userInput.KeyChar);
                        Console.Write("*");
                        break;
                }
            }

            Console.WriteLine();

            userData.Password.MakeReadOnly();
        } */

        /*public ExchangeVersion Version
        { get { return ExchangeVersion.Exchange2013; } }*/

        /*public string EmailAddress
        {
            get;
            private set;
        }

        public SecureString Password
        {
            get;
            private set;
        }

        public Uri AutodiscoverUrl
        {
            get;
            set;
        } */
    }
}
