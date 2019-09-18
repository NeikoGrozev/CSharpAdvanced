namespace SongsQueue
{
    using System;
    using System.Collections.Generic;
    
    class StartUp
    {
        static void Main()
        {
            string[] allSongs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queue = new Queue<string>(allSongs);

            while (true)
            {
                string command = Console.ReadLine();

                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command.StartsWith("Add "))
                {
                    string song = command.Remove(0, 4);
                    
                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show" || queue.Count > 0)
                {
                    Console.Write(string.Join(", ", queue));
                    Console.WriteLine();
                }
            }
        }
    }
}
