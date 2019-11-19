namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }
        
        string Drive(int distance);

        string Refuel(int liters);
    }
}