namespace SquareRoor
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if(number < 0)
                {
                    throw new ArgumentException();
                }

                double result = Math.Sqrt(number);

                Console.WriteLine(result);
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}