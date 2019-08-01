namespace MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumAndMinimumElementProg
    {
        static void Main()
        {
            int counter = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < counter; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                int command = input[0];

                if (command == 1)
                {
                    int digit = input[1];
                    stack.Push(digit);
                }
                else if (command == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (command == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());

                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
