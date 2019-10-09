namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon()
        {
            this.Name = string.Empty;
            this.Element = string.Empty;
            this.Health = 0;
        }

        public Pokemon(string name, string element, int health)
            : this()
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }
    }
}
