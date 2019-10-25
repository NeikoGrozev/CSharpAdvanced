namespace SummerCocktails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            const int mimosa = 150;
            const int daiquiri = 250;
            const int sunshine = 300;
            const int mojito = 400;

            int[] ingredientsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] freshnessInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredients = new Queue<int>(ingredientsInput);
            Stack<int> freshness = new Stack<int>(freshnessInput);

            Dictionary<string, int> table = new Dictionary<string, int>();
            table["Mimosa"] = 0;
            table["Daiquiri"] = 0;
            table["Sunshine"] = 0;
            table["Mojito"] = 0;


            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();
                int currentFresh = freshness.Pop();

                if (currentIngredient == 0)
                {
                    freshness.Push(currentFresh);
                    continue;
                }

                int mix = currentIngredient * currentFresh;

                if (mix == mimosa)
                {
                    table["Mimosa"]++;
                }
                else if (mix == daiquiri)
                {
                    table["Daiquiri"]++;
                }
                else if (mix == sunshine)
                {
                    table["Sunshine"]++;
                }
                else if (mix == mojito)
                {
                    table["Mojito"]++;
                }
                else
                {
                    ingredients.Enqueue(currentIngredient + 5);
                }
            }

            bool isPartyTime = table.Any(x => x.Value == 0);

            if (!isPartyTime)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");

                if (ingredients.Count > 0)
                {
                    int sum = ingredients.Sum();
                    Console.WriteLine($"Ingredients left: {sum}");
                }
            }

            foreach (var cocktail in table.OrderBy(x => x.Key).Where(x => x.Value != 0))
            {
                Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
            }
        }
    }
}
