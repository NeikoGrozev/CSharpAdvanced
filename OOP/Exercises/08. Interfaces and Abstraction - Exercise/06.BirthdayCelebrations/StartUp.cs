namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Society> society = new List<Society>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] args = input
                    .Split();

                if (args[0] == "Citizen")
                {
                    society.Add(new Citizen(args[1], int.Parse(args[2]), args[3], args[4]));
                }
                else if (args[0] == "Robot")
                {
                    society.Add(new Robot(args[1], args[2]));
                }
                else
                {
                    society.Add(new Pet(args[1], args[2]));
                }
            }

            string year = Console.ReadLine();

            foreach (var item in society)
            {
                if (item.FindingYear(year))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}