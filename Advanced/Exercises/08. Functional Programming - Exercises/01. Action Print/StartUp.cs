namespace ActionPrint
{
    using System;

    class StartUp
    {
        static void Main()
        {
            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printName = name 
                => Console.WriteLine(string.Join(Environment.NewLine, inputNames));

            printName(inputNames);
        }
    }
}
