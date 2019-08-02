namespace CupsAndBottles
{
    using System;  
    using System.Collections.Generic;
    using System.Linq;

    class CupsAndBottlesProg
    {
        static void Main()
        {
            int[] cups = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int[] bottles = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(cups);
            Stack<int> stack = new Stack<int>(bottles);
            int wastedWater = 0;

            while (queue.Count > 0 && stack.Count > 0)
            {
                int cup = queue.Peek();
                int bottle = stack.Peek();

                if (bottle - cup >= 0)
                {
                    wastedWater += bottle - cup;
                    queue.Dequeue();
                    stack.Pop();
                }
                else
                {
                    cup -= bottle;
                    stack.Pop();

                    while (cup > 0)
                    {
                        bottle = stack.Peek();

                        if (bottle - cup >= 0)
                        {
                            wastedWater += bottle - cup;
                            cup -= bottle;
                            queue.Dequeue();
                            stack.Pop();
                        }
                        else
                        {
                            cup -= bottle;
                            stack.Pop();
                        }
                    }
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stack)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queue)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
