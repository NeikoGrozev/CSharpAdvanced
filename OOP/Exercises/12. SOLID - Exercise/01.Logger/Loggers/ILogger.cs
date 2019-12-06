namespace Logger.Loggers
{
    using Appenders;

    public interface ILogger
    {
        Appender[] Appender { get; }

        void Error(string dataTime, string message);

        void Info(string dataTime, string message);

        void Fatal(string dataTime, string message);

        void Critical(string dataTime, string message);

        void Warning(string dataTime, string message);
    }
}