namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KeyRevolverProg
    {
        static void Main()
        {
            int priceOfOneBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(bullets);
            Queue<int> queue = new Queue<int>(locks);
            int countBarrel = 0;
            int countBullets = 0;

            while (stack.Count > 0 && queue.Count > 0)
            {
                int bullet = stack.Peek();
                int currentLock = queue.Peek();

                if (currentLock >= bullet)
                {
                    countBarrel++;
                    countBullets++;
                    stack.Pop();
                    queue.Dequeue();

                    Console.WriteLine("Bang!");
                }
                else
                {
                    countBarrel++;
                    countBullets++;
                    stack.Pop();

                    Console.WriteLine("Ping!");
                }

                if (countBarrel % sizeOfGunBarrel == 0 && stack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (queue.Count == 0)
            {
                int sumOfBullets = countBullets * priceOfOneBullet;
                int diff = valueOfIntelligence - sumOfBullets;

                Console.WriteLine($"{stack.Count} bullets left. Earned ${diff}");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queue.Count}");
            }
        }
    }
}
