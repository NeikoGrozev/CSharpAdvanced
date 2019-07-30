namespace Supermarket
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class SupermarketProg
    {
        static void Main()
        {
            Queue<string> queuePaid = new Queue<string>();
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else if (input == "Paid")
                {
                    int count = queue.Count;

                    for (int i = 0; i < count; i++)
                    {
                        string name = queue.Dequeue();
                        queuePaid.Enqueue(name);
                    }

                    continue;
                }

                queue.Enqueue(input);
            }
            if (queuePaid.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, queuePaid));
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
