namespace MXGP.Core
{
    using Contracts;
    using IO;
    using IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IChampionshipController championshipController;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine()
                    .Split();

                if (input[0] == "End")
                {
                    break;
                }

                try
                {
                    string output = string.Empty;

                    if (input[0] == "CreateRider")
                    {
                        output = this.championshipController.CreateRider(input[1]);
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        output = this.championshipController.CreateMotorcycle(input[1], input[2], int.Parse(input[3]));
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        output = this.championshipController.AddMotorcycleToRider(input[1], input[2]);
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        output = this.championshipController.AddRiderToRace(input[1], input[2]);
                    }
                    else if (input[0] == "CreateRace")
                    {
                        output = this.championshipController.CreateRace(input[1], int.Parse(input[2]));
                    }
                    else if (input[0] == "StartRace")
                    {
                        output = this.championshipController.StartRace(input[1]);
                    }

                    this.writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
