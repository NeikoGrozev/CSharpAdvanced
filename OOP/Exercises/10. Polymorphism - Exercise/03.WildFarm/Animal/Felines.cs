namespace WildFarm.Animal
{
    public abstract class Felines : Mammal
    {
        private string breed;

        public Felines(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get => this.breed;
            private set
            {
                this.breed = value;
            }
        }
    }
}