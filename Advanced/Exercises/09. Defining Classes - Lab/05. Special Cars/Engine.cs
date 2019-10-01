namespace CarManufacturer
{
    using System;

    public class Engine
    {
        private int horsePower;

        private double cubicCapacity;

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                this.horsePower = value;
            }
        }

        public double CubicCapacity
        {
            get
            {
                return this.cubicCapacity;
            }
            set
            {
                this.cubicCapacity = value;
            }
        }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.horsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}