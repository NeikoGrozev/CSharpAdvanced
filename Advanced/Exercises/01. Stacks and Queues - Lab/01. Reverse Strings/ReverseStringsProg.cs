namespace ReverseStrings
{
    using System;    
    using System.Collections.Generic;

    class ReverseStringsProg
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>(input);

            Console.Write(string.Join("", stack));
        }
    }
}
