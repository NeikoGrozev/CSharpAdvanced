namespace VehiclesExtension
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] carArgs = Console.ReadLine()
                .Split();
            string[] truckArgs = Console.ReadLine()
                .Split();
            string[] busArgs = Console.ReadLine()
                .Split();

            Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
            Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
            Bus bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine()
                        .Split();

                    string command = inputArgs[0];
                    string vehicleType = inputArgs[1];
                    double distanceOrLiters = double.Parse(inputArgs[2]);

                    if (command == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(distanceOrLiters));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distanceOrLiters));
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.IsEmpty = false;
                            Console.WriteLine(bus.Drive(distanceOrLiters));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(distanceOrLiters);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(distanceOrLiters);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(distanceOrLiters);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        Console.WriteLine(bus.Drive(distanceOrLiters));

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}