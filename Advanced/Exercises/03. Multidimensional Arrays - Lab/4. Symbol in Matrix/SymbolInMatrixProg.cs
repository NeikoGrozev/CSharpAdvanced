namespace SymbolInMatrix
{
using System;

    class SymbolInMatrixProg
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, rows];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }                    
            }

            char findSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == findSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{findSymbol} does not occur in the matrix");
        }
    }
}
