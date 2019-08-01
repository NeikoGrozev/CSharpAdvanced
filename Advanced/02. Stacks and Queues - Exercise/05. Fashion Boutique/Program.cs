namespace FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] botique = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(botique);

            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;

            while(stack.Count != 0)
            {
                int currentClothing = stack.Pop();

                if (sum + currentClothing <= capacity)
                {
                    sum += currentClothing;
                }
                else
                {
                    counter++;
                    sum = currentClothing;
                }

                if (stack.Count == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
