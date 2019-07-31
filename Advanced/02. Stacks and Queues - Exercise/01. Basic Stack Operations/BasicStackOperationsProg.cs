namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicStackOperationsProg
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int arrayLength = input[0];
            int counter = input[1];
            int digit = input[2];

            int[] numbersCollection = new int[arrayLength];
            numbersCollection = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbersCollection);

            for (int i = 0; i < counter; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (stack.Contains(digit))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minDigit = stack.Min();
                Console.WriteLine($"{minDigit}");
            }
        }
    }
}
