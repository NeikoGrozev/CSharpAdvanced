namespace WildFarm.Animal
{
    using System.Collections.Generic;
    using Food;

    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            protected set
            {
                this.weight = value;
            }
        }
        public int FoodEaten { get; set; }

        public abstract List<TypeFood> CurrentTypeEatFood { get; }

        public abstract void AddWeight(int quantity);

        public abstract string ProduceSound();
    }
}