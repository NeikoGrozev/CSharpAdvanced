namespace PascalTriangle
{
    using System;

    class PascalTriangleProg
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rows][];

            jaggedArray[0] = new long[] { 1 };

            if (rows > 1)
            {
                jaggedArray[1] = new long[] { 1, 1 };
            }

            if (rows > 2)
            {
                for (int row = 2; row < rows; row++)
                {
                    jaggedArray[row] = new long[row + 1];

                    jaggedArray[row][0] = 1;
                    jaggedArray[row][jaggedArray[row].Length - 1] = 1;

                    for (int col = 1; col < jaggedArray[row].Length - 1; col++)
                    {
                        jaggedArray[row][col] = jaggedArray[row - 1][col] + jaggedArray[row - 1][col - 1];
                    }
                }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
