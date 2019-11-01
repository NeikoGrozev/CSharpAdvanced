namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class Runner
    {
        public static void Run()
        {
            int[,] matrix = CreateMatrix();

            long sum = Stars.SumOfStars(matrix);

            Console.WriteLine(sum);
        }

        private static int[,] CreateMatrix()
        {
            int[] dimestions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }
    }
}
