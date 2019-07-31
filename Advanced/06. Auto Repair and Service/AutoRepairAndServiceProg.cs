namespace AutoRepairAndService
{
    using System;
    using System.Collections.Generic;

    class AutoRepairAndServiceProg
    {
        static void Main()
        {
            string[] tracks = Console.ReadLine()
                .Split(" ");

            Queue<string> queue = new Queue<string>(tracks);
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] token = input
                    .Split("-");

                string command = token[0];

                if (command == "Service" && queue.Count > 0)
                {
                    string track = queue.Dequeue();
                    stack.Push(track);
                    Console.WriteLine($"Vehicle {track} got served.");
                }
                else if (command == "CarInfo")
                {
                    string currentTrack = token[1];

                    if (queue.Contains(currentTrack))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else if (stack.Contains(currentTrack))
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", stack));
                }
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", queue)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", stack)}");
        }
    }
}
