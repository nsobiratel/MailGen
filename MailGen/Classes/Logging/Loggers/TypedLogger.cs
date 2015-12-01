namespace MailGen.Classes.Logging.Loggers
{
    using System;

    internal static class TypedLogger
    {
        private static string Beautify(Type type, string msg)
        {
            return type.Name + @" : " + msg;
        }

        public static void Message(Type type, string msg)
        {
            Logger.Message(Beautify(type, msg));
        }

        /*public static void Message(string msg, params object[] @params)
        {
            Logger.Message(Beautify(msg), @params);
        }  */

        public static void Error(Type type, string msg, Exception exc = null, bool critical = false)
        {
            Logger.Error(Beautify(type, msg), exc, critical);
        }

        public static void Debug(Type type, string msg)
        {
            Logger.Debug(Beautify(type, msg));
        }

        public static void Debug(Type type, string msg, params object[] args)
        {
            Logger.Debug(Beautify(type, msg), args);
        }

        public static void Warning(Type type, string msg, params object[] @params)
        {
            Logger.Warning(Beautify(type, msg), @params);
        }
    }
}
