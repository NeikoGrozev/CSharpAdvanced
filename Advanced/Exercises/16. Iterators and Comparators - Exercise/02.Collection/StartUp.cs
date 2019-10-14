namespace ListIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            ListyIterator<string> setCollection = new ListyIterator<string>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToList();

                string command = input[0];

                if (command == "END")
                {
                    break;
                }
                else if (command == "Create")
                {
                    input.RemoveAt(0);
                    setCollection.Create(input);
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(setCollection.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(setCollection.Move());
                }
                else if (command == "Print")
                {
                    Console.WriteLine(setCollection.Print());
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(setCollection.PrintAll());                                          
                }
            }
        }
    }
}
