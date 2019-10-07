namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ");

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] inputArray = input
                    .Split(" ");

                string command = inputArray[0];

                if (command == "Drive")
                {
                    string carModel = inputArray[1];
                    double amountOfKm = double.Parse(inputArray[2]);

                    for (int i = 0; i < cars.Count; i++)
                    {
                        if (cars[i].Model == carModel)
                        {
                            cars[i] = Car.Drive(cars[i], amountOfKm);
                        }
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
