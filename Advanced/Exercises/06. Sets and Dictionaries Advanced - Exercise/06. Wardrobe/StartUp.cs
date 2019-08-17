namespace Wardrobe
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] str = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = str[0];
                string[] clothes = str[1]
                    .Split(",");


                if (!dict.ContainsKey(color))
                {
                    dict.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!dict[color].ContainsKey(clothes[j]))
                    {
                        dict[color].Add(clothes[j], 0);
                    }

                    dict[color][clothes[j]]++;
                }
            }

            string[] find = Console.ReadLine()
                .Split(" ");

            string findColor = find[0];
            string findClothe = find[1];

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key} clothes:");

                foreach (var item in value)
                {
                    if (key == findColor && item.Key == findClothe)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
