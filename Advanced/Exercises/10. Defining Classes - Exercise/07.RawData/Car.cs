namespace RawData
{
    public class Car
    {
        public Car()
        {
            this.Model = string.Empty;
            this.Engine = null;
            this.Cargo = null;
            this.Tire = null;
        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tire;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tire { get; set; }
    }
}
