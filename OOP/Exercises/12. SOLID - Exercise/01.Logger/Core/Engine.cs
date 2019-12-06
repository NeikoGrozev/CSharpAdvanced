namespace Logger.Core
{
    using Appenders;
    using Logger.Loggers;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private List<Appender> appenders;
        private CommandInterpreter commandInterpreter;

        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter();
            this.appenders = new List<Appender>();
        }

        public void Run()
        {
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.Read(inputInfo);
                          
            }

            ILogger logger = new Logger(appenders.ToArray());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    this.commandInterpreter.PrintInfo();

                    break;
                }

                string[] inputInfo = input
                    .Split("|");

                this.commandInterpreter.Read(inputInfo);
            }
        }
    }
}
