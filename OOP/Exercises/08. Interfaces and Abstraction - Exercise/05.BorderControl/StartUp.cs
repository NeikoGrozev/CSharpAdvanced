namespace BorderControl
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

                if (args.Length == 3)
                {
                    society.Add(new Citizen(args[0], int.Parse(args[1]), args[2]));
                }
                else if (args.Length == 2)
                {
                    society.Add(new Robot(args[0], args[1]));

                }
            }

            string number = Console.ReadLine();

            foreach (var item in society)
            {
                if (item.FindingFakeId(number))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
