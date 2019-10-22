namespace Repository
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Repository repo = new Repository();

            repo.Add(new Person("George", 10, new DateTime(2009, 05, 04)));
            repo.Add(new Person("Peter", 5, new DateTime(2014, 05, 24)));

            Person foundPerson = repo.Get(0);
            Console.WriteLine($"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");

            Person newPerson = new Person("John", 12, new DateTime(2007, 2, 3));
            Console.WriteLine(repo.Update(2, newPerson));// false
            Console.WriteLine(repo.Update(0, newPerson));// true

            foundPerson = repo.Get(0);
            Console.WriteLine($"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");
            //John is 12 years old (03/02/2007)

            Console.WriteLine(repo.Count); // 2

            Console.WriteLine(repo.Delete(5));// false
            Console.WriteLine(repo.Delete(0));// true

            Console.WriteLine(repo.Count); // 1
        }
    }
}
