namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class Stars
    {
        public static long SumOfStars(int[,] matrix)
        {
            long sum = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Let the Force be with you")
                {
                    break;
                }

                int[] ivoS = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evil = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int xE = evil[0];
                int yE = evil[1];

                while (xE >= 0 && yE >= 0)
                {
                    if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                    {
                        matrix[xE, yE] = 0;
                    }
                    xE--;
                    yE--;
                }

                int xI = ivoS[0];
                int yI = ivoS[1];

                while (xI >= 0 && yI < matrix.GetLength(1))
                {
                    if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                    {
                        sum += matrix[xI, yI];
                    }

                    xI--;
                    yI++;
                }
            }

            return sum;
        }
    }
}
