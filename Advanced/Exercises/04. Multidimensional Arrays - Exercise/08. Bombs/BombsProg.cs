namespace Bombs
{
    using System;
    using System.Linq;

    class BombsProg
    {
        static void Main()
        {
            int rowsOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsOfMatrix, rowsOfMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] digit = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = digit[col];
                }
            }

            string[] bombCell = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[] neighbourCells = new int[]
                {
                    -1, -1,
                    -1,  0,
                    -1,  1,
                     0,  1,
                     1,  1,
                     1,  0,
                     1, -1,
                     0, -1,

                };

            for (int i = 0; i < bombCell.Length; i++)
            {
                int[] currentBomb = bombCell[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = currentBomb[0];
                int bombCol = currentBomb[1];
                int bombNumber = matrix[bombRow, bombCol];

                if (bombNumber > 0)
                {
                    for (int j = 0; j < neighbourCells.Length; j += 2)
                    {
                        int currentBombRow = bombRow + neighbourCells[j];
                        int currentBombCol = bombCol + neighbourCells[j + 1];

                        if (currentBombRow >= 0 && currentBombRow < matrix.GetLength(0)
                            && currentBombCol >= 0 && currentBombCol < matrix.GetLength(1))
                        {
                            if (matrix[currentBombRow, currentBombCol] > 0)
                            {
                                int temp = matrix[currentBombRow, currentBombCol];
                                matrix[currentBombRow, currentBombCol] = temp - bombNumber;
                            }
                        }
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }
            int activeCell = 0;
            int sum = 0;

            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    activeCell++;
                    sum += item;
                }
            }

            Console.WriteLine($"Alive cells: {activeCell}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
