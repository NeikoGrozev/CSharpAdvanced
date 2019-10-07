namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire tireFirst = new Tire(tire1Pressure, tire1Age);
                Tire tireSecond = new Tire(tire2Pressure, tire2Age);
                Tire tireThird = new Tire(tire3Pressure, tire3Age);
                Tire tireFourth = new Tire(tire4Pressure, tire4Age);

                Tire[] tires = new Tire[]
                {
                    tireFirst,
                    tireSecond,
                    tireThird,
                    tireFourth
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string cargoTypeCommand = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            if (cargoTypeCommand == "fragile")
            {
                cars = cars
                    .Where(x => x.Cargo.Type == cargoTypeCommand)
                    .ToList();

                foreach (var car in cars)
                {
                    foreach (var item in car.Tire)
                    {
                        if (item.Pressure < 1)
                        {
                            sb.AppendLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else if (cargoTypeCommand == "flamable")
            {
                cars = cars
                    .Where(x => x.Cargo.Type == cargoTypeCommand)
                    .Where(x => x.Engine.Power > 250)
                    .ToList();

                foreach (var car in cars)
                {
                    sb.AppendLine(car.Model);
                }
            }

            Console.WriteLine(string.Join("", sb));
        }
    }
}
