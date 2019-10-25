namespace SeashellTreasure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[][] seashells = new char[n][];

            for (int row = 0; row < seashells.Length; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                seashells[row] = new char[input.Length];

                for (int col = 0; col < seashells[row].Length; col++)
                {
                    seashells[row][col] = input[col];
                }
            }

            Queue<char> collectedSeashells = new Queue<char>();
            int stolenSeashells = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sunset")
                {
                    break;
                }

                string[] commandInfo = input
                    .Split();

                string command = commandInfo[0];
                int moveRow = int.Parse(commandInfo[1]);
                int moveCol = int.Parse(commandInfo[2]);

                if (moveRow < 0 || moveRow >= seashells.Length
                    || moveCol < 0 || moveCol >= seashells[moveRow].Length)
                {
                    continue;
                }

                if (command == "Collect")
                {
                    if (seashells[moveRow][moveCol] != '-')
                    {
                        collectedSeashells.Enqueue(seashells[moveRow][moveCol]);
                        seashells[moveRow][moveCol] = '-';
                    }
                }
                else if (command == "Steal")
                {
                    string directions = commandInfo[3];

                    if (directions == "up")
                    {
                        for (int row = moveRow; row >= moveRow - 3; row--)
                        {
                            for (int col = moveCol; col <= moveCol; col++)
                            {
                                if (row >= 0 && row < seashells.Length
                                    && col >= 0 && col < seashells[row].Length)
                                {
                                    if (seashells[row][col] != '-')
                                    {
                                        stolenSeashells++;
                                        seashells[row][col] = '-';
                                    }
                                }
                            }
                        }
                    }
                    else if (directions == "down")
                    {
                        for (int row = moveRow; row <= moveRow + 3; row++)
                        {
                            for (int col = moveCol; col <= moveCol; col++)
                            {
                                if (row >= 0 && row < seashells.Length
                                    && col >= 0 && col < seashells[row].Length)
                                {
                                    if (seashells[row][col] != '-')
                                    {
                                        stolenSeashells++;
                                        seashells[row][col] = '-';
                                    }
                                }
                            }
                        }
                    }
                    else if (directions == "left")
                    {
                        for (int row = moveRow; row <= moveRow; row++)
                        {
                            for (int col = moveCol; col >= moveCol - 3; col--)
                            {
                                if (row >= 0 && row < seashells.Length
                                    && col >= 0 && col < seashells[row].Length)
                                {
                                    if (seashells[row][col] != '-')
                                    {
                                        stolenSeashells++;
                                        seashells[row][col] = '-';
                                    }
                                }
                            }
                        }
                    }
                    else if (directions == "right")
                    {
                        for (int row = moveRow; row <= moveRow; row++)
                        {
                            for (int col = moveCol; col <= moveCol + 3; col++)
                            {
                                if (row >= 0 && row < seashells.Length
                                    && col >= 0 && col < seashells[row].Length)
                                {
                                    if (seashells[row][col] != '-')
                                    {
                                        stolenSeashells++;
                                        seashells[row][col] = '-';
                                    }
                                }
                            }
                        }
                    }

                }
            }

            for (int row = 0; row < seashells.Length; row++)
            {
                Console.WriteLine(string.Join(" ", seashells[row]));
            }

            if (collectedSeashells.Count > 0)
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count} -> {string.Join(", ", collectedSeashells)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count}");
            }

            Console.WriteLine($"Stolen seashells: {stolenSeashells}");
        }
    }
}
