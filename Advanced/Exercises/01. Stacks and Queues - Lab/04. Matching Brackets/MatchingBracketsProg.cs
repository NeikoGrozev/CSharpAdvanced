namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;
   
    class MatchingBracketsProg
    {
        static void Main()
        {
            string input = Console.ReadLine();
               
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int index = stack.Pop();
                    int count = i - index + 1;
                    string str = input.Substring(index, count);

                    Console.WriteLine(str);
                }
            }
        }
    }
}
