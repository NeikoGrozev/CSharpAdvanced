namespace PrimaryDiagonal
{
    using System;
    using System.Linq;

    class PrimaryDiagonalProg
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, rows];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] digits = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = digits[col];

                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
