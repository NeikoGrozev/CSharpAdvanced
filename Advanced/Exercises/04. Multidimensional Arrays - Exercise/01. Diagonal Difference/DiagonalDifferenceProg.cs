namespace DiagonalDifference
{
    using System;
    using System.Linq;

    class DiagonalDifferenceProg
    {
        static void Main()
        {
            int numOfRows = int.Parse(Console.ReadLine());

            int[,] matrix = new int[numOfRows, numOfRows];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] digits = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = digits[col];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        primaryDiagonalSum += matrix[row, col];
                    }

                    if (row + col == matrix.GetLength(0) - 1)
                    {
                        secondaryDiagonalSum += matrix[row, col];
                    }
                }
            }

            int diff = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(diff);
        }
    }
}
