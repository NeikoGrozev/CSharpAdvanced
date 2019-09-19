namespace CustomMinFunction
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int minValue = int.MaxValue;

            Func<int[], int> minFunctions = numbers =>
            {
                foreach (var number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }

                return minValue;
            };

            Action<int> printNumber = number
                => Console.WriteLine(number);

            int minNumber = minFunctions(inputNumbers);
            printNumber(minNumber);
        }
    }
}
