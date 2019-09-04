namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            Func<string, bool> cheker = w => w[0] == w.ToUpper()[0];

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(cheker)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
