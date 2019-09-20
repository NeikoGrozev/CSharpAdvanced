using System.Collections.Generic;

namespace CustomComparator
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
                       
            Predicate<int> isEven = number 
                => number % 2 == 0;
            
            foreach (var number in numbers)
            {
                if (isEven(number))
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Add(number);
                }
            }

            evenNumbers.Sort();
            oddNumbers.Sort();

            Console.Write(string.Join(" ", evenNumbers));
            Console.Write(" " + string.Join(" ", oddNumbers));
        }
    }
}
