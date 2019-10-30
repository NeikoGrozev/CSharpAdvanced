namespace HotelReservation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];
            string discountType = "None";

            var currentSeason = Enum.Parse(typeof(Season), season);

            if (input.Length == 4)
            {
                discountType = input[3];
            }

            var currentDiscount = Enum.Parse(typeof(Discount), discountType);

            decimal totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, (Season)currentSeason, (Discount)currentDiscount);

            Console.WriteLine($"{totalPrice:F2}");

        }
    }
}
