namespace CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] inputEngine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = inputEngine[0];
                string power = inputEngine[1];

                if (inputEngine.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (inputEngine.Length == 3)
                {
                    string temp = inputEngine[2];

                    int currentDisplacement;
                    bool isTrue = int.TryParse(temp, out currentDisplacement);

                    if (isTrue)
                    {
                        Engine engine = new Engine(model, power, currentDisplacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine(model, power, temp);
                        engines.Add(engine);
                    }
                }
                else if (inputEngine.Length == 4)
                {
                    string displacement = inputEngine[2];
                    string efficiency = inputEngine[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
            }

            List<Car> cars = new List<Car>();

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] inputCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = inputCar[0];
                string engine = inputCar[1];

                Engine currentEngine = null;

                foreach (var item in engines)
                {
                    if (item.Model == engine)
                    {
                        currentEngine = item;
                        break;
                    }
                }

                if (inputCar.Length == 2)
                {
                    Car car = new Car(model, currentEngine);
                    cars.Add(car);
                }
                else if (inputCar.Length == 3)
                {
                    string temp = inputCar[2];

                    int currentWeigth;
                    bool isTrue = int.TryParse(temp, out currentWeigth);

                    if (isTrue)
                    {
                        Car car = new Car(model, currentEngine, currentWeigth);
                        cars.Add(car);
                    }
                    else
                    {
                        Car car = new Car(model, currentEngine, temp);
                        cars.Add(car);
                    }
                }
                else if (inputCar.Length == 4)
                {
                    string weigth = inputCar[2];
                    string color = inputCar[3];

                    Car car = new Car(model, currentEngine, weigth, color);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}

