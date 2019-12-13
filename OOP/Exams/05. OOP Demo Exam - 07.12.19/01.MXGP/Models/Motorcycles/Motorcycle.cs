namespace MXGP.Models.Motorcycles
{
    using Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int MinNumberOfSymbols = 4;

        private string model;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < MinNumberOfSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MinNumberOfSymbols));
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }
        
        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double result = this.CubicCentimeters / (this.HorsePower * laps);

            return result;
        }
    }
}
