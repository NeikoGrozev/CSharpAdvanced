﻿namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    class SquaresInMatrixProg
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if ((matrix[row, col] == matrix[row, col + 1])
                        && (matrix[row, col] == matrix[row + 1, col])
                        && (matrix[row, col] == matrix[row + 1, col + 1]))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
