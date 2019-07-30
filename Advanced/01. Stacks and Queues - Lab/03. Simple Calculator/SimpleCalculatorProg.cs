namespace SimpleCalculator
{
    using System;
        using System.Collections.Generic;
    using System.Linq;

    class SimpleCalculatorProg
    {
        static void Main()
        {
            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(array.Reverse());
            
            while (stack.Count != 1)
            {
                int firstDigit = int.Parse(stack.Pop());
                string symbol = stack.Pop();
                int secondDigit = int.Parse(stack.Pop());

                if (symbol == "+")
                {
                    stack.Push((firstDigit + secondDigit).ToString());
                }
                else if (symbol == "-")
                {
                    stack.Push((firstDigit - secondDigit).ToString());
                }
            }

            Console.WriteLine(stack.Pop());                
        }
    }
}
