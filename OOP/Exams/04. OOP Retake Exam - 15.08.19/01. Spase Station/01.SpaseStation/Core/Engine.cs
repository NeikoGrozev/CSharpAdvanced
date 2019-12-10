namespace SpaceStation.Core
{
    using Contracts;
    using IO;
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine()
                    .Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string output = string.Empty;

                    if (input[0] == "AddAstronaut")
                    {
                        output = this.controller.AddAstronaut(input[1], input[2]);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string[] items = input.Skip(2).ToArray();

                        output = this.controller.AddPlanet(input[1], items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        output = this.controller.RetireAstronaut(input[1]);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        output = this.controller.ExplorePlanet(input[1]);
                    }
                    else if (input[0] == "Report")
                    {
                        output = this.controller.Report();
                    }

                    this.writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}