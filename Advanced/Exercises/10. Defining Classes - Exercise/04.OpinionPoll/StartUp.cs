namespace DefiningClasses
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person member = new Person(name, age);

                family.AddMember(member);
            }

            List<Person> oldestPeople = family.GetOldestPeople();

            foreach (var people in oldestPeople.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{people.Name} - {people.Age}");

            }

        }
    }
}