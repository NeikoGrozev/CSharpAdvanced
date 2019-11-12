namespace BookWorm
{
    using System;

    class StartUp
    {
        static void Main()
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    matrix[playerRow, playerCol] = 'P';
                    break;
                }

                if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }
                else if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }

                if (playerRow < 0 || playerRow >= matrix.GetLength(0)
                    || playerCol < 0 || playerCol >= matrix.GetLength(1))
                {
                    word = word.Remove(word.Length - 1);

                    if (command == "up")
                    {
                        playerRow++;
                    }
                    else if (command == "down")
                    {
                        playerRow--;
                    }
                    else if (command == "left")
                    {
                        playerCol++;
                    }
                    else if (command == "right")
                    {
                        playerCol--;
                    }

                    continue;
                }

                if (matrix[playerRow, playerCol] != '-')
                {
                    word += matrix[playerRow, playerCol];
                    matrix[playerRow, playerCol] = '-';
                }
            }

            Console.WriteLine(word);

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
