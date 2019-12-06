namespace Logger.Loggers
{
    using Appenders;
    using Enums;
    using System;

    public class Logger : ILogger
    {
        public Logger(params Appender[] appender)
        {
            this.Appender = appender;
        }

        public Appender[] Appender { get; }        

        public void Error(string dataTime, string message)
        {
            AppendMessage(dataTime, ReportLevel.Error, message);
        }

        public void Info(string dataTime, string message)
        {
            AppendMessage(dataTime, ReportLevel.Info, message);
        }

        public void Fatal(string dataTime, string message)
        {
            AppendMessage(dataTime, ReportLevel.Fatal, message);
        }

        public void Critical(string dataTime, string message)
        {
            AppendMessage(dataTime, ReportLevel.Critical, message);
        }
        public void Warning(string dataTime, string message)
        {
            AppendMessage(dataTime, ReportLevel.Warning, message);

        }

        public void AppendMessage(string dateTime, ReportLevel level, string message)
        {
            foreach (var apender in this.Appender)
            {
                apender.Append(dateTime, level, message);
            }
        }        
    }
}