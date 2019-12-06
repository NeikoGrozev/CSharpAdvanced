namespace Logger.Factory
{
    using Appenders;
    using Logger.Enums;
    using Logger.Layouts;
    using Logger.Loggers;
    using System;

    public static class AppenderFactory
    {
        public static Appender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {            
            switch (type)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout) { ReportLevel = reportLevel};
                case "FileAppender":
                    return new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel};
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }
        }
    }
}