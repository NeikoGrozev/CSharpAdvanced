namespace KnightsOfHonor
{
    using System;

    class StartUp
    {
        static void Main()
        {
            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printName = name 
                => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", inputNames));

            printName(inputNames);
        }
    }
}
