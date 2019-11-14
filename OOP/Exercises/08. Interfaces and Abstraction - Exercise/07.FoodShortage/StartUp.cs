namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            List<IBuyer> people = new List<IBuyer>();

            for (int i = 0; i < num; i++)
            {
                string[] args = Console.ReadLine()
                    .Split();

                if (args.Length == 4)
                {
                    people.Add(new Citizen(args[0], int.Parse(args[1]), args[2], args[3]));
                }
                else if (args.Length == 3)
                {
                    people.Add(new Rebel(args[0], int.Parse(args[1]), args[2]));
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else if (people.Any(x => x.Name == input))
                {
                    people.First(x => x.Name == input).BuyFood();
                }
            }

            Console.WriteLine(people.Sum(x => x.Food));
        }
    }
}