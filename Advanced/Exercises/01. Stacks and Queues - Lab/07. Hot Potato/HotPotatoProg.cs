namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    class HotPotatoProg
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int num = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(input);
            int count = 0;

            while (queue.Count != 1)
            {
                count++;

                if (count % num == 0)
                {
                    string removeChild = queue.Dequeue();
                    Console.WriteLine($"Removed {removeChild}");
                    continue;
                }

                string currentChild = queue.Dequeue();
                queue.Enqueue(currentChild);
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
