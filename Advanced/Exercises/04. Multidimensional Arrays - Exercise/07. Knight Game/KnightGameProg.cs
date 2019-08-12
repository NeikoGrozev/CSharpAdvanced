namespace KnightGame
{
    using System;
    using System.Linq;

    class KnightGameProg
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, rows];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] newLine = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = newLine[col];
                }
            }

            int[] LPattern = new int[] {
                 1,  2,
                 1, -2,
                 2,  1,
                 2, -1,
                -1,  2,
                -1, -2,
                -2,  1,
                -2, -1,
            };

            int count = 0;

            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxKnight = 0;


                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currentKnight = 0;

                        if (matrix[row, col] == 'K')
                        {
                            for (int i = 0; i < LPattern.Length; i += 2)
                            {
                                if (IsInside(matrix, row + LPattern[i], col + LPattern[i + 1])
                                    && matrix[row + LPattern[i], col + LPattern[i + 1]] == 'K')
                                {
                                    currentKnight++;

                                }
                            }
                        }

                        if (currentKnight > maxKnight)
                        {
                            maxKnight = currentKnight;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxKnight == 0)
                {
                    break;
                }

                matrix[knightRow, knightCol] = '0';
                count++;

            }

            Console.WriteLine(count);
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            bool isTrue = row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);

            return isTrue;
        }
    }
}
