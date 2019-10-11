namespace GenericBoxOfString
{
    using System;
   
    public class StartUp
    {
        public static void Main()
        {

            Box<string> collection = new Box<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                collection.Add(input);
            }

            Console.WriteLine(collection.ToString());
        }
    }
}
