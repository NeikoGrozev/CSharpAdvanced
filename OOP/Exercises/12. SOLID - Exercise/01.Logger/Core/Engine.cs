﻿namespace Logger.Core
{
    using Appenders;
    using Enums;
    using Factory;
    using Layouts;
    using Loggers;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private List<Appender> appenders = new List<Appender>();
        public void Run()
        {
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

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

            ILogger logger = new Logger(appenders.ToArray());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] inputInfo = input
                    .Split("|");

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

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
