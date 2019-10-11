namespace GenericSwapMethodString
{
    using System;
    using System.Linq;

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

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            collection.Swap(firstIndex, secondIndex);

            Console.WriteLine(collection.ToString());
        }
    }
}
