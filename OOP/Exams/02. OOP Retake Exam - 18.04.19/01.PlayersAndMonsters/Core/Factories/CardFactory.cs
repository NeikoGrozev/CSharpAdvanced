namespace PlayersAndMonsters.Core.Factories
{
    using Contracts;
    using Models.Cards.Contracts;
    using Models.Cards;
    using System;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            switch (type)
            {
                case "Trap":
                    card = new TrapCard(name);
                    break;
                case "Magic":
                    card = new MagicCard(name);
                    break;
                default:
                    throw new ArgumentException("Card of this type does not exists!");
            }

            return card;
        }
    }
}