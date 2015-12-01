namespace MailGen.Classes
{
    using System.Globalization;

    using Logging.Loggers;
    using Properties;

    internal static class LocalizationHelper
    {
        public const string RuStr = "1049";
        public const int RuInt = 1049;

        public const string EnStr = "9";
        public const int EnInt = 9;

        public static CultureInfo TryGetCulture(string cultureStr)
        {
            if (string.IsNullOrWhiteSpace(cultureStr))
            {
                // если в конфиге не указана локаль, берем дефолтную для системы
                return GetInstalledUiCulture();
            }

            // если локаль указана, то пытаемся понять, настоящая она или нет
            int lcId;

            if (int.TryParse(cultureStr, out lcId))
            {
                // если настоящая - применяем
                try
                {
                    return CultureInfo.GetCultureInfo(lcId);
                }
                catch
                {
                    Logger.Warning(string.Format(
                        CultureInfo.CurrentCulture,
                        LocalizibleStrings.LangUnrecognized,
                        cultureStr));
                    return GetInstalledUiCulture();
                }
            }
            // если не настоящая - ругаемся и устанавливаем системную дефолтную
            Logger.Warning(string.Format(
                CultureInfo.CurrentCulture,
                LocalizibleStrings.LangCodeIsNotInteger,
                cultureStr));
            return GetInstalledUiCulture();
        }

        private static CultureInfo GetInstalledUiCulture()
        {
            int curId = CultureInfo.InstalledUICulture.LCID;
            if (curId == LocalizationHelper.EnInt || curId == LocalizationHelper.RuInt)
                return CultureInfo.InstalledUICulture;
            return
                CultureInfo.GetCultureInfo(LocalizationHelper.EnInt);
        }
    }
}
