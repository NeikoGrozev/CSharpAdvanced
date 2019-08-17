namespace CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            char[] symbol = Console.ReadLine()
                .ToCharArray();

            for (int i = 0; i < symbol.Length; i++)
            {
                if (!dict.ContainsKey(symbol[i]))
                {
                    dict.Add(symbol[i], 0);
                }

                dict[symbol[i]]++;

            }

            foreach (var item in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
