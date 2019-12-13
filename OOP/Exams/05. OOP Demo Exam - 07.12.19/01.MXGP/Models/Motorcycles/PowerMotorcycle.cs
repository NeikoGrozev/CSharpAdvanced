namespace MXGP.Models.Motorcycles
{
    using Utilities.Messages;
    using System;

    public class PowerMotorcycle : Motorcycle
    {
        private const double CurrentCubicCentimeters = 450;
        private const int CurrentMinHorsePower = 70;
        private const int CurrentMaxHorsePower = 100;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CurrentCubicCentimeters)
        {           
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if(value < CurrentMinHorsePower || value > CurrentMaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
