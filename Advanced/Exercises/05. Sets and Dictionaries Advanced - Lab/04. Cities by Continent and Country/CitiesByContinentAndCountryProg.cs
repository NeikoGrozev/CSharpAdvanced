namespace CitiesByContinentAndCountry
{
    using System;
    using System.Collections.Generic;

    class CitiesByContinentAndCountryProg
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < num; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!dict.ContainsKey(continent))
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                    dict[continent].Add(country, new List<string>());
                    dict[continent][country].Add(city);
                }
                else
                {
                    if (!dict[continent].ContainsKey(country))
                    {
                        dict[continent].Add(country, new List<string>());
                    }

                    dict[continent][country].Add(city);
                }
            }

            foreach (var continent in dict)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var item in continent.Value)
                {
                    Console.WriteLine($"    {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
