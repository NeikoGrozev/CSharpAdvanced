namespace TrafficJam
{
    using System;
    using System.Collections.Generic;

    class TrafficJamProg
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            int countCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                else if (input == "green")
                {
                    for (int i = 0; i < num; i++)
                    {
                        if (queue.Count > 0)
                        {
                            string carName = queue.Dequeue();
                            Console.WriteLine($"{carName} passed!");
                            countCars++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine($"{countCars} cars passed the crossroads.");
        }
    }
}
