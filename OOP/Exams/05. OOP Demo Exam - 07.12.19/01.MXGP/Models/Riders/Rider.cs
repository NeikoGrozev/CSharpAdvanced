namespace MXGP.Models.Riders
{
    using Contracts;
    using Motorcycles.Contracts;
    using System;
    using Utilities.Messages;

    public class Rider : IRider
    {
        private const int MinNumberOfSymbols = 5;

        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNumberOfSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNumberOfSymbols));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if(motorcycle == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.MotorcycleInvalid));
            }

            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
