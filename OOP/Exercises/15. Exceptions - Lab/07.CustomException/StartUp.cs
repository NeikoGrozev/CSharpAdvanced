namespace CustomException
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string name = Console.ReadLine();
                ValidateName validate = new ValidateName(name);
            }
            catch(InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}