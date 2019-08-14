namespace Miner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MinerProg
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, rows];

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string> (commands);

            int allCoals = 0;
            int currentCoals = 0;
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];

                    if (symbols[col] == 'c')
                    {
                        allCoals++;
                    }

                    if (symbols[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            bool isFinish = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = queue.Dequeue();

                if (command == "left" && startCol - 1 >= 0)
                {
                    startCol--;
                }
                else if (command == "right" && startCol + 1 < matrix.GetLength(1))
                {
                    startCol++;
                }
                else if (command == "up" && startRow - 1 >= 0)
                {
                    startRow--;
                }
                else if (command == "down" && startRow + 1 < matrix.GetLength(0))
                {
                    startRow++;
                }

                if (matrix[startRow, startCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                    isFinish = true;
                    break;
                }
                else if (matrix[startRow, startCol] == 'c')
                {
                    currentCoals++;
                    matrix[startRow, startCol] = '*';

                    if (currentCoals == allCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                        isFinish = true;
                        break;
                    }
                }
            }

            if (queue.Count == 0 && !isFinish && currentCoals < allCoals)
            {
                int coalsLeft = allCoals - currentCoals;

                Console.WriteLine($"{coalsLeft} coals left. ({startRow}, {startCol})");
            }
        }        
    }
}
