namespace SpaceStation.Models.Mission
{
    using Astronauts.Contracts;
    using Planets;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(x => x.CanBreath))
            {
                while (true)
                {
                    if (!astronaut.CanBreath)
                    {
                        break;
                    }

                    if (planet.Items.Count == 0)
                    {
                        break;
                    }

                    string item = planet.Items.First();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}