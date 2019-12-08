namespace PlayersAndMonsters.Models.BattleFields
{
    using Contracts;
    using Players;
    using Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        private const int extraHealthPointsForBeginer = 40;
        private const int extraDamagePointsToCards = 30;
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            CheckPlayerIsDead(attackPlayer);
            CheckPlayerIsDead(enemyPlayer);

            CheckPlayerIsBeginner(attackPlayer);
            CheckPlayerIsBeginner(enemyPlayer);

            while (true)
            {
                int attackPlayerAllDamage = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerAllDamage);

                if(enemyPlayer.IsDead)
                {
                    break;
                }

                int enemyPlayerAllDamage = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerAllDamage);

                if(attackPlayer.IsDead)
                {
                    break;
                }

            }
        }

        private void CheckPlayerIsDead(IPlayer player)
        {
            if(player.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
        }

        private void CheckPlayerIsBeginner(IPlayer player)
        {
            if(player.GetType() == typeof(Beginner))
            {
                player.Health += extraHealthPointsForBeginer;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += extraDamagePointsToCards;
                }
            }
        }
    }
}