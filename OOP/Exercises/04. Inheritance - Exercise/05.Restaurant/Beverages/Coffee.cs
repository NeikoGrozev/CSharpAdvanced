namespace Restaurant.Beverages
{
    public class Coffee : HotBeverage
    {
        private const decimal price = 3.50M;
        private const double milliliters = 50;

        public Coffee(string name, double caffeine)
            : base(name, price, milliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; protected set; }
    }
}
