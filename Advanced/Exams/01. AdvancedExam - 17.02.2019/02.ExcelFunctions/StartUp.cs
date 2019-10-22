namespace ExcelFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> header = Console.ReadLine()
                .Split(", ")
                .ToList();

            string[][] jaggedArray = new string[n - 1][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(", ");
            }

            string[] commandInfo = Console.ReadLine()
                .Split();

            string command = commandInfo[0];
            string headerColumn = commandInfo[1];

            int column = header.IndexOf(headerColumn);

            if (command == "hide")
            {
                header.RemoveAt(column);

                for (int row = 0; row < jaggedArray.Length; row++)
                {
                    List<string> temp = jaggedArray[row].ToList();
                    temp.RemoveAt(column);
                    jaggedArray[row] = temp.ToArray();
                }
            }
            else if (command == "sort")
            {
                jaggedArray = jaggedArray.OrderBy(x => x[column]).ToArray();
            }
            else if (command == "filter")
            {
                string value = commandInfo[2];                
                jaggedArray = jaggedArray.Where(x => x[column] == value).ToArray();                
            }

            Console.WriteLine(string.Join(" | ", header));

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.Write(string.Join(" | ", jaggedArray[row]));
                Console.WriteLine();
            }
        }
    }    
}

