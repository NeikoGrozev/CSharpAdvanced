namespace MXGP.Core
{
    using Contracts;
    using Models.Motorcycles;
    using Models.Motorcycles.Contracts;
    using Models.Races.Contracts;
    using Models.Riders;
    using Models.Riders.Contracts;
    using MXGP.Models.Races;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private const int MinRiders = 3;

        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;
        private RiderRepository riderRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
            this.riderRepository = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riderRepository.GetByName(riderName);
            IMotorcycle motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            else if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            IRider rider = this.riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcycle = null;

            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace currentRace = new Race(name, laps);

            this.raceRepository.Add(currentRace);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            IRider rider = new Rider(riderName);
            this.riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Riders.Count < MinRiders)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MinRiders));
            }

            List<IRider> sortedRiders = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, sortedRiders[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, sortedRiders[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, sortedRiders[2].Name, race.Name));

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
