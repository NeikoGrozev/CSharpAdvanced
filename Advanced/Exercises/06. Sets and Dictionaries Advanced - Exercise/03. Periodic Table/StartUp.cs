namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < array.Length; j++)
                {
                    if (!set.Contains(array[j]))
                    {
                        set.Add(array[j]);
                    }
                }
            }

            foreach (var item in set.OrderBy(x => x))
            {
                Console.Write($"{item} ");
            }
        }
    }
}
