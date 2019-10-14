namespace Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var custumStack = new CustomStack<int>();

            while (true)
            {
                List<string> input = Console.ReadLine()
                    .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = input[0];

                if (command == "END")
                {
                    break;
                }
                else if (command == "Push")
                {
                    input.RemoveAt(0);

                    int[] numbers = input
                          .Select(int.Parse)
                          .ToArray();

                    custumStack.Push(numbers);
                }
                else if (command == "Pop")
                {
                    custumStack.Pop();
                }
            }

            foreach (var item in custumStack)
            {
                Console.WriteLine($"{item}");
            }

            foreach (var item in custumStack)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
