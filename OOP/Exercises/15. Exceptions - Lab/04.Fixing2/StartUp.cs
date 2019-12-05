namespace Fixing2
{
    using System;

    class StartUp
    {
        static void Main()
        {
            try
            {
                int num1 = 30;
                int num2 = 60;
                byte result;

                result = Convert.ToByte(num1 * num2);

                Console.WriteLine($"{num1} * {num2} = {result}");
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
         }
    }
}