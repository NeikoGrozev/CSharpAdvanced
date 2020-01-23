namespace AquaShop.Models.Aquariums
{
    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in this.fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            string currentFish = string.Empty;

            if (this.fish.Count != 0)
            {
                currentFish = $"{string.Join(", ", this.Fish.Select(f => f.Name).ToList())}";
            }
            else
            {
                currentFish = "none";
            }

            sb.AppendLine($"Fish: { currentFish}");
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
