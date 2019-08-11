namespace MatrixShuffling
{
    using System;
    using System.Linq;

    class MatrixShufflingProg
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] str = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = str[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] token = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool isValid = false;

                string command = token[0];

                if (command == "swap" && token.Length == 5)
                {
                    int firstRow = int.Parse(token[1]);
                    int firstCol = int.Parse(token[2]);
                    int secondRol = int.Parse(token[3]);
                    int secondCol = int.Parse(token[4]);


                    if (firstRow >= 0 && firstRow < matrix.GetLength(0)
                        && firstCol >= 0 && firstCol < matrix.GetLength(1)
                        && secondRol >= 0 && secondRol < matrix.GetLength(0)
                        && secondCol >= 0 && secondCol < matrix.GetLength(1))
                    {
                        string temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRol, secondCol];
                        matrix[secondRol, secondCol] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    isValid = true;
                }

                if (isValid)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
