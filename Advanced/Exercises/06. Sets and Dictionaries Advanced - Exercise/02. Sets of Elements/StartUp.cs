namespace SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] num = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int numbersOfFirstSet = num[0];
            int numbersOfSecondSet = num[1];

            for (int i = 0; i < numbersOfFirstSet; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < numbersOfSecondSet; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));

            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
