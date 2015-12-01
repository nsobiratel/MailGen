namespace MailGen.Classes.Logging.Loggers
{
    using System;

    public static class GenericLogger<TType>
    {
        private static string Beautify(string msg)
        {
            return typeof(TType).Name + @" : " + msg;
        }

        public static void Message(string msg)
        {
            Logger.Message(GenericLogger<TType>.Beautify(msg));
        }

        /*public static void Message(string msg, params object[] @params)
        {
            Logger.Message(Beautify(msg), @params);
        }  */

        public static void Error(string msg, Exception exc = null, bool critical = false)
        {
            Logger.Error(GenericLogger<TType>.Beautify(msg), exc, critical);
        }

        public static void Debug(string msg)
        {
            Logger.Debug(GenericLogger<TType>.Beautify(msg));
        }

        public static void Debug(string msg, params object[] args)
        {
            Logger.Debug(GenericLogger<TType>.Beautify(msg), args);
        }

        public static void Warning(string msg, params object[] @params)
        {
            Logger.Warning(GenericLogger<TType>.Beautify(msg), @params);
        }

        /*public static void Warning(string msg,  Exception exc = null)
        {
            Logger.Warning(Beautify(msg), exc);
        } */
    }
}