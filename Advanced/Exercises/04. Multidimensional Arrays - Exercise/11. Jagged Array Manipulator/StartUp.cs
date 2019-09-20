namespace JaggedArrayManipulator
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                double[] numbers = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = new double[numbers.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = numbers[col];
                }
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int tempRow = row; tempRow <= row + 1; tempRow++)
                    {
                        for (int tempCol = 0; tempCol < jaggedArray[tempRow].Length; tempCol++)
                        {
                            jaggedArray[tempRow][tempCol] *= 2;
                        }
                    }
                }
                else
                {
                    for (int tempRow = row; tempRow <= row + 1; tempRow++)
                    {
                        for (int tempCol = 0; tempCol < jaggedArray[tempRow].Length; tempCol++)
                        {
                            jaggedArray[tempRow][tempCol] /= 2;
                        }
                    }
                }
            }

            while (true)
            {
                string[] token = Console.ReadLine()
                    .Split();

                string command = token[0];

                if (command == "End")
                {
                    break;
                }
                else if (command == "Add")
                {
                    int row = int.Parse(token[1]);
                    int col = int.Parse(token[2]);
                    double value = double.Parse(token[3]);

                    if (row >= 0 && row < jaggedArray.Length 
                        && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] += value;
                    }
                }
                else if (command == "Subtract")
                {
                    int row = int.Parse(token[1]);
                    int col = int.Parse(token[2]);
                    double value = double.Parse(token[3]);

                    if (row >= 0 && row < jaggedArray.Length 
                        && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }
    }
}
