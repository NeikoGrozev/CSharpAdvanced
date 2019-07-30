namespace PrintEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrintEvenNumbersProg
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    queue.Enqueue(input[i]);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
