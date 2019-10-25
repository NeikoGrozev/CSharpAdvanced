namespace SpaceStationEstablishment
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int neededStars = 50;

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int stars = 0;
            int stephenRow = -1;
            int stephenCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        stephenRow = row;
                        stephenCol = col;
                    }
                }
            }

            matrix[stephenRow, stephenCol] = '-';

            bool isWin = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    stephenRow--;
                }
                else if (command == "down")
                {
                    stephenRow++;
                }
                else if (command == "left")
                {
                    stephenCol--;
                }
                else if (command == "right")
                {
                    stephenCol++;
                }                               

                if (stephenRow < 0 || stephenRow >= matrix.GetLength(0)
                    || stephenCol < 0 || stephenCol >= matrix.GetLength(1))
                {
                    break;
                }   
                else if (matrix[stephenRow, stephenCol] == 'O')
                {
                    matrix[stephenRow, stephenCol] = '-';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        bool isFound = false;

                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                stephenRow = row;
                                stephenCol = col;
                                matrix[stephenRow, stephenCol] = '-';
                                isFound = true;
                                break;
                            }
                        }

                        if (isFound)
                        {
                            break;
                        }
                    }
                }
                else if (int.TryParse(matrix[stephenRow, stephenCol].ToString(), out int result))
                {
                    stars += result;
                    matrix[stephenRow, stephenCol] = '-';
                }

                if (stars >= neededStars)
                {
                    isWin = true;
                    matrix[stephenRow, stephenCol] = 'S';
                    break;
                }
            }

            if(isWin)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }

            Console.WriteLine($"Star power collected: {stars}");

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
