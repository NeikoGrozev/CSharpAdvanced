namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int lifePoints = 50;

        public CivilPlayer(string name) 
            : base(name, lifePoints)
        {
        }
    }
}