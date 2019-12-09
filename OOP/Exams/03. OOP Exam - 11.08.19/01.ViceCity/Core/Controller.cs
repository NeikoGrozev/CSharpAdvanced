namespace ViceCity.Core
{
    using Contracts;
    using Models.Guns;
    using Models.Guns.Contracts;
    using Models.Neghbourhoods;
    using Models.Players;
    using Models.Players.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private List<IGun> gunRepository;
        private List<IPlayer> civilPlayers;
        private MainPlayer mainPlayer;
        private GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.gunRepository = new List<IGun>();
            this.civilPlayers = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            string message = string.Empty;

            IGun gun = null;

            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name);
                    break;
                case "Rifle":
                    gun = new Rifle(name);
                    break;
                default:

                    return "Invalid gun type!";
            }

            this.gunRepository.Add(gun);

            message = $"Successfully added {name} of type: {type}";

            return message;

        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = this.gunRepository.First();
            

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);
                this.gunRepository.Remove(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            if(!this.civilPlayers.Any(x => x.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }

            IPlayer civilPlayer = this.civilPlayers.FirstOrDefault(x => x.Name == name);
            civilPlayer.GunRepository.Add(gun);
            this.gunRepository.Remove(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            this.civilPlayers.Add(new CivilPlayer(name));

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int totalPointsOfMainPlayer = this.mainPlayer.LifePoints;
            int totalPointsOfAllCivilPlayers = this.civilPlayers.Sum(x => x.LifePoints);
            int totalPoint = totalPointsOfMainPlayer + totalPointsOfAllCivilPlayers;

            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            int totalPointsOfMainPlayerAfterAction = this.mainPlayer.LifePoints;
            int totalPointsOfAllCivilPlayersAfterActon = this.civilPlayers.Sum(x => x.LifePoints);
            int totalPointsAfterAction = totalPointsOfMainPlayerAfterAction 
                + totalPointsOfAllCivilPlayersAfterActon;

            if(totalPoint == totalPointsAfterAction)
            {
                return "Everything is okay!";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("A fight happened:");
            sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
            sb.AppendLine($"Tommy has killed: {this.civilPlayers.Count(x => !x.IsAlive)} players!");
            sb.AppendLine($"Left Civil Players: {this.civilPlayers.Count(x => x.IsAlive)}!");

            return sb.ToString().TrimEnd();
        }
    }
}