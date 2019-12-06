namespace Logger.Core
{
    using Appenders;
    using Enums;
    using Factory;
    using Layouts;
    using Logger.Loggers;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter
    {
        private readonly List<Appender> appenders;
        private readonly ILogger logger;

        public CommandInterpreter()
        {
            this.appenders = new List<Appender>();
            this.logger = new Logger();
        }
        public void Read(string[] args)
        {
            string typeMethod = args[0];

            if (typeMethod.Contains("Appender"))
            {
                CreateAppender(args);
            }
            else
            {
                AppendMessage(args);
            }
        }

        private void CreateAppender(string[] inputInfo)
        {
            string appenderType = inputInfo[0];
            string layoutType = inputInfo[1];
            ReportLevel reportLevel = ReportLevel.Info;

            if (inputInfo.Length > 2)
            {
                reportLevel = Enum.Parse<ReportLevel>(inputInfo[2], true);
            }

            ILayout layout = LayoutFactory.CreateLayout(layoutType);
            Appender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
            appenders.Add(appender);
        }

        private void AppendMessage(string[] inputInfo)
        {
            string loggerMethodType = inputInfo[0];
            string date = inputInfo[1];
            string message = inputInfo[2];

            if (loggerMethodType == "INFO")
            {
                logger.Info(date, message);
            }
            else if (loggerMethodType == "WARNING")
            {
                logger.Warning(date, message);
            }
            else if (loggerMethodType == "ERROR")
            {
                logger.Error(date, message);
            }
            else if (loggerMethodType == "CRITICAL")
            {
                logger.Critical(date, message);
            }
            else if (loggerMethodType == "FATAL")
            {
                logger.Fatal(date, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}