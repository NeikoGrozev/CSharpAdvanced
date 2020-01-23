namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int DefaultSize = 5;
        private const int DefaultEat = 2;

        public SaltwaterFish(string name, string species, decimal price)
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
