namespace GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Box<int> collection = new Box<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                collection.Add(input);
            }

            Console.WriteLine(collection.ToString());
        }
    }
}
