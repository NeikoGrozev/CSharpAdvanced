using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int healthPoints = 250;
        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, healthPoints)
        {
        }
    }
}