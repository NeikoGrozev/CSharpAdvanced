namespace PredicateForNames
{
    using System;

    class StartUp
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> nameFunction = name
                => name.Length <= length;

            Action<string> print = name 
                => Console.WriteLine(name);

            for (int i = 0; i < names.Length; i++)
            {
                if (nameFunction(names[i]))
                {
                    print(names[i]);
                }
            }
        }
    }
}
