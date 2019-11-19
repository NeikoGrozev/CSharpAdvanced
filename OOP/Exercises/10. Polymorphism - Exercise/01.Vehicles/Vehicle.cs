namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;


        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            private set
            {
                this.fuelConsumption = value;
            }
        }
        
        public virtual string Drive(double distance)
        {
            return "";
        }

        public virtual void Refuel(double liters)
        {
        }    
    }
}