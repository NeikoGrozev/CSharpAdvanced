namespace SpaceStation.Core
{
    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Models.Mission;
    using Models.Planets;
    using Repositories;
    using Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities.Messages;

    public class Controller : IController
    {
        private const int currentOxygenForMission = 60;

        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private IMission mission;
        private int explorePlanet = 0;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            string message = string.Empty;
            IAstronaut astronaut = null;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:

                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }

            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            int astronautsCount = this.astronauts.Models.Count(x => x.Oxygen > currentOxygenForMission);

            if (astronautsCount == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }

            IPlanet currentPanet = this.planets.Models.FirstOrDefault(x => x.Name == planetName);
            ICollection<IAstronaut> astronauts = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            this.mission.Explore(currentPanet, astronauts);
            this.explorePlanet++;
          
            int deadAstronauts = this.astronauts.Models.Count(x => x.CanBreath == false);

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{explorePlanet} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                string message = string.Empty;

                if(astronaut.Bag.Items.Count == 0)
                {
                    message = "none";
                }
                else
                {
                    message = string.Join(", ", astronaut.Bag.Items);
                }

                sb.AppendLine($"Bag items: {message}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            string message = string.Empty;

            if (this.astronauts.Models.Any(x => x.Name == astronautName))
            {
                IAstronaut astronaut = this.astronauts.Models.FirstOrDefault(x => x.Name == astronautName);

                this.astronauts.Remove(astronaut);
                message = string.Format(OutputMessages.AstronautRetired, astronautName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            return message;
        }
    }
}