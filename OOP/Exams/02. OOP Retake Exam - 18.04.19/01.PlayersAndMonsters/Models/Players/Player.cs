namespace PlayersAndMonsters.Models.Players
{
    using Contracts;
    using Repositories.Contracts;
    using System;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.CardRepository = cardRepository;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            if(damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            int currentHealt = this.Health - damagePoints;
            this.Health = Math.Max(0, currentHealt);
        }
    }
}