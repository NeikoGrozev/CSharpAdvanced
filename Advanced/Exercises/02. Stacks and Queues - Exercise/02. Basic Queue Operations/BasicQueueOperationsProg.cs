namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperationsProg
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

            Queue<int> queue = new Queue<int>(numbersCollection);

            for (int i = 0; i < counter; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(digit))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minDigit = queue.Min();
                Console.WriteLine($"{minDigit}");
            }
        }
    }
}
