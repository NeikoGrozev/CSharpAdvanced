namespace RawData
{
    using Data;
    using DataCar;
    using DataCargo;
    using DataEngine;
    using DataTire;
    using System;

    public class Runner
    {
        public static void Run()
        {
            EngineFactory engineFactory = new EngineFactory();
            CargoFactory cargoFactory = new CargoFactory();
            TireFactory tireFactory = new TireFactory();
            CarFactory carFactory = new CarFactory();
            ConsoleReader consoleReader = new ConsoleReader();

            CarsCatalog cars = new CarsCatalog(engineFactory, cargoFactory, tireFactory, carFactory);

            int lines = int.Parse(consoleReader.Read());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = consoleReader.Read()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                cars.Add(parameters);
            }

            string command = consoleReader.Read();
            cars.GetCarsInfo(command);
        }
    }
}
