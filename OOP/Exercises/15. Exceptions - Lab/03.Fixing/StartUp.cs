﻿namespace Fixing
{
    using System;

    class StartUp
    {
        static void Main()
        {
            try
            {
                string[] weekdays = new string[5];
                weekdays[0] = "Sunday";
                weekdays[1] = "Monday";
                weekdays[2] = "Tuesday";
                weekdays[3] = "Wednesday";
                weekdays[4] = "Thursday";

                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                } 
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}