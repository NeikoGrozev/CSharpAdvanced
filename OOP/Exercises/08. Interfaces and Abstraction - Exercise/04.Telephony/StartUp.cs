namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine()
                .Split()
                .ToList();

            List<string> webAddresses = Console.ReadLine()
                .Split()
                .ToList();

            SmartPhone smartPhone = new SmartPhone();
            
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(smartPhone.Calling(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var webAddress in webAddresses)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browsing(webAddress));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}