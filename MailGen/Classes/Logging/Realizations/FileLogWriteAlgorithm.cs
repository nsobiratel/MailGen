namespace MailGen.Classes.Logging.Realizations
{
    using System.IO;
    using System.Text;

    using Algorithms;

    internal sealed class FileLogWriteAlgorithm : IFileLogWriteAlgorithm
    {
        #region Члены ILogPostAlgorithm

        private readonly StreamWriter _writer;

        public FileLogWriteAlgorithm(string filePath)
        {
            this.FileName = filePath;
            FileStream stream;
            try
            {
                stream =
                    File.Open(
                        this.FileName,
                        FileMode.OpenOrCreate,
                        FileAccess.Write,
                        FileShare.Read);
            }
            catch (IOException)
            {
                // скорее всего файл занят другим процессом
                // наиболее вероятно - другой копией центра управления
                this.FileName = Path.GetRandomFileName() + @".log";
                stream =
                    File.Open(
                        this.FileName,
                        FileMode.OpenOrCreate,
                        FileAccess.Write,
                        FileShare.Read);
            }

            this._writer = new StreamWriter(stream, Encoding.Unicode)
            {
                AutoFlush = true
            };
        }

        /// <summary>
        /// Записать одно сообщение в файл лога.
        /// </summary>
        /// <param name="msg">Текст сообщения</param>
        public void Write(string msg)
        {
            this._writer.WriteLine(msg);
            this._writer.Flush();
        }

        #endregion

        public string FileName { get; set; }

        public string GetLogText()
        {
            return File.Exists(this.FileName) 
                ? File.ReadAllText(this.FileName) : null;
        }
    }
}
