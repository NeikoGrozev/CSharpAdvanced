namespace RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    class RecordUniqueNamesProg
    {
        static void Main()
        {
            HashSet<string> set = new HashSet<string>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();

                if (!set.Contains(name))
                {
                    set.Add(name);
                }
            }

            Console.WriteLine($"{string.Join(Environment.NewLine, set)}");
        }
    }
}
