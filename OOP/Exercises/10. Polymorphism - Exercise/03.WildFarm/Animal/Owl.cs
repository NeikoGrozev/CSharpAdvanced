namespace WildFarm.Animal
{
    using System.Collections.Generic;
    using Food;

    public class Owl : Bird
    {
        private const double pieceOfFood = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override List<TypeFood> CurrentTypeEatFood
            => new List<TypeFood>
            {
                TypeFood.Meat
            };

        public override void AddWeight(int quantity)
        {
            this.Weight += quantity * pieceOfFood;
            this.FoodEaten += quantity;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}