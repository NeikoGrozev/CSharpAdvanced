namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int DefaultSize = 3;
        private const int DefaultEat = 3;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = DefaultSize;
        }

        public override void Eat()
        {
            this.Size += DefaultEat;
        }
    }
}
