namespace PlayersAndMonsters.Core
{
    using Contracts;
    using IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpeter commandInterpeter;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpeter commandInterpeter, IReader reader, IWriter writer)
        {
            this.commandInterpeter = commandInterpeter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                try
                {                    
                    string[] input = this.reader.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if(input[0] == "Exit")
                    {
                        break;
                    }

                    string output = this.commandInterpeter.Read(input);

                    this.writer.WriteLine(output);
                }
                catch(Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}