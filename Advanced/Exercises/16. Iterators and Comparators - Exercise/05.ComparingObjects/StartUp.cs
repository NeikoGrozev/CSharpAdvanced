namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            List<Person> peoples = new List<Person>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (input[0] == "END")
                {
                    break;
                }

                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];

                Person person = new Person(name, age, town);
                peoples.Add(person);
            }

            int compareIndex = int.Parse(Console.ReadLine()) - 1;
            int count = 0;

            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[compareIndex].CompareTo(peoples[i]) == 0)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{count} {peoples.Count - count} {peoples.Count}");
            }
        }
    }
}
