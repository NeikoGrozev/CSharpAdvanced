namespace MXGP.Models.Motorcycles
{
    using System;
    using Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle
    {

        private const double CurrentCubicCentimeters = 125;
        private const int CurrentMinHorsePower = 50;
        private const int CurrentMaxHorsePower = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, CurrentCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < CurrentMinHorsePower || value > CurrentMaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
