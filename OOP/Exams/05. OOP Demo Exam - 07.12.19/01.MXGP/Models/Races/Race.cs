namespace MXGP.Models.Races
{
    using Contracts;
    using Riders.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities.Messages;

    public class Race : IRace
    {
        private const int MinNumbersOfSymbols = 5;
        private const int MinNumberOfLaps = 1;

        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNumbersOfSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNumbersOfSymbols));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if(value < MinNumberOfLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinNumberOfLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if(rider == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderInvalid));
            }
            else if(!rider.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }
            else if(this.Riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
