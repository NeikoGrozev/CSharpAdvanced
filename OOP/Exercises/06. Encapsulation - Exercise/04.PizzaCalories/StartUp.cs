namespace PizzaCalories
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string[] inputPizza = Console.ReadLine()
                    .Split();

                string pizzaName = inputPizza[1];

                string input = Console.ReadLine();

                string[] arguments = input
                       .Split();

                string typeProduct = arguments[0];
                string flourType = arguments[1];
                string bakingTechnique = arguments[2];
                double weight = double.Parse(arguments[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string inputToping = Console.ReadLine();

                    if (inputToping == "END")
                    {
                        break;
                    }

                    string[] argumenrsTopiing = inputToping
                        .Split();

                    string typeProduct2 = argumenrsTopiing[0];
                    string typeTopiing = argumenrsTopiing[1];
                    double weightTopiing = double.Parse(argumenrsTopiing[2]);

                    Topping topping = new Topping(typeTopiing, weightTopiing);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

