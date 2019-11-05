namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] inputPersons = Console.ReadLine()
                .Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);

            string[] inputProducts = Console.ReadLine()
                .Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                List<Person> persons = new List<Person>();

                for (int i = 0; i < inputPersons.Length; i += 2)
                {
                    string currentPerson = inputPersons[i];
                    int currentBudget = int.Parse(inputPersons[i + 1]);

                    Person person = new Person(currentPerson, currentBudget);
                    persons.Add(person);
                }

                List<Product> products = new List<Product>();

                for (int i = 0; i < inputProducts.Length; i += 2)
                {
                    string currentProduct = inputProducts[i];
                    int currentSum = int.Parse(inputProducts[i + 1]);

                    Product product = new Product(currentProduct, currentSum);
                    products.Add(product);
                }

                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    string[] arguments = input
                        .Split();

                    string currentPerson = arguments[0];
                    string currentProduct = arguments[1];

                    Person person = persons.FirstOrDefault(x => x.Name == currentPerson);
                    Product product = products.FirstOrDefault(x => x.Name == currentProduct);

                    Console.WriteLine(person.BuyProduct(product));

                }

                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
