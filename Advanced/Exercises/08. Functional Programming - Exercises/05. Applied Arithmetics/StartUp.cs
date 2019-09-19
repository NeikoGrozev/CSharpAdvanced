namespace AppliedArithmetics
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] numbersCollection= Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                Func<int[], int[]> addFunction = numbers =>
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]++;
                    }

                    return numbers;
                };

                Func<int[], int[]> multiplyFunction = numbers =>
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] *= 2;
                    }

                    return numbers;
                };

                Func<int[], int[]> substractFunction = numbers =>
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }

                    return numbers;
                };

                Action<int[]> print = number
                    => Console.WriteLine(string.Join(" ", number));


                if (command == "end")
                {
                    break;
                }
                else if (command == "add")
                {
                    addFunction(numbersCollection);
                }
                else if (command == "multiply")
                {
                    multiplyFunction(numbersCollection);
                }
                else if (command == "subtract")
                {
                    substractFunction(numbersCollection);
                }
                else if(command == "print")
                {
                    print(numbersCollection);
                }
            }
        }
    }
}
