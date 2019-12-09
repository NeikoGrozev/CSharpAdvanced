namespace ViceCity.Models.Neghbourhoods
{
    using Contracts;
    using Players.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                foreach (var civilPlayer in civilPlayers.Where(x => x.IsAlive == true))
                {
                    while (true)
                    {
                        if (!civilPlayer.IsAlive)
                        {
                            break;
                        }

                        int gunShoot = gun.Fire();
                        civilPlayer.TakeLifePoints(gunShoot);

                        if (!gun.CanFire)
                        {
                            break;
                        }
                    }

                    if (!gun.CanFire)
                    {
                        break;
                    }
                }
            }

            foreach (var civilPlayer in civilPlayers)
            {
                foreach (var gun in civilPlayer.GunRepository.Models)
                {
                    while (true)
                    {
                        if (!mainPlayer.IsAlive)
                        {
                            break;
                        }

                        int gumShoot = gun.Fire();
                        mainPlayer.TakeLifePoints(gumShoot);

                        if (!gun.CanFire)
                        {
                            break;
                        }
                    }

                    if (!gun.CanFire)
                    {
                        break;
                    }
                }
            }
        }
    }
}