namespace BombTheBasement
{
    using System;
    using System.Linq;

    class BombTheBasementProg
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] parameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowsMatrix = dimensions[0];
            int colsMatrix = dimensions[1];
            int[,] matrix = new int[rowsMatrix, colsMatrix];

            int currentRowBomb = parameters[0];
            int currentColBomb = parameters[1];
            int radius = parameters[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isInRadius = Math.Pow(row - currentRowBomb, 2) + Math.Pow(col - currentColBomb, 2) <=
                        Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        counter++;
                        matrix[row, col] = 0;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row, col] = 1;
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
