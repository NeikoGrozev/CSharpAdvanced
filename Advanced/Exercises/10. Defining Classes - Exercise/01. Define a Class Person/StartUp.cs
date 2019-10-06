namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person = new Person();
            person.Name = name;
            person.Age = age;
        }
    }
}
