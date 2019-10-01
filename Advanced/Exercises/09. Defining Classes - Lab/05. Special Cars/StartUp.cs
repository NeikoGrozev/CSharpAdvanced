namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }

                double[] tiresInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Tire[] currentTire = new Tire[4];

                for (int i = 0; i < tiresInput.Length; i+=2)
                {
                    int year = (int)tiresInput[i];
                    double pressure = tiresInput[i + 1];

                    Tire tire = new Tire(year, pressure);
                    currentTire[i / 2] = tire;
                }

                tires.Add(currentTire);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                double[] engineInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                int horsePower = (int)engineInput[0];
                double cubicCapacity = engineInput[1];

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                string[] car = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string make = car[0];
                string model = car[1];
                int year = int.Parse(car[2]);
                double fuelQuantity = double.Parse(car[3]);
                double fuelConsumption = double.Parse(car[4]);
                int engineIndex = int.Parse(car[5]);
                int tiresIndex = int.Parse(car[6]);

                Car currentCar = new Car();

                currentCar.Make = make;
                currentCar.Model = model;
                currentCar.Year = year;
                currentCar.FuelQuantity = fuelQuantity;
                currentCar.FuelConsumption = fuelConsumption;
                currentCar.Engine = engines[engineIndex];
                currentCar.Tires = tires[tiresIndex];

                cars.Add(currentCar);
            }

            cars = cars
                .Where(y => y.Year >= 2017)
                .Where(h => h.Engine.HorsePower >= 330)
                .ToList();
            List<Car> specialCar = new List<Car>();

            foreach (var car in cars)
            {
                double pressureSum = 0;

                foreach (var item in car.Tires)
                {
                    pressureSum += item.Pressure;
                }

                if (pressureSum >= 9 && pressureSum <= 10)
                {
                    specialCar.Add(car);
                }
            }

            foreach (var car in specialCar)
            {
                car.Drive(20);
                PrintSpecialCar(car);
            }
        }

        private static void PrintSpecialCar(Car car)
        {
            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
            Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
            Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
        }
    }   
}
