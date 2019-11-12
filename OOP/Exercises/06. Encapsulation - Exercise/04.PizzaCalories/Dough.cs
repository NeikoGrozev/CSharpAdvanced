namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double BaseCalotiesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> validFlourTypeDough;
        private Dictionary<string, double> validBakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.validFlourTypeDough = new Dictionary<string, double>();
            this.validBakingTechnique = new Dictionary<string, double>();
            this.SeedValidFlourTypeDough();
            this.SeedValidBakingTechnique();
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if(!validFlourTypeDough.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!validBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            return (BaseCalotiesPerGram * this.Weight) * this.validFlourTypeDough[this.FlourType.ToLower()] * validBakingTechnique[this.BakingTechnique.ToLower()];
        }

        private void SeedValidFlourTypeDough()
        {
            validFlourTypeDough.Add("white", 1.5);
            validFlourTypeDough.Add("wholegrain", 1.0);

        }

        private void SeedValidBakingTechnique()
        {
            validBakingTechnique.Add("crispy", 0.9);
            validBakingTechnique.Add("chewy", 1.1);
            validBakingTechnique.Add("homemade", 1.0);
        }
    }
}