namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<KeyValuePair<string, int>> peoples = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ");

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                peoples.Add(new KeyValuePair<string, int>(name, age));
            }

            string condition = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            peoples = peoples
                .Where(x => condition == "younger" ? x.Value < filterAge : x.Value >= filterAge)
                .ToList();

            foreach (var item in peoples)
            {
                Print(item.Key, item.Value, format);
            }          
        }

        private static void Print(string key, int value, string format)
        {
            if (format == "name age")
            {
                Console.WriteLine($"{key} - {value}");
            }
            else if (format == "name")
            {
                Console.WriteLine($"{key}");
            }
            else
            {
                Console.WriteLine($"{value}");
            }
        }
    }
}
