namespace CountSameValuesInArray
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSameValuesInArrayProg
    {
        static void Main()
        {
            double[] digits = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            for (int i = 0; i < digits.Length; i++)
            {
                if (!dict.ContainsKey(digits[i]))
                {
                    dict.Add(digits[i], 0);
                }

                dict[digits[i]]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
