namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double addiitionalSummerConsumtion = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double distance)
        {
            double needFuel = distance * (this.FuelConsumption + addiitionalSummerConsumtion);

            if (this.FuelQuantity >= needFuel)
            {
                this.FuelQuantity -= needFuel;
                return $"Truck travelled {distance} km";
            }

            return "Truck needs refueling";
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}