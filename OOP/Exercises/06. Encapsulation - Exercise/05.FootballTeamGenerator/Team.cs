namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void Add(Player player)
        {
            if (!players.Contains(player))
            {
                players.Add(player);
            }
        }

        public void Remove(string playerName)
        {
            if (!players.Any(x => x.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(this.players.FirstOrDefault(x => x.Name == playerName));
        }

        public override string ToString()
        {
            int raiting = 0;

            if (this.players.Count != 0)
            {
                raiting = (int)Math.Round((this.players.Sum(x => x.Stats)) / this.players.Count);
            }

            return $"{this.Name} - {raiting}";
        }
    }
}
