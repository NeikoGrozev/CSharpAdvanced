namespace EnterNumbers
{
    using System;

    public class StartUp
    {


        public static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    RealNumber(start, end);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number");
                    i--;
                }
            }
        }

        public static void RealNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new InvalidOperationException();
            }
        }
    }
}