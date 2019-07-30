namespace StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StackSumProg
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(array);

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0].ToLower();

                if (command == "end")
                {
                    break;
                }
                else if (command == "add")
                {
                    int firstDigit = int.Parse(input[1]);
                    int secondDigit = int.Parse(input[2]);

                    stack.Push(firstDigit);
                    stack.Push(secondDigit);
                }
                else if (command == "remove")
                {
                    int removeDigit = int.Parse(input[1]);

                    if (stack.Count > removeDigit)
                    {
                        for (int i = 0; i < removeDigit; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
