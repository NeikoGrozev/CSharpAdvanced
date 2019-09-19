namespace FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string evenOrOdd = Console.ReadLine();

            int lowerRange = range[0];
            int upperRange = range[1];

            List<int> numbers = new List<int>();

            for (int i = lowerRange; i <= upperRange; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = number => number % 2 == 0;
            Predicate<int> isOdd = number => number % 2 != 0;

            Action<List<int>> printNumbers = number => Console.WriteLine(string.Join(" ", numbers));

            if (evenOrOdd == "even")
            {
                numbers = numbers.Where(x => isEven(x))
                    .ToList();
            }
            else if(evenOrOdd == "odd")
            {
                numbers = numbers.Where(x => isOdd(x))
                    .ToList();
            }

            printNumbers(numbers);
        }
    }
}
