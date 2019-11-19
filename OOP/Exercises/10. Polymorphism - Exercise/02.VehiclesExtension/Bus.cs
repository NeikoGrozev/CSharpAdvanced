namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private double addiitionalSummerConsumtion = 1.4;
        private double currentBusConsumption;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.currentBusConsumption = fuelConsumption;
            this.addiitionalSummerConsumtion += fuelConsumption;
        }

        public bool IsEmpty { get; set; }

        public override string Drive(double distance)
        {
            if(this.IsEmpty)
            {
                this.FuelConsumption = currentBusConsumption;
            }
            else
            {
                this.FuelConsumption = addiitionalSummerConsumtion;
            }

            return base.Drive(distance);
        }
    }
}