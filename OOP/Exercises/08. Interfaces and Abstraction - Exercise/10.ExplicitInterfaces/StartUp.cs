namespace ExplicitInterfaces
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                string[] args = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = args[0];
                string country = args[1];
                int age = int.Parse(args[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
