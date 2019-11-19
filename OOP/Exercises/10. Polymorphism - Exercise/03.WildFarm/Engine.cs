namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Animal;
    using Food;

    public class Engine
    {
        List<IAnimal> animals = new List<IAnimal>();

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] inputArgs = input
                    .Split();

                string animalType = inputArgs[0];
                string name = inputArgs[1];
                double weight = double.Parse(inputArgs[2]);

                IAnimal currentAnimal = null;

                if(animalType == "Owl")
                {
                    double wingSize = double.Parse(inputArgs[3]);
                    currentAnimal = new Owl(name, weight, wingSize);                    
                }
                else if(animalType == "Hen")
                {
                    double wingSize = double.Parse(inputArgs[3]);
                    currentAnimal = new Hen(name, weight, wingSize);                    
                }
                else if(animalType == "Mouse")
                {
                    string livingRegion = inputArgs[3];
                    currentAnimal = new Mouse(name, weight, livingRegion);
                }
                else if(animalType == "Dog")
                {
                    string livingRegion = inputArgs[3];
                    currentAnimal = new Dog(name, weight, livingRegion);
                }
                else if(animalType == "Cat")
                {
                    string livingRegion = inputArgs[3];
                    string breed = inputArgs[4];
                    currentAnimal = new Cat(name, weight, livingRegion, breed);
                }
                else if(animalType == "Tiger")
                {
                    string livingRegion = inputArgs[3];
                    string breed = inputArgs[4];
                    currentAnimal = new Tiger(name, weight, livingRegion, breed);
                }

                animals.Add(currentAnimal);

                string[] foodArgs = Console.ReadLine()
                    .Split();

                string foodType = foodArgs[0];
                int quantity = int.Parse(foodArgs[1]);

                Console.WriteLine(currentAnimal.ProduceSound());

                if (!currentAnimal.CurrentTypeEatFood.Any(x => x == Enum.Parse<TypeFood>(foodType)))
                {
                    Console.WriteLine($"{currentAnimal.GetType().Name} does not eat {foodType}!");
                }
                else
                {
                    currentAnimal.AddWeight(quantity);
                }                
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}