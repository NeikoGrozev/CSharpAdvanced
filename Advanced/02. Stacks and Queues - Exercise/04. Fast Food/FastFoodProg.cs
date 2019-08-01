namespace FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class FastFoodProg
    {
        static void Main()
        {
            int food = int.Parse(Console.ReadLine());

            int[] ordersQuantity = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(ordersQuantity);

            int maxOrder = queue.Max();
            bool isValid = true;

            while (queue.Count != 0)
            {
                int currentOrder = queue.Peek();

                if (food - currentOrder >= 0)
                {
                    food -= currentOrder;
                    queue.Dequeue();                    
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            Console.WriteLine(maxOrder);

            if (isValid)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
