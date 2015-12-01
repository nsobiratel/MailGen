namespace MailGen.Classes.Logging.Algorithms
{
    interface IFileLogWriteAlgorithm : ILogWriteAlgorithm
    {
        string FileName { get; set; }

        string GetLogText();
    }
}
