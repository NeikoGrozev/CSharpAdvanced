namespace WildFarm.Animal
{
    using System.Collections.Generic;
    using Food;

    public class Hen : Bird
    {
        private const double pieceOfFood = 0.35;

        public Hen(string name, double weight, double wingSize)
                 : base(name, weight, wingSize)
        {
        }

        public override List<TypeFood> CurrentTypeEatFood
            => new List<TypeFood>
            {
                TypeFood.Vegetable,
                TypeFood.Fruit,
                TypeFood.Meat,
                TypeFood.Seeds
            };

        public override void AddWeight(int quantity)
        {
            this.Weight += quantity * pieceOfFood;
            this.FoodEaten += quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}