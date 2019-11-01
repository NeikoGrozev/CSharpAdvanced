namespace RawData.DataCar
{
    using DataCargo;
    using DataTire;
    using DataEngine;

    public class CarFactory
    {
        public Car Create(string model,Engine engine, Cargo cargo,Tire[] tires)
        {
            return new Car(model, engine, cargo, tires);
        }
    }
}
