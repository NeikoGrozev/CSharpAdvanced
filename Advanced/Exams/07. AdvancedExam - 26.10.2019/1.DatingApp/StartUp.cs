namespace DatingApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] malesInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int[] femalesInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            Stack<int> man = new Stack<int>(malesInput);
            Queue<int> woman = new Queue<int>(femalesInput);

            int matches = 0;

            while (man.Count > 0 && woman.Count > 0)
            {
                int currentMan = man.Peek();
                int currentWonam = woman.Peek();

                if (currentMan <= 0)
                {
                    man.Pop();
                    continue;
                }
                else if(currentWonam <= 0)
                {
                    woman.Dequeue();
                    continue;
                }

                if(currentMan % 25 == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if(man.Count > 0)
                        {
                            man.Pop();
                        }
                    }

                    continue;
                }
                else if(currentWonam % 25 == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (woman.Count > 0)
                        {
                            woman.Dequeue();
                        }
                    }

                    continue;
                }

                if(currentMan == currentWonam)
                {
                    matches++;
                    man.Pop();
                    woman.Dequeue();
                }
                else if(currentMan != currentWonam)
                {
                    woman.Dequeue();
                    man.Pop();
                    man.Push(currentMan - 2);
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if(man.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", man)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if(woman.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", woman)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
