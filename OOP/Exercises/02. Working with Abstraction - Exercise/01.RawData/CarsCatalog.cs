namespace RawData
{
    using Data;
    using DataCar;
    using DataCargo;
    using DataEngine;
    using DataTire;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsCatalog
    {
        private EngineFactory engineFactory;
        private CargoFactory cargoFactory;
        private TireFactory tireFactory;
        private CarFactory carFactory;
        private ConsoleWriter dataWrite;

        public CarsCatalog(EngineFactory engineFactory, 
            CargoFactory cargoFactory, 
            TireFactory tireFactory,
            CarFactory carFactory)
        {
            this.Cars = new List<Car>();
            this.engineFactory = engineFactory;
            this.cargoFactory = cargoFactory;
            this.tireFactory = tireFactory;
            this.carFactory = carFactory;
            this.dataWrite = new ConsoleWriter();
        }

        public List<Car> Cars { get; private set; }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            Engine engine = engineFactory.Create(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Cargo cargo = cargoFactory.Create(cargoWeight, cargoType);

            Tire[] tires = GetTire(parameters.Skip(5).ToArray());

            Car car = carFactory.Create(model, engine, cargo, tires);

            this.Cars.Add(car);
        }

        private Tire[] GetTire(string[] parameters)
        {
            Tire[] tires = new Tire[4];

            int counterIndexTires = 0;

            for (int j = 0; j <= 7; j += 2)
            {
                double pressure = double.Parse(parameters[j]);
                int age = int.Parse(parameters[j + 1]);
                Tire tire = tireFactory.Create(pressure, age);

                tires[counterIndexTires] = tire;

                counterIndexTires++;
            }

            return tires;
        }

        public void GetCarsInfo(string command)
        {
            List<string> result = null;

            if (command == "fragile")
            {
                result = this.Cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();                
            }
            else
            {
                result = this.Cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();
            }

            dataWrite.Write(string.Join(Environment.NewLine, result));
        }
    }
}
