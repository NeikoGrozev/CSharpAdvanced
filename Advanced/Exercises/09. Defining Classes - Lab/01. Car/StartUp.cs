namespace CarManufacturer
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "Passat";
            car.Year = 2011;

            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
        }
    }
}
