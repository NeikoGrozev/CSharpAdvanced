namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                sortedSet.Add(person);
                hashSet.Add(person); 
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
