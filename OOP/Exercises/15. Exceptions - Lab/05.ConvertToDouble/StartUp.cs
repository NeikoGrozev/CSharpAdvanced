namespace ConvertToDouble
{
    using System;

    class StartUp
    {
        static void Main()
        {
            try
            {
                string num = Console.ReadLine();
                double result = Convert.ToDouble(num);

                Console.WriteLine(result);
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}