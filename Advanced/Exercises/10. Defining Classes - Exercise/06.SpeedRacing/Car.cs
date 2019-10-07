namespace SpeedRacing
{
    using System;
    using System.IO;

    public class Car
    {
        public Car()
        {
            this.Model = string.Empty;
            this.FuelAmount = 0;
            this.FuelConsumptionPerKilometer = 0;
            this.TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumption)
            : this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;            
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public static Car Drive(Car car, double amountOfKm)
        {
            double temp = car.FuelConsumptionPerKilometer * amountOfKm;

            if (car.FuelAmount >= temp)
            {
                car.FuelAmount -= temp;
                car.TravelledDistance += amountOfKm;

                return car;
            }
            else
            {
                Print();
                return car;
            }           
        }

        private static void Print()
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
