namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            StackOfStrings stackOfString = new StackOfStrings();

            Console.WriteLine(stackOfString.IsEmpty());

            List<string> temp = new List<string> { "1", "2", "3", "4", "5" };

            stackOfString.AddRange(temp);

            Console.WriteLine(string.Join(" ", stackOfString));
        }
    }
}
