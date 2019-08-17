namespace EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < num; i++)
            {
                int digit = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(digit))
                {
                    dict.Add(digit, 0);
                }

                dict[digit]++;
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
