namespace MailGen.Classes
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using fastJSON;

    internal static class Config
    {
        public const string SmtpPort = "smtpport";
        public const string ErrorMailSender = "errormailfrom";
        public const string ErrorMailAndress = "errormailadress";
        public const string SmtpServer = "smtpserver";
        public const string LogFileName = "logfilename";
        public const string Lang = "lang";
        public const string EwsUri = "ews_url";

        public const string ContactFolder = "contactfolder";
        public const string EventTemplateFolderRu = "eventtemplatefolder_ru";
        public const string EmailTemplateFolderRu = "emailtemplatefolder_ru";
        public const string EventTemplateFolderEn = "eventtemplatefolder_en";
        public const string EmailTemplateFolderEn = "emailtemplatefolder_en";

        public const string User = "user";
        public const string Password = "password";
        public const string UserEmail = "user_email";
        public const string Domain = "domain";

        private static readonly string ConfigpathJson =
            Path.Combine(Directory.GetCurrentDirectory(), "conf.json");
        private static Dictionary<string, string> _parameters =
            new Dictionary<string, string>(5);

        public static void SetParam(string paramName, string paramValue)
        {
            if (_parameters.ContainsKey(paramName))
                _parameters[paramName] = paramValue;
            else
                _parameters.Add(paramName, paramValue);
            SaveConfig();
        }

        public static string GetParam(string paramName)
        {
            string value;
            _parameters.TryGetValue(paramName, out value);
            return value;
        }

        public static void LoadConfig()
        {
            string line = File.ReadAllText(ConfigpathJson);
            _parameters = JSON.ToObject<Dictionary<string, string>>(
                line, new JSONParameters { SerializeToLowerCaseNames = true }).ToDictionary(p => p.Key.ToLowerInvariant(), p => p.Value);
        }

        public static void SaveConfig()
        {
            File.WriteAllText(ConfigpathJson, JSON.ToJSON(_parameters));
        }
    }
}