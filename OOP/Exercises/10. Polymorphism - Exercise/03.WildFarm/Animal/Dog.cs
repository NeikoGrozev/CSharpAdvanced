namespace WildFarm.Animal
{
    using System.Collections.Generic;
    using Food;

    public class Dog : Mammal
    {
        private const double pieceOfFood = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
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
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}