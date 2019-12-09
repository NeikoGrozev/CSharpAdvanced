namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string name = "Tommy Vercetti";
        private const int lifePoints = 100;

        public MainPlayer() 
            : base(name, lifePoints)
        {
        }
    }
}