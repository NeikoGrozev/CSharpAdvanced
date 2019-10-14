namespace Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var stone = new Lake(input);

            Console.WriteLine(string.Join(", ", stone));
        }
    }
}
