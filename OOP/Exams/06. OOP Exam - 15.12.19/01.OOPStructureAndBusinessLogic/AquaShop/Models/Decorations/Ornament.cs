namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DefaultComfort = 1;
        private const int DefaultPrice = 5;

        public Ornament()
            : base(DefaultComfort, DefaultPrice)
        {
        }
    }
}
