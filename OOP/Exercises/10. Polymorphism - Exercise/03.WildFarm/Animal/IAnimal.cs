namespace WildFarm.Animal
{
    using System.Collections.Generic;
    using Food;

    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        List<TypeFood> CurrentTypeEatFood { get; }

        void AddWeight(int quantity);

        string ProduceSound();
    }
}