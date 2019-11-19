namespace WildFarm.Animal
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get => this.wingSize;
            protected set
            {
                this.wingSize = value;
            }
        }
    }
}