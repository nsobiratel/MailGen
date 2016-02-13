using System;
using System.Windows.Forms;

namespace MailGen
{
    using System.Globalization;
    using System.Threading;

    using Classes.Logging.Loggers;
    using Classes.Logging.Realizations;
    using Dialogs;

    using Classes;
    using Properties;

    static class Program
    {
        static void ShowWarn(string msg)
        {
            Mailer.SendingEnabled = false;
            TypedLogger.Warning(typeof(Program), msg);
            DialogResult res = MessageBox.Show(
                msg, LocalizibleStrings.Warning,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (res == DialogResult.No)
                Environment.Exit(-1);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // загружаем конфиг
            Config.LoadConfig();
            
            // включаем логирование. пока что в файл
            Logger.AddAlgorithm(new FileLogWriteAlgorithm(Config.GetParam(Config.LogFileName)));

            AppDomain.CurrentDomain.UnhandledException +=
                    (sender, args) => TypedLogger.Error(
                        typeof(Program), 
                        LocalizibleStrings.ErrorUnhandledException, 
                        args.ExceptionObject as Exception);

            // получаем и устанавливаем язык
            string lang = Config.GetParam(Config.Lang);
            CultureInfo culture = LocalizationHelper.TryGetCulture(lang);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            int port;
            if (!int.TryParse(Config.GetParam(Config.SmtpPort), out port))
            {
                ShowWarn(
                    LocalizibleStrings.SmtpUndefined 
                    + LocalizibleStrings.StandartEnd);
                port = -1;
            }

            string mailFrom = Config.GetParam(Config.ErrorMailSender);

            if (string.IsNullOrWhiteSpace(mailFrom))
            {
                ShowWarn(
                    LocalizibleStrings.SenderUndefined 
                    + LocalizibleStrings.StandartEnd);
            }

            string mailTo = Config.GetParam(Config.ErrorMailAndress);

            if (string.IsNullOrWhiteSpace(mailTo))
            {
                ShowWarn(
                    LocalizibleStrings.ErrorAdressUndefined
                    + LocalizibleStrings.StandartEnd);
            }

            string smtpServer = Config.GetParam(Config.SmtpServer);

            if (string.IsNullOrWhiteSpace(smtpServer))
            {
                ShowWarn(
                    LocalizibleStrings.SmtpServerUndefined 
                    + LocalizibleStrings.StandartEnd);
            }

            Mailer.SetParams(mailFrom, mailTo, smtpServer, port);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
