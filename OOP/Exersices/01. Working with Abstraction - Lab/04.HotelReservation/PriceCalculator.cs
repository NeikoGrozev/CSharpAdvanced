namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal pricePerDay, int numberOfDays, Season season, Discount discount)
        {
            decimal totalPrice = 0;

            decimal price = pricePerDay * numberOfDays * (int)season;
            decimal discountAmount = (decimal)discount / 100;

            totalPrice = price - (price * discountAmount);

            return totalPrice;
        }
    }
}
