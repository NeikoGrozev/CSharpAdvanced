namespace JaggedArrayModification
{
using System;
    using System.Linq;

    class JaggedArrayModificationProg
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] digits = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = new int[digits.Length];

                for (int col = 0; col < digits.Length; col++)
                {
                    jaggedArray[row][col] = digits[col];
                }
            }

            while (true)
            {
                string[] token = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = token[0];

                if (command == "END")
                {
                    break;
                }

                int row = int.Parse(token[1]);
                int col = int.Parse(token[2]);
                int digit = int.Parse(token[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[row][col] += digit;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[row][col] -= digit;
                }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
