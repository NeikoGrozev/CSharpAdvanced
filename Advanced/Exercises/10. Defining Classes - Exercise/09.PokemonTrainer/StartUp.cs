namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    newTrainer.AddPokemon(pokemon);
                    trainers.Add(newTrainer);
                }
                else
                {
                    var currentTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                    currentTrainer.CollectionOfPokemon.Add(pokemon);
                }
            }

            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }
                else if (element != "Fire" && element != "Water" && element != "Electricity")
                {
                    continue;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.CollectionOfPokemon.Any(x => x.Element == element))
                    {
                        trainer.AddBadges();
                    }
                    else
                    {
                        trainer.ReduciceHealth();
                        trainer.RemovePokemon();
                    }
                }
            }

            foreach (var item in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine(item);
            }
        }
    }
}
