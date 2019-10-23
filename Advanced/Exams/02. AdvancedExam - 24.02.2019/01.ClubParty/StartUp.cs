namespace ClubParty
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine()
                .Split();

            Stack<string> stack = new Stack<string>(input);
            Queue<string> halls = new Queue<string>();
            List<int> groups = new List<int>();

            int currentCapacity = 0;

            while (true)
            {
                if(stack.Count == 0)
                {
                    break;
                }

                string element = stack.Pop();

                bool isNumber = int.TryParse(element, out int resilt);

                if(!isNumber)
                {
                    halls.Enqueue(element);
                }
                else
                {
                    if(halls.Count == 0)
                    {
                        continue;
                    }
                    else if(currentCapacity + resilt > hallCapacity)
                    {
                        string hall = halls.Dequeue();
                        Console.WriteLine($"{hall} -> {string.Join(", ", groups)}");
                        groups.Clear();
                        currentCapacity = 0;
                    }

                    if(halls.Count > 0)
                    {
                        groups.Add(resilt);
                        currentCapacity += resilt;
                    }
                }
            }
        }
    }
}
