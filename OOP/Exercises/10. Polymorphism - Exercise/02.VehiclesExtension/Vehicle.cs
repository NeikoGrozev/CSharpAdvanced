namespace VehiclesExtension
{
    using System;

    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;


        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set
            {
                if (value > 0)
                {
                    this.fuelConsumption = value;
                }
            }
        }

        public double TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            double needFuel = distance * this.FuelConsumption;

            if (this.FuelQuantity >= needFuel)
            {
                this.FuelQuantity -= needFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            else if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }

            if (this is Truck)
            {
                fuel *= 0.95;
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}