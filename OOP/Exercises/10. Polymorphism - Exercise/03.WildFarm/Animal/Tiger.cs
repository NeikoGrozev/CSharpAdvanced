namespace WildFarm.Animal
{
    using System.Collections.Generic;
    using Food;

    public class Tiger : Felines
    {
        private const double pieceOfFood = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}