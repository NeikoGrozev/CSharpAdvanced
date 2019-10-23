namespace TronRacers
{
    using System;

    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            int[] firstPlayer = new int[2];
            int[] secondPlayer = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col].ToString();

                    if (matrix[row, col] == "f")
                    {
                        firstPlayer[0] = row;
                        firstPlayer[1] = col;
                    }
                    else if (matrix[row, col] == "s")
                    {
                        secondPlayer[0] = row;
                        secondPlayer[1] = col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split();

                string firstPlayerCommand = commands[0];
                string secondPlayerCommand = commands[1];

                if (firstPlayerCommand == "up")
                {
                    if (firstPlayer[0] - 1 < 0)
                    {
                        firstPlayer[0] = matrix.GetLength(0) - 1;
                    }
                    else
                    {
                        firstPlayer[0] -= 1;
                    }
                }
                else if (firstPlayerCommand == "right")
                {
                    if (firstPlayer[1] + 1 > matrix.GetLength(1) - 1)
                    {
                        firstPlayer[1] = 0;
                    }
                    else
                    {
                        firstPlayer[1] += 1;
                    }
                }
                else if (firstPlayerCommand == "down")
                {
                    if (firstPlayer[0] + 1 > matrix.GetLength(0) - 1)
                    {
                        firstPlayer[0] = 0;
                    }
                    else
                    {
                        firstPlayer[0] += 1;
                    }
                }
                else if (firstPlayerCommand == "left")
                {
                    if (firstPlayer[1] - 1 < 0)
                    {
                        firstPlayer[1] = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        firstPlayer[1] -= 1;
                    }
                }

                if (KillFirstPlayer(matrix, firstPlayer[0], firstPlayer[1]))
                {
                    matrix[firstPlayer[0], firstPlayer[1]] = "x";
                    break;
                }

                matrix[firstPlayer[0], firstPlayer[1]] = "f";


                if (secondPlayerCommand == "up")
                {
                    if (secondPlayer[0] - 1 < 0)
                    {
                        secondPlayer[0] = matrix.GetLength(0) - 1;
                    }
                    else
                    {
                        secondPlayer[0] -= 1;
                    }
                }
                else if (secondPlayerCommand == "right")
                {
                    if (secondPlayer[1] + 1 > matrix.GetLength(1) - 1)
                    {
                        secondPlayer[1] = 0;
                    }
                    else
                    {
                        secondPlayer[1] += 1;
                    }
                }
                else if (secondPlayerCommand == "down")
                {
                    if (secondPlayer[0] + 1 > matrix.GetLength(0) - 1)
                    {
                        secondPlayer[0] = 0;
                    }
                    else
                    {
                        secondPlayer[0] += 1;
                    }
                }
                else if (secondPlayerCommand == "left")
                {
                    if (secondPlayer[1] - 1 < 0)
                    {
                        secondPlayer[1] = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        secondPlayer[1] -= 1;
                    }
                }

                if (KillSecondPlayer(matrix, secondPlayer[0], secondPlayer[1]))
                {
                    matrix[secondPlayer[0], secondPlayer[1]] = "x";
                    break;
                }

                matrix[secondPlayer[0], secondPlayer[1]] = "s";
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool KillFirstPlayer(string[,] matrix, int row, int col)
        {
            if (matrix[row, col] == "s")
            {
                return true;
            }

            return false;
        }

        private static bool KillSecondPlayer(string[,] matrix, int row, int col)
        {
            if (matrix[row, col] == "f")
            {
                return true;
            }

            return false;
        }
    }
}
