namespace MailGen.Classes.Logging.Realizations
{
    using System;

    using Algorithms;

    internal sealed class ComponentLogWriteAlgorithm : ILogWriteAlgorithm
    {
        #region Члены ILogPostAlgorithm

        //private readonly Control _control;

        private readonly Action<string> _writeMethod;

        public ComponentLogWriteAlgorithm(Action<string> writeMethod)
        {
            //this._control = control;
            this._writeMethod = writeMethod;
        }

        /// <summary>
        /// Записать одно сообщение в файл лога.
        /// </summary>
        /// <param name="msg">Текст сообщения</param>
        public void Write(string msg)
        {
            this._writeMethod.Invoke(msg);
        }

        #endregion
    }
}
