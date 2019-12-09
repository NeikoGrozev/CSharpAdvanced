namespace PlayersAndMonsters.Core
{
    using Common;
    using Contracts;
    using Factories.Contracts;
    using Models.BattleFields.Contracts;
    using Models.Cards.Contracts;
    using Models.Players.Contracts;
    using Repositories.Contracts;
    using System.Linq;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerFactory playerFactory;
        private readonly IPlayerRepository playerRepository;
        private readonly ICardFactory cardFactory;
        private readonly ICardRepository cardRepository;
        private readonly IBattleField battleField;

        
        public ManagerController(IPlayerFactory playerFactory,
            IPlayerRepository playerRepository,
            ICardFactory cardFactory,
            ICardRepository cardRepository,
            IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Players.FirstOrDefault(x => x.Username == username);
            ICard card = this.cardRepository.Cards.FirstOrDefault(x => x.Name == cardName);

            player.CardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackerPlayer = this.playerRepository.Find(attackUser);
            IPlayer enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackerPlayer, enemyPlayer);

            string result = string.Format(ConstantMessages.FightInfo, attackerPlayer.Health, enemyPlayer.Health);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return sb.ToString().TrimEnd();
        }
    }
}