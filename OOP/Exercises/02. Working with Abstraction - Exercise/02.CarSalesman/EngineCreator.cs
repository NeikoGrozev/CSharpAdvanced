namespace CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class EngineCreator
    {
        public List<Engine> Creat(int count)
        {
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < count; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                int displacement = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
                {
                    engines.Add(new Engine(model, power, displacement));
                }
                else if (parameters.Length == 3)
                {
                    string efficiency = parameters[2];
                    engines.Add(new Engine(model, power, efficiency));
                }
                else if (parameters.Length == 4)
                {
                    string efficiency = parameters[3];
                    engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }

            return engines;
        }
    }
}
