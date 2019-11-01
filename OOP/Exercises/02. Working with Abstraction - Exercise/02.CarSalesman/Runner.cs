namespace CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class Runner
    {
        public static void Run()
        {
            EngineCreator engineCreator = new EngineCreator();
            CarCreator carCreator = new CarCreator();         

            int engineCount = int.Parse(Console.ReadLine());
            List<Engine> engines = engineCreator.Creat(engineCount);            

            int carCount = int.Parse(Console.ReadLine());
            List<Car> cars = carCreator.Creat(carCount, engines);

            Print(cars);            
        }

        public static void Print(List<Car>cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
