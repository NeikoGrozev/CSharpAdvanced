namespace TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> nameFunction = (name, num) =>
            {
                int nameSum = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    nameSum += name[i];
                }

                if (nameSum >= num)
                {
                    return true;
                }

                return false;
            };

            foreach (var name in names)
            {
                if (nameFunction(name, number))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
