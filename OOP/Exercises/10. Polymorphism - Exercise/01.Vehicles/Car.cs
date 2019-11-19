namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double addiitionalSummerConsumtion = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double distance)
        {
            double needFuel = distance * (this.FuelConsumption + addiitionalSummerConsumtion);

            if(this.FuelQuantity >= needFuel)
            {
                this.FuelQuantity -= needFuel;
                return $"Car travelled {distance} km";
            }

            return "Car needs refueling";
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}