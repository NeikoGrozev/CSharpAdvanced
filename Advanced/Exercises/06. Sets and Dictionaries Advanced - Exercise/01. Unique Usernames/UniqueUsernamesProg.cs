namespace UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    class UniqueUsernamesProg
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();

                if (!set.Contains(name))
                {
                    set.Add(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
