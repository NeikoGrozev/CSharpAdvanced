namespace DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string firstStr = Console.ReadLine();
            string secondStr = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifferenceBetwenTwoDays(firstStr, secondStr));
        }
    }
}
