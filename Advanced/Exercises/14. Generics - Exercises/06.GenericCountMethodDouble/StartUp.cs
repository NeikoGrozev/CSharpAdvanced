namespace GenericCountMethodDouble
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Box<double> collection = new Box<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                collection.Add(input);
            }

            double num = double.Parse(Console.ReadLine());

            Console.WriteLine(collection.Count(num));
        }
    }
}
