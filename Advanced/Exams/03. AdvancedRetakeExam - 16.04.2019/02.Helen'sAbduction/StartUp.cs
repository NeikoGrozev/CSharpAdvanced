namespace HelenAbduction
{
    using System;

    class StartUpcs
    {
        static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int parisRow = -1;
            int parisCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }

            matrix[parisRow][parisCol] = '-';

            while (true)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandInfo[0];
                int spartanRow = int.Parse(commandInfo[1]);
                int spartanCol = int.Parse(commandInfo[2]);

                matrix[spartanRow][spartanCol] = 'S';

                if (command == "up")
                {
                    if (parisRow - 1 >= 0)
                    {
                        parisRow--;
                    }
                }
                else if (command == "down")
                {
                    if (parisRow + 1 < matrix.Length)
                    {
                        parisRow++;
                    }
                }
                else if (command == "left")
                {
                    if (parisCol - 1 >= 0)
                    {
                        parisCol--;
                    }
                }
                else if (command == "right")
                {
                    if (parisCol + 1 < matrix[parisRow].Length)
                    {
                        parisCol++;
                    }
                }

                energy--;

                if (matrix[parisRow][parisCol] == 'H')
                {
                    matrix[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    break;
                }
                else if (matrix[parisRow][parisCol] == 'S')
                {
                    energy -= 2;
                    matrix[parisRow][parisCol] = '-';
                }

                if (energy <= 0)
                {
                    matrix[parisRow][parisCol] = 'X';
                    Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    break;
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
