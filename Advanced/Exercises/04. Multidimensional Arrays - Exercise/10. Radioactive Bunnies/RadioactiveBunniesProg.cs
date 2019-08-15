namespace RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RadioactiveBunniesProg
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

            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string symbols = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];

                    if (matrix[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            Queue<char> queue = new Queue<char>(commands);
            bool isWon = false;
            bool isDead = false;

            for (int i = 0; i < commands.Length; i++)
            {
                List<int> newVampBannies = new List<int>();

                char command = queue.Dequeue();

                if (command == 'U')
                {
                    matrix[startRow, startCol] = '.';
                    startRow--;

                    if (startRow == -1)
                    {
                        isWon = true;
                        startRow++;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (command == 'D')
                {
                    matrix[startRow, startCol] = '.';
                    startRow++;

                    if (startRow == matrix.GetLength(0))
                    {
                        isWon = true;
                        startRow--;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (command == 'L')
                {
                    matrix[startRow, startCol] = '.';
                    startCol--;

                    if (startCol == -1)
                    {
                        isWon = true;
                        startCol++;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (command == 'R')
                {
                    matrix[startRow, startCol] = '.';
                    startCol++;

                    if (startCol == matrix.GetLength(1))
                    {
                        isWon = true;
                        startCol--;
                    }
                    else if (matrix[startRow, startCol] == 'B')
                    {
                        isDead = true;
                    }
                }

                int[] vampBannies = new int[]
                {
                    -1,  0,
                     0,  1,
                     1,  0,
                     0, -1
                };

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            for (int j = 0; j < vampBannies.Length; j += 2)
                            {
                                int moveIndexRow = vampBannies[j];
                                int moveIndexCol = vampBannies[j + 1];

                                if (row + moveIndexRow >= 0 && row + moveIndexRow < matrix.GetLength(0)
                                    && col + moveIndexCol >= 0 && col + moveIndexCol < matrix.GetLength(1))
                                {
                                    if (row + moveIndexRow == startRow && col + moveIndexCol == startCol)
                                    {
                                        isDead = true;
                                    }

                                    if (matrix[row + moveIndexRow, col + moveIndexCol] == '.')
                                    {
                                        newVampBannies.Add(row + moveIndexRow);
                                        newVampBannies.Add(col + moveIndexCol);
                                    }
                                }
                            }
                        }
                    }
                }

                for (int k = 0; k < newVampBannies.Count; k += 2)
                {
                    matrix[newVampBannies[k], newVampBannies[k + 1]] = 'B';
                }

                if (isWon || isDead)
                {
                    break;
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

            if (isWon)
            {
                Console.WriteLine($"won: {startRow} {startCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {startRow} {startCol}");
            }
        }
    }
}
