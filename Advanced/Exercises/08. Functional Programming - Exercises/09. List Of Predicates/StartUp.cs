namespace ListOfPredicates
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] divisibleNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isTrue = false;

            Predicate<int> divisibleFunction = number =>
            {
                for (int i = 0; i < divisibleNumbers.Length; i++)
                {
                    if (number % divisibleNumbers[i] == 0)
                    {
                        isTrue = true;
                    }
                    else
                    {
                        isTrue = false;
                        break;
                    }
                }
                return isTrue;
            };

            for (int i = 1; i <= endOfRange; i++)
            {
                if (divisibleFunction(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
