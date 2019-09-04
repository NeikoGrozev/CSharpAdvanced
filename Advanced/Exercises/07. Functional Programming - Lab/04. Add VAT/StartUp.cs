namespace AddVAT
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:F2}");
            }

        }
    }
}
