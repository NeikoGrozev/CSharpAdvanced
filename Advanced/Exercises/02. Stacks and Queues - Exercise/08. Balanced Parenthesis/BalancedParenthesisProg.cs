namespace BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    class BalancedParenthesisProg
    {
        static void Main()
        { 

            string input = Console.ReadLine();
            List<char> symbols = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsWhiteSpace(input[i]))
                {
                    continue;
                }

                symbols.Add(input[i]);
            }                       

            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (symbols[i] == '{' || symbols[i] == '(' || symbols[i] == '[')
                {
                    stack.Push(symbols[i]);
                }
                else 
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    char symbol = stack.Pop();

                    if (symbol == '{' && symbols[i] == '}')
                    {
                        continue;
                    }
                    else if (symbol == '(' && symbols[i] == ')')
                    {
                        continue;
                    }
                    else if (symbol == '[' && symbols[i] == ']')
                    {
                        continue;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
