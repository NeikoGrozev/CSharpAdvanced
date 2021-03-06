﻿namespace SnakeMoves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[] word = Console.ReadLine()
                .ToCharArray();

            Queue<char> queue = new Queue<char>(word);
          
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentSymbol = queue.Dequeue();
                    queue.Enqueue(currentSymbol);


                    if (row % 2 == 0)
                    {
                        matrix[row, col] = currentSymbol;
                    }
                    else
                    {
                        matrix[row, cols - col - 1] = currentSymbol;
                    }
                    
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }

        }
    }
}
