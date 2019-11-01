namespace RhombusOfStars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var rhombus = new Rhombus(n);

            Console.WriteLine(rhombus.PrintRow());
        }
    }
}
