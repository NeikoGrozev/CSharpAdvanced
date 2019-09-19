namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int divisibleNum = int.Parse(Console.ReadLine());

            Predicate<int> divisible = number => number % divisibleNum == 0;
            Action<List<int>> print = numbres => Console.WriteLine(string.Join(" ", numbers));

            for (int i = 0; i < numbers.Count; i++)
            {
                if (divisible(numbers[i]))
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            numbers.Reverse();
            print(numbers);

        }
    }
}
