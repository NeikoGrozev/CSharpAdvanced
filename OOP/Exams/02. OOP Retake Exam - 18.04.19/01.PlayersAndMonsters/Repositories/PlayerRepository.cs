namespace PlayersAndMonsters.Repositories
{
    using Contracts;
    using Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if(player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if(this.players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players.FirstOrDefault(x => x.Username == username);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if(player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            bool isRemove = this.players.Remove(player);

            return isRemove;
        }
    }
}