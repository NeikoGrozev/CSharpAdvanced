namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarCreator
    {
        public List<Car> Creat(int count, List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                string engineModel = parameters[1];

                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                int weight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    cars.Add(new Car(model, engine, weight));
                }
                else if (parameters.Length == 3)
                {
                    string color = parameters[2];
                    cars.Add(new Car(model, engine, color));
                }
                else if (parameters.Length == 4)
                {
                    string color = parameters[3];
                    cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }

            return cars;
        }
    }
}
