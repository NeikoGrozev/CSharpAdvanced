namespace ViceCity.Core
{
    using Contracts;
    using IO;
    using IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controler;


        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controler = new Controller();

        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    break; ;
                }

                try
                {
                    string output = string.Empty;

                    if (input[0] == "AddPlayer")
                    {
                        output = this.controler.AddPlayer(input[1]);
                    }
                    else if (input[0] == "AddGun")
                    {
                        output = this.controler.AddGun(input[1], input[2]);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        output = this.controler.AddGunToPlayer(input[1]);
                    }
                    else if (input[0] == "Fight")
                    {
                       output =  this.controler.Fight();
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