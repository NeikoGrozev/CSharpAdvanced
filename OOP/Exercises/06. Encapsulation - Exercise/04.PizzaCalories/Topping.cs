namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const double baseCaloriesPerGram = 2;

        private string type;
        private double weight;
        private Dictionary<string, double> allTopiing;

        public Topping(string type, double weight)
        {
            this.allTopiing = new Dictionary<string, double>();
            this.SeedAllTopiing();
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!this.allTopiing.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            return baseCaloriesPerGram * this.Weight * this.allTopiing[this.Type.ToLower()];
        }

        private void SeedAllTopiing()
        {
            this.allTopiing.Add("meat", 1.2);
            this.allTopiing.Add("veggies", 0.8);
            this.allTopiing.Add("cheese", 1.1);
            this.allTopiing.Add("sauce", 0.9);
        }
    }
}