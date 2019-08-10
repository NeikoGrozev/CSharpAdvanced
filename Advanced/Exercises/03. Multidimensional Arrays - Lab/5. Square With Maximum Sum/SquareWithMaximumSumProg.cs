namespace SquareWithMaximumSum
{
using System;
    using System.Linq;

    class SquareWithMaximumSumProg
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] digits = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = digits[col];
                }
            }

            int maxSum = int.MinValue;
            int startIndexRow = -1;
            int startIndexCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                int sum = 0;

                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startIndexRow = row;
                        startIndexCol = col;
                    }
                }
            }

            for (int row = startIndexRow; row <= startIndexRow + 1; row++)
            {
                for (int col = startIndexCol; col <= startIndexCol + 1; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
