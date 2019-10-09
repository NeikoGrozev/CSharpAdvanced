namespace PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        private string name;
        private int numbersOfBadges;
        private List<Pokemon> collectionOfPokemon;

        public Trainer()
        {
            this.Name = string.Empty;
            this.numbersOfBadges = 0;
            this.collectionOfPokemon = new List<Pokemon>();
        }

        public Trainer(string name)
            : this()
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int NumberOfBadges
        {
            get
            {
                return this.numbersOfBadges;
            }
            set
            {
                this.numbersOfBadges = value;
            }
        }

        public List<Pokemon> CollectionOfPokemon
        {
            get
            {
                return this.collectionOfPokemon;
            }
        }

        public void AddBadges()
        {
            this.numbersOfBadges++;
        }

        public void ReduciceHealth()
        {
            this.CollectionOfPokemon.ForEach(x => x.Health -= 10);
        }

        public void RemovePokemon()
        {
            this.CollectionOfPokemon.RemoveAll(x => x.Health <= 0);
        }

        public void AddPokemon(Pokemon pokemon)
        {
            this.CollectionOfPokemon.Add(pokemon);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.CollectionOfPokemon.Count}";
        }
    }
}
