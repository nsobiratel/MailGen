namespace MailGen.Classes.Logging.Loggers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;

    using MailGen.Classes.Logging.Algorithms;
    using MailGen.Properties;

    internal static class Logger
    {
        private const string MESSAGE = "MESSAGE";
        private const string WARNING = "WARNING";
        private const string ERROR = "ERROR";
        private const string DEBUG = "DEBUG";

        private static readonly List<ILogWriteAlgorithm> Algorithms =
            new List<ILogWriteAlgorithm>();

        private static string Beautify(string msg, string msgType)
        {
            return DateTime.Now.ToString(
                @"dd.MM.yy HH:mm:ss", CultureInfo.CurrentCulture)
                + @" " + msgType + @" : " + msg;
        }

        public static void AddAlgorithm(ILogWriteAlgorithm algorithm)
        {
            Logger.Algorithms.Add(algorithm);
        }

        private static void Exec(string msg, string type)
        {
            Contract.Requires(Algorithms != null && Algorithms.Any());
            Logger.Algorithms.ForEach(a => a.Write(Logger.Beautify(msg, type)));
        }

        public static void Message(string msg)
        {
            Logger.Exec(msg, Logger.MESSAGE);
        }

        public static void Message(string msg, params object[] @params)
        {
            Logger.Message(string.Format(CultureInfo.InvariantCulture, msg, @params));
        }

        public static void Error(
            string msg,
            Exception exc = null,
            bool critical = false,
            bool sendMail = true)
        {
            try
            {
				if (exc == null)
				{
                    Exec(msg, ERROR);
					if (sendMail)
						Mailer.Send(null, msg);
				}
				else
				{
                    Exec(
						msg 
						+ LocalizibleStrings.ErrorText + exc.Message 
						+ "\nExceptionStackTrace : \n" + exc.StackTrace
						+ "\nTargetSite : " + exc.TargetSite
						+ "\nSource : " + exc.Source, 
						Logger.ERROR);
					if (sendMail)
						Mailer.Send(exc, msg);					
				}
            }
            finally
            {
                if (critical)
                {
                    Environment.FailFast(msg, exc);
                    Environment.Exit(1);
                }
            }
        }

        public static void Warning(
            string msg,
            object[] @params = null,
            bool sendMail = true)
        {
            Logger.Exec(msg, Logger.WARNING);
            if (sendMail)
                Mailer.Send(null, msg);
        }

        public static void Debug(string msg)
        {
            Logger.Exec(msg, Logger.DEBUG);
        }

		public static void Debug(string who, string what)
		{
			Logger.Debug(who + @" - " + what);
		}

        public static void Debug(string msg, params object[] args)
        {
            Logger.Debug(string.Format(CultureInfo.InvariantCulture, msg, args));
        }

        public static string GetLogText()
        {
            IFileLogWriteAlgorithm alg =
                Logger.Algorithms.OfType<IFileLogWriteAlgorithm>().FirstOrDefault();
            return alg == null ? null : alg.GetLogText();
        }
    }
}
